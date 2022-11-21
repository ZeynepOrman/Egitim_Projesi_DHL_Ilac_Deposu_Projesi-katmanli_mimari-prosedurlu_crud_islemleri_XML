using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace DHLİlacDeposu_Projesi
{
    public partial class Anaekranform : Form
    {
        public Anaekranform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepoPersoneliform go = new DepoPersoneliform();
            go.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gelenİlacform go = new Gelenİlacform();
            go.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            İadeedilenilacform go = new İadeedilenilacform();
            go.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Firmaform go = new Firmaform();
            go.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Gerigelenilacform go = new Gerigelenilacform();
            go.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RaporlarForm go = new RaporlarForm();
            go.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();
            XmlElement root = xdoc.CreateElement("İlacDeposu_FirmaXMLDokumu");
            SqlConnection baglanti = new SqlConnection("Server=LAPTOP-1NP5U72T; Database= İlacDeposu; integrated security=true;");
            SqlCommand tedkom = new SqlCommand("select * from İlac_Firma", baglanti);
            baglanti.Open();
            SqlDataReader oku = tedkom.ExecuteReader();
            while (oku.Read())
            {
                XmlElement İlacDeposu_FirmaXMLDokumu = xdoc.CreateElement("İlac_Firma");
                XmlAttribute FirmaNo = xdoc.CreateAttribute("FirmaNo");
                FirmaNo.Value = oku["FirmaNo"].ToString();
                XmlAttribute FirmaAdi = xdoc.CreateAttribute("FirmaAdi");
                FirmaAdi.Value = oku["FirmaAdi"].ToString();
                XmlAttribute FirmaSorumlusu = xdoc.CreateAttribute("FirmaSorumlusu");
                FirmaSorumlusu.Value = oku["FirmaSorumlusu"].ToString();
                XmlAttribute BorcDurumu = xdoc.CreateAttribute("BorcDurumu");
                BorcDurumu.Value = oku["BorcDurumu"].ToString();

                İlacDeposu_FirmaXMLDokumu.Attributes.Append(FirmaNo);
                İlacDeposu_FirmaXMLDokumu.Attributes.Append(FirmaAdi);
                İlacDeposu_FirmaXMLDokumu.Attributes.Append(FirmaSorumlusu);
                İlacDeposu_FirmaXMLDokumu.Attributes.Append(BorcDurumu);

                root.AppendChild(İlacDeposu_FirmaXMLDokumu);
            }
            baglanti.Close();
            xdoc.AppendChild(root); //tedarikçilerin altına ekliyor.
            xdoc.Save("İlacDeposuFirma.xml");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DepoPersoneliXMLCrudİslemleri go = new DepoPersoneliXMLCrudİslemleri();
            go.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
