using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace Facade
{
    public class Baglanti
    {

        public static readonly SqlConnection con = new SqlConnection("Server=LAPTOP-1NP5U72T; Database= İlacDeposu; integrated security=true;");

    }
}
