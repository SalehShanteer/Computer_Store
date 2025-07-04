﻿namespace Computer_Store
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
            this.lblEmptyCart = new System.Windows.Forms.Label();
            this.btnContinueToPayment = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblTotalAmountLabel = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnManageYourOrders = new System.Windows.Forms.Button();
            this.pbEmptyCart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmptyCart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(238, 44);
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
            this.pnItemsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnItemsContainer.Location = new System.Drawing.Point(12, 128);
            this.pnItemsContainer.Name = "pnItemsContainer";
            this.pnItemsContainer.Size = new System.Drawing.Size(550, 500);
            this.pnItemsContainer.TabIndex = 116;
            // 
            // lblEmptyCart
            // 
            this.lblEmptyCart.AutoSize = true;
            this.lblEmptyCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblEmptyCart.Location = new System.Drawing.Point(333, 423);
            this.lblEmptyCart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmptyCart.Name = "lblEmptyCart";
            this.lblEmptyCart.Size = new System.Drawing.Size(204, 26);
            this.lblEmptyCart.TabIndex = 144;
            this.lblEmptyCart.Text = "The Cart Is Empty";
            this.lblEmptyCart.Click += new System.EventHandler(this.lblEmptyCart_Click);
            // 
            // btnContinueToPayment
            // 
            this.btnContinueToPayment.BackColor = System.Drawing.Color.Black;
            this.btnContinueToPayment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnContinueToPayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnContinueToPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinueToPayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnContinueToPayment.Location = new System.Drawing.Point(599, 638);
            this.btnContinueToPayment.Name = "btnContinueToPayment";
            this.btnContinueToPayment.Size = new System.Drawing.Size(198, 31);
            this.btnContinueToPayment.TabIndex = 145;
            this.btnContinueToPayment.Text = "Continue To Payment";
            this.btnContinueToPayment.UseVisualStyleBackColor = false;
            this.btnContinueToPayment.Click += new System.EventHandler(this.btnContinueToPayment_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalPrice.Location = new System.Drawing.Point(626, 567);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(146, 24);
            this.lblTotalPrice.TabIndex = 146;
            this.lblTotalPrice.Text = "$0.00";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalAmountLabel
            // 
            this.lblTotalAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmountLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalAmountLabel.Location = new System.Drawing.Point(626, 531);
            this.lblTotalAmountLabel.Name = "lblTotalAmountLabel";
            this.lblTotalAmountLabel.Size = new System.Drawing.Size(153, 24);
            this.lblTotalAmountLabel.TabIndex = 147;
            this.lblTotalAmountLabel.Text = "Total Amount:";
            this.lblTotalAmountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(12, 638);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 31);
            this.btnClose.TabIndex = 148;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnManageYourOrders
            // 
            this.btnManageYourOrders.BackColor = System.Drawing.Color.Black;
            this.btnManageYourOrders.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnManageYourOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManageYourOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageYourOrders.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageYourOrders.Location = new System.Drawing.Point(364, 638);
            this.btnManageYourOrders.Name = "btnManageYourOrders";
            this.btnManageYourOrders.Size = new System.Drawing.Size(198, 31);
            this.btnManageYourOrders.TabIndex = 149;
            this.btnManageYourOrders.Text = "Manage Your Orders";
            this.btnManageYourOrders.UseVisualStyleBackColor = false;
            this.btnManageYourOrders.Click += new System.EventHandler(this.btnManageYourOrders_Click);
            // 
            // pbEmptyCart
            // 
            this.pbEmptyCart.Image = global::Computer_Store.Properties.Resources.cart;
            this.pbEmptyCart.Location = new System.Drawing.Point(349, 265);
            this.pbEmptyCart.Name = "pbEmptyCart";
            this.pbEmptyCart.Size = new System.Drawing.Size(164, 134);
            this.pbEmptyCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmptyCart.TabIndex = 117;
            this.pbEmptyCart.TabStop = false;
            this.pbEmptyCart.Click += new System.EventHandler(this.pbEmptyCart_Click);
            // 
            // frmOrderCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 681);
            this.Controls.Add(this.pbEmptyCart);
            this.Controls.Add(this.lblEmptyCart);
            this.Controls.Add(this.btnManageYourOrders);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotalAmountLabel);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.btnContinueToPayment);
            this.Controls.Add(this.pnItemsContainer);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOrderCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Cart";
            this.Load += new System.EventHandler(this.frmOrderCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmptyCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnItemsContainer;
        private System.Windows.Forms.PictureBox pbEmptyCart;
        private System.Windows.Forms.Label lblEmptyCart;
        private System.Windows.Forms.Button btnContinueToPayment;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblTotalAmountLabel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnManageYourOrders;
    }
}