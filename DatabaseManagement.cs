using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace BookManagement
{
    public class DatabaseManagement
    {
        // The global reader for common usage
        static public DatabaseManagement PersistentReader = new DatabaseManagement();

        #region Init/Deinit
        public void Connect(string str)
        {
            connection = new MySqlConnection(str);
            connection.Open();
        }

        public void Disconnect()
        {
            connection?.Close();
        }
        #endregion

        #region Login
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
        #endregion

        #region AdminMode-UserData
        public DataTable QueryUserDataTable(string username)
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

        public DataTable QueryAdminDataTable(string username)
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
        #endregion

        #region AdminMode-AuthorData
        public DataTable QueryAuthorDataTable()
        {
            var result = new DataTable();
            var cmd = new MySqlCommand(
                "select * from Author",
                connection
            );
            var adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(result);
            return result;
        }

        public void AddAuthor(object authorId, object name, object gender, object birth, object death, object nation, object desc)
        {
            var cmd = new MySqlCommand(
                "insert into Author values(@id, @name, @gender, @birth, @death, @nation, @desc)",
                connection
            );

            cmd.Parameters.AddWithValue("id", authorId);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("gender", gender);
            cmd.Parameters.AddWithValue("birth", birth);
            cmd.Parameters.AddWithValue("death", death);
            cmd.Parameters.AddWithValue("nation", nation);
            cmd.Parameters.AddWithValue("desc", desc);

            cmd.ExecuteNonQuery();
        }
        
        public void DeleteAuthor(object authorId)
        {
            var cmd = new MySqlCommand(
                "delete from Author where authorId = @id",
                connection
            );
            cmd.Parameters.AddWithValue("id", authorId);
            cmd.ExecuteNonQuery();
        }

        public void UpdateAuthor(object authorId, object name, object gender, object birth, object death, object nation, object desc, object oldId)
        {
            var cmd = new MySqlCommand(
                "update Author set authorId = @id, name = @name, gender = @gender, birth = @birth, death = @death, nationality = @nation, description = @desc where authorId = @oldId",
                connection
            );

            cmd.Parameters.AddWithValue("id", authorId);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("gender", gender);
            cmd.Parameters.AddWithValue("birth", birth);
            cmd.Parameters.AddWithValue("death", death);
            cmd.Parameters.AddWithValue("nation", nation);
            cmd.Parameters.AddWithValue("desc", desc);
            cmd.Parameters.AddWithValue("oldId", oldId);

            cmd.ExecuteNonQuery();
        }
        #endregion

        #region AdminMode-PressData
        public DataTable QueryPressDataTable()
        {
            var result = new DataTable();
            var cmd = new MySqlCommand(
                "select * from Press",
                connection
            );
            var adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(result);
            return result;
        }

        public void AddPress(object pressId, object name, object desc)
        {
            var cmd = new MySqlCommand(
                "insert into Press values(@id, @name, @desc)",
                connection
            );

            cmd.Parameters.AddWithValue("id", pressId);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("desc", desc);

            cmd.ExecuteNonQuery();
        }

        public void DeletePress(object pressId)
        {
            var cmd = new MySqlCommand(
                "delete from Press where pressId = @id",
                connection
            );
            cmd.Parameters.AddWithValue("id", pressId);
            cmd.ExecuteNonQuery();
        }

        public void UpdatePress(object pressId, object name, object desc, object oldId)
        {
            var cmd = new MySqlCommand(
                "update Press set pressId = @id, name = @name, description = @desc where pressId = @oldId",
                connection
            );

            cmd.Parameters.AddWithValue("id", pressId);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("desc", desc);
            cmd.Parameters.AddWithValue("oldId", oldId);

            cmd.ExecuteNonQuery();
        }
        #endregion

        #region Reflection-Generic
        public DataTable QueryGenericDataTable(string tableName)
        {
            var result = new DataTable();
            var cmd = new MySqlCommand(
               "select * from @table",
               connection
            );
            cmd.Parameters.AddWithValue("table", tableName);
            var adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(result);
            return result;
        }

        public void AddGeneric(string tableName, string[] names, params object[] objects)
        {
            if (names.Length != objects.Length)
                throw new Exception("Length of names and objects should be equal");

            StringBuilder sb = new StringBuilder();
            sb.Append("insert into @table values(");
            for (int i = 0; i< names.Length - 1; i++) 
            {
                sb.Append('@');
                sb.Append(names[i]);
                sb.Append(',');
            }
            sb.Append('@');
            sb.Append(names.Last());
            sb.Append(")");
            var cmd = new MySqlCommand(
                sb.ToString(),
                connection
            );
            for (int i = 0; i< names.Length; i++) 
                cmd.Parameters.AddWithValue(names[i], objects[i]);

            cmd.ExecuteNonQuery();
        }

        public void DeleteGeneric(string tableName, string key, object id)
        {
            var cmd = new MySqlCommand(
                "delete from @table where @key = @id",
                connection
            );
            cmd.Parameters.AddWithValue("table", tableName);
            cmd.Parameters.AddWithValue("key", key);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateGeneric(string tableName, string key, object oldId, string[] names, params object[] objects)
        {
            if (names.Length != objects.Length)
                throw new Exception("Length of names and objects should be equal");

            // update Press set pressId = @id, name = @name, description = @desc where pressId = @oldId
            StringBuilder sb = new StringBuilder();
            sb.Append("update @table set ");
            for (int i = 0; i< names.Length - 1; i++)
            {
                sb.Append(names[i]);
                sb.Append("=@");
                sb.Append(names[i]);
                sb.Append(',');
            }
            sb.Append(names.Last());
            sb.Append("=@");
            sb.Append(names.Last());
            sb.Append(" where ");
            sb.Append(key);
            sb.Append("=@");
            sb.Append(key);

            var cmd = new MySqlCommand(
                sb.ToString(),
                connection
            );
            for (int i = 0; i< names.Length; i++)
                cmd.Parameters.AddWithValue(names[i], objects[i]);
            cmd.Parameters.AddWithValue(key, oldId);

            cmd.ExecuteNonQuery();
        }

        #endregion

        #region AdminMode-Backup
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
        #endregion

        #region Properties
        private MySqlConnection connection = null;

        public MySqlConnection Connection { get { return connection; } }
        #endregion
    }
}
