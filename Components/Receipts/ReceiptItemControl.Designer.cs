namespace KioskByGT.Components.Receipts
{
    partial class ReceiptItemControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCount = new Label();
            lblSumPrice = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(19, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(65, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "lblTitle";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(206, 19);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(79, 25);
            lblCount.TabIndex = 1;
            lblCount.Text = "lblCount";
            // 
            // lblSumPrice
            // 
            lblSumPrice.AutoSize = true;
            lblSumPrice.Location = new Point(350, 19);
            lblSumPrice.Name = "lblSumPrice";
            lblSumPrice.Size = new Size(106, 25);
            lblSumPrice.TabIndex = 2;
            lblSumPrice.Text = "lblSumPrice";
            // 
            // ReceiptItemControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSumPrice);
            Controls.Add(lblCount);
            Controls.Add(lblTitle);
            Name = "ReceiptItemControl";
            Size = new Size(481, 63);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCount;
        private Label lblSumPrice;
    }
}
