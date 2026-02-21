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
    public partial class AltKalip : Form
    {
        private S7Client Client;
        private int Result;
        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBKalip = new byte[600];
        
        private int baglanmasayisi = 0;
        public AltKalip()
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
            //Ekranlar.HarcTeknesiScreen.Show();
            // this.Show();
            //this.Close();

        }

        private void btnPalet1(object sender, EventArgs e)
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
        private void btnPalet3(object sender, EventArgs e)
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

        private void AltKalip_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Application.Exit();
        }

        private void lblAltYukKalkSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[76], 100, 50, 0);
            f.ShowDialog(this);
        }

       
        private void test(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void lblAltYukKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[74], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltYukKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[75], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltYukHizHarSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[73], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblAltYukHizHarBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[71], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltYukHizHarHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[72], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltYukDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[69], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltYukDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[70], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblUstKilitSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[96], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblAltAsgKalkSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[67], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblAltAsgKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[65], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltAsgKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[66], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltAsgHizHarSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[64], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblAltAsgHizHarBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[62], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltAsgHizHarHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[63], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltAsgDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[60], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblAltAsgDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[61], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Result != 0 || !Client.Connected){

                CPUbaglan();
                return;
            }
            try
            {
               
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

                
                lblAltYukKalkSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 102)) / 100).ToString();
                lblAltYukKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 106))).ToString();
                lblAltYukKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 108))).ToString();

                lblAltYukHizHarSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 110)) / 100).ToString();
                lblAltYukHizHarBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 114))).ToString();
                lblAltYukHizHarHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 116))).ToString();

                lblAltYukDurusBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 120))).ToString();
                lblAltYukDurusHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 122))).ToString();

                lblUstKilitSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 228)) / 100).ToString();

                lblAltAsgKalkSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 80)) / 100).ToString();
                lblAltAsgKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 84))).ToString();
                lblAltAsgKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 86))).ToString();

                lblAltAsgHizHarSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 88)) / 100).ToString();
                lblAltAsgHizHarBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 92))).ToString();
                lblAltAsgHizHarHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 94))).ToString();

                lblAltAsgDurusBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 98))).ToString();
                lblAltAsgDurusHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 100))).ToString();

               

            }
        }
        private void CPUbaglan()
        {
            try
            {
                Client = new S7Client();
                Result = Client.ConnectTo("192.168.0.2", 0, 0);
                ShowResult(Result);
                timer1.Enabled = true;
            }
            catch(Exception ex)
            {
                ShowResult(Result);
            }
           
        }
        private void AltKalip_Load(object sender, EventArgs e)
        {
            CPUbaglan();
            Debug.WriteLine("Alt Kalıp Load");

            // backgroundWorker1.RunWorkerAsync();

            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            panel1.BackColor = Sistem.PanelsColor;
            groupBox2.BackColor = Sistem.PanelsColor;
            groupBox3.BackColor = Sistem.PanelsColor;


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
            button30.BackColor = Sistem.ustbuttoncolor;
            button32.BackColor = Sistem.ustbuttoncolor;
        }

        private void AltKalip_Activated(object sender, EventArgs e)
        {
            if(!timer1.Enabled)
                timer1.Enabled=true;

            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            panel1.BackColor = Sistem.PanelsColor;
            groupBox2.BackColor = Sistem.PanelsColor;
            groupBox3.BackColor = Sistem.PanelsColor;


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
            button30.BackColor = Sistem.ustbuttoncolor;
            button32.BackColor = Sistem.ustbuttoncolor;

        }

        private void AltKalip_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }
    }
}
