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
    public partial class AyarlarEkrani : Form
    {
        public static string ikincicozumicin, ucuncucozumicin, dorduncucozumicin, besincicozumicin, altincicozumicin, yedincicozumicin;

        private void button1_Click(object sender, EventArgs e)
        {
            if ((secondcozum.Text == "") || (thirdcozum.Text == "") || (fourthcozum.Text == "") || (fifthcozum.Text == "") || (sixthcozum.Text == "") || (seventhcozum.Text == ""))
            {
                MessageBox.Show("Lutfen gecerli bir deger girin.");
            }
            if (!(secondcozum.Text =="")&& !(thirdcozum.Text == "") && !(fourthcozum.Text == "") && !(fifthcozum.Text == "") && !(sixthcozum.Text == "") && !(seventhcozum.Text == "") )
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand query = new SqlCommand("UPDATE TblTekrar SET Cozum2='"+secondcozum.Text+"',Cozum3='"+thirdcozum.Text+"',Cozum4='"+fourthcozum.Text+"',Cozum5='"+fifthcozum.Text+"',Cozum6='"+sixthcozum.Text+"',Cozum7='"+seventhcozum.Text+"' WHERE OgrenciId='"+Ogrencigirisi.idtutucu+"'",conn);
                query.ExecuteNonQuery();
                MessageBox.Show("Zaman degistirilmistir.");
                conn.Close();
            }
        }

        public AyarlarEkrani()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            string query = "SELECT * FROM TblTekrar WHERE OgrenciId='"+Ogrencigirisi.idtutucu+"' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                secondcozum.Text = dr["Cozum2"].ToString();
                thirdcozum.Text = dr["Cozum3"].ToString();
                fourthcozum.Text = dr["Cozum4"].ToString();
                fifthcozum.Text = dr["Cozum5"].ToString();
                sixthcozum.Text = dr["Cozum6"].ToString();
                seventhcozum.Text = dr["Cozum7"].ToString();
                
            }
            conn.Close();
            ikincicozumicin = secondcozum.Text;
            ucuncucozumicin = thirdcozum.Text;
            dorduncucozumicin = fourthcozum.Text;
            besincicozumicin = fifthcozum.Text;
            altincicozumicin = sixthcozum.Text;
            yedincicozumicin = seventhcozum.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciEkrani ogrenciEkrani = new OgrenciEkrani();
            this.Hide();
            ogrenciEkrani.Show();
        }

        private void AyarlarEkrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
