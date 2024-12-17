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
    public partial class ChangePassword : Form
    {
        // role variable is used to redirect page after password changed
        string? role;

        // employeeId variable is used to pass to other forms which need EmployeeID to
        // manipulate data in tables (Like Order needs EmployeeID when inserted)
        int employeeId;

        public ChangePassword(int employeeId, string? role)
        {
            // Assign data to the above variables when form is initialized
            employeeId = employeeId;
            this.role = role;
            InitializeComponent();
        }

        private void ClearData()
        {
            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtNewPassword.Focus();
        }

        private void RedirectPage(int employeeId, string authorityLevel)
        {
            if (authorityLevel == "Admin")
            {
                AdminForm adminForm = new AdminForm(authorityLevel, employeeId);
                adminForm.Show();
            }
            else if (authorityLevel == "Warehouse Manager")
            {
                Warehouse_Manager_Form warehouseManagerForm = new Warehouse_Manager_Form(authorityLevel, employeeId);
                warehouseManagerForm.Show();
            }
            else if (authorityLevel == "Sale")
            {
                Sale_Form saleForm = new Sale_Form(authorityLevel, employeeId);
                saleForm.Show();
            }
        }

        private void UpdateEmployee(int employeeId, string newPassword)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Employee SET Password = @newPassword, " +
                             "PasswordChanged = 1 " +
                             "WHERE EmployeeID = @employeeId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                command.Parameters.AddWithValue("@employeeId", employeeId);
                int isChanged = command.ExecuteNonQuery();
                if (isChanged > 0)
                {
                    MessageBox.Show(
                        "Successfully change password",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    RedirectPage(employeeId, "role");
                }
                else
                {
                    MessageBox.Show(
                        "An error occur while change password",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    ClearData();
                }
                connection.Close();
            }
        }

        private bool ValidateData(string newPassword, string confirmPassword)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show(
                    "New password cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtNewPassword.Focus();
                isValid = false;
            }
            else if (string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show(
                    "Confirm password cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtConfirmPassword.Focus();
                isValid = false;
            }
            else if (newPassword != confirmPassword)
            {
                MessageBox.Show(
                    "New & confirm passwords are not similar",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ClearData();
                isValid = false;
            }
            return isValid;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            bool isValid = ValidateData(newPassword, confirmPassword);
            if (isValid)
            {
                UpdateEmployee(employeeId, newPassword);
            }
        }

        private void InitializeComponent()
        {
            btnChange = new Button();
            txtNewPassword = new TextBox();
            lblNewPassword = new Label();
            gbChangePassword = new GroupBox();
            btnClear = new Button();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            gbChangePassword.SuspendLayout();
            SuspendLayout();
            // 
            // btnChange
            // 
            btnChange.Location = new Point(52, 164);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(91, 36);
            btnChange.TabIndex = 0;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(188, 75);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(235, 23);
            txtNewPassword.TabIndex = 1;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(72, 78);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(87, 15);
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "New password ";
            // 
            // gbChangePassword
            // 
            gbChangePassword.Controls.Add(btnClear);
            gbChangePassword.Controls.Add(lblConfirmPassword);
            gbChangePassword.Controls.Add(txtConfirmPassword);
            gbChangePassword.Controls.Add(btnChange);
            gbChangePassword.Controls.Add(lblNewPassword);
            gbChangePassword.Controls.Add(txtNewPassword);
            gbChangePassword.Location = new Point(28, 15);
            gbChangePassword.Name = "gbChangePassword";
            gbChangePassword.Size = new Size(744, 255);
            gbChangePassword.TabIndex = 3;
            gbChangePassword.TabStop = false;
            gbChangePassword.Text = "Change password ";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(332, 164);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(91, 36);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear ";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(72, 120);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(107, 15);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Confirm password ";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(188, 117);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(235, 23);
            txtConfirmPassword.TabIndex = 4;
            // 
            // ChangePassword
            // 
            ClientSize = new Size(804, 296);
            Controls.Add(gbChangePassword);
            Name = "ChangePassword";
            gbChangePassword.ResumeLayout(false);
            gbChangePassword.PerformLayout();
            ResumeLayout(false);
        }
    }
}
