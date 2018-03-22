using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rest_api.DB
{
    public class DBConnection
    {
        private static SqlConnection con;

        public DBConnection(String conStr)
        {
            con = new SqlConnection(conStr);
            con.Open();
        }

        public static object ExecuteScalar(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            return cmd.ExecuteScalar();
        }

        public static SqlDataReader ExecuteReader(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            return cmd.ExecuteReader();
        }

        public static void ExecuteNonQuery(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
    }
}