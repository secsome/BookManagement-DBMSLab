using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    public partial class AdminForm : Form
    {
        public AdminForm(string username)
        {
            InitializeComponent();
            Text = "Admin - Logined as " + username;
            tbp_UsersUpdateDataSet();
        }

        private void tbcAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcAdmin.SelectedIndex == 0)  // Users
            {
                tbp_UsersUpdateDataSet();
            }
            else if (tbcAdmin.SelectedIndex == 1) // Books
            {

            }
        }

        private void tbp_UsersUpdateDataSet()
        {
            if (rdbUser.Checked)
                dgvUsers.DataSource = DatabaseManagement.Instance.QueryUserDataSet(txbUsersSearch.Text);
            else
                dgvUsers.DataSource = DatabaseManagement.Instance.QueryAdminDataSet(txbUsersSearch.Text);

        }

        private void rdbUser_CheckedChanged(object sender, EventArgs e)
            => tbp_UsersUpdateDataSet();

        private void rdbAdmin_CheckedChanged(object sender, EventArgs e)
            => tbp_UsersUpdateDataSet();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var changes = (dgvUsers.DataSource as DataSet).GetChanges();
            if (changes == null)
                return;

            var table = changes.Tables[0];
            foreach(DataRow row in table.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        {
                            if (rdbUser.Checked) 
                            {
                                var cmd = new MySqlCommand(
                                    string.Format(
                                        "insert into Reader values('{0}','{1}','{2}','{3}')",
                                        row[0], PasswordHasher.Hash(row[1] as string), row[2], row[3]
                                    ),
                                    DatabaseManagement.Instance.Connection
                                );
                                cmd.ExecuteNonQuery();
                            }
                            else if(rdbAdmin.Checked)
                            {
                                var cmd = new MySqlCommand(
                                    string.Format(
                                        "insert into Admin values('{0}','{1}')",
                                        row[0], PasswordHasher.Hash(row[1] as string)
                                    ),
                                    DatabaseManagement.Instance.Connection
                                );
                                cmd.ExecuteNonQuery();
                            }
                        }
                        break;
                    case DataRowState.Deleted:
                        row.RejectChanges();
                        if (rdbUser.Checked)
                        {
                            var cmd = new MySqlCommand(
                                string.Format(
                                    "delete from Reader where Username='{0}'",
                                    row[0]
                                ),
                                DatabaseManagement.Instance.Connection
                            );
                            cmd.ExecuteNonQuery();
                        }
                        else if (rdbAdmin.Checked)
                        {
                            var cmd = new MySqlCommand(
                                string.Format(
                                    "delete from Admin where Username='{0}'",
                                    row[0]
                                ),
                                DatabaseManagement.Instance.Connection
                            );
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    
                    case DataRowState.Modified:
                        if (rdbUser.Checked)
                        {
                            var str = string.Format(
                                "update Reader set Username='{0}',Password='{1}',name='{2}',birth='{3}' where Username='",
                                row[0], PasswordHasher.Hash(row[1] as string), row[2], row[3]
                            );
                            row.RejectChanges();
                            str += row[0] + "'";
                            var cmd = new MySqlCommand(
                                str,
                                DatabaseManagement.Instance.Connection
                            );
                            cmd.ExecuteNonQuery();
                        }
                        else if (rdbAdmin.Checked)
                        {
                            var str = string.Format(
                                "update Admin set Username='{0}',Password='{1}' where Username='",
                                row[0], PasswordHasher.Hash(row[1] as string)
                            );
                            row.RejectChanges();
                            str += row[0] + "'";
                            var cmd = new MySqlCommand(
                                str,
                                DatabaseManagement.Instance.Connection
                            );
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    
                    default:
                        break;
                }
            }

            tbp_UsersUpdateDataSet();
        }

        private void txbUsersSearch_TextChanged(object sender, EventArgs e)
         => tbp_UsersUpdateDataSet();
    }
}
