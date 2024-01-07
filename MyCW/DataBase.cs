using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCW
{
    internal class DataBase
    {
        // класс для подключения к базе данных
        private SqlConnection SqlConnection = new SqlConnection(@"Data Source=TERMINATOR\SQLEXPRESS;Initial Catalog = CW_pharmacy;Integrated Security=true");

        public void openConnection()
        {
            if (SqlConnection.State == ConnectionState.Closed)
                SqlConnection.Open();
        }

        public void closeConnection()
        {
            if (SqlConnection.State == ConnectionState.Open)
                SqlConnection.Close();
        }

        public SqlConnection getConnection()
        {
            return SqlConnection;
        }
        

    }
}