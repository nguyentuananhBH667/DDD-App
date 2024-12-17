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
    public partial class AdminForm : Form
    {
        int employeeId;
        string authorityLevel;
        public AdminForm(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            authorityLevel = authorityLevel;
            employeeId = employeeId;
        }

        private void InitializeComponent()
        {
            gbAdminFeature = new GroupBox();
            btnManageEmployee = new Button();
            btnManageProduct = new Button();
            btnManageCategory = new Button();
            btnManageOrder = new Button();
            btnManageImport = new Button();
            btnViewStatistic = new Button();
            gbAdminFeature.SuspendLayout();
            SuspendLayout();
            // 
            // gbAdminFeature
            // 
            gbAdminFeature.Controls.Add(btnViewStatistic);
            gbAdminFeature.Controls.Add(btnManageImport);
            gbAdminFeature.Controls.Add(btnManageOrder);
            gbAdminFeature.Controls.Add(btnManageCategory);
            gbAdminFeature.Controls.Add(btnManageProduct);
            gbAdminFeature.Controls.Add(btnManageEmployee);
            gbAdminFeature.Location = new Point(7, 8);
            gbAdminFeature.Name = "gbAdminFeature";
            gbAdminFeature.Size = new Size(717, 366);
            gbAdminFeature.TabIndex = 0;
            gbAdminFeature.TabStop = false;
            gbAdminFeature.Text = "Admin feature";
            // 
            // btnManageEmployee
            // 
            btnManageEmployee.Location = new Point(53, 43);
            btnManageEmployee.Name = "btnManageEmployee";
            btnManageEmployee.Size = new Size(253, 70);
            btnManageEmployee.TabIndex = 0;
            btnManageEmployee.Text = "Manage Employee ";
            btnManageEmployee.UseVisualStyleBackColor = true;
            btnManageEmployee.Click += btnManageEmployee_Click;
            // 
            // btnManageProduct
            // 
            btnManageProduct.Location = new Point(422, 43);
            btnManageProduct.Name = "btnManageProduct";
            btnManageProduct.Size = new Size(242, 70);
            btnManageProduct.TabIndex = 1;
            btnManageProduct.Text = "Manage Product ";
            btnManageProduct.UseVisualStyleBackColor = true;
            btnManageProduct.Click += btnManageProduct_Click;
            // 
            // btnManageCategory
            // 
            btnManageCategory.Location = new Point(53, 129);
            btnManageCategory.Name = "btnManageCategory";
            btnManageCategory.Size = new Size(253, 65);
            btnManageCategory.TabIndex = 2;
            btnManageCategory.Text = "Manage Category ";
            btnManageCategory.UseVisualStyleBackColor = true;
            btnManageCategory.Click += btnManageCategory_Click;
            // 
            // btnManageOrder
            // 
            btnManageOrder.Location = new Point(422, 129);
            btnManageOrder.Name = "btnManageOrder";
            btnManageOrder.Size = new Size(242, 65);
            btnManageOrder.TabIndex = 3;
            btnManageOrder.Text = "Manage Order ";
            btnManageOrder.UseVisualStyleBackColor = true;
            btnManageOrder.Click += btnManageOrder_Click;
            // 
            // btnManageImport
            // 
            btnManageImport.Location = new Point(53, 209);
            btnManageImport.Name = "btnManageImport";
            btnManageImport.Size = new Size(253, 65);
            btnManageImport.TabIndex = 4;
            btnManageImport.Text = "Manage Import ";
            btnManageImport.UseVisualStyleBackColor = true;
            btnManageImport.Click += btnManageImport_Click;
            // 
            // btnViewStatistic
            // 
            btnViewStatistic.Location = new Point(53, 290);
            btnViewStatistic.Name = "btnViewStatistic";
            btnViewStatistic.Size = new Size(611, 57);
            btnViewStatistic.TabIndex = 5;
            btnViewStatistic.Text = "View Statistic ";
            btnViewStatistic.UseVisualStyleBackColor = true;
            btnViewStatistic.Click += btnViewStatistic_Click;
            // 
            // AdminForm
            // 
            ClientSize = new Size(736, 386);
            Controls.Add(gbAdminFeature);
            Name = "AdminForm";
            gbAdminFeature.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            ManageEmployee manageEmployee = new ManageEmployee(authorityLevel);
            this.Hide();
            manageEmployee.Show();
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            ManageProduct manageProduct = new ManageProduct(this.authorityLevel, this.employeeId);
            this.Hide();
            manageProduct.Show();
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnManageImport_Click(object sender, EventArgs e)
        {

        }

        private void btnManageCategory_Click(object sender, EventArgs e)
        {

        }

        private void btnViewStatistic_Click(object sender, EventArgs e)
        {

        }
    }
}
