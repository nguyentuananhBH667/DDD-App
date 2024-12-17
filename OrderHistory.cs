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
    public partial class OrderHistory : Form
    {
        private int employeeId;
        private string authorityLevel;

        public OrderHistory()
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.authorityLevel = authorityLevel;
        }

        public OrderHistory(string authorityLevel, int employeeId)
        {
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
        }

        private void LoadOrderHistory()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "SELECT o.OrderDate, " +
                    "e.employeeName, " +
                    "c.CustomerName " +
                    "FROM Orders o INNER JOIN employee e ON o.employeeID = e.employeeID" +
                    "INNER JOIN Customer c ON o.CustomerID = c.CustomerID " +
                    "WHERE o.employeeID = @employeeId " +
                    "GROUP BY o.OrderDate, e.employeeName, e.employeeCode";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("employeeId", employeeId);
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            RedirectPage();
        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void CustomerHistory_Load(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            OrderHistory orderHistory = new OrderHistory(this.authorityLevel, this.employeeId);
            this.Hide();
            orderHistory.Show();
        }
    }
}
