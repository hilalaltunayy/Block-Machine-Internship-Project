using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace denem2
{
    class ButtonWTags : Button
    {
        public int PLCtag { get; set; } = AlltagClass.ALLTagList[1].no;
        public Color OnColor { get; set; } = Color.Green;
        public Color OffColor { get; set; } = Color.Gray;


        public ButtonWTags()
        {
            this.Size = new Size(100, 40);
            this.BackColor = Color.Red;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Text = "";
        }

    }
}
