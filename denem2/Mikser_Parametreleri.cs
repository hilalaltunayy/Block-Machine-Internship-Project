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
    public partial class Mikser_Parametreleri : Form
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
        public Mikser_Parametreleri()
        {
            InitializeComponent();
            GoFullscreen(true);
            CustumizeDesign();
            //CPUbaglan();
            Debug.WriteLine("Mikser param ilk fons calisti");
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

        private void lblKuruKrsmSure_Click_1(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[199], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblSuluKrsmSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[203], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblHarcMaxSev_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[526], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblMikserKkSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[197], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblHarcMinSev_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[527], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblAsYukBekSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[176], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblAsAsagBekSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[177], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblCimSetDegeri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[185], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblCimBosSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[180], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblCimBosDevamSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[181], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblCimMaxAlimSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[309], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblCimSiloMaxKap_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[419], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblCimAlinanDegeri_Click(object sender, EventArgs e)
        {
           
        }

        private void lblCimBosDegeri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[184], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblCimHavadaDegeri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[183], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblKiriciKpkAcKptAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[194], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblKiriciDevamSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[193], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblKiriciBandStartSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[192], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void label41_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[205], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblBunkerToplam_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[480], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblKiriciSensorSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[196], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblKiriciValfiAcikKalmaSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[195], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblToprakBandiDevamSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[204], 1000, 9999, 0);
            f.ShowDialog(this);
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
        private void btnP23Ayri_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[50]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[50], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[50], true, 1);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[476]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[476], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[476], true, 1);
            }
        }

        private void btnOTMdara_Click_1(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[477]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[477], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[477], true, 1);
            }
        }

        private void btnNemSensoru_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[479]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[479], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[479], true, 1);
            }
        }

        private void lblTBunkerVibroStSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[510], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblTBunkerVibroStDevSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[511], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblKiriciKpkVibroStSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[512], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblKiriciKpkVibroStDevSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[535], 1, 9999, 0);
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
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 1, 0, 352, S7Consts.S7WLByte, DBMikser);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 112, 0, 12, S7Consts.S7WLByte, timer112DB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 113, 0, 12, S7Consts.S7WLByte, timer113DB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 8, 0, 250, S7Consts.S7WLByte, DBEkran8);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 9, 0, 144, S7Consts.S7WLByte, Db9);

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

                lblKuruKrsmSure.Text = ((Convert.ToDouble(S7.GetDWordAt(DBMikser, 30))) / 1000).ToString();
                lblSuluKrsmSure.Text = ((Convert.ToDouble(S7.GetDWordAt(DBMikser, 34))) / 1000).ToString();
                lblHarcMaxSev.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 12))).ToString();

                lblMikserKkSure.Text = ((Convert.ToDouble(S7.GetDWordAt(DBMikser, 38))) / 1000).ToString();
                lblHarcMinSev.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 14))).ToString();

                lblAsYukBekSure.Text = ((Convert.ToDouble(S7.GetDWordAt(DBMikser, 8))) / 1000).ToString();
                lblAsAsagBekSure.Text = ((Convert.ToDouble(S7.GetDWordAt(DBMikser, 58))) / 1000).ToString();

                lblCimSetDegeri.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 20))).ToString();
                lblCimBosSure.Text = ((Convert.ToDouble(S7.GetDWordAt(DBMikser, 44))) / 1000).ToString();
                lblCimBosDevamSure.Text = ((Convert.ToDouble(S7.GetDWordAt(DBMikser, 26))) / 1000).ToString();
                lblCimMaxAlimSure.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 72))) / 1000).ToString();
                lblCimSiloMaxKap.Text = (Convert.ToDouble(S7.GetRealAt(DBMikser, 114))).ToString();

                lblCimAlinanDegeri.Text = (Convert.ToDouble(S7.GetIntAt(BufferDB6, 36))).ToString();
                lblCimBosDegeri.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 42))).ToString();
                lblCimHavadaDegeri.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 78))).ToString();
                lblKiriciKpkAcKptAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 112))).ToString();

                lblKiriciDevamSure.Text = ((Convert.ToDouble(S7.GetDWordAt(DBMikser, 70))) / 1000).ToString();
                lblKiriciBandStartSure.Text = ((Convert.ToDouble(S7.GetDWordAt(DBMikser, 66))) / 1000).ToString();
                lblToprakBandStartSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBMikser, 54)) / 1000).ToString();
                lblBunkerToplam.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 148))).ToString();

                lblKiriciSensorSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBMikser, 74)) / 1000).ToString();
                lblKiriciValfiAcikKalmaSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBMikser, 0)) / 1000).ToString();
                lblToprakBandiDevamSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBMikser, 62)) / 1000).ToString();

                lblTBunkerVibroStSure.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 130))).ToString();
                lblTBunkerVibroStDevSure.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 132))).ToString();

                lblKiriciKpkVibroStSure.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 134))).ToString();
                lblKiriciKpkVibroStDevSure.Text = (Convert.ToDouble(S7.GetWordAt(DBMikser, 136))).ToString();


                if (S7.GetBitAt(DBEkran8, 21, 0))
                    btnSuAlimZamanli.BackColor = Color.LimeGreen;
                else
                    btnSuAlimZamanli.BackColor = Color.Gray;
                if (S7.GetBitAt(DBEkran8, 21, 2))
                    btnAsagidaBekle.BackColor = Color.LimeGreen;
                else
                    btnAsagidaBekle.BackColor = Color.Gray;
                if (S7.GetBitAt(DBEkran8, 21, 3))
                    btnOTMdara.BackColor = Color.LimeGreen;
                else
                    btnOTMdara.BackColor = Color.Gray;

                if (S7.GetBitAt(DBEkran8, 21, 7))
                    btnNemSensoru.BackColor = Color.LimeGreen;
                else
                    btnNemSensoru.BackColor = Color.Gray;
            }

        }

        private void Mikser_Parametreleri_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        private void Mikser_Parametreleri_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }

        private void Mikser_Parametreleri_Load(object sender, EventArgs e)
        {
            CPUbaglan();
            
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
