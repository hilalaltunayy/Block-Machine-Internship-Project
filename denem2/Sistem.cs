using Sharp7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace denem2
{
    public partial class Sistem : Form
    {

        private S7Client Client;
        private int Result = 5;
        public static string IPadres = "192.168.0.2";
        private int val = 0;
        private AlltagClass aa;
        private ALLAlarmListClass bb;
        public static string ip;
        int butonbasmasıra;
        int okudb = 1;
        int okudiziuzu;
        public static Color AlarmbuttonColor = Color.DarkKhaki;
        public static Color PanelsColor = Color.PaleGoldenrod;
        public static Color altbuttonColors = Color.Khaki;
        public static Color logocolor = Color.Orange;
        public static Color ustbuttoncolor = Color.DarkKhaki;
        public static Color formbackgroundColor= Color.LightSteelBlue;

        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBKalip = new byte[600];
        private byte[] DBKalip2 = new byte[600];
        private byte[] DBKalip3 = new byte[600];
        private byte[] MLER = new byte[408810];
        private byte[] MLER1 = new byte[408810];
        private byte[] MLER2 = new byte[408810];

        string ipkonum = Application.StartupPath.ToString();
        string[] textdata = new string[500];

        public Sistem()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
            hata.Text = Result + " " + Client.ErrorText(Result);
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
        private int writePLC(PLCTag gelentag, bool boolvalue, double othersvalue)
        {
      
            try
            {
              
                if (Result == 0)
                {
                    if (gelentag.Area == "M")
                    {
                        if (gelentag.Tip == "bool")
                        {
                            byte[] bytearray = new byte[1];
                            S7.SetBitAt(ref bytearray, 0, gelentag.BitNo, boolvalue);
                            bool a = S7.GetBitAt(bytearray, 0, 1);
                            Debug.WriteLine("gelen tag offset :" + gelentag.Offset.ToString());
                            Debug.WriteLine("Test bit yazma :" + a.ToString());
                            Result = Client.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, (gelentag.Offset * 8) + gelentag.BitNo, 1, S7Consts.S7WLBit, bytearray);
                           
                            ShowResult(Result);
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
                    else
                    {
                        Debug.WriteLine("Test bit yazma :error");
                        
                        return 0;
                    }

                }
                return 0;
            }
            catch (Exception error)
            {
                Debug.WriteLine("Write PLC Catch :" + error.ToString());
                ShowResult(Result);
                return 0;
            }

        }
        protected string read_Tag(PLCTag gelentag)
        {
           
            try
            {
                
                if (Result == 0)
                {


                    ShowResult(Result);
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

                            Result = Client.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLBit, bytearray);
                            

                            return bytearray[gelentag.BitNo].ToString();
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
                return 0.ToString();
            }
            catch (Exception error)
            {
                ShowResult(Result);
                return 0.ToString();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
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

        private void btnPLCOnline_Click(object sender, EventArgs e)
        {
            if ((tbipadres.Text.Length > 10) & (tbipadres.Text.Length < 12))

            {
                string ipkonum = Application.StartupPath.ToString();

                File.Delete(ipkonum + "\\" + "ip" + ".txt");

                FileStream fs = new FileStream(ipkonum + "\\" + "ip" + ".txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(tbipadres.Text);
                sw.Flush();
                sw.Close();
                fs.Close();
                textdata = System.IO.File.ReadAllLines(ipkonum + "\\" + "ip" + ".txt");
                tbipadres.Text = textdata[0];

            }

            else
            {
                MessageBox.Show("İp Adresi Giriş Şekli Yanlış");
                tbipadres.Text = textdata[0];
            }
        }

        private void Sistem_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;

            panelAna.BackColor = PanelsColor;
            panellogo.BackColor = logocolor;
            btnPnlKontrol.BackColor = PanelsColor;
            this.BackColor = formbackgroundColor;
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

        private void Sistem_Deactivate(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = false;
        }

        private void Sistem_Load(object sender, EventArgs e)
        {
            CPUbaglan();
            if (Uyari.temakod == 0)
            {
                cbTemaAcik.Checked = true;
                cbTemaSari.Checked = false;
                cbTemaKoyu.Checked = false;
            }
            else if(Uyari.temakod == 1)
            {
                cbTemaSari.Checked = true;
                cbTemaAcik.Checked = false;
                cbTemaKoyu.Checked = false;
            }
            else if (Uyari.temakod == 2)
            {
                cbTemaKoyu.Checked = true;
                cbTemaSari.Checked = false;
                cbTemaAcik.Checked = false;
            }
            panelAna.BackColor = PanelsColor;
            panellogo.BackColor = logocolor;
            btnPnlKontrol.BackColor = PanelsColor;
            this.BackColor = formbackgroundColor;
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


            textdata = System.IO.File.ReadAllLines(ipkonum + "\\" + "ip" + ".txt");
            tbipadres.Text = textdata[0];

            area1.Text = "DB";
            type1.Text = "bool";

            area2.Text = "DB";
            type2.Text = "bool";

            area3.Text = "DB";
            type3.Text = "bool";

            textBox1.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
        }

        private void btnOffline_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();

            timer1.Enabled = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {


            bool deger = false;


            if (checkBox1.Checked == true)
            {

                deger = true;
            }
            if (checkBox2.Checked == true)                                     // 1.sıra bool true false kontrolü
            {

                deger = false;
            }


            if (area1.Text == "DB")
            {
                if (dbn1.Text != "" && offset1.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(dbn1.Text), 0, (Convert.ToInt32(offset1.Text) + 4), S7Consts.S7WLByte, DBKalip);

                }


                if (type1.Text == "byte")
                {
                    for (int i = 0; i < 8; i++)
                    {
                        PLCTag aa = new PLCTag(1, "b", area1.Text, "bool", Convert.ToInt16(dbn1.Text), Convert.ToInt16(offset1.Text), i, true); //1.sıra byte resetleme

                        writePLC(aa, deger, Convert.ToDouble(textBox1.Text));
                        label16.Visible = true;
                        label16.Text = "Byte Değiştirildi";
                    }

                }

                if (type1.Text != "byte")
                {
                    PLCTag aa = new PLCTag(1, "b", area1.Text, type1.Text, Convert.ToInt16(dbn1.Text), Convert.ToInt16(offset1.Text), Convert.ToInt16(bitno1.Text), true);


                    writePLC(aa, deger, Convert.ToDouble(textBox1.Text));
                    label16.Visible = false;
                }


            }

            if (area1.Text == "M")
            {
                PLCTag aa = new PLCTag(1, "b", area1.Text, type1.Text, Convert.ToInt16(dbn1.Text), Convert.ToInt16(offset1.Text), Convert.ToInt16(bitno1.Text), true);

                label12.Text = "oldu";
                writePLC(aa, deger, Convert.ToDouble(textBox1.Text));
            }
            butonbasmasıra = 1;
            //   coffsetyazma("offset1.Text", "bitno1.Text", "type1.Text", 1, "label8.Text");
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (butonbasmasıra == 1)
            {

                coffsetyazma(bitno1.Text, type1.Text, 1, label8.Text, offset1.Text);
            }
            if (butonbasmasıra == 2)
            {
                coffsetyazma(bitno2.Text, type2.Text, 2, label10.Text, offset2.Text);
            }
            if (butonbasmasıra == 3)
            {
                coffsetyazma(bitno3.Text, type3.Text, 3, label15.Text, offset3.Text);
            }


            timer2.Enabled = false;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (area2.Text == "DB")
            {
                if (dbn2.Text != "" && offset2.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(dbn2.Text), 0, (Convert.ToInt32(offset2.Text) + 4), S7Consts.S7WLByte, DBKalip2);

                }
            }

            bool deger2 = false;
            if (checkBox4.Checked == true)
            {

                deger2 = true;
            }
            if (checkBox3.Checked == true)                                   // 2.sıra bool true false kontrolü
            {

                deger2 = false;
            }

            if (type2.Text == "byte")
            {
                for (int i = 0; i < 8; i++)
                {
                    PLCTag aa = new PLCTag(1, "b", area2.Text, "bool", Convert.ToInt16(dbn2.Text), Convert.ToInt16(offset2.Text), i, true); //1.sıra byte resetleme

                    writePLC(aa, deger2, Convert.ToDouble(textBox6.Text));
                }

            }


            if (type2.Text != "byte")
            {
                PLCTag aa = new PLCTag(1, "b", area2.Text, type2.Text, Convert.ToInt16(dbn2.Text), Convert.ToInt16(offset2.Text), Convert.ToInt16(bitno2.Text), true);


                writePLC(aa, deger2, Convert.ToDouble(textBox6.Text));

            }
            butonbasmasıra = 2;
            timer2.Enabled = true;
        }
        public void coffsetyazma(object bitnoc, object typec, int dbnoc, object labelc, object offsetc)
        {
            if (area1.Text == "DB")
            {
                if (dbn1.Text != "" && offset1.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(dbn1.Text), 0, (Convert.ToInt32(offset1.Text) + 4), S7Consts.S7WLByte, DBKalip);

                }
            }



            if (area2.Text == "DB")
            {
                if (dbn2.Text != "" && offset2.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(dbn2.Text), 0, (Convert.ToInt32(offset2.Text) + 4), S7Consts.S7WLByte, DBKalip2);

                }
            }

            if (area3.Text == "DB")
            {
                if (dbn3.Text != "" && offset3.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(dbn3.Text), 0, (Convert.ToInt32(offset3.Text) + 4), S7Consts.S7WLByte, DBKalip3);

                }
            }


            if (area1.Text == "M")
            {
                if (dbn1.Text != "" && offset1.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaMK, Convert.ToInt32(dbn1.Text), 0, (Convert.ToInt32(offset1.Text) + 4), S7Consts.S7WLByte, MLER1);             //M LERİ OKUMA

                }
            }

            if (area2.Text == "M")
            {
                if (dbn2.Text != "" && offset2.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaMK, Convert.ToInt32(dbn2.Text), 0, (Convert.ToInt32(offset2.Text) + 4), S7Consts.S7WLByte, MLER2);             //M LERİ OKUMA

                }
            }

            if (area3.Text == "M")
            {
                if (dbn3.Text != "" && offset3.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaMK, Convert.ToInt32(dbn3.Text), 0, (Convert.ToInt32(offset3.Text) + 4), S7Consts.S7WLByte, MLER);             //M LERİ OKUMA

                }
            }

            if (typec.ToString() == "bool")

            {
                if (offsetc.ToString() != "" && bitnoc.ToString() != "")
                {
                    if (butonbasmasıra == 1)
                    {



                        if (area1.Text == "DB")
                        {
                            label8.Text = S7.GetBitAt(DBKalip, Convert.ToInt16(offsetc), Convert.ToInt16(bitnoc)).ToString();
                        }

                        if (area1.Text == "M")
                        {
                            label8.Text = S7.GetBitAt(MLER1, Convert.ToInt16(offsetc), Convert.ToInt16(bitnoc)).ToString();
                        }




                        //    label11.Text = "oldu";
                    }


                    if (butonbasmasıra == 2)
                    {
                        // label10.Text = S7.GetBitAt(DBKalip2, Convert.ToInt16(offsetc), Convert.ToInt16(bitnoc)).ToString();


                        if (area2.Text == "DB")
                        {
                            label10.Text = S7.GetBitAt(DBKalip2, Convert.ToInt16(offsetc), Convert.ToInt16(bitnoc)).ToString();
                        }

                        if (area2.Text == "M")
                        {
                            label10.Text = S7.GetBitAt(MLER2, Convert.ToInt16(offsetc), Convert.ToInt16(bitnoc)).ToString();
                        }
                    }

                    if (butonbasmasıra == 3)
                    {

                        if (area3.Text == "DB")
                        {
                            label15.Text = S7.GetBitAt(DBKalip3, Convert.ToInt16(offsetc), Convert.ToInt16(bitnoc)).ToString();
                        }

                        if (area3.Text == "M")
                        {
                            label15.Text = S7.GetBitAt(MLER, Convert.ToInt16(offsetc), Convert.ToInt16(bitnoc)).ToString();
                        }

                    }

                }

            }

            if (typec.ToString() == "int")

            {
                if (offsetc.ToString() != "")

                {

                    if (butonbasmasıra == 1)
                    {
                        if (area1.Text == "DB")
                        {
                            label8.Text = S7.GetIntAt(DBKalip, Convert.ToInt32(offsetc)).ToString();
                        }



                        if (area1.Text == "M")
                        {
                            label8.Text = S7.GetIntAt(MLER1, Convert.ToInt32(offsetc)).ToString();


                        }



                    }

                    if (butonbasmasıra == 2)
                    {

                        if (area2.Text == "DB")
                        {
                            label10.Text = S7.GetIntAt(DBKalip2, Convert.ToInt32(offsetc)).ToString();
                        }



                        if (area2.Text == "M")
                        {
                            label10.Text = S7.GetIntAt(MLER2, Convert.ToInt32(offsetc)).ToString();

                        }

                    }

                    if (butonbasmasıra == 3)
                    {

                        if (area3.Text == "DB")
                        {
                            label15.Text = S7.GetIntAt(DBKalip3, Convert.ToInt32(offsetc)).ToString();
                        }

                        if (area3.Text == "M")
                        {
                            label15.Text = S7.GetIntAt(MLER, Convert.ToInt32(offsetc)).ToString();

                            label11.Text = "oldu";
                        }
                    }
                }
            }

            if (typec.ToString() == "real")

            {
                if (offsetc.ToString() != "")
                {

                    if (butonbasmasıra == 1)
                    {

                        // label8.Text = S7.GetRealAt(DBKalip, Convert.ToInt16(offsetc)).ToString();



                        if (area1.Text == "DB")
                        {
                            label8.Text = S7.GetRealAt(DBKalip, Convert.ToInt16(offsetc)).ToString();
                        }


                        if (area1.Text == "M")
                        {
                            label8.Text = S7.GetRealAt(MLER1, Convert.ToInt32(offsetc)).ToString();

                            //   label10.Text = "oldu";
                        }
                    }

                    if (butonbasmasıra == 2)
                    {

                        //label10.Text = S7.GetRealAt(DBKalip2, Convert.ToInt16(offsetc)).ToString();

                        if (area2.Text == "DB")
                        {
                            label10.Text = S7.GetRealAt(DBKalip2, Convert.ToInt16(offsetc)).ToString();
                        }


                        if (area2.Text == "M")
                        {
                            label10.Text = S7.GetRealAt(MLER2, Convert.ToInt32(offsetc)).ToString();

                            //   label10.Text = "oldu";
                        }
                    }

                    if (butonbasmasıra == 3)
                    {
                        if (area3.Text == "DB")
                        {
                            label15.Text = S7.GetRealAt(DBKalip3, Convert.ToInt16(offsetc)).ToString();
                        }


                        if (area3.Text == "M")
                        {
                            label15.Text = S7.GetRealAt(MLER, Convert.ToInt32(offsetc)).ToString();

                            label11.Text = "oldu";
                        }
                    }
                }

            }

            if (typec.ToString() == "dword")

            {
                if (offsetc.ToString() != "")
                {
                    if (butonbasmasıra == 1)
                    {

                        if (area1.Text == "DB")
                        {
                            label8.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, Convert.ToInt16(offsetc)))) / 1000).ToString();
                        }


                        if (area1.Text == "M")
                        {
                            label8.Text = ((Convert.ToDouble(S7.GetDWordAt(MLER1, Convert.ToInt16(offsetc)))) / 1000).ToString();

                            //   label10.Text = "oldu";
                        }


                        //   label8.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip, Convert.ToInt16(offsetc)))) / 1000).ToString();
                    }

                    if (butonbasmasıra == 2)
                    {
                        if (area2.Text == "DB")
                        {
                            label10.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip2, Convert.ToInt16(offsetc)))) / 1000).ToString();
                        }


                        if (area2.Text == "M")
                        {
                            label10.Text = ((Convert.ToDouble(S7.GetDWordAt(MLER2, Convert.ToInt16(offsetc)))) / 1000).ToString();

                            //   label10.Text = "oldu";
                        }

                        //   label10.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip2, Convert.ToInt16(offsetc)))) / 1000).ToString();
                    }

                    if (butonbasmasıra == 3)
                    {
                        if (area3.Text == "DB")
                        {
                            label15.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip3, Convert.ToInt16(offsetc)))) / 1000).ToString();
                        }


                        if (area3.Text == "M")
                        {
                            label15.Text = ((Convert.ToDouble(S7.GetDWordAt(MLER, Convert.ToInt16(offsetc)))) / 1000).ToString();

                            //   label10.Text = "oldu";
                        }
                        //  label15.Text = ((Convert.ToDouble(S7.GetDWordAt(DBKalip3, Convert.ToInt16(offsetc)))) / 1000).ToString();
                    }

                }

            }
            if (typec.ToString() == "dint")

            {
                if (offsetc.ToString() != "")
                {


                    if (butonbasmasıra == 1)
                    {
                        if (area1.Text == "DB")
                        {
                            label8.Text = S7.GetDIntAt(DBKalip, Convert.ToInt16(offsetc)).ToString();
                        }


                        if (area1.Text == "M")
                        {
                            label8.Text = S7.GetDIntAt(MLER1, Convert.ToInt16(offsetc)).ToString();

                        }

                    }

                    if (butonbasmasıra == 2)
                    {
                        if (area2.Text == "DB")
                        {
                            label10.Text = S7.GetDIntAt(DBKalip2, Convert.ToInt16(offsetc)).ToString();
                        }


                        if (area2.Text == "M")
                        {
                            label10.Text = S7.GetDIntAt(MLER2, Convert.ToInt16(offsetc)).ToString();

                        }

                        // label10.Text = S7.GetDIntAt(DBKalip2, Convert.ToInt16(offsetc)).ToString();
                    }

                    if (butonbasmasıra == 3)
                    {

                        if (area3.Text == "DB")
                        {
                            label15.Text = S7.GetDIntAt(DBKalip3, Convert.ToInt16(offsetc)).ToString();

                        }
                        if (area3.Text == "M")
                        {
                            label15.Text = S7.GetDIntAt(MLER, Convert.ToInt16(offsetc)).ToString();
                        }


                    }
                }

            }

            butonbasmasıra = 0;

        }
        private void offset2_TextChanged(object sender, EventArgs e)
        {
            //   butonbasmasıra = 0;
            if (area2.Text == "DB")
            {
                if (dbn2.Text != "" && offset2.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(dbn2.Text), 0, (Convert.ToInt32(offset2.Text) + 4), S7Consts.S7WLByte, DBKalip2);

                }
            }

            butonbasmasıra = 2;

            coffsetyazma(bitno2.Text, type2.Text, 2, label10.Text, offset2.Text);




        }
        private void button25_Click(object sender, EventArgs e)
        {

            bool deger3 = false;

            if (checkBox6.Checked == true)
            {

                deger3 = true;
            }
            if (checkBox5.Checked == true)                                   // 2.sıra bool true false kontrolü
            {

                deger3 = false;
            }

            label12.Text = deger3.ToString();

            if (area3.Text == "DB")
            {


                if (dbn3.Text != "" && offset3.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(dbn3.Text), 0, (Convert.ToInt32(offset3.Text) + 4), S7Consts.S7WLByte, DBKalip3);
                }


                if (type3.Text == "byte")
                {
                    for (int i = 0; i < 8; i++)
                    {
                        PLCTag aa = new PLCTag(1, "b", area3.Text, "bool", Convert.ToInt16(dbn3.Text), Convert.ToInt16(offset3.Text), i, true); //1.sıra byte resetleme

                        writePLC(aa, deger3, Convert.ToDouble(textBox7.Text));
                    }
                }





                if (type3.Text != "byte")
                {
                    PLCTag aa = new PLCTag(1, "c", area3.Text, type3.Text, Convert.ToInt16(dbn3.Text), Convert.ToInt16(offset3.Text), Convert.ToInt16(bitno3.Text), true);


                    writePLC(aa, deger3, Convert.ToDouble(textBox7.Text));
                    label16.Visible = false;
                }

            }
            if (area3.Text == "M")
            {
                PLCTag aa = new PLCTag(1, "b", area3.Text, type3.Text, Convert.ToInt16(dbn3.Text), Convert.ToInt16(offset3.Text), Convert.ToInt16(bitno3.Text), true);

                label12.Text = "oldu";
                writePLC(aa, deger3, Convert.ToDouble(textBox7.Text));

            }


            butonbasmasıra = 3;
            timer2.Enabled = true;
        }

        private void offset1_TextChanged(object sender, EventArgs e)
        {
            butonbasmasıra = 1;
            // butonbasmasıra = 0;
            if (area1.Text == "DB")
            {
                if (dbn1.Text != "" && offset1.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(dbn1.Text), 0, (Convert.ToInt32(offset1.Text) + 4), S7Consts.S7WLByte, DBKalip);

                }
            }

            if (type1.Text != "bool")
            {
                coffsetyazma(bitno1.Text, type1.Text, 1, "label8.Text", offset1.Text);
            }





        }

        private void offset3_TextChanged(object sender, EventArgs e)
        {
            butonbasmasıra = 3;

            if (area3.Text == "DB")
            {
                if (dbn3.Text != "" && offset3.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaDB, Convert.ToInt32(dbn3.Text), 0, (Convert.ToInt32(offset3.Text) + 4), S7Consts.S7WLByte, DBKalip3);

                }
            }
            if (area3.Text == "M")
            {
                if (dbn3.Text != "" && offset3.Text != "")
                {
                    Result = Client.ReadArea(S7Consts.S7AreaMK, Convert.ToInt32(dbn3.Text), 0, (Convert.ToInt32(offset3.Text) + 4), S7Consts.S7WLByte, MLER);             //M LERİ OKUMA

                }
            }

            coffsetyazma(bitno3.Text, type3.Text, 3, label15.Text, offset3.Text);
        }

        private void bitno1_TextChanged(object sender, EventArgs e)
        {
            /*
           if (type1.Text == "bool")

           {
               if (offset1.Text != "" && bitno1.Text != "")
               {
                   label8.Text = S7.GetBitAt(DBKalip, Convert.ToInt16(offset1.Text), Convert.ToInt16(bitno1.Text)).ToString();
               }

           }
           */
            butonbasmasıra = 1;
            coffsetyazma(bitno1.Text, type1.Text, 1, label8.Text, offset1.Text);
        }

        private void bitno2_TextChanged(object sender, EventArgs e)
        {
            butonbasmasıra = 2;
            coffsetyazma(bitno2.Text, type2.Text, 2, label10.Text, offset2.Text);
        }

        private void bitno3_TextChanged(object sender, EventArgs e)
        {
            butonbasmasıra = 3;
            coffsetyazma(bitno3.Text, type3.Text, 2, label15.Text, offset3.Text);
        }

        private void cbTemaAcik_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTemaAcik.Checked == true) 
            {
                cbTemaKoyu.Checked=false;
                cbTemaSari.Checked=false;

            }
        }

        private void cbTemaKoyu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTemaKoyu.Checked == true)
            {
                cbTemaAcik.Checked = false;
                cbTemaSari.Checked = false;

            }
        }

        private void cbTemaSari_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTemaSari.Checked == true)
            {
                cbTemaKoyu.Checked = false;
                cbTemaAcik.Checked = false;

            }
        }

        private void btnTemaSet_Click(object sender, EventArgs e)
        {

            try
            {
                //Once pcye text dosyasına temayı kaydet!
                File.Delete(Uyari.temakonum + "\\" + "tema" + ".txt");
                FileStream fs = new FileStream(Uyari.temakonum + "\\" + "tema" + ".txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                if (cbTemaAcik.Checked == true)
                {
                    sw.WriteLine("0");
                    Uyari.temakod = 0;
                }
                else if (cbTemaSari.Checked == true)
                {
                    sw.WriteLine("1");
                    Uyari.temakod = 1;
                }
                else if (cbTemaKoyu.Checked == true)
                {
                    sw.WriteLine("2");
                    Uyari.temakod = 2;
                }
                Uyari.renk_degistir();

                sw.Flush();
                sw.Close();
                fs.Close();
                textdata = System.IO.File.ReadAllLines(Uyari.temakonum + "\\" + "tema" + ".txt");
                lblhata.Text = "Başarılı ";

                panelAna.BackColor = PanelsColor;
                panellogo.BackColor = logocolor;
                btnPnlKontrol.BackColor = PanelsColor;
                this.BackColor = formbackgroundColor;
                button4.BackColor = altbuttonColors;
                button5.BackColor = altbuttonColors;
                button6.BackColor = altbuttonColors;
                button11.BackColor = altbuttonColors;
                button10.BackColor = altbuttonColors;
                button9.BackColor = altbuttonColors;
                button8.BackColor = altbuttonColors;
                button3.BackColor = altbuttonColors;
                button17.BackColor = altbuttonColors;

                button1.BackColor = ustbuttoncolor;
                button7.BackColor = ustbuttoncolor;
                button13.BackColor = ustbuttoncolor;
                button14.BackColor = ustbuttoncolor;
                button15.BackColor = ustbuttoncolor;
                button16.BackColor = ustbuttoncolor;
                button19.BackColor = ustbuttoncolor;
                button20.BackColor = ustbuttoncolor;
                button21.BackColor = ustbuttoncolor;
                button26.BackColor = ustbuttoncolor;//Raporlar
                button31.BackColor = ustbuttoncolor;//operator
            }
            catch (Exception ex)
            {
                lblhata.Text="hata: "+ex.Message;
            }
           
                     
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
    }
}
