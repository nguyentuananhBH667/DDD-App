using GLOCERY;
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
    public partial class ManageOrder : Form
    {
        private int employeeId;
        private string authorityLevel;
        public ManageOrder(string authorityLevel)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.authorityLevel = authorityLevel;
        }

        public ManageOrder(string authorityLevel, int employeeId) : this(authorityLevel)
        {
        }

        private void LoadOrderHistory()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();

            if (connection != null)
            {
                connection.Open();
                string query = @"SELECT o.SaleDate, e.employeeName, c.CustomerName AS CustomerName FROM Sale o
                                 INNER JOIN employee e ON o.employeeID = e.employeeID
                                 INNER JOIN Customer c ON o.CustomerID = c.CustomerID
                                 WHERE o.employeeID = @employeeID
                                 GROUP BY o.SaleDate, e.employeeName, e.employeeCode, c.CustomerName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dtgOrderHistory.DataSource = dataTable;
            }
        }

        private void RedirectPage()
        {
            switch (this.authorityLevel)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(authorityLevel, employeeId);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }

                case "Warehouse Manager":
                    {
                        Warehouse_Manager_Form warehouseManagerForm = new Warehouse_Manager_Form(authorityLevel, employeeId);
                        this.Hide();
                        warehouseManagerForm.Show();
                        break;
                    }

                case "Sale":
                    {
                        ManageCustomer saleForm = new ManageCustomer(authorityLevel, employeeId);
                        this.Hide();
                        saleForm.Show();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private void CustomerHistory_Load(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RedirectPage();
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            ManageOrder ManageOrder = new ManageOrder(this.authorityLevel, this.employeeId);
            this.Hide();
            ManageOrder.Show();
        }

        private void ManageOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
