using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Too_Doo_List
{
    class Database
    {
        private static string server = "localhost";
        private static string port = "3306";
        private static string username = "root";
        private static string password = "root";
        private static string database = "tasks";

        MySqlConnection connection = new MySqlConnection($@"server ={server};port={port};username={username};password={password};database={database}");
    

        public void openConnect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
