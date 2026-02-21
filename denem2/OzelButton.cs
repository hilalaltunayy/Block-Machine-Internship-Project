using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace denem2
{
    public partial class OzelButton : Button
    {
        public int PLCtag { get; set; } = 1;
        public Color OnColor { get; set; } = Color.Green;
        public Color OffColor { get; set; } = Color.Gray;


        public OzelButton (){
            this.Size = new Size(64, 36);
            this.BackColor = Color.SkyBlue;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            this.Text = "İleri";
            this.Font = new Font("Microsoft Sans Serif",10);
           
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            AlltagClass aa = new AlltagClass();

            Debug.WriteLine("aaa ssdafas :" + AlltagClass.ALLTagList[this.PLCtag].ToString());
            WriteTag.writePLC(AlltagClass.ALLTagList[this.PLCtag],true,0);
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            AlltagClass aa = new AlltagClass();
            Debug.WriteLine("aaa ssdafas :" + AlltagClass.ALLTagList[this.PLCtag].ToString());
            WriteTag.writePLC(AlltagClass.ALLTagList[this.PLCtag], false, 0);
            base.OnMouseUp(mevent);
        }





    }
}
