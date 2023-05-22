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

        private DataSet tbpUsers_ds = null;

        private void tbp_UsersUpdateDataSet()
        {
            if (rdbUser.Checked)
            {
                tbpUsers_ds = new DataSet();
                var adapter = new MySqlDataAdapter(
                    "select * from Reader",
                    DatabaseManagement.Instance.Connection
                );
                adapter.Fill(tbpUsers_ds);
                dgvUsers.DataSource = tbpUsers_ds;
                dgvUsers.DataMember = tbpUsers_ds.Tables[0].TableName;
            }
            else if (rdbAdmin.Checked)
            {
                tbpUsers_ds = new DataSet();
                var adapter = new MySqlDataAdapter(
                    "select * from Admin",
                    DatabaseManagement.Instance.Connection
                );
                adapter.Fill(tbpUsers_ds);
                dgvUsers.DataSource = tbpUsers_ds;
                dgvUsers.DataMember = tbpUsers_ds.Tables[0].TableName;
            }
        }

        private void rdbUser_CheckedChanged(object sender, EventArgs e)
            => tbp_UsersUpdateDataSet();

        private void rdbAdmin_CheckedChanged(object sender, EventArgs e)
            => tbp_UsersUpdateDataSet();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var changes = tbpUsers_ds.GetChanges();
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

                            }
                            else if(rdbAdmin.Checked)
                            {

                            }
                        }
                        break;
                    case DataRowState.Deleted:

                        break;
                    
                    case DataRowState.Modified:
                        break;
                    
                    default:
                        break;
                }
            }
        }
    }
}
