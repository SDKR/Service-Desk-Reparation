using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ServiceDesk_Reperation.DBConnect
{
    public class DBObject
    {
        private string server;
        private string database;
        private string uid;
        private string password;

        private MySqlConnection _connection;

        private MySqlConnection connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public DBObject()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "192.168.4.140";
            database = "reparationsdesk";
            uid = "root";
            password = "passw0rd";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";SslMode=none";
            connection = new MySqlConnection(connectionString);
        }

        public DataSet Query(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter adr = new MySqlDataAdapter(sql, connection);
                adr.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{oops - {0}", ex.Message);
                return ds;
            }
            finally
            {
                connection.Close(); 
            }
        }

        public string ScalarQuery(string sql)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("oops - {0}", ex.Message);
                return ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        public int NonQuery(string sql)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{oops - {0}", ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }

        }



      
    }
}
