using System;
using System.Collections.Generic;
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

        public void Connect(string server, string database, string userid, string password)
        {
            var connection_string = string.Format("Server={0};Database={1};User ID={2};Password={3}", server, database, userid, password);
            connection = new MySqlConnection(connection_string);
            connection.Open();
        }

        public void Disconnect()
        {
            connection?.Close();
        }

        private MySqlConnection connection = null;

        public MySqlConnection Connection { get { return connection; } }
    }
}
