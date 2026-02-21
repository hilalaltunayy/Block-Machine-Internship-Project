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

namespace denem2
{
    public partial class Calculator : Form
    {
        string input = string.Empty;        //String storing user input
        String operand1 = string.Empty;     //String storing first operand
        String operand2 = string.Empty;     //String storing second operand
        char operation;                     //Char to store operator
        double result = 0.0;                //Get result
        int val = 0;
        private S7Client Client;
        private int Result;
        private byte[] Buffer = new byte[65536];
        private byte[] BufferDB6 = new byte[65536];
        private byte[] MarkersDB = new byte[65536];
        private PLCTag tag;
        private int carpi;
        private int MaxVal;
        private int MinVal;
        private bool klavyeModu = false;
        public Calculator(PLCTag tag, int carpi, int MaxVal, int MinVal)
        {
            InitializeComponent();
            this.tag = tag;
            this.carpi = carpi;
            this.MaxVal = MaxVal;
            this.MinVal = MinVal;

            lblMaxVal.Text = MaxVal.ToString();
            lblMinVal.Text = MinVal.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "1";
            this.textBox1.Text += input;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "2";
            this.textBox1.Text += input;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "3";
            this.textBox1.Text += input;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "4";
            this.textBox1.Text += input;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "5";
            this.textBox1.Text += input;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "6";
            this.textBox1.Text += input;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "7";
            this.textBox1.Text += input;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "8";
            this.textBox1.Text += input;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "9";
            this.textBox1.Text += input;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += "0";
            this.textBox1.Text += input;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            input += ",";
            this.textBox1.Text += input;
        }

       

        private void btnEksiFunc(object sender, EventArgs e)
        {
            // operand1 = input;
            // operation = '-';
            // input = string.Empty;
            this.textBox1.Text = (Convert.ToInt32(textBox1.Text)-1).ToString();
            input= (Convert.ToInt32(textBox1.Text)).ToString();

        }

        private void btnArtiFunc(object sender, EventArgs e)
        {
            
            this.textBox1.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
            input = (Convert.ToInt32(textBox1.Text)).ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (klavyeModu)
            {
                input = textBox1.Text;
            }

            operand2 = input;
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);
            
            /* if (operation == '+')
             {
                 result = num1 + num2;
                 textBox1.Text = result.ToString();
             }
             else if (operation == '-')
             {
                 result = num1 - num2;
                 textBox1.Text = result.ToString();
             }
             else if (operation == '*')
             {
                 result = num1 * num2;
                 textBox1.Text = result.ToString();
             }
             else if (operation == '/')
             {
                 if (num2 != 0)
                 {
                     result = num1 / num2;
                     textBox1.Text = result.ToString();
                 }
                 else
                 {
                     textBox1.Text = "ERROR DIV BY ZERO";
                 }
             }*/
            Debug.WriteLine("test 1 :" + num2);
            Debug.WriteLine("operand 2 :" + operand2);
            
