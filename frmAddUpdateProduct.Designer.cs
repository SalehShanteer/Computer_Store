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
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage5)).BeginInit();
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
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(42, 147);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtProductName.MaxLength = 100;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(248, 22);
            this.txtProductName.TabIndex = 117;
            // 
            // cbxCategory
            // 
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(358, 146);
            this.cbxCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(180, 24);
            this.cbxCategory.TabIndex = 119;
            this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.cbxCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 119);
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
            this.label2.Location = new System.Drawing.Point(598, 121);
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
            this.label3.Location = new System.Drawing.Point(821, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 124;
            this.label3.Text = "Brand";
            // 
            // nudQuantityInStock
            // 
            this.nudQuantityInStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudQuantityInStock.Location = new System.Drawing.Point(358, 232);
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
            this.label4.Location = new System.Drawing.Point(354, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 126;
            this.label4.Text = "Quantity In Stock";
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtDescription.Location = new System.Drawing.Point(43, 301);
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
            this.label5.Location = new System.Drawing.Point(43, 274);
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
            this.cbxSubcategory.Location = new System.Drawing.Point(602, 146);
            this.cbxSubcategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSubcategory.Name = "cbxSubcategory";
            this.cbxSubcategory.Size = new System.Drawing.Size(180, 24);
            this.cbxSubcategory.TabIndex = 129;
            // 
            // cbxBrand
            // 
            this.cbxBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbxBrand.FormattingEnabled = true;
            this.cbxBrand.Location = new System.Drawing.Point(822, 146);
            this.cbxBrand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxBrand.Name = "cbxBrand";
            this.cbxBrand.Size = new System.Drawing.Size(180, 24);
            this.cbxBrand.TabIndex = 130;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(881, 599);
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
            this.label6.Location = new System.Drawing.Point(42, 201);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 133;
            this.label6.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(42, 228);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(248, 22);
            this.txtPrice.TabIndex = 132;
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReleaseDate.Location = new System.Drawing.Point(602, 228);
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
            this.label7.Location = new System.Drawing.Point(606, 201);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 20);
            this.label7.TabIndex = 135;
            this.label7.Text = "Release Date";
            // 
            // pbImage1
            // 
            this.pbImage1.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage1.Location = new System.Drawing.Point(43, 389);
            this.pbImage1.Name = "pbImage1";
            this.pbImage1.Size = new System.Drawing.Size(144, 147);
            this.pbImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage1.TabIndex = 136;
            this.pbImage1.TabStop = false;
            // 
            // pbImage2
            // 
            this.pbImage2.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage2.Location = new System.Drawing.Point(213, 389);
            this.pbImage2.Name = "pbImage2";
            this.pbImage2.Size = new System.Drawing.Size(144, 147);
            this.pbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage2.TabIndex = 137;
            this.pbImage2.TabStop = false;
            // 
            // pbImage3
            // 
            this.pbImage3.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage3.Location = new System.Drawing.Point(378, 389);
            this.pbImage3.Name = "pbImage3";
            this.pbImage3.Size = new System.Drawing.Size(144, 147);
            this.pbImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage3.TabIndex = 138;
            this.pbImage3.TabStop = false;
            // 
            // pbImage4
            // 
            this.pbImage4.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage4.Location = new System.Drawing.Point(542, 389);
            this.pbImage4.Name = "pbImage4";
            this.pbImage4.Size = new System.Drawing.Size(144, 147);
            this.pbImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage4.TabIndex = 139;
            this.pbImage4.TabStop = false;
            // 
            // pbImage5
            // 
            this.pbImage5.Image = global::Computer_Store.Properties.Resources.addImage;
            this.pbImage5.Location = new System.Drawing.Point(714, 389);
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
            this.btnAddImage.Location = new System.Drawing.Point(881, 459);
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
            this.btnRemoveImage1.Location = new System.Drawing.Point(68, 552);
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
            this.btnRemoveImage2.Location = new System.Drawing.Point(243, 552);
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
            this.btnRemoveImage3.Location = new System.Drawing.Point(405, 552);
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
            this.btnRemoveImage4.Location = new System.Drawing.Point(571, 552);
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
            this.btnRemoveImage5.Location = new System.Drawing.Point(739, 552);
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
            this.btnClose.Location = new System.Drawing.Point(646, 599);
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
            // frmAddUpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1056, 643);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Product";
            this.Load += new System.EventHandler(this.frmAddUpdateProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage5)).EndInit();
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
    }
}