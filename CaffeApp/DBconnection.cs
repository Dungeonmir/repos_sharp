using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeApp
{
    public class DBconnection
    {
        public string ConnectionString { get; set; }
        public string Database { get;  }
        public string Server { get;  }
        public string Password { get; }
        public string Login { get;  }
        public MySql.Data.MySqlClient.MySqlConnection mySqlConnection { get; set; }
        /// <summary>
        /// Params: Server, Database, Login, Password
        /// </summary>
        public DBconnection(string server, string database, string login, string password)
        {
            Database = database;
            Server = server;
            Password = password;
            Login = login;
            ConnectionString = $"server={server};uid={login};pwd={password};database={database}";

        }
        /// <summary>
        /// DBstrings: Server, Database, Login, Password
        /// </summary>
        public DBconnection(string[] DBstrings)
        {
            if (DBstrings != null)
            {
                if (DBstrings.Length == 4)
                {
                    Server = DBstrings[0];
                    Database = DBstrings[1];
                    Login = DBstrings[2];
                    Password = DBstrings[3];
                    ConnectionString = $"server={Server};uid={Login};pwd={Password};database={Database}";
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid number of params");
                }
            }
            else
            {
                throw new Exception("Null recieved");
            }
        }
        /// <summary>
        ///         Method invokes mySqlConnection.Open() method
        ///     <para>
        ///         If succesful returns "Connected" string
        ///     </para>
        ///     <para>
        ///         Else returns Exception message
        ///     </para>
        /// </summary>
        public string connect()
        {
            try
            {
                mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
                mySqlConnection.ConnectionString = ConnectionString;
                mySqlConnection.Open();
                return "Connected";
            }



            catch (System.AggregateException ex)
            {
                return ex.Message;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// Method invokes mySqlConnection.Close() method
        /// </summary>
        public void close()
        {
            mySqlConnection.Close();
        }
        public MySql.Data.MySqlClient.MySqlDataReader execute(string statement)
        {
            MySql.Data.MySqlClient.MySqlCommand cmd =  mySqlConnection.CreateCommand();
            cmd.CommandText = statement;
            return cmd.ExecuteReader();

        }
        public int getRowsCount(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            MySql.Data.MySqlClient.MySqlDataReader tempReader = reader;
            try
            {
                int count = 0;
                while (tempReader.Read())
                {
                    count++;
                }
                tempReader = null;
                return count;
            }
            catch (Exception ex)
            {
                string error = string.Format("Failed to get total rows in MySQL Database. Exception: {0}", ex.Message);
                return -1;
            }
        }
    }
}
