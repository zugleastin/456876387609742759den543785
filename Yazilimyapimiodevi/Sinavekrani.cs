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
    public partial class Sinavekrani : Form
    {
        int zaman;
        
        public Sinavekrani()
        {
            InitializeComponent();
            soruyap1();
            soruyap2();
            soruyap3();
            soruyap4();
            soruyap5();
            soruyap6();
            soruyap7();
            soruyap8();
            soruyap9();
            soruyap10();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deniz\Documents\quizdatabase.mdf;Integrated Security=True;Connect Timeout=30");
        string id1, id2, id3, id4, id5, id6, id7, id8, id9, id10;
        string c1, c2, c3, c4, c5, c6, c7, c8, c9, c10;
        
        private void soruyap1()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='1' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'"+AyarlarEkrani.ikincicozumicin+"' AND TSE.OgrenciId='"+Ogrencigirisi.idtutucu+ "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='1'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                id1 = dr["SId"].ToString();
                S1.Text = dr["Ssoru"].ToString();
                S1cevap1.Text = dr["Scevap1"].ToString();
                S1cevap2.Text = dr["Scevap2"].ToString();
                S1cevap3.Text = dr["Scevap3"].ToString();
                S1cevap4.Text = dr["Scevap4"].ToString();
                c1 = dr["Scevap"].ToString();
                conn.Close();
            }

        }
        private void soruyap2()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='1' AND SId<>'"+id1+"' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'"+AyarlarEkrani.ikincicozumicin+"' AND TSE.OgrenciId='"+Ogrencigirisi.idtutucu+ "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='1' AND SId<>'" + id1 + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id2 = dr["SId"].ToString();
                S2.Text = dr["Ssoru"].ToString();
                S2cevap1.Text = dr["Scevap1"].ToString();
                S2cevap2.Text = dr["Scevap2"].ToString();
                S2cevap3.Text = dr["Scevap3"].ToString();
                S2cevap4.Text = dr["Scevap4"].ToString();
                c2 = dr["Scevap"].ToString();
                conn.Close ();
            }

        }
        private void soruyap3()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='2' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ikincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='2'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id3 = dr["SId"].ToString();
                S3.Text = dr["Ssoru"].ToString();
                S3cevap1.Text = dr["Scevap1"].ToString();
                S3cevap2.Text = dr["Scevap2"].ToString();
                S3cevap3.Text = dr["Scevap3"].ToString();
                S3cevap4.Text = dr["Scevap4"].ToString();
                c3 = dr["Scevap"].ToString();
                conn.Close();
            }

        }
        private void soruyap4()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='2' AND SId<>'"+id3+"' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ikincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='2' AND SId<>'" + id3 + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id4 = dr["SId"].ToString();
                S4.Text = dr["Ssoru"].ToString();
                S4cevap1.Text = dr["Scevap1"].ToString();
                S4cevap2.Text = dr["Scevap2"].ToString();
                S4cevap3.Text = dr["Scevap3"].ToString();
                S4cevap4.Text = dr["Scevap4"].ToString();
                c4 = dr["Scevap"].ToString();
                conn.Close();
            }

        }
        private void soruyap5()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='3' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ikincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='3'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id5 = dr["SId"].ToString();
                S5.Text = dr["Ssoru"].ToString();
                S5cevap1.Text = dr["Scevap1"].ToString();
                S5cevap2.Text = dr["Scevap2"].ToString();
                S5cevap3.Text = dr["Scevap3"].ToString();
                S5cevap4.Text = dr["Scevap4"].ToString();
                c5 = dr["Scevap"].ToString();
                conn.Close();
            }

        }
        private void soruyap6()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='3' AND SId<>'" + id5 + "' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ikincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='3' AND SId<>'" + id5 + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id6 = dr["SId"].ToString();
                S6.Text = dr["Ssoru"].ToString();
                S6cevap1.Text = dr["Scevap1"].ToString();
                S6cevap2.Text = dr["Scevap2"].ToString();
                S6cevap3.Text = dr["Scevap3"].ToString();
                S6cevap4.Text = dr["Scevap4"].ToString();
                c6 = dr["Scevap"].ToString();
                conn.Close ();
            }

        }
        private void soruyap7()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='4' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ikincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='4'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id7 = dr["SId"].ToString();
                S7.Text = dr["Ssoru"].ToString();
                S7cevap1.Text = dr["Scevap1"].ToString();
                S7cevap2.Text = dr["Scevap2"].ToString();
                S7cevap3.Text = dr["Scevap3"].ToString();
                S7cevap4.Text = dr["Scevap4"].ToString();
                c7 = dr["Scevap"].ToString();
                conn.Close();
            }

        }
        private void soruyap8()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='4' AND SId<>'" + id7 + "' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ikincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='4' AND SId<>'" + id7 + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id8 = dr["SId"].ToString();
                S8.Text = dr["Ssoru"].ToString();
                S8cevap1.Text = dr["Scevap1"].ToString();
                S8cevap2.Text = dr["Scevap2"].ToString();
                S8cevap3.Text = dr["Scevap3"].ToString();
                S8cevap4.Text = dr["Scevap4"].ToString();
                c8 = dr["Scevap"].ToString();
                conn.Close();
            }

        }
        private void soruyap9()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='5' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ikincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='5'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id9 = dr["SId"].ToString();
                S9.Text = dr["Ssoru"].ToString();
                S9cevap1.Text = dr["Scevap1"].ToString();
                S9cevap2.Text = dr["Scevap2"].ToString();
                S9cevap3.Text = dr["Scevap3"].ToString();
                S9cevap4.Text = dr["Scevap4"].ToString();
                c9 = dr["Scevap"].ToString();
                conn.Close();
            }

        }
        private void soruyap10()
        {
            conn.Open();
            string query = "SELECT * FROM TblSoru TS WHERE NOT EXISTS(SELECT SId FROM TblSinavekrani TSE WHERE TS.SId=TSE.SId) AND KId='5' AND SId<>'" + id9 + "' OR (EXISTS(SELECT OgrenciId,SId,Scozulmesayisi,Scozulmezamani,DATEDIFF(minute,Scozulmezamani,GETDATE()) FROM TblSinavekrani TSE WHERE (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ikincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=1) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.ucuncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=2) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.dorduncucozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=3) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.besincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=4) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.altincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=5) OR (TS.SId=TSE.SId AND DATEDIFF(minute,Scozulmezamani,GETDATE())>'" + AyarlarEkrani.yedincicozumicin + "' AND TSE.OgrenciId='" + Ogrencigirisi.idtutucu + "' AND TSE.Scozulmesayisi=6)))AND KId='5' AND SId<>'" + id9 + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                id10 = dr["SId"].ToString();
                S10.Text = dr["Ssoru"].ToString();
                S10cevap1.Text = dr["Scevap1"].ToString();
                S10cevap2.Text = dr["Scevap2"].ToString();
                S10cevap3.Text = dr["Scevap3"].ToString();
                S10cevap4.Text = dr["Scevap4"].ToString();
                c10 = dr["Scevap"].ToString();
                conn.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((c1==S1cevap1.Text)&&(S1cevap1.Checked))
            {   
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('"+Ogrencigirisi.idtutucu+"','"+id1+"')",conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query =  new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='"+Ogrencigirisi.idtutucu+"' AND SId='"+id1+"'",conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id1 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c1==S1cevap2.Text)&&(S1cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id1 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id1 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='"+Ogrencigirisi.idtutucu+"' AND SId='"+id1+"'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c1 == S1cevap3.Text) && (S1cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id1 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id1 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id1 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c1 == S1cevap4.Text) && (S1cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id1 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id1 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id1 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c2 == S2cevap1.Text) && (S2cevap1.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id2 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id2 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id2 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c2 == S2cevap2.Text) && (S2cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id2 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id2 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='"+Ogrencigirisi.idtutucu+"' AND SId='"+id2+"'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c2 == S2cevap3.Text) && (S2cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id2 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id2 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id2 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c2 == S2cevap4.Text) && (S2cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id2 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id2 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id2 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c3 == S3cevap1.Text) && (S3cevap1.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id3 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id3 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id3 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c3 == S3cevap2.Text) && (S3cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id3 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id3 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id3 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c3 == S3cevap3.Text) && (S3cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id3 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id3 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id3 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c3 == S3cevap4.Text) && (S3cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id3 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id3 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id3 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c4 == S4cevap1.Text) && (S4cevap1.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id4 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id4 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id4 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c4 == S4cevap2.Text) && (S4cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id4 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id4 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id4 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c4 == S4cevap3.Text) && (S4cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id4 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id4 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id4 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c4 == S4cevap4.Text) && (S4cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id4 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id4 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id4 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c5 == S5cevap1.Text) && (S5cevap1.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id5 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id5 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id5 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c5 == S5cevap2.Text) && (S5cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id5 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id5 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id5 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c5 == S5cevap3.Text) && (S5cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id5 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id5 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id5 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c5 == S5cevap4.Text) && (S5cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id5 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id5 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id5 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c6 == S6cevap1.Text) && (S6cevap1.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id6 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id6 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id6 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c6 == S6cevap2.Text) && (S6cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id6 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id6 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id6 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c6 == S6cevap3.Text) && (S6cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id6 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id6 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id6 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c6 == S6cevap4.Text) && (S6cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id6 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id6 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id6 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c7 == S7cevap1.Text) && (S7cevap1.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id7 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id7 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id7 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c7 == S7cevap2.Text) && (S7cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id7 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id7 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id7 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c7 == S7cevap3.Text) && (S7cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id7 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id7 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id7 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c7 == S7cevap4.Text) && (S7cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id7 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id7 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id7 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c8 == S8cevap1.Text) && (S8cevap1.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id8 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id8 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id8 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c8 == S8cevap2.Text) && (S8cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id8 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id8 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id8 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c8 == S8cevap3.Text) && (S8cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id8 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id8 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id8 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c8 == S8cevap4.Text) && (S8cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id8 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id8 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id8 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c9 == S9cevap1.Text) && (S9cevap1.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id9 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id9 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id9 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c9 == S9cevap2.Text) && (S9cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id9 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id9 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id9 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c9 == S9cevap3.Text) && (S9cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id9 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id9 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id9 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c9 == S9cevap4.Text) && (S9cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id9 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id9 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id9 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c10 == S10cevap1.Text) && (S10cevap1.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id10 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id10 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id10 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c10 == S10cevap2.Text) && (S10cevap2.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id10 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id10 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id10 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c10 == S10cevap3.Text) && (S10cevap3.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id10 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id10 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id10 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            if ((c10 == S10cevap4.Text) && (S10cevap4.Checked))
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TblSinavekrani (OgrenciId,SId) VALUES('" + Ogrencigirisi.idtutucu + "','" + id10 + "')", conn);
                sqlCommand.ExecuteNonQuery();
                SqlCommand query = new SqlCommand("UPDATE TblSinavekrani SET Scozulmesayisi=ISNULL(Scozulmesayisi, 0) +1,Scozulmezamani=GETDATE() WHERE OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id10 + "'", conn);
                query.ExecuteNonQuery();
                SqlCommand query2 = new SqlCommand("DELETE FROM TblSinavekrani WHERE Scozulmesayisi<>(SELECT MAX(Scozulmesayisi) FROM TblSinavekrani) AND OgrenciId='" + Ogrencigirisi.idtutucu + "' AND SId='" + id10 + "'", conn);
                query2.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Cevaplarinizi analiz ekraninda görebilirsiniz.");
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = (zaman--).ToString();
            if(zaman == -1)
            {
                timer1.Stop();
                MessageBox.Show("Sureniz bitmistir");
                this.Close();
                OgrenciEkrani ogrenciEkrani = new OgrenciEkrani();
                ogrenciEkrani.Show();
            }
        }

        private void Sinavekrani_Load(object sender, EventArgs e)
        {
            
            if (int.TryParse(label3.Text, out zaman))
            {
                timer1.Start();
            }
            
            
        }

        private void Sinavekrani_FormClosed(object sender, FormClosedEventArgs e)
        {
          Environment.Exit(0);
            Application.Exit();
        }
    }
}
