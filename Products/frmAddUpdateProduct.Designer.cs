namespace Computer_Store
{
    partial class frmAddUpdateProduct
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudQuantityInStock = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxSubcategory = new System.Windows.Forms.ComboBox();
            this.cbxBrand = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.pbImage1 = new System.Windows.Forms.PictureBox();
            this.pbImage2 = new System.Windows.Forms.PictureBox();
            this.pbImage3 = new System.Windows.Forms.PictureBox();
            this.pbImage4 = new System.Windows.Forms.PictureBox();
            this.pbImage5 = new System.Windows.Forms.PictureBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnRemoveImage1 = new System.Windows.Forms.Button();
            this.btnRemoveImage2 = new System.Windows.Forms.Button();
            this.btnRemoveImage3 = new System.Windows.Forms.Button();
            this.btnRemoveImage4 = new System.Windows.Forms.Button();
            this.btnRemoveImage5 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.openFileDialogForImage = new System.Windows.Forms.OpenFileDialog();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnDeleteSubcategory = new System.Windows.Forms.Button();
            this.btnEditSubcategory = new System.Windows.Forms.Button();
            this.btnAddSubcategory = new System.Windows.Forms.Button();
            this.btnDeleteBrand = new System.Windows.Forms.Button();
            this.btnEditBrand = new System.Windows.Forms.Button();
            this.btnAddBrand = new System.Windows.Forms.Button();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblSubcategoryName = new System.Windows.Forms.Label();
            this.txtSubcategoryName = new System.Windows.Forms.TextBox();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.btnSaveSubcategory = new System.Windows.Forms.Button();
            this.btnCancelSubcategory = new System.Windows.Forms.Button();
            this.btnCancelCategory = new System.Windows.Forms.Button();
            this.btnSaveCategory = new System.Windows.Forms.Button();
            this.btnCancelBrand = new System.Windows.Forms.Button();
            this.btnSaveBrand = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(126, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(812, 60);
            this.lblTitle.TabIndex = 115;
            this.lblTitle.Text = "Add New Product";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(42, 119);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(122, 20);
            this.lblFirstName.TabIndex = 118;
            this.lblFirstName.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtProductName.Location = new System.Drawing.Point(42, 147);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtProductName.MaxLength = 100;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(248, 19);
            this.txtProductName.TabIndex = 117;
            // 
            // cbxCategory
            // 
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(45, 213);
            this.cbxCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(155, 24);
            this.cbxCategory.TabIndex = 119;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 121;
            this.label1.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(383, 187);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 122;
            this.label2.Text = "Subcategory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(714, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 124;
            this.label3.Text = "Brand";
            // 
            // nudQuantityInStock
            // 
            this.nudQuantityInStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudQuantityInStock.Location = new System.Drawing.Point(533, 147);
            this.nudQuantityInStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudQuantityInStock.Name = "nudQuantityInStock";
            this.nudQuantityInStock.Size = new System.Drawing.Size(180, 22);
            this.nudQuantityInStock.TabIndex = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(539, 119);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 126;
            this.label4.Text = "Quantity In Stock";
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Location = new System.Drawing.Point(43, 326);
            this.rtxtDescription.MaxLength = 2000;
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.Size = new System.Drawing.Size(959, 64);
            this.rtxtDescription.TabIndex = 127;
            this.rtxtDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 299);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 128;
            this.label5.Text = "Description";
            // 
            // cbxSubcategory
            // 
            this.cbxSubcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbxSubcategory.FormattingEnabled = true;
            this.cbxSubcategory.Location = new System.Drawing.Point(387, 214);
            this.cbxSubcategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSubcategory.Name = "cbxSubcategory";
            this.cbxSubcategory.Size = new System.Drawing.Size(144, 24);
            this.cbxSubcategory.TabIndex = 129;
            // 
            // cbxBrand
            // 
            this.cbxBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbxBrand.FormattingEnabled = true;
            this.cbxBrand.Location = new System.Drawing.Point(715, 214);
            this.cbxBrand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxBrand.Name = "cbxBrand";
            this.cbxBrand.Size = new System.Drawing.Size(143, 24);
            this.cbxBrand.TabIndex = 130;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(881, 624);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 31);
            this.btnSave.TabIndex = 131;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(334, 119);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 133;
            this.label6.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPrice.Location = new System.Drawing.Point(327, 147);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(166, 19);
            this.txtPrice.TabIndex = 132;
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReleaseDate.Location = new System.Drawing.Point(778, 143);
            this.dtpReleaseDate.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dtpReleaseDate.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(180, 26);
            this.dtpReleaseDate.TabIndex = 134;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(805, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 20);
            this.label7.TabIndex = 135;
            this.label7.Text = "Release Date";
            // 
            // pbImage1
            // 
            this.pbImage1.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage1.Location = new System.Drawing.Point(43, 414);
            this.pbImage1.Name = "pbImage1";
            this.pbImage1.Size = new System.Drawing.Size(144, 147);
            this.pbImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage1.TabIndex = 136;
            this.pbImage1.TabStop = false;
            // 
            // pbImage2
            // 
            this.pbImage2.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage2.Location = new System.Drawing.Point(213, 414);
            this.pbImage2.Name = "pbImage2";
            this.pbImage2.Size = new System.Drawing.Size(144, 147);
            this.pbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage2.TabIndex = 137;
            this.pbImage2.TabStop = false;
            // 
            // pbImage3
            // 
            this.pbImage3.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage3.Location = new System.Drawing.Point(378, 414);
            this.pbImage3.Name = "pbImage3";
            this.pbImage3.Size = new System.Drawing.Size(144, 147);
            this.pbImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage3.TabIndex = 138;
            this.pbImage3.TabStop = false;
            // 
            // pbImage4
            // 
            this.pbImage4.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage4.Location = new System.Drawing.Point(542, 414);
            this.pbImage4.Name = "pbImage4";
            this.pbImage4.Size = new System.Drawing.Size(144, 147);
            this.pbImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage4.TabIndex = 139;
            this.pbImage4.TabStop = false;
            // 
            // pbImage5
            // 
            this.pbImage5.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage5.Location = new System.Drawing.Point(714, 414);
            this.pbImage5.Name = "pbImage5";
            this.pbImage5.Size = new System.Drawing.Size(144, 147);
            this.pbImage5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage5.TabIndex = 140;
            this.pbImage5.TabStop = false;
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.Black;
            this.btnAddImage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddImage.Location = new System.Drawing.Point(881, 484);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(121, 31);
            this.btnAddImage.TabIndex = 141;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnRemoveImage1
            // 
            this.btnRemoveImage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveImage1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveImage1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveImage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnRemoveImage1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemoveImage1.Location = new System.Drawing.Point(68, 577);
            this.btnRemoveImage1.Name = "btnRemoveImage1";
            this.btnRemoveImage1.Size = new System.Drawing.Size(88, 24);
            this.btnRemoveImage1.TabIndex = 142;
            this.btnRemoveImage1.Text = "Remove";
            this.btnRemoveImage1.UseVisualStyleBackColor = false;
            this.btnRemoveImage1.Visible = false;
            this.btnRemoveImage1.Click += new System.EventHandler(this.btnRemoveImage1_Click);
            // 
            // btnRemoveImage2
            // 
            this.btnRemoveImage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveImage2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveImage2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveImage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnRemoveImage2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemoveImage2.Location = new System.Drawing.Point(243, 577);
            this.btnRemoveImage2.Name = "btnRemoveImage2";
            this.btnRemoveImage2.Size = new System.Drawing.Size(88, 24);
            this.btnRemoveImage2.TabIndex = 143;
            this.btnRemoveImage2.Text = "Remove";
            this.btnRemoveImage2.UseVisualStyleBackColor = false;
            this.btnRemoveImage2.Visible = false;
            this.btnRemoveImage2.Click += new System.EventHandler(this.btnRemoveImage2_Click);
            // 
            // btnRemoveImage3
            // 
            this.btnRemoveImage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveImage3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveImage3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveImage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnRemoveImage3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemoveImage3.Location = new System.Drawing.Point(405, 577);
            this.btnRemoveImage3.Name = "btnRemoveImage3";
            this.btnRemoveImage3.Size = new System.Drawing.Size(88, 24);
            this.btnRemoveImage3.TabIndex = 144;
            this.btnRemoveImage3.Text = "Remove";
            this.btnRemoveImage3.UseVisualStyleBackColor = false;
            this.btnRemoveImage3.Visible = false;
            this.btnRemoveImage3.Click += new System.EventHandler(this.btnRemoveImage3_Click);
            // 
            // btnRemoveImage4
            // 
            this.btnRemoveImage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveImage4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveImage4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveImage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnRemoveImage4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemoveImage4.Location = new System.Drawing.Point(571, 577);
            this.btnRemoveImage4.Name = "btnRemoveImage4";
            this.btnRemoveImage4.Size = new System.Drawing.Size(88, 24);
            this.btnRemoveImage4.TabIndex = 145;
            this.btnRemoveImage4.Text = "Remove";
            this.btnRemoveImage4.UseVisualStyleBackColor = false;
            this.btnRemoveImage4.Visible = false;
            this.btnRemoveImage4.Click += new System.EventHandler(this.btnRemoveImage4_Click);
            // 
            // btnRemoveImage5
            // 
            this.btnRemoveImage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveImage5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveImage5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveImage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnRemoveImage5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemoveImage5.Location = new System.Drawing.Point(739, 577);
            this.btnRemoveImage5.Name = "btnRemoveImage5";
            this.btnRemoveImage5.Size = new System.Drawing.Size(88, 24);
            this.btnRemoveImage5.TabIndex = 146;
            this.btnRemoveImage5.Text = "Remove";
            this.btnRemoveImage5.UseVisualStyleBackColor = false;
            this.btnRemoveImage5.Visible = false;
            this.btnRemoveImage5.Click += new System.EventHandler(this.btnRemoveImage5_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(646, 624);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 31);
            this.btnClose.TabIndex = 147;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // openFileDialogForImage
            // 
            this.openFileDialogForImage.FileName = "openFileDialogForImage";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.Black;
            this.btnAddCategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddCategory.Location = new System.Drawing.Point(212, 213);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(47, 24);
            this.btnAddCategory.TabIndex = 148;
            this.btnAddCategory.Text = "Add";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.BackColor = System.Drawing.Color.Black;
            this.btnEditCategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEditCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditCategory.Location = new System.Drawing.Point(263, 213);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(47, 24);
            this.btnEditCategory.TabIndex = 149;
            this.btnEditCategory.Text = "Edit";
            this.btnEditCategory.UseVisualStyleBackColor = false;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteCategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnDeleteCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteCategory.Location = new System.Drawing.Point(314, 213);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(60, 24);
            this.btnDeleteCategory.TabIndex = 150;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = false;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnDeleteSubcategory
            // 
            this.btnDeleteSubcategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteSubcategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnDeleteSubcategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteSubcategory.Location = new System.Drawing.Point(643, 214);
            this.btnDeleteSubcategory.Name = "btnDeleteSubcategory";
            this.btnDeleteSubcategory.Size = new System.Drawing.Size(60, 24);
            this.btnDeleteSubcategory.TabIndex = 153;
            this.btnDeleteSubcategory.Text = "Delete";
            this.btnDeleteSubcategory.UseVisualStyleBackColor = false;
            this.btnDeleteSubcategory.Click += new System.EventHandler(this.btnDeleteSubcategory_Click);
            // 
            // btnEditSubcategory
            // 
            this.btnEditSubcategory.BackColor = System.Drawing.Color.Black;
            this.btnEditSubcategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEditSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditSubcategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditSubcategory.Location = new System.Drawing.Point(592, 214);
            this.btnEditSubcategory.Name = "btnEditSubcategory";
            this.btnEditSubcategory.Size = new System.Drawing.Size(47, 24);
            this.btnEditSubcategory.TabIndex = 152;
            this.btnEditSubcategory.Text = "Edit";
            this.btnEditSubcategory.UseVisualStyleBackColor = false;
            this.btnEditSubcategory.Click += new System.EventHandler(this.btnEditSubcategory_Click);
            // 
            // btnAddSubcategory
            // 
            this.btnAddSubcategory.BackColor = System.Drawing.Color.Black;
            this.btnAddSubcategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddSubcategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddSubcategory.Location = new System.Drawing.Point(541, 214);
            this.btnAddSubcategory.Name = "btnAddSubcategory";
            this.btnAddSubcategory.Size = new System.Drawing.Size(47, 24);
            this.btnAddSubcategory.TabIndex = 151;
            this.btnAddSubcategory.Text = "Add";
            this.btnAddSubcategory.UseVisualStyleBackColor = false;
            this.btnAddSubcategory.Click += new System.EventHandler(this.btnAddSubcategory_Click);
            // 
            // btnDeleteBrand
            // 
            this.btnDeleteBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteBrand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeleteBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnDeleteBrand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteBrand.Location = new System.Drawing.Point(969, 214);
            this.btnDeleteBrand.Name = "btnDeleteBrand";
            this.btnDeleteBrand.Size = new System.Drawing.Size(60, 24);
            this.btnDeleteBrand.TabIndex = 156;
            this.btnDeleteBrand.Text = "Delete";
            this.btnDeleteBrand.UseVisualStyleBackColor = false;
            this.btnDeleteBrand.Click += new System.EventHandler(this.btnDeleteBrand_Click);
            // 
            // btnEditBrand
            // 
            this.btnEditBrand.BackColor = System.Drawing.Color.Black;
            this.btnEditBrand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEditBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditBrand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditBrand.Location = new System.Drawing.Point(918, 214);
            this.btnEditBrand.Name = "btnEditBrand";
            this.btnEditBrand.Size = new System.Drawing.Size(47, 24);
            this.btnEditBrand.TabIndex = 155;
            this.btnEditBrand.Text = "Edit";
            this.btnEditBrand.UseVisualStyleBackColor = false;
            this.btnEditBrand.Click += new System.EventHandler(this.btnEditBrand_Click);
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.BackColor = System.Drawing.Color.Black;
            this.btnAddBrand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddBrand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddBrand.Location = new System.Drawing.Point(867, 214);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(47, 24);
            this.btnAddBrand.TabIndex = 154;
            this.btnAddBrand.Text = "Add";
            this.btnAddBrand.UseVisualStyleBackColor = false;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCategoryName.Location = new System.Drawing.Point(46, 269);
            this.txtCategoryName.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtCategoryName.MaxLength = 100;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(154, 19);
            this.txtCategoryName.TabIndex = 157;
            this.txtCategoryName.Visible = false;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategoryName.Location = new System.Drawing.Point(47, 246);
            this.lblCategoryName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(119, 17);
            this.lblCategoryName.TabIndex = 158;
            this.lblCategoryName.Text = "Category Name";
            this.lblCategoryName.Visible = false;
            // 
            // lblSubcategoryName
            // 
            this.lblSubcategoryName.AutoSize = true;
            this.lblSubcategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubcategoryName.Location = new System.Drawing.Point(387, 246);
            this.lblSubcategoryName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubcategoryName.Name = "lblSubcategoryName";
            this.lblSubcategoryName.Size = new System.Drawing.Size(145, 17);
            this.lblSubcategoryName.TabIndex = 160;
            this.lblSubcategoryName.Text = "Subcategory Name";
            this.lblSubcategoryName.Visible = false;
            // 
            // txtSubcategoryName
            // 
            this.txtSubcategoryName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubcategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSubcategoryName.Location = new System.Drawing.Point(386, 269);
            this.txtSubcategoryName.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtSubcategoryName.MaxLength = 100;
            this.txtSubcategoryName.Name = "txtSubcategoryName";
            this.txtSubcategoryName.Size = new System.Drawing.Size(146, 19);
            this.txtSubcategoryName.TabIndex = 159;
            this.txtSubcategoryName.Visible = false;
            // 
            // lblBrandName
            // 
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblBrandName.Location = new System.Drawing.Point(715, 246);
            this.lblBrandName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(97, 17);
            this.lblBrandName.TabIndex = 162;
            this.lblBrandName.Text = "Brand Name";
            this.lblBrandName.Visible = false;
            // 
            // txtBrandName
            // 
            this.txtBrandName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBrandName.Location = new System.Drawing.Point(714, 269);
            this.txtBrandName.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtBrandName.MaxLength = 100;
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(144, 19);
            this.txtBrandName.TabIndex = 161;
            this.txtBrandName.Visible = false;
            // 
            // btnSaveSubcategory
            // 
            this.btnSaveSubcategory.BackColor = System.Drawing.Color.Black;
            this.btnSaveSubcategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveSubcategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveSubcategory.Location = new System.Drawing.Point(543, 267);
            this.btnSaveSubcategory.Name = "btnSaveSubcategory";
            this.btnSaveSubcategory.Size = new System.Drawing.Size(47, 24);
            this.btnSaveSubcategory.TabIndex = 163;
            this.btnSaveSubcategory.Text = "Save";
            this.btnSaveSubcategory.UseVisualStyleBackColor = false;
            this.btnSaveSubcategory.Visible = false;
            this.btnSaveSubcategory.Click += new System.EventHandler(this.btnSaveSubcategory_Click);
            // 
            // btnCancelSubcategory
            // 
            this.btnCancelSubcategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelSubcategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelSubcategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelSubcategory.Location = new System.Drawing.Point(599, 267);
            this.btnCancelSubcategory.Name = "btnCancelSubcategory";
            this.btnCancelSubcategory.Size = new System.Drawing.Size(60, 24);
            this.btnCancelSubcategory.TabIndex = 164;
            this.btnCancelSubcategory.Text = "Cancel";
            this.btnCancelSubcategory.UseVisualStyleBackColor = false;
            this.btnCancelSubcategory.Visible = false;
            this.btnCancelSubcategory.Click += new System.EventHandler(this.btnCancelSubcategory_Click);
            // 
            // btnCancelCategory
            // 
            this.btnCancelCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelCategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelCategory.Location = new System.Drawing.Point(268, 267);
            this.btnCancelCategory.Name = "btnCancelCategory";
            this.btnCancelCategory.Size = new System.Drawing.Size(60, 24);
            this.btnCancelCategory.TabIndex = 166;
            this.btnCancelCategory.Text = "Cancel";
            this.btnCancelCategory.UseVisualStyleBackColor = false;
            this.btnCancelCategory.Visible = false;
            this.btnCancelCategory.Click += new System.EventHandler(this.btnCancelCategory_Click);
            // 
            // btnSaveCategory
            // 
            this.btnSaveCategory.BackColor = System.Drawing.Color.Black;
            this.btnSaveCategory.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveCategory.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveCategory.Location = new System.Drawing.Point(212, 267);
            this.btnSaveCategory.Name = "btnSaveCategory";
            this.btnSaveCategory.Size = new System.Drawing.Size(47, 24);
            this.btnSaveCategory.TabIndex = 165;
            this.btnSaveCategory.Text = "Save";
            this.btnSaveCategory.UseVisualStyleBackColor = false;
            this.btnSaveCategory.Visible = false;
            this.btnSaveCategory.Click += new System.EventHandler(this.btnSaveCategory_Click);
            // 
            // btnCancelBrand
            // 
            this.btnCancelBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelBrand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelBrand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelBrand.Location = new System.Drawing.Point(923, 266);
            this.btnCancelBrand.Name = "btnCancelBrand";
            this.btnCancelBrand.Size = new System.Drawing.Size(60, 24);
            this.btnCancelBrand.TabIndex = 168;
            this.btnCancelBrand.Text = "Cancel";
            this.btnCancelBrand.UseVisualStyleBackColor = false;
            this.btnCancelBrand.Visible = false;
            this.btnCancelBrand.Click += new System.EventHandler(this.btnCancelBrand_Click);
            // 
            // btnSaveBrand
            // 
            this.btnSaveBrand.BackColor = System.Drawing.Color.Black;
            this.btnSaveBrand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveBrand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveBrand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveBrand.Location = new System.Drawing.Point(867, 266);
            this.btnSaveBrand.Name = "btnSaveBrand";
            this.btnSaveBrand.Size = new System.Drawing.Size(47, 24);
            this.btnSaveBrand.TabIndex = 167;
            this.btnSaveBrand.Text = "Save";
            this.btnSaveBrand.UseVisualStyleBackColor = false;
            this.btnSaveBrand.Visible = false;
            this.btnSaveBrand.Click += new System.EventHandler(this.btnSaveBrand_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1068, 662);
            this.Controls.Add(this.btnCancelBrand);
            this.Controls.Add(this.btnSaveBrand);
            this.Controls.Add(this.btnCancelCategory);
            this.Controls.Add(this.btnSaveCategory);
            this.Controls.Add(this.btnCancelSubcategory);
            this.Controls.Add(this.btnSaveSubcategory);
            this.Controls.Add(this.lblBrandName);
            this.Controls.Add(this.txtBrandName);
            this.Controls.Add(this.lblSubcategoryName);
            this.Controls.Add(this.txtSubcategoryName);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.btnDeleteBrand);
            this.Controls.Add(this.btnEditBrand);
            this.Controls.Add(this.btnAddBrand);
            this.Controls.Add(this.btnDeleteSubcategory);
            this.Controls.Add(this.btnEditSubcategory);
            this.Controls.Add(this.btnAddSubcategory);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnEditCategory);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRemoveImage5);
            this.Controls.Add(this.btnRemoveImage4);
            this.Controls.Add(this.btnRemoveImage3);
            this.Controls.Add(this.btnRemoveImage2);
            this.Controls.Add(this.btnRemoveImage1);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.pbImage5);
            this.Controls.Add(this.pbImage4);
            this.Controls.Add(this.pbImage3);
            this.Controls.Add(this.pbImage2);
            this.Controls.Add(this.pbImage1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxBrand);
            this.Controls.Add(this.cbxSubcategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtxtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudQuantityInStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCategory);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdateProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Product";
            this.Load += new System.EventHandler(this.frmAddUpdateProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudQuantityInStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxSubcategory;
        private System.Windows.Forms.ComboBox cbxBrand;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DateTimePicker dtpReleaseDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbImage1;
        private System.Windows.Forms.PictureBox pbImage2;
        private System.Windows.Forms.PictureBox pbImage3;
        private System.Windows.Forms.PictureBox pbImage4;
        private System.Windows.Forms.PictureBox pbImage5;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnRemoveImage1;
        private System.Windows.Forms.Button btnRemoveImage2;
        private System.Windows.Forms.Button btnRemoveImage3;
        private System.Windows.Forms.Button btnRemoveImage4;
        private System.Windows.Forms.Button btnRemoveImage5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFileDialogForImage;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnDeleteSubcategory;
        private System.Windows.Forms.Button btnEditSubcategory;
        private System.Windows.Forms.Button btnAddSubcategory;
        private System.Windows.Forms.Button btnDeleteBrand;
        private System.Windows.Forms.Button btnEditBrand;
        private System.Windows.Forms.Button btnAddBrand;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblSubcategoryName;
        private System.Windows.Forms.TextBox txtSubcategoryName;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.Button btnSaveSubcategory;
        private System.Windows.Forms.Button btnCancelSubcategory;
        private System.Windows.Forms.Button btnCancelCategory;
        private System.Windows.Forms.Button btnSaveCategory;
        private System.Windows.Forms.Button btnCancelBrand;
        private System.Windows.Forms.Button btnSaveBrand;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}