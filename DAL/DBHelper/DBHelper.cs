using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL.DBHelper
{
    public static class DBHelper
    {

        private static string connectionString = "Data Source=DESKTOP-N99ELG0\\SQLEXPRESS;Initial Catalog=StudentTasksManager;Integrated Security=True;Trust Server Certificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
