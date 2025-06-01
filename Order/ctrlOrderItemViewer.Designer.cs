namespace Computer_Store
{
    partial class ctrlOrderItemViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblTotalItemsPrice = new System.Windows.Forms.Label();
            this.lblOneItemPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.llblRemove = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.pbSub = new System.Windows.Forms.PictureBox();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.lblQuantityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(145, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(222, 52);
            this.lblName.TabIndex = 118;
            this.lblName.Text = "OrderItem name";
            // 
            // lblTotalItemsPrice
            // 
            this.lblTotalItemsPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalItemsPrice.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalItemsPrice.Location = new System.Drawing.Point(370, 47);
            this.lblTotalItemsPrice.Name = "lblTotalItemsPrice";
            this.lblTotalItemsPrice.Size = new System.Drawing.Size(146, 24);
            this.lblTotalItemsPrice.TabIndex = 119;
            this.lblTotalItemsPrice.Text = "0.00$";
            this.lblTotalItemsPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOneItemPrice
            // 
            this.lblOneItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblOneItemPrice.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblOneItemPrice.Location = new System.Drawing.Point(145, 93);
            this.lblOneItemPrice.Name = "lblOneItemPrice";
            this.lblOneItemPrice.Size = new System.Drawing.Size(85, 20);
            this.lblOneItemPrice.TabIndex = 120;
            this.lblOneItemPrice.Text = "0.00$";
            this.lblOneItemPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(431, 17);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(19, 20);
            this.lblQuantity.TabIndex = 123;
            this.lblQuantity.Text = "1";
            // 
            // llblRemove
            // 
            this.llblRemove.AutoSize = true;
            this.llblRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.llblRemove.Location = new System.Drawing.Point(442, 93);
            this.llblRemove.Name = "llblRemove";
            this.llblRemove.Size = new System.Drawing.Size(68, 20);
            this.llblRemove.TabIndex = 124;
            this.llblRemove.TabStop = true;
            this.llblRemove.Text = "Remove";
            this.llblRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRemove_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 125;
            this.label1.Text = "Product ID:";
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductID.Location = new System.Drawing.Point(229, 70);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(16, 17);
            this.lblProductID.TabIndex = 126;
            this.lblProductID.Text = "0";
            // 
            // pbSub
            // 
            this.pbSub.Image = global::Computer_Store.Properties.Resources.minus__1_;
            this.pbSub.Location = new System.Drawing.Point(381, 13);
            this.pbSub.Name = "pbSub";
            this.pbSub.Size = new System.Drawing.Size(25, 25);
            this.pbSub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSub.TabIndex = 122;
            this.pbSub.TabStop = false;
            this.pbSub.Click += new System.EventHandler(this.pbSub_Click);
            this.pbSub.MouseLeave += new System.EventHandler(this.pbSub_MouseLeave);
            this.pbSub.MouseHover += new System.EventHandler(this.pbSub_MouseHover);
            // 
            // pbAdd
            // 
            this.pbAdd.Image = global::Computer_Store.Properties.Resources.plus;
            this.pbAdd.Location = new System.Drawing.Point(480, 13);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(25, 25);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAdd.TabIndex = 121;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            this.pbAdd.MouseLeave += new System.EventHandler(this.pbAdd_MouseLeave);
            this.pbAdd.MouseHover += new System.EventHandler(this.pbAdd_MouseHover);
            // 
            // pbProductImage
            // 
            this.pbProductImage.Image = global::Computer_Store.Properties.Resources.No_Image;
            this.pbProductImage.Location = new System.Drawing.Point(3, 1);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(128, 119);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProductImage.TabIndex = 1;
            this.pbProductImage.TabStop = false;
            // 
            // lblQuantityLabel
            // 
            this.lblQuantityLabel.AutoSize = true;
            this.lblQuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityLabel.Location = new System.Drawing.Point(286, 93);
            this.lblQuantityLabel.Name = "lblQuantityLabel";
            this.lblQuantityLabel.Size = new System.Drawing.Size(81, 20);
            this.lblQuantityLabel.TabIndex = 127;
            this.lblQuantityLabel.Text = "Quantity:";
            this.lblQuantityLabel.Visible = false;
            // 
            // ctrlOrderItemViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblQuantityLabel);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llblRemove);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.pbSub);
            this.Controls.Add(this.pbAdd);
            this.Controls.Add(this.lblOneItemPrice);
            this.Controls.Add(this.lblTotalItemsPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbProductImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlOrderItemViewer";
            this.Size = new System.Drawing.Size(526, 122);
            ((System.ComponentModel.ISupportInitialize)(this.pbSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTotalItemsPrice;
        private System.Windows.Forms.Label lblOneItemPrice;
        private System.Windows.Forms.PictureBox pbAdd;
        private System.Windows.Forms.PictureBox pbSub;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.LinkLabel llblRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label lblQuantityLabel;
    }
}
