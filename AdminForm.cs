using System;
using System.Data;
using System.Windows.Forms;

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
            var changes = (dgvUsers.DataSource as DataTable).GetChanges();
            if (changes == null)
                return;

            foreach(DataRow row in changes.Rows)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        {
                            if (rdbUser.Checked) 
                                DatabaseManagement.Instance.AddUser(row[0], row[1], row[2], row[3]);
                            else
                                DatabaseManagement.Instance.AddAdmin(row[0], row[1]);
                        }
                        break;
                    case DataRowState.Deleted:
                        {
                            row.RejectChanges();
                            if (rdbUser.Checked)
                                DatabaseManagement.Instance.DeleteUser(row[0]);
                            else
                                DatabaseManagement.Instance.DeleteAdmin(row[0]);
                        }
                        break;
                    
                    case DataRowState.Modified:
                        {
                            if (rdbUser.Checked)
                            {
                                var username = row[0];
                                var password = row[1];
                                var name = row[2];
                                var birthday = row[3];
                                row.RejectChanges();
                                DatabaseManagement.Instance.UpdateUser(username, password, name, birthday, row[0]);
                            }
                            else if (rdbAdmin.Checked)
                            {
                                var username = row[0];
                                var password = row[1];
                                row.RejectChanges();
                                DatabaseManagement.Instance.UpdateAdmin(username, password, row[0]);
                            }
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

        private void btnExportBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                DatabaseManagement.Instance.ExportBackup(sfd.FileName);
                MessageBox.Show(
                    "Backup exported!", 
                    "Backup Exporter", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnImportBackup_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                DatabaseManagement.Instance.ImportBackup(ofd.FileName);
                MessageBox.Show(
                    "Backup imported!",
                    "Backup Importer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                tbp_UsersUpdateDataSet();
            }
        }
    }
}
