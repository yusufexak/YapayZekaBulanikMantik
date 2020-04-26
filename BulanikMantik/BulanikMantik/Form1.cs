using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulanikMantik
{
    public partial class Form1 : Form
    {
        BulanikMantik bm = new BulanikMantik();
        List<Kural> kurallar = new List<Kural>();
        List<Kural> aralikdegerlendirme = new List<Kural>();
        List<double> mandani =new  List<double>();
        double[] max_bul = new double[3];
 
        public Form1()
        {
            InitializeComponent();

            kurallar = bm.liste();

            tabloyu_doldur(listView1);
        }
        public void ekle(ListView l)
        {
            l.Columns.Clear();
            l.Columns.Add("No", (int)(30),HorizontalAlignment.Center);
            l.Columns.Add("Hassaslık", (int)(100), HorizontalAlignment.Center);
            l.Columns.Add("Miktar", (int)(100), HorizontalAlignment.Center);
            l.Columns.Add("Kirlilik", (int)(100), HorizontalAlignment.Center);
            l.Columns.Add("DönüşHızı", (int)(100), HorizontalAlignment.Center);
            l.Columns.Add("Süre", (int)(100), HorizontalAlignment.Center);
            l.Columns.Add("Deterjan", (int)(100), HorizontalAlignment.Center);
            l.View = View.Details;
        }
        public void tabloyu_doldur(ListView l)
        {
            ekle(l);
            for (int i = 0; i < 27; i++)
            {
                ListViewItem row = new ListViewItem((i + 1).ToString());  
                row.SubItems.Add(kurallar[i].hassaslik);
                row.SubItems.Add(kurallar[i].miktar);
                row.SubItems.Add(kurallar[i].kirlilik);
                row.SubItems.Add(kurallar[i].donus_hizi);
                row.SubItems.Add(kurallar[i].sure);
                row.SubItems.Add(kurallar[i].deterjan);
                l.Items.Add(row);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double hassaslikTrackBar = (Convert.ToDouble(trackBar1.Value) / 10);
            numericUpDown1.Value = Convert.ToDecimal(hassaslikTrackBar);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double hassaslikNUD =(double)numericUpDown1.Value * 10;
            trackBar1.Value =(int) hassaslikNUD;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            double miktarTrackBar = (Convert.ToDouble(trackBar2.Value) / 10);
            numericUpDown2.Value = Convert.ToDecimal(miktarTrackBar);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double miktarNUD = (double)numericUpDown2.Value * 10;
            trackBar2.Value = (int)miktarNUD;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double kirlilikTrackBar = (Convert.ToDouble(trackBar3.Value) / 10);
            numericUpDown3.Value = Convert.ToDecimal(kirlilikTrackBar);
      

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double kirlilikNUD = (double)numericUpDown3.Value * 10;
            trackBar3.Value = (int)kirlilikNUD;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            aralikdegerlendirme.Clear();
            mandani.Clear();
            
            aralikdegerlendirme = bm.aralikdegerlendirme(
                (Convert.ToDouble(trackBar1.Value) / 10), 
                (Convert.ToDouble(trackBar2.Value) / 10),
                (Convert.ToDouble(trackBar3.Value) / 10));
            mandani = bm.mandani();
            max_bul = bm.max_bul();

            lbD.Text = max_bul[0].ToString();
            lbDH.Text = max_bul[1].ToString();
            lbS.Text = max_bul[2].ToString();

            foreach (var item in mandani)
            {
                listBox1.Items.Add(item);
            }
            for (int i = 0; i < kurallar.Count; i++)
            {
                listView1.Items[i].BackColor = Color.White;
                listView1.Items[i].ForeColor = Color.Black;
            }

            for (int i = 0; i < kurallar.Count; i++)
            {
                for (int j = 0; j < aralikdegerlendirme.Count; j++)
                {
                    if (kurallar[i].hassaslik == aralikdegerlendirme[j].hassaslik&& kurallar[i].miktar == aralikdegerlendirme[j].miktar && kurallar[i].kirlilik == aralikdegerlendirme[j].kirlilik)
                    {
                        listView1.Items[i].BackColor = Color.Blue;
                        listView1.Items[i].ForeColor = Color.White;
                    }
                }
            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
