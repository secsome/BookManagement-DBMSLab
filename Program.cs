using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BookManagement
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var csb = new MySqlConnectionStringBuilder();
                csb.Server = "localhost";
                csb.Database = "bm";
                csb.UserID = "root";
                csb.Password = "root";
                DatabaseManagement.Instance.Connect(csb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to connect to the MySql database, reason might be:\n" + ex.Message,
                    "Fatal Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            DatabaseManagement.Instance.Disconnect();
        }
    }
}
