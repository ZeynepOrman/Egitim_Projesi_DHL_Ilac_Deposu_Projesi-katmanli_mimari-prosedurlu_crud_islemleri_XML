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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DHLİlacDeposu_Projesi
{
    public partial class DepoPersoneliXMLCrudİslemleri : Form
    {
        public DepoPersoneliXMLCrudİslemleri()
        {
            InitializeComponent();
        }

        void Yukle()
        {
            XmlDocument i = new XmlDocument(); //varolan bir dosya ile çalışacaksam nesne böyle üretilir. //<personel id="10"> attribute deniliyor.

            DataSet ds = new DataSet(); //xml dosyamızı okumak için bir reader oluşturuyoruz.
            XmlReader xmlFile;
            xmlFile = XmlReader.Create(@"İlacDeposuDepoPersoneli.xml", new XmlReaderSettings()); //içeriği datasete aktarıyoruz.
            ds.ReadXml(xmlFile); //datagridviewin kaynağı olarak dataseti gösteriyoruz.
            dataGridView1.DataSource = ds.Tables[0];
            xmlFile.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yukle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"İlacDeposuDepoPersoneli.xml");
            x.Element("İlacDeposu").Add(new XElement("personel", new XElement("id", textBox1.Text), new XElement("Adisoyadi", textBox2.Text), new XElement("Unvan", textBox4.Text)));
            x.Save(@"İlacDeposuDepoPersoneli.xml");
            Yukle();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"İlacDeposuDepoPersoneli.xml");
            XElement node = x.Element("İlacDeposu").Elements("personel").FirstOrDefault(a => a.Element("id").Value.Trim() == textBox1.Text);
            //trim boşluk hassasiyetini ortadan kaldırır. İlk bulduğu boşlukta çalışır.
            if (node != null)
            {

                node.SetElementValue("Adisoyadi", textBox2.Text);
                node.SetElementValue("Unvan", textBox4.Text);

                x.Save(@"İlacDeposuDepoPersoneli.xml");
                Yukle();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"İlacDeposuDepoPersoneli.xml");
            //ürünid=textBox'a girilen numaralı öğreniyi sil
            x.Root.Elements().Where(a => a.Element("id").Value == textBox1.Text).Remove(); // => lambda işareti? a değişken aslında
            x.Save(@"İlacDeposuDepoPersoneli.xml");
            Yukle();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                DataGridViewRow satir = dataGridView1.CurrentRow;
                textBox1.Text = satir.Cells["id"].Value.ToString();
                textBox2.Text = satir.Cells["Adisoyadi"].Value.ToString();
                textBox4.Text = satir.Cells["Unvan"].Value.ToString();
        }
    }
}
