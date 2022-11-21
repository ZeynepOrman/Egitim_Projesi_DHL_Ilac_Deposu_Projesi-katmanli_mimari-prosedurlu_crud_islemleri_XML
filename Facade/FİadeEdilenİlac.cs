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
    public class FİadeEdilenİlac
    {
        public static int Ekleme(EİadeEdilenİlac veri)

        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("İlac_İadeEdilenİlacEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("İadeEdilenİlacAdi", veri.İadeEdilenİlacAdi);
                komut.Parameters.AddWithValue("İadeEdilenİlacBarkodNo", veri.İadeEdilenİlacBarkodNo);
                komut.Parameters.AddWithValue("İadeEdilenİlacUretimTarihi", veri.İadeEdilenİlacUretimTarihi);
                komut.Parameters.AddWithValue("İadeEdilenİlacTuketimTarihi", veri.İadeEdilenİlacTuketimTarihi);
                komut.Parameters.AddWithValue("İadeEdilenİlacAlinanFirmaAdi", veri.İadeEdilenİlacAlinanFirmaAdi);

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
            SqlDataAdapter adp = new SqlDataAdapter("İlac_İadeEdilenİlacListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //---------------------------guncelle--------------------------------

        public static bool Guncelle(EİadeEdilenİlac islem)

        {
            SqlCommand komut = new SqlCommand("İlac_İadeEdilenİlacYenile", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("İadeEdilenİlacNo", islem.İadeEdilenİlacNo);
            komut.Parameters.AddWithValue("İadeEdilenİlacAdi", islem.İadeEdilenİlacAdi);
            komut.Parameters.AddWithValue("İadeEdilenİlacBarkodNo", islem.İadeEdilenİlacBarkodNo);
            komut.Parameters.AddWithValue("İadeEdilenİlacUretimTarihi", islem.İadeEdilenİlacUretimTarihi);
            komut.Parameters.AddWithValue("İadeEdilenİlacTuketimTarihi", islem.İadeEdilenİlacTuketimTarihi);

            komut.Parameters.AddWithValue("İadeEdilenİlacAlinanFirmaAdi", islem.İadeEdilenİlacAlinanFirmaAdi);

            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static bool Sil(EİadeEdilenİlac islem)
        {
            SqlCommand komut = new SqlCommand("İlac_İadeEdilenİlacSil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("İadeEdilenİlacNo", islem.İadeEdilenİlacNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }

    }
}
