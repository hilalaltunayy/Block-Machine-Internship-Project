//using CsvHelper;
using Sharp7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LINQtoCSV;
using Excel = Microsoft.Office.Interop.Excel;

namespace denem2
{
    public partial class Operator : Form
    {
        private S7Client Client;
        private int Result;
        private Excel.Application aa;
        Microsoft.Office.Interop.Excel.Application oXL;
        Microsoft.Office.Interop.Excel._Workbook oWB;
        Microsoft.Office.Interop.Excel._Worksheet oSheet;
        Microsoft.Office.Interop.Excel.Range oRng;
        object misvalue = System.Reflection.Missing.Value;


        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private byte[] DBPaketleme = new byte[600];
        private byte[] DBMikser = new byte[600];
        private byte[] timer112DB = new byte[36];
        private byte[] Db9 = new byte[200];
        private byte[] DBEkran8 = new byte[300];

        private byte[] timer113DB = new byte[36];

        private byte[] DB7 = new byte[350];
        private int sifre = 0;

        public Operator()
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
                    bglntld.BackColor = Color.Green;
                }
                else
                {
                    bglntld.BackColor = Color.Blue;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void Operator_Load(object sender, EventArgs e)
        {
            CPUbaglan();
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

                    Result = Client.ReadArea(S7Consts.S7AreaDB, 7, 0, 336, S7Consts.S7WLByte, DB7);
                    Result = Client.ReadArea(S7Consts.S7AreaMK, 0, 0, 320, S7Consts.S7WLByte, MarkersDB);
                    Result = Client.ReadArea(S7Consts.S7AreaDB, 8, 0, 250, S7Consts.S7WLByte, DBEkran8);
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
                tbSifre.Text = ((Convert.ToDouble(S7.GetIntAt(MarkersDB, 234)))).ToString();
                sifre = S7.GetIntAt(MarkersDB, 234);
                if (sifre == 7652)
                {
                    tbSetyil.Visible = true;
                    tbSetGun.Visible = true;
                    tbSetAy.Visible = true;
                    tbSetSaat.Visible = true;
                    tbSetDk.Visible = true;
                    tbSetSan.Visible = true;
                }
                else
                {
                    tbSetyil.Visible = false;
                    tbSetGun.Visible = false;
                    tbSetAy.Visible = false;
                    tbSetSaat.Visible = false;
                    tbSetDk.Visible = false;
                    tbSetSan.Visible = false;
                }

                tbMakOtmCalSureSa.Text = read_Tag(AlltagClass.ALLTagList[29]);
                tbMakOtmCalSuDk.Text = read_Tag(AlltagClass.ALLTagList[30]);
                tbUretımBaskAdet.Text = read_Tag((AlltagClass.ALLTagList[146]));
                tbYapKarisimAdet.Text = read_Tag((AlltagClass.ALLTagList[189]));
                tbKullCim.Text = read_Tag((AlltagClass.ALLTagList[478]));
                tbKalanCim.Text = read_Tag((AlltagClass.ALLTagList[33]));
                tbDisarCikanPakAdet.Text = read_Tag((AlltagClass.ALLTagList[296]));
                tbHarcBekSureSa.Text = read_Tag((AlltagClass.ALLTagList[479]));
                tbHarcBekSureDk.Text = read_Tag((AlltagClass.ALLTagList[480]));
                tbPakBekSureSaat.Text = read_Tag((AlltagClass.ALLTagList[481]));
                tbPakBekSureDk.Text = read_Tag((AlltagClass.ALLTagList[482]));
                tbPakBekSureSaat.Text = read_Tag((AlltagClass.ALLTagList[483]));
                tbPakBekSureDk.Text = read_Tag((AlltagClass.ALLTagList[484]));

               
                tbAktifYil.Text = S7.GetIntAt(DBEkran8,158).ToString();
                tbAktifAy.Text = S7.GetByteAt(DBEkran8, 160).ToString();
                tbAktifGun.Text = S7.GetByteAt(DBEkran8, 161).ToString();
              
                tbAktifSaat.Text = S7.GetByteAt(DBEkran8, 163).ToString();
                tbAktifDk.Text = S7.GetByteAt(DBEkran8, 164).ToString();

                tbAktifSaniye.Text = S7.GetByteAt(DBEkran8, 165).ToString();

                tbSetyil.Text= S7.GetIntAt(DBEkran8,140).ToString() ;
                tbSetAy.Text = S7.GetByteAt(DBEkran8, 142).ToString();
                tbSetGun.Text = S7.GetByteAt(DBEkran8, 143).ToString();
                tbSetSaat.Text = S7.GetByteAt(DBEkran8, 145).ToString();
                tbSetDk.Text = S7.GetByteAt(DBEkran8, 146).ToString();
                tbSetSan.Text = S7.GetByteAt(DBEkran8, 147).ToString();
                S7.GetDTLAt(DBEkran8,140).ToString();



            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[442], 1, 9999, 0);
            f.ShowDialog(this);
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

                            Result = Client.ReadArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLByte, bytearray);

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
                        else if (gelentag.Tip == "byte")
                        {
                            byte[] realArray = new byte[1];

                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 4, S7Consts.S7WLByte, realArray);

