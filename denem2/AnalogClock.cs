using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace denem2
{
    public partial class AnalogClock : UserControl
    {
        public double ClockScalingFactor { get; set; } = 0.4;
        public Color ClockHourColor { get; set; } = Color.Black;
        public Color ClockMinuteColor { get; set; } = Color.Black;
        public Color ClockSecondColor { get; set; } = Color.Red;
        public float ClockHourWidth { get; set; } = 8f;
        public float ClockMinuteWidth { get; set; } = 4f;
        public float ClockSecondWidth { get; set; } = 2f;
        public LineCap ClockHourLineCap { get; set; } = LineCap.Round;
        public LineCap ClockMinuteLineCap { get; set; } = LineCap.Round;
        public LineCap ClockSecondLineCap { get; set; } = LineCap.Round;
        public Color ClockCenterColor { get; set; } = Color.Black;
        public float ClockCenterRadius { get; set; } = 10;

        public AnalogClock()
        {
            InitializeComponent();
        }

        private void AnalogClock_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Tick += (s, ev) => { BackgroundImage = DrawClock(); };
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        private Bitmap DrawClock()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bitmap);

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(BackColor);

            double radius = Math.Min(Width, Height) * ClockScalingFactor;
            double center = Math.Min(Width, Height) / 2.0d;

            for (int i = 0; i < 12; i++)
            {
                float x = (float)(center + Math.Cos(i * Math.PI / 6) * radius);
                float y = (float)(center + Math.Sin(i * Math.PI / 6) * radius);

                int t = (i + 3) % 12;
                String hour = t == 0 ? "12" : t.ToString();
                SizeF size = g.MeasureString(hour, Font);

                g.DrawString(hour, Font, new SolidBrush(ForeColor), x - size.Width / 2, y - size.Height / 2);

                int h = (DateTime.Now.Hour + 9) % 12;
                float hx = (float)(center + Math.Cos(h * Math.PI / 6) * radius * 0.75f);
                float hy = (float)(center + Math.Sin(h * Math.PI / 6) * radius * 0.75f);
                Pen hourPen = new Pen(ClockHourColor, ClockHourWidth);
                hourPen.EndCap = ClockHourLineCap;
                g.DrawLine(hourPen, (float)center, (float)center, hx, hy);

                int m = (DateTime.Now.Minute + 45) % 60;
                float mx = (float)(center + Math.Cos(m * 6 * Math.PI / 180) * radius * 0.85f);
                float my = (float)(center + Math.Sin(m * 6 * Math.PI / 180) * radius * 0.85f);
                Pen minutePen = new Pen(ClockMinuteColor, ClockMinuteWidth);
                minutePen.EndCap = ClockMinuteLineCap;
                g.DrawLine(minutePen, (float)center, (float)center, mx, my);

                int s = (DateTime.Now.Second + 45) % 60;
                float sx = (float)(center + Math.Cos(s * 6 * Math.PI / 180) * radius * 0.92f);
                float sy = (float)(center + Math.Sin(s * 6 * Math.PI / 180) * radius * 0.92f);
                Pen secondPen = new Pen(ClockSecondColor, ClockSecondWidth);
                secondPen.EndCap = ClockSecondLineCap;
                g.DrawLine(secondPen, (float)center, (float)center, sx, sy);

                g.FillEllipse(new SolidBrush(ClockCenterColor), (float)center - ClockCenterRadius,
                    (float)center - ClockCenterRadius, ClockCenterRadius * 2f, ClockCenterRadius * 2f);
            }

            return bitmap;
        }

        private void AnalogClock_Resize(object sender, EventArgs e)
        {
            Width = Height = Math.Max(Width, Height);
        }
    }
}
