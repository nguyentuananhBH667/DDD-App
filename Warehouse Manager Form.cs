using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Warehouse_Manager_Form : Form
    {
        int employeeId;
        string authorityLevel;
        public Warehouse_Manager_Form(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            authorityLevel = authorityLevel;
            employeeId = employeeId;
        }

        private void InitializeComponent()
        {
            this.gbWarehouseManagerFeature = new GroupBox();
            this.btnManageProduct = new Button();
            this.gbWarehouseManagerFeature.SuspendLayout();
            SuspendLayout();
            // 
            // gbWarehouseManagerFeature
            // 
            this.gbWarehouseManagerFeature.Controls.Add(this.btnManageProduct);
            this.gbWarehouseManagerFeature.Location = new Point(14, 15);
            this.gbWarehouseManagerFeature.Name = "gbWarehouseManagerFeature";
            this.gbWarehouseManagerFeature.Size = new Size(710, 344);
            this.gbWarehouseManagerFeature.TabIndex = 0;
            this.gbWarehouseManagerFeature.TabStop = false;
            this.gbWarehouseManagerFeature.Text = "Warehouse Manager Feature";
            // 
            // btnManageProduct
            // 
            this.btnManageProduct.Location = new Point(19, 29);
            this.btnManageProduct.Name = "btnManageProduct";
            this.btnManageProduct.Size = new Size(161, 66);
            this.btnManageProduct.TabIndex = 0;
            this.btnManageProduct.Text = "Manage Product";
            this.btnManageProduct.UseVisualStyleBackColor = true;
            this.btnManageProduct.Click += this.btnManageProduct_Click;
            // 
            // Warehouse_Manager_Form
            // 
            ClientSize = new Size(736, 371);
            Controls.Add(this.gbWarehouseManagerFeature);
            Name = "Warehouse_Manager_Form";
            this.gbWarehouseManagerFeature.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            ManageProduct manageProduct = new ManageProduct(authorityLevel, employeeId);
            this.Hide();
            manageProduct.Show();
        }
    }

}
