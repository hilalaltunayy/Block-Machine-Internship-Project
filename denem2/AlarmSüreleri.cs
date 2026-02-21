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

namespace denem2
{
    public partial class AlarmSüreleri : Form
    {
        private S7Client Client;
        private int Result;


       
        private byte[] DBPaketleme = new byte[600];
        
        private byte[] Db9 = new byte[200];
       
        private byte[] DBKalip = new byte[600];
        private byte[] DB100 = new byte[600];
      

        public AlarmSüreleri()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            GoFullscreen(true);
            CustumizeDesign();
    
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

        private void AlarmSüreleri_Load(object sender, EventArgs e)
        {

            //backgroundWorker1.RunWorkerAsync();
            CPUbaglan();
            timer1.Enabled=true;

            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            eprsgrpbx.BackColor=Sistem.PanelsColor;
            groupBox1.BackColor = Sistem.PanelsColor;
            groupBox2.BackColor = Sistem.PanelsColor;


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
            button33.BackColor = Sistem.ustbuttoncolor;
            button32.BackColor = Sistem.ustbuttoncolor;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
                   

        }
        private int writePLC(PLCTag gelentag, bool boolvalue, int othersvalue)
        {
             
            try
            {
               
                if(Result == 0 && Client.Connected)
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
                           
                            ShowResult(Result);
                            return Result;
                        }
                        else if (gelentag.Tip == "real")
                        {
                            byte[] realArray = new byte[4];
                            int val = Convert.ToInt32(othersvalue);
                            realArray = BitConverter.GetBytes(val);
                            Result = Client.WriteArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLReal, realArray);
                           
                            ShowResult(Result);
                            return Result;
                        }
                        else
                        {
                            Debug.WriteLine("Test bit yazma :");
                           

                            ShowResult(Result);
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

                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, aa);
                           
                            ShowResult(Result);
                            return Result;
                        }
                        else if (gelentag.Tip == "dint")
                        {
                            byte[] realArray = new byte[4];
                            Int32 val = Convert.ToInt32(othersvalue);
                            realArray = BitConverter.GetBytes(val);
                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDInt, realArray);
                            
