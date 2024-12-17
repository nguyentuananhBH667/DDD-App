namespace LoginApp
{
    partial class ManageCustomer
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
            gbCustomerManager = new GroupBox();
            dtgCustomer = new DataGridView();
            txtSearch = new TextBox();
            lblSearch = new Label();
            gbCustomerInformation = new GroupBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtCustomerAddress = new TextBox();
            txtPhonenumber = new TextBox();
            txtCustomerName = new TextBox();
            txtCustomerCode = new TextBox();
            lblCustomerAddress = new Label();
            lblPhonenumber = new Label();
            lblCustomerName = new Label();
            lblCustomerCode = new Label();
            lblCustomerList = new Label();
            btnBack = new Button();
            gbCustomerManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgCustomer).BeginInit();
            gbCustomerInformation.SuspendLayout();
            SuspendLayout();
            // 
            // gbCustomerManager
            // 
            gbCustomerManager.Controls.Add(dtgCustomer);
            gbCustomerManager.Controls.Add(txtSearch);
            gbCustomerManager.Controls.Add(lblSearch);
            gbCustomerManager.Controls.Add(gbCustomerInformation);
            gbCustomerManager.Controls.Add(lblCustomerList);
            gbCustomerManager.Location = new Point(10, -3);
            gbCustomerManager.Name = "gbCustomerManager";
            gbCustomerManager.Size = new Size(732, 416);
            gbCustomerManager.TabIndex = 0;
            gbCustomerManager.TabStop = false;
            gbCustomerManager.Text = "Customer Manager";
            gbCustomerManager.Enter += groupBox1_Enter;
            // 
            // dtgCustomer
            // 
            dtgCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgCustomer.Location = new Point(399, 49);
            dtgCustomer.Name = "dtgCustomer";
            dtgCustomer.RowTemplate.Height = 25;
            dtgCustomer.Size = new Size(327, 315);
            dtgCustomer.TabIndex = 9;
            dtgCustomer.CellClick += dtgProduct_CellClick;
            dtgCustomer.CellDoubleClick += dtgCustomer_CellDoubleClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(595, 19);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(131, 23);
            txtSearch.TabIndex = 8;
            txtSearch.KeyUp += txtSearch_KeyUp;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(532, 22);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(42, 15);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Search";
            // 
            // gbCustomerInformation
            // 
            gbCustomerInformation.Controls.Add(btnClear);
            gbCustomerInformation.Controls.Add(btnDelete);
            gbCustomerInformation.Controls.Add(btnUpdate);
            gbCustomerInformation.Controls.Add(btnAdd);
            gbCustomerInformation.Controls.Add(txtCustomerAddress);
            gbCustomerInformation.Controls.Add(txtPhonenumber);
            gbCustomerInformation.Controls.Add(txtCustomerName);
            gbCustomerInformation.Controls.Add(txtCustomerCode);
            gbCustomerInformation.Controls.Add(lblCustomerAddress);
            gbCustomerInformation.Controls.Add(lblPhonenumber);
            gbCustomerInformation.Controls.Add(lblCustomerName);
            gbCustomerInformation.Controls.Add(lblCustomerCode);
            gbCustomerInformation.Location = new Point(8, 22);
            gbCustomerInformation.Name = "gbCustomerInformation";
            gbCustomerInformation.Size = new Size(385, 342);
            gbCustomerInformation.TabIndex = 0;
            gbCustomerInformation.TabStop = false;
            gbCustomerInformation.Text = "Customer information";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(301, 280);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(78, 34);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(208, 280);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(78, 34);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(107, 280);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(78, 34);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(8, 280);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(78, 34);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtCustomerAddress
            // 
            txtCustomerAddress.Location = new Point(131, 134);
            txtCustomerAddress.Multiline = true;
            txtCustomerAddress.Name = "txtCustomerAddress";
            txtCustomerAddress.Size = new Size(248, 112);
            txtCustomerAddress.TabIndex = 7;
            // 
            // txtPhonenumber
            // 
            txtPhonenumber.Location = new Point(131, 100);
            txtPhonenumber.Name = "txtPhonenumber";
            txtPhonenumber.Size = new Size(248, 23);
            txtPhonenumber.TabIndex = 6;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(131, 63);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(248, 23);
            txtCustomerName.TabIndex = 5;
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Location = new Point(131, 33);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.Size = new Size(248, 23);
            txtCustomerCode.TabIndex = 4;
            // 
            // lblCustomerAddress
            // 
            lblCustomerAddress.AutoSize = true;
            lblCustomerAddress.Location = new Point(18, 142);
            lblCustomerAddress.Name = "lblCustomerAddress";
            lblCustomerAddress.Size = new Size(49, 15);
            lblCustomerAddress.TabIndex = 3;
            lblCustomerAddress.Text = "Address";
            // 
            // lblPhonenumber
            // 
            lblPhonenumber.AutoSize = true;
            lblPhonenumber.Location = new Point(18, 103);
            lblPhonenumber.Name = "lblPhonenumber";
            lblPhonenumber.Size = new Size(88, 15);
            lblPhonenumber.TabIndex = 2;
            lblPhonenumber.Text = "Phone Number";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(18, 66);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(94, 15);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Customer Name";
            // 
            // lblCustomerCode
            // 
            lblCustomerCode.AutoSize = true;
            lblCustomerCode.Location = new Point(18, 33);
            lblCustomerCode.Name = "lblCustomerCode";
            lblCustomerCode.Size = new Size(90, 15);
            lblCustomerCode.TabIndex = 0;
            lblCustomerCode.Text = "Customer Code";
            // 
            // lblCustomerList
            // 
            lblCustomerList.AutoSize = true;
            lblCustomerList.Location = new Point(399, 22);
            lblCustomerList.Name = "lblCustomerList";
            lblCustomerList.Size = new Size(75, 15);
            lblCustomerList.TabIndex = 4;
            lblCustomerList.Text = "customer list";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(10, 379);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(78, 34);
            btnBack.TabIndex = 12;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ManageCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 422);
            Controls.Add(btnBack);
            Controls.Add(gbCustomerManager);
            Name = "ManageCustomer";
            Text = "ManageCustomer";
            Load += ManageCustomer_Load;
            gbCustomerManager.ResumeLayout(false);
            gbCustomerManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgCustomer).EndInit();
            gbCustomerInformation.ResumeLayout(false);
            gbCustomerInformation.PerformLayout();
            ResumeLayout(false);
        }

        private void dtgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgCustomer.CurrentCell.RowIndex;
            if (index > -1)
            {
                customerId = (int)dtgCustomer.Rows[index].Cells[0].Value;
                txtCustomerCode.Text = dtgCustomer.Rows[index].Cells[1].Value.ToString();
                txtCustomerName.Text = dtgCustomer.Rows[index].Cells[2].Value.ToString();
                txtPhonenumber.Text = dtgCustomer.Rows[index].Cells[3].Value.ToString();
                txtCustomerAddress.Text = dtgCustomer.Rows[index].Cells[4].Value.ToString();
                ChangeButtonStatus(true);
            }
        }

        #endregion

        private GroupBox gbCustomerManager;
        private GroupBox gbCustomerInformation;
        private Label lblCustomerCode;
        private Label lblSearch;
        private Label lblCustomerAddress;
        private Label lblPhonenumber;
        private Label lblCustomerName;
        private Label lblCustomerList;
        private TextBox txtSearch;
        private TextBox txtCustomerAddress;
        private TextBox txtPhonenumber;
        private TextBox txtCustomerName;
        private TextBox txtCustomerCode;
        private DataGridView dtgCustomer;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnBack;
    }
}