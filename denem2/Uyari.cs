using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denem2
{
    public partial class Uyari : Form
    {
        private AlltagClass aa;
        private ALLAlarmListClass bb;
        public static string temakonum = Application.StartupPath.ToString();
        public static int temakod;


        public Uyari()
        {
            InitializeComponent();
            GoFullscreen(true);
            aa = new AlltagClass();
            bb = new ALLAlarmListClass();
            
        }
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            this.Hide();
            Ekranlar.MainForm.Show();
        }

        private void Uyari_Load(object sender, EventArgs e)
        {

            //File.Delete(temakonum + "\\" + "ip" + ".txt");

            string [] tema = System.IO.File.ReadAllLines(temakonum + "\\" + "tema" + ".txt");
            temakod = Convert.ToInt32(tema[0]);
            renk_degistir();

            

        }
        public static void renk_degistir()
        {
            if (temakod == 0)//açık
            {
               
                Sistem.logocolor = Color.RoyalBlue;
                Sistem.altbuttonColors = Color.DeepSkyBlue;
                Sistem.PanelsColor = Color.LightSkyBlue;
                Sistem.AlarmbuttonColor = Color.SteelBlue;
                Sistem.ustbuttoncolor = Color.SteelBlue;
                Sistem.formbackgroundColor = Color.LightSteelBlue;
            }
            else if (temakod == 1)//sarı
            {
                Sistem.logocolor = Color.Orange;
                Sistem.altbuttonColors = Color.Khaki;
                Sistem.PanelsColor = Color.PaleGoldenrod;
                Sistem.AlarmbuttonColor = Color.DarkKhaki;
                Sistem.ustbuttoncolor = Color.DarkKhaki;
                Sistem.formbackgroundColor = Color.LemonChiffon;
            }
            else//koyu
            {

            }
        }
    }
}
