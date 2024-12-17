namespace LoginApp
{
    partial class ManageOrder
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
            dtgOrderHistory = new DataGridView();
            btnBack = new Button();
            gbPurchaseHistory = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dtgOrderHistory).BeginInit();
            gbPurchaseHistory.SuspendLayout();
            SuspendLayout();
            // 
            // dtgOrderHistory
            // 
            dtgOrderHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgOrderHistory.Location = new Point(10, 22);
            dtgOrderHistory.Name = "dtgOrderHistory";
            dtgOrderHistory.RowTemplate.Height = 25;
            dtgOrderHistory.Size = new Size(696, 368);
            dtgOrderHistory.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(559, 405);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(113, 43);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // gbPurchaseHistory
            // 
            gbPurchaseHistory.Controls.Add(dtgOrderHistory);
            gbPurchaseHistory.Controls.Add(btnBack);
            gbPurchaseHistory.Location = new Point(2, 1);
            gbPurchaseHistory.Name = "gbPurchaseHistory";
            gbPurchaseHistory.Size = new Size(717, 458);
            gbPurchaseHistory.TabIndex = 2;
            gbPurchaseHistory.TabStop = false;
            gbPurchaseHistory.Text = "Purchase history";
            // 
            // ManageOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 462);
            Controls.Add(gbPurchaseHistory);
            Name = "ManageOrder";
            Text = "ManageOrder";
            Load += ManageOrder_Load;
            Click += btnManageOrder_Click;
            ((System.ComponentModel.ISupportInitialize)dtgOrderHistory).EndInit();
            gbPurchaseHistory.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtgOrderHistory;
        private Button btnBack;
        private GroupBox gbPurchaseHistory;
    }
}