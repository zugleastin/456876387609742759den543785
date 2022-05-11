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
    public partial class Kayıtekrani : Form
    {
        public Kayıtekrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
            {
                MessageBox.Show("Lutfen bos yer birakmayiniz.");
            }

            if(!(textBox1.Text == "")&& !(textBox2.Text == "") && !(textBox3.Text == "") && !(textBox4.Text == "") )
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TblOgrenci (Ad,Soyad,Email,Sifre) values(@A,@S,@E,@Si)",conn);
                cmd.Parameters.AddWithValue("@A", textBox1.Text);
                cmd.Parameters.AddWithValue("@S", textBox2.Text);
                cmd.Parameters.AddWithValue("@E", textBox3.Text);
                cmd.Parameters.AddWithValue("@Si", textBox4.Text);
                cmd.ExecuteNonQuery();
                SqlCommand sqlCommand1 = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,Ad,Soyad) SELECT DISTINCT OgrenciId,Ad,Soyad FROM TblOgrenci T WHERE NOT EXISTS (SELECT 1 FROM TblSinavekrani TSE WHERE TSE.OgrenciId=T.OgrenciId AND TSE.Ad=T.Ad AND TSE.Soyad=T.Soyad)",conn);
                sqlCommand1.ExecuteNonQuery();
                SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO TblTekrar (OgrenciId) SELECT DISTINCT OgrenciId FROM TblOgrenci T WHERE NOT EXISTS (SELECT 1 FROM TblTekrar TT WHERE TT.OgrenciId=T.OgrenciId )", conn);
                sqlCommand2.ExecuteNonQuery();
                MessageBox.Show("Kaydiniz yapilmistir.");
                string sqlCommand = "SELECT * FROM TblOgrenci WHERE Email ='" + textBox3.Text + "'AND Sifre ='" + textBox4.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count == 1)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.ColumnCount = 2;
                    dataGridView1.Columns[0].HeaderText = "OgrenciId";
                    dataGridView1.Columns[0].DataPropertyName = "OgrenciId";
                    dataGridView1.Columns[1].HeaderText = "Sifreniz";
                    dataGridView1.Columns[1].DataPropertyName = "Sifre";
                    dataGridView1.DataSource = dtable;
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ogrencigirisi ogrencigirisi = new Ogrencigirisi();
            this.Hide();
            ogrencigirisi.Show();
        }

        private void Kayıtekrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
