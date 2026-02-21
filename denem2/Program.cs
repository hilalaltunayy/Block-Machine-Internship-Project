using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace denem2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Form f;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Uyari().Show();
            Application.Run();

        }
    }
}