                            return S7.GetByteAt(realArray, 0).ToString();
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

       

        private void btnKaydetUretim_Click(object sender, EventArgs e)
        {
            if (sifre == 2945)
            {
              
                String tbMakOtmCalSureSa = read_Tag(AlltagClass.ALLTagList[29]);
                String tbMakOtmCalSuDk = read_Tag(AlltagClass.ALLTagList[30]);
                String tbUretımBaskAdet = read_Tag((AlltagClass.ALLTagList[146]));
                String tbYapKarisimAdet = read_Tag((AlltagClass.ALLTagList[189]));
                String tbKullCim = read_Tag((AlltagClass.ALLTagList[478]));
                String tbDisarCikanPakAdet = read_Tag((AlltagClass.ALLTagList[33]));
                String tbKalanCim = read_Tag((AlltagClass.ALLTagList[296]));
                String tbHarcBekSureSa = read_Tag((AlltagClass.ALLTagList[479]));
                String tbHarcBekSureDk = read_Tag((AlltagClass.ALLTagList[480]));
                String tbPakBekSureSaat = read_Tag((AlltagClass.ALLTagList[481]));
                String tbPakBekSureDk = read_Tag((AlltagClass.ALLTagList[482]));
                String tbPaletBekSureSaat = read_Tag((AlltagClass.ALLTagList[483]));
                String tbPaletBekSureDk = read_Tag((AlltagClass.ALLTagList[484]));

                int val1 = Convert.ToInt32(tbMakOtmCalSureSa);
                int val2 = Convert.ToInt32(tbMakOtmCalSuDk);
                int val3 = Convert.ToInt32(tbUretımBaskAdet);
                int val4 = Convert.ToInt32(tbYapKarisimAdet);
                double val5 = Convert.ToDouble(tbKullCim);
                double val6 = Convert.ToDouble(tbDisarCikanPakAdet);
                int val7 = Convert.ToInt32(tbKalanCim);
                int val8 = Convert.ToInt32(tbHarcBekSureSa);
                int val9 = Convert.ToInt32(tbHarcBekSureDk);
                int val10 = Convert.ToInt32(tbPakBekSureSaat);
                int val11 = Convert.ToInt32(tbPakBekSureDk);
                int val12 = Convert.ToInt32(tbPaletBekSureSaat);
                int val13 = Convert.ToInt32(tbPaletBekSureSaat);
                //web suncuuya istek atılır
                UretimKayit val = new UretimKayit(val1,val2,val3,val4,val5,val6,val7,val8,val9,val10,val11,val12,val13);
                List<UretimKayit> BB = new List<UretimKayit>();
                BB.Add(val);
                SaveUretimKayit(BB);

            }
        }
        public void SaveUretimKayit( List<UretimKayit> students)
        {
            Excel.Application aa;
            aa = new Excel.Application();
            
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;
            try
            {
                string mksrkonum = Application.StartupPath.ToString();
                Debug.WriteLine("Konum " + mksrkonum);
                //using (var writer = new StreamWriter(mksrkonum + "\\" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "work.xlsx"));
                
                Excel.Workbook oWB;                // çalışma Kitabı tanımla
                Excel.Worksheet oSheet;              // çalışma Sayfası tanımla
                                                     // oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));

                oWB = (oXL.Workbooks.Add(""));
                oSheet = oWB.ActiveSheet;
                
                string file_path = mksrkonum + "\\" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "work.xlsx";

                //oWB = aa.Workbooks.Open(file_path);                  // dosyayı aç
                //oSheet = (Excel.Worksheet)aa.Worksheets.get_Item(1);   // 1. sayfayı aç
                oSheet.Cells[1, 1] = "Makine Otomatik Calısma Sure";
                oSheet.Cells[2, 1] = "Uretim Baski Adedi";
                oSheet.Cells[3, 1] = "Yapilan Karisim Adedi";
                oSheet.Cells[4, 1] = "Kullanilan Cim Miktari";
                oSheet.Cells[5, 1] = "Kalan Cim Miktari";
                oSheet.Cells[6, 1] = "Paket Adedi";
                oSheet.Cells[7, 1] = "Harc Bekleme Sure Saat";
                oSheet.Cells[8, 1] = "Harc Bekleme Sure Dk";
                oSheet.Cells[9, 1] = "Pak Bekleme Sure Saat";
                oSheet.Cells[10, 1] = "Pak Bekleme Sure Dk";
                oSheet.Cells[11, 1] = "Palet Bekleme Sure Saat";
                oSheet.Cells[12, 1] = "Palet Bekleme Sure Dk";
                oSheet.Cells[13, 1] = "Otomatik Calisma Sure Dk";
                oSheet.Cells[1, 2] = students[0].MakineOtomatikCalısmaSure;                                // dataya yaz
                oSheet.Cells[2, 2] = students[0].UretimBaskiAdedi;
                oSheet.Cells[3, 2] = students[0].YapilanKarisimAdedi;                                // dataya yaz
                oSheet.Cells[4, 2] = students[0].KullanilanCimMiktari;
                oSheet.Cells[5, 2] = students[0].KalanCimMiktari;                                // dataya yaz
                oSheet.Cells[6, 2] = students[0].PaketAdedi;
                oSheet.Cells[7, 2] = students[0].MakineHarcBeklemeSureSaat;                                // dataya yaz
                oSheet.Cells[8, 2] = students[0].MakineHarcBeklemeSureDk;
                oSheet.Cells[9, 2] = students[0].MakinePakBeklemeSureSaat;                                // dataya yaz
                oSheet.Cells[10, 2] = students[0].MakinePakBeklemeSureDk;
                oSheet.Cells[11, 2] = students[0].MakinePaletBeklemeSureSaat;                                // dataya yaz
                oSheet.Cells[12, 2] = students[0].MakinePaletBeklemeSureDk;
                oSheet.Cells[13, 2] = students[0].MakineOtomatikCalismaSureDk;
                oSheet.get_Range("A1", "A15").Font.Bold = true;
                oSheet.get_Range("A1", "A15").VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;// dataya yaz
                                                                           //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "A1");
                oRng.EntireColumn.AutoFit();

                oWB.SaveAs(file_path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                oWB.Close();

                               // excel' i görünür yap

                oXL.Quit();      // excel uygulamasını kapat
                // using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                //{
                //    var csvDs = new CsvFileDescription
                //    {
                //        FirstLineHasColumnNames = true,
                //        SeparatorChar = ','   

                //    };
                //    var csvcon = new CsvContext();
                //    csvcon.Write(students, "aaaa.csv", csvDs);

                //  //  csv.Context.RegisterClassMap<UretimKayitClassMap>();
                // //   csv.WriteRecords(students);
                //}
            }
            catch(Exception ex)
            {
                oXL.Quit();
                Debug.WriteLine("Hata " + ex.Message);
                MessageBox.Show(ex.Message);
            }
          
        }

        private void tbSetyil_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[528], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void tbSetAy_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[529], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void tbSetGun_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[530], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void tbSetSaat_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[532], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void tbSetDk_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[533], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void tbSetSan_Click(object sender, EventArgs e)
        {
            Form f = new Calculator(AlltagClass.ALLTagList[534], 1, 9999, 0);
            f.ShowDialog(this);
        }

        private void tbTimeSet_Click(object sender, EventArgs e)
        {
            writePLC(AlltagClass.ALLTagList[407], false, 85);
        }
    }
}
