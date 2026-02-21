using System;
using Sharp7;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Microsoft.VisualBasic;

namespace denem2
{
    public partial class Recete_Giris : Form
    {

        public static string receteisim = "";
        public static int recetekonum = 0;


        public Recete_Giris()
        {
            InitializeComponent();



        }

        private void recetegiris_Load(object sender, EventArgs e)
        {



        }

        private void recetegiris_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (recetekonum == 1)
            {
                receteisim = textBox1.Text;
                string mksrkonum = Application.StartupPath.ToString();
                System.IO.StreamWriter notDefteri = File.AppendText(mksrkonum + "\\MikserRecete\\" + receteisim + ".txt");
                notDefteri.Close();

            }

            if (recetekonum == 2)
            {
                receteisim = textBox1.Text;
                string mksrkonum = Application.StartupPath.ToString();
                System.IO.StreamWriter notDefteri = File.AppendText(mksrkonum + "\\ToplamaRecete\\" + receteisim + ".txt");
                notDefteri.Close();

            }
            if (recetekonum == 3)
            {
                receteisim = textBox1.Text;
                string mksrkonum = Application.StartupPath.ToString();
                System.IO.StreamWriter notDefteri = File.AppendText(mksrkonum + "\\CatalRecete\\" + receteisim + ".txt");
                notDefteri.Close();

            }



            this.Close();
            textBox1.Text = "";
        }

    }
}
