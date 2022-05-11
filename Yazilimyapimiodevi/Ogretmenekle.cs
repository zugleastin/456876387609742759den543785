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
    public partial class Ogretmenekle : Form
    {
        public Ogretmenekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Lutfen bos yer birakmayiniz.");
            }

            if (!(textBox1.Text == "") && !(textBox2.Text == "") && !(textBox3.Text == "") && !(textBox4.Text == ""))
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TblOgretmen (OgretmenAd,OgretmenSoyad,OgretmenEmail,OgretmenSifre) values(@OA,@OS,@OE,@OSi)", conn);
                cmd.Parameters.AddWithValue("@OA", textBox2.Text);
                cmd.Parameters.AddWithValue("@OS", textBox3.Text);
                cmd.Parameters.AddWithValue("@OE", textBox1.Text);
                cmd.Parameters.AddWithValue("@OSi", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt yapilmistir.");
                string sqlCommand = "SELECT * FROM TblOgretmen WHERE OgretmenEmail ='" + textBox1.Text + "'AND OgretmenSifre ='" + textBox4.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count == 1)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.ColumnCount = 2;
                    dataGridView1.Columns[0].HeaderText = "OgretmenId";
                    dataGridView1.Columns[0].DataPropertyName = "OgretmenId";
                    dataGridView1.Columns[1].HeaderText = "Sifresi";
                    dataGridView1.Columns[1].DataPropertyName = "OgretmenSifre";
                    dataGridView1.DataSource = dtable;
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sinavsorumlusugirisi sinavsorumgirisi = new Sinavsorumlusugirisi();
            this.Hide();
            sinavsorumgirisi.Show();
        }

        private void Ogretmenekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
