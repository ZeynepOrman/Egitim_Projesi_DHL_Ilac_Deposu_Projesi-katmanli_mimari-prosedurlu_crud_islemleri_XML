using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Facade;

namespace Facade
{
    public class FComboBox
    {
        public static DataTable CBDoldur1()
        {
            SqlDataAdapter adp = new SqlDataAdapter("FirmaNoSec", Baglanti.con);
            //SqlDataReader dr;
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }

        public static DataTable CBDoldur2()
        {
            SqlDataAdapter adp = new SqlDataAdapter("DepoNoSec", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

    }

}
