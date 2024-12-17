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
    public partial class ManageCustomer : Form
    {
        private int customerId;
        private int employeeId;
        private string authorityLevel;
        public ManageCustomer(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.authorityLevel = authorityLevel;
        }

        private void ChangeButtonStatus(bool buttonStatus)
        {
            btnUpdate.Enabled = buttonStatus;
            btnDelete.Enabled = buttonStatus;
            btnClear.Enabled = buttonStatus;
            btnAdd.Enabled = !buttonStatus;
        }

        private bool ValidateData(string customerCode, string customerName, string customerAddress, string phonenumber)
        {
            // Validate user input data
            // Declare isValid variable to check. First we assume all data is valid and check each of it
            bool isValid = true;

            if (customerCode == null || customerCode == string.Empty)
            {
                MessageBox.Show(
                    "Customer Code cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtCustomerCode.Focus();
            }
            else if (customerName == null || customerName == string.Empty)
            {
                MessageBox.Show(
                    "Customer Name cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtCustomerName.Focus();
            }
            else if (customerAddress == null || customerAddress == string.Empty)
            {
                MessageBox.Show(
                    "Customer Address cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtCustomerAddress.Focus();
            }
            else if (phonenumber == null || phonenumber == string.Empty)
            {
                MessageBox.Show(
                    "Phonenumber cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtPhonenumber.Focus();
            }

            return isValid;
        }

        private void FlushCustomerId()
        {
            this.customerId = 0;
            ChangeButtonStatus(false);
        }

        private void LoadCustomerData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "SELECT * FROM Customer";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dtgCustomer.DataSource = table;
                connection.Close();
            }
        }

        private bool CheckUserExistence(int customerId)
        {
            bool isExist = false;
            SqlConnection connection = DatabaseConnection.GetConnection();

            if (connection != null)
            {
                connection.Open();
                string checkCustomerQuery = "SELECT * FROM Customer WHERE CustomerID = @customerId";
                // Declare SqlCommand variable to add parameters to query and execute it
                SqlCommand command = new SqlCommand(checkCustomerQuery, connection);

                // Add parameters
                command.Parameters.AddWithValue("customerId", customerId);

                // Declare SqlDataReader variable to read retrieved data
                SqlDataReader reader = command.ExecuteReader();

                // Check if reader has row (query success and return one row show user information)
                isExist = reader.HasRows;

                // close the connection
                connection.Close();
            }
            return isExist;
        }

        private void AddCustomer(string customerCode, string customerName, string customerAddress, string phoneNumber)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();

            if (connection != null)
            {
                connection.Open();

                // Declare query to insert customer:
                string query = "INSERT INTO Customer (CustomerCode, CustomerName, PhoneNumber, Address) " +
                               "VALUES (@customerCode, @customerName, @phoneNumber, @customerAddress)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("customerCode", customerCode);
                command.Parameters.AddWithValue("customerName", customerName);
                command.Parameters.AddWithValue("phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("customerAddress", customerAddress);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    // Success message
                    MessageBox.Show("Successfully add new customer", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Error message
                    MessageBox.Show("An error occur while adding customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();

                // Clear all user input data and flush customerID
                ClearData();
                LoadCustomerData();
            }
        }

        private void updateCustomer(int customerId, string customerCode, string customerName, string customerAddress, string phoneNumber)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();

            if (connection != null)
            {
                connection.Open();

                string query = "UPDATE Customer SET " +
                               "CustomerCode = @customerCode, " +
                               "CustomerName = @customerName, " +
                               "Address = @customerAddress, " +
                               "PhoneNumber = @phoneNumber " +
                               "WHERE CustomerID = @customerId";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("customerCode", customerCode);
                command.Parameters.AddWithValue("customerName", customerName);
                command.Parameters.AddWithValue("customerAddress", customerAddress);
                command.Parameters.AddWithValue("phoneNumber", phoneNumber);
                command.Parameters.AddWithValue("customerId", customerId);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Successfully update customer", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An error occur while updating customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();

                // Clear all user input data and flush customerID
                ClearData();
                LoadCustomerData();
            }
        }

        private void DeleteCustomer(int customerId)
        {

            SqlConnection connection = DatabaseConnection.GetConnection();

            if (connection != null)
            {
                connection.Open();

                string deleteOrderDetailQuery = "DELETE FROM OrderDetail WHERE OrderID IN " +
                                                "(SELECT OrderID FROM Orders WHERE CustomerID = @customerId)";
                SqlCommand command = new SqlCommand(deleteOrderDetailQuery, connection);

                command.Parameters.AddWithValue("customerId", customerId);

                command.ExecuteNonQuery();

                string deleteOrderQuery = "DELETE FROM Orders WHERE CustomerID = @customerId";

                command = new SqlCommand(deleteOrderQuery, connection);

                command.Parameters.AddWithValue("customerId", customerId);

                command.ExecuteNonQuery();

                string deleteCustomerQuery = "DELETE FROM Customer WHERE CustomerID = @customerId";

                command = new SqlCommand(deleteCustomerQuery, connection);

                command.Parameters.AddWithValue("customerId", customerId);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Successfully delete customer", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An error occur while deleting customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();

                ClearData();
                LoadCustomerData();
            }
        }

        private void SearchCustomer(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadCustomerData();
            }
            else
            {
                // Open connection by call the GetConnection function in DatabaseConnection class
                SqlConnection connection = DatabaseConnection.GetConnection();

                if (connection != null)
                {
                    connection.Open();

                    // Declare query to the database
                    string query = "SELECT * FROM Customer WHERE CustomerCode LIKE @search OR CustomerName LIKE @search OR PhoneNumber LIKE @search OR Address LIKE @search";

                    // Initialize SqlDataAdapter to translate query result to a data table
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("search", "%" + search + "%");

                    // Initialize data table
                    DataTable table = new DataTable();

                    // Fill the data set by data queried from the database
                    adapter.Fill(table);

                    // Set the datasource of data gridview by the dataset
                    dtgCustomer.DataSource = table;

                    // close the connection
                    connection.Close();
                }
            }
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ManageCustomer_Load(object sender, EventArgs e)
        {
            // Load data from database to the data gridview
            LoadCustomerData();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get data from user input
            string customerCode = txtCustomerCode.Text;
            string customerName = txtCustomerName.Text;
            string customerAddress = txtCustomerAddress.Text;
            string phoneNumber = txtPhonenumber.Text;

            // Validate data
            bool isValid = ValidateData(customerCode, customerName, customerAddress, phoneNumber);

            if (isValid)
            {
                AddCustomer(customerCode, customerName, customerAddress, phoneNumber);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (customerId > 0)
            {
                bool isUserExist = CheckUserExistence(customerId);
                if (isUserExist)
                {
                    string customerCode = txtCustomerCode.Text;
                    string customerName = txtCustomerName.Text;
                    string customerAddress = txtCustomerAddress.Text;
                    string phoneNumber = txtPhonenumber.Text;

                    bool isValid = ValidateData(customerCode, customerName, customerAddress, phoneNumber);
                    if (isValid)
                    {
                        updateCustomer(customerId, customerCode, customerName, customerAddress, phoneNumber);
                    }
                }
                else
                {
                    MessageBox.Show("No customer found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (customerId > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Do you want to delete this customer with all related data?",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    bool isUserExist = CheckUserExistence(customerId);
                    if (isUserExist)
                    {
                        DeleteCustomer(customerId);
                    }
                    else
                    {
                        MessageBox.Show(
                            "No customer found",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            FlushCustomerId();
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtPhonenumber.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (authorityLevel)
            {
                case "Admin":
                    AdminForm adminForm = new AdminForm(this.authorityLevel, this.employeeId);
                    this.Hide();
                    adminForm.Show();
                    break;
                case "Warehouse Manager":
                    Warehouse_Manager_Form warehouseManagerForm = new Warehouse_Manager_Form(this.authorityLevel, this.employeeId);
                    this.Hide();
                    warehouseManagerForm.Show();
                    break;
                case "Sale":
                    Sale_Form saleForm = new Sale_Form(this.authorityLevel, this.employeeId);
                    this.Hide();
                    saleForm.Show();
                    break;
                default:
                    break;
            }
        }

        private void dtgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void dtgCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgCustomer.CurrentCell.RowIndex;
            if (index > -1)
            {
                customerId = (int)dtgCustomer.Rows[index].Cells[0].Value;
                string customerName = dtgCustomer.Rows[index].Cells[2].Value.ToString();
                Order order = new Order(customerId, employeeId, customerName);
                order.ShowDialog();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text;
            SearchCustomer(search);
        }

        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            ManageCustomer manageCustomer = new ManageCustomer(authorityLevel, employeeId);
            this.Hide();
            manageCustomer.Show();
        }
    }
}
