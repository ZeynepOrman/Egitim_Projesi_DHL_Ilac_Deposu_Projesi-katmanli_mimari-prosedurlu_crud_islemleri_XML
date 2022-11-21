using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Facade
{
    public class FArama
    {

        public static DataTable Arama1(EDepoPersoneli islem)
        {

            SqlCommand komut = new SqlCommand("İlac_AraDepoPersoneli", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("DepoPersoneliAdSoyad", islem.DepoPersoneliAdSoyad);
            //DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Arama2(EFirma islem)
        {

            SqlCommand komut = new SqlCommand("İlac_Arafirma", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("FirmaAdi", islem.FirmaAdi);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Arama3(EGelenİlac islem)
        {

            SqlCommand komut = new SqlCommand("İlac_AraGelenİlac", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("GelenİlacAdi", islem.GelenİlacAdi);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Arama4(EGeriGelenİlac islem)
        {

            SqlCommand komut = new SqlCommand("İlac_AraGeriGelenİlac", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("GeriGelenİlacAdi", islem.GeriGelenİlacAdi);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Arama5(EİadeEdilenİlac islem)
        {

            SqlCommand komut = new SqlCommand("İlac_AraİadeEdilenİlac", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("İadeEdilenİlacAdi", islem.İadeEdilenİlacAdi);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }


    }
}
