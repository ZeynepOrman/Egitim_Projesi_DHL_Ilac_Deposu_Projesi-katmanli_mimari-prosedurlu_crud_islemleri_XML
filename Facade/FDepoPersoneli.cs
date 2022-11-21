using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Entity;
using Facade;

namespace Facade
{
    public class FDepoPersoneli
    {
        public static int Ekleme(EDepoPersoneli veri)

        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("DepoPersoneliEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("DepoPersoneliAdSoyad", veri.DepoPersoneliAdSoyad);
                komut.Parameters.AddWithValue("Unvan", veri.Unvan);

                islem = komut.ExecuteNonQuery();
            }

            catch
            {
                islem = -1;

            }

            return islem;
        }

        public static DataTable Listele()

        {
            SqlDataAdapter adp = new SqlDataAdapter("DepoPersoneliListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //---------------------------guncelle--------------------------------

        public static bool Guncelle(EDepoPersoneli islem)

        {
            SqlCommand komut = new SqlCommand("DepoPersoneliYenile", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("DepoPersoneliNo", islem.DepoPersoneliNo);
            komut.Parameters.AddWithValue("DepoPersoneliAdSoyad", islem.DepoPersoneliAdSoyad);
            komut.Parameters.AddWithValue("Unvan", islem.Unvan);

            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static bool Sil(EDepoPersoneli islem)
        {
            SqlCommand komut = new SqlCommand("DepoPersoneliSil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("DepoPersoneliNo", islem.DepoPersoneliNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }

    }
}
