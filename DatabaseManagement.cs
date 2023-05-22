using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    public class DatabaseManagement
    {
        static public DatabaseManagement Instance = new DatabaseManagement();

        public void Connect(string str)
        {
            connection = new MySqlConnection(str);
            connection.Open();
        }

        public void Disconnect()
        {
            connection?.Close();
        }

        public string QueryUserPassword(string username)
        {
            MySqlCommand cmd = new MySqlCommand(
                string.Format(
                    "select Password from Reader where Username='{0}'",
                    username
                ),
                connection
            );
            var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return string.Empty;
            var result = reader.GetString(0);
            reader.Close();
            return result;
        }

        public string QueryAdminPassword(string username)
        {
            MySqlCommand cmd = new MySqlCommand(
                string.Format(
                    "select Password from Admin where Username='{0}'",
                    username
                ),
                connection
            );
            var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return string.Empty;
            var result = reader.GetString(0);
            reader.Close();
            return result;
        }

        public DataTable QueryUserDataSet(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var result = new DataTable();
                var adapter = new MySqlDataAdapter(
                    string.Format("select * from Reader where Username like \"%{0}%\"", username),
                    connection
                );
                adapter.Fill(result);
                return result;
            }
            else
            {
                var result = new DataTable();
                var adapter = new MySqlDataAdapter(
                    "select * from Reader",
                    connection
                );
                adapter.Fill(result);
                return result;
            }
        }

        public DataTable QueryAdminDataSet(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var result = new DataTable();
                var adapter = new MySqlDataAdapter(
                    string.Format("select * from Admin where Username like \"%{0}%\"", username),
                    connection
                );
                adapter.Fill(result);
                return result;
            }
            else
            {
                var result = new DataTable();
                var adapter = new MySqlDataAdapter(
                    "select * from Admin",
                    connection
                );
                adapter.Fill(result);
                return result;
            }
            
        }

        private MySqlConnection connection = null;

        public MySqlConnection Connection { get { return connection; } }
    }
}
