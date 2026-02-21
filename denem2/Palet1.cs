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
    public partial class Palet1 : Form
    {
        private S7Client Client;
        private int Result;
        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBKalip = new byte[600];
        private byte[] DBEkran = new byte[400];
        public Palet1()
        {
            InitializeComponent();
            GoFullscreen(true);
            CustumizeDesign();
            
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

        private void Palet1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void lblP1BosPaletAdet_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[89], 1, 100, 0);
            f.ShowDialog(this);
        }
        private void lblP1ileriKalkSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[115], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblP1ileriKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[113], 100, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1ileriKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[114], 100,100, 0);
            f.ShowDialog(this);
        }

        private void lblP1ileriHizHarSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[112], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblP1ileriHizHarBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[110], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1ileriHizHarHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[111], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1ileriDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[108], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1ileriDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[109], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1geriKalkSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[107], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1geriKalkBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[105], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1geriKalkHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[106], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1geriHizHarSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[104], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1geriHizHarBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[102], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1geriHizHarHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[103], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1geriDurusBasinc_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[100], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1geriDurusHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[101], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1PaletAraKpmaSure_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[118], 100, 50, 0);
            f.ShowDialog(this);
        }

        private void lblP1PaletAraKpmaBas_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[116], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void lblP1PaletAraKpmaHiz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[117], 1, 100, 0);
            f.ShowDialog(this);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string sonuc =read_Tag(AlltagClass.ALLTagList[41]);
            Debug.WriteLine("azsdfasfasf " + sonuc);

            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[41], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[41], true, 1);
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

        private void btnOnceP1_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[39]);
            

            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[39], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[39], true, 1);
            }
        }

        private void btnOncep3_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[38]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[38], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[38], true, 1);
            }
        }

        private void btnParaKapat_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[42]);


            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[42], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[42], true, 1);
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
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 4, 40, 548, S7Consts.S7WLByte, DBKalip);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 8, 0, 250, S7Consts.S7WLByte, DBEkran);
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


                lblP1ileriKalkSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 0)) / 100).ToString();
                lblP1ileriKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 4))).ToString();
                lblP1ileriKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 6))).ToString();

                lblP1ileriHizHarSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 8)) / 100).ToString();
                lblP1ileriHizHarBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 12))).ToString();
                lblP1ileriHizHarHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 14))).ToString();

                lblP1ileriDurusBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 16))).ToString();
                lblP1ileriDurusHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 18))).ToString();



                lblP1geriKalkSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 20)) / 100).ToString();
                lblP1geriKalkBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 24))).ToString();
                lblP1geriKalkHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 26))).ToString();

                lblP1geriHizHarSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 28)) / 100).ToString();
                lblP1geriHizHarBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 32))).ToString();
                lblP1geriHizHarHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 34))).ToString();

                lblP1geriDurusBasinc.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 36))).ToString();
                lblP1geriDurusHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 38))).ToString();


                lblP1PaletAraKpmaSure.Text = (Convert.ToDouble(S7.GetDWordAt(DBKalip, 20)) / 100).ToString();
                lblP1PaletAraKpmaBas.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 24))).ToString();
                lblP1PaletAraKpmaHiz.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 24))).ToString();

                lblP1BosPaletAdet.Text = (Convert.ToDouble(S7.GetWordAt(DBKalip, 250))).ToString();

                if (S7.GetBitAt(DBEkran, 20, 5))
                    btnP23Ayri.BackColor = Color.Green;
                else
                    btnP23Ayri.BackColor = Color.Gray;

                if (S7.GetBitAt(DBEkran, 20, 7))
                    btnOnceP1.BackColor = Color.Green;
                else
                    btnOnceP1.BackColor = Color.Gray;
                if (S7.GetBitAt(DBEkran, 20, 6))
                    btnOncep3.BackColor = Color.Green;
                else
                    btnOncep3.BackColor = Color.Gray;
                if (S7.GetBitAt(DBEkran, 21, 1))
                    btnParaKapat.BackColor = Color.Green;
                else
                    btnParaKapat.BackColor = Color.Gray;
            }
        }

        private void Palet1_Load(object sender, EventArgs e)
        {
            CPUbaglan();
        }

        private void Palet1_Activated(object sender, EventArgs e)
        {
            Debug.WriteLine("Palet 1 Aktif edildi0");
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        private void Palet1_Deactivate(object sender, EventArgs e)
        {
            Debug.WriteLine("Palet 1 Deaktif edildi0");
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
