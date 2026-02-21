using System;
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
using System.Linq.Expressions;

namespace denem2
{
    public partial class Vibrasyon : Form
    {
        private S7Client Client;
        private int Result;


       
        private byte[] MarkersDB = new byte[65536];
       
        private byte[] DBKalip = new byte[600];

        private byte[] timer113DB = new byte[36];

        private byte[] DB7 = new byte[350];
        private byte[] Db2000 = new byte[260];
        public Vibrasyon()
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
                if (Result == 0)
                {
                    vibbglntld.BackColor = Color.Green;
                }
                else
                {
                    vibbglntld.BackColor = Color.Blue;

                }
            }
            else
            {


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

                    Int16 val = Convert.ToInt16(othersvalue);

                    realArray = BitConverter.GetBytes(Convert.ToInt16(val));
                    Array.Reverse(realArray);
                    byte[] aa = realArray;

                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLInt, aa);
                    return Result;
                }
                else if (gelentag.Tip == "dint")
                {
                    byte[] realArray = new byte[4];
                    Int32 val = Convert.ToInt32(othersvalue);
                    realArray = BitConverter.GetBytes(val);
                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDInt, realArray);
                    return Result;
                }
                else if (gelentag.Tip == "real")
                {
                    byte[] realArray = new byte[4];
                    int val = Convert.ToInt32(othersvalue);
                    realArray = BitConverter.GetBytes(val);
                    Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLReal, realArray);
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

        private void aravb1strt_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[78], 100, 9999, 0);
            f.ShowDialog(this);
        }

        private void aravb2strt_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[80], 100, 9999, 0);
            f.ShowDialog(this);
        }

        private void ustklpvbbkl_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[93], 100, 9999, 0);
            f.ShowDialog(this);
        }

        private void vbbklsr_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[165], 100, 9999, 0);
            f.ShowDialog(this);
        }

        private void hrcyervbhz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[659], 10, 9999, 0);

            f.ShowDialog(this);
        }

        private void aravbhz_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[649], 10, 9999, 0);
            f.ShowDialog(this);
        }

        private void bskvbhz_Click(object sender, EventArgs e)
        {


            if ((S7.GetIntAt(MarkersDB, 234) == 2945))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[651], 10, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void bvsifre_Click(object sender, EventArgs e)
        {

            Form f = new Calculator(AlltagClass.ALLTagList[442], 10, 9999, 0);
            f.ShowDialog(this);



        }

        private void vbbshz_Click(object sender, EventArgs e)
        {
            if ((S7.GetIntAt(MarkersDB, 234) == 2945))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[648], 10, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void vbklkrmp_Click(object sender, EventArgs e)
        {
            if ((S7.GetIntAt(MarkersDB, 234) == 2945))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[653], 1000, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void vbdrsrmp_Click(object sender, EventArgs e)
        {
            if ((S7.GetIntAt(MarkersDB, 234) == 2945))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[654], 1000, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void aravb1sr_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[77], 100, 9999, 0);
            f.ShowDialog(this);

        }

        private void aravb2sr_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[79], 100, 9999, 0);
            f.ShowDialog(this);
        }

        private void vbdvmsr_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[166], 100, 9999, 0);
            f.ShowDialog(this);
        }

        private void hrcyeradt_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[167], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void hrcyeradt2_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[660], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void Vibrasyon_Load(object sender, EventArgs e)
        {
            CPUbaglan();
           
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

                    Result = Client.ReadArea(S7Consts.S7AreaDB, 2000, 0, 260, S7Consts.S7WLByte, Db2000);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 4, 0, 548, S7Consts.S7WLByte, DBKalip);
                    Result = Client.ReadArea(S7Consts.S7AreaMK, 0, 0, 320, S7Consts.S7WLByte, MarkersDB);
                    ShowResult(Result);
                    ALLAlarmListClass.AlarmlariOku(Client);
                    writePLC(AlltagClass.ALLTagList[442], false, 0);
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

                vbsifre.Text = ((Convert.ToDouble(S7.GetIntAt(MarkersDB, 234)))).ToString();


                aravb1strt.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, 208))) / 100).ToString();
                aravb2strt.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, 212))) / 100).ToString();
                ustklpvbbkl.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, 390))) / 100).ToString();
                vbbklsr.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, 188))) / 100).ToString();

                vbbshz.Text = ((Convert.ToDouble(S7.GetIntAt(DBKalip, 512))) / 10).ToString();
                hrcyervbhz.Text = ((Convert.ToDouble(S7.GetIntAt(DBKalip, 530))) / 10).ToString();
                aravbhz.Text = ((Convert.ToDouble(S7.GetIntAt(DBKalip, 514))) / 10).ToString();
                bskvbhz.Text = ((Convert.ToDouble(S7.GetIntAt(DBKalip, 518))) / 10).ToString();

                vbklkrmp.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, 522))) / 1000).ToString();
                vbdrsrmp.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, 526))) / 1000).ToString();

                aravb1sr.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, 200))) / 100).ToString();
                aravb2sr.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, 204))) / 100).ToString();
                vbdvmsr.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, 184))) / 100).ToString();

                hrcyeradt.Text = ((Convert.ToDouble(S7.GetIntAt(DBKalip, 216)))).ToString();
                hrcyeradt2.Text = ((Convert.ToDouble(S7.GetIntAt(DBKalip, 532)))).ToString();



                if ((S7.GetIntAt(MarkersDB, 234) == 2945))
                { }

                int k = Convert.ToInt16(S7.GetIntAt(Db2000, 4));
                //Vibdurum2
                switch (k)
                {
                    case var Expression when (1<k && k<11):
                        vbdurumlbl.Text = "RUN";
                        vbdurumlbl.BackColor = Color.LimeGreen;
                        vbdurum.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   Run");
                        break;
                    case var Expression when (33 < k && k < 256):
                        vbdurumlbl.Text = "ARIZA";
                        vbdurumlbl.BackColor = Color.Red;
                        vbdurum.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   Arıza");
                        break;
                    case var Expression when (0 == k ):
                        vbdurumlbl.Text = "READY";
                        vbdurumlbl.BackColor = Color.DodgerBlue;
                        vbdurum.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   Ready");
                        break;
                    case var Expression when (333 == k):
                        vbdurumlbl.Text = "CMARIZA";
                        vbdurumlbl.BackColor = Color.DodgerBlue;
                        vbdurum.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   CMARIZA");
                        break;
                       
                    default:
                        vbdurumlbl.Text = "DEFAULT";
                        vbdurumlbl.BackColor = Color.DodgerBlue;
                        vbdurum.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   DEFAULT");
                        break;
                       
                }

                //Vibdurum2

                int m = Convert.ToInt16(S7.GetIntAt(Db2000, 44));
                //Vibdurum2
                switch (m)
                {
                    case var Expression when (1 < m && m < 11):
                        Vibdurum2.Text = "RUN";
                        Vibdurum2.BackColor = Color.LimeGreen;
                        Vibdurum2.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   Run");
                        break;
                    case var Expression when (33 < m && m < 256):
                        Vibdurum2.Text = "ARIZA";
                        Vibdurum2.BackColor = Color.Red;
                        Vibdurum2.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   Arıza");
                        break;
                    case var Expression when (0 == m):
                        Vibdurum2.Text = "READY";
                        Vibdurum2.BackColor = Color.DodgerBlue;
                        Vibdurum2.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   Ready");
                        break;
                    case var Expression when (333 == m):
                        Vibdurum2.Text = "CMARIZA";
                        Vibdurum2.BackColor = Color.DodgerBlue;
                        vbdurum.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   CMARIZA");
                        break;

                    default:
                        Vibdurum2.Text = "DEFAULT";
                        Vibdurum2.BackColor = Color.DodgerBlue;
                        Vibdurum2.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 4)))).ToString() + "   DEFAULT");
                        break;
                }

                        if (((Convert.ToDouble(S7.GetIntAt(Db2000, 160))) == 55) || ((Convert.ToDouble(S7.GetIntAt(Db2000, 160)))) == 1079)
                {
                    vbdurumlbl.Text = "RUN";
                    vbdurumlbl.BackColor = Color.LimeGreen;
                    vbdurum.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 160)))).ToString() + "   Run");
                }

                if ((Convert.ToDouble(S7.GetIntAt(Db2000, 160))) == 51)
                {
                    vbdurumlbl.Text = "READY";
                    vbdurumlbl.BackColor = Color.DodgerBlue;
                    vbdurum.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 160)))).ToString() + "   Ready");
                }


                if (((Convert.ToDouble(S7.GetIntAt(Db2000, 160))) == 0) || ((((Convert.ToDouble(S7.GetIntAt(Db2000, 160))) < 50)) && (((Convert.ToDouble(S7.GetIntAt(Db2000, 160))) > 33))) || ((Convert.ToDouble(S7.GetIntAt(Db2000, 160))) == 56))
                {
                    vbdurumlbl.Text = "ARIZA";
                    vbdurumlbl.BackColor = Color.Red;
                    vbdurum.Text = (((Convert.ToDouble(S7.GetIntAt(Db2000, 160)))).ToString() + "   Arıza");
                }

                // vbdurum.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 160)))).ToString();
                vbmfre.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 162))) / 10).ToString();
                bvreffre.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 164))) / 10).ToString();
                vbmtrakm.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 166))) / 10).ToString();
                vbmtrtrk.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 168))) / 10).ToString();

                vbgrsvlt.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 172))) / 10).ToString();
                vbmtrvlt.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 174))) / 10).ToString();
                vbscklk.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 176))) / 10).ToString();
                vbmtrgc.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 180))) / 10).ToString();

                vbps2.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 182))) / 10).ToString();
                vbps3.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 184))) / 10).ToString();
                vbps4.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 186))) / 10).ToString();
                vbps5.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 188))) / 10).ToString();
                vbps6.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 190))) / 10).ToString();
                vbps7.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 192))) / 10).ToString();
                vbps8.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 194))) / 10).ToString();
                vbps9.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 196))) / 10).ToString();

                vbacc.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 202))) / 10).ToString();
                vbdec.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 204))) / 10).ToString();

                vbht1.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 162))) / 10).ToString();
                vbht2.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 162))) / 10).ToString();
                vbht3.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 162))) / 10).ToString();
                vbht4.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 162))) / 10).ToString();
                vbht5.Text = ((Convert.ToDouble(S7.GetIntAt(Db2000, 162))) / 10).ToString();


            }
        }

        private void Vibrasyon_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        private void Vibrasyon_Deactivate(object sender, EventArgs e)
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
