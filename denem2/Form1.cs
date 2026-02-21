using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sharp7;
using System.Diagnostics;
using System.Drawing.Text;
using System.Collections;

namespace denem2
{
    public partial class Form1 : Form
    {
        private S7Client ClientAna;
        private int Result=5;
        private byte[] Buffer = new byte[750];
        private byte[] BufferDB6 = new byte[750];
        private byte[] MarkersDB = new byte[750];
        private byte[] PaketlemeDB = new byte[750];
        private byte[] timer112DB = new byte[36];
        private byte[] MikserDB = new byte[750];
        private byte[] timer113DB = new byte[36];
        private int val = 0;
       
        private bool PanelControl = false;


        public Form1()
        {
            InitializeComponent();
                     
        }
      
        private void CustumizeDesign()
        {
            panelUretim.Visible = false;
            panelPaketleme.Visible = false;
            panelMikser.Visible = false;
            //if (Ekranlar.darkMode)
            //{
            //    panel1.BackColor= Color.FromArgb(17, 72, 125);
            //    label66.BackColor = Color.FromArgb(17, 72, 125);

            //    button1.BackColor = Color.FromArgb(0, 23, 71);
            //    button1.ForeColor = Color.WhiteSmoke;
            //    button7.BackColor = Color.FromArgb(0, 23, 71);
            //    button7.ForeColor = Color.WhiteSmoke;
            //    button13.BackColor = Color.FromArgb(0, 23, 71);
            //    button13.ForeColor = Color.WhiteSmoke;
            //    button14.BackColor = Color.FromArgb(0, 23, 71);
            //    button14.ForeColor = Color.WhiteSmoke;
            //    button15.BackColor = Color.FromArgb(0, 23, 71);
            //    button15.ForeColor = Color.WhiteSmoke;
            //    button16.BackColor = Color.FromArgb(0, 23, 71);
            //    button16.ForeColor = Color.WhiteSmoke;
            //    button19.BackColor = Color.FromArgb(0, 23, 71);
            //    button19.ForeColor = Color.WhiteSmoke;
            //    button20.BackColor = Color.FromArgb(0, 23, 71);
            //    button20.ForeColor = Color.WhiteSmoke;
            //    button21.BackColor = Color.FromArgb(0, 23, 71);
            //    button21.ForeColor = Color.WhiteSmoke;
            //    button28.BackColor = Color.FromArgb(0, 23, 71);
            //    button28.ForeColor = Color.WhiteSmoke;
            //}
            //else {

            //    panel1.BackColor = Color.DimGray;
            //    label66.BackColor = Color.DimGray;

            //    button1.BackColor = Color.Silver;
            //    button7.BackColor = Color.Silver;
            //    button13.BackColor = Color.Silver;
            //    button14.BackColor = Color.Silver;
            //    button15.BackColor = Color.Silver;
            //    button16.BackColor = Color.Silver;
            //    button19.BackColor = Color.Silver;
            //    button20.BackColor = Color.Silver;
            //    button21.BackColor = Color.Silver;
            //    button28.BackColor = Color.Silver;
            //}
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
      
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            GoFullscreen(true);
            CustumizeDesign();
            panel1.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            panelalt.BackColor = Sistem.PanelsColor;
            panelyan.BackColor = Sistem.PanelsColor;
            panel1.BackColor = Sistem.PanelsColor;
            //this.BackColor = Sistem.formbackgroundColor;
            

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
            button28.BackColor = Sistem.ustbuttoncolor;
            button31.BackColor = Sistem.ustbuttoncolor;




            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }

        }
        

        private void btnUretim(object sender, EventArgs e)
        {
            showSubMenu(panelUretim);
        }

        private void btnTopParam(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (ClientAna.Connected)
                ClientAna.Disconnect(); 
            timer1.Enabled = false;
           Ekranlar.OpenToplamaParamScreen(this);
        }

        private void btnUstKalip(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (ClientAna.Connected)
                ClientAna.Disconnect();

            Ekranlar.OpenUstKalipScreen(this);
            //Ekranlar.UstkalipScreen.Show();
  
        }

        private void btnAltKalip(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (ClientAna.Connected)
                ClientAna.Disconnect();

            Ekranlar.OpenAltKalipScreen(this);
            //Ekranlar.AltKalipScreen.Show();


        }

        private void btnHarcTeknesi(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (ClientAna.Connected)
                ClientAna.Disconnect();
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
            if (ClientAna.Connected)
                ClientAna.Disconnect();
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
            if (ClientAna.Connected)
                ClientAna.Disconnect();
            timer1.Enabled = false;
            Ekranlar.OpenIticiParamScreen(this);

        }

        private void btnCatalParam(object sender, EventArgs e)
        {
            if(backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();

            if (ClientAna.Connected)
                ClientAna.Disconnect();
            timer1.Enabled = false;
            Ekranlar.OpenCatalAcmaParamScreen(this);
        
        }

        private void btnTopYuk_Asg(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (ClientAna.Connected)
                ClientAna.Disconnect();
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
                if (ClientAna.Connected)
                    ClientAna.Disconnect();

                Ekranlar.OpenMikserScreen(this);
                
            }
        }

        private void btnMikserParam(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (ClientAna.Connected)
                ClientAna.Disconnect();
          Ekranlar.OpenMikserParamScreen(this);
           
        }
        private void btnHidrolik(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (ClientAna.Connected)
                ClientAna.Disconnect();
            Ekranlar.OpenHidrolikScreen(this);
           
        }
        private void btnVibrasyon(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (ClientAna.Connected)
                ClientAna.Disconnect();

            Ekranlar.OpenVibrasyonScreen(this); 
            
        }
        private void btnSystem(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (ClientAna.Connected)
                ClientAna.Disconnect();
            Ekranlar.OpenSistemScreen(this);
           
        }
        private void btnGrafik(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            timer1.Enabled = false;
            if (ClientAna.Connected)
                ClientAna.Disconnect();
           Ekranlar.OpenGrafikScreen(this);
           
        }
        private void btnRecete(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (ClientAna.Connected)
                ClientAna.Disconnect();
            timer1.Enabled = false;
           Ekranlar.OpenReceteScreen(this);
            
        }
        private void btnAlarm(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if(ClientAna.Connected)
                ClientAna.Disconnect();    
            
            timer1.Enabled = false;
            Ekranlar.OpenAlarmScreen(this);
            
        }
        private void btnPalet3(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();

            timer1.Enabled = false;
            if (ClientAna.Connected)
                ClientAna.Disconnect();
            Ekranlar.OpenPalet3Screen(this);
            
        }
        private void BTNvardiya(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (ClientAna.Connected)
                ClientAna.Disconnect();
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
            hataAna.Text = Result + " " + ClientAna.ErrorText(Result);
            if (Result == 0)
            {
                
                btnconnectionStatus.BackColor = Color.Green;
            }
            else
            {
               
                btnconnectionStatus.BackColor = Color.Blue;

            }

        }
       
