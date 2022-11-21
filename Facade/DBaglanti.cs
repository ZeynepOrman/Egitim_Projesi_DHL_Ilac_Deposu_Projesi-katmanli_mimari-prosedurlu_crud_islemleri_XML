using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Facade
{
    public class DBaglanti
    {

        public static readonly SqlConnection con = new SqlConnection("Server=LAPTOP-1NP5U72T; Database= İlacDeposu; integrated security=true;");

        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            try
            {
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                return komut.ExecuteNonQuery() > 0;


            }

            catch (Exception)
            {
                return false;

            }
            finally
            {
                if (komut.Connection.State != ConnectionState.Closed)
                    komut.Connection.Close();
            }
        }
    }
}
