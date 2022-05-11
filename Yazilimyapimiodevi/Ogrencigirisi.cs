using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Yazilimyapimiodevi
{
    public partial class Ogrencigirisi : Form
    {
        public static string idtutucu;
        public Ogrencigirisi()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sifremiunuttum sifremiunuttum = new Sifremiunuttum();
            
            sifremiunuttum.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Kayıtekrani kayit = new Kayıtekrani();
            this.Hide();
            kayit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ogrencigirisid.Text.Trim() == "" || ogrencigirissifre.Text.Trim() == "")
            {
                MessageBox.Show("Lutfen bos alan birakmayiniz.");
            }
            if (!(ogrencigirisid.Text == "") && !(ogrencigirissifre.Text == ""))
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM TblOgrenci WHERE OgrenciId = '" + ogrencigirisid.Text.ToString() + "' AND Sifre = '" + ogrencigirissifre.Text.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                idtutucu = ogrencigirisid.Text;

                if (dtable.Rows.Count == 1)
                {
                    OgrenciEkrani ogrenciEkrani = new OgrenciEkrani();
                    this.Hide();
                    ogrenciEkrani.Show();
                    conn.Close();
                }
            }
        }

        private void Ogrencigirisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
