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
  
    public partial class Alarm : Form
    {
        private S7Client Client;
        private int Result;
        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBPaketleme = new byte[600];
        private byte[] DBMikser = new byte[600];
        private byte[] Db4Kalip = new byte[600];
        private byte[] DBEkran8 = new byte[300];
   
      
       
        private  int[] kayitliAlarmlar; 
        public Alarm()
        {
            InitializeComponent();
            GoFullscreen(true);
            CustumizeDesign();
           
            //aa = new ALLAlarmListClass();
            //CPUbaglan();
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
        private void Alarm_Load(object sender, EventArgs e)
        {
            CPUbaglan();
            AlarmlariOku();

            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            panel1.BackColor = Sistem.PanelsColor;


            this.BackColor = Sistem.formbackgroundColor;

            //-4-5-6-11-10-9-8-3-17
            // 1 - 7 - 13 - 14 - 15 - 16 - 19 - 20 - 21 - 28 - 31
            button4.BackColor = Sistem.altbuttonColors;
            button5.BackColor = Sistem.altbuttonColors;
            button6.BackColor = Sistem.altbuttonColors;
            button11.BackColor = Sistem.altbuttonColors;
            button10.BackColor = Sistem.altbuttonColors;
            button9.BackColor = Sistem.altbuttonColors;
            button8.BackColor = Sistem.altbuttonColors;
            button3.BackColor = Sistem.altbuttonColors;
            button17.BackColor = Sistem.altbuttonColors;

            button1.BackColor = Sistem.ustbuttoncolor;
            button7.BackColor = Sistem.ustbuttoncolor;
            button13.BackColor = Sistem.ustbuttoncolor;
            button14.BackColor = Sistem.ustbuttoncolor;
            button15.BackColor = Sistem.ustbuttoncolor;
            button16.BackColor = Sistem.ustbuttoncolor;
            button19.BackColor = Sistem.ustbuttoncolor;
            button20.BackColor = Sistem.ustbuttoncolor;
            button21.BackColor = Sistem.ustbuttoncolor;
            button33.BackColor = Sistem.ustbuttoncolor;
            button32.BackColor = Sistem.ustbuttoncolor;



        }
        private void CustumizeDesign()
        {
            panelUretim.Visible = false;
            panelPaketleme.Visible = false;
            panelMikser.Visible = false;
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
        private void btnPalet3C(object sender, EventArgs e)
        {
            if (Result == 3)
            {
                Form f = new Palet3();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                timer1.Enabled = false;
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                if (Client.Connected)
                    Client.Disconnect();
                Form f = new Palet3();
                f.ShowDialog();
                this.Close();
            }

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
        protected string read_Tag(PLCTag gelentag)
        {
            if (gelentag.Area == "M")
            {
                if (gelentag.Tip == "bool")
                {
                    byte[] bytearray = new byte[1];

                    Result = Client.ReadArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLBit, bytearray);

                    return S7.GetBitAt(bytearray, 0, gelentag.BitNo).ToString();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
           
        }
        public  void AlarmlariOku()
        {
            if (Client == null)
            {
                CPUbaglan();
                return;
            }
               

            if (Result != 0 || !Client.Connected)
            {

                CPUbaglan();
                return;

            }

            try
            {
                Result = Client.ReadArea(S7Consts.S7AreaMK, 0, 200, 10, S7Consts.S7WLByte, MarkersDB);


                ShowResult(Result);
                if (Result == 0)
                {
                    if (S7.GetBitAt(MarkersDB, 0, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[1]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[1]);
                    if (S7.GetBitAt(MarkersDB, 0, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[2]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[2]);
                    if (S7.GetBitAt(MarkersDB, 0, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[3]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[3]);
                    if (S7.GetBitAt(MarkersDB, 0, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[4]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[4]);
                    if (S7.GetBitAt(MarkersDB, 0, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[5]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[5]);
                    if (S7.GetBitAt(MarkersDB, 0, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[6]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[6]);

                    if (S7.GetBitAt(MarkersDB, 0, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[7]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[7]);
                    if (S7.GetBitAt(MarkersDB, 0, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[8]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[8]);
                    if (S7.GetBitAt(MarkersDB, 1, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[9]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[9]);
                    if (S7.GetBitAt(MarkersDB, 1, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[10]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[10]);
                    if (S7.GetBitAt(MarkersDB, 1, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[11]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[11]);
                    if (S7.GetBitAt(MarkersDB, 1, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[12]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[12]);
                    if (S7.GetBitAt(MarkersDB, 1, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[13]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[13]);
                    if (S7.GetBitAt(MarkersDB, 1, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[14]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[14]);
                    if (S7.GetBitAt(MarkersDB, 1, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[15]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[15]);
                    if (S7.GetBitAt(MarkersDB, 1, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[16]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[16]);



                    AlarmDelete(ALLAlarmListClass.ALLAlarmList[16]);
                    if (S7.GetBitAt(MarkersDB, 2, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[17]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[17]);
                    if (S7.GetBitAt(MarkersDB, 2, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[18]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[18]);
                    if (S7.GetBitAt(MarkersDB, 2, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[19]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[19]);
                    if (S7.GetBitAt(MarkersDB, 2, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[20]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[20]);
                    if (S7.GetBitAt(MarkersDB, 2, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[21]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[21]);
                    if (S7.GetBitAt(MarkersDB, 2, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[22]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[22]);
                    if (S7.GetBitAt(MarkersDB, 2, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[23]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[23]);

                    if (S7.GetBitAt(MarkersDB, 2, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[24]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[24]);
                    if (S7.GetBitAt(MarkersDB, 3, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[25]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[25]);
                    if (S7.GetBitAt(MarkersDB, 3, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[26]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[26]);
                    if (S7.GetBitAt(MarkersDB, 3, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[27]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[27]);
                    if (S7.GetBitAt(MarkersDB, 3, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[28]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[28]);
                    if (S7.GetBitAt(MarkersDB, 3, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[29]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[29]);
                    if (S7.GetBitAt(MarkersDB, 3, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[30]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[30]);
                    if (S7.GetBitAt(MarkersDB, 3, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[31]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[31]);


                    if (S7.GetBitAt(MarkersDB, 3, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[32]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[32]);
                    if (S7.GetBitAt(MarkersDB, 4, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[33]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[33]);
                    if (S7.GetBitAt(MarkersDB, 4, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[34]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[34]);
                    if (S7.GetBitAt(MarkersDB, 4, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[35]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[35]);
                    if (S7.GetBitAt(MarkersDB, 4, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[36]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[36]);
                    if (S7.GetBitAt(MarkersDB, 4, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[37]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[37]);
                    if (S7.GetBitAt(MarkersDB, 4, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[38]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[38]);
                    if (S7.GetBitAt(MarkersDB, 4, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[39]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[39]);


                    if (S7.GetBitAt(MarkersDB, 4, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[40]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[40]);
                    if (S7.GetBitAt(MarkersDB, 5, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[41]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[41]);
                    if (S7.GetBitAt(MarkersDB, 5, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[42]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[42]);
                    if (S7.GetBitAt(MarkersDB, 5, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[43]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[43]);
                    if (S7.GetBitAt(MarkersDB, 5, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[44]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[44]);
                    if (S7.GetBitAt(MarkersDB, 5, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[45]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[45]);
                    if (S7.GetBitAt(MarkersDB, 5, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[46]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[46]);
                    if (S7.GetBitAt(MarkersDB, 5, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[47]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[47]);


                    if (S7.GetBitAt(MarkersDB, 5, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[48]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[48]);
                    if (S7.GetBitAt(MarkersDB, 6, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[49]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[49]);
                    if (S7.GetBitAt(MarkersDB, 6, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[50]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[50]);
                    if (S7.GetBitAt(MarkersDB, 6, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[51]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[51]);
                    if (S7.GetBitAt(MarkersDB, 6, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[52]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[52]);
                    if (S7.GetBitAt(MarkersDB, 6, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[53]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[53]);
                    if (S7.GetBitAt(MarkersDB, 6, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[54]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[54]);
                    if (S7.GetBitAt(MarkersDB, 6, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[55]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[55]);
                    if (S7.GetBitAt(MarkersDB, 6, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[56]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[56]);

                    if (S7.GetBitAt(MarkersDB, 7, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[57]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[57]);
                    if (S7.GetBitAt(MarkersDB, 7, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[58]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[58]);
                    if (S7.GetBitAt(MarkersDB, 7, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[59]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[59]);
                    if (S7.GetBitAt(MarkersDB, 7, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[60]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[60]);
                    if (S7.GetBitAt(MarkersDB, 7, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[61]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[61]);
                    if (S7.GetBitAt(MarkersDB, 7, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[62]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[62]);
                    if (S7.GetBitAt(MarkersDB, 7, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[63]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[63]);
                    if (S7.GetBitAt(MarkersDB, 7, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[64]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[64]);

                    if (S7.GetBitAt(MarkersDB, 8, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[65]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[65]);
                    if (S7.GetBitAt(MarkersDB, 8, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[66]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[66]);
                    if (S7.GetBitAt(MarkersDB, 8, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[67]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[67]);
                    if (S7.GetBitAt(MarkersDB, 8, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[68]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[68]);
                    if (S7.GetBitAt(MarkersDB, 8, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[69]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[69]);
                    if (S7.GetBitAt(MarkersDB, 8, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[70]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[70]);
                    if (S7.GetBitAt(MarkersDB, 8, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[71]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[71]);
                    if (S7.GetBitAt(MarkersDB, 8, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[72]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[72]);

                    if (S7.GetBitAt(MarkersDB, 9, 0))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[73]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[73]);
                    if (S7.GetBitAt(MarkersDB, 9, 1))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[74]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[74]);
                    if (S7.GetBitAt(MarkersDB, 9, 2))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[75]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[75]);
                    if (S7.GetBitAt(MarkersDB, 9, 3))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[76]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[76]);
                    if (S7.GetBitAt(MarkersDB, 9, 4))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[77]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[77]);
                    if (S7.GetBitAt(MarkersDB, 9, 5))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[78]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[78]);
                    if (S7.GetBitAt(MarkersDB, 9, 6))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[79]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[79]);
                    if (S7.GetBitAt(MarkersDB, 9, 7))
                        AlarmEkle(ALLAlarmListClass.ALLAlarmList[80]);
                    else
                        AlarmDelete(ALLAlarmListClass.ALLAlarmList[80]);



                }
            }
            catch(Exception err)
            {

            }
           
        }

        protected  void AlarmEkle(AlarmTag tag)
        {
            DateTime dt =  DateTime.Now;
           
            dataGridView1.Rows.Add(tag.no, dt.Hour + ":" + dt.Minute + ":" + dt.Second, dt.DayOfYear, tag.PLCadres, tag.Aciklama);

        }
        private void AlarmDelete(AlarmTag tag)
        {



        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            AlarmlariOku();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[407], false, 66);
            dataGridView1.Rows.Clear();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();


            Form f = new AlarmSüreleri();
            f.ShowDialog();
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Result != 0 || !Client.Connected)
            {

                CPUbaglan();

            }
            try
            {
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
            catch (Exception)
            {
            }
        }

        private void Alarm_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;

            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            panel1.BackColor = Sistem.PanelsColor;


            this.BackColor = Sistem.formbackgroundColor;

            //-4-5-6-11-10-9-8-3-17
            // 1 - 7 - 13 - 14 - 15 - 16 - 19 - 20 - 21 - 28 - 31
            button4.BackColor = Sistem.altbuttonColors;
            button5.BackColor = Sistem.altbuttonColors;
            button6.BackColor = Sistem.altbuttonColors;
            button11.BackColor = Sistem.altbuttonColors;
            button10.BackColor = Sistem.altbuttonColors;
            button9.BackColor = Sistem.altbuttonColors;
            button8.BackColor = Sistem.altbuttonColors;
            button3.BackColor = Sistem.altbuttonColors;
            button17.BackColor = Sistem.altbuttonColors;

            button1.BackColor = Sistem.ustbuttoncolor;
            button7.BackColor = Sistem.ustbuttoncolor;
            button13.BackColor = Sistem.ustbuttoncolor;
            button14.BackColor = Sistem.ustbuttoncolor;
            button15.BackColor = Sistem.ustbuttoncolor;
            button16.BackColor = Sistem.ustbuttoncolor;
            button19.BackColor = Sistem.ustbuttoncolor;
            button20.BackColor = Sistem.ustbuttoncolor;
            button21.BackColor = Sistem.ustbuttoncolor;
            button33.BackColor = Sistem.ustbuttoncolor;
            button32.BackColor = Sistem.ustbuttoncolor;
        }

        private void Alarm_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }

        private void button32_Click(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();

            timer1.Enabled = false;
            Ekranlar.OpenOperatprScreen(this);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenVardiyaScreen(this);
        }
    }
}
