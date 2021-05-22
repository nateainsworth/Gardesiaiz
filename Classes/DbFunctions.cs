using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gardesiai.Classes
{
    public static class DbFunctions
    {
        public static String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=\"" + Environment.CurrentDirectory + "\\DB\\GardesiaiDB.MDF\";Integrated Security=True";

        public static bool sendQuery(String SQLQuery)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = DbFunctions.connectionString;
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = SQLQuery;
                query.ExecuteReader();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool compareRecord(String table, String column, String record)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = DbFunctions.connectionString;
            conn.Open();
            SqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT " + column + " FROM " + table + "";
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                if (reader[column].ToString() == record)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
    }
}
