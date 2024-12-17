namespace LoginApp
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbRole = new ComboBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            lblRole = new Label();
            btnLogin = new Button();
            btnClear = new Button();
            SuspendLayout();
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(302, 179);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(155, 23);
            cbRole.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(302, 139);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(155, 23);
            txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(302, 105);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(155, 23);
            txtUsername.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(219, 113);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(219, 147);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(219, 179);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(30, 15);
            lblRole.TabIndex = 5;
            lblRole.Text = "Role";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(219, 234);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(93, 32);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(368, 234);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(89, 32);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 399);
            Controls.Add(btnClear);
            Controls.Add(btnLogin);
            Controls.Add(lblRole);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(cbRole);
            Name = "LoginForm";
            Text = "Login Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbRole;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblRole;
        private Button btnLogin;
        private Button btnClear;
    }
}