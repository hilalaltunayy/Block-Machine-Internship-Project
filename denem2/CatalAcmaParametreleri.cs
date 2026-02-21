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
    public partial class CatalAcmaParametreleri : Form
    {
        private S7Client Client;
        private int Result;


        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBEkran = new byte[600];
        private byte[] DBCatal = new byte[600];
        public CatalAcmaParametreleri()
        {
            InitializeComponent();
            GoFullscreen(true);
            CustumizeDesign();
            
        }
        private void CustumizeDesign()
        {
            panelUretim.Visible = false;
            panelPaketleme.Visible = false;
            panelMikser.Visible = false;
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

        private void CatalAcmaParametreleri_Load(object sender, EventArgs e)
        {
            CPUbaglan();
            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            btnPnlKontrol.BackColor = Sistem.PanelsColor;


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
            button26.BackColor = Sistem.ustbuttoncolor;
            button32.BackColor = Sistem.ustbuttoncolor;
        }

        private void lblTopBirakKnm_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[620], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }


        }

        private void lblBlokGenislik_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[621], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblSira1BlokAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[622], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblCatal1AcmaMsf_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[623], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblSira2BlokAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[624], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblAraBoslukMsf_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[625], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblSira3BlokAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[626], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblCatal2AcmaMsf_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[627], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblSira4BlokAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[628], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblKalanSiraBlokAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[629], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblTopicinGeriCekmeMsf_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[630], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblCatalYvsMsf_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[619], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblilkSiraKaydirmaMSF_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[641], 1, 9999, -9999);
            f.ShowDialog(this);
        }

        private void lblCatalAktifAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[618], 1, 9999, -9999);
            f.ShowDialog(this);
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

        private void btnCatalDevreyeAl_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[631]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[631], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[631], true, 1);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Client == null)
            {
                CPUbaglan();
                return;
            }
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
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 8, 0, 250, S7Consts.S7WLByte, DBEkran);
                    Result = Client.ReadArea(S7Consts.S7AreaMK, 0, 0, 320, S7Consts.S7WLByte, MarkersDB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 2, 0, 94, S7Consts.S7WLByte, DBCatal);
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

                lblTopBirakKnm.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 6))).ToString();
                lblBlokGenislik.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 8))).ToString();
                lblSira1BlokAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 10))).ToString();

                lblCatal1AcmaMsf.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 12))).ToString();
                lblSira2BlokAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 14))).ToString();
                lblAraBoslukMsf.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 16))).ToString();

                lblSira3BlokAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 18))).ToString();
                lblCatal2AcmaMsf.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 20))).ToString();
                lblSira4BlokAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 22))).ToString();

                lblKalanSiraBlokAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 24))).ToString();
                lblTopicinGeriCekmeMsf.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 26))).ToString();
                lblCatalYvsMsf.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 4))).ToString();
                lblilkSiraKaydirmaMSF.Text = (Convert.ToDouble(S7.GetWordAt(DBCatal, 28))).ToString();

                lblCATALRecete.Text = S7.GetStringAt(DBEkran, 180);
                lblCatalAktifPoz.Text = S7.GetIntAt(DBCatal, 0).ToString();
                lblCatalAktifAdet.Text = S7.GetIntAt(DBCatal, 2).ToString();

                if (S7.GetBitAt(DBEkran, 21, 5))
                {
                    btnCatalDevreyeAl.Text = "Çatal Açma Devrede";
                    btnCatalDevreyeAl.BackColor = Color.LimeGreen;

                }
                else
                {
                    btnCatalDevreyeAl.Text = "Çatal Açmayı Devreye Al";
                    btnCatalDevreyeAl.BackColor = Color.Gray;
                }


            }



        }

        private void CatalAcmaParametreleri_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;

            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            btnPnlKontrol.BackColor = Sistem.PanelsColor;


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
            button26.BackColor = Sistem.ustbuttoncolor;
            button32.BackColor = Sistem.ustbuttoncolor;
        }

        private void CatalAcmaParametreleri_Deactivate(object sender, EventArgs e)
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
    }
}
