using System;
using Sharp7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace denem2
{
    public partial class Vardiya : Form
    {
        private S7Client Client;
        private int Result;


        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBPaketleme = new byte[600];
        private byte[] DBMikser = new byte[600];
        private byte[] timer112DB = new byte[36];
        private byte[] Db9 = new byte[200];
        private byte[] DBEkran8 = new byte[300];

        private byte[] timer113DB = new byte[36];

        private byte[] DB7 = new byte[350];



        public Vardiya()
        {
            InitializeComponent();
            GoFullscreen(true);
            CustumizeDesign();
            //CPUbaglan();
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
            hata.Text = Result + " " + Client.ErrorText(Result);
            if (Result == 0)
            {
                if (Result == 0)
                {
                    bglntld.BackColor = Color.Green;
                }
                else
                {
                    bglntld.BackColor = Color.Blue;

                }
            }
            else
            {
                

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

        private void Vardiya_Load(object sender, EventArgs e)
        {
            CPUbaglan();
        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            if(!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();

        }
        private int writePLC(PLCTag gelentag, bool boolvalue, int othersvalue)
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
                else if (gelentag.Tip == "real")
                {
                    byte[] realArray = new byte[4];
                    int val = Convert.ToInt32(othersvalue);
                    realArray = BitConverter.GetBytes(val);
                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLReal, realArray);
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

        private void var1bassa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[513], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var1basdk_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[514], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var1btssa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[515], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var1btsdk_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[516], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var2bassa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[517], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var2basdk_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[518], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var2btssa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[519], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var2btsdk_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[520], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var3bassa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[521], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var3basdk_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[522], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var3btssa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[523], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void var3btsdk_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[524], 1000, 9999, 0);
            f.ShowDialog(this);
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Result != 0 || !Client.Connected)
            {

                CPUbaglan();

            }

            try
            {

                if (Result == 0 && Client.Connected)
                {

                    Result = Client.ReadArea(S7Consts.S7AreaDB, 7, 0, 336, S7Consts.S7WLByte, DB7);
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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Result == 0)
            {
                var1akuretadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 36)))).ToString();
                var1akmksradt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 38)))).ToString();
                var1akpltadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 40)))).ToString();
                var1akçim.Text = (((S7.GetRealAt(DB7, 42)))).ToString();
                var1akotoçalsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 46)))).ToString();
                var1akotoçaldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 48)))).ToString();
                var1akhrçbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 50)))).ToString();
                var1akhrçbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 52)))).ToString();
                var1akpktbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 54)))).ToString();
                var1akpktbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 56)))).ToString();                        //1.Vardiya aktüel
                var1akpaletbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 58)))).ToString();
                var1akpaletbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 60)))).ToString();
                var1akkatbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 62)))).ToString();
                var1akkatbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 64)))).ToString();
                var1akagrega1.Text = (((S7.GetRealAt(DB7, 66)))).ToString();
                var1akagrega2.Text = (((S7.GetRealAt(DB7, 70)))).ToString();
                var1akagrega3.Text = (((S7.GetRealAt(DB7, 74)))).ToString();

                var1kyturetadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 186)))).ToString();
                var1kytmksradt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 188)))).ToString();
                var1kytpltadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 190)))).ToString();
                var1kytçim.Text = (((S7.GetRealAt(DB7, 192)))).ToString();
                var1kytotoçalsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 196)))).ToString();
                var1kytotoçaldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 198)))).ToString();
                var1kythrçbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 200)))).ToString();
                var1kythrçbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 202)))).ToString();                          //1.Vardiya kayıt
                var1kytpktbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 204)))).ToString();
                var1kytpktbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 206)))).ToString();
                var1kytpaletbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 208)))).ToString();
                var1kytpaletbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 210)))).ToString();
                var1kytkatbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 212)))).ToString();
                var1kytkatbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 214)))).ToString();
                var1kytagrega1.Text = (((S7.GetRealAt(DB7, 216)))).ToString();
                var1kytagrega2.Text = (((S7.GetRealAt(DB7, 220)))).ToString();
                var1kytagrega3.Text = (((S7.GetRealAt(DB7, 224)))).ToString();

                var2akuretadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 86)))).ToString();
                var2akmksradt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 88)))).ToString();
                var2akpltadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 90)))).ToString();
                var2akçim.Text = (((S7.GetRealAt(DB7, 92)))).ToString();
                var2akotoçalsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 96)))).ToString();
                var2akotoçaldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 98)))).ToString();
                var2akhrçbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 100)))).ToString();
                var2akhrçbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 102)))).ToString();
                var2akpktbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 104)))).ToString();           //2.Vardiya aktüel
                var2akpktbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 106)))).ToString();
                var2akpaletbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 108)))).ToString();
                var2akpaletbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 110)))).ToString();
                var2akkatbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 112)))).ToString();
                var2akkatbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 114)))).ToString();
                var2akagrega1.Text = (((S7.GetRealAt(DB7, 116)))).ToString();
                var2akagrega2.Text = (((S7.GetRealAt(DB7, 120)))).ToString();
                var2akagrega3.Text = (((S7.GetRealAt(DB7, 124)))).ToString();

                var2kyturetadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 236)))).ToString();
                var2kytmksradt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 238)))).ToString();
                var2kytpltadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 240)))).ToString();
                var2kytçim.Text = (((S7.GetRealAt(DB7, 242)))).ToString();
                var2kytotoçalsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 246)))).ToString();
                var2kytotoçaldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 248)))).ToString();                    //2.Vardiya kayıt
                var2kythrçbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 250)))).ToString();
                var2kythrçbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 252)))).ToString();
                var2kytpktbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 254)))).ToString();
                var2kytpktbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 256)))).ToString();
                var2kytpaletbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 258)))).ToString();
                var2kytpaletbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 260)))).ToString();
                var2kytkatbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 262)))).ToString();
                var2kytkatbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 264)))).ToString();
                var2kytagrega1.Text = (((S7.GetRealAt(DB7, 266)))).ToString();
                var2kytagrega2.Text = (((S7.GetRealAt(DB7, 270)))).ToString();
                var2kytagrega3.Text = (((S7.GetRealAt(DB7, 274)))).ToString();

                var3akuretadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 136)))).ToString();
                var3akmksradt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 138)))).ToString();
                var3akpltadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 140)))).ToString();
                var3akçim.Text = (((S7.GetRealAt(DB7, 142)))).ToString();
                var3akotoçalsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 146)))).ToString();
                var3akotoçaldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 148)))).ToString();
                var3akhrçbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 150)))).ToString();
                var3akhrçbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 152)))).ToString();
                var3akpktbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 154)))).ToString();
                var3akpktbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 156)))).ToString();
                var3akpaletbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 158)))).ToString();
                var3akpaletbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 160)))).ToString();
                var3akkatbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 162)))).ToString();
                var3akkatbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 164)))).ToString();
                var3akagrega1.Text = (((S7.GetRealAt(DB7, 166)))).ToString();
                var3akagrega2.Text = (((S7.GetRealAt(DB7, 170)))).ToString();
                var3akagrega3.Text = (((S7.GetRealAt(DB7, 174)))).ToString();

                var3kyturetadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 286)))).ToString();
                var3kytmksradt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 288)))).ToString();
                var3kytpltadt.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 290)))).ToString();
                var3kytçim.Text = (((S7.GetRealAt(DB7, 292)))).ToString();
                var3kytotoçalsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 296)))).ToString();
                var3kytotoçaldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 298)))).ToString();
                var3kythrçbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 300)))).ToString();
                var3kythrçbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 302)))).ToString();
                var3kytpktbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 304)))).ToString();
                var3kytpktbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 306)))).ToString();
                var3kytpaletbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 308)))).ToString();
                var3kytpaletbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 310)))).ToString();
                var3kytkatbklsa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 312)))).ToString();
                var3kytkatbkldk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 314)))).ToString();
                var3kytagrega1.Text = (((S7.GetRealAt(DB7, 316)))).ToString();
                var3kytagrega2.Text = (((S7.GetRealAt(DB7, 320)))).ToString();
                var3kytagrega3.Text = (((S7.GetRealAt(DB7, 324)))).ToString();

                var1bassa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 0)))).ToString();
                var1basdk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 2)))).ToString();
                var1btssa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 4)))).ToString();
                var1btsdk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 6)))).ToString();

                var2bassa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 8)))).ToString();
                var2basdk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 10)))).ToString();
                var2btssa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 12)))).ToString();
                var2btsdk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 14)))).ToString();

                var3bassa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 16)))).ToString();
                var3basdk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 18)))).ToString();
                var3btssa.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 20)))).ToString();
                var3btsdk.Text = ((Convert.ToDouble(S7.GetWordAt(DB7, 22)))).ToString();
            }
        }

        private void Vardiya_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        private void Vardiya_Deactivate(object sender, EventArgs e)
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