            try
            {
                if (num2 < MinVal)
                {
                    MessageBox.Show("Küçük Değer Girildi.");
                    return;
                }

                if (num2 > MaxVal)
                {
                    MessageBox.Show("Büyük Değer Girildi.");
                    return;
                }
                writePLC(tag, true, num2);
                Client.Disconnect();
                this.Close();
            }
            catch (Exception k)
            {
                Client.Disconnect();
                this.Close();
                Debug.WriteLine(k);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            klavyeModu = true;

            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            
            try
            {
                String sonuc;
                Client = new S7Client();
                Client.ConnTimeout = 300;
                Client.RecvTimeout = 300;
                Client.SendTimeout = 300;
                Result = Client.ConnectTo("192.168.0.2", 0, 0);
                if (Result == 0)
                {
                     sonuc = read_Tag(tag);
                  
                    textBox1.Text = sonuc;
                }
                else
                {
                    textBox1.Text = "Haberleşme YOK";
                }
                    

               
            }
            catch(Exception err)
            {
                MessageBox.Show("Haberleşme Yok");
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

                    return (S7.GetIntAt(realArray, 0)/carpi).ToString();
                }
                else if (gelentag.Tip == "real")
                {
                    byte[] realArray = new byte[4];

                    Result = Client.ReadArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLReal, realArray);
                    return S7.GetRealAt(realArray, 0).ToString();
                }
                else if (gelentag.Tip == "dword")
                {
                    byte[] realArray = new byte[4];

                    Result = Client.ReadArea(S7Consts.S7AreaMK, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDWord, realArray);
                    return (S7.GetDWordAt(realArray, 0)/carpi).ToString();
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

                    return (S7.GetIntAt(realArray, 0)/carpi).ToString();
                }
                else if (gelentag.Tip == "real")
                {
                    byte[] realArray = new byte[4];

                    Result = Client.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLReal, realArray);
                    return S7.GetRealAt(realArray, 0).ToString();
                }
                else if (gelentag.Tip == "dword")
                {
                    byte[] realArray = new byte[4];

                    Result = Client.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDWord, realArray);
                    return (S7.GetDWordAt(realArray, 0) / carpi).ToString();
                }
                else if (gelentag.Tip == "byte")
                {
                    byte[] bytearray = new byte[1];

                    Result = Client.ReadArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLByte, bytearray);
                    return (S7.GetByteAt(bytearray, 0) / carpi).ToString();
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
                            bool a = S7.GetBitAt(bytearray, 0, 1);
                            Debug.WriteLine("gelen tag offset :" + gelentag.Offset.ToString());
                            Debug.WriteLine("Test bit yazma :" + a.ToString());
                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, (gelentag.Offset * 8) + gelentag.BitNo, 1, S7Consts.S7WLBit, bytearray);

                            return Result;
                        }
                        else if (gelentag.Tip == "byte")
                        {
                            byte[] realArray = new byte[1];

                            int val = Convert.ToSByte(othersvalue);
                            realArray = BitConverter.GetBytes(Convert.ToSByte(val));
                            //Array.Reverse(realArray);
                            byte[] aa = realArray;

                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLByte, aa);
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
                            float val = Convert.ToSingle(othersvalue);
                            //realArray = BitConverter.GetBytes(val);
                            S7.SetRealAt(realArray, 0, val);

                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLReal, realArray);
                            return Result;
                        }
                        else if (gelentag.Tip == "dword")
                        {
                            byte[] realArray = new byte[4];
                            int val = Convert.ToInt32(othersvalue);
                            // realArray = BitConverter.GetBytes(othersvalue*carpi);

                            S7.SetDWordAt(realArray, 0, Convert.ToUInt32(othersvalue * carpi));
                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDWord, realArray);
                            Client.Disconnect();
                            this.Close();
                            return Result;
                        }
                        else if (gelentag.Tip == "dint")
                        {
                            byte[] realArray = new byte[4];
                            int val = Convert.ToInt32(othersvalue);
                            // realArray = BitConverter.GetBytes(othersvalue*carpi);

                            S7.SetDWordAt(realArray, 0, Convert.ToUInt32(othersvalue * carpi));
                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLDInt, realArray);
                            Client.Disconnect();
                            this.Close();
                            return Result;
                        }
                        else if (gelentag.Tip == "word")
                        {
                            byte[] realArray = new byte[2];
                            int val = Convert.ToInt16(othersvalue);
                            // realArray = BitConverter.GetBytes(othersvalue*carpi);

                            S7.SetWordAt(realArray, 0, Convert.ToUInt16(othersvalue * carpi));
                            Result = Client.WriteArea(S7Consts.S7AreaDB, gelentag.DB_No, gelentag.Offset, 1, S7Consts.S7WLWord, realArray);
                            Client.Disconnect();
                            this.Close();
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
                        Debug.WriteLine("Test bit yazma :error 111");
                        return 0;
                    }
                }
                else
                {
                    Debug.WriteLine("Error :Haberleşme Hatası ");
                    return 0;
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine("Error : " + e.ToString());
                return 0;
            }
        }

        private void Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Client.Connected)
                Client.Disconnect();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
           
        }
    }
}
