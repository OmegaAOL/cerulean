namespace Cerulean
{
    partial class Menu_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Main));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemTweet = new System.Windows.Forms.MenuItem();
            this.menuItemDM = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemLock = new System.Windows.Forms.MenuItem();
            this.menuItemLogout = new System.Windows.Forms.MenuItem();
            this.menuItem39 = new System.Windows.Forms.MenuItem();
            this.menuItemReload = new System.Windows.Forms.MenuItem();
            this.menuItemRefreshToken = new System.Windows.Forms.MenuItem();
            this.menuItem41 = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItemOptions = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItemGotoCeruleanCom = new System.Windows.Forms.MenuItem();
            this.menuItemGotoGitRepo = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItemBugGitFile = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.connStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.proBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.handleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.quickPostBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newPostButton = new System.Windows.Forms.ToolStripButton();
            this.newDmButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.feedSelectorButton = new System.Windows.Forms.ToolStripButton();
            this.notificationsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reauthButton = new System.Windows.Forms.ToolStripButton();
            this.logoutButton = new System.Windows.Forms.ToolStripButton();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.mainTree = new Cerulean.BorderTreeView();
            this.predictionBox = new Cerulean.TypeaheadBox();
            this.tweetBoard = new Cerulean.BorderPanel();
            this.quickPostButton = new Cerulean.CeruleanButton();
            this.statusStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem20,
            this.menuItem3,
            this.menuItem43,
            this.menuItem21,
            this.menuItem22});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemTweet,
            this.menuItemDM,
            this.menuItem18,
            this.menuItem19,
            this.menuItem23,
            this.menuItem24,
            this.menuItem25,
            this.menuItemExit});
            this.menuItem1.Text = "&File";
            // 
            // menuItemTweet
            // 
            this.menuItemTweet.Index = 0;
            this.menuItemTweet.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuItemTweet.Text = "New Post...";
            this.menuItemTweet.Click += new System.EventHandler(this.menuItemTweet_Click);
            // 
            // menuItemDM
            // 
            this.menuItemDM.Index = 1;
            this.menuItemDM.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftT;
            this.menuItemDM.Text = "New Direct Message...";
            this.menuItemDM.Click += new System.EventHandler(this.menuItemDM_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 2;
            this.menuItem18.Text = "-";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 3;
            this.menuItem19.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftE;
            this.menuItem19.Text = "Email Link to Post...";
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 4;
            this.menuItem23.Text = "-";
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 5;
            this.menuItem24.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuItem24.Text = "Print...";
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 6;
            this.menuItem25.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 7;
            this.menuItemExit.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem8,
            this.menuItem9,
            this.menuItem10,
            this.menuItem11,
            this.menuItem12,
            this.menuItem13,
            this.menuItem14,
            this.menuItem15});
            this.menuItem2.Text = "&Edit";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuItem4.Text = "Undo";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
            this.menuItem5.Text = "Redo";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "-";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 3;
            this.menuItem7.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuItem7.Text = "Cut";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 4;
            this.menuItem8.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuItem8.Text = "Copy";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 5;
            this.menuItem9.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuItem9.Text = "Paste";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 6;
            this.menuItem10.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.menuItem10.Text = "Delete";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 7;
            this.menuItem11.Text = "-";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 8;
            this.menuItem12.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.menuItem12.Text = "Select All";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 9;
            this.menuItem13.Text = "-";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 10;
            this.menuItem14.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.menuItem14.Text = "Find...";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 11;
            this.menuItem15.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.menuItem15.Text = "Replace...";
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 2;
            this.menuItem20.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem27,
            this.menuItem28,
            this.menuItem29,
            this.menuItem30});
            this.menuItem20.Text = "&View";
            // 
            // menuItem27
            // 
            this.menuItem27.Checked = true;
            this.menuItem27.Index = 0;
            this.menuItem27.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftQ;
            this.menuItem27.Text = "Quick Post Bar";
            // 
            // menuItem28
            // 
            this.menuItem28.Checked = true;
            this.menuItem28.Index = 1;
            this.menuItem28.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftD;
            this.menuItem28.Text = "Direct Messages";
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 2;
            this.menuItem29.Text = "-";
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 3;
            this.menuItem30.Text = "Full Screen";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemLock,
            this.menuItemLogout,
            this.menuItem39,
            this.menuItemReload,
            this.menuItemRefreshToken,
            this.menuItem41,
            this.menuItem42});
            this.menuItem3.Text = "&Account";
            // 
            // menuItemLock
            // 
            this.menuItemLock.Index = 0;
            this.menuItemLock.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
            this.menuItemLock.Text = "Lock...";
            // 
            // menuItemLogout
            // 
            this.menuItemLogout.Index = 1;
            this.menuItemLogout.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftL;
            this.menuItemLogout.Text = "Log Out...";
            this.menuItemLogout.Click += new System.EventHandler(this.menuItemLogout_Click);
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 2;
            this.menuItem39.Text = "-";
            // 
            // menuItemReload
            // 
            this.menuItemReload.Index = 3;
            this.menuItemReload.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.menuItemReload.Text = "Reload Firehose";
            this.menuItemReload.Click += new System.EventHandler(this.menuItemReload_Click);
            // 
            // menuItemRefreshToken
            // 
            this.menuItemRefreshToken.Index = 4;
            this.menuItemRefreshToken.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftR;
            this.menuItemRefreshToken.Text = "Reauthenticate";
            this.menuItemRefreshToken.Click += new System.EventHandler(this.menuItemRefreshToken_Click);
            // 
            // menuItem41
            // 
            this.menuItem41.Index = 5;
            this.menuItem41.Text = "-";
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 6;
            this.menuItem42.Text = "Delete My Login Data";
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 4;
            this.menuItem43.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem44,
            this.menuItem45});
            this.menuItem43.Text = "A&utomation";
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 0;
            this.menuItem44.Text = "Cerulean Automator...";
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 1;
            this.menuItem45.Text = "Advanced Scripting...";
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 5;
            this.menuItem21.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOptions});
            this.menuItem21.Text = "&Tools";
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.Index = 0;
            this.menuItemOptions.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItemOptions.Text = "Options...";
            this.menuItemOptions.Click += new System.EventHandler(this.menuItemOptions_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 6;
            this.menuItem22.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemGotoCeruleanCom,
            this.menuItemGotoGitRepo,
            this.menuItem17,
            this.menuItemBugGitFile,
            this.menuItem33,
            this.menuItemAbout});
            this.menuItem22.Text = "&Help";
            // 
            // menuItemGotoCeruleanCom
            // 
            this.menuItemGotoCeruleanCom.Index = 0;
            this.menuItemGotoCeruleanCom.Text = "Cerulean Website...";
            this.menuItemGotoCeruleanCom.Click += new System.EventHandler(this.menuItemGotoCeruleanCom_Click);
            // 
            // menuItemGotoGitRepo
            // 
            this.menuItemGotoGitRepo.Index = 1;
            this.menuItemGotoGitRepo.Text = "Cerulean on GitHub...";
            this.menuItemGotoGitRepo.Click += new System.EventHandler(this.menuItemGotoGitRepo_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 2;
            this.menuItem17.Text = "-";
            // 
            // menuItemBugGitFile
            // 
            this.menuItemBugGitFile.Index = 3;
            this.menuItemBugGitFile.Text = "Report a bug on GitHub...";
            this.menuItemBugGitFile.Click += new System.EventHandler(this.menuItemBugGitFile_Click);
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 4;
            this.menuItem33.Text = "-";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 5;
            this.menuItemAbout.Text = "About Cerulean";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackgroundImage = global::Cerulean.CeruleanArt.gradLight;
            this.statusStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connStatusLabel,
            this.proBar,
            this.toolStripStatusLabel1,
            this.handleLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 710);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1350, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // connStatusLabel
            // 
            this.connStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.connStatusLabel.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.connStatusLabel.Name = "connStatusLabel";
            this.connStatusLabel.Padding = new System.Windows.Forms.Padding(6, 0, 5, 0);
            this.connStatusLabel.Size = new System.Drawing.Size(102, 17);
            this.connStatusLabel.Text = "Placeholder text";
            this.connStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // proBar
            // 
            this.proBar.MarqueeAnimationSpeed = 0;
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(120, 16);
            this.proBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1010, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "    ";
            // 
            // handleLabel
            // 
            this.handleLabel.BackColor = System.Drawing.Color.Transparent;
            this.handleLabel.Name = "handleLabel";
            this.handleLabel.Size = new System.Drawing.Size(91, 17);
            this.handleLabel.Text = "Placeholder text";
            this.handleLabel.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // quickPostBox
            // 
            this.quickPostBox.ForeColor = System.Drawing.Color.DarkGray;
            this.quickPostBox.Location = new System.Drawing.Point(276, 648);
            this.quickPostBox.Name = "quickPostBox";
            this.quickPostBox.Size = new System.Drawing.Size(960, 20);
            this.quickPostBox.TabIndex = 3;
            this.quickPostBox.Text = "Placeholder text";
            this.quickPostBox.TextChanged += new System.EventHandler(this.quickPostBox_TextChanged);
            this.quickPostBox.Enter += new System.EventHandler(this.quickPostBox_Enter);
            this.quickPostBox.Leave += new System.EventHandler(this.quickPostBox_Leave);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::Cerulean.CeruleanArt.gradLight;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPostButton,
            this.newDmButton,
            this.toolStripSeparator3,
            this.feedSelectorButton,
            this.notificationsButton,
            this.toolStripSeparator2,
            this.reauthButton,
            this.logoutButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(1351, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(1351, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newPostButton
            // 
            this.newPostButton.Image = global::Cerulean.Icons_Aero.imageres_158_10;
            this.newPostButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.newPostButton.Name = "newPostButton";
            this.newPostButton.Size = new System.Drawing.Size(111, 22);
            this.newPostButton.Text = "Placeholder text";
            this.newPostButton.Click += new System.EventHandler(this.menuItemTweet_Click);
            // 
            // newDmButton
            // 
            this.newDmButton.Image = global::Cerulean.Icons_Aero.imageres_128_10;
            this.newDmButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.newDmButton.Name = "newDmButton";
            this.newDmButton.Size = new System.Drawing.Size(111, 22);
            this.newDmButton.Text = "Placeholder text";
            this.newDmButton.Click += new System.EventHandler(this.menuItemDM_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // feedSelectorButton
            // 
            this.feedSelectorButton.Image = global::Cerulean.Icons_Aero.imageres_25_10;
            this.feedSelectorButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.feedSelectorButton.Name = "feedSelectorButton";
            this.feedSelectorButton.Size = new System.Drawing.Size(111, 22);
            this.feedSelectorButton.Text = "Placeholder text";
            this.feedSelectorButton.Click += new System.EventHandler(this.menuItemReload_Click);
            // 
            // notificationsButton
            // 
            this.notificationsButton.Image = global::Cerulean.CeruleanArt.globe_16;
            this.notificationsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.notificationsButton.Name = "notificationsButton";
            this.notificationsButton.Size = new System.Drawing.Size(111, 22);
            this.notificationsButton.Text = "Placeholder text";
            this.notificationsButton.ToolTipText = "Placeholder text";
            this.notificationsButton.Click += new System.EventHandler(this.notificationsButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // reauthButton
            // 
            this.reauthButton.Image = global::Cerulean.Icons_Aero.imageres_82_10;
            this.reauthButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reauthButton.Name = "reauthButton";
            this.reauthButton.Size = new System.Drawing.Size(111, 22);
            this.reauthButton.Text = "Placeholder text";
            this.reauthButton.Click += new System.EventHandler(this.menuItemRefreshToken_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.ForeColor = System.Drawing.Color.Black;
            this.logoutButton.Image = global::Cerulean.Icons_Aero.imageres_59_10;
            this.logoutButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(111, 22);
            this.logoutButton.Text = "Placeholder text";
            this.logoutButton.Click += new System.EventHandler(this.menuItemLogout_Click);
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.ForeColor = System.Drawing.Color.DarkGray;
            this.searchBox.Location = new System.Drawing.Point(1107, 1);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(231, 20);
            this.searchBox.TabIndex = 6;
            this.searchBox.Text = "Placeholder text";
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_keyDown);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
            // 
            // mainTree
            // 
            this.mainTree.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTree.Location = new System.Drawing.Point(27, 38);
            this.mainTree.Name = "mainTree";
            this.mainTree.Size = new System.Drawing.Size(218, 639);
            this.mainTree.TabIndex = 0;
            // 
            // predictionBox
            // 
            this.predictionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.predictionBox.FormattingEnabled = true;
            this.predictionBox.Location = new System.Drawing.Point(1108, 20);
            this.predictionBox.MaximumSize = new System.Drawing.Size(229, 300);
            this.predictionBox.MinimumSize = new System.Drawing.Size(229, 0);
            this.predictionBox.Name = "predictionBox";
            this.predictionBox.Size = new System.Drawing.Size(229, 91);
            this.predictionBox.TabIndex = 11;
            this.predictionBox.Visible = false;
            this.predictionBox.Click += new System.EventHandler(this.listView_Click);
            this.predictionBox.SelectedIndexChanged += new System.EventHandler(this.predictionBox_SelectedIndexChanged);
            // 
            // tweetBoard
            // 
            this.tweetBoard.AutoScroll = true;
            this.tweetBoard.AutoScrollMargin = new System.Drawing.Size(0, 1);
            this.tweetBoard.BackColor = System.Drawing.Color.Transparent;
            this.tweetBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tweetBoard.Location = new System.Drawing.Point(276, 38);
            this.tweetBoard.Margin = new System.Windows.Forms.Padding(0);
            this.tweetBoard.Name = "tweetBoard";
            this.tweetBoard.Size = new System.Drawing.Size(1047, 589);
            this.tweetBoard.TabIndex = 10;
            this.tweetBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // quickPostButton
            // 
            this.quickPostButton.AutoSize = true;
            this.quickPostButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.quickPostButton.BackColor = System.Drawing.Color.LightGray;
            this.quickPostButton.Enabled = false;
            this.quickPostButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.quickPostButton.Location = new System.Drawing.Point(1248, 646);
            this.quickPostButton.Margin = new System.Windows.Forms.Padding(0);
            this.quickPostButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.quickPostButton.Name = "quickPostButton";
            this.quickPostButton.Padding = new System.Windows.Forms.Padding(6, 1, 5, 0);
            this.quickPostButton.Size = new System.Drawing.Size(75, 23);
            this.quickPostButton.TabIndex = 4;
            this.quickPostButton.Text = "Post";
            this.quickPostButton.UseVisualStyleBackColor = false;
            this.quickPostButton.Click += new System.EventHandler(this.quickPostButton_Click);
            // 
            // Menu_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1350, 732);
            this.Controls.Add(this.mainTree);
            this.Controls.Add(this.predictionBox);
            this.Controls.Add(this.tweetBoard);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.quickPostButton);
            this.Controls.Add(this.quickPostBox);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1366, 770);
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(1366, 770);
            this.Name = "Menu_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Placeholder text";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_Main_Close);
            this.Load += new System.EventHandler(this.Menu_Main_Load);
            this.Shown += new System.EventHandler(this.Menu_Main_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Menu_MouseDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItemTweet;
        private System.Windows.Forms.MenuItem menuItemDM;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem18;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem menuItem23;
        private System.Windows.Forms.MenuItem menuItem24;
        private System.Windows.Forms.MenuItem menuItem25;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem menuItem27;
        private System.Windows.Forms.MenuItem menuItem28;
        private System.Windows.Forms.MenuItem menuItem29;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.MenuItem menuItem22;
        private System.Windows.Forms.MenuItem menuItemGotoCeruleanCom;
        private System.Windows.Forms.MenuItem menuItem30;
        private System.Windows.Forms.MenuItem menuItemRefreshToken;
        private System.Windows.Forms.MenuItem menuItemLogout;
        private System.Windows.Forms.MenuItem menuItemLock;
        private System.Windows.Forms.MenuItem menuItem39;
        private System.Windows.Forms.MenuItem menuItemReload;
        private System.Windows.Forms.MenuItem menuItem41;
        private System.Windows.Forms.MenuItem menuItem42;
        private System.Windows.Forms.MenuItem menuItemOptions;
        private System.Windows.Forms.MenuItem menuItemGotoGitRepo;
        private System.Windows.Forms.MenuItem menuItem33;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel connStatusLabel;
        private System.Windows.Forms.MenuItem menuItem43;
        private System.Windows.Forms.MenuItem menuItem44;
        private System.Windows.Forms.MenuItem menuItem45;
        private System.Windows.Forms.ToolStripStatusLabel handleLabel;
        private System.Windows.Forms.ToolStripProgressBar proBar;
        private System.Windows.Forms.TextBox quickPostBox;
        private Cerulean.CeruleanButton quickPostButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newPostButton;
        private System.Windows.Forms.ToolStripButton newDmButton;
        private System.Windows.Forms.ToolStripButton feedSelectorButton;
        private System.Windows.Forms.ToolStripButton logoutButton;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton reauthButton;
        private BorderPanel tweetBoard;
        private System.Windows.Forms.MenuItem menuItemBugGitFile;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private Cerulean.TypeaheadBox predictionBox;
        private System.Windows.Forms.ToolStripButton notificationsButton;
        private Cerulean.BorderTreeView mainTree;
    }
}