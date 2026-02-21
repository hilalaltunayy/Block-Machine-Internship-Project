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
    public partial class ToplamaOransal : Form
    {
        private S7Client Client;
        private int Result;
        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBPaketleme = new byte[600];
        private byte[] DBMikser = new byte[600];
        private byte[] Db4Kalip = new byte[600];
        private byte[] DBEkran8 = new byte[300];
        public ToplamaOransal()
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
        private void btnPalet3C(object sender, EventArgs e)
        {
            if (Result == 3)
            {
                Form f = new Palet3();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                timer1.Enabled = false;
                Client.Disconnect();
                Form f = new Palet3();
                f.ShowDialog();
                this.Close();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
           
        }
        private void btnPresHidStart_Click(object sender, EventArgs e)
        {
            if (lblSifre.Text == "2946")
            {
                Debug.WriteLine("Sifre Doğru ");
                string tag = read_Tag(AlltagClass.ALLTagList[604]);
                Debug.WriteLine("Ayar değeri şuuuuu : " + tag);
                if (tag == "True")
                {
                    writePLC(AlltagClass.ALLTagList[604], false, 1);
                }
                else
                {
                    writePLC(AlltagClass.ALLTagList[604], true, 1);
                }
                writePLC(AlltagClass.ALLTagList[442], true, 0);
            }
        }

        private void btnp1adim_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[598], true, 1);
        }

        private void btnp2adim_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[599], true, 1);
        }

        private void btnp3adim_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[600], true, 1);
        }

        private void lblPresPKatsayi_Click(object sender, EventArgs e)
        {
            if (S7.GetBitAt(Db4Kalip, 20, 6))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[592], 1, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void lblSifre_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[442], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void lblPresPsifirVal_Click(object sender, EventArgs e)
        {
            if (S7.GetBitAt(Db4Kalip, 20, 6))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[590], 1, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void lblPresPYuzVal_Click(object sender, EventArgs e)
        {
            if (S7.GetBitAt(Db4Kalip, 20, 6))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[591], 1, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void lblPresQKatsayi_Click(object sender, EventArgs e)
        {
            if (S7.GetBitAt(Db4Kalip, 21, 6))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[596], 1, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void lblPresQsifirVal_Click(object sender, EventArgs e)
        {
            if (S7.GetBitAt(Db4Kalip, 21, 6))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[594], 1, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void lblPresQYuzVal_Click(object sender, EventArgs e)
        {
            if (S7.GetBitAt(Db4Kalip, 21, 6))
            {
                Form f = new Calculator(AlltagClass.ALLTagList[595], 1, 9999, 0);
                f.ShowDialog(this);
            }
        }

        private void btnQ1adim_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[605], true, 1);
        }

        private void btnQ2adim_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[606], true, 1);
        }

        private void btnQ3adim_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[607], true, 1);
        }

        private void btnPresQayarla_Click(object sender, EventArgs e)
        {
            if (lblSifre.Text == "2946")
            {

                string tag = read_Tag(AlltagClass.ALLTagList[611]);

                if (tag == "True")
                {
                    writePLC(AlltagClass.ALLTagList[611], false, 1);
                }
                else
                {
                    writePLC(AlltagClass.ALLTagList[611], true, 1);
                }
                writePLC(AlltagClass.ALLTagList[442], true, 0);
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

                    Result = Client.ReadArea(S7Consts.S7AreaMK, 0, 0, 320, S7Consts.S7WLByte, MarkersDB);

                    Result = Client.ReadArea(S7Consts.S7AreaDB, 3, 260, 22, S7Consts.S7WLByte, Db4Kalip);
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

                lblPresPOransalCikis.Text = S7.GetIntAt(Db4Kalip, 8).ToString();
                lblPresPYuzVal.Text = S7.GetIntAt(Db4Kalip, 2).ToString();
                lblPresPsifirVal.Text = S7.GetIntAt(Db4Kalip, 0).ToString();
                lblPresPKatsayi.Text = S7.GetRealAt(Db4Kalip, 4).ToString();
                lblSifre.Text = S7.GetIntAt(MarkersDB, 234).ToString();

                lblPresQKatsayi.Text = S7.GetRealAt(Db4Kalip, 14).ToString();
                lblPresQsifirVal.Text = S7.GetIntAt(Db4Kalip, 10).ToString();
                lblPresQYuzVal.Text = S7.GetIntAt(Db4Kalip, 12).ToString();
                lblPresQOransalCikis.Text = S7.GetIntAt(Db4Kalip, 18).ToString();

                if (S7.GetBitAt(Db4Kalip, 20, 6))
                    gr.Visible = true;
                else
                    gr.Visible = false;

                if (S7.GetBitAt(Db4Kalip, 20, 3))
                {
                    lbl1.Visible = true;
                    btnp1adim.Visible = true;
                }
                else
                {
                    lbl1.Visible = false;
                    btnp1adim.Visible = false;
                }

                if (S7.GetBitAt(Db4Kalip, 20, 4))
                {
                    lbl2.Visible = true;
                    btnp2adim.Visible = true;
                }
                else
                {
                    lbl2.Visible = false;
                    btnp2adim.Visible = false;
                }

                if (S7.GetBitAt(Db4Kalip, 20, 5))
                {
                    lbl3.Visible = true;
                    btnp3adim.Visible = true;
                }
                else
                {
                    lbl3.Visible = false;
                    btnp3adim.Visible = false;
                }

                if (S7.GetBitAt(Db4Kalip, 21, 6))
                    groupBox2.Visible = true;
                else
                    groupBox2.Visible = false;

                if (S7.GetBitAt(Db4Kalip, 21, 3))
                {
                    lbl4.Visible = true;
                    btnQ1adim.Visible = true;
                }
                else
                {
                    lbl4.Visible = false;
                    btnQ1adim.Visible = false;
                }
                if (S7.GetBitAt(Db4Kalip, 21, 4))
                {
                    lbl5.Visible = true;
                    btnQ2adim.Visible = true;
                }
                else
                {
                    lbl5.Visible = false;
                    btnQ2adim.Visible = false;
                }
                if (S7.GetBitAt(Db4Kalip, 21, 5))
                {
                    lbl6.Visible = true;
                    btnQ3adim.Visible = true;
                }
                else
                {
                    lbl6.Visible = false;
                    btnQ3adim.Visible = false;
                }
            }

        }

        private void ToplamaOransal_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;
        }

        private void ToplamaOransal_Deactivate(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = false;
        }

        private void ToplamaOransal_Load(object sender, EventArgs e)
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
