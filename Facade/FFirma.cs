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
    public class FFirma
    {
        public static int Ekleme(EFirma veri)

        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("İlacFirmaEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("FirmaAdi", veri.FirmaAdi);
                komut.Parameters.AddWithValue("FirmaSorumlusu", veri.FirmaSorumlusu);
                komut.Parameters.AddWithValue("BorcDurumu", veri.BorcDurumu);

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
            SqlDataAdapter adp = new SqlDataAdapter("İlacFirmaListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //---------------------------guncelle--------------------------------

        public static bool Guncelle(EFirma islem)

        {
            SqlCommand komut = new SqlCommand("İlacFirmaYenile", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("FirmaNo", islem.FirmaNo);
            komut.Parameters.AddWithValue("FirmaAdi", islem.FirmaAdi);
            komut.Parameters.AddWithValue("FirmaSorumlusu", islem.FirmaSorumlusu);
            komut.Parameters.AddWithValue("BorcDurumu", islem.BorcDurumu);

            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static bool Sil(EFirma islem)
        {
            SqlCommand komut = new SqlCommand("İlacFirmaSil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("FirmaNo", islem.FirmaNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }

    }
}
