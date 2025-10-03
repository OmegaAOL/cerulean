using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Cerulean.LangPacks;
using Newtonsoft.Json.Linq;
using LibPurple;
using OmegaAOL.SkyBridge;

namespace Cerulean
{
    public partial class Menu_Login : Form
    {
        /* ===== Constants ===== */
        private const string DEBUGCODE_LEAD = "$";
        private const string REG_PATH_LOGINDATA = "\\LoginData";
        private const string REG_KEY_HANDLE = "handle";
        private const string REG_KEY_PASSWORD = "password";
        private static readonly string[] LOCALMSG_DEFAULT = new string[2] { LangPack.LOGIN_LOCALMSG_DEFAULT, LangPack.LOGIN_LOCALMSG_DEFAULT_SUB };
        private static readonly string[] LOCALMSG_EMPTY_FIELD = new string[2] { LangPack.GLOBAL_INFOLABEL_EMPTY_FIELDS, LangPack.LOGIN_LOCALMSG_EMPTY_FIELD_SUB };
        private static readonly string[] LOCALMSG_INVALID_DEBUGCODE = new string[2] { LangPack.LOGIN_LOCALMSG_INVALID_DEBUGCODE, LangPack.LOGIN_LOCALMSG_INVALID_DEBUGCODE_SUB };
        private static readonly string[] LOCALMSG_CONNECTING_TO_PDS = new string[2] { LangPack.LOGIN_LOCALMSG_CONNECTING_TO_PDS, LangPack.LOGIN_LOCALMSG_CONNECTING_TO_PDS_SUB };

        public Menu_Login()
        {
            InitializeComponent();
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            MaximizeBox = false;
        }

        private void LocalizeControlText()
        {
            this.Text = LangPack.LOGIN_WINTITLE;
            header.Text = LOCALMSG_DEFAULT[0];
            descriptor.Text = LOCALMSG_DEFAULT[1];
            newAccountButton.Text = LangPack.LOGIN_LINKLABEL_NEWACCOUNT;
            handleLabel.Text = LangPack.LOGIN_LABEL_HANDLE;
            passwordLabel.Text = LangPack.LOGIN_LABEL_PASSWORD;
            forgotPasswordButton.Text = LangPack.LOGIN_BUTTON_FORGOTPASS;
            loginButton.Text = LangPack.LOGIN_BUTTON_LOGIN;
            changePdsHostButton.Text = LangPack.LOGIN_BUTTON_CHANGEPDS;
            rememberMeBox.Text = LangPack.LOGIN_CHECKBOX_REMEMBER_CREDENTIALS;
        }

        private void Menu_Login_Load(object sender, EventArgs e)
        {
            CenterToParent();
            LocalizeControlText();
            CheckSavedCred();
            this.AcceptButton = loginButton;
            BackgroundImage = ThemeDefinitions.Background;
            Variables.PDSHost = RegKit.Read.String("API", "PDSHost");
        }

        public void displayError(string[] strArray) // called to display error message
        {
            timeOutBar.MarqueeAnimationSpeed = 0;
            timeOutBar.Invalidate();
            header.Text = strArray[0];
            descriptor.Text = strArray[1];
            header.ForeColor = ThemeDefinitions.TextError;
            timeOutBar.Value = 0;
            ToggleControls(true);
        }

        private void loginButton_Click(object sender, EventArgs ev)
        {
            InitLogin(handleBox.Text, passwordBox.Text);
        }

        private void ToggleControls(bool enabled, bool newAccEnabled = false)
        {
            handleBox.Enabled = enabled;
            passwordBox.Enabled = enabled;
            loginButton.Enabled = enabled;
            forgotPasswordButton.Enabled = enabled;
            changePdsHostButton.Enabled = enabled;
            newAccountButton.Visible = newAccEnabled;
            rememberMeBox.Enabled = enabled;
        }

