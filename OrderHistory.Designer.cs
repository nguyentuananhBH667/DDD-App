namespace LoginApp
{
    partial class OrderHistory
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
            gbPurchaseHistory = new GroupBox();
            dtgOrderHistory = new DataGridView();
            btnBack = new Button();
            label1 = new Label();
            gbPurchaseHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgOrderHistory).BeginInit();
            SuspendLayout();
            // 
            // gbPurchaseHistory
            // 
            gbPurchaseHistory.Controls.Add(label1);
            gbPurchaseHistory.Controls.Add(dtgOrderHistory);
            gbPurchaseHistory.Location = new Point(13, 6);
            gbPurchaseHistory.Name = "gbPurchaseHistory";
            gbPurchaseHistory.Size = new Size(727, 365);
            gbPurchaseHistory.TabIndex = 0;
            gbPurchaseHistory.TabStop = false;
            gbPurchaseHistory.Text = "Purchase history";
            // 
            // dtgOrderHistory
            // 
            dtgOrderHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgOrderHistory.Location = new Point(7, 22);
            dtgOrderHistory.Name = "dtgOrderHistory";
            dtgOrderHistory.RowTemplate.Height = 25;
            dtgOrderHistory.Size = new Size(714, 327);
            dtgOrderHistory.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(625, 377);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(98, 49);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(239, 171);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // OrderHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 438);
            Controls.Add(btnBack);
            Controls.Add(gbPurchaseHistory);
            Name = "OrderHistory";
            Text = "OrderHistory";
            Load += OrderHistory_Load;
            gbPurchaseHistory.ResumeLayout(false);
            gbPurchaseHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgOrderHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbPurchaseHistory;
        private DataGridView dtgOrderHistory;
        private Button btnBack;
        private Label label1;
    }
}