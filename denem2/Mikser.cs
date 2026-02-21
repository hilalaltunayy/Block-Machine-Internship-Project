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
    public partial class Mikser : Form
    {
        private S7Client Client;
        private int Result;


        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBPaketleme = new byte[600];
        private byte[] DBMikser = new byte[600];
        private byte[] timer112DB = new byte[36];
        private byte[] DBEkran8 = new byte[300];


        private byte[] timer113DB = new byte[36];
        public Mikser()
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

        protected string read_Tag(PLCTag gelentag)
        {
            if (gelentag.Area == "M")
            {
                if (gelentag.Tip == "bool")
                {
                    byte[] bytearray = new byte[1];

                    Result = Client.ReadArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLBit, bytearray);

                    return S7.GetBitAt(bytearray,0, gelentag.BitNo).ToString();
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

        private void btnCimentoHelezon_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[348]);

           
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[348], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[348], true, 1);
            }
        }

        private void btnKiriciKapak_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[361]);

          
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[361], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[361], true, 1);
            }
        }

        private void btnKirici_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[362]);

           
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[362], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[362], true, 1);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSuDolum_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[377]);

           
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[377], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[377], true, 1);
            }
        }

        private void btnCimentoKapak_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[377]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[347], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[347], true, 1);
            }
        }

        private void btnP23Ayri_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[616]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[616], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[616], true, 1);
            }
        }

        private void btnKiriciBandi_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[360]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[360], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[360], true, 1);
            }
        }

        private void btnToprakBandi_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[646]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[646], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[646], true, 1);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[416]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[416], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[416], true, 1);
            }
        }

        private void btnKpk1_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[673]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[673], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[673], true, 1);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[674]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[674], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[674], true, 1);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[675]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[675], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[675], true, 1);
            }
        }

        private void lblMalzKapakStart1_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[661], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblMalzKapakStart2_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[663], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblMalzKapakStart3_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[665], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblMalzKapakDevam1_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[662], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblMalzKapakDevam2_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[664], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblMalzKapakDevam3_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[666], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void btnHarcKStart_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[407], true, 21);
        }

        private void btnHarcKStop_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[407], true, 25);
        }

        private void btnKovadaBHazir_Click(object sender, EventArgs e)
        {
            BTNbimhazir.Visible = true;
            BTNbimhazir.Enabled = true;
           
        }

        private void btnHarcGondDevrede_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[400]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[400], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[400], true, 1);
            }
        }

        private void btnSurekliKrsm_Click(object sender, EventArgs e)
        {
            string sonuc = read_Tag(AlltagClass.ALLTagList[401]);
            if (sonuc == "True")
            {
                writePLC(AlltagClass.ALLTagList[401], false, 1);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[401], true, 1);
            }
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[407], true, 91);
        }

        private void lblGelenCim_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[34], 1, 99999, 0);
            f.ShowDialog(this);
        }

        private void lblKalanCim_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[34], 1, 9999, 0);
            f.ShowDialog(this);
        }
        private void tbKuruSetSure_Click(object sender, EventArgs e)
        {
            //Client.Disconnect();
            //timer1.Enabled = false;
            Form f = new Calculator(AlltagClass.ALLTagList[199], 1000, 250, 0);
            f.ShowDialog(this);
        }

        private void tbSuluSetSure_Click(object sender, EventArgs e)
        {
            //Client.Disconnect();
            //timer1.Enabled = false;
            Form f = new Calculator(AlltagClass.ALLTagList[203], 1000, 32000, 0);
            f.ShowDialog(this);
        }

        private void tbSetCimVal_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[185], 1, 250, 0);
            f.ShowDialog(this);
        }

        private void tbSetSuVa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[202], 1, 32000, 0);
            f.ShowDialog(this);

        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
           
                try
                {
                    Result = writePLC(AlltagClass.ALLTagList[407], false, 11);
                    ShowResult(Result);
                }
                catch (Exception m)
                {

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
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 1, 0, 320, S7Consts.S7WLByte, DBMikser);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 8, 0, 250, S7Consts.S7WLByte, DBEkran8);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 112, 0, 12, S7Consts.S7WLByte, timer112DB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 113, 0, 12, S7Consts.S7WLByte, timer113DB);

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
                        if (ALLAlarmListClass.AktifAlarmList.Count == 0)
                        {
                            button21.Text = "Alarm ";
                            button21.BackColor = Sistem.AlarmbuttonColor;
                        }
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
                lblLzrHarc.Text = S7.GetIntAt(BufferDB6, 94).ToString();
                tbMikserStep.Text = S7.GetIntAt(BufferDB6, 32).ToString();
                int mikserStep = S7.GetIntAt(BufferDB6, 32);
                lbKuruSure.Text = (S7.GetDWordAt(timer112DB, 8) / 1000).ToString();
                lbSuluSure.Text = (S7.GetDWordAt(timer113DB, 8) / 1000).ToString();
                tbKuruSetSure.Text = (Convert.ToDouble((S7.GetDWordAt(DBMikser, 30))) / 1000).ToString();
                double k = Convert.ToDouble(S7.GetDWordAt(DBMikser, 34)) / 1000;
                tbYapCim.Text = S7.GetIntAt(BufferDB6, 36).ToString();
                tbYapSu.Text = S7.GetIntAt(BufferDB6, 92).ToString();

                lblSifre.Text = S7.GetIntAt(MarkersDB, 234).ToString();
                lblKalanCim.Text = S7.GetRealAt(DBEkran8,8).ToString();
                lblGelenCim.Text= S7.GetRealAt(DBEkran8,12).ToString(); 

                tbSetCimVal.Text = S7.GetIntAt(DBMikser, AlltagClass.ALLTagList[185].Offset).ToString();
                tbSetSuVa.Text = S7.GetIntAt(DBMikser, AlltagClass.ALLTagList[202].Offset).ToString();
                tbSuluSetSure.Text = k.ToString();

                lblMalzKapakStart1.Text= (Convert.ToDouble((S7.GetDWordAt(DBMikser, 288))) / 1000).ToString();
                lblMalzKapakStart2.Text = (Convert.ToDouble((S7.GetDWordAt(DBMikser, 292))) / 1000).ToString();
                lblMalzKapakStart3.Text = (Convert.ToDouble((S7.GetDWordAt(DBMikser, 296))) / 1000).ToString();

                lblMalzKapakDevam1.Text = (Convert.ToDouble((S7.GetDWordAt(DBMikser, 304))) / 1000).ToString();
                lblMalzKapakDevam2.Text = (Convert.ToDouble((S7.GetDWordAt(DBMikser, 308))) / 1000).ToString();
                lblMalzKapakDevam3.Text = (Convert.ToDouble((S7.GetDWordAt(DBMikser, 312))) / 1000).ToString();

                if (S7.GetBitAt(BufferDB6, 3, 1))
                    snsMCalisti.BackColor = Color.LimeGreen;
                else
                    snsMCalisti.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 2))
                    snsKlepeKapali.BackColor = Color.LimeGreen;
                else
                    snsKlepeKapali.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 3))
                    snsKlepeAcik.BackColor = Color.LimeGreen;
                else
                    snsKlepeAcik.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 4))
                    snsAsYuk.BackColor = Color.LimeGreen;
                else
                    snsAsYuk.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 5))
                    snsAsAsagida.BackColor = Color.LimeGreen;
                else
                    snsAsAsagida.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 6))
                    snsAsBekleme.BackColor = Color.LimeGreen;
                else
                    snsAsBekleme.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 7))
                    snsEmniyet.BackColor = Color.LimeGreen;
                else
                    snsEmniyet.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 18, 5))//Harc Sevieye Max-min
                    snsHarcMax.BackColor = Color.LimeGreen;
                else
                    snsHarcMax.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 18, 6))
                    snsHarcMin.BackColor = Color.LimeGreen;
                else
                    snsHarcMin.BackColor = Color.Blue;

                //Kirici
                if (S7.GetBitAt(BufferDB6, 4, 1))
                    snsKiriciFotoseli.BackColor = Color.LimeGreen;
                else
                    snsKiriciFotoseli.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 4, 2))
                    snsKiriciAcil.BackColor = Color.LimeGreen;
                else
                    snsKiriciAcil.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 4, 3))
                    snsKiriciBantDur.BackColor = Color.LimeGreen;
                else
                    snsKiriciBantDur.BackColor = Color.Blue;


                bool kirici = S7.GetBitAt(BufferDB6, 15, 2);
                if (kirici)
                    btnKirici.BackColor = Color.LimeGreen;
                else
                    btnKirici.BackColor = Color.Gray;
                bool kiriciBandi = S7.GetBitAt(BufferDB6, 15, 3);
                if (kiriciBandi)
                    btnKiriciBandi.BackColor = Color.LimeGreen;
                else
                    btnKiriciBandi.BackColor = Color.Gray;
                bool CimHelezon = S7.GetBitAt(BufferDB6, 14, 7);
                if (CimHelezon)
                    btnCimentoHelezon.BackColor = Color.LimeGreen;
                else
                    btnCimentoHelezon.BackColor = Color.Gray;

                bool KiriciKapak = S7.GetBitAt(BufferDB6, 14, 6);
                if (KiriciKapak)
                    btnKiriciKapak.BackColor = Color.LimeGreen;
                else
                    btnKiriciKapak.BackColor = Color.Gray;

                bool CimBasolt = S7.GetBitAt(BufferDB6, 14, 5);
                if (CimBasolt)
                    btnCimentoKapak.BackColor = Color.LimeGreen;
                else
                    btnCimentoKapak.BackColor = Color.Gray;


                bool sudolum = S7.GetBitAt(BufferDB6, 14, 4);
                if (sudolum)
                    btnSuDolum.BackColor = Color.Blue;
                else
                    btnSuDolum.BackColor = Color.Gray;

                bool toprakbandi = S7.GetBitAt(BufferDB6, 18, 1);
                if (toprakbandi)
                    btnToprakBandi.BackColor = Color.LimeGreen;
                else
                    btnToprakBandi.BackColor = Color.Gray;

                bool kapak1led = S7.GetBitAt(BufferDB6, 108, 3);
                if (kapak1led)
                    btnKpk1.BackColor = Color.LimeGreen;
                else
                    btnKpk1.BackColor = Color.Gray;

                bool kapak2led = S7.GetBitAt(BufferDB6, 108, 4);
                if (kapak2led)
                    btnKpk2.BackColor = Color.LimeGreen;
                else
                    btnKpk2.BackColor = Color.Gray;


                bool kapak3led = S7.GetBitAt(BufferDB6, 108, 5);
                if (kapak3led)
                    btnKpk3.BackColor = Color.LimeGreen;
                else
                    btnKpk3.BackColor = Color.Gray;


                if (S7.GetBitAt(MarkersDB, 26, 5))
                {
                    btnKiriciDevAl.BackColor = Color.LimeGreen;
                    btnKiriciDevAl.Text = "KIRICILAR DEVREDE";
                }
                else
                {
                    btnKiriciDevAl.BackColor = Color.Gray;
                    btnKiriciDevAl.Text = "KIRICILARI DEVREYE AL";
                }

                if (S7.GetBitAt(BufferDB6, 19, 5))
                {
                    btnSurekliKrsm.BackColor = Color.LimeGreen;
                    btnSurekliKrsm.Text = "Sürekli Karışım";
                }
                else
                {
                    btnSurekliKrsm.BackColor = Color.Gray;
                    btnSurekliKrsm.Text = "Tekli Karışım";
                }
                if (S7.GetBitAt(BufferDB6, 19, 6))
                {
                    btnHarcGondDevrede.BackColor = Color.LimeGreen;
                    btnHarcGondDevrede.Text = "Harç Gönderme Devrede";
                }
                else
                {
                    btnHarcGondDevrede.BackColor = Color.Gray;
                    btnHarcGondDevrede.Text = "Harç Gönderme YOK";
                }
                if (S7.GetBitAt(MarkersDB, 7, 6))
                    btnP23Ayri.BackColor = Color.LimeGreen;
                else
                    btnP23Ayri.BackColor = Color.Gray;

            }
        }

        private void Mikser_Load(object sender, EventArgs e)
        {
            CPUbaglan();
            BTNbimhazir.Visible = false;
            BTNbimhazir.Enabled = false;
            label6.Visible = false;
            lblMalzKapakDevam3.Visible = false;
            lblMalzKapakStart3.Visible = false;
            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            panelMikser.BackColor = Sistem.PanelsColor;
            panelPaketleme.BackColor = Sistem.PanelsColor;
            panelUretim.BackColor = Sistem.PanelsColor;
            panelmikserpar.BackColor = Sistem.PanelsColor;
            panelalt.BackColor = Sistem.PanelsColor;
            button4.BackColor = Sistem.altbuttonColors;
            button5.BackColor = Sistem.altbuttonColors;
            button6.BackColor = Sistem.altbuttonColors;
            button11.BackColor = Sistem.altbuttonColors;
            button10.BackColor = Sistem.altbuttonColors;
            button9.BackColor = Sistem.altbuttonColors;
            button8.BackColor = Sistem.altbuttonColors;
            button3.BackColor = Sistem.altbuttonColors;
            button17.BackColor = Sistem.altbuttonColors;
            panelmikserpar.BackColor = Sistem.formbackgroundColor;

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

        private void Mikser_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            panelalt.BackColor = Sistem.PanelsColor;
            this.BackColor = Sistem.formbackgroundColor;
            panelmikserpar.BackColor = Sistem.formbackgroundColor; 
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

        private void Mikser_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }

        private void lblSifre_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[442], 10, 9999, 0);
            f.ShowDialog(this);
        }

        private void BTNbimhazir_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[19], true, 44);
            BTNbimhazir.Visible = false;
            BTNbimhazir.Enabled = false;
        }

        private void snsCimhelCalisiyor_Click(object sender, EventArgs e)
        {
           
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();

            timer1.Enabled = false;
            Ekranlar.OpenOperatprScreen(this);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenVardiyaScreen(this);
        }
    }
}
