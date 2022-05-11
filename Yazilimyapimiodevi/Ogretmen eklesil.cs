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
    public partial class Ogretmen_eklesil : Form
    {
        public Ogretmen_eklesil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lutfen silmek istediginiz ogretmenin numarasini giriniz");
            }
            if (!(textBox1.Text == ""))
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
                conn.Open();
                string sqlCommand = "SELECT * FROM TblOgretmen WHERE OgretmenId = '" +textBox1.Text+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand,conn);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                if(datatable.Rows.Count == 1)
                {
                    SqlCommand cmd = new SqlCommand(@"DELETE FROM TblOgretmen WHERE OgretmenId ='" + textBox1.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ogretmen silindi.");
                }
                conn.Close();
            }
        }

        private void Ogretmen_eklesil_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
