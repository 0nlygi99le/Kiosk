namespace KioskByGT.Forms
{
    partial class ReceiptForm
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
            lblStoreName = new Label();
            lblDescription = new Label();
            lblOrderNumber = new Label();
            lblOrderTime = new Label();
            flpnlItems = new KioskByGT.Components.RoundedPanel();
            lblTotalCount = new Label();
            lblTotalPrice = new Label();
            SuspendLayout();
            // 
            // lblStoreName
            // 
            lblStoreName.AutoSize = true;
            lblStoreName.FlatStyle = FlatStyle.Popup;
            lblStoreName.Location = new Point(12, 9);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(123, 25);
            lblStoreName.TabIndex = 0;
            lblStoreName.Text = "lblStoreName";
            lblStoreName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 45);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(123, 25);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "lblDescription";
            // 
            // lblOrderNumber
            // 
            lblOrderNumber.AutoSize = true;
            lblOrderNumber.Location = new Point(12, 80);
            lblOrderNumber.Name = "lblOrderNumber";
            lblOrderNumber.Size = new Size(145, 25);
            lblOrderNumber.TabIndex = 2;
            lblOrderNumber.Text = "lblOrderNumber";
            // 
            // lblOrderTime
            // 
            lblOrderTime.AutoSize = true;
            lblOrderTime.Location = new Point(12, 117);
            lblOrderTime.Name = "lblOrderTime";
            lblOrderTime.Size = new Size(118, 25);
            lblOrderTime.TabIndex = 3;
            lblOrderTime.Text = "lblOrderTime";
            // 
            // flpnlItems
            // 
            flpnlItems.Location = new Point(8, 157);
            flpnlItems.Name = "flpnlItems";
            flpnlItems.Size = new Size(523, 441);
            flpnlItems.TabIndex = 4;
            // 
            // lblTotalCount
            // 
            lblTotalCount.AutoSize = true;
            lblTotalCount.Location = new Point(12, 613);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(119, 25);
            lblTotalCount.TabIndex = 5;
            lblTotalCount.Text = "lblTotalCount";
            lblTotalCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(12, 651);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(110, 25);
            lblTotalPrice.TabIndex = 6;
            lblTotalPrice.Text = "lblTotalPrice";
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 762);
            Controls.Add(lblTotalPrice);
            Controls.Add(lblTotalCount);
            Controls.Add(flpnlItems);
            Controls.Add(lblOrderTime);
            Controls.Add(lblOrderNumber);
            Controls.Add(lblDescription);
            Controls.Add(lblStoreName);
            Name = "ReceiptForm";
            Text = "ReceiptForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStoreName;
        private Label lblDescription;
        private Label lblOrderNumber;
        private Label lblOrderTime;
        private Components.RoundedPanel flpnlItems;
        private Label lblTotalCount;
        private Label lblTotalPrice;
    }
}