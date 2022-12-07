using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class FKullaniciGirisi
    {
        public static int KullaniciKayit(EKullaniciGirisi veri)

        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("KKayitİlacDeposu", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("KullaniciAdi", veri.KullaniciAdi);
                komut.Parameters.AddWithValue("Sifre", veri.Sifre);
                komut.Parameters.AddWithValue("Email", veri.Email);
                komut.Parameters.AddWithValue("Telefon", veri.Telefon);
                islem = komut.ExecuteNonQuery();

            }

            catch
            {
                islem = -1;

            }

            return islem;
        }

        public static int KullaniciKontrol(EKullaniciGirisi veri)

        {
            int islem = 0;
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("KGirisİlacDeposu", Baglanti.con);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                //SqlCommand komut = new SqlCommand("KGirisİlacDeposu", Baglanti.con);
                //adp.CommandType = CommandType.StoredProcedure;
                //if (komut.Connection.State != ConnectionState.Open)
                //{
                //    komut.Connection.Open();
                //}
                adp.SelectCommand.Parameters.AddWithValue("KullaniciAdi", veri.KullaniciAdi);
                adp.SelectCommand.Parameters.AddWithValue("Sifre", veri.Sifre);
                //islem = komut.ExecuteNonQuery();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    islem = 1;
                }

                else
                {
                    islem = 0;
                }
            }

            catch
            {
                islem = -1;

            }

            return islem;
        }
    }
}
