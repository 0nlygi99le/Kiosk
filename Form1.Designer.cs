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
            Models.Product product3 = new Models.Product();
            Models.Product product4 = new Models.Product();
            Models.Product product5 = new Models.Product();
            Models.Product product6 = new Models.Product();
            Models.Product product7 = new Models.Product();
            Models.Product product8 = new Models.Product();
            Models.Product product9 = new Models.Product();
            headerControl1 = new KioskByGT.Components.HeaderControl();
            produstList1 = new KioskByGT.Components.Products.ProductList();
            pickList = new KioskByGT.Components.Picks.PickList();
            orderSummaryControl1 = new KioskByGT.Components.OrderSummaryControl();
            roundedButton1 = new KioskByGT.Components.RoundedButton();
            roundedButton2 = new KioskByGT.Components.RoundedButton();
            SuspendLayout();
            // 
            // headerControl1
            // 
            headerControl1.Description = "\r\n주문은 여기서!\r\n경태의 매점에 온 걸 환영해용";
            headerControl1.Dock = DockStyle.Top;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1329, 175);
            headerControl1.TabIndex = 0;
            headerControl1.Title = "매점 전용 키오스크";
            // 
            // produstList1
            // 
            produstList1.BackColor = Color.Transparent;
            produstList1.BorderColor = Color.Silver;
            produstList1.BorderWidth = 1;
            product1.ID = 1;
            product1.Image = Properties.Resources.apple;
            product1.Price = new decimal(new int[] { 1800, 0, 0, 0 });
            product1.Title = "사과";
            product2.ID = 2;
            product2.Image = Properties.Resources.chicken;
            product2.Price = new decimal(new int[] { 20000, 0, 0, 0 });
            product2.Title = "치킨";
            product3.ID = 3;
            product3.Image = Properties.Resources.cookie;
            product3.Price = new decimal(new int[] { 1200, 0, 0, 0 });
            product3.Title = "쿠키";
            product4.ID = 4;
            product4.Image = Properties.Resources.hamburger;
            product4.Price = new decimal(new int[] { 5500, 0, 0, 0 });
            product4.Title = "햄버거";
            product5.ID = 5;
            product5.Image = Properties.Resources.icecream;
            product5.Price = new decimal(new int[] { 3500, 0, 0, 0 });
            product5.Title = "아이스크림";
            product6.ID = 6;
            product6.Image = Properties.Resources.jjajang;
            product6.Price = new decimal(new int[] { 7000, 0, 0, 0 });
            product6.Title = "짜장면";
            product7.ID = 7;
            product7.Image = Properties.Resources.pizza;
            product7.Price = new decimal(new int[] { 18000, 0, 0, 0 });
            product7.Title = "피자";
            product8.ID = 8;
            product8.Image = Properties.Resources.salad;
            product8.Price = new decimal(new int[] { 5000, 0, 0, 0 });
            product8.Title = "샐러드";
            product9.ID = 9;
            product9.Image = Properties.Resources.tangsu;
            product9.Price = new decimal(new int[] { 8000, 0, 0, 0 });
            product9.Title = "탕수육";
            produstList1.Items.Add(product1);
            produstList1.Items.Add(product2);
            produstList1.Items.Add(product3);
            produstList1.Items.Add(product4);
            produstList1.Items.Add(product5);
            produstList1.Items.Add(product6);
            produstList1.Items.Add(product7);
            produstList1.Items.Add(product8);
            produstList1.Items.Add(product9);
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
            // roundedButton1
            // 
            roundedButton1.BorderColor = Color.FromArgb(255, 192, 255);
            roundedButton1.BorderWidth = 2;
            roundedButton1.Location = new Point(850, 849);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(229, 135);
            roundedButton1.TabIndex = 4;
            // 
            // roundedButton2
            // 
            roundedButton2.BorderColor = Color.SkyBlue;
            roundedButton2.BorderWidth = 2;
            roundedButton2.Location = new Point(1088, 849);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new Size(229, 135);
            roundedButton2.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1329, 1000);
            Controls.Add(roundedButton2);
            Controls.Add(roundedButton1);
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
        private Components.RoundedButton roundedButton1;
        private Components.RoundedButton roundedButton2;
    }
}
