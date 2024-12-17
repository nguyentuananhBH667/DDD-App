namespace LoginApp
{
    partial class ChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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



        private Button btnChange;
        private TextBox txtNewPassword;
        private Label lblNewPassword;
        private GroupBox gbChangePassword;
        private Button btnClear;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
    }
}