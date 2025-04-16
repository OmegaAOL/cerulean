using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json.Linq;


namespace Cerulean
{
    public partial class Menu_Login : Form
    {
        public Menu_Login()
        {
            InitializeComponent();

            this.MinimumSize = this.Size; // makes the window non-resizeable
            this.MaximumSize = this.Size;
            MaximizeBox = false;
        }

        private void Menu_Login_Load(object sender, EventArgs e)
        {
            CenterToParent();
            this.AcceptButton = loginButton;
        }

        private void connFailed(string headertext, string descriptortext)
        {
            timeOutBar.MarqueeAnimationSpeed = 0;
            timeOutBar.Style = ProgressBarStyle.Continuous;
            header.Text = headertext;
            descriptor.Text = descriptortext;
            header.ForeColor = Color.Red;
            timeOutBar.Value = 0;
            loginButton.Enabled = true;
        }

        private void loginButton_Click(object sender, EventArgs ev)
        {
            loginButton.Enabled = false;

            Global.handle = handleBox.Text.Trim();
            string password = passwordBox.Text.Trim();

            if (Global.handle == String.Empty || password == String.Empty) // Checks for empty handle/password field
            {
                header.Text = "Input Error";
                header.ForeColor = Color.Red;
                descriptor.Text = "Make sure that both the handle and password fields are filled.";
                loginButton.Enabled = true;
            }

            else
            {
                Global.handle = Global.handle.Replace("@", String.Empty); // replacing the @ symbol (Twitter legacy remnant) with blank space
                timeOutBar.Style = ProgressBarStyle.Marquee; // setting progress bar style to "Marquee", only works on Windows XP and up
                timeOutBar.MarqueeAnimationSpeed = 15;

                header.Text = "Connecting to PDS host"; // update the login form header (big) text to say that it's connecting 
                header.ForeColor = Color.Blue;
                descriptor.Text = "Cerulean is connecting to the specified PDS host. If authentication fails, check PDS settings and login details.";

                SkyBridge.SkyWorker(
                (s, evt) => evt.Result = SkyBridge.Auth(password),
                (s, evt) =>
                {
                    try
                    {
                        JObject reply = JObject.Parse((string)evt.Result); // using Newtonsoft.Json to parse the API response

                        //MessageBox.Show((string)e.Result); // Uncomment for debugging Bluesky's response

                        if (reply.ContainsKey("accessJwt")) // checking if accessJwt exists in the response
                        {
                            Global.token = (string)reply["accessJwt"]; // sets global variable Global.token to accessJwt
                            Global.refreshToken = (string)reply["refreshJwt"]; // sets global variable Global.refreshToken to refreshJwt (for reauthentication background process)                        
                            Global.connectionStatus = "Connected";

                            timeOutBar.MarqueeAnimationSpeed = 0; // stops the Marquee progress bar
                            timeOutBar.Style = ProgressBarStyle.Continuous;

                            var mainmenu = new Menu_Main(); // switches from login to main menu
                            loginButton.Enabled = true;
                            this.Hide();
                            mainmenu.Show();

                            if (rememberMeBox.Checked) // writes values to registry
                            {
                                RegKit.write("\\LoginData", "handle", Global.handle);
                                RegKit.write("\\LoginData", "password", password);

                            }

                            else if (!rememberMeBox.Checked)
                            {
                                RegKit.write("\\LoginData", "handle", "0");
                                RegKit.write("\\LoginData", "password", "0");
                            }
                        }

                        else // if accessJwt isn't present, signifying connection and a valid JSON response but no token (meaning invalid details)
                        {
                            string headertext = "Invalid login details";
                            string descriptortext = "The login credentials you have provided are invalid. If you used your email to log in, use your handle instead.";
                            connFailed(headertext, descriptortext);

                        }
                    }
                    catch
                    {
                        string result = String.Empty;
                        string headertext = "Connection failed";
                        string descriptortext = "Cerulean cannot connect to Bluesky. Check if you are connected to the Internet, or check your PDS Host.";
                        connFailed(headertext, descriptortext);

                        if (evt.Result.ToString() != String.Empty)
                        {
                            result = evt.Result.ToString();
                        }

                        if (evt.Result.ToString() == String.Empty)
                        {
                            result = "Nothing to parse. Your specified PDS host server is down.";
                        }

                        MessageBox.Show(Global.cantConnect);
                    }
                }
                );
            }

        }

        private void setupTotpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature will be added in a later version of Cerulean.\nNote that Bluesky does not support TOTP authentication, so " +
                "until it does you can use Cerulean's own implenentation.\n\nRecommended TOTP programs are:\nKeePass 2, KeePassXC (Desktop)\nAuthy, Google Authenticator " +
                "(Mobile)\n\nTOTP authentication will only be available in the .NET Framework 4.6 build of Cerulean.");

        }

        private void changePdsHostButton_Click(object sender, EventArgs e)
        {
            var pds = new Menu_ChangePDS();
            pds.Show();
        }

        private void timeOutBar_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Login_Close(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
