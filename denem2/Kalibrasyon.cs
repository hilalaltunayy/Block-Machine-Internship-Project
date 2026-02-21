using Sharp7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denem2
{
    public partial class Kalibrasyon : Form
    {
        private S7Client Client;
        private int Result = 5;
        private byte[] Buffer = new byte[750];
        private byte[] BufferDB6 = new byte[750];
        private byte[] MarkersDB = new byte[750];
        private byte[] PaketlemeDB = new byte[750];
        private byte[] timer112DB = new byte[36];
        private byte[] MikserDB = new byte[750];
        private byte[] timer113DB = new byte[36];
        private int val = 0;
        public Kalibrasyon()
        {
            InitializeComponent();
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

                btnconnectionStatus.BackColor = Color.Green;
            }
            else
            {

                btnconnectionStatus.BackColor = Color.Blue;

            }

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

        private void Kalibrasyon_Load(object sender, EventArgs e)
        {
            GoFullscreen(true);
            CustumizeDesign();



            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
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
        private int writePLC(PLCTag gelentag, bool boolvalue, int othersvalue)
        {

            try
            {
                Result = Client.ConnectTo("192.168.0.2", 0, 0);
                if (Result == 0)
                {
                    if (gelentag.Area == "M")
                    {
                        if (gelentag.Tip == "bool")
                        {
                            byte[] bytearray = new byte[1];
                            S7.SetBitAt(ref bytearray, 0, gelentag.BitNo, boolvalue);
                            bool a = S7.GetBitAt(bytearray, 0, 1);
                            Debug.WriteLine("gelen tag offset :" + gelentag.Offset.ToString());
                            Debug.WriteLine("Test bit yazma :" + a.ToString());
                            Result = Client.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, (gelentag.Offset * 8) + gelentag.BitNo, 1, S7Consts.S7WLBit, bytearray);

                            ShowResult(Result);
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
                    else
                    {
                        Debug.WriteLine("Test bit yazma :error");

                        return 0;
                    }

                }
                return 0;
            }
            catch (Exception error)
            {
                Debug.WriteLine("Write PLC Catch :" + error.ToString());
                ShowResult(Result);
                return 0;
            }

        }
        protected string read_Tag(PLCTag gelentag)
        {

            try
            {

                if (Result == 0)
                {


                    ShowResult(Result);
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

                            Result = Client.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLBit, bytearray);


                            return bytearray[gelentag.BitNo].ToString();
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
                return 0.ToString();
            }
            catch (Exception error)
            {
                ShowResult(Result);
                return 0.ToString();
            }

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
                return;

            }

            try
            {

                if (Result == 0 && Client.Connected)
                {

                    Result = Client.ReadArea(S7Consts.S7AreaDB, 8, 0, 120, S7Consts.S7WLByte, Buffer);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 6, 0, 198, S7Consts.S7WLByte, BufferDB6);
                    Result = Client.ReadArea(S7Consts.S7AreaMK, 0, 0, 320, S7Consts.S7WLByte, MarkersDB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 3, 0, 280, S7Consts.S7WLByte, PaketlemeDB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 112, 0, 12, S7Consts.S7WLByte, timer112DB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 113, 0, 12, S7Consts.S7WLByte, timer113DB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 1, 0, 320, S7Consts.S7WLByte, MikserDB);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void Kalibrasyon_Activated(object sender, EventArgs e)
        {
            if(!timer1.Enabled)
                timer1.Enabled=true;

        }

        private void Kalibrasyon_Deactivate(object sender, EventArgs e)
        {
            if(timer1.Enabled)
                timer1.Enabled=false;
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
