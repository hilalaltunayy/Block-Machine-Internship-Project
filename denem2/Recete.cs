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
    public partial class Recete : Form
    {
        Form recetegrs = new Recete_Giris();
        private S7Client Client;
        private int Result;

        string[] mksroku = new string[25];
        int[] mikserrct = new int[25];

        string[] dizi1 = new string[20];
        string[] topoku = new string[400];
        string[] mksrplcyazdizi = new string[500];
        string[] topplcyazdizi = new string[400];
        string[] Catalplcyazdizi = new string[400];

        string toprctkonum;
        string topreceteisim;
        int mikserrecetesayı;
        int toprecetesayı;
        int catalrecetesayı;

        string[] catalplcoku = new string[700];
        string secilenreceteglobal;
        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBPaketleme = new byte[600];
        private byte[] DBMikser = new byte[600];
        private byte[] timer112DB = new byte[36];
        private byte[] Db9 = new byte[200];
        private byte[] DBEkran8 = new byte[300];
        private byte[] DBCatal = new byte[600];
        private byte[] timer113DB = new byte[36];
        private byte[] DB8 = new byte[600];
        private byte[] DB7 = new byte[350];

        private byte[] DBKalip = new byte[600];
        private byte[] DB100 = new byte[600];

        public Recete()
        {
            InitializeComponent();
            GoFullscreen(true);
            CustumizeDesign();
           

        }

        private void CPUbaglan()
        {
            try
            {
                Client = new S7Client();
                Client.SendTimeout = 300;
                Client.ConnTimeout = 300;
                Client.RecvTimeout = 300;
                Result = Client.ConnectTo("192.168.0.2", 0, 0);
                ShowResult(Result);
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowResult(Result);
            }

        }
        private void CustumizeDesign()
        {
            panelUretim.Visible = false;
            panelPaketleme.Visible = false;
            panelMikser.Visible = false;
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
        private void ShowResult(int Result)
        {
            // This function returns a textual explaination of the error code
            hata.Text = Client.ErrorText(Result);
            if (Result == 0)
            {
                btnconnectionStatus.BackColor = Color.Green;
            }
            else
            {
                btnconnectionStatus.BackColor = Color.Blue;

            }

        }
        private void hideSubMenu()
        {
            if (panelUretim.Visible == true)
                panelUretim.Visible = false;
            if (panelPaketleme.Visible == true)
                panelPaketleme.Visible = false;
            if (panelMikser.Visible == true)
                panelMikser.Visible = false;


        }
        private void showSubMenu(Panel Subpanel)
        {
            if (Subpanel.Visible == false)
            {
                hideSubMenu();
                Subpanel.Visible = true;
            }
            else
            {
                Subpanel.Visible = false;
            }

        }
        private void btnUretim(object sender, EventArgs e)
        {
            if (panelUretim.Visible == false)
            {
                showSubMenu(panelUretim);
            }
            else
            {

                timer1.Enabled = false;
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                if (Client.Connected)
                    Client.Disconnect();
                Ekranlar.GoMainForm(this);
                //Ekranlar.UstkalipScreen.Hide();

            }
        }

        private void btnTopParam(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            timer1.Enabled = false;
            Ekranlar.OpenToplamaParamScreen(this);
        }

        private void btnUstKalip(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (Client.Connected)
                Client.Disconnect();

            Ekranlar.OpenUstKalipScreen(this);
            //Ekranlar.UstkalipScreen.Show();

        }

        private void btnAltKalip(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (Client.Connected)
                Client.Disconnect();

            Ekranlar.OpenAltKalipScreen(this);
            //Ekranlar.AltKalipScreen.Show();


        }

        private void btnHarcTeknesi(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            timer1.Enabled = false;

            Ekranlar.OpenHarcTeknesiScreen(this);


        }

        private void btnPalet1Fonk(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            timer1.Enabled = false;
            Ekranlar.OpenPalet1Screen(this);
            //Ekranlar.Palet1Screen.Show();

            // this.Hide();
            //this.Close();

        }

        private void btnIticiParam(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            timer1.Enabled = false;
            Ekranlar.OpenIticiParamScreen(this);

        }

        private void btnCatalParam(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();

            if (Client.Connected)
                Client.Disconnect();
            timer1.Enabled = false;
            Ekranlar.OpenCatalAcmaParamScreen(this);

        }

        private void btnTopYuk_Asg(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            timer1.Enabled = false;
            Ekranlar.OpenToplamaYukAsgScreen(this);

        }

        private void btnPaketleme(object sender, EventArgs e)
        {


            showSubMenu(panelPaketleme);

        }

        private void btnMikser(object sender, EventArgs e)
        {

            if (panelMikser.Visible == false)
            {
                showSubMenu(panelMikser);
            }
            else
            {
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                timer1.Enabled = false;
                if (Client.Connected)
                    Client.Disconnect();

                Ekranlar.OpenMikserScreen(this);

            }
        }

        private void btnMikserParam(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenMikserParamScreen(this);

        }
        private void btnHidrolik(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenHidrolikScreen(this);

        }
        private void btnVibrasyon(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (Client.Connected)
                Client.Disconnect();

            Ekranlar.OpenVibrasyonScreen(this);

        }
        private void btnSystem(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenSistemScreen(this);

        }
        private void btnGrafik(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenGrafikScreen(this);

        }
        private void btnRecete(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            timer1.Enabled = false;
            Ekranlar.OpenReceteScreen(this);

        }
        private void btnAlarm(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();

            timer1.Enabled = false;
            Ekranlar.OpenAlarmScreen(this);

        }
        private void btnPalet3fonk(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();

            timer1.Enabled = false;
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenPalet3Screen(this);

        }
        private void BTNvardiya(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenVardiyaScreen(this);

        }
        private int writePLC(PLCTag gelentag, bool boolvalue, int othersvalue, string stringvalue)
        {

            if (gelentag.Area == "M")
            {
                if (gelentag.Tip == "bool")
                {
                    byte[] bytearray = new byte[1];
                    S7.SetBitAt(ref bytearray, 0, gelentag.BitNo, boolvalue);
                    bool a = S7.GetBitAt(bytearray, 0, gelentag.BitNo);
                    Debug.WriteLine("gelen tag offset :" + gelentag.Offset.ToString());
                    Debug.WriteLine("Test bit yazma :" + a.ToString());
                    Result = Client.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, (gelentag.Offset * 8) + gelentag.BitNo, 1, S7Consts.S7WLBit, bytearray);

                    return Result;
                }
                else if (gelentag.Tip == "int")
                {
                    byte[] realArray = new byte[2];

                    int val = Convert.ToInt16(othersvalue);
                    realArray = BitConverter.GetBytes(Convert.ToInt16(val));
                    Array.Reverse(realArray);
                    byte[] aa = realArray;

                    Result = Client.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, aa);
                    return Result;
                }
                else if (gelentag.Tip == "real")
                {
                    byte[] realArray = new byte[4];
                    int val = Convert.ToInt32(othersvalue);
                    realArray = BitConverter.GetBytes(val);
                    Result = Client.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLReal, realArray);
                    return Result;
                }
                else
                {
                    Debug.WriteLine("Test bit yazma :");
                    return 0;
                }
            }
            else if (gelentag.Area == "DB")
            {
                if (gelentag.Tip == "bool")
                {
                    byte[] bytearray = new byte[1];
                    S7.SetBitAt(ref bytearray, 0, gelentag.BitNo, boolvalue);
                    bool a = S7.GetBitAt(bytearray, 0, gelentag.BitNo);
                    Debug.WriteLine("gelen tag offset :" + gelentag.Offset.ToString());
                    Debug.WriteLine("Test bit yazma :" + a.ToString());
                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, (gelentag.Offset * 8) + gelentag.BitNo, 1, S7Consts.S7WLBit, bytearray);

                    return Result;
                }
                else if (gelentag.Tip == "int")
                {
                    byte[] realArray = new byte[2];

                    int val = Convert.ToInt16(othersvalue);
                    realArray = BitConverter.GetBytes(Convert.ToInt16(val));
                    Array.Reverse(realArray);
                    byte[] aa = realArray;

                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, aa);
                    return Result;
                }
                else if (gelentag.Tip == "dint")
                {
                    byte[] realArray = new byte[4];
                    Int32 val = Convert.ToInt32(othersvalue);
                    S7.SetDIntAt(realArray, 0, othersvalue);
                    //    realArray = BitConverter.GetBytes(val);
                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDInt, realArray);
                    return Result;
                }
                else if (gelentag.Tip == "real")
                {
                    byte[] realArray = new byte[4];
                    int val = Convert.ToInt32(othersvalue);
                    realArray = BitConverter.GetBytes(val);
                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLReal, realArray);
                    return Result;
                }
                else if (gelentag.Tip == "dword")
                {
                    byte[] realArray = new byte[4];
                    int val = Convert.ToInt32(othersvalue);
                    S7.SetDWordAt(realArray, 0, Convert.ToUInt32(othersvalue));

                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDWord, realArray);
                    return Result;
                }
                else if (gelentag.Tip == "byte")
                {
                    byte[] realArray = new byte[28];
                    // int val = Convert.ToInt32(othersvalue);

                    S7.SetStringAt(realArray, 0, 28, stringvalue);
                    // S7.SetDWordAt(realArray, 0, Convert.ToUInt32(othersvalue));

                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 28, S7Consts.S7WLByte, realArray);
                    return Result;
                }
                else
                {
                    Debug.WriteLine("Test bit yazma :");
                    return 0;
                }
            }
            else
            {
                Debug.WriteLine("Test bit yazma :error");
                return 0;
            }

        }

        protected string read_Tag(PLCTag gelentag)
        {
            if (gelentag.Area == "M")
            {
                if (gelentag.Tip == "bool")
                {
                    byte[] bytearray = new byte[1];

                    Result = Client.ReadArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLBit, bytearray);

                    return bytearray[gelentag.BitNo].ToString();
                }
                else if (gelentag.Tip == "int")
                {
                    byte[] realArray = new byte[2];


                    Result = Client.ReadArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, realArray);

                    return S7.GetIntAt(realArray, 0).ToString();
                }
                else if (gelentag.Tip == "real")
                {
                    byte[] realArray = new byte[4];

                    Result = Client.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLReal, realArray);
                    return S7.GetRealAt(realArray, 0).ToString();
                }
                else
                {

                    return 0.ToString();
                }
            }
            else if (gelentag.Area == "DB")
            {
                if (gelentag.Tip == "bool")
                {
                    byte[] bytearray = new byte[1];

                    Result = Client.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLByte, bytearray);
                    Debug.WriteLine("DİZİİİİİ " + S7.GetBitAt(bytearray, 0, gelentag.BitNo).ToString());

                    return S7.GetBitAt(bytearray, 0, gelentag.BitNo).ToString();
                }
                else if (gelentag.Tip == "int")
                {
                    byte[] realArray = new byte[2];


                    Result = Client.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, realArray);

                    return S7.GetIntAt(realArray, 0).ToString();
                }
                else if (gelentag.Tip == "real")
                {
                    byte[] realArray = new byte[4];

                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLReal, realArray);
                    return S7.GetRealAt(realArray, 0).ToString();
                }

                else if (gelentag.Tip == "dint")
                {
                    byte[] realArray = new byte[4];


                    Result = Client.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDInt, realArray);

                    return S7.GetDIntAt(realArray, 0).ToString();
                }
                else if (gelentag.Tip == "dword")
                {
                    byte[] realArray = new byte[4];


                    Result = Client.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDWord, realArray);

                    return S7.GetDWordAt(realArray, 0).ToString();
                }


                else
                {

                    return 0.ToString();
                }
            }
            else
            {
                Debug.WriteLine("Test bit oKUMA  :error");
                return 0.ToString();
            }
        }


        private void mksrynbtn_Click(object sender, EventArgs e)
        {


            Recete_Giris.recetekonum = 1;
            recetegrs.ShowDialog(this);



        }


        public void Mksryaz()
        {

            writePLC(AlltagClass.ALLTagList[174], false, Convert.ToInt32(mksrplcyazdizi[0]), "a");
            writePLC(AlltagClass.ALLTagList[176], false, Convert.ToInt32(mksrplcyazdizi[1]), "a");
            writePLC(AlltagClass.ALLTagList[177], false, Convert.ToInt32(mksrplcyazdizi[2]) * 1000, "a");
            writePLC(AlltagClass.ALLTagList[180], false, Convert.ToInt32(mksrplcyazdizi[3]), "a");
            writePLC(AlltagClass.ALLTagList[181], false, Convert.ToInt32(mksrplcyazdizi[4]), "a");
            writePLC(AlltagClass.ALLTagList[182], false, Convert.ToInt32(mksrplcyazdizi[5]), "a");
            writePLC(AlltagClass.ALLTagList[183], false, Convert.ToInt32(mksrplcyazdizi[6]), "a");
            writePLC(AlltagClass.ALLTagList[184], false, Convert.ToInt32(mksrplcyazdizi[7]), "a");
            writePLC(AlltagClass.ALLTagList[185], false, Convert.ToInt32(mksrplcyazdizi[8]), "a");
            writePLC(AlltagClass.ALLTagList[192], false, Convert.ToInt32(mksrplcyazdizi[9]), "a");
            writePLC(AlltagClass.ALLTagList[193], false, Convert.ToInt32(mksrplcyazdizi[10]), "a");
            writePLC(AlltagClass.ALLTagList[194], false, Convert.ToInt32(mksrplcyazdizi[11]), "a");
            writePLC(AlltagClass.ALLTagList[195], false, Convert.ToInt32(mksrplcyazdizi[12]), "a");
            writePLC(AlltagClass.ALLTagList[196], false, Convert.ToInt32(mksrplcyazdizi[13]), "a");
            writePLC(AlltagClass.ALLTagList[197], false, Convert.ToInt32(mksrplcyazdizi[14]), "a");
            writePLC(AlltagClass.ALLTagList[198], false, Convert.ToInt32(mksrplcyazdizi[15]), "a");
            writePLC(AlltagClass.ALLTagList[199], false, Convert.ToInt32(mksrplcyazdizi[16]), "a");
            writePLC(AlltagClass.ALLTagList[202], false, Convert.ToInt32(mksrplcyazdizi[17]), "a");
            writePLC(AlltagClass.ALLTagList[203], false, Convert.ToInt32(mksrplcyazdizi[18]), "a");
            writePLC(AlltagClass.ALLTagList[204], false, Convert.ToInt32(mksrplcyazdizi[19]), "a");


        }

        public void Mksrokuma()

        {

            Result = Client.ReadArea(S7Consts.S7AreaDB, 1, 0, 352, S7Consts.S7WLByte, DBMikser);




            mksroku[0] = read_Tag(AlltagClass.ALLTagList[174]).ToString();
            mksroku[1] = read_Tag(AlltagClass.ALLTagList[176]).ToString();
            mksroku[2] = read_Tag(AlltagClass.ALLTagList[177]).ToString();
            mksroku[3] = read_Tag(AlltagClass.ALLTagList[180]).ToString();
            mksroku[4] = read_Tag(AlltagClass.ALLTagList[181]).ToString();
            mksroku[5] = read_Tag(AlltagClass.ALLTagList[182]).ToString();
            mksroku[6] = read_Tag(AlltagClass.ALLTagList[183]).ToString();
            mksroku[7] = read_Tag(AlltagClass.ALLTagList[184]).ToString();
            mksroku[8] = read_Tag(AlltagClass.ALLTagList[185]).ToString();
            mksroku[9] = read_Tag(AlltagClass.ALLTagList[192]).ToString();
            mksroku[10] = read_Tag(AlltagClass.ALLTagList[193]).ToString();
            mksroku[11] = read_Tag(AlltagClass.ALLTagList[194]).ToString();
            mksroku[12] = read_Tag(AlltagClass.ALLTagList[195]).ToString();
            mksroku[13] = read_Tag(AlltagClass.ALLTagList[196]).ToString();
            mksroku[14] = read_Tag(AlltagClass.ALLTagList[197]).ToString();
            mksroku[15] = read_Tag(AlltagClass.ALLTagList[198]).ToString();
            mksroku[16] = read_Tag(AlltagClass.ALLTagList[199]).ToString();
            mksroku[17] = read_Tag(AlltagClass.ALLTagList[202]).ToString();
            mksroku[18] = read_Tag(AlltagClass.ALLTagList[203]).ToString();
            mksroku[19] = read_Tag(AlltagClass.ALLTagList[204]).ToString();



        }



        public void Topplcokuma()

        {
            Result = Client.ReadArea(S7Consts.S7AreaDB, 3, 0, 282, S7Consts.S7WLByte, DBPaketleme);

            for (int i = 207; i < 277; i++)
            {
                topoku[i] = read_Tag(AlltagClass.ALLTagList[i]).ToString();

            }

            for (int i = 278; i < 296; i++)
            {
                topoku[i] = read_Tag(AlltagClass.ALLTagList[i]).ToString();

            }
            topoku[297] = read_Tag(AlltagClass.ALLTagList[297]).ToString();

            for (int i = 299; i < 304; i++)
            {
                topoku[i] = read_Tag(AlltagClass.ALLTagList[i]).ToString();

            }

        }



        private void mksrplcparaykl_Click(object sender, EventArgs e)
        {
            byte[] mikserdnm = new byte[25];
            string secilenrecete = listBox1.GetItemText(listBox1.SelectedItem);

            S7.SetStringAt(mikserdnm, 0, 25, secilenrecete);
            Result = Client.WriteArea(S7Consts.S7AreaDB, 8, 24, 25, S7Consts.S7WLByte, mikserdnm);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mksroncebtn_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            if (index == 0)
            {
                listBox1.SetSelected(mikserrecetesayı - 1, true);
            }
            else
            {
                index--;
                listBox1.SetSelected(index, true);

            }

        }

        private void Recete_Load(object sender, EventArgs e)
        {
            CPUbaglan();
            string mksrkonum = Application.StartupPath.ToString();
            string[] mreçeteler = System.IO.Directory.GetFiles(mksrkonum + "\\MikserRecete"); // C:\\Windows dizinindeki dosyaları diziye çeker.

            string[] topreçeteler = System.IO.Directory.GetFiles(mksrkonum + "\\ToplamaRecete");

            string[] catalreceteler = System.IO.Directory.GetFiles(mksrkonum + "\\CatalRecete");

            for (int i = 0; i < mreçeteler.Length; i++)
            {
                dizi1[i] = mreçeteler[i].Remove(0, mksrkonum.Length + 14);
                dizi1[i] = dizi1[i].Replace(".txt", "");
                listBox1.Items.Add(dizi1[i]);               // Dosyaları listBox1'de göstermek istersek
            }

            for (int i = 0; i < topreçeteler.Length; i++)
            {
                dizi1[i] = topreçeteler[i].Remove(0, mksrkonum.Length + 15);
                dizi1[i] = dizi1[i].Replace(".txt", "");
                listBox3.Items.Add(dizi1[i]);               // Dosyaları listBox1'de göstermek istersek
            }
            for (int i = 0; i < catalreceteler.Length; i++)
            {
                dizi1[i] = catalreceteler[i].Remove(0, mksrkonum.Length + 13);
                dizi1[i] = dizi1[i].Replace(".txt", "");
                listBox4.Items.Add(dizi1[i]);               // Dosyaları listBox1'de göstermek istersek
            }



            toprctkonum = Application.StartupPath.ToString();


            listBox1.SetSelected(0, true);
            listBox3.SetSelected(0, true);
            listBox3.SetSelected(0, true);
            listBox4.SetSelected(0, true);
            mikserrecetesayı = listBox1.Items.Count;
            toprecetesayı = listBox3.Items.Count;
            catalrecetesayı = listBox4.Items.Count;
        }
        public void receteekleme()
        {
            string mksrkonum = Application.StartupPath.ToString();
            string[] dizi = System.IO.Directory.GetFiles(mksrkonum + "\\MikserRecete"); // C:\\Windows dizinindeki dosyaları diziye çeker.

            mksroncebtn.Text = (dizi[0].Length).ToString();

            mksrsnrabtn.Text = (mksrkonum.Length).ToString();


            for (int i = 0; i < dizi.Length; i++)
            {
                dizi1[i] = dizi[i].Remove(0, mksrkonum.Length + 14);
                dizi1[i] = dizi1[i].Replace(".txt", "");
                listBox1.Items.Add(dizi1[i]);
            }




        }

        private void prsynbtn_Click(object sender, EventArgs e)
        {

        }

        private void mksrsnrabtn_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            index++;
            if (index == mikserrecetesayı)
            {
                index = 0;
            }

            listBox1.SetSelected(index, true);
        }

        private void topynbtn_Click(object sender, EventArgs e)
        {
            Recete_Giris.recetekonum = 2;

            recetegrs.ShowDialog(this);



        }

        private void toprctsilbtn_Click(object sender, EventArgs e)
        {
            string secilenrecete = listBox3.GetItemText(listBox3.SelectedItem);

            File.Delete(toprctkonum + "\\ToplamaRecete\\" + secilenrecete + ".txt");
            listBox3.Items.Remove(secilenrecete);
            listBox3.SetSelected(0, true);

        }

        private void mksrrctsil_Click(object sender, EventArgs e)
        {
            string secilenrecete = listBox1.GetItemText(listBox1.SelectedItem);

            File.Delete(toprctkonum + "\\MikserRecete\\" + secilenrecete + ".txt");
            listBox1.Items.Remove(secilenrecete);
            listBox1.SetSelected(0, true);

        }

        private void topsnrabtn_Click(object sender, EventArgs e)
        {
            int index = listBox3.SelectedIndex;

            index++;
            if (index == toprecetesayı)
            {
                index = 0;
            }

            listBox3.SetSelected(index, true);
        }

        private void toponcebtn_Click(object sender, EventArgs e)
        {

        }

        private void topplcykle_Click(object sender, EventArgs e)
        {
            secilenreceteglobal = listBox3.GetItemText(listBox3.SelectedItem);
            if(!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();




        }
        private void toppckaydet_Click(object sender, EventArgs e)
        {
            Topplcokuma();
            string secilenrecete = listBox3.GetItemText(listBox3.SelectedItem);

            FileStream fs = new FileStream(toprctkonum + "\\ToplamaRecete" + "\\" + secilenrecete + ".txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            //  Mksrokuma();

            for (int i = 207; i < 277; i++)
            {
                sw.WriteLine(topoku[i]);

            }

            for (int i = 278; i < 296; i++)
            {
                sw.WriteLine(topoku[i]);

            }

            sw.WriteLine(topoku[297]);



            for (int i = 299; i < 304; i++)
            {
                sw.WriteLine(topoku[i]);

            }

            sw.Flush();
            sw.Close();
            fs.Close();
        }


        private void topplcparaykl_Click(object sender, EventArgs e)
        {
            byte[] toplama = new byte[25];
            string secilenrecete = listBox3.GetItemText(listBox3.SelectedItem);

            S7.SetStringAt(toplama, 0, 25, secilenrecete);
            Result = Client.WriteArea(S7Consts.S7AreaDB, 8, 84, 25, S7Consts.S7WLByte, toplama);
        }
        public void catalplcokuma()
        {

            Result = Client.ReadArea(S7Consts.S7AreaDB, 2, 0, 645, S7Consts.S7WLByte, DBCatal);


            catalplcoku[0] = read_Tag(AlltagClass.ALLTagList[619]).ToString();
            catalplcoku[1] = read_Tag(AlltagClass.ALLTagList[620]).ToString();
            catalplcoku[2] = read_Tag(AlltagClass.ALLTagList[621]).ToString();
            catalplcoku[3] = read_Tag(AlltagClass.ALLTagList[622]).ToString();
            catalplcoku[4] = read_Tag(AlltagClass.ALLTagList[623]).ToString();
            catalplcoku[5] = read_Tag(AlltagClass.ALLTagList[624]).ToString();
            catalplcoku[6] = read_Tag(AlltagClass.ALLTagList[625]).ToString();
            catalplcoku[7] = read_Tag(AlltagClass.ALLTagList[626]).ToString();
            catalplcoku[8] = read_Tag(AlltagClass.ALLTagList[627]).ToString();
            catalplcoku[9] = read_Tag(AlltagClass.ALLTagList[628]).ToString();
            catalplcoku[10] = read_Tag(AlltagClass.ALLTagList[629]).ToString();
            catalplcoku[11] = read_Tag(AlltagClass.ALLTagList[630]).ToString();
            catalplcoku[12] = read_Tag(AlltagClass.ALLTagList[641]).ToString();
            catalplcoku[13] = read_Tag(AlltagClass.ALLTagList[642]).ToString();
            catalplcoku[14] = read_Tag(AlltagClass.ALLTagList[643]).ToString();
            catalplcoku[15] = read_Tag(AlltagClass.ALLTagList[644]).ToString();
            catalplcoku[16] = read_Tag(AlltagClass.ALLTagList[645]).ToString();


        }





        private void ctlynbtn_Click(object sender, EventArgs e)
        {
            Recete_Giris.recetekonum = 3;


            recetegrs.ShowDialog(this);





        }

        private void catalpckaydetbtn_Click(object sender, EventArgs e)
        {

            string secilenrecete = listBox4.GetItemText(listBox4.SelectedItem);
            FileStream fs = new FileStream(toprctkonum + "\\CatalRecete" + "\\" + secilenrecete + ".txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);


            catalplcokuma();

            for (int i = 0; i < 17; i++)
            {
                sw.WriteLine(catalplcoku[i]);

            }

            sw.Flush();
            sw.Close();
            fs.Close();
            catalrecetesayı = listBox4.Items.Count;
        }

        private void ctlrctsilbtn_Click(object sender, EventArgs e)
        {
            string secilenrecete = listBox4.GetItemText(listBox4.SelectedItem);
            File.Delete(toprctkonum + "\\CatalRecete\\" + secilenrecete + ".txt");
            listBox4.Items.Remove(secilenrecete);
            listBox4.SetSelected(0, true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void ctlplcbtn_Click(object sender, EventArgs e)
        {
            string secilenrecete = listBox4.GetItemText(listBox4.SelectedItem);



            Catalplcyazdizi = System.IO.File.ReadAllLines(toprctkonum + "\\CatalRecete\\" + secilenrecete + ".txt");

            Catalplcyazfonk();
        }

        public void Catalplcyazfonk()
        {

            writePLC(AlltagClass.ALLTagList[619], false, Convert.ToInt32(Catalplcyazdizi[0]), "a");
            writePLC(AlltagClass.ALLTagList[620], false, Convert.ToInt32(Catalplcyazdizi[1]), "a");
            writePLC(AlltagClass.ALLTagList[621], false, Convert.ToInt32(Catalplcyazdizi[2]), "a");
            writePLC(AlltagClass.ALLTagList[622], false, Convert.ToInt32(Catalplcyazdizi[3]), "a");
            writePLC(AlltagClass.ALLTagList[623], false, Convert.ToInt32(Catalplcyazdizi[4]), "a");
            writePLC(AlltagClass.ALLTagList[624], false, Convert.ToInt32(Catalplcyazdizi[5]), "a");
            writePLC(AlltagClass.ALLTagList[625], false, Convert.ToInt32(Catalplcyazdizi[6]), "a");
            writePLC(AlltagClass.ALLTagList[626], false, Convert.ToInt32(Catalplcyazdizi[7]), "a");
            writePLC(AlltagClass.ALLTagList[627], false, Convert.ToInt32(Catalplcyazdizi[8]), "a");
            writePLC(AlltagClass.ALLTagList[628], false, Convert.ToInt32(Catalplcyazdizi[9]), "a");
            writePLC(AlltagClass.ALLTagList[629], false, Convert.ToInt32(Catalplcyazdizi[10]), "a");
            writePLC(AlltagClass.ALLTagList[630], false, Convert.ToInt32(Catalplcyazdizi[11]), "a");
            writePLC(AlltagClass.ALLTagList[641], false, Convert.ToInt32(Catalplcyazdizi[12]), "a");
            writePLC(AlltagClass.ALLTagList[642], false, Convert.ToInt32(Catalplcyazdizi[13]), "a");
            writePLC(AlltagClass.ALLTagList[643], false, Convert.ToInt32(Catalplcyazdizi[14]), "a");
            writePLC(AlltagClass.ALLTagList[644], false, Convert.ToInt32(Catalplcyazdizi[15]), "a");
            writePLC(AlltagClass.ALLTagList[645], false, Convert.ToInt32(Catalplcyazdizi[16]), "a");


        }

        private void ctlplcparabtn_Click(object sender, EventArgs e)
        {
            byte[] catal = new byte[25];
            string secilenrecete = listBox4.GetItemText(listBox4.SelectedItem);

            S7.SetStringAt(catal, 0, 25, secilenrecete);
            Result = Client.WriteArea(S7Consts.S7AreaDB, 8, 180, 25, S7Consts.S7WLByte, catal);

        }

        private void mksrplcykl_Click(object sender, EventArgs e)
        {
            string secilenrecete = listBox1.GetItemText(listBox1.SelectedItem);



            mksrplcyazdizi = System.IO.File.ReadAllLines(toprctkonum + "\\MikserRecete\\" + secilenrecete + ".txt");
            //  checkBox1.Text = mksrplcyazdizi.Length.ToString();
        


            Mksryaz();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string secilenrecete = listBox1.GetItemText(listBox1.SelectedItem);

            Mksrokuma();

            FileStream fs = new FileStream(toprctkonum + "\\MikserRecete" + "\\" + secilenrecete + ".txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < 20; i++)
            {
                sw.WriteLine(mksroku[i]);
            }




            sw.Flush();
            sw.Close();
            fs.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            if(!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();

            if (checkBox1.Checked == true)
            {


                checkBox3.Show();
            }
            if (checkBox1.Checked == false)
            {


                checkBox3.Hide();

            }
            if (checkBox1.Checked == true && checkBox3.Checked == true)
            {


                catalpckaydetbtn.Show();
                toppckaydet.Show();
                mikpckaydetbtn.Show();

            }
            if (checkBox3.Checked == false)
            {
                catalpckaydetbtn.Hide();
                toppckaydet.Hide();
                mikpckaydetbtn.Hide();


            }

            Result = Client.ReadArea(S7Consts.S7AreaDB, 1, 0, 352, S7Consts.S7WLByte, DBMikser);
            Result = Client.ReadArea(S7Consts.S7AreaDB, 8, 0, 248, S7Consts.S7WLByte, DB8);


            label1.Text = S7.GetStringAt(DB8, 180);
            label3.Text = S7.GetStringAt(DB8, 24);
            label2.Text = S7.GetStringAt(DB8, 84);

        }

        private void ctlsnrabtn_Click(object sender, EventArgs e)
        {
            int index = listBox4.SelectedIndex;

            index++;
            if (index == catalrecetesayı)
            {
                index = 0;
            }

            listBox4.SetSelected(index, true);
        }

        private void ctloncebtn_Click(object sender, EventArgs e)
        {

            int index = listBox4.SelectedIndex;

            if (index == 0)
            {
                listBox4.SetSelected(catalrecetesayı - 1, true);
            }
            else
            {
                index--;
                listBox4.SetSelected(index, true);

            }


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {



            topplcyazdizi = System.IO.File.ReadAllLines(toprctkonum + "\\ToplamaRecete\\" + secilenreceteglobal + ".txt");



            for (int i = 0; i < 70; i++)
            {
                if (topplcyazdizi[i] == "False" || topplcyazdizi[i] == "True")
                {
                    if (topplcyazdizi[i] == "False")
                    {
                        writePLC(AlltagClass.ALLTagList[i + 208], false, 0, "a");
                    }
                    else if (topplcyazdizi[i] == "True")
                    {
                        writePLC(AlltagClass.ALLTagList[i + 208], true, 0, "a");

                    }

                }
                else
                {

                    writePLC(AlltagClass.ALLTagList[i + 208], false, Convert.ToInt32(topplcyazdizi[i]), "a");
                }

            }

            for (int ii = 70; ii < 88; ii++)
            {
                writePLC(AlltagClass.ALLTagList[ii + 208], false, Convert.ToInt32(topplcyazdizi[ii]), "a");

            }


            writePLC(AlltagClass.ALLTagList[297], false, Convert.ToInt32(topplcyazdizi[88]), "a");

            for (int iii = 89; iii < 94; iii++)
            {
                writePLC(AlltagClass.ALLTagList[iii + 210], false, Convert.ToInt32(topplcyazdizi[iii]), "a");

            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("ok");
        }






        private void recetelis_Tick(object sender, EventArgs e)
        {

            string mksrkonum = Application.StartupPath.ToString();
            string[] mreçeteler = System.IO.Directory.GetFiles(mksrkonum + "\\MikserRecete"); // C:\\Windows dizinindeki dosyaları diziye çeker.

            string[] topreçeteler = System.IO.Directory.GetFiles(mksrkonum + "\\ToplamaRecete");

            string[] catalreceteler = System.IO.Directory.GetFiles(mksrkonum + "\\CatalRecete");

            if (Recete_Giris.receteisim != "")
            {
                listBox1.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();

                for (int i = 0; i < mreçeteler.Length; i++)
                {
                    dizi1[i] = mreçeteler[i].Remove(0, mksrkonum.Length + 14);
                    dizi1[i] = dizi1[i].Replace(".txt", "");

                    listBox1.Items.Add(dizi1[i]);               // Dosyaları listBox1'de göstermek istersek

                }

                for (int i = 0; i < topreçeteler.Length; i++)
                {
                    dizi1[i] = topreçeteler[i].Remove(0, mksrkonum.Length + 15);
                    dizi1[i] = dizi1[i].Replace(".txt", "");
                    listBox3.Items.Add(dizi1[i]);               // Dosyaları listBox1'de göstermek istersek

                }
                for (int i = 0; i < catalreceteler.Length; i++)
                {
                    dizi1[i] = catalreceteler[i].Remove(0, mksrkonum.Length + 13);
                    dizi1[i] = dizi1[i].Replace(".txt", "");
                    listBox4.Items.Add(dizi1[i]);               // Dosyaları listBox1'de göstermek istersek

                }
                Recete_Giris.receteisim = "";
                Recete_Giris.recetekonum = 0;
            }
        }

      
       
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Result != 0 || !Client.Connected)
            {

                CPUbaglan();

            }

            try
            {

                if (Result == 0 && Client.Connected)
                {

                  
                    ShowResult(Result);
                    ALLAlarmListClass.AlarmlariOku(Client);
                    if (ALLAlarmListClass.AktifAlarmList.Count > 0)
                    {
                        if (button21.BackColor == Color.Red)
                        {
                            button21.BackColor = Color.Blue;
                            button21.Text = "Alarm " + ALLAlarmListClass.AktifAlarmList.Count;
                        }
                        else
                        {
                            button21.Text = "Alarm " + ALLAlarmListClass.AktifAlarmList.Count;
                            button21.BackColor = Color.Red;
                        }
                    }
                    if (ALLAlarmListClass.AktifAlarmList.Count == 0)
                    {
                        button21.Text = "Alarm ";
                        button21.BackColor = Sistem.AlarmbuttonColor;
                    }



                }

            }
            catch (Exception error)
            {
                ShowResult(Result);
            }
        }

        private void Recete_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        private void Recete_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }
        private void btnOperatorScreen(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenOperatprScreen(this);
        }
    }
}