                            ShowResult(Result);
                            return Result;
                        }
                        else if (gelentag.Tip == "real")
                        {
                            byte[] realArray = new byte[4];
                            int val = Convert.ToInt32(othersvalue);
                            realArray = BitConverter.GetBytes(val);
                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLReal, realArray);
                            
                            ShowResult(Result);
                            return Result;
                        }
                        else
                        {
                            Debug.WriteLine("Test bit yazma :");
                          
                            ShowResult(Result);
                            return 0;

                        }
                    }
                    else
                    {
                        Debug.WriteLine("Test bit yazma :error");
                      
                        ShowResult(Result);
                        return 0;
                    }
                }
                else
                {
                    
                    ShowResult(Result);
                    return 0;
                }
            }catch (Exception ex)
            {
               
                ShowResult(Result);
                return 0;
            }


        }

        private void ealtklpyu_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[305], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void ealtklpasa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[304], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eustklpyu_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[337], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eustklpasa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[336], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void etkneileri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[328], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void etnkgeri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[327], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eplt1ileri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[322], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eplt1geri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[321], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eplt2ileri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[324], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eplt2geri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[323], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eplt3ileri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[326], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eplt3geri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[325], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void einasyuk_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[313], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void einasasa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[312], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void ekalyu_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[315], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void ekalasa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[314], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eonbant_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[320], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void epltcev_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[329], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void ecimcal_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[309], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void ecimbos_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[308], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void easanyu_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[307], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void easnasa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[306], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eklpacma_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[316], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void eklpkpt_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[317], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void ezinileri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[339], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void ezingeri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[338], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void edikileri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[311], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void edikgeri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[310], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void emasaileri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[319], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void emasageri_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[318], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void etopyuk_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[335], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void etopasa_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[332], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void etopig_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[334], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void etopcev_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[331], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void ecatalig_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[331], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void ecatalya_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[331], 1000, 9999, 0);
            f.ShowDialog(this);
        }

        private void prsyagsıfır_Click(object sender, EventArgs e)
        {
             writePLC(AlltagClass.ALLTagList[121], false, 0);
            
        }

        private void vbroygkntrlsıfır_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[671], false, 0);
        }

        private void vbroyagsıfır_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[672], false, 0);
        }

        private void tophidyagsfr_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[277], false, 0);
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

                    Result = Client.ReadArea(S7Consts.S7AreaDB, 9, 0, 144, S7Consts.S7WLByte, Db9);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 4, 0, 548, S7Consts.S7WLByte, DBKalip);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 100, 0, 84, S7Consts.S7WLByte, DB100);
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
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Result == 0)
            {
               // ealtklpyu.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 0))) / 1000).ToString();
                ealtklpasa.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 4))) / 1000).ToString();
                eustklpyu.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 8))) / 1000).ToString();
                eustklpasa.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 12))) / 1000).ToString();
                etkneileri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 16))) / 1000).ToString();
                etnkgeri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 20))) / 1000).ToString();

                eplt1ileri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 24))) / 1000).ToString();
                eplt1geri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 28))) / 1000).ToString();
                eplt2ileri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 32))) / 1000).ToString();
                eplt2geri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 36))) / 1000).ToString();
                eplt3ileri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 40))) / 1000).ToString();
                eplt3geri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 44))) / 1000).ToString();
                einasyuk.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 48))) / 1000).ToString();
                einasasa.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 52))) / 1000).ToString();
                ekalyu.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 56))) / 1000).ToString();
                ekalasa.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 60))) / 1000).ToString();
                eonbant.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 64))) / 1000).ToString();
                epltcev.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 68))) / 1000).ToString();

                ecimcal.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 72))) / 1000).ToString();
                ecimbos.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 76))) / 1000).ToString();
                easanyu.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 80))) / 1000).ToString();
                easnasa.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 84))) / 1000).ToString();
                eklpacma.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 88))) / 1000).ToString();
                eklpkpt.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 92))) / 1000).ToString();

                ezinileri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 96))) / 1000).ToString();
                ezingeri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 100))) / 1000).ToString();
                edikileri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 104))) / 1000).ToString();
                edikgeri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 108))) / 1000).ToString();
                emasaileri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 112))) / 1000).ToString();
                emasageri.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 116))) / 1000).ToString();
                etopyuk.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 120))) / 1000).ToString();
                etopasa.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 124))) / 1000).ToString();
                etopig.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 128))) / 1000).ToString();
                etopcev.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 136))) / 1000).ToString();
                ecatalig.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 136))) / 1000).ToString();
                ecatalya.Text = ((Convert.ToDouble(S7.GetDWordAt(Db9, 136))) / 1000).ToString();

                prsyagde.Text = (((S7.GetDIntAt(DBKalip, 400))) / 60).ToString();

                vibroygkntrl.Text = (((S7.GetIntAt(DB100, 4)))).ToString();

                vbroygdgsm.Text = (((S7.GetIntAt(DB100, 6)))).ToString();

                tophidyag.Text = (((S7.GetDIntAt(DBPaketleme, 256))) / 60).ToString();

                if ((((S7.GetDIntAt(DBKalip, 400))) / 60) > 240000)
                    prsyagsıfır.Show();
                else
                    prsyagsıfır.Hide();

                if ((((S7.GetIntAt(DB100, 4)))) > 7)
                    vbroygkntrlsıfır.Show();
                else
                    vbroygkntrlsıfır.Hide();

                if ((((S7.GetIntAt(DB100, 6)))) > 30)
                    vbroyagsıfır.Show();
                else
                    vbroyagsıfır.Hide();

                if ((((S7.GetDIntAt(DBPaketleme, 256))) / 60) > 240000)
                    tophidyagsfr.Show();
                else
                    tophidyagsfr.Hide();
            } 
        }

        private void AlarmSüreleri_Activated(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Enabled = true;

            panelAna.BackColor = Sistem.PanelsColor;
            panellogo.BackColor = Sistem.logocolor;
            eprsgrpbx.BackColor = Sistem.PanelsColor;
            groupBox1.BackColor = Sistem.PanelsColor;
            groupBox2.BackColor = Sistem.PanelsColor;


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
            button33.BackColor = Sistem.ustbuttoncolor;
            button32.BackColor = Sistem.ustbuttoncolor;
        }

        private void AlarmSüreleri_Deactivate(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Enabled = false;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            if (Client.Connected)
                Client.Disconnect();
            Ekranlar.OpenVardiyaScreen(this);
        }

        private void button32_Click(object sender, EventArgs e)
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
