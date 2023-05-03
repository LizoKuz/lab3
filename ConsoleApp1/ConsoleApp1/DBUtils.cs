using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "product";
            string username = "lizok";
            string password = "some_pass";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }
}
