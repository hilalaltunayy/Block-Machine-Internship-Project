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
    public partial class ToplamaYuk_Asg : Form
    {
        private S7Client Client;
        private int Result;


        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBPaketleme = new byte[600];
        public ToplamaYuk_Asg()
        {
            InitializeComponent();
            GoFullscreen(true);
            CustumizeDesign();
            //
            
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void label51_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();


        }
        private void lblileriTopYukKalkKonum_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[282], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopYukKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[288], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopYukKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[290], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopYukHizliHarekBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[284], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopYukHizliHarekHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[286], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopYukDurusKonum_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[293], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopYukDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[278], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopYukDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[280], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopAssagiKalkKonum_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[255], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopAssagiKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[261], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopAssagiKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[263], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopAssagiHizliHarekBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[257], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopAssagiHizliHarekHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[259], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopAssagiDurKonum_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[265], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopAssagiDurBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[251], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblileriTopAssagiDurHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[253], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopYukKalkKonum_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[283], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopYukKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[289], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopYukKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[292], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopYukHizliHarekBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[285], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopYukHizliHarekHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[287], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopYukDurKonum_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[294], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopYukDurBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[279], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopYukDurHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[281], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopAssagiKalkKonum_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[254], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopAssagiKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[260], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopAssagiKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[262], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopAssagiHizliHarekBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[256], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopAssagiHizliHarekHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[258], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopAssagiDurusKonum_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[264], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopAssagiDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[250], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblGeriTopAssagiDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[252], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblTopCene1SikistirBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[275], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblTopCene1SikistirHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[276], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblTopCene1CozBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[269], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblTopCene1CozHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[270], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblTopCene2SikistirBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[273], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblTopCene2SikistirHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[274], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblTopCene2CozBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[267], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblTopCene2CozHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[268], 1, 100, 0);
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


                lblileriTopYukKalkKonum.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 22))).ToString();
                lblileriTopYukKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 18))).ToString();
                lblileriTopYukKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 20))).ToString();

                lblileriTopYukHizliHarekBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 26))).ToString();
                lblileriTopYukHizliHarekHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 28))).ToString();

                lblileriTopYukDurKonum.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 30))).ToString();
                lblileriTopYukDurBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 34))).ToString();
                lblileriTopYukDurHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 36))).ToString();


                lblileriTopAssagiKalkKonum.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 120))).ToString();
                lblileriTopAssagiKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 116))).ToString();
                lblileriTopAssagiKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 118))).ToString();

                lblileriTopAssagiHizliHarekBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 124))).ToString();
                lblileriTopAssagiHizliHarekHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 126))).ToString();

                lblileriTopAssagiDurKonum.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 128))).ToString();
                lblileriTopAssagiDurBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 132))).ToString();
                lblileriTopAssagiDurHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 134))).ToString();



                lblGeriTopYukKalkKonum.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 100))).ToString();
                lblGeriTopYukKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 96))).ToString();
                lblGeriTopYukKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 98))).ToString();

                lblGeriTopYukHizliHarekBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 104))).ToString();
                lblGeriTopYukHizliHarekHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 106))).ToString();

                lblGeriTopYukDurKonum.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 108))).ToString();
                lblGeriTopYukDurBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 112))).ToString();
                lblGeriTopYukDurHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 114))).ToString();


                lblGeriTopAssagiKalkKonum.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 42))).ToString();
                lblGeriTopAssagiKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 38))).ToString();
                lblGeriTopAssagiKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 40))).ToString();

                lblGeriTopAssagiHizliHarekBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 46))).ToString();
                lblGeriTopAssagiHizliHarekHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 48))).ToString();

                lblGeriTopAssagiDurKonum.Text = (Convert.ToDouble(S7.GetDWordAt(DBPaketleme, 50))).ToString();
                lblGeriTopAssagiDurBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 54))).ToString();
                lblGeriTopAssagiDurHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 56))).ToString();



                lblTopCene1SikistirBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 58))).ToString();
                lblTopCene1SikistirHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 60))).ToString();

                lblTopCene1CozBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 70))).ToString();
                lblTopCene1CozHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 72))).ToString();


                lblTopCene2SikistirBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 238))).ToString();
                lblTopCene2SikistirHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 240))).ToString();

                lblTopCene2CozBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 242))).ToString();
                lblTopCene2CozHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBPaketleme, 244))).ToString();
            }
        }

        private void ToplamaYuk_Asg_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        private void ToplamaYuk_Asg_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }

        private void ToplamaYuk_Asg_Load(object sender, EventArgs e)
        {
            if (Client == null)
            {
                CPUbaglan();
                return;
            }
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
