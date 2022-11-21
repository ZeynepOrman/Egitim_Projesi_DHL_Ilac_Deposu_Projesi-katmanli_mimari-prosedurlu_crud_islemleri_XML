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
    public class FGeriGelenİlac
    {
        public static int Ekleme(EGeriGelenİlac veri)

        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("İlac_GeriGelenİlacEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("GeriGelenİlacAdi", veri.GeriGelenİlacAdi);
                komut.Parameters.AddWithValue("GeriGelenİlacBarkodNo", veri.GeriGelenİlacBarkodNo);
                komut.Parameters.AddWithValue("GeriGelenİlacUretimTarihi", veri.GeriGelenİlacUretimTarihi);
                komut.Parameters.AddWithValue("GeriGelenİlacTuketimTarihi", veri.GeriGelenİlacTuketimTarihi);
                komut.Parameters.AddWithValue("GeriGelenİlacSatilanFirmaAdi", veri.GeriGelenİlacSatilanFirmaAdi);

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
            SqlDataAdapter adp = new SqlDataAdapter("İlac_GeriGelenİlacListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //---------------------------guncelle--------------------------------

        public static bool Guncelle(EGeriGelenİlac islem)

        {
            SqlCommand komut = new SqlCommand("İlac_GeriGelenİlacYenile", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("GeriGelenİlacNo", islem.GeriGelenİlacNo);
            komut.Parameters.AddWithValue("GeriGelenİlacAdi", islem.GeriGelenİlacAdi);
            komut.Parameters.AddWithValue("GeriGelenİlacBarkodNo", islem.GeriGelenİlacBarkodNo);
            komut.Parameters.AddWithValue("GeriGelenİlacUretimTarihi", islem.GeriGelenİlacUretimTarihi);
            komut.Parameters.AddWithValue("GeriGelenİlacTuketimTarihi", islem.GeriGelenİlacTuketimTarihi);

            komut.Parameters.AddWithValue("GeriGelenİlacSatilanFirmaAdi", islem.GeriGelenİlacSatilanFirmaAdi);

            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static bool Sil(EGeriGelenİlac islem)
        {
            SqlCommand komut = new SqlCommand("İlac_GeriGelenİlacSil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("GeriGelenİlacNo", islem.GeriGelenİlacNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }

    }
}
