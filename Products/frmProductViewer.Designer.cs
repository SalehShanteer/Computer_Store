namespace Computer_Store
{
    partial class frmProductViewer
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.lblProductInStock = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblSubcategory = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblReviewsCount = new System.Windows.Forms.Label();
            this.btnAddEditReview = new System.Windows.Forms.Button();
            this.rtxtReviewText = new System.Windows.Forms.RichTextBox();
            this.rbOne = new System.Windows.Forms.RadioButton();
            this.rbTwo = new System.Windows.Forms.RadioButton();
            this.rbThree = new System.Windows.Forms.RadioButton();
            this.rbFour = new System.Windows.Forms.RadioButton();
            this.rbFive = new System.Windows.Forms.RadioButton();
            this.lblRatinglabel = new System.Windows.Forms.Label();
            this.pbSend = new System.Windows.Forms.PictureBox();
            this.pbNext = new System.Windows.Forms.PictureBox();
            this.pbPrevious = new System.Windows.Forms.PictureBox();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.nudQuantityToCart = new System.Windows.Forms.NumericUpDown();
            this.ctrlStarsRating = new Computer_Store.ctrlStarsRating();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityToCart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 111;
            this.label1.Text = "Rating:";
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblProductPrice.Location = new System.Drawing.Point(429, 257);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(142, 31);
            this.lblProductPrice.TabIndex = 112;
            this.lblProductPrice.Text = "0.00$";
            this.lblProductPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProductInStock
            // 
            this.lblProductInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductInStock.Location = new System.Drawing.Point(90, 533);
            this.lblProductInStock.Name = "lblProductInStock";
            this.lblProductInStock.Size = new System.Drawing.Size(212, 24);
            this.lblProductInStock.TabIndex = 113;
            this.lblProductInStock.Text = "In Stock";
            this.lblProductInStock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblProductID.Location = new System.Drawing.Point(697, 556);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(16, 18);
            this.lblProductID.TabIndex = 116;
            this.lblProductID.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(597, 556);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 18);
            this.label2.TabIndex = 115;
            this.label2.Text = "ID:";
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(419, 111);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(394, 24);
            this.lblProductName.TabIndex = 114;
            this.lblProductName.Text = "Product Name";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(597, 585);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 119;
            this.label3.Text = "Category:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(597, 618);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 120;
            this.label4.Text = "Subategory:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(597, 652);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 121;
            this.label5.Text = "Brand:";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(434, 299);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(373, 194);
            this.lblDescription.TabIndex = 122;
            this.lblDescription.Text = "Description";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(697, 587);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(30, 16);
            this.lblCategory.TabIndex = 123;
            this.lblCategory.Text = "N/A";
            // 
            // lblSubcategory
            // 
            this.lblSubcategory.AutoSize = true;
            this.lblSubcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubcategory.Location = new System.Drawing.Point(697, 620);
            this.lblSubcategory.Name = "lblSubcategory";
            this.lblSubcategory.Size = new System.Drawing.Size(30, 16);
            this.lblSubcategory.TabIndex = 124;
            this.lblSubcategory.Text = "N/A";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(697, 654);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(30, 16);
            this.lblBrand.TabIndex = 125;
            this.lblBrand.Text = "N/A";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pbExit);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 39);
            this.panel1.TabIndex = 126;
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pbExit.Image = global::Computer_Store.Properties.Resources.Close_Login;
            this.pbExit.Location = new System.Drawing.Point(786, 3);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(32, 32);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExit.TabIndex = 108;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Location = new System.Drawing.Point(-1, 697);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 18);
            this.panel2.TabIndex = 127;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Location = new System.Drawing.Point(818, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(12, 664);
            this.panel3.TabIndex = 128;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Location = new System.Drawing.Point(-1, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 664);
            this.panel4.TabIndex = 129;
            // 
            // lblReviewsCount
            // 
            this.lblReviewsCount.AutoSize = true;
            this.lblReviewsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblReviewsCount.Location = new System.Drawing.Point(312, 493);
            this.lblReviewsCount.Name = "lblReviewsCount";
            this.lblReviewsCount.Size = new System.Drawing.Size(26, 18);
            this.lblReviewsCount.TabIndex = 130;
            this.lblReviewsCount.Text = "(0)";
            // 
            // btnAddEditReview
            // 
            this.btnAddEditReview.BackColor = System.Drawing.Color.Black;
            this.btnAddEditReview.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddEditReview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddEditReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddEditReview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddEditReview.Location = new System.Drawing.Point(29, 572);
            this.btnAddEditReview.Name = "btnAddEditReview";
            this.btnAddEditReview.Size = new System.Drawing.Size(104, 29);
            this.btnAddEditReview.TabIndex = 131;
            this.btnAddEditReview.Text = "Add Review";
            this.btnAddEditReview.UseVisualStyleBackColor = false;
            this.btnAddEditReview.Click += new System.EventHandler(this.btnAddEditReview_Click);
            // 
            // rtxtReviewText
            // 
            this.rtxtReviewText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtReviewText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.rtxtReviewText.Location = new System.Drawing.Point(28, 607);
            this.rtxtReviewText.MaxLength = 255;
            this.rtxtReviewText.Name = "rtxtReviewText";
            this.rtxtReviewText.Size = new System.Drawing.Size(402, 71);
            this.rtxtReviewText.TabIndex = 132;
            this.rtxtReviewText.Text = "";
            this.rtxtReviewText.Visible = false;
            // 
            // rbOne
            // 
            this.rbOne.AutoSize = true;
            this.rbOne.Checked = true;
            this.rbOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbOne.Location = new System.Drawing.Point(148, 574);
            this.rbOne.Name = "rbOne";
            this.rbOne.Size = new System.Drawing.Size(34, 21);
            this.rbOne.TabIndex = 133;
            this.rbOne.TabStop = true;
            this.rbOne.Text = "1";
            this.rbOne.UseVisualStyleBackColor = true;
            this.rbOne.Visible = false;
            // 
            // rbTwo
            // 
            this.rbTwo.AutoSize = true;
            this.rbTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbTwo.Location = new System.Drawing.Point(188, 574);
            this.rbTwo.Name = "rbTwo";
            this.rbTwo.Size = new System.Drawing.Size(34, 21);
            this.rbTwo.TabIndex = 134;
            this.rbTwo.Text = "2";
            this.rbTwo.UseVisualStyleBackColor = true;
            this.rbTwo.Visible = false;
            // 
            // rbThree
            // 
            this.rbThree.AutoSize = true;
            this.rbThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbThree.Location = new System.Drawing.Point(228, 574);
            this.rbThree.Name = "rbThree";
            this.rbThree.Size = new System.Drawing.Size(34, 21);
            this.rbThree.TabIndex = 135;
            this.rbThree.Text = "3";
            this.rbThree.UseVisualStyleBackColor = true;
            this.rbThree.Visible = false;
            // 
            // rbFour
            // 
            this.rbFour.AutoSize = true;
            this.rbFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbFour.Location = new System.Drawing.Point(270, 574);
            this.rbFour.Name = "rbFour";
            this.rbFour.Size = new System.Drawing.Size(34, 21);
            this.rbFour.TabIndex = 136;
            this.rbFour.Text = "4";
            this.rbFour.UseVisualStyleBackColor = true;
            this.rbFour.Visible = false;
            // 
            // rbFive
            // 
            this.rbFive.AutoSize = true;
            this.rbFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbFive.Location = new System.Drawing.Point(315, 574);
            this.rbFive.Name = "rbFive";
            this.rbFive.Size = new System.Drawing.Size(34, 21);
            this.rbFive.TabIndex = 137;
            this.rbFive.Text = "5";
            this.rbFive.UseVisualStyleBackColor = true;
            this.rbFive.Visible = false;
            // 
            // lblRatinglabel
            // 
            this.lblRatinglabel.AutoSize = true;
            this.lblRatinglabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblRatinglabel.Location = new System.Drawing.Point(353, 576);
            this.lblRatinglabel.Name = "lblRatinglabel";
            this.lblRatinglabel.Size = new System.Drawing.Size(50, 18);
            this.lblRatinglabel.TabIndex = 138;
            this.lblRatinglabel.Text = "Rating";
            this.lblRatinglabel.Visible = false;
            // 
            // pbSend
            // 
            this.pbSend.Image = global::Computer_Store.Properties.Resources.Send;
            this.pbSend.Location = new System.Drawing.Point(437, 625);
            this.pbSend.Name = "pbSend";
            this.pbSend.Size = new System.Drawing.Size(40, 42);
            this.pbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSend.TabIndex = 139;
            this.pbSend.TabStop = false;
            this.pbSend.Visible = false;
            this.pbSend.Click += new System.EventHandler(this.pbSend_Click);
            this.pbSend.MouseLeave += new System.EventHandler(this.pbSend_MouseLeave);
            this.pbSend.MouseHover += new System.EventHandler(this.pbSend_MouseHover);
            // 
            // pbNext
            // 
            this.pbNext.Image = global::Computer_Store.Properties.Resources.right_arrow;
            this.pbNext.Location = new System.Drawing.Point(259, 423);
            this.pbNext.Name = "pbNext";
            this.pbNext.Size = new System.Drawing.Size(43, 39);
            this.pbNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNext.TabIndex = 118;
            this.pbNext.TabStop = false;
            this.pbNext.Click += new System.EventHandler(this.pbNext_Click);
            this.pbNext.MouseLeave += new System.EventHandler(this.pbNext_MouseLeave);
            this.pbNext.MouseHover += new System.EventHandler(this.pbNext_MouseHover);
            // 
            // pbPrevious
            // 
            this.pbPrevious.Image = global::Computer_Store.Properties.Resources.left_arrow;
            this.pbPrevious.Location = new System.Drawing.Point(148, 423);
            this.pbPrevious.Name = "pbPrevious";
            this.pbPrevious.Size = new System.Drawing.Size(43, 39);
            this.pbPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrevious.TabIndex = 117;
            this.pbPrevious.TabStop = false;
            this.pbPrevious.Click += new System.EventHandler(this.pbPrevious_Click);
            this.pbPrevious.MouseLeave += new System.EventHandler(this.pbPrevious_MouseLeave);
            this.pbPrevious.MouseHover += new System.EventHandler(this.pbPrevious_MouseHover);
            // 
            // pbProductImage
            // 
            this.pbProductImage.Image = global::Computer_Store.Properties.Resources.No_Image;
            this.pbProductImage.Location = new System.Drawing.Point(20, 82);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(397, 335);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImage.TabIndex = 110;
            this.pbProductImage.TabStop = false;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.Gray;
            this.btnAddToCart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddToCart.Enabled = false;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.ForeColor = System.Drawing.Color.Black;
            this.btnAddToCart.Location = new System.Drawing.Point(673, 496);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(116, 29);
            this.btnAddToCart.TabIndex = 140;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // nudQuantityToCart
            // 
            this.nudQuantityToCart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudQuantityToCart.Location = new System.Drawing.Point(614, 497);
            this.nudQuantityToCart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudQuantityToCart.Name = "nudQuantityToCart";
            this.nudQuantityToCart.Size = new System.Drawing.Size(43, 26);
            this.nudQuantityToCart.TabIndex = 141;
            this.nudQuantityToCart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudQuantityToCart.ValueChanged += new System.EventHandler(this.nudQuantityToCart_ValueChanged);
            // 
            // ctrlStarsRating
            // 
            this.ctrlStarsRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctrlStarsRating.Location = new System.Drawing.Point(139, 486);
            this.ctrlStarsRating.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlStarsRating.Name = "ctrlStarsRating";
            this.ctrlStarsRating.RateFrom = 5;
            this.ctrlStarsRating.Size = new System.Drawing.Size(165, 32);
            this.ctrlStarsRating.TabIndex = 109;
            // 
            // frmProductViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(828, 714);
            this.Controls.Add(this.nudQuantityToCart);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.pbSend);
            this.Controls.Add(this.lblRatinglabel);
            this.Controls.Add(this.rbFive);
            this.Controls.Add(this.rbFour);
            this.Controls.Add(this.rbThree);
            this.Controls.Add(this.rbTwo);
            this.Controls.Add(this.rbOne);
            this.Controls.Add(this.rtxtReviewText);
            this.Controls.Add(this.btnAddEditReview);
            this.Controls.Add(this.lblReviewsCount);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblSubcategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbNext);
            this.Controls.Add(this.pbPrevious);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblProductInStock);
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbProductImage);
            this.Controls.Add(this.ctrlStarsRating);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmProductViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductViewer";
            this.Load += new System.EventHandler(this.frmProductViewer_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityToCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbExit;
        private ctrlStarsRating ctrlStarsRating;
        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.Label lblProductInStock;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.PictureBox pbPrevious;
        private System.Windows.Forms.PictureBox pbNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSubcategory;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblReviewsCount;
        private System.Windows.Forms.Button btnAddEditReview;
        private System.Windows.Forms.RichTextBox rtxtReviewText;
        private System.Windows.Forms.RadioButton rbOne;
        private System.Windows.Forms.RadioButton rbTwo;
        private System.Windows.Forms.RadioButton rbThree;
        private System.Windows.Forms.RadioButton rbFour;
        private System.Windows.Forms.RadioButton rbFive;
        private System.Windows.Forms.Label lblRatinglabel;
        private System.Windows.Forms.PictureBox pbSend;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.NumericUpDown nudQuantityToCart;
    }
}