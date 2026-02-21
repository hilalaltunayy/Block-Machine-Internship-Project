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
    public partial class ToplamaParametreleri : Form
    {
        private S7Client Client;
        private int Result;


        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBPaketleme = new byte[600];
        public ToplamaParametreleri()
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
        private void timer1_Tick(object sender, EventArgs e)
        {
           if(!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();


        }

        private void lblTopYukarıDurKon_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[295], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopAssagiLimKon_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[248], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopilkSıraKon_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[223], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblMalAraMesafe_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[225], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblMalYukseklik_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[226], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopileriGeriSerKon_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[218], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopileriLimKon_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[220], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopileriYavasKon_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[222], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopGeriYavasKon_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[217], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopGeriLimKon_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[215], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblileriHareketYukAsgSerKon_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[299], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblSira3icinTopBekleme_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[614], 1, 10, 0);
            f.ShowDialog(this);
        }

        private void lblTopCalTipi_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[297], 1, 5, 0);
            f.ShowDialog(this);
        }

        private void lblKatmerBantSaymaAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[224], 1, 30, 0);
            f.ShowDialog(this);
        }

        private void lblTopCeneSikmaModu_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[209], 1, 10, 0);
            f.ShowDialog(this);
        }

        private void lblTopSikistirma1SetBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[228], 1, 500, 0);
            f.ShowDialog(this);
        }

        private void lblTopSikistirma2SetBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[227], 1, 500, 0);
            f.ShowDialog(this);
        }

        private void lblTopCozSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[271], 1, 10, 0);
            f.ShowDialog(this);
        }

        private void lblTopGeriCozSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[272], 1, 10, 0);
            f.ShowDialog(this);
        }

        private void lblTopCevirmeHizliSüre_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[266], 1, 10, 0);
            f.ShowDialog(this);
        }

        private void lblTopSikistirma1MaxSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[231], 1, 10, 0);
            f.ShowDialog(this);
        }

        private void lblTopSikistirma2MaxSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[230], 1, 10, 0);
            f.ShowDialog(this);
        }

        private void lblTopCatalAcmaBirakma_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[642], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopCevirmeBirakma_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[643], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopCevirmeAlma_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[644], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTopCatalAcmaSıkmaCene_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[645], 1, 9999, 0);
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

        private void btn1SiraCevrilecek_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[232]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[232], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[232], true, 1);
            }
        }

        private void btn2SiraDüz_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[240]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[240], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[240], true, 1);
            }
        }

        private void btn3SiraCevrilecek_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[241]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[241], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[241], true, 1);
            }
        }

        private void btn4SiraDüz_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[242]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[242], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[242], true, 1);
            }
        }

        private void btn5SiraCevrilecek_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[243]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[243], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[243], true, 1);
            }
        }

        private void btn6SiraDüz_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[244]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[244], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[244], true, 1);
            }
        }

        private void btn7SiraCevrilecek_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[245]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[245], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[245], true, 1);
            }
        }

        private void btn8SiraDüz_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[246]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[246], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[246], true, 1);
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

                    Result = Client.ReadArea(S7Consts.S7AreaDB, 6, 0, 198, S7Consts.S7WLByte, BufferDB6);
                    Result = Client.ReadArea(S7Consts.S7AreaMK, 0, 0, 320, S7Consts.S7WLByte, MarkersDB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 3, 0, 282, S7Consts.S7WLByte, DBPaketleme);
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
                lblTopYukarıDurKon.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 74))).ToString();
                lblTopAssagiLimKon.Text = (Convert.ToDouble(S7.GetDIntAt(DBPaketleme, 78))).ToString();
                lblTopilkSıraKon.Text = (Convert.ToDouble(S7.GetDIntAt(DBPaketleme, 92))).ToString();
                lblMalAraMesafe.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 88))).ToString();
                lblMalYukseklik.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 82))).ToString();
                lblTopileriGeriSerKon.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 166))).ToString();

                lblTopileriLimKon.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 154))).ToString();
                lblTopileriYavasKon.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 170))).ToString();
                lblTopGeriYavasKon.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 174))).ToString();
                lblTopGeriLimKon.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 158))).ToString();
                lblileriHareketYukAsgSerKon.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 162))).ToString();
                lblSira3icinTopBekleme.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 226))).ToString();


                lblTopCalTipi.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 14))).ToString();
                lblKatmerBantSaymaAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 136))).ToString();
                lblTopCeneSikmaModu.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 234))).ToString();
                lblTopSikistirma1SetBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 86))).ToString();
                lblTopSikistirma2SetBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 236))).ToString();

                lblTopCozSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 4))).ToString();
                lblTopGeriCozSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 206))).ToString();
                lblTopCevirmeHizliSüre.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 202))).ToString();
                lblTopSikistirma1MaxSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 194))).ToString();
                lblTopSikistirma2MaxSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 198))).ToString();


                lblTopCatalAcmaBirakma.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 186))).ToString();
                lblTopCevirmeBirakma.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 246))).ToString();
                lblTopCevirmeAlma.Text = (Convert.ToDouble(S7.GetIntAt(DBPaketleme, 248))).ToString();
                lblTopCatalAcmaSıkmaCene.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 250))).ToString();

                if (S7.GetBitAt(DBPaketleme, 254, 0))
                {
                    btn1SiraCevrilecek.BackColor = Color.Green;
                    btn1SiraCevrilecek.Text = "1. Sıra Çevrilecek";
                }
                else
                {
                    btn1SiraCevrilecek.BackColor = Color.Gray;
                    btn1SiraCevrilecek.Text = "1. Sıra Düz";
                }


                if (S7.GetBitAt(DBPaketleme, 254, 1))
                {
                    btn2SiraDüz.BackColor = Color.Green;
                    btn2SiraDüz.Text = "2. Sıra Çevrilecek";
                }
                else
                {
                    btn2SiraDüz.BackColor = Color.Gray;
                    btn2SiraDüz.Text = "2. Sıra Düz";
                }

                if (S7.GetBitAt(DBPaketleme, 254, 2))
                {
                    btn3SiraCevrilecek.BackColor = Color.Green;
                    btn3SiraCevrilecek.Text = "3. Sıra Çevrilecek";
                }
                else
                {
                    btn3SiraCevrilecek.BackColor = Color.Gray;
                    btn3SiraCevrilecek.Text = "3. Sıra Düz";
                }

                if (S7.GetBitAt(DBPaketleme, 254, 3))
                {
                    btn4SiraDüz.BackColor = Color.Green;
                    btn4SiraDüz.Text = "4. Sıra Çevrilecek";
                }
                else
                {
                    btn4SiraDüz.BackColor = Color.Gray;
                    btn4SiraDüz.Text = "4. Sıra Düz";
                }

                if (S7.GetBitAt(DBPaketleme, 254, 4))
                {
                    btn5SiraCevrilecek.BackColor = Color.Green;
                    btn5SiraCevrilecek.Text = "5. Sıra Çevrilecek";
                }
                else
                {
                    btn5SiraCevrilecek.BackColor = Color.Gray;
                    btn5SiraCevrilecek.Text = "5. Sıra Düz";
                }

                if (S7.GetBitAt(DBPaketleme, 254, 5))
                {
                    btn6SiraDüz.BackColor = Color.Green;
                    btn6SiraDüz.Text = "6. Sıra Çevrilecek";
                }
                else
                {
                    btn6SiraDüz.BackColor = Color.Gray;
                    btn6SiraDüz.Text = "6. Sıra Düz";
                }

                if (S7.GetBitAt(DBPaketleme, 254, 6))
                {
                    btn7SiraCevrilecek.BackColor = Color.Green;
                    btn7SiraCevrilecek.Text = "7. Sıra Çevrilecek";
                }
                else
                {
                    btn7SiraCevrilecek.BackColor = Color.Gray;
                    btn7SiraCevrilecek.Text = "7. Sıra Düz";
                }

                if (S7.GetBitAt(DBPaketleme, 254, 7))
                {
                    btn8SiraDüz.BackColor = Color.Green;
                    btn8SiraDüz.Text = "8. Sıra Çevrilecek";
                }
                else
                {
                    btn8SiraDüz.BackColor = Color.Gray;
                    btn8SiraDüz.Text = "8. Sıra Düz";
                }
            }
        }

        private void ToplamaParametreleri_Activated(object sender, EventArgs e)
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
            button31.BackColor = Sistem.ustbuttoncolor;
        }

        private void ToplamaParametreleri_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }

        private void ToplamaParametreleri_Load(object sender, EventArgs e)
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
            button31.BackColor = Sistem.ustbuttoncolor;
        }

        
    }
}
