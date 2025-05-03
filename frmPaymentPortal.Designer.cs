namespace Computer_Store
{
    partial class frmPaymentPortal
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
            this.cbxShippingCarriers = new System.Windows.Forms.ComboBox();
            this.lblEmptyCart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShippingAddress = new System.Windows.Forms.TextBox();
            this.lblEstimatedDeliveryDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblShippingCost = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxPaymentMethods = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pbEmptyCart = new System.Windows.Forms.PictureBox();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmptyCart)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxShippingCarriers
            // 
            this.cbxShippingCarriers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxShippingCarriers.FormattingEnabled = true;
            this.cbxShippingCarriers.Location = new System.Drawing.Point(249, 89);
            this.cbxShippingCarriers.Name = "cbxShippingCarriers";
            this.cbxShippingCarriers.Size = new System.Drawing.Size(133, 28);
            this.cbxShippingCarriers.TabIndex = 0;
            // 
            // lblEmptyCart
            // 
            this.lblEmptyCart.AutoSize = true;
            this.lblEmptyCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmptyCart.Location = new System.Drawing.Point(244, 45);
            this.lblEmptyCart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmptyCart.Name = "lblEmptyCart";
            this.lblEmptyCart.Size = new System.Drawing.Size(129, 18);
            this.lblEmptyCart.TabIndex = 145;
            this.lblEmptyCart.Text = "Shipping Carrier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(402, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 18);
            this.label1.TabIndex = 146;
            this.label1.Text = "Estimated Delivery Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(402, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 147;
            this.label2.Text = "Shipping Address";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Location = new System.Drawing.Point(406, 89);
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new System.Drawing.Size(152, 26);
            this.txtShippingAddress.TabIndex = 148;
            // 
            // lblEstimatedDeliveryDate
            // 
            this.lblEstimatedDeliveryDate.AutoSize = true;
            this.lblEstimatedDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblEstimatedDeliveryDate.Location = new System.Drawing.Point(467, 186);
            this.lblEstimatedDeliveryDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstimatedDeliveryDate.Name = "lblEstimatedDeliveryDate";
            this.lblEstimatedDeliveryDate.Size = new System.Drawing.Size(43, 18);
            this.lblEstimatedDeliveryDate.TabIndex = 149;
            this.lblEstimatedDeliveryDate.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(639, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 151;
            this.label4.Text = "Total Amount:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(761, 157);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(146, 24);
            this.lblTotalPrice.TabIndex = 150;
            this.lblTotalPrice.Text = "$0.00";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblPrice.Location = new System.Drawing.Point(755, 68);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(146, 24);
            this.lblPrice.TabIndex = 152;
            this.lblPrice.Text = "$0.00";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblShippingCost
            // 
            this.lblShippingCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblShippingCost.ForeColor = System.Drawing.Color.Black;
            this.lblShippingCost.Location = new System.Drawing.Point(766, 113);
            this.lblShippingCost.Name = "lblShippingCost";
            this.lblShippingCost.Size = new System.Drawing.Size(127, 24);
            this.lblShippingCost.TabIndex = 154;
            this.lblShippingCost.Text = "$0.00";
            this.lblShippingCost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(677, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 155;
            this.label7.Text = "Shipping";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(854, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 24);
            this.label8.TabIndex = 156;
            this.label8.Text = "+";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbxPaymentMethods
            // 
            this.cbxPaymentMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPaymentMethods.FormattingEnabled = true;
            this.cbxPaymentMethods.Location = new System.Drawing.Point(247, 182);
            this.cbxPaymentMethods.Name = "cbxPaymentMethods";
            this.cbxPaymentMethods.Size = new System.Drawing.Size(134, 28);
            this.cbxPaymentMethods.TabIndex = 157;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(239, 145);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 18);
            this.label9.TabIndex = 158;
            this.label9.Text = "Payment Method";
            // 
            // pbEmptyCart
            // 
            this.pbEmptyCart.Image = global::Computer_Store.Properties.Resources.Payment;
            this.pbEmptyCart.Location = new System.Drawing.Point(12, 26);
            this.pbEmptyCart.Name = "pbEmptyCart";
            this.pbEmptyCart.Size = new System.Drawing.Size(200, 199);
            this.pbEmptyCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmptyCart.TabIndex = 159;
            this.pbEmptyCart.TabStop = false;
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackColor = System.Drawing.Color.Black;
            this.btnPurchase.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPurchase.Location = new System.Drawing.Point(813, 230);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(92, 31);
            this.btnPurchase.TabIndex = 160;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = false;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(782, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 3);
            this.panel1.TabIndex = 153;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(612, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 150);
            this.panel2.TabIndex = 161;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(643, 230);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 31);
            this.btnClose.TabIndex = 162;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPaymentPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(946, 268);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.pbEmptyCart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxPaymentMethods);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblShippingCost);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblEstimatedDeliveryDate);
            this.Controls.Add(this.txtShippingAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEmptyCart);
            this.Controls.Add(this.cbxShippingCarriers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPaymentPortal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Portal";
            this.Load += new System.EventHandler(this.frmPaymentPortal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEmptyCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxShippingCarriers;
        private System.Windows.Forms.Label lblEmptyCart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShippingAddress;
        private System.Windows.Forms.Label lblEstimatedDeliveryDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblShippingCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxPaymentMethods;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pbEmptyCart;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
    }
}