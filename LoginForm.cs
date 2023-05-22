using System;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Reset();
        }

        private void UpdateLoginButtonStatus()
        {
            if (string.IsNullOrEmpty(txbUsername.Text) || string.IsNullOrEmpty(txbPassword.Text))
                btnLogin.Enabled = false;
            else
                btnLogin.Enabled = true;
        }

        private void Reset()
        {
            txbUsername.Text = string.Empty;
            txbPassword.Text = string.Empty;
            rdbNormal.Checked = true;
            btnLogin.Enabled = false;
        }

        private bool LoginAsAdmin(string username, string hashed_password)
        {
            MySqlCommand cmd = new MySqlCommand(
                string.Format(
                    "select Password from Admin where Username='{0}'",
                    username
                ),
                DatabaseManagement.Instance.Connection
            );
            var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return false;
            var result = reader.GetString(0);
            reader.Close();

            return hashed_password == result;
        }

        private bool LoginAsUser(string username, string hashed_password)
        {
            MySqlCommand cmd = new MySqlCommand(
                string.Format(
                    "select Password from Reader where Username='{0}'",
                    username
                ),
                DatabaseManagement.Instance.Connection
            );
            var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return false;
            var result = reader.GetString(0);
            reader.Close();

            return hashed_password == result;
        }

        private void TryLogin(string username, string password, bool admin)
        {
            string hashed_password = PasswordHasher.Hash(password);
            if (admin)
            {
                if (LoginAsAdmin(username, hashed_password)) 
                {
                    var admin_form = new AdminForm(username);
                    Hide();
                    admin_form.ShowDialog();
                    Reset();
                    Show();
                }
                else
                {
                    MessageBox.Show(
                        "Invalid username or password!",
                        "Login failed!", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                if (LoginAsUser(username, hashed_password))
                {
                    var user_form = new UserForm(username);
                    Hide();
                    user_form.ShowDialog();
                    Reset();
                    Show();
                }
                else
                {
                    MessageBox.Show(
                        "Invalid username or password!",
                        "Login failed!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void txbUsername_TextChanged(object sender, EventArgs e) 
            => UpdateLoginButtonStatus();
        private void txbPassword_TextChanged(object sender, EventArgs e) 
            => UpdateLoginButtonStatus();
        private void btnLogin_Click(object sender, EventArgs e)
            => TryLogin(txbUsername.Text, txbPassword.Text, rdbAdmin.Checked);
    }
}
