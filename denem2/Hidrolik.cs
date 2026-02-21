using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sharp7;

namespace denem2
{
    public partial class Hidrolik : Form
    {
        private S7Client Client;
        private int Result;
        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBPaketleme = new byte[600];
        private byte[] DBMikser = new byte[600];
        private byte[] Db9 = new byte[200];
        private byte[] DBEkran8 = new byte[300];
        public Hidrolik()
        {
            InitializeComponent();
         
            GoFullscreen(true);
            CustumizeDesign();

        }

        private void Hidrolik_Load(object sender, EventArgs e)
        {
            CPUbaglan();

            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            btnPnlKontrol.BackColor = Sistem.PanelsColor;
            this.BackColor = Sistem.formbackgroundColor;
            
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
            button26.BackColor = Sistem.ustbuttoncolor;//Raporlar
            button31.BackColor = Sistem.ustbuttoncolor;//operator
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
            timer1.Enabled = false;
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenVardiyaScreen(this);

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
            
                timer1.Enabled = false;
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                if (Client.Connected)
                    Client.Disconnect();
                Form f = new Palet3();
                f.Show();
                this.Hide();
            

        }

        private void Hidrolik_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
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

        private void lblPhidRezStoPDeg_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[655], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblPhidFanStartDeg_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[656], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopHidRezStopDeg_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[657], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopHidFanStartDeg_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[658], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void btnPresHidStart_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[376]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[376], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[376], true, 1);
            }
        }

        private void btnIndirmeHidStart_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[354]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[354], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[354], true, 1);
            }
        }

        private void btnKaldirmaHidStart_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[357]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[357], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[357], true, 1);
            }
        }

        private void btnMklepeStart_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[364]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[364], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[364], true, 1);
            }
        }

        private void btnTopHidStart_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[388]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[388], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[388], true, 1);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[375]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[375], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[375], true, 1);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[387]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[387], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[387], true, 1);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[43]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[43], false, 1);
                
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[43], true, 1);
               
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[53]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[53], false, 1);

            }
            else
            {
                writePLC(AlltagClass.ALLTagList[53], true, 1);

            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
           
                timer1.Enabled = false;
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                if (Client.Connected)
                    Client.Disconnect();
                Ekranlar.OpenPressOransalAyarScreen(this);
            
        }

        private void button28_Click(object sender, EventArgs e)
        {
           
                timer1.Enabled = false;
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
                if (Client.Connected)
                    Client.Disconnect();
                Ekranlar.OpenToplamaOransalScreen(this);
            
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
            try
            {
                if (Result != 0 || !Client.Connected)
                {

                    CPUbaglan();
                    return;

                }
                if (Result == 0 && Client.Connected)
                {

                    Result = Client.ReadArea(S7Consts.S7AreaDB, 6, 0, 198, S7Consts.S7WLByte, BufferDB6);
                    Result = Client.ReadArea(S7Consts.S7AreaMK, 0, 0, 320, S7Consts.S7WLByte, MarkersDB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 1, 0, 352, S7Consts.S7WLByte, DBMikser);

                    Result = Client.ReadArea(S7Consts.S7AreaDB, 8, 0, 250, S7Consts.S7WLByte, DBEkran8);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 9, 0, 144, S7Consts.S7WLByte, Db9);
                    ShowResult(Result);
                    if (Result == 0)
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


                }
                ShowResult(Result);


            }
            catch (NullReferenceException error)
            {

                ShowResult(Result);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Result == 0)
            {

                lblPhidRezStoPDeg.Text = ((Convert.ToDouble(S7.GetIntAt(DBEkran8, 210)))).ToString();
                lblPhidFanStartDeg.Text = ((Convert.ToDouble(S7.GetIntAt(DBEkran8, 208)))).ToString();
                lblTopHidRezStopDeg.Text = (Convert.ToDouble(S7.GetIntAt(DBEkran8, 214))).ToString();
                lblTopHidFanStartDeg.Text = (Convert.ToDouble(S7.GetIntAt(DBEkran8, 212))).ToString();
                if (S7.GetBitAt(BufferDB6, 2, 7))
                    snsPresBasKirli.BackColor = Color.LimeGreen;
                else
                    snsPresBasKirli.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 4, 4))
                    snsPressGeriKirli.BackColor = Color.LimeGreen;
                else
                    snsPressGeriKirli.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 3, 0))
                    snsPresYagSicak.BackColor = Color.LimeGreen;
                else
                    snsPresYagSicak.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 4, 5))
                    snsTopFiltreKirli.BackColor = Color.LimeGreen;
                else
                    snsTopFiltreKirli.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 5, 5))
                    snsTopYagSicak.BackColor = Color.LimeGreen;
                else
                    snsTopYagSicak.BackColor = Color.Blue;

                lblPressBasinc.Text = S7.GetIntAt(BufferDB6, 98).ToString();
                lblPressSicak.Text = S7.GetIntAt(BufferDB6, 100).ToString();
                lblTopBasinc.Text = S7.GetIntAt(BufferDB6, 102).ToString();
                lblTopSicaklik.Text = S7.GetIntAt(BufferDB6, 104).ToString();

                if (S7.GetBitAt(DBEkran8, 20, 0))
                {
                    button24.Text = "Sürekli";
                    button24.BackColor = Color.LimeGreen;
                }
                else
                {
                    button24.Text = "Sıcaklığa Göre";
                    button24.BackColor = Color.Gray;
                }


                if (S7.GetBitAt(DBEkran8, 20, 1))
                {
                    button25.Text = "Sürekli";
                    button25.BackColor = Color.LimeGreen;
                }
                else
                {
                    button25.Text = "Sıcaklığa Göre";
                    button25.BackColor = Color.Gray;
                }

                if (S7.GetBitAt(BufferDB6, 13, 5))
                    btnPresHidStart.BackColor = Color.LimeGreen;
                else
                    btnPresHidStart.BackColor = Color.Gray;

                if (S7.GetBitAt(BufferDB6, 13, 7))
                    btnIndirmeHidStart.BackColor = Color.LimeGreen;
                else
                    btnIndirmeHidStart.BackColor = Color.Gray;

                if (S7.GetBitAt(BufferDB6, 12, 7))
                    btnKaldirmaHidStart.BackColor = Color.LimeGreen;
                else
                    btnKaldirmaHidStart.BackColor = Color.Gray;

                if (S7.GetBitAt(BufferDB6, 15, 4))
                    btnMklepeStart.BackColor = Color.LimeGreen;
                else
                    btnMklepeStart.BackColor = Color.Gray;

                if (S7.GetBitAt(BufferDB6, 17, 4))
                    btnTopHidStart.BackColor = Color.LimeGreen;
                else
                    btnTopHidStart.BackColor = Color.Gray;


            }
        }

        private void Hidrolik_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;

            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            btnPnlKontrol.BackColor = Sistem.PanelsColor;
            this.BackColor = Sistem.formbackgroundColor;

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
            button26.BackColor = Sistem.ustbuttoncolor;//Raporlar
            button31.BackColor = Sistem.ustbuttoncolor;//operator
        }

        private void Hidrolik_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }
        private void btnOperatorScreen(object sender, EventArgs e)
        {

        }
    }
}
