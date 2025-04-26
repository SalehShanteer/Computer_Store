namespace Computer_Store
{
    partial class frmOrderCart
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
            this.pnItemsContainer = new System.Windows.Forms.Panel();
            this.pbEmptyCart = new System.Windows.Forms.PictureBox();
            this.lblEmptyCart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmptyCart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(13, 60);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(341, 39);
            this.lblTitle.TabIndex = 115;
            this.lblTitle.Text = "Review Your Order";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnItemsContainer
            // 
            this.pnItemsContainer.AutoScroll = true;
            this.pnItemsContainer.BackColor = System.Drawing.Color.Silver;
            this.pnItemsContainer.Location = new System.Drawing.Point(12, 128);
            this.pnItemsContainer.Name = "pnItemsContainer";
            this.pnItemsContainer.Size = new System.Drawing.Size(550, 541);
            this.pnItemsContainer.TabIndex = 116;
            // 
            // pbEmptyCart
            // 
            this.pbEmptyCart.Image = global::Computer_Store.Properties.Resources.cart;
            this.pbEmptyCart.Location = new System.Drawing.Point(737, 174);
            this.pbEmptyCart.Name = "pbEmptyCart";
            this.pbEmptyCart.Size = new System.Drawing.Size(164, 134);
            this.pbEmptyCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmptyCart.TabIndex = 117;
            this.pbEmptyCart.TabStop = false;
            // 
            // lblEmptyCart
            // 
            this.lblEmptyCart.AutoSize = true;
            this.lblEmptyCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblEmptyCart.Location = new System.Drawing.Point(720, 415);
            this.lblEmptyCart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmptyCart.Name = "lblEmptyCart";
            this.lblEmptyCart.Size = new System.Drawing.Size(204, 26);
            this.lblEmptyCart.TabIndex = 144;
            this.lblEmptyCart.Text = "The Cart Is Empty";
            // 
            // frmOrderCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 681);
            this.Controls.Add(this.lblEmptyCart);
            this.Controls.Add(this.pbEmptyCart);
            this.Controls.Add(this.pnItemsContainer);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOrderCart";
            this.Text = "Order Cart";
            ((System.ComponentModel.ISupportInitialize)(this.pbEmptyCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnItemsContainer;
        private System.Windows.Forms.PictureBox pbEmptyCart;
        private System.Windows.Forms.Label lblEmptyCart;
    }
}