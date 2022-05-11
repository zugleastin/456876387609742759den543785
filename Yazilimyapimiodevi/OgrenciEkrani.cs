using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazilimyapimiodevi
{
    public partial class OgrenciEkrani : Form
    {
        AyarlarEkrani ayarlar = new AyarlarEkrani();
        public OgrenciEkrani()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sinavekrani sinavekrani = new Sinavekrani();
            this.Hide();
            sinavekrani.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eksikgiderme eksikgiderme = new Eksikgiderme();
            this.Hide();
            eksikgiderme.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Analiz analiz = new Analiz();
            analiz.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ayarlar.Show();
            this.Hide();
            
        }

        private void OgrenciEkrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