        private void InitLogin(string handle, string password)
        {
            ToggleControls(false);

            Variables.Handle = handle; // set variables to handle and password

            if (string.IsNullOrEmpty(Variables.Handle) || string.IsNullOrEmpty(password))
            {
                if (Variables.Handle.StartsWith("$"))
                {
                    switch (Variables.Handle.Substring(1, Variables.Handle.Length - 1).ToLower())
                    {
                        case "offline":
                            EnterOfflineMode();
                            return;
                        default:
                            displayError(LOCALMSG_INVALID_DEBUGCODE);
                            return;
                    }
                }
                else
                {
                    displayError(LOCALMSG_EMPTY_FIELD);
                    return;
                }
            }

            Variables.Handle = Variables.Handle.Replace("@", String.Empty);
            timeOutBar.MarqueeAnimationSpeed = 10;

            header.Text = LOCALMSG_CONNECTING_TO_PDS[0];
            header.ForeColor = ThemeDefinitions.TextSuccess;
            descriptor.Text = LOCALMSG_CONNECTING_TO_PDS[1];

            /*Async.SkyWorker(
                (s, evt) => evt.Result = Auth.Login(Variables.Handle, password),
                (s, evt) => HandleLoginResponse(evt, password)
            );*/

            Thread t = new Thread(() => //omega
            {
                // Run the login on the background thread
                object result = Auth.Login(Variables.Handle, password);

                // Marshal back to the UI thread for safe control updates
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)(() => HandleLoginResponse(result, password)));
                }
                else
                {
                    HandleLoginResponse(result, password);
                }
            });

            t.Start();

        }

        private void EnterOfflineMode()
        {
            Global.connectionStatus = LangPack.MAIN_TLABEL_DISCONNECTED;
            Variables.Handle = LangPack.MAIN_TLABEL_HANDLE_OFFLINE;

            timeOutBar.MarqueeAnimationSpeed = 0;
            timeOutBar.Invalidate();

            var mainmenu = new Menu_Main();
            this.Hide(); // Keep hidden since it's the startup form
            mainmenu.Show();
            ToggleControls(true);
        }

        private void WriteHandlePassword(string handle, string password)
        {
            RegKit.Write("\\LoginData", "handle", Encryptor.Encrypt(handle));
            RegKit.Write("\\LoginData", "password", Encryptor.Encrypt(password));
            RegKit.Write("\\LoginData", "CredentialsEncrypted", 1);
        }

        private void CheckSavedCred()
        {
            if (RegKit.Read.Dword("LoginData", "CredentialsEncrypted") == 1)
            {
                string handle = Encryptor.Decrypt(RegKit.Read.String("LoginData", "handle"));
                string password = Encryptor.Decrypt(RegKit.Read.String("LoginData", "password"));
                const string error = "$CERULEAN_ENCRYPTOR_ERROR_DECRYPT";

                if (handle == error || password == error)
                    displayError(new string[2] { "Credential decryption error", "Cerulean could not decrypt your credentials; please re-enter them. This is not a bug." });
                else
                    InitLogin(handle, password);
            }
        }

        private void HandleLoginResponse(object result, string password)
        {
            JObject reply = result as JObject;
            string[] errReply = WEH.ErrHandler(reply, true);

            if (errReply[2] != "false")
            {
                displayError(errReply);
                return;
            }

            Variables.Token = (string)reply["accessJwt"];
            Variables.RefreshToken = (string)reply["refreshJwt"];
            Global.connectionStatus = LangPack.MAIN_TLABEL_CONNECTED;

            timeOutBar.MarqueeAnimationSpeed = 0;
            timeOutBar.Invalidate();

            if (rememberMeBox.Checked)
            {
                WriteHandlePassword(Variables.Handle, password);
            }

            else
            {
                WriteHandlePassword(String.Empty, String.Empty);
                RegKit.Write("\\LoginData", "CredentialsEncrypted", "false");
            }

            var mainmenu = new Menu_Main();
            this.Hide(); // Keep hidden since it's the startup form
            mainmenu.Show();
            ToggleControls(true);
        }

        private void changePdsHostButton_Click(object sender, EventArgs e)
        {
            new Menu_ChangePDS().ShowDialog();
        }

        private void Menu_Login_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void forgotPasswordButton_Click(object sender, EventArgs e)
        {
            Purple.purple_core_init("dummy-ui");
            string version = Purple.GetVersion();
            MessageBox.Show("Libpurple version: " + version);
            //new Menu_ResetPass().ShowDialog();
            //OAuth.Test();
        }

        private void newAccountButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Menu_CreateAccount().ShowDialog();
        }

    }
}
