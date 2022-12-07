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
    public class FRapor
    {
        public static DataTable Raporlama1(EFirma islem)
        {
            //EFirma islem = new EFirma();
            SqlCommand komut = new SqlCommand("İlac_Raporlafirma", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("FirmaAdi",islem.FirmaAdi);
            DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Raporlama2(EFirma islem)
        {
            //EFirma islem = new EFirma();
             SqlCommand komut = new SqlCommand("FirmanınİadeEttiğiİlacAdedi", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;

            komut.Parameters.AddWithValue("FirmaAdi", islem.FirmaAdi);



            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Raporlama4(EDepo islem)
        {
            SqlCommand komut = new SqlCommand("FirmayaİadeEdilenİlacAdedi", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;

            komut.Parameters.AddWithValue("DepoAdi", islem.DepoAdi);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Raporlama3(EGeriGelenİlac islem)
        {

            SqlCommand komut = new SqlCommand("İlac_Tuketimtarihinegoresirala", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            //komut.Parameters.AddWithValue("İadeEdilenİlacAdi", islem.İadeEdilenİlacAdi);
            DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Raporlama5(EGelenİlac islem)
        {
            SqlCommand komut = new SqlCommand("FirmaGelenİlac", Baglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }




}

