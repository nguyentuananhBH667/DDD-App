namespace LoginApp
{
    partial class ManageProduct
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
            lblProductCode = new Label();
            lblProductName = new Label();
            lblProductPrice = new Label();
            lblProductQuantity = new Label();
            lblProductImg = new Label();
            lblCategory = new Label();
            gbProductInformation = new GroupBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnUpload = new Button();
            cbCategory = new ComboBox();
            txtProductImg = new TextBox();
            txtProductQuantity = new TextBox();
            txtProductPrice = new TextBox();
            txtProductName = new TextBox();
            txtProductCode = new TextBox();
            gbProductData = new GroupBox();
            dtgProduct = new DataGridView();
            txtSearch = new TextBox();
            btnBack = new Button();
            gbProductInformation.SuspendLayout();
            gbProductData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProduct).BeginInit();
            SuspendLayout();
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Location = new Point(16, 34);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(80, 15);
            lblProductCode.TabIndex = 0;
            lblProductCode.Text = "Product Code";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(16, 70);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(84, 15);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            // 
            // lblProductPrice
            // 
            lblProductPrice.AutoSize = true;
            lblProductPrice.Location = new Point(16, 104);
            lblProductPrice.Name = "lblProductPrice";
            lblProductPrice.Size = new Size(78, 15);
            lblProductPrice.TabIndex = 2;
            lblProductPrice.Text = "Product Price";
            // 
            // lblProductQuantity
            // 
            lblProductQuantity.AutoSize = true;
            lblProductQuantity.Location = new Point(16, 136);
            lblProductQuantity.Name = "lblProductQuantity";
            lblProductQuantity.Size = new Size(98, 15);
            lblProductQuantity.TabIndex = 3;
            lblProductQuantity.Text = "Product Quantity";
            // 
            // lblProductImg
            // 
            lblProductImg.AutoSize = true;
            lblProductImg.Location = new Point(16, 170);
            lblProductImg.Name = "lblProductImg";
            lblProductImg.Size = new Size(85, 15);
            lblProductImg.TabIndex = 4;
            lblProductImg.Text = "Product Image";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(16, 201);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Category";
            // 
            // gbProductInformation
            // 
            gbProductInformation.Controls.Add(btnClear);
            gbProductInformation.Controls.Add(btnDelete);
            gbProductInformation.Controls.Add(btnUpdate);
            gbProductInformation.Controls.Add(btnAdd);
            gbProductInformation.Controls.Add(btnUpload);
            gbProductInformation.Controls.Add(cbCategory);
            gbProductInformation.Controls.Add(txtProductImg);
            gbProductInformation.Controls.Add(txtProductQuantity);
            gbProductInformation.Controls.Add(txtProductPrice);
            gbProductInformation.Controls.Add(txtProductName);
            gbProductInformation.Controls.Add(txtProductCode);
            gbProductInformation.Controls.Add(lblProductCode);
            gbProductInformation.Controls.Add(lblCategory);
            gbProductInformation.Controls.Add(lblProductPrice);
            gbProductInformation.Controls.Add(lblProductImg);
            gbProductInformation.Controls.Add(lblProductName);
            gbProductInformation.Controls.Add(lblProductQuantity);
            gbProductInformation.Location = new Point(23, 4);
            gbProductInformation.Name = "gbProductInformation";
            gbProductInformation.Size = new Size(366, 403);
            gbProductInformation.TabIndex = 6;
            gbProductInformation.TabStop = false;
            gbProductInformation.Text = "Product Information";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(229, 296);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(89, 35);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(25, 296);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(89, 35);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(229, 241);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(89, 35);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(25, 241);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(89, 35);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(302, 169);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(49, 23);
            btnUpload.TabIndex = 12;
            btnUpload.Text = "....";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(133, 203);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(227, 23);
            cbCategory.TabIndex = 11;
            // 
            // txtProductImg
            // 
            txtProductImg.Enabled = false;
            txtProductImg.Location = new Point(131, 167);
            txtProductImg.Name = "txtProductImg";
            txtProductImg.ReadOnly = true;
            txtProductImg.Size = new Size(159, 23);
            txtProductImg.TabIndex = 10;
            // 
            // txtProductQuantity
            // 
            txtProductQuantity.Location = new Point(131, 133);
            txtProductQuantity.Name = "txtProductQuantity";
            txtProductQuantity.Size = new Size(229, 23);
            txtProductQuantity.TabIndex = 9;
            // 
            // txtProductPrice
            // 
            txtProductPrice.Location = new Point(131, 101);
            txtProductPrice.Name = "txtProductPrice";
            txtProductPrice.Size = new Size(229, 23);
            txtProductPrice.TabIndex = 8;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(131, 70);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(229, 23);
            txtProductName.TabIndex = 7;
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(131, 34);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(229, 23);
            txtProductCode.TabIndex = 6;
            // 
            // gbProductData
            // 
            gbProductData.Controls.Add(dtgProduct);
            gbProductData.Controls.Add(txtSearch);
            gbProductData.Location = new Point(395, 4);
            gbProductData.Name = "gbProductData";
            gbProductData.Size = new Size(359, 403);
            gbProductData.TabIndex = 7;
            gbProductData.TabStop = false;
            gbProductData.Text = "Product Data";
            // 
            // dtgProduct
            // 
            dtgProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProduct.Location = new Point(12, 74);
            dtgProduct.Name = "dtgProduct";
            dtgProduct.RowTemplate.Height = 25;
            dtgProduct.Size = new Size(344, 274);
            dtgProduct.TabIndex = 1;
            dtgProduct.CellClick += dtgProduct_CellClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(94, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(259, 23);
            txtSearch.TabIndex = 0;
            txtSearch.KeyUp += txtSearch_KeyUp;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(28, 364);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(89, 35);
            btnBack.TabIndex = 17;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ManageProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 419);
            Controls.Add(btnBack);
            Controls.Add(gbProductData);
            Controls.Add(gbProductInformation);
            Name = "ManageProduct";
            Text = "ManageProduct";
            Load += ManageProduct_Load;
            Click += btnManageProduct_Click;
            gbProductInformation.ResumeLayout(false);
            gbProductInformation.PerformLayout();
            gbProductData.ResumeLayout(false);
            gbProductData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblProductCode;
        private Label lblProductName;
        private Label lblProductPrice;
        private Label lblProductQuantity;
        private Label lblProductImg;
        private Label lblCategory;
        private GroupBox gbProductInformation;
        private GroupBox gbProductData;
        private ComboBox cbCategory;
        private TextBox txtProductImg;
        private TextBox txtProductQuantity;
        private TextBox txtProductPrice;
        private TextBox txtProductName;
        private TextBox txtProductCode;
        private Button button1;
        private Button btnUpload;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnBack;
        private DataGridView dtgProduct;
        private TextBox txtSearch;
    }
}