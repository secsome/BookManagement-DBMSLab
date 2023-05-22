using System.Data;
using System.IO;
using System.IO.Compression;
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
                "select Password from Reader where Username = @username",
                connection
            );
            cmd.Parameters.AddWithValue("username", username);
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
                "select Password from Admin where Username = @username",
                connection
            );
            cmd.Parameters.AddWithValue("username", username);
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
                var cmd = new MySqlCommand(
                    "select * from Reader where instr(Username, @username)",
                    connection
                );
                cmd.Parameters.AddWithValue("username", username);
                var adapter = new MySqlDataAdapter(cmd);
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
                var cmd = new MySqlCommand(
                    "select * from Admin where instr(Username, @username)",
                    connection
                );
                cmd.Parameters.AddWithValue("username", username);
                var adapter = new MySqlDataAdapter(cmd);
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

        public void AddUser(object username, object password, object name, object birthday)
        {
            var cmd = new MySqlCommand(
                "insert into Reader values(@username, @password, @name, @birthday)",
                connection
            );
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", PasswordHasher.Hash(password as string));
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("birthday", birthday);
            cmd.ExecuteNonQuery();
        }

        public void AddAdmin(object username, object password)
        {
            var cmd = new MySqlCommand(
                "insert into Admin values(@username, @password)",
                connection
            );
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", PasswordHasher.Hash(password as string));
            cmd.ExecuteNonQuery();
        }

        public void DeleteUser(object username)
        {
            var cmd = new MySqlCommand(
                "delete from Reader where Username = @username",
                connection
            );
            cmd.Parameters.AddWithValue("username", username);
            cmd.ExecuteNonQuery();
        }

        public void DeleteAdmin(object username)
        {
            var cmd = new MySqlCommand(
                "delete from Admin where Username = @username",
                connection
            );
            cmd.Parameters.AddWithValue("username", username);
            cmd.ExecuteNonQuery();
        }

        public void UpdateUser(object username, object password, object name, object birthday, object oldusername)
        {
            var cmd = new MySqlCommand(
                "update Reader set Username=@username, Password=@password, name=@name,birth=@birthday where Username=@oldusername",
                connection
            );
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("birthday", birthday);
            cmd.Parameters.AddWithValue("oldusername", oldusername);
            cmd.ExecuteNonQuery();
        }

        public void UpdateAdmin(object username, object password, object oldusername)
        {
            var cmd = new MySqlCommand(
                "update Admin set Username=@username, Password=@password where Username=@oldusername",
                connection
            );
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("oldusername", oldusername);
            cmd.ExecuteNonQuery();
        }

        public void ExportBackup(string path)
        {
            var cmd = new MySqlCommand();
            cmd.Connection = connection;
            var backup = new MySqlBackup(cmd);

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (var zip = new GZipStream(fs, CompressionLevel.Optimal))
                {
                    backup.ExportToStream(zip);
                }
            }
        }

        public void ImportBackup(string path)
        {
            var cmd = new MySqlCommand();
            cmd.Connection = connection;
            var backup = new MySqlBackup(cmd);

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var zip = new GZipStream(fs, CompressionMode.Decompress))
                {
                    backup.ImportFromStream(zip);
                }
            }
        }

        private MySqlConnection connection = null;

        public MySqlConnection Connection { get { return connection; } }
    }
}
