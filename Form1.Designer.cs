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
            SuspendLayout();
            // 
            // headerControl1
            // 
            headerControl1.Description = "\r\n주문은 여기서!\r\n경태의 매점에 온 걸 환영해용";
            headerControl1.Dock = DockStyle.Top;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(1279, 175);
            headerControl1.TabIndex = 0;
            headerControl1.Title = "매점 전용 키오스크";
            // 
            // produstList1
            // 
            produstList1.BackColor = Color.Transparent;
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
            produstList1.Size = new Size(683, 775);
            produstList1.TabIndex = 1;
            produstList1.ItemClicked += produstList1_ItemClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 968);
            Controls.Add(produstList1);
            Controls.Add(headerControl1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Components.HeaderControl headerControl1;
        private Components.Products.ProductList produstList1;
    }
}
