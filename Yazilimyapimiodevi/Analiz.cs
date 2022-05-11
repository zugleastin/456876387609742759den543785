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
    public partial class Analiz : Form
    {
        public Analiz()
        {
            InitializeComponent();
        }

        private void Analiz_Load(object sender, EventArgs e)
        {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT * FROM TblSinavekrani WHERE OgrenciId = '" + Ogrencigirisi.idtutucu + "' AND SId IS NOT NULL ORDER BY SId ASC";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0 )
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.ColumnCount = 3;
                    dataGridView1.Columns[0].HeaderText = "Soru";
                    dataGridView1.Columns[0].DataPropertyName = "SId";
                    dataGridView1.Columns[1].HeaderText = "Cozulme sayisi";
                    dataGridView1.Columns[1].DataPropertyName = "Scozulmesayisi";
                    dataGridView1.Columns[2].HeaderText = "Cozulme zamani";
                    dataGridView1.Columns[2].DataPropertyName = "Scozulmezamani";
                    dataGridView1.DataSource = dtable;
                    conn.Close();
                }
                
        }

        private void Analiz_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
        Bitmap bmp;
        private void button1_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
