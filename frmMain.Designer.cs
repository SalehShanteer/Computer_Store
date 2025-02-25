namespace Computer_Store
{
    partial class frmMain
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
            this.tsMainBar = new System.Windows.Forms.ToolStrip();
            this.tsbLaptop = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbDesktop = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbMonitor = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbComponents = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbStorage = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAccessories = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbHeadset = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAdminSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAccount = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbLogoutSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbBasket = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMainBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainBar
            // 
            this.tsMainBar.BackColor = System.Drawing.SystemColors.Control;
            this.tsMainBar.ImageScalingSize = new System.Drawing.Size(81, 81);
            this.tsMainBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLaptop,
            this.tsbDesktop,
            this.tsbMonitor,
            this.tsbComponents,
            this.tsbStorage,
            this.tsbAccessories,
            this.tsbHeadset,
            this.tsbAdminSettings,
            this.tsbAccount,
            this.tsbBasket,
            this.toolStripSeparator1});
            this.tsMainBar.Location = new System.Drawing.Point(0, 0);
            this.tsMainBar.Name = "tsMainBar";
            this.tsMainBar.Size = new System.Drawing.Size(1904, 88);
            this.tsMainBar.TabIndex = 0;
            this.tsMainBar.Text = "toolStrip1";
            // 
            // tsbLaptop
            // 
            this.tsbLaptop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbLaptop.Image = global::Computer_Store.Properties.Resources.laptop;
            this.tsbLaptop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLaptop.Name = "tsbLaptop";
            this.tsbLaptop.ShowDropDownArrow = false;
            this.tsbLaptop.Size = new System.Drawing.Size(160, 85);
            this.tsbLaptop.Text = "Laptop";
            // 
            // tsbDesktop
            // 
            this.tsbDesktop.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbDesktop.Image = global::Computer_Store.Properties.Resources.Desktop;
            this.tsbDesktop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDesktop.Name = "tsbDesktop";
            this.tsbDesktop.ShowDropDownArrow = false;
            this.tsbDesktop.Size = new System.Drawing.Size(171, 85);
            this.tsbDesktop.Text = "Desktop";
            // 
            // tsbMonitor
            // 
            this.tsbMonitor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbMonitor.Image = global::Computer_Store.Properties.Resources.monitor;
            this.tsbMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMonitor.Name = "tsbMonitor";
            this.tsbMonitor.ShowDropDownArrow = false;
            this.tsbMonitor.Size = new System.Drawing.Size(171, 85);
            this.tsbMonitor.Text = "Monitor";
            // 
            // tsbComponents
            // 
            this.tsbComponents.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbComponents.Image = global::Computer_Store.Properties.Resources.Components1;
            this.tsbComponents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbComponents.Name = "tsbComponents";
            this.tsbComponents.ShowDropDownArrow = false;
            this.tsbComponents.Size = new System.Drawing.Size(211, 85);
            this.tsbComponents.Text = "Components";
            // 
            // tsbStorage
            // 
            this.tsbStorage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbStorage.Image = global::Computer_Store.Properties.Resources.Storage;
            this.tsbStorage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStorage.Name = "tsbStorage";
            this.tsbStorage.ShowDropDownArrow = false;
            this.tsbStorage.Size = new System.Drawing.Size(167, 85);
            this.tsbStorage.Text = "Storage";
            // 
            // tsbAccessories
            // 
            this.tsbAccessories.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbAccessories.Image = global::Computer_Store.Properties.Resources.Accessories;
            this.tsbAccessories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAccessories.Name = "tsbAccessories";
            this.tsbAccessories.ShowDropDownArrow = false;
            this.tsbAccessories.Size = new System.Drawing.Size(197, 85);
            this.tsbAccessories.Text = "Accessories";
            // 
            // tsbHeadset
            // 
            this.tsbHeadset.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbHeadset.Image = global::Computer_Store.Properties.Resources.headphone;
            this.tsbHeadset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHeadset.Name = "tsbHeadset";
            this.tsbHeadset.ShowDropDownArrow = false;
            this.tsbHeadset.Size = new System.Drawing.Size(169, 85);
            this.tsbHeadset.Text = "Headset";
            // 
            // tsbAdminSettings
            // 
            this.tsbAdminSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAdminSettings.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbAdminSettings.Image = global::Computer_Store.Properties.Resources.system_administration;
            this.tsbAdminSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdminSettings.Name = "tsbAdminSettings";
            this.tsbAdminSettings.ShowDropDownArrow = false;
            this.tsbAdminSettings.Size = new System.Drawing.Size(233, 85);
            this.tsbAdminSettings.Text = "Admin Settings";
            this.tsbAdminSettings.Visible = false;
            // 
            // tsbAccount
            // 
            this.tsbAccount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLogoutSettings,
            this.tsbChangePassword,
            this.tsbLogout});
            this.tsbAccount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbAccount.Image = global::Computer_Store.Properties.Resources.Account;
            this.tsbAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAccount.Name = "tsbAccount";
            this.tsbAccount.ShowDropDownArrow = false;
            this.tsbAccount.Size = new System.Drawing.Size(171, 85);
            this.tsbAccount.Text = "Account";
            // 
            // tsbLogoutSettings
            // 
            this.tsbLogoutSettings.Image = global::Computer_Store.Properties.Resources.account_settings;
            this.tsbLogoutSettings.Name = "tsbLogoutSettings";
            this.tsbLogoutSettings.Size = new System.Drawing.Size(306, 88);
            this.tsbLogoutSettings.Text = "Account Settings";
            this.tsbLogoutSettings.Click += new System.EventHandler(this.tsbLogoutSettings_Click);
            // 
            // tsbChangePassword
            // 
            this.tsbChangePassword.Image = global::Computer_Store.Properties.Resources.Change_Password;
            this.tsbChangePassword.Name = "tsbChangePassword";
            this.tsbChangePassword.Size = new System.Drawing.Size(306, 88);
            this.tsbChangePassword.Text = "Change Password";
            this.tsbChangePassword.Click += new System.EventHandler(this.tsbChangePassword_Click);
            // 
            // tsbLogout
            // 
            this.tsbLogout.Image = global::Computer_Store.Properties.Resources.Logout;
            this.tsbLogout.Name = "tsbLogout";
            this.tsbLogout.Size = new System.Drawing.Size(306, 88);
            this.tsbLogout.Text = "Logout";
            this.tsbLogout.Click += new System.EventHandler(this.tsbLogout_Click);
            // 
            // tsbBasket
            // 
            this.tsbBasket.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbBasket.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbBasket.Image = global::Computer_Store.Properties.Resources.Basket;
            this.tsbBasket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBasket.Name = "tsbBasket";
            this.tsbBasket.ShowDropDownArrow = false;
            this.tsbBasket.Size = new System.Drawing.Size(155, 85);
            this.tsbBasket.Text = "Basket";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 88);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1036);
            this.Controls.Add(this.tsMainBar);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tsMainBar.ResumeLayout(false);
            this.tsMainBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainBar;
        private System.Windows.Forms.ToolStripDropDownButton tsbLaptop;
        private System.Windows.Forms.ToolStripDropDownButton tsbDesktop;
        private System.Windows.Forms.ToolStripDropDownButton tsbAccessories;
        private System.Windows.Forms.ToolStripDropDownButton tsbHeadset;
        private System.Windows.Forms.ToolStripDropDownButton tsbMonitor;
        private System.Windows.Forms.ToolStripDropDownButton tsbComponents;
        private System.Windows.Forms.ToolStripDropDownButton tsbStorage;
        private System.Windows.Forms.ToolStripDropDownButton tsbBasket;
        private System.Windows.Forms.ToolStripDropDownButton tsbAccount;
        private System.Windows.Forms.ToolStripDropDownButton tsbAdminSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsbLogoutSettings;
        private System.Windows.Forms.ToolStripMenuItem tsbLogout;
        private System.Windows.Forms.ToolStripMenuItem tsbChangePassword;
    }
}