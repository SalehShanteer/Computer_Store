namespace Computer_Store
{
    partial class frmManageUsersOrders
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
            this.dgvOrdersList = new System.Windows.Forms.DataGridView();
            this.cmsManageProducts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showOrderItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.startShippingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setShippingAsDeliveredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelShippingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersList)).BeginInit();
            this.cmsManageProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrdersList
            // 
            this.dgvOrdersList.AllowUserToAddRows = false;
            this.dgvOrdersList.AllowUserToDeleteRows = false;
            this.dgvOrdersList.AllowUserToOrderColumns = true;
            this.dgvOrdersList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOrdersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersList.ContextMenuStrip = this.cmsManageProducts;
            this.dgvOrdersList.Location = new System.Drawing.Point(12, 276);
            this.dgvOrdersList.Name = "dgvOrdersList";
            this.dgvOrdersList.ReadOnly = true;
            this.dgvOrdersList.Size = new System.Drawing.Size(1244, 413);
            this.dgvOrdersList.TabIndex = 1;
            // 
            // cmsManageProducts
            // 
            this.cmsManageProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOrderItemsToolStripMenuItem,
            this.startShippingToolStripMenuItem,
            this.setShippingAsDeliveredToolStripMenuItem,
            this.cancelShippingToolStripMenuItem});
            this.cmsManageProducts.Name = "cmsManageProducts";
            this.cmsManageProducts.Size = new System.Drawing.Size(251, 122);
            this.cmsManageProducts.Opening += new System.ComponentModel.CancelEventHandler(this.cmsManageProducts_Opening);
            // 
            // showOrderItemsToolStripMenuItem
            // 
            this.showOrderItemsToolStripMenuItem.Name = "showOrderItemsToolStripMenuItem";
            this.showOrderItemsToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.showOrderItemsToolStripMenuItem.Text = "Show Order Items";
            this.showOrderItemsToolStripMenuItem.Click += new System.EventHandler(this.showOrderItemsToolStripMenuItem_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(476, 202);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(308, 46);
            this.label.TabIndex = 169;
            this.label.Text = "Manage Orders";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(12, 695);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 31);
            this.button1.TabIndex = 171;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Computer_Store.Properties.Resources.ManageOrders;
            this.pictureBox1.Location = new System.Drawing.Point(541, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 170;
            this.pictureBox1.TabStop = false;
            // 
            // startShippingToolStripMenuItem
            // 
            this.startShippingToolStripMenuItem.Name = "startShippingToolStripMenuItem";
            this.startShippingToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.startShippingToolStripMenuItem.Text = "Start Shipping";
            this.startShippingToolStripMenuItem.Click += new System.EventHandler(this.startShippingToolStripMenuItem_Click);
            // 
            // setShippingAsDeliveredToolStripMenuItem
            // 
            this.setShippingAsDeliveredToolStripMenuItem.Name = "setShippingAsDeliveredToolStripMenuItem";
            this.setShippingAsDeliveredToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.setShippingAsDeliveredToolStripMenuItem.Text = "Set Shipping As Delivered";
            this.setShippingAsDeliveredToolStripMenuItem.Click += new System.EventHandler(this.setShippingAsDeliveredToolStripMenuItem_Click);
            // 
            // cancelShippingToolStripMenuItem
            // 
            this.cancelShippingToolStripMenuItem.Name = "cancelShippingToolStripMenuItem";
            this.cancelShippingToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.cancelShippingToolStripMenuItem.Text = "Cancel Shipping";
            this.cancelShippingToolStripMenuItem.Click += new System.EventHandler(this.cancelShippingToolStripMenuItem_Click);
            // 
            // frmManageUsersOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1274, 736);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.dgvOrdersList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmManageUsersOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageUsersOrders";
            this.Load += new System.EventHandler(this.frmManageUsersOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersList)).EndInit();
            this.cmsManageProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrdersList;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip cmsManageProducts;
        private System.Windows.Forms.ToolStripMenuItem showOrderItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startShippingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setShippingAsDeliveredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelShippingToolStripMenuItem;
    }
}