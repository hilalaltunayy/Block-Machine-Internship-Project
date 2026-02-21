using Sharp7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace denem2
{
    public partial class HarcTeknesi : Form
    {
        private S7Client Client;
        private int Result;
        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBKalip = new byte[600];
        public HarcTeknesi()
        {
            InitializeComponent();
            GoFullscreen(true);
           
            CustumizeDesign();
            CheckForIllegalCrossThreadCalls = false;

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

        private void HarcTeknesi_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void lblHarcileriKalkSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[143], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblHarcileriHizHarSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[140], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblHarcileriHizHarBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[138], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcileriKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[141], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcileriKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[142], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcileriHizHarHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[139], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcileriDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[135], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcileriDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[136], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[136], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblHarcigAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[137], 1, 50, 0);
            f.ShowDialog(this);
        }

        private void lblHarcKapakAcmaKapaAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[94], 1, 50, 0);
            f.ShowDialog(this);
        }

        private void lblHarcgeriKalkSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[131], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblHarcgeriKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[129], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcgeriKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[130], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcgeriHizHarSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[128], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblHarcgeriHizHarBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[126], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcgeriHizHarHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[127], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcgeriDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[124], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcgeriDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[125], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcTekileriSalBas_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[144], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcTekileriSalHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[145], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcTekGeriSalSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[134], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblHarcTekGeriSalBas_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[132], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblHarcTekGeriSalHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[133], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void HarcTeknesi_Load(object sender, EventArgs e)
        {
            CPUbaglan();
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
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 4, 0, 548, S7Consts.S7WLByte, DBKalip);
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


                lblHarcileriKalkSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 0)) / 100).ToString();
                lblHarcileriKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 4))).ToString();
                lblHarcileriKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 6))).ToString();

                lblHarcileriHizHarSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 8)) / 100).ToString();
                lblHarcileriHizHarBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 12))).ToString();
                lblHarcileriHizHarHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 14))).ToString();

                lblHarcileriDurusBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 16))).ToString();
                lblHarcileriDurusHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 18))).ToString();



                lblHarcgeriKalkSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 20)) / 100).ToString();
                lblHarcgeriKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 24))).ToString();
                lblHarcgeriKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 26))).ToString();

                lblHarcgeriHizHarSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 28)) / 100).ToString();
                lblHarcgeriHizHarBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 32))).ToString();
                lblHarcgeriHizHarHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 34))).ToString();

                lblHarcgeriDurusBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 36))).ToString();
                lblHarcgeriDurusHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 38))).ToString();


                lblHarcKapakacikSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 394)) / 100).ToString();
                lblHarcKapakAcmaKapaAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 398))).ToString();
                lblHarcigAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 218))).ToString();

                lblHarcTekGeriSalSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 412)) / 100).ToString();
                lblHarcTekGeriSalBas.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 272))).ToString();
                lblHarcTekGeriSalHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 274))).ToString();


                lblHarcTekileriSalBas.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 264))).ToString();
                lblHarcTekileriSalHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 266))).ToString();


            }
        }

        private void HarcTeknesi_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
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
