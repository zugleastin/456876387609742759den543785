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
    public partial class Sifremiunuttum : Form
    {
        public Sifremiunuttum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Lutfen bos alan birakmayiniz.");
            }
            if (!(textBox1.Text == "") && !(textBox2.Text == ""))
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM TblOgrenci WHERE OgrenciId = '" + textBox1.Text.ToString() + "' AND Email = '" + textBox2.Text.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count == 1)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.ColumnCount = 1;
                    dataGridView1.Columns[0].HeaderText = "Sifreniz";
                    dataGridView1.Columns[0].DataPropertyName = "Sifre";
                    dataGridView1.DataSource = dtable;
                    conn.Close();
                }
            }
        }
    }
}
