namespace KioskByGT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Models.Product product1 = new Models.Product();
            Models.Product product2 = new Models.Product();
            headerControl1 = new KioskByGT.Components.HeaderControl();
            produstList1 = new KioskByGT.Components.Products.ProductList();
            pickList = new KioskByGT.Components.Picks.PickList();
            orderSummaryControl1 = new KioskByGT.Components.OrderSummaryControl();
            roundedButtonCancel = new KioskByGT.Components.RoundedButton();
            roundedButtonPay = new KioskByGT.Components.RoundedButton();
            SuspendLayout();
            // 
            // headerControl1
            // 
            headerControl1.Description = "\r\n주문하는 곳.\r\n다 맛있습니다.";
            headerControl1.Dock = DockStyle.Top;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1329, 175);
            headerControl1.TabIndex = 0;
            headerControl1.Title = "경자카야";
            // 
            // produstList1
            // 
            produstList1.BackColor = Color.Transparent;
            produstList1.BorderColor = Color.Silver;
            produstList1.BorderWidth = 1;
            product1.ID = 6;
            product1.Image = Properties.Resources.jjajang;
            product1.Price = new decimal(new int[] { 7000, 0, 0, 0 });
            product1.Title = "짜장면";
            product2.ID = 9;
            product2.Image = Properties.Resources.tangsu;
            product2.Price = new decimal(new int[] { 8000, 0, 0, 0 });
            product2.Title = "탕수육";
            produstList1.Items.Add(product1);
            produstList1.Items.Add(product2);
            produstList1.Location = new Point(12, 181);
            produstList1.Name = "produstList1";
            produstList1.Size = new Size(1305, 492);
            produstList1.TabIndex = 1;
            produstList1.ItemClicked += produstList1_ItemClicked;
            // 
            // pickList
            // 
            pickList.BackColor = Color.Transparent;
            pickList.BorderColor = Color.Silver;
            pickList.BorderWidth = 1;
            pickList.Location = new Point(12, 692);
            pickList.Name = "pickList";
            pickList.Size = new Size(832, 296);
            pickList.TabIndex = 2;
            pickList.ItemValueChanged += pickList_ItemValueChanged;
            // 
            // orderSummaryControl1
            // 
            orderSummaryControl1.BorderColor = Color.Silver;
            orderSummaryControl1.BorderWidth = 1;
            orderSummaryControl1.Count = 0;
            orderSummaryControl1.Location = new Point(850, 692);
            orderSummaryControl1.Name = "orderSummaryControl1";
            orderSummaryControl1.Size = new Size(467, 151);
            orderSummaryControl1.TabIndex = 3;
            orderSummaryControl1.TotalPrice = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // roundedButtonCancel
            // 
            roundedButtonCancel.BorderColor = Color.FromArgb(255, 192, 255);
            roundedButtonCancel.BorderWidth = 2;
            roundedButtonCancel.Location = new Point(850, 849);
            roundedButtonCancel.Name = "roundedButtonCancel";
            roundedButtonCancel.Size = new Size(229, 135);
            roundedButtonCancel.TabIndex = 4;
            roundedButtonCancel.Text = "취소하기";
            roundedButtonCancel.ButtonClick += roundedButtonCancel_ButtonClick;
            // 
            // roundedButtonPay
            // 
            roundedButtonPay.BorderColor = Color.SkyBlue;
            roundedButtonPay.BorderWidth = 2;
            roundedButtonPay.Location = new Point(1088, 849);
            roundedButtonPay.Name = "roundedButtonPay";
            roundedButtonPay.Size = new Size(229, 134);
            roundedButtonPay.TabIndex = 5;
            roundedButtonPay.Text = "결제하기";
            roundedButtonPay.ButtonClick += roundedButtonPay_ButtonClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1329, 1000);
            Controls.Add(roundedButtonPay);
            Controls.Add(roundedButtonCancel);
            Controls.Add(orderSummaryControl1);
            Controls.Add(pickList);
            Controls.Add(produstList1);
            Controls.Add(headerControl1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Components.HeaderControl headerControl1;
        private Components.Products.ProductList produstList1;
        private Components.Picks.PickList pickList;
        private Components.OrderSummaryControl orderSummaryControl1;
        private Components.RoundedButton roundedButtonCancel;
        private Components.RoundedButton roundedButtonPay;
    }
}
