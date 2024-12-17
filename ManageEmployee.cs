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
    public partial class ManageEmployee : Form
    {
        int employeeId;
        string employeePosition;

        public ManageEmployee(string employeePosition)
        {
            employeeId = 0;
            InitializeComponent();
            employeePosition = employeePosition;
        }

        private bool ValidateData(string employeeCode,
                          string employeeName,
                          string employeePosition,
                          string authorityLevel,
                          string username,
                          string password)
        {
            bool isValid = true;
            if (employeeCode == null || employeeCode == string.Empty)
            {
                MessageBox.Show(
                    "Employee Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtEmployeeCode.Focus();
                isValid = false;
            }
            else if (employeeName == null || employeeName == string.Empty)
            {
                MessageBox.Show(
                    "Employee Name cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtEmployeeName.Focus();
                isValid = false;
            }
            else if (employeePosition == null || employeePosition == string.Empty)
            {
                MessageBox.Show(
                    "Employee Position cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtEmployeePosition.Focus();
                isValid = false;
            }
            else if (authorityLevel == null || authorityLevel == string.Empty)
            {
                MessageBox.Show(
                    "Employee Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cbAuthorityLevel.Focus();
                isValid = false;
            }
            else if (username == null || username == string.Empty)
            {
                MessageBox.Show(
                    "Username cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtUsername.Focus();
                isValid = false;
            }
            else if (password == null || password == string.Empty)
            {
                MessageBox.Show(
                    "Password cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPassword.Focus();
                isValid = false;
            }
            return isValid;
        }

        private void ChangeButtonStatus(bool buttonStatus)
        {
            // When employee is selected, button add will be disabled
            // button Update, Delete & Clear will be enabled and vice versa
            btnUpdate.Enabled = buttonStatus;
            btnDelete.Enabled = buttonStatus;
            btnClear.Enabled = buttonStatus;
            btnAdd.Enabled = !buttonStatus;
        }

        private void FlushemployeeId()
        {
            // Flush employeeId value to check button and setup status for buttons
            employeeId = 0;
            ChangeButtonStatus(false);
        }

        private void LoadEmployeeData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Employee";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dtgEmployee.DataSource = table;
                connection.Close();
            }
        }

        private void ClearData()
        {
            FlushemployeeId();
            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtEmployeePosition.Text = string.Empty;
            cbAuthorityLevel.SelectedIndex = 0;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmployeeCode.Focus();
        }

        public void InitializeCombobox()
        {
            // Setup for combobox
            cbAuthorityLevel.Items.Add("Admin");
            cbAuthorityLevel.Items.Add("Warehouse Manager");
            cbAuthorityLevel.Items.Add("Sale");

            // Set the selected index to the first item of the array (Admin)
            cbAuthorityLevel.SelectedIndex = 0;
        }

        private bool CheckUserExistence(int employeeId)
        {
            bool isExist = false;
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string checkCustomerQuery = "SELECT * FROM Employee WHERE employeeId = @employeeId";
                // Declare SqlCommand variable to add parameters to query and execute it
                SqlCommand command = new SqlCommand(checkCustomerQuery, connection);
                // Add parameters
                command.Parameters.AddWithValue("employeeId", employeeId);
                // Declare SqlDataReader variable to read retrieved data
                SqlDataReader reader = command.ExecuteReader();
                // Check if reader has row (query success and return one row show user information)
                isExist = reader.HasRows;
                // close the connection
                connection.Close();
            }
            return isExist;
        }

        private void AddUser(string employeeCode, string employeeName,
           string employeePosition,
           string authorityLevel,
           string username,
           string password)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO Employee VALUES (@employeeCode, " +
                    "@employeeName, @employeePosition, " +
                    "@authorityLevel, @username, @password, 0)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeCode", employeeCode);
                command.Parameters.AddWithValue("employeeName", employeeName);
                command.Parameters.AddWithValue("employeePosition", employeePosition);
                command.Parameters.AddWithValue("authorityLevel", authorityLevel);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Successfully add new user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show("Cannot add new user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }
        private void UpdateUser(int employeeId,
                                string employeeCode,
                                string employeeName,
                                string employeePosition,
                                string authorityLevel,
                                string username,
                                string password)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Employee SET EmployeeCode = @employeeCode, " +
                    "EmployeeName = @employeeName, " +
                    "Position = @employeePosition, " +
                    "AuthorityLevel = @authorityLevel, " +
                    "Username = @username, " +
                    "Password = @password " +
                    "WHERE employeeId = @employeeId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeCode", employeeCode);
                command.Parameters.AddWithValue("employeeName", employeeName);
                command.Parameters.AddWithValue("employeePosition", employeePosition);
                command.Parameters.AddWithValue("authorityLevel", authorityLevel);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);
                command.Parameters.AddWithValue("employeeId", employeeId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Successfully update user",
                                            "Infrmation",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show("Cannot update user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }
        private void DeleteUser(int employeeId)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE Employee WHERE employeeId = @employeeId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeId", employeeId);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Successfully delete user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show("Cannot delete user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }
        private void SearchUser(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadEmployeeData();
            }
            else
            {
                SqlConnection connection = DatabaseConnection.GetConnection();
                if (connection != null)
                {
                    connection.Open();
                    string query = "SELECT * FROM Employee WHERE EmployeeCode LIKE @search, " +
                        "OR EmployeeName LIKE @search, " +
                        "OR Position LIKE @search, " +
                        "OR AuthorityLevel LIKE @search, " +
                        "OR Username LIKE @search, " +
                        "OR Password LIKE @search";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("search", "%" + search + "%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dtgEmployee.DataSource = table;
                    connection.Close();
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string employeeCode = txtEmployeeCode.Text;
            string employeeName = txtEmployeeName.Text;
            string employeePosition = txtEmployeePosition.Text;
            string authorityLevel = cbAuthorityLevel.SelectedItem.ToString();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool isValid = ValidateData(employeeCode,
                employeeName,
                employeePosition,
                authorityLevel,
                username,
                password);
            if (isValid)
            {
                AddUser(employeeCode, employeeName, employeePosition, authorityLevel, username, password);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string employeeCode = txtEmployeeCode.Text;
            string employeeName = txtEmployeeName.Text;
            string employeePosition = txtEmployeePosition.Text;
            string authorityLevel = cbAuthorityLevel.SelectedItem.ToString();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool isValid = ValidateData(employeeCode,
                                        employeeName,
                                        employeePosition,
                                        authorityLevel,
                                        username,
                                        password);
            if (isValid)
            {
                UpdateUser(employeeId, employeeCode, employeeName, employeePosition, authorityLevel, username, password);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DeleteUser(employeeId);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (employeePosition)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(employeePosition, employeeId);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse Manager":
                    {
                        Warehouse_Manager_Form warehouseManagerForm = new Warehouse_Manager_Form(employeePosition, employeeId);
                        this.Hide();
                        warehouseManagerForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        Sale_Form saleForm = new Sale_Form(employeePosition, employeeId);
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            ChangeButtonStatus(false);
            InitializeCombobox();
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text;
            SearchUser(search);
        }
        private void dtgEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgEmployee.CurrentCell.RowIndex;
            if (index != -1)
            {
                employeeId = Convert.ToInt32(dtgEmployee.Rows[index].Cells[0].Value);
                ChangeButtonStatus(true);
                txtEmployeeCode.Text = dtgEmployee.Rows[index].Cells[1].Value.ToString();
                txtEmployeeName.Text = dtgEmployee.Rows[index].Cells[2].Value.ToString();
                txtEmployeePosition.Text = dtgEmployee.Rows[index].Cells[3].Value.ToString();
                string authorityLevel = dtgEmployee.Rows[index].Cells[4].Value.ToString();
                if (authorityLevel == "Admin")
                {
                    cbAuthorityLevel.SelectedIndex = 0;
                }
                else if (authorityLevel == "Warehouse Manager")
                {
                    cbAuthorityLevel.SelectedIndex = 1;
                }
                else if (authorityLevel == "Sale")
                {
                    cbAuthorityLevel.SelectedIndex = 2;
                }
                txtUsername.Text = dtgEmployee.Rows[index].Cells[5].Value.ToString();
                txtPassword.Text = dtgEmployee.Rows[index].Cells[6].Value.ToString();
            }
        }

        private void InitializeComponent()
        {
            gbManageEmployee = new GroupBox();
            dtgEmployee = new DataGridView();
            txtSearch = new TextBox();
            lblEmployeeList = new Label();
            gbEmployeeInformation = new GroupBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cbAuthorityLevel = new ComboBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            txtEmployeePosition = new TextBox();
            txtEmployeeName = new TextBox();
            txtEmployeeCode = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            lblAuthorityLevel = new Label();
            lblPosition = new Label();
            lblEmployeeName = new Label();
            lblEmployeeCode = new Label();
            btnBack = new Button();
            gbManageEmployee.SuspendLayout();
            ((ISupportInitialize)dtgEmployee).BeginInit();
            gbEmployeeInformation.SuspendLayout();
            SuspendLayout();
            // 
            // gbManageEmployee
            // 
            gbManageEmployee.Controls.Add(dtgEmployee);
            gbManageEmployee.Controls.Add(txtSearch);
            gbManageEmployee.Controls.Add(lblEmployeeList);
            gbManageEmployee.Controls.Add(gbEmployeeInformation);
            gbManageEmployee.Location = new Point(15, 11);
            gbManageEmployee.Name = "gbManageEmployee";
            gbManageEmployee.Size = new Size(711, 470);
            gbManageEmployee.TabIndex = 0;
            gbManageEmployee.TabStop = false;
            gbManageEmployee.Text = "Manage Employee";
            // 
            // dtgEmployee
            // 
            dtgEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgEmployee.Location = new Point(394, 76);
            dtgEmployee.Name = "dtgEmployee";
            dtgEmployee.RowTemplate.Height = 25;
            dtgEmployee.Size = new Size(301, 337);
            dtgEmployee.TabIndex = 3;
            dtgEmployee.CellClick += dtgEmployee_CellClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(472, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(223, 23);
            txtSearch.TabIndex = 2;
            txtSearch.KeyUp += txtSearch_KeyUp;
            // 
            // lblEmployeeList
            // 
            lblEmployeeList.AutoSize = true;
            lblEmployeeList.Location = new Point(386, 31);
            lblEmployeeList.Name = "lblEmployeeList";
            lblEmployeeList.Size = new Size(80, 15);
            lblEmployeeList.TabIndex = 1;
            lblEmployeeList.Text = "Employee List";
            // 
            // gbEmployeeInformation
            // 
            gbEmployeeInformation.Controls.Add(btnClear);
            gbEmployeeInformation.Controls.Add(btnDelete);
            gbEmployeeInformation.Controls.Add(btnUpdate);
            gbEmployeeInformation.Controls.Add(btnAdd);
            gbEmployeeInformation.Controls.Add(cbAuthorityLevel);
            gbEmployeeInformation.Controls.Add(txtPassword);
            gbEmployeeInformation.Controls.Add(txtUsername);
            gbEmployeeInformation.Controls.Add(txtEmployeePosition);
            gbEmployeeInformation.Controls.Add(txtEmployeeName);
            gbEmployeeInformation.Controls.Add(txtEmployeeCode);
            gbEmployeeInformation.Controls.Add(lblPassword);
            gbEmployeeInformation.Controls.Add(lblUsername);
            gbEmployeeInformation.Controls.Add(lblAuthorityLevel);
            gbEmployeeInformation.Controls.Add(lblPosition);
            gbEmployeeInformation.Controls.Add(lblEmployeeName);
            gbEmployeeInformation.Controls.Add(lblEmployeeCode);
            gbEmployeeInformation.Location = new Point(6, 22);
            gbEmployeeInformation.Name = "gbEmployeeInformation";
            gbEmployeeInformation.Size = new Size(359, 391);
            gbEmployeeInformation.TabIndex = 0;
            gbEmployeeInformation.TabStop = false;
            gbEmployeeInformation.Text = "Employee Information";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(211, 334);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(98, 35);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(42, 334);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(91, 35);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(211, 278);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(98, 36);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(42, 278);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(91, 36);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cbAuthorityLevel
            // 
            cbAuthorityLevel.FormattingEnabled = true;
            cbAuthorityLevel.Location = new Point(103, 151);
            cbAuthorityLevel.Name = "cbAuthorityLevel";
            cbAuthorityLevel.Size = new Size(234, 23);
            cbAuthorityLevel.TabIndex = 11;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(103, 234);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(234, 23);
            txtPassword.TabIndex = 10;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(103, 194);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(234, 23);
            txtUsername.TabIndex = 9;
            // 
            // txtEmployeePosition
            // 
            txtEmployeePosition.Location = new Point(102, 110);
            txtEmployeePosition.Name = "txtEmployeePosition";
            txtEmployeePosition.Size = new Size(235, 23);
            txtEmployeePosition.TabIndex = 8;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(102, 72);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(235, 23);
            txtEmployeeName.TabIndex = 7;
            // 
            // txtEmployeeCode
            // 
            txtEmployeeCode.Location = new Point(103, 31);
            txtEmployeeCode.Name = "txtEmployeeCode";
            txtEmployeeCode.Size = new Size(234, 23);
            txtEmployeeCode.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(19, 234);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(19, 197);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // lblAuthorityLevel
            // 
            lblAuthorityLevel.AutoSize = true;
            lblAuthorityLevel.Location = new Point(19, 154);
            lblAuthorityLevel.Name = "lblAuthorityLevel";
            lblAuthorityLevel.Size = new Size(30, 15);
            lblAuthorityLevel.TabIndex = 3;
            lblAuthorityLevel.Text = "Role";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(19, 118);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(50, 15);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "Position";
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Location = new Point(19, 75);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(56, 15);
            lblEmployeeName.TabIndex = 1;
            lblEmployeeName.Text = "Fullname";
            // 
            // lblEmployeeCode
            // 
            lblEmployeeCode.AutoSize = true;
            lblEmployeeCode.Location = new Point(19, 34);
            lblEmployeeCode.Name = "lblEmployeeCode";
            lblEmployeeCode.Size = new Size(35, 15);
            lblEmployeeCode.TabIndex = 0;
            lblEmployeeCode.Text = "Code";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(21, 443);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(77, 31);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ManageEmployee
            // 
            ClientSize = new Size(738, 486);
            Controls.Add(btnBack);
            Controls.Add(gbManageEmployee);
            Name = "ManageEmployee";
            Load += ManageEmployee_Load;
            gbManageEmployee.ResumeLayout(false);
            gbManageEmployee.PerformLayout();
            ((ISupportInitialize)dtgEmployee).EndInit();
            gbEmployeeInformation.ResumeLayout(false);
            gbEmployeeInformation.PerformLayout();
            ResumeLayout(false);
        }
    }
}