using Sharp7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace denem2
{
    public partial class UstKalip : Form
    {
        private S7Client Client;
        private int Result;


        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBKalip = new byte[600];

       
        public UstKalip()
        {
            InitializeComponent();
            

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
     
        private void UstKalip_Load(object sender, EventArgs e)
        {
           
            GoFullscreen(true);
            CustumizeDesign();
            
            CPUbaglan();
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
            //Ekranlar.HarcTeknesiScreen.Show();
            // this.Show();
            //this.Close();

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

        private void UstKalip_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void lblUstYukKalkSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[164], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
            timer1.Enabled = false;
            Application.Exit();
        }

        private void lblUstYukKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[162], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstYukKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[163], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstYukHizHarSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[161], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblUstYukHizHarBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[159], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstYukHizHarHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[160], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstYukDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[157], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstYukDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[158], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstAsgKalkSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[155], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblUstAsgKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[153], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstAsgKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[154], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstAsgHizHarSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[152], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblUstAsgHizHarBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[150], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstAsgHizHarHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[151], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstAsgDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[148], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstAsgDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[149], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstSekmedeStartSur_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[122], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblUstSekmedeYukSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[123], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblUstPalet1BekSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[99], 100, 50, 0);
            f.ShowDialog(this);
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
                    }
                    if (ALLAlarmListClass.AktifAlarmList.Count == 0)
                    {
                        button21.Text = "Alarm ";
                        button21.BackColor = Sistem.AlarmbuttonColor;
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


                lblUstYukKalkSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 124)) / 100).ToString();
                lblUstYukKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 128))).ToString();
                lblUstYukKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 130))).ToString();

                lblUstYukHizHarSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 132)) / 100).ToString();
                lblUstYukHizHarBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 136))).ToString();
                lblUstYukHizHarHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 138))).ToString();

                lblUstYukDurusBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 142))).ToString();
                lblUstYukDurusHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 144))).ToString();

                lblUstAsgKalkSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 146)) / 100).ToString();
                lblUstAsgKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 150))).ToString();
                lblUstAsgKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 152))).ToString();

                lblUstAsgHizHarSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 154)) / 100).ToString();
                lblUstAsgHizHarBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 158))).ToString();
                lblUstAsgHizHarHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 160))).ToString();

                lblUstAsgDurusBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 164))).ToString();
                lblUstAsgDurusHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 166))).ToString();

                lblUstSekmedeStartSur.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 220)) / 100).ToString();
                lblUstSekmedeYukSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 224)) / 100).ToString();
                lblUstPalet1BekSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 416)) / 100).ToString();

            }
        }

        private void UstKalip_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        private void UstKalip_Deactivate(object sender, EventArgs e)
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
