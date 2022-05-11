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
    public partial class Adminmenu : Form
    {
        public Adminmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciSil ogrenciSil = new OgrenciSil();
            this.Hide();
            ogrenciSil.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ogretmenekle ogretmenekle = new Ogretmenekle();
            this.Hide();
            ogretmenekle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ogretmen_eklesil ogretmen= new Ogretmen_eklesil();
            this.Hide();
            ogretmen.Show();
        }

        private void Adminmenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
