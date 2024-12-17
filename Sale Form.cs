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
    public partial class Sale_Form : Form
    {
        private int employeeId;
        private string authorityLevel;
        public Sale_Form(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            employeeId = employeeId;
            authorityLevel = authorityLevel;
        }

        private void InitializeComponent()
        {
            backgroundWorker1 = new BackgroundWorker();
            gbSaleFeature = new GroupBox();
            btnManageCustomer = new Button();
            btnManageOrder = new Button();
            gbSaleFeature.SuspendLayout();
            SuspendLayout();
            // 
            // gbSaleFeature
            // 
            gbSaleFeature.Controls.Add(btnManageOrder);
            gbSaleFeature.Controls.Add(btnManageCustomer);
            gbSaleFeature.Location = new Point(12, 10);
            gbSaleFeature.Name = "gbSaleFeature";
            gbSaleFeature.Size = new Size(635, 276);
            gbSaleFeature.TabIndex = 0;
            gbSaleFeature.TabStop = false;
            gbSaleFeature.Text = "Sale Feature";
            // 
            // btnManageCustomer
            // 
            btnManageCustomer.Location = new Point(20, 33);
            btnManageCustomer.Name = "btnManageCustomer";
            btnManageCustomer.Size = new Size(208, 62);
            btnManageCustomer.TabIndex = 0;
            btnManageCustomer.Text = "Manage Customer";
            btnManageCustomer.UseVisualStyleBackColor = true;
            btnManageCustomer.Click += btnManageCustomer_Click;
            // 
            // btnManageOrder
            // 
            btnManageOrder.Location = new Point(397, 33);
            btnManageOrder.Name = "btnManageOrder";
            btnManageOrder.Size = new Size(208, 62);
            btnManageOrder.TabIndex = 1;
            btnManageOrder.Text = "Manage Order";
            btnManageOrder.UseVisualStyleBackColor = true;
            btnManageOrder.Click += btnManageOrder_Click;
            // 
            // Sale_Form
            // 
            ClientSize = new Size(659, 298);
            Controls.Add(gbSaleFeature);
            Name = "Sale_Form";
            gbSaleFeature.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            ManageCustomer manageCustomer = new ManageCustomer(authorityLevel, employeeId);
            this.Hide();
            manageCustomer.Show();
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            ManageOrder ManageOrder = new ManageOrder(this.authorityLevel, this.employeeId);
            this.Hide();
            ManageOrder.Show();
        }
    }
}
