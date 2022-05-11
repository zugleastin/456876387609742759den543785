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
    public partial class Eksikgiderme : Form
    {
        public Eksikgiderme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id1, c1;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
            conn.Open();
            string query = "SELECT * FROM TblSoru WHERE SId='" + textBox2.Text + "' AND KId='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id1 = dr["SId"].ToString();
                Eksikgidermesorusu.Text = dr["Ssoru"].ToString();
                eksiksorucevap1.Text = dr["Scevap1"].ToString();
                eksiksorucevap2.Text = dr["Scevap2"].ToString();
                eksiksorucevap3.Text = dr["Scevap3"].ToString();
                eksiksorucevap4.Text = dr["Scevap4"].ToString();
                c1 = dr["Scevap"].ToString();
                conn.Close();
            }
        }


        private void Eksikgiderme_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}