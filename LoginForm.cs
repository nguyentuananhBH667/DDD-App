using GLOCERY;
using Microsoft.Data.SqlClient;

namespace LoginApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitializeCombobox();
        }
        public void InitializeCombobox()
        {
            // Setup for combobox
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Warehouse Manager");
            cbRole.Items.Add("Sale");
            // Set the selected index to the first item of the array (Admin)
            cbRole.SelectedIndex = 0;
        }

        private bool ValidateData(string username, string password, string? role)
        {
            bool isValid = true;
            if (username == null || username == string.Empty)
            {
                MessageBox.Show(
                    "Username cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtUsername.Focus();
            }
            else if (password == null || password == string.Empty)
            {
                MessageBox.Show(
                    "Password cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtPassword.Focus();
            }
            else if (role == null || role == string.Empty)
            {
                MessageBox.Show(
                    "No role selected",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                cbRole.Focus();
            }
            return isValid;
        }

        private void RedirectPage(string? selectedRole, int employeeId, bool isChangePassword)
        {
            // Check if isChangePassword = true (1 in database)
            // so that application does not need to redirect user to ChangePassword Form
            if (isChangePassword)
            {
                if (selectedRole != null)
                {
                    // Redirect user based on role
                    if (selectedRole == "Admin")
                    {
                        AdminForm adminForm = new AdminForm(selectedRole, employeeId);
                        this.Hide();
                        adminForm.Show();
                    }
                    else if (selectedRole == "Warehouse Manager")
                    {
                        Warehouse_Manager_Form warehouseManagerForm = new Warehouse_Manager_Form(selectedRole, employeeId);
                        this.Hide();
                        warehouseManagerForm.Show();
                    }
                    else if (selectedRole == "Sale")
                    {
                        Sale_Form saleForm = new Sale_Form(selectedRole, employeeId);
                        this.Hide();
                        saleForm.Show();
                    }
                }
            }
            // If it is false (0 in database) the app will redirect to ChangePassword Form
            // so that user has to change password on the first login
            else
            {
                ChangePassword changePassword = new ChangePassword(employeeId, selectedRole);
                changePassword.Show();
                this.Hide();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cbRole.SelectedIndex = 0;
            txtUsername.Focus();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            // Get data from user input
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem.ToString();

            // Valid data
            bool isValid = ValidateData(username, password, role);
            if (isValid)
            {
                // Open connection by call the GetConnection function in DatabaseConnection
                // class
                SqlConnection connection = DatabaseConnection.GetConnection();

                // Check the connection
                if (connection != null)
                {
                    // Define query to execute (Remember to enter the correct table name
                    // to avoid exception
                    string query = "SELECT EmployeeID, PasswordChanged FROM Employee WHERE Username = @username " +
                                   "AND Password = @password AND Position = @role";

                    connection.Open();

                    // Initialize a SqlCommand variable to execute query
                    SqlCommand command = new SqlCommand(query, connection);

                    // Add params to query
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("password", password);
                    command.Parameters.AddWithValue("role", role);

                    // Retrieve data from database
                    SqlDataReader reader = command.ExecuteReader();
                    int employeeId = 0;
                    bool passwordChanged = false;

                    while (reader.Read())
                    {
                        employeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                        passwordChanged = reader.GetBoolean(reader.GetOrdinal("PasswordChanged"));
                    }

                    if (employeeId > 0)
                    {
                        MessageBox.Show(
                            "Login success",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        RedirectPage(role, employeeId, passwordChanged);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid login credential",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        ClearData();
                    }

                    // Close the connection
                    connection.Close();
                }
            }
        }

        private void ClearData()
        {
            throw new NotImplementedException();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }
    }
}