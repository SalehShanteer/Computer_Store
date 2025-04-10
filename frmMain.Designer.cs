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
            this.manageProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAccount = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbLogoutSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbBasket = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSubcategory = new System.Windows.Forms.Label();
            this.cbxSubcategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cbxBrand = new System.Windows.Forms.ComboBox();
            this.txtMinPrice = new System.Windows.Forms.TextBox();
            this.txtMaxPrice = new System.Windows.Forms.TextBox();
            this.lblMinPrice = new System.Windows.Forms.Label();
            this.lblMaxPrice = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblNoResult = new System.Windows.Forms.Label();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.ctrlPageNavigator1 = new Computer_Store.ctrlPageNavigator();
            this.ctrlProduct5 = new Computer_Store.ctrlProduct();
            this.ctrlProduct6 = new Computer_Store.ctrlProduct();
            this.ctrlProduct7 = new Computer_Store.ctrlProduct();
            this.ctrlProduct8 = new Computer_Store.ctrlProduct();
            this.ctrlProduct4 = new Computer_Store.ctrlProduct();
            this.ctrlProduct3 = new Computer_Store.ctrlProduct();
            this.ctrlProduct2 = new Computer_Store.ctrlProduct();
            this.ctrlProduct1 = new Computer_Store.ctrlProduct();
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
            this.tsbLaptop.Click += new System.EventHandler(this.tsbLaptop_Click);
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
            this.tsbDesktop.Click += new System.EventHandler(this.tsbDesktop_Click);
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
            this.tsbMonitor.Click += new System.EventHandler(this.tsbMonitor_Click);
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
            this.tsbComponents.Click += new System.EventHandler(this.tsbComponents_Click);
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
            this.tsbStorage.Click += new System.EventHandler(this.tsbStorage_Click);
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
            this.tsbAccessories.Click += new System.EventHandler(this.tsbAccessories_Click);
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
            this.tsbHeadset.Click += new System.EventHandler(this.tsbHeadset_Click);
            // 
            // tsbAdminSettings
            // 
            this.tsbAdminSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAdminSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageProductsToolStripMenuItem});
            this.tsbAdminSettings.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbAdminSettings.Image = global::Computer_Store.Properties.Resources.system_administration;
            this.tsbAdminSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdminSettings.Name = "tsbAdminSettings";
            this.tsbAdminSettings.ShowDropDownArrow = false;
            this.tsbAdminSettings.Size = new System.Drawing.Size(233, 85);
            this.tsbAdminSettings.Text = "Admin Settings";
            this.tsbAdminSettings.Visible = false;
            // 
            // manageProductsToolStripMenuItem
            // 
            this.manageProductsToolStripMenuItem.Image = global::Computer_Store.Properties.Resources.products;
            this.manageProductsToolStripMenuItem.Name = "manageProductsToolStripMenuItem";
            this.manageProductsToolStripMenuItem.Size = new System.Drawing.Size(241, 30);
            this.manageProductsToolStripMenuItem.Text = "Manage Products";
            this.manageProductsToolStripMenuItem.Click += new System.EventHandler(this.manageProductsToolStripMenuItem_Click);
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
            this.tsbLogoutSettings.Size = new System.Drawing.Size(241, 30);
            this.tsbLogoutSettings.Text = "Account Settings";
            this.tsbLogoutSettings.Click += new System.EventHandler(this.tsbLogoutSettings_Click);
            // 
            // tsbChangePassword
            // 
            this.tsbChangePassword.Image = global::Computer_Store.Properties.Resources.Change_Password;
            this.tsbChangePassword.Name = "tsbChangePassword";
            this.tsbChangePassword.Size = new System.Drawing.Size(241, 30);
            this.tsbChangePassword.Text = "Change Password";
            this.tsbChangePassword.Click += new System.EventHandler(this.tsbChangePassword_Click);
            // 
            // tsbLogout
            // 
            this.tsbLogout.Image = global::Computer_Store.Properties.Resources.Logout;
            this.tsbLogout.Name = "tsbLogout";
            this.tsbLogout.Size = new System.Drawing.Size(241, 30);
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
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(1385, 144);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 31);
            this.btnSearch.TabIndex = 110;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(1053, 143);
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(310, 31);
            this.txtSearch.TabIndex = 111;
            // 
            // lblSubcategory
            // 
            this.lblSubcategory.AutoSize = true;
            this.lblSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubcategory.Location = new System.Drawing.Point(676, 122);
            this.lblSubcategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubcategory.Name = "lblSubcategory";
            this.lblSubcategory.Size = new System.Drawing.Size(110, 20);
            this.lblSubcategory.TabIndex = 133;
            this.lblSubcategory.Text = "Subcategory";
            // 
            // cbxSubcategory
            // 
            this.cbxSubcategory.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbxSubcategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxSubcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSubcategory.FormattingEnabled = true;
            this.cbxSubcategory.Location = new System.Drawing.Point(677, 147);
            this.cbxSubcategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSubcategory.Name = "cbxSubcategory";
            this.cbxSubcategory.Size = new System.Drawing.Size(167, 26);
            this.cbxSubcategory.TabIndex = 132;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(494, 122);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(81, 20);
            this.lblCategory.TabIndex = 135;
            this.lblCategory.Text = "Category";
            // 
            // cbxCategory
            // 
            this.cbxCategory.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbxCategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(495, 147);
            this.cbxCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(167, 26);
            this.cbxCategory.TabIndex = 134;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(857, 122);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(57, 20);
            this.lblBrand.TabIndex = 137;
            this.lblBrand.Text = "Brand";
            // 
            // cbxBrand
            // 
            this.cbxBrand.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cbxBrand.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBrand.FormattingEnabled = true;
            this.cbxBrand.Location = new System.Drawing.Point(858, 147);
            this.cbxBrand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxBrand.Name = "cbxBrand";
            this.cbxBrand.Size = new System.Drawing.Size(167, 26);
            this.cbxBrand.TabIndex = 136;
            // 
            // txtMinPrice
            // 
            this.txtMinPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMinPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinPrice.Location = new System.Drawing.Point(217, 147);
            this.txtMinPrice.MaxLength = 100;
            this.txtMinPrice.Name = "txtMinPrice";
            this.txtMinPrice.Size = new System.Drawing.Size(111, 26);
            this.txtMinPrice.TabIndex = 138;
            this.txtMinPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinPrice_KeyPress);
            // 
            // txtMaxPrice
            // 
            this.txtMaxPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxPrice.Location = new System.Drawing.Point(357, 147);
            this.txtMaxPrice.MaxLength = 100;
            this.txtMaxPrice.Name = "txtMaxPrice";
            this.txtMaxPrice.Size = new System.Drawing.Size(111, 26);
            this.txtMaxPrice.TabIndex = 139;
            this.txtMaxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxPrice_KeyPress);
            // 
            // lblMinPrice
            // 
            this.lblMinPrice.AutoSize = true;
            this.lblMinPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPrice.Location = new System.Drawing.Point(217, 122);
            this.lblMinPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinPrice.Name = "lblMinPrice";
            this.lblMinPrice.Size = new System.Drawing.Size(82, 20);
            this.lblMinPrice.TabIndex = 140;
            this.lblMinPrice.Text = "Min Price";
            // 
            // lblMaxPrice
            // 
            this.lblMaxPrice.AutoSize = true;
            this.lblMaxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxPrice.Location = new System.Drawing.Point(358, 122);
            this.lblMaxPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaxPrice.Name = "lblMaxPrice";
            this.lblMaxPrice.Size = new System.Drawing.Size(86, 20);
            this.lblMaxPrice.TabIndex = 141;
            this.lblMaxPrice.Text = "Max Price";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(328, 149);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(29, 20);
            this.lblTo.TabIndex = 142;
            this.lblTo.Text = "To";
            // 
            // lblNoResult
            // 
            this.lblNoResult.AutoSize = true;
            this.lblNoResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblNoResult.Location = new System.Drawing.Point(888, 565);
            this.lblNoResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoResult.Name = "lblNoResult";
            this.lblNoResult.Size = new System.Drawing.Size(117, 26);
            this.lblNoResult.TabIndex = 143;
            this.lblNoResult.Text = "No Result";
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.Black;
            this.btnShowAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnShowAll.Location = new System.Drawing.Point(1500, 144);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(87, 31);
            this.btnShowAll.TabIndex = 144;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // ctrlPageNavigator1
            // 
            this.ctrlPageNavigator1.CurrentPage = 0;
            this.ctrlPageNavigator1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctrlPageNavigator1.Location = new System.Drawing.Point(742, 960);
            this.ctrlPageNavigator1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPageNavigator1.Name = "ctrlPageNavigator1";
            this.ctrlPageNavigator1.NumberOfItemsInPage = 8;
            this.ctrlPageNavigator1.NumberOfPages = 0;
            this.ctrlPageNavigator1.Size = new System.Drawing.Size(421, 52);
            this.ctrlPageNavigator1.TabIndex = 9;
            this.ctrlPageNavigator1.OnPageChange += new Computer_Store.ctrlPageNavigator.OnPageChangeEventHandler(this.ctrlPageNavigator1_OnPageChange);
            // 
            // ctrlProduct5
            // 
            this.ctrlProduct5.BackColor = System.Drawing.Color.White;
            this.ctrlProduct5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlProduct5.Location = new System.Drawing.Point(118, 602);
            this.ctrlProduct5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlProduct5.Name = "ctrlProduct5";
            this.ctrlProduct5.Size = new System.Drawing.Size(409, 364);
            this.ctrlProduct5.TabIndex = 8;
            // 
            // ctrlProduct6
            // 
            this.ctrlProduct6.BackColor = System.Drawing.Color.White;
            this.ctrlProduct6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlProduct6.Location = new System.Drawing.Point(535, 602);
            this.ctrlProduct6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlProduct6.Name = "ctrlProduct6";
            this.ctrlProduct6.Size = new System.Drawing.Size(409, 364);
            this.ctrlProduct6.TabIndex = 7;
            // 
            // ctrlProduct7
            // 
            this.ctrlProduct7.BackColor = System.Drawing.Color.White;
            this.ctrlProduct7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlProduct7.Location = new System.Drawing.Point(952, 602);
            this.ctrlProduct7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlProduct7.Name = "ctrlProduct7";
            this.ctrlProduct7.Size = new System.Drawing.Size(409, 364);
            this.ctrlProduct7.TabIndex = 6;
            // 
            // ctrlProduct8
            // 
            this.ctrlProduct8.BackColor = System.Drawing.Color.White;
            this.ctrlProduct8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlProduct8.Location = new System.Drawing.Point(1369, 602);
            this.ctrlProduct8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlProduct8.Name = "ctrlProduct8";
            this.ctrlProduct8.Size = new System.Drawing.Size(409, 364);
            this.ctrlProduct8.TabIndex = 5;
            // 
            // ctrlProduct4
            // 
            this.ctrlProduct4.BackColor = System.Drawing.Color.White;
            this.ctrlProduct4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlProduct4.Location = new System.Drawing.Point(1369, 196);
            this.ctrlProduct4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlProduct4.Name = "ctrlProduct4";
            this.ctrlProduct4.Size = new System.Drawing.Size(409, 364);
            this.ctrlProduct4.TabIndex = 4;
            // 
            // ctrlProduct3
            // 
            this.ctrlProduct3.BackColor = System.Drawing.Color.White;
            this.ctrlProduct3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlProduct3.Location = new System.Drawing.Point(952, 196);
            this.ctrlProduct3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlProduct3.Name = "ctrlProduct3";
            this.ctrlProduct3.Size = new System.Drawing.Size(409, 364);
            this.ctrlProduct3.TabIndex = 3;
            // 
            // ctrlProduct2
            // 
            this.ctrlProduct2.BackColor = System.Drawing.Color.White;
            this.ctrlProduct2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlProduct2.Location = new System.Drawing.Point(535, 196);
            this.ctrlProduct2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlProduct2.Name = "ctrlProduct2";
            this.ctrlProduct2.Size = new System.Drawing.Size(409, 364);
            this.ctrlProduct2.TabIndex = 2;
            // 
            // ctrlProduct1
            // 
            this.ctrlProduct1.BackColor = System.Drawing.Color.White;
            this.ctrlProduct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlProduct1.Location = new System.Drawing.Point(118, 196);
            this.ctrlProduct1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlProduct1.Name = "ctrlProduct1";
            this.ctrlProduct1.Size = new System.Drawing.Size(409, 364);
            this.ctrlProduct1.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1036);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.lblNoResult);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblMaxPrice);
            this.Controls.Add(this.lblMinPrice);
            this.Controls.Add(this.txtMaxPrice);
            this.Controls.Add(this.txtMinPrice);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cbxBrand);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.lblSubcategory);
            this.Controls.Add(this.cbxSubcategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.ctrlPageNavigator1);
            this.Controls.Add(this.ctrlProduct5);
            this.Controls.Add(this.ctrlProduct6);
            this.Controls.Add(this.ctrlProduct7);
            this.Controls.Add(this.ctrlProduct8);
            this.Controls.Add(this.ctrlProduct4);
            this.Controls.Add(this.ctrlProduct3);
            this.Controls.Add(this.ctrlProduct2);
            this.Controls.Add(this.ctrlProduct1);
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
        private ctrlProduct ctrlProduct1;
        private ctrlProduct ctrlProduct2;
        private ctrlProduct ctrlProduct3;
        private ctrlProduct ctrlProduct4;
        private ctrlProduct ctrlProduct5;
        private ctrlProduct ctrlProduct6;
        private ctrlProduct ctrlProduct7;
        private ctrlProduct ctrlProduct8;
        private ctrlPageNavigator ctrlPageNavigator1;
        private System.Windows.Forms.ToolStripMenuItem manageProductsToolStripMenuItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSubcategory;
        private System.Windows.Forms.ComboBox cbxSubcategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cbxBrand;
        private System.Windows.Forms.TextBox txtMinPrice;
        private System.Windows.Forms.TextBox txtMaxPrice;
        private System.Windows.Forms.Label lblMinPrice;
        private System.Windows.Forms.Label lblMaxPrice;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblNoResult;
        private System.Windows.Forms.Button btnShowAll;
    }
}