        private void xuıSuperButton1_Click(object sender, EventArgs e)
        {
            if (Result == 3)
            {

                timer1.Enabled = false;
                Application.Exit();
            }
            else
            {
                ClientAna.Disconnect();
                timer1.Enabled = false;
                Application.Exit();
            }

        }
     


        private int writePLC(PLCTag gelentag, bool boolvalue, int othersvalue)
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
                        
                            Result = ClientAna.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, (gelentag.Offset * 8) + gelentag.BitNo, 1, S7Consts.S7WLBit, bytearray);
                            Debug.WriteLine("Gelen Bool Val " + boolvalue);
                            Debug.WriteLine("Yazan bool Val " + S7.GetBitAt(bytearray, 0, 1));

                            
                            return Result;
                        }
                        else if (gelentag.Tip == "int")
                        {
                            byte[] realArray = new byte[2];

                            int val = Convert.ToInt16(othersvalue);
                            realArray = BitConverter.GetBytes(Convert.ToInt16(val));
                            Array.Reverse(realArray);
                            byte[] aa = realArray;
                            

                            Result = ClientAna.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, aa);
                          
                            return Result;
                        }
                        else if (gelentag.Tip == "real")
                        {
                            byte[] realArray = new byte[4];
                            int val = Convert.ToInt32(othersvalue);
                            realArray = BitConverter.GetBytes(val);
                            Result = ClientAna.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLReal, realArray);
                           
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
                            Result = ClientAna.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, (gelentag.Offset * 8) + gelentag.BitNo, 1, S7Consts.S7WLBit, bytearray);

                            return Result;
                        }
                        else if (gelentag.Tip == "int")
                        {
                            byte[] realArray = new byte[2];

                            int val = Convert.ToInt16(othersvalue);
                            realArray = BitConverter.GetBytes(Convert.ToInt16(val));
                            Array.Reverse(realArray);
                            byte[] aa = realArray;

                            Result = ClientAna.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, aa);
                            return Result;
                        }
                        else if (gelentag.Tip == "real")
                        {
                            byte[] realArray = new byte[4];
                            int val = Convert.ToInt32(othersvalue);
                            realArray = BitConverter.GetBytes(val);
                            Result = ClientAna.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLReal, realArray);
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
            catch(Exception error)
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
                    if (gelentag.Area == "M")
                    {
                        if (gelentag.Tip == "bool")
                        {
                            byte[] bytearray = new byte[1];

                            Result = ClientAna.ReadArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLByte, bytearray);
                            
                            return S7.GetBitAt(bytearray, 0, gelentag.BitNo).ToString();
                        }
                        else if (gelentag.Tip == "int")
                        {
                            byte[] realArray = new byte[2];


                            Result = ClientAna.ReadArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, realArray);
                          
                            return S7.GetIntAt(realArray, 0).ToString();
                        }
                        else if (gelentag.Tip == "real")
                        {
                            byte[] realArray = new byte[4];

                            Result = ClientAna.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLReal, realArray);
                      
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

                            Result = ClientAna.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLBit, bytearray);
                            

                            return bytearray[gelentag.BitNo].ToString();
                        }
                        else if (gelentag.Tip == "int")
                        {
                            byte[] realArray = new byte[2];


                            Result = ClientAna.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, realArray);
                            

                            return S7.GetIntAt(realArray, 0).ToString();
                        }
                        else if (gelentag.Tip == "real")
                        {
                            byte[] realArray = new byte[4];

                            Result = ClientAna.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLReal, realArray);
                           
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
            catch(Exception error)
            {
                ShowResult(Result);
                return 0.ToString();
            }
           
        }

        private void PanelControlButton(object sender, EventArgs e)
        {

            if (PanelControl)
            {
                btnTopYuk.Visible = true;
                btnTopAsag.Visible = true;
                btnTopCoz.Visible = true;
                btnTopSik.Visible = true;
                btnTopileri.Visible = true;
                btnTopGeri.Visible = true;
                btnTopCevileri.Visible = true;
                btnTopCevGeri.Visible = true;
                btnAltKlpAsagi.Visible = true;
                btnAltKlpYukari.Visible = true;
                btnUstKlpAsagi.Visible = true;
                btnUstKlpYuk.Visible = true;
                btnVibstart.Visible = true;
                btnP2Geri.Visible = true;
                btnP2ileri.Visible = true;
                btnP3geri.Visible = true;
                btnP3ileri.Visible = true;
                btnZinGeri.Visible = true;
                btnZincirliileri.Visible = true;
                btnDikeyileri.Visible = true;
                btnDikeyGeri.Visible = true;
                btnP1ileri.Visible = true;
                btnP1Geri.Visible = true;
                btnHarcTekileri.Visible = true;
                btnHarcTekGeri.Visible = true;
               // Debug.WriteLine("Saat 1 :" + DateTime.Now.ToLongTimeString());
                Result = writePLC(AlltagClass.ALLTagList[429], false, 1);
              //  Debug.WriteLine("Saat 2 :" + DateTime.Now.ToLongTimeString());
                ShowResult(Result);
            }
            else
            {
                btnTopYuk.Visible = false;
                btnTopAsag.Visible = false;
                btnTopCoz.Visible = false;
                btnTopSik.Visible = false;
                btnTopileri.Visible = false;
                btnTopGeri.Visible = false;
                btnTopCevileri.Visible = false;
                btnTopCevGeri.Visible = false;
                btnAltKlpAsagi.Visible = false;
                btnAltKlpYukari.Visible = false;
                btnUstKlpAsagi.Visible = false;
                btnUstKlpYuk.Visible = false;
                btnVibstart.Visible = false;
                btnP2Geri.Visible = false;
                btnP2ileri.Visible = false;
                btnP3geri.Visible = false;
                btnP3ileri.Visible = false;
                btnZinGeri.Visible = false;
                btnZincirliileri.Visible = false;
                btnDikeyileri.Visible = false;
                btnDikeyGeri.Visible = false;
                btnP1ileri.Visible = false;
                btnP1Geri.Visible = false;
                btnHarcTekileri.Visible = false;
                btnHarcTekGeri.Visible = false;
              //  Debug.WriteLine("Saat 3 :" + DateTime.Now.ToLongTimeString());
                Result = writePLC(AlltagClass.ALLTagList[429], true, 1);
              //  Debug.WriteLine("Saat 4 :" + DateTime.Now.ToLongTimeString());
                ShowResult(Result);
            }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
     
            timer1.Enabled = false;
            Application.ExitThread();
           // this.BeginInvoke(new MethodInvoker(Close));
           // Application.Exit();
        }


        private void tbAnaStepNo_Click(object sender, EventArgs e)
        {
            // Client.Disconnect();
            //timer1.Enabled = false;
            Form f = new Calculator(AlltagClass.ALLTagList[415], 1, 500, 0);
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

        private void tbSetCim_Click(object sender, EventArgs e)
        {
          
            Form f = new Calculator(AlltagClass.ALLTagList[185], 1, 250, 0);
           
            f.ShowDialog(this);
        }

        private void tbSetSu_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[202], 1, 32000, 0);
            f.ShowDialog(this);
        }

        private void button72_Click(object sender, EventArgs e)
        {
            try
            {
                Result = writePLC(AlltagClass.ALLTagList[407], false, 41);
                ShowResult(Result);
            }
            catch (Exception k)
            {

            }
        }

        private void button73_Click(object sender, EventArgs e)
        {
            try
            {
                Result = writePLC(AlltagClass.ALLTagList[407], false, 45);
                ShowResult(Result);
            }
            catch (Exception m)
            {

            }
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

        private void btnPressDur_Click(object sender, EventArgs e)
        {
            try
            {
                String gelenvalue = read_Tag(AlltagClass.ALLTagList[432]);
                bool gelenvaluebool = Convert.ToBoolean(gelenvalue);
                if (gelenvaluebool)
                    Result = writePLC(AlltagClass.ALLTagList[432], false, 1);
                else
                    Result = writePLC(AlltagClass.ALLTagList[407], true, 11);

            }
            catch (Exception m)
            {

            }
        }

        private void btnTopYuk_MouseDown(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[391], true, 0);
        }

        private void btnTopYuk_MouseUp(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[391], false, 0);
        }
        private void btnTopAsag_MouseDown(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[382], true, 0);
        }

        private void btnTopAsag_MouseUp(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[391], false, 0);
        }

        private void btnTopSik_MouseDown(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[390], true, 0);
        }

        private void btnTopSik_MouseUp(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[390], false, 0);
        }

        private void btnTopCoz_MouseDown(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[385], true, 0);
        }

        private void btnTopCoz_MouseUp(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[385], false, 0);
        }

        private void btnTopileri_MouseDown(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[389], true, 0);
        }

        private void btnTopileri_MouseUp(object sender, MouseEventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[389], false, 0);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string val = read_Tag(AlltagClass.ALLTagList[361]);
            if (val == "true")
            {
                writePLC(AlltagClass.ALLTagList[361], false, 0);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[361], true, 0);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[485], true, 0);
        }

     
        private void tbTopSikBarSet_Click_1(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[228], 1, 999, 0);
            f.ShowDialog(this);
        }

        

        private void CPUbaglan()
        {
            try
            {
                ClientAna = new S7Client();
                ClientAna.SendTimeout = 300;
                ClientAna.ConnTimeout = 300;
                ClientAna.RecvTimeout = 300;
                Result = ClientAna.ConnectTo("192.168.0.2", 0, 0);
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

            if (Result != 0 || !ClientAna.Connected)
            {

                CPUbaglan();
                return;

            }

            try
            {

                if (Result == 0 && ClientAna.Connected)
                {
                  
                    Result = ClientAna.ReadArea(S7Consts.S7AreaDB, 8, 0, 120, S7Consts.S7WLByte, Buffer);
                    Result = ClientAna.ReadArea(S7Consts.S7AreaDB, 6, 0, 198, S7Consts.S7WLByte, BufferDB6);
                    Result = ClientAna.ReadArea(S7Consts.S7AreaMK, 0, 0, 320, S7Consts.S7WLByte, MarkersDB);
                    Result = ClientAna.ReadArea(S7Consts.S7AreaDB, 3, 0, 280, S7Consts.S7WLByte, PaketlemeDB);
                    Result = ClientAna.ReadArea(S7Consts.S7AreaDB, 112, 0, 12, S7Consts.S7WLByte, timer112DB);
                    Result = ClientAna.ReadArea(S7Consts.S7AreaDB, 113, 0, 12, S7Consts.S7WLByte, timer113DB);
                    Result = ClientAna.ReadArea(S7Consts.S7AreaDB, 1, 0, 320, S7Consts.S7WLByte, MikserDB);
                    ShowResult(Result);
                    ALLAlarmListClass.AlarmlariOku(ClientAna);
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

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;

            Debug.WriteLine("Form1 Aktif edildi!!!");
            panel1.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            panelalt.BackColor = Sistem.PanelsColor;
            panelyan.BackColor = Sistem.PanelsColor;
            panel1.BackColor = Sistem.PanelsColor;
            panelAna.BackColor = Sistem.PanelsColor;
            panelmikserekran.BackColor = Sistem.PanelsColor;
            //this.BackColor = Sistem.formbackgroundColor;

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
            button28.BackColor = Sistem.ustbuttoncolor;
            button31.BackColor = Sistem.ustbuttoncolor;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;

            Debug.WriteLine("Form1 Deaktif edildi!!!");
        }

        private void timer_hazirla_Tick(object sender, EventArgs e)
        {
           
           // lblZincirliLzr.Font = new Font("DS-Digital", 20);
           // lblLzrMasa.Font = new Font("DS-Digital", 20);
            lblLzrHarc.Font = new Font("DS-Digital", 20);
            

            timer_hazirla.Enabled = false;
        }

       

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Result == 0)
            {
                tbCalismaSaniye.Text = S7.GetIntAt(Buffer, AlltagClass.ALLTagList[31].Offset).ToString();
                tbCalismaSaat.Text = S7.GetIntAt(Buffer, AlltagClass.ALLTagList[30].Offset).ToString();
                tbCalismaDk.Text = S7.GetIntAt(Buffer, AlltagClass.ALLTagList[29].Offset).ToString();
                tbCevrimS.Text = S7.GetRealAt(Buffer, AlltagClass.ALLTagList[32].Offset).ToString();
                tbUretilenAdet.Text = S7.GetIntAt(BufferDB6, 38).ToString();
                tbPbasinc.Text = S7.GetIntAt(MarkersDB, AlltagClass.ALLTagList[430].Offset).ToString();
                tbQbasinc.Text = S7.GetIntAt(MarkersDB, AlltagClass.ALLTagList[433].Offset).ToString();
                PanelControl = S7.GetBitAt(MarkersDB, AlltagClass.ALLTagList[429].Offset, AlltagClass.ALLTagList[429].BitNo);

                int EkranAciklama = S7.GetIntAt(MarkersDB, AlltagClass.ALLTagList[399].Offset);
                if (S7.GetBitAt(BufferDB6, 19, 1))
                    btnManuel.BackColor = Color.Green;
                else
                    btnManuel.BackColor = Color.Gray;
                if (S7.GetBitAt(BufferDB6, 19, 3))
                    btnOtmHazir.BackColor = Color.Green;
                else
                    btnOtmHazir.BackColor = Color.Gray;
                if (S7.GetBitAt(BufferDB6, 19, 2))
                    btnOtomatikCal.BackColor = Color.Green;
                else
                    btnOtomatikCal.BackColor = Color.Gray;



                tbTopStep.Text = S7.GetIntAt(BufferDB6, 30).ToString();
                tbMikserStep.Text = S7.GetIntAt(BufferDB6, 32).ToString();
                int mikserStep = S7.GetIntAt(BufferDB6, 32);
                lbKuruSure.Text = (S7.GetDWordAt(timer112DB, 8) / 1000).ToString();
                lbSuluSure.Text = (S7.GetDWordAt(timer113DB, 8) / 1000).ToString();
                tbKuruSetSure.Text = (Convert.ToDouble((S7.GetDWordAt(MikserDB, 30))) / 1000).ToString();
                double k = Convert.ToDouble(S7.GetDWordAt(MikserDB, 34)) / 1000;

                tbSuluSetSure.Text = k.ToString();

                tbAnaStepNo.Text = S7.GetWordAt(MarkersDB, AlltagClass.ALLTagList[452].Offset).ToString();
                tbToplamaSetSira.Text = S7.GetIntAt(PaketlemeDB, AlltagClass.ALLTagList[229].Offset).ToString();
                tbToplamaYapSira.Text = S7.GetIntAt(PaketlemeDB, AlltagClass.ALLTagList[298].Offset).ToString();

                tbTopRecete.Text = S7.GetStringAt(Buffer, 84);
                tbRecete.Text = S7.GetStringAt(Buffer, 54);
                tbYapCim.Text = S7.GetIntAt(BufferDB6, 36).ToString();
                tbYapSu.Text = S7.GetIntAt(BufferDB6, 92).ToString();

                tbSetCimVal.Text = S7.GetIntAt(MikserDB, AlltagClass.ALLTagList[185].Offset).ToString();
                tbSetSuVa.Text = S7.GetIntAt(MikserDB, AlltagClass.ALLTagList[202].Offset).ToString();

                //SENSÖRLER
                if (S7.GetBitAt(BufferDB6, 7, 6))
                {
                    snsHarcKapakKapali1.BackColor = Color.LimeGreen;
                    snsHarKapak11.BackColor = Color.LimeGreen;
                }

                else
                {
                    snsHarcKapakKapali1.BackColor = Color.Blue;
                    snsHarKapak11.BackColor = Color.Blue;
                }


                if (S7.GetBitAt(BufferDB6, 7, 7))
                {
                    snsHarcKapakKapali2.BackColor = Color.LimeGreen;
                    snsHarcKapak22.BackColor = Color.LimeGreen;
                        }

                else
                {
                    snsHarcKapakKapali2.BackColor = Color.Blue;
                    snsHarcKapak22.BackColor = Color.Blue;
                }

                if (S7.GetBitAt(BufferDB6, 7, 4))
                    snsHarcDolu1.BackColor = Color.LimeGreen;
                else
                    snsHarcDolu1.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 7, 5))
                    snsHarcDolu2.BackColor = Color.LimeGreen;
                else
                    snsHarcDolu2.BackColor = Color.Blue;


                if (S7.GetBitAt(BufferDB6, 2, 4))
                    snsKalYukYvs.BackColor = Color.LimeGreen;
                else
                    snsKalYukYvs.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 2, 3))
                    snsKalAsg.BackColor = Color.LimeGreen;
                else
                    snsKalAsg.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 2, 2))
                    snsKalYuk.BackColor = Color.LimeGreen;
                else
                    snsKalYuk.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 0, 0))
                    snsAltKlpYuk.BackColor = Color.LimeGreen;
                else
                    snsAltKlpYuk.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 0, 1))
                    snsAltKlpAsg.BackColor = Color.LimeGreen;
                else
                    snsAltKlpAsg.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 0, 2))
                    snsUstKlpYuk.BackColor = Color.LimeGreen;
                else
                    snsUstKlpYuk.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 108, 6))
                    snsUstKlpAsg2.BackColor = Color.LimeGreen;
                else
                    snsUstKlpAsg2.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 0, 3))
                    snsUstKlpAsg.BackColor = Color.LimeGreen;
                else
                    snsUstKlpAsg.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 2, 0))
                    snsKalicinYvs.BackColor = Color.LimeGreen;
                else
                    snsKalicinYvs.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 2, 1))
                    snsKalicinDur.BackColor = Color.LimeGreen;
                else
                    snsKalicinDur.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 2, 5))
                    snsKalAsgYvs.BackColor = Color.LimeGreen;
                else
                    snsKalAsgYvs.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 2, 6))
                    snsKalAsnDolu.BackColor = Color.LimeGreen;
                else
                    snsKalAsnDolu.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 0, 4))
                    snsP1ileri.BackColor = Color.LimeGreen;
                else
                    snsP1ileri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 0, 5))
                    snsP1geri.BackColor = Color.LimeGreen;
                else
                    snsP1geri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 0, 6))
                    snsP2ileri.BackColor = Color.LimeGreen;
                else
                    snsP2ileri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 0, 7))
                    snsP2geri.BackColor = Color.LimeGreen;
                else
                    snsP2geri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 1, 0))
                    snsP3ileri.BackColor = Color.LimeGreen;
                else
                    snsP3ileri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 1, 1))
                    snsP3Geri.BackColor = Color.LimeGreen;
                else
                    snsP3Geri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 1, 2))
                    snsİndirmeYuk.BackColor = Color.LimeGreen;
                else
                    snsİndirmeYuk.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 1, 3))
                    snsİndirmeAsg.BackColor = Color.LimeGreen;
                else
                    snsİndirmeAsg.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 1, 4))
                    snsPaletvar.BackColor = Color.LimeGreen;
                else
                    snsPaletvar.BackColor = Color.Blue;
              
                if (S7.GetBitAt(BufferDB6, 1, 6))
                    snsHarcTekileri.BackColor = Color.LimeGreen;
                else
                    snsHarcTekileri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 1, 7))
                    snsHarcTekGeri.BackColor = Color.LimeGreen;
                else
                    snsHarcTekGeri.BackColor = Color.Blue;
                //Palet Yollari
                if (S7.GetBitAt(BufferDB6, 0, 5))//Palet1ler
                    snsAltP1Geri.BackColor = Color.LimeGreen;
                else
                    snsAltP1Geri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 8, 4))
                    snsAltP1Geriyvs.BackColor = Color.LimeGreen;
                else
                    snsAltP1Geriyvs.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 0, 4))
                    snsAltP1ileri.BackColor = Color.LimeGreen;
                else
                    snsAltP1ileri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 8, 3))
                    snsAltP1ileriyavas.BackColor = Color.LimeGreen;
                else
                    snsAltP1ileriyavas.BackColor = Color.Blue;
                //Palet2
                if (S7.GetBitAt(BufferDB6, 0, 7))
                    snsAltP2Geri.BackColor = Color.LimeGreen;
                else
                    snsAltP2Geri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 8, 6))
                    snsAltP2Geriyvs.BackColor = Color.LimeGreen;
                else
                    snsAltP2Geriyvs.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 8, 5))
                    snsAltP2ileriyvs.BackColor = Color.LimeGreen;
                else
                    snsAltP2ileriyvs.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 0, 6))
                    snsAltP2ileri.BackColor = Color.LimeGreen;
                else
                    snsAltP2ileri.BackColor = Color.Blue;//LED_Palet32

                if (S7.GetBitAt(BufferDB6, 108, 1))
                    snsP3Sonda.BackColor = Color.LimeGreen;
                else
                    snsP3Sonda.BackColor = Color.Blue;
                //Palet 3
                if (S7.GetBitAt(BufferDB6, 1, 1))
                    snsAltP3Geri.BackColor = Color.LimeGreen;
                else
                    snsAltP3Geri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 9, 0))
                    snsAltP3Geriyvs.BackColor = Color.LimeGreen;
                else
                    snsAltP3Geriyvs.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 8, 7))
                    snsAltP3ileriyvs.BackColor = Color.LimeGreen;
                else
                    snsAltP3ileriyvs.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 1, 0))
                    snsAltP3ileri.BackColor = Color.LimeGreen;
                else
                    snsAltP3ileri.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 11, 6))
                    snsPTersC.BackColor = Color.LimeGreen;
                else
                    snsPTersC.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 11, 7))
                    snsPTersC2.BackColor = Color.LimeGreen;
                else
                    snsPTersC2.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 12, 0))
                    snsPTersC3.BackColor = Color.LimeGreen;
                else
                    snsPTersC3.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 12, 1))
                    snsPTersC3.BackColor = Color.LimeGreen;
                else
                    snsPTersC3.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 10, 2))//Markers okuyor
                    snsPaletTersCozdu.BackColor = Color.LimeGreen;
                else
                    snsPaletTersCozdu.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 6, 5))
                    snsPTersCevIleri.BackColor = Color.LimeGreen;
                else
                    snsPTersCevIleri.BackColor = Color.Blue; //snsPTersCevGeri
                if (S7.GetBitAt(BufferDB6, 6, 7))
                    snsPTersCevGeri.BackColor = Color.LimeGreen;
                else
                    snsPTersCevGeri.BackColor = Color.Blue;


                //Mikser
                if (S7.GetBitAt(BufferDB6, 3, 1))
                {
                    if (val == 0)
                    {
                      
                        val = 1;
                    }
                    else if (val == 1)
                    {
                        
                        val = 2;
                    }
                    else if (val == 2)
                    {
                        

                        val = 0;
                    }
                    snsMCalisti.BackColor = Color.LimeGreen;
                }

                else
                {
                    snsMCalisti.BackColor = Color.Blue;
                }

                if (S7.GetBitAt(BufferDB6, 3, 2))
                    snsKlepeKapali.BackColor = Color.LimeGreen;
                else
                    snsKlepeKapali.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 3))
                    snsKlepeAcik.BackColor = Color.LimeGreen;
                else
                    snsKlepeAcik.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 4))
                    snsAsnYuk.BackColor = Color.LimeGreen;
                else
                    snsAsnYuk.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 5))
                    snsAsnAsagida.BackColor = Color.LimeGreen;
                else
                    snsAsnAsagida.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 6))
                    snsAsnBekleme.BackColor = Color.LimeGreen;
                else
                    snsAsnBekleme.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 3, 7))
                    snsAsnEmny.BackColor = Color.LimeGreen;
                else
                    snsAsnEmny.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 4, 0))
                    snsPalet1Fotoseli.BackColor = Color.LimeGreen;
                else
                    snsPalet1Fotoseli.BackColor = Color.Blue;
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
              
                if (S7.GetBitAt(BufferDB6, 4, 3))
                    snsKiriciBantDur.BackColor = Color.LimeGreen;
                else
                    snsKiriciBantDur.BackColor = Color.Blue;
                //TOPLAMA 
                if (S7.GetBitAt(BufferDB6, 4, 6))
                    snsTopileri.BackColor = Color.LimeGreen;
                else
                    snsTopileri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 4, 7))
                    snsTopGeri.BackColor = Color.LimeGreen;
                else
                    snsTopGeri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 5, 0))
                    snsCatalYuk.BackColor = Color.LimeGreen;
                else
                    snsCatalYuk.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 18, 3))
                    snsCatalAsagi.BackColor = Color.LimeGreen;
                else
                    snsCatalAsagi.BackColor = Color.Blue;


                if (S7.GetBitAt(BufferDB6, 5, 1))
                    snsTopAsagi.BackColor = Color.LimeGreen;
                else
                    snsTopAsagi.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 5, 5))
                    snsTopYukari.BackColor = Color.LimeGreen;
                else
                    snsTopYukari.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 4, 5))
                    snsTopEmniyet.BackColor = Color.Blue;
                else
                    snsTopEmniyet.BackColor = Color.LimeGreen;

                if (S7.GetBitAt(BufferDB6, 5, 2))
                    snsTopCevileri.BackColor = Color.LimeGreen;
                else
                    snsTopCevileri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 5, 3))
                    snsTopCevGeri.BackColor = Color.LimeGreen;
                else
                    snsTopCevGeri.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 5, 4))
                    snsTopAcil.BackColor = Color.Red;
                else
                    snsTopAcil.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 5, 7))
                    snsCatalileri.BackColor = Color.LimeGreen;
                else
                    snsCatalileri.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 10, 5))
                    snsSeritIleride.BackColor = Color.LimeGreen;
                else
                    snsSeritIleride.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 10, 4))
                    snsSeritGeride.BackColor = Color.LimeGreen;
                else
                    snsSeritGeride.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 10, 6))
                    snsSerit2Acil.BackColor = Color.Red;
                else
                    snsSerit2Acil.BackColor = Color.Blue;

               
               
                
                if (S7.GetBitAt(BufferDB6, 6, 6))
                    snsKatmerliSayma.BackColor = Color.LimeGreen;
                else
                    snsKatmerliSayma.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 7, 0))
                    snsKatmerliDolu.BackColor = Color.LimeGreen;
                else
                    snsKatmerliDolu.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 7, 1))
                    snsZincirliMalzVar.BackColor = Color.LimeGreen;
                else
                    snsZincirliMalzVar.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 7, 2))
                    snsTopGeriYvs.BackColor = Color.LimeGreen;
                else
                    snsTopGeriYvs.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 9, 1))
                    snsTopOrtada.BackColor = Color.LimeGreen;
                else
                    snsTopOrtada.BackColor = Color.Blue;
                //Acil
                if (S7.GetBitAt(BufferDB6, 9, 4))
                    snsSeritAcil.BackColor = Color.Red;
                else
                    snsSeritAcil.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 9, 3))
                    snsCatalAcil.BackColor = Color.Red;
                else
                    snsCatalAcil.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 10, 0))
                    snsKaldirmaAcil.BackColor = Color.Red;
                else
                    snsKaldirmaAcil.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 10, 1))
                    snsIndirmeAcil.BackColor = Color.Red;
                else
                    snsIndirmeAcil.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 4, 2))
                    snsKiriciAcil.BackColor = Color.Red;
                else
                    snsKiriciAcil.BackColor = Color.Blue;
              

                //7.SIRA SENSÖRLERİ

                if (S7.GetBitAt(BufferDB6, 6, 3))
                    snsSira7CevIleride.BackColor = Color.LimeGreen;
                else
                    snsSira7CevIleride.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 6, 4))
                    snsSira7CevGeride.BackColor = Color.LimeGreen;
                else
                    snsSira7CevGeride.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 6, 2))
                    snsSira7Yukarida.BackColor = Color.LimeGreen;
                else
                    snsSira7Yukarida.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 6, 1))
                    snsSira7AsagidaBek.BackColor = Color.LimeGreen;
                else
                    snsSira7AsagidaBek.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 6, 0))
                    snsSira7Asagida.BackColor = Color.LimeGreen;
                else
                    snsSira7Asagida.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 5, 5))
                    snsSira7YukYavas.BackColor = Color.LimeGreen;
                else
                    snsSira7YukYavas.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 10, 3))
                    snsS7ACIL.BackColor = Color.Red;
                else
                    snsS7ACIL.BackColor = Color.Blue;


                //Lazerler
                if (S7.GetBitAt(BufferDB6, 7, 6))
                    snsDikeyYvslama.BackColor = Color.LimeGreen;
                else
                    snsDikeyYvslama.BackColor = Color.Blue;

                if (S7.GetBitAt(BufferDB6, 5, 6))
                    snsTopSik1.BackColor = Color.LimeGreen;
                else
                    snsTopSik1.BackColor = Color.Blue;
                if (S7.GetBitAt(BufferDB6, 5, 6))
                    snsTopSik2.BackColor = Color.LimeGreen;
                else
                    snsTopSik2.BackColor = Color.Blue;

                lblLzrHarc.Text = S7.GetIntAt(MarkersDB, 236).ToString();
                //lblLzrMasa.Text = S7.GetDIntAt(MarkersDB, 170).ToString();
                //lblZincirliLzr.Text = S7.GetDIntAt(MarkersDB, 166).ToString();
                lblCimSev.Text = S7.GetIntAt(BufferDB6, 36).ToString();

                
                if (S7.GetBitAt(MikserDB, 142, 7))
                    tgOnceSu.Checked = true;
                else
                    tgOnceSu.Checked = false;

                //Toplama Tarafi

                lblPPT.Text = S7.GetWordAt(BufferDB6, 88).ToString();
                lblQQT.Text = S7.GetWordAt(BufferDB6, 90).ToString();
                tbTopigKonum.Text = S7.GetIntAt(BufferDB6, 44).ToString();
               
                lblTopYukAsgKnm.Text = S7.GetIntAt(BufferDB6, 42).ToString();

                bool kiricidevrede = S7.GetBitAt(BufferDB6, 17, 7);
                if (kiricidevrede)
                {
                    btnKiriciDevAl.Text="Kırıcılar Devrede";
                    btnKiriciDevAl.BackColor = Color.Purple;
                }
                else
                {
                    btnKiriciDevAl.Text = "Kırıcılar Devreye Al";
                    btnKiriciDevAl.BackColor = Color.Gray;
                }

                bool kirici = S7.GetBitAt(BufferDB6, 15, 2);
                if (kirici)
                    button25.BackColor = Color.LimeGreen;
                else
                    button25.BackColor = Color.Gray;
                bool kiriciBandi = S7.GetBitAt(BufferDB6, 15, 3);
                if (kiriciBandi)
                    button26.BackColor = Color.LimeGreen;
                else
                    button26.BackColor = Color.Gray;
                bool CimHelezon = S7.GetBitAt(BufferDB6, 14, 7);
                if (CimHelezon)
                    btnCimHel.BackColor = Color.LimeGreen;
                else
                   btnCimHel.BackColor = Color.Gray;

                bool KiriciKapak = S7.GetBitAt(BufferDB6, 14, 6);
                if (KiriciKapak)
                    btnkiricikapakk.BackColor = Color.LimeGreen;
                else
                    btnkiricikapakk.BackColor = Color.Gray;

                bool CimBasolt = S7.GetBitAt(BufferDB6, 14, 5);
                if (CimBasolt)
                    btnCimkapak.BackColor = Color.LimeGreen;
                else
                    btnCimkapak.BackColor = Color.Gray;



                bool sudolum = S7.GetBitAt(BufferDB6, 14, 4);
                if (sudolum)
                    btnSudolum.BackColor = Color.DodgerBlue;
                else
                    btnSudolum.BackColor = Color.Gray;


                bool pressdur = S7.GetBitAt(MarkersDB, AlltagClass.ALLTagList[432].Offset, AlltagClass.ALLTagList[432].BitNo);
                if (pressdur)
                {
                    if (btnPressDur.BackColor == Color.Blue)
                        btnPressDur.BackColor = Color.Gray;
                    else
                        btnPressDur.BackColor = Color.Blue;

                }
                else
                    btnPressDur.BackColor = Color.Gray;
                switch (EkranAciklama)
                {
                    case 0:
                        tbSystemDurumu.Text = "System Kapalı";
                        break;
                    case 1:
                        tbSystemDurumu.Text = "Manuel Kumanda";
                        break;
                    case 2:
                        tbSystemDurumu.Text = "Otomatik Kumanda";
                        break;
                    case 3:
                        tbSystemDurumu.Text = "Harç Var ise Start";
                        break;
                    case 4:
                        tbSystemDurumu.Text = "Otm. Start ile Başla";
                        break;
                    case 5:
                        tbSystemDurumu.Text = "Emniyet Basınç Alarmı";
                        break;
                    case 6:
                        tbSystemDurumu.Text = "Alt Kalıp Yukarı";
                        break;
                    case 7:
                        tbSystemDurumu.Text = "Alt Kalıp Aşağı";
                        break;
                    case 8:
                        tbSystemDurumu.Text = "Üst Kalıp Yukarı";
                        break;
                    case 9:
                        tbSystemDurumu.Text = "Üst Kalıp Aşağı";
                        break;
                    case 10:
                        tbSystemDurumu.Text = "Harç Teknesi İleri";
                        break;
                    case 11:
                        tbSystemDurumu.Text = "Harç Teknesi Geri";
                        break;
                    case 12:
                        tbSystemDurumu.Text = "Palet Çekme 1 İleri";
                        break;
                    case 13:
                        tbSystemDurumu.Text = "Palet Çekme 1 Geri";
                        break;
                    case 14:
                        tbSystemDurumu.Text = "Alt Vibrasyon";
                        break;
                    case 15:
                        tbSystemDurumu.Text = "Harç Yerleştirme İleri";
                        break;
                    case 16:
                        tbSystemDurumu.Text = "Harç Yerleştirme Geri";
                        break;
                    case 17:
                        tbSystemDurumu.Text = "Alt Kalıp Aşağıda Değil";
                        break;
                    case 18:
                        tbSystemDurumu.Text = "Üst Kalıp Yukarıda Değil";
                        break;
                    case 19:
                        tbSystemDurumu.Text = "Harç Teknesi Geride Değil";
                        break;
                    case 20:
                        tbSystemDurumu.Text = "Palet Çekme 1 İleride Değil";
                        break;
                    case 21:
                        tbSystemDurumu.Text = "Boş Palet Bitti !..";
                        break;
                    case 22:
                        tbSystemDurumu.Text = "Harç Bitti !.. ";
                        break;
                    case 23:
                        tbSystemDurumu.Text = "Palet Çekme 2 Geride Değil";
                        break;
                    case 24:
                        tbSystemDurumu.Text = "Palet Çekme 3 Geride Değil";
                        break;
                    case 25:
                        tbSystemDurumu.Text = "";
                        break;
                    case 26:
                        tbSystemDurumu.Text = "";
                        break;
                    case 27:
                        tbSystemDurumu.Text = "";
                        break;
                    case 28:
                        tbSystemDurumu.Text = "";
                        break;
                    case 29:
                        tbSystemDurumu.Text = "İndirme Asn. Yukarı";
                        break;
                    case 30:
                        tbSystemDurumu.Text = "İndirme Asn. Aşağı";
                        break;
                    case 31:
                        tbSystemDurumu.Text = "Kaldırma Asn. Yukarı";
                        break;
                    case 32:
                        tbSystemDurumu.Text = "Kaldırma Asn. Aşağı";
                        break;
                    case 33:
                        tbSystemDurumu.Text = "Palet Çekme 2 İleri";
                        break;
                    case 34:
                        tbSystemDurumu.Text = "Palet Çekme 2 Geri";
                        break;
                    case 35:
                        tbSystemDurumu.Text = "Palet Çekme 3 İleri";
                        break;
                    case 36:
                        tbSystemDurumu.Text = "Palet Çekme 3 Geri";
                        break;
                    case 37:
                        tbSystemDurumu.Text = "Palet Ters Çevirme";
                        break;
                    case 38:
                        tbSystemDurumu.Text = "Toplama İleri";
                        break;
                    case 39:
                        tbSystemDurumu.Text = "";
                        break;
                    case 40:
                        tbSystemDurumu.Text = "Toplama Geri";
                        break;
                    case 41:
                        tbSystemDurumu.Text = "";
                        break;
                    case 42:
                        tbSystemDurumu.Text = "Toplama Aşağı";
                        break;
                    case 43:
                        tbSystemDurumu.Text = "Toplama Yukarı";
                        break;
                    case 44:
                        tbSystemDurumu.Text = "Toplama Sıkıştır";
                        break;
                    case 45:
                        tbSystemDurumu.Text = "Toplama Çöz";
                        break;
                    case 46:
                        tbSystemDurumu.Text = "Toplama Çevirme İleri";
                        break;
                    case 47:
                        tbSystemDurumu.Text = "Toplama Çevirme Geri";
                        break;
                }

                if (mikserStep == 0)
                {
                    btnMalzBek.BackColor = Color.Gray;
                    btnMalzAlindi.BackColor = Color.Gray;
                    btnCimAlindi.BackColor = Color.Gray;
                    btnKuruKrsmSrc.BackColor = Color.Gray;
                    btnSuluKrsmSrc.BackColor = Color.Gray;
                    btnHarcGonderiliyo.BackColor = Color.Gray;
                }
                else if (mikserStep < 20 && mikserStep > 0)
                {
                    btnMalzBek.BackColor = Color.Green;
                    btnMalzAlindi.BackColor = Color.Gray;
                    btnCimAlindi.BackColor = Color.Gray;
                    btnKuruKrsmSrc.BackColor = Color.Gray;
                    btnSuluKrsmSrc.BackColor = Color.Gray;
                    btnHarcGonderiliyo.BackColor = Color.Gray;
                }
                else if (mikserStep <= 20 && mikserStep > 0)
                {
                    btnMalzBek.BackColor = Color.Gray;
                    btnMalzAlindi.BackColor = Color.Green;
                    btnCimAlindi.BackColor = Color.Gray;
                    btnKuruKrsmSrc.BackColor = Color.Gray;
                    btnSuluKrsmSrc.BackColor = Color.Gray;
                    btnHarcGonderiliyo.BackColor = Color.Gray;
                }
                else if (mikserStep <= 30 && mikserStep > 0)
                {
                    btnMalzBek.BackColor = Color.Gray;
                    btnMalzAlindi.BackColor = Color.Green;
                    btnCimAlindi.BackColor = Color.Green;
                    btnKuruKrsmSrc.BackColor = Color.Green;
                    btnSuluKrsmSrc.BackColor = Color.Gray;
                    btnHarcGonderiliyo.BackColor = Color.Gray;
                }
                else if (mikserStep <= 40 && mikserStep > 0)
                {
                    btnMalzBek.BackColor = Color.Gray;
                    btnMalzAlindi.BackColor = Color.Green;
                    btnCimAlindi.BackColor = Color.Green;
                    btnKuruKrsmSrc.BackColor = Color.Green;
                    btnSuluKrsmSrc.BackColor = Color.Green;
                    btnHarcGonderiliyo.BackColor = Color.Gray;
                }
                else if (mikserStep <= 52 && mikserStep > 0)
                {
                    btnMalzBek.BackColor = Color.Gray;
                    btnMalzAlindi.BackColor = Color.Green;
                    btnCimAlindi.BackColor = Color.Green;
                    btnKuruKrsmSrc.BackColor = Color.Green;
                    btnSuluKrsmSrc.BackColor = Color.Green;
                    btnHarcGonderiliyo.BackColor = Color.Gray;
                }
                else if (mikserStep <= 120 && mikserStep > 0)
                {
                    btnMalzBek.BackColor = Color.Gray;
                    btnMalzAlindi.BackColor = Color.Gray;
                    btnCimAlindi.BackColor = Color.Gray;
                    btnKuruKrsmSrc.BackColor = Color.Gray;
                    btnSuluKrsmSrc.BackColor = Color.Gray;
                    btnHarcGonderiliyo.BackColor = Color.Green;
                }
                if (PanelControl)
                {
                    btnTopYuk.Visible = true;
                    btnTopAsag.Visible = true;
                    btnTopCoz.Visible = true;
                    btnTopSik.Visible = true;
                    btnTopileri.Visible = true;
                    btnTopGeri.Visible = true;
                    btnTopCevileri.Visible = true;
                    btnTopCevGeri.Visible = true;
                    btnAltKlpAsagi.Visible = true;
                    btnAltKlpYukari.Visible = true;
                    btnUstKlpAsagi.Visible = true;
                    btnUstKlpYuk.Visible = true;
                    btnVibstart.Visible = true;
                    btnP2Geri.Visible = true;
                    btnP2ileri.Visible = true;
                    btnP3geri.Visible = true;
                    btnP3ileri.Visible = true;
                    btnZinGeri.Visible = true;
                    btnZincirliileri.Visible = true;
                    btnDikeyileri.Visible = true;
                    btnDikeyGeri.Visible = true;
                    btnP1ileri.Visible = true;
                    btnP1Geri.Visible = true;
                    btnHarcTekileri.Visible = true;
                    btnHarcTekGeri.Visible = true;
                    btnKatmerliPaket.Visible = true;
                    btnKatmerliStart.Visible = true;
                    if (btnPnlControl.BackColor == Color.Gray)
                        btnPnlControl.BackColor = Color.RoyalBlue;
                    else
                        btnPnlControl.BackColor = Color.Gray;

                }
                else
                {
                    btnPnlControl.BackColor = Color.Gray;
                    btnTopYuk.Visible = false;
                    btnTopAsag.Visible = false;
                    btnTopCoz.Visible = false;
                    btnTopSik.Visible = false;
                    btnTopileri.Visible = false;
                    btnTopGeri.Visible = false;
                    btnTopCevileri.Visible = false;
                    btnTopCevGeri.Visible = false;
                    btnAltKlpAsagi.Visible = false;
                    btnAltKlpYukari.Visible = false;
                    btnUstKlpAsagi.Visible = false;
                    btnUstKlpYuk.Visible = false;
                    btnVibstart.Visible = false;
                    btnP2Geri.Visible = false;
                    btnP2ileri.Visible = false;
                    btnP3geri.Visible = false;
                    btnP3ileri.Visible = false;
                    btnZinGeri.Visible = false;
                    btnZincirliileri.Visible = false;
                    btnDikeyileri.Visible = false;
                    btnDikeyGeri.Visible = false;
                    btnP1ileri.Visible = false;
                    btnP1Geri.Visible = false;
                    btnHarcTekileri.Visible = false;
                    btnHarcTekGeri.Visible = false;
                    btnKatmerliPaket.Visible = false;
                    btnKatmerliStart.Visible = false;

                }

            }
        }

        private void test(object sender, EventArgs e)
        {
            
             if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnKiriciDevAl_Click(object sender, EventArgs e)
        {
            string val = read_Tag(AlltagClass.ALLTagList[416]);
            if (val == "true")
            {
                writePLC(AlltagClass.ALLTagList[416], false, 0);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[416], true, 0);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string val = read_Tag(AlltagClass.ALLTagList[362]);
            if (val == "true")
            {
                writePLC(AlltagClass.ALLTagList[362], false, 0);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[362], true, 0);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string val = read_Tag(AlltagClass.ALLTagList[360]);
            if (val == "true")
            {
                writePLC(AlltagClass.ALLTagList[360], false, 0);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[360], true, 0);
            }
        }

        private void btnCimHel_Click(object sender, EventArgs e)
        {
            string val = read_Tag(AlltagClass.ALLTagList[348]);
            if (val == "true")
            {
                writePLC(AlltagClass.ALLTagList[348], false, 0);
           }
           else
            {
                writePLC(AlltagClass.ALLTagList[348], true, 0);
            }
           
        }

        private void btnHarcKapakk_Click(object sender, EventArgs e)
        {
            //string val = read_Tag(AlltagClass.ALLTagList[347]);
            //if (val == "true")
            //{
            //    writePLC(AlltagClass.ALLTagList[347], false, 0);
            //}
            //else
            //{
            //    writePLC(AlltagClass.ALLTagList[347], true, 0);
            //}
            
        }

        private void btnOperatorScreen(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (ClientAna.Connected)
                ClientAna.Disconnect();
            Ekranlar.OpenOperatprScreen(this);
        }

        private void btnCimkapak_Click(object sender, EventArgs e)
        {
            string val = read_Tag(AlltagClass.ALLTagList[347]);
            if (val == "true")
            {
                writePLC(AlltagClass.ALLTagList[347], false, 0);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[347], true, 0);
            }
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            string val = read_Tag(AlltagClass.ALLTagList[377]);
            if (val == "true")
            {
                writePLC(AlltagClass.ALLTagList[377], false, 0);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[377], true, 0);
            }
        }

        private void tgOnceSu_CheckedChanged(object sender, EventArgs e)
        {
            if (tgOnceSu.Checked)
            {
                writePLC(AlltagClass.ALLTagList[677], true, 0);
            }
            else
            {
                writePLC(AlltagClass.ALLTagList[677], false, 0);
            }
        }

        private void tbToplamaSetSira_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[229], 1, 9, 0);
            f.ShowDialog(this);
        }
    }
        
}
