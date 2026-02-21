using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denem2
{
    public static  class Ekranlar
    {
        public static Form UstkalipScreen = new UstKalip();
        public static Form AltKalipScreen = new AltKalip();
        public static Form HarcTeknesiScreen = new HarcTeknesi();
        public static Form Palet1Screen = new Palet1();
        public static Form MainForm = new Form1();
        public static Form AlarmScreen = new Alarm();
        public static Form AlarmSureleriScreen = new AlarmSüreleri();
        public static Form MikserParamScreen = new Mikser_Parametreleri();
        private static string AnaEkranText = "Ana Ekran";

        public static Form CatalParamScreen = new CatalAcmaParametreleri();
        public static Form GrafikScreen = new Grafik();
        public static Form HidrolikScreen = new Hidrolik();
        public static Form IticiParamScreen = new IticiParametreleri();
        public static Form MikserScreen = new Mikser();

        public static Form Palet3Screen = new Palet3();
        public static Form PresOransalScreen = new HidrolikOransal();
        public static Form ReceteScreen = new Recete();
        public static Form SistemScreen = new Sistem();
        public static Form ToplamaOransalScreen = new ToplamaOransal();
        public static Form ToplamaParamScreen = new ToplamaParametreleri();
        public static Form ToplamaYukAsgScreen = new ToplamaYuk_Asg();
        public static Form VardiyaScreen = new Vardiya();
        public static Form VibrasyonScreen = new Vibrasyon();
        public static Form OperatorScreen = new Operator();

        public static bool darkMode = false;
        public static void Screens()

        {

        }
        public static void GoMainForm(Form f)
        {
            f.Hide();
            
        }
        public static void OpenAltKalipScreen(Form f)
        {
            if (f.Text == AnaEkranText)
            {
                AltKalipScreen.Show();
                
            }    
            else
            {
               
                f.Hide();
                AltKalipScreen.Show();
            }

        }
        public static void OpenUstKalipScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                UstkalipScreen.Show();
            else
            {
                f.Hide();
                UstkalipScreen.Show();
            }

        }
        public static void OpenHarcTeknesiScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                HarcTeknesiScreen.Show();
            else
            {
                f.Hide();
                HarcTeknesiScreen.Show();
            }

        }
        public static void OpenOperatprScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                OperatorScreen.Show();
            else
            {
                f.Hide();
                OperatorScreen.Show();
            }

        }
        public static void OpenPalet1Screen(Form f)
        {
            if (f.Text == AnaEkranText)
                Palet1Screen.Show();
            else
            {
                f.Hide();
                Palet1Screen.Show();
            }

        }
        public static void OpenAlarmScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                AlarmScreen.Show();
            else
            {
                f.Hide();
                AlarmScreen.Show();
            }

        }
        public static void OpenAlarmSureleriScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                AlarmSureleriScreen.Show();
            else
            {
                f.Hide();
                AlarmSureleriScreen.Show();
            }
        }
        public static void OpenCatalAcmaParamScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                CatalParamScreen.Show();
            else
            {
                f.Hide();
                CatalParamScreen.Show();
            }
        }
        public static void OpenGrafikScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                GrafikScreen.Show();
            else
            {
                f.Hide();
                GrafikScreen.Show();
            }
        }
        public static void OpenHidrolikScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                HidrolikScreen.Show();
            else
            {
                f.Hide();
                HidrolikScreen.Show();
            }
        }
        public static void OpenIticiParamScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                IticiParamScreen.Show();
            else
            {
                f.Hide();
                IticiParamScreen.Show();
            }
        }
        public static void OpenMikserScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                MikserScreen.Show();
            else
            {
                f.Hide();
                MikserScreen.Show();
            }
        }
        public static void OpenMikserParamScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                MikserParamScreen.Show();
            else
            {
                f.Hide();
                MikserParamScreen.Show();
            }
        }
        public static void OpenPalet3Screen(Form f)
        {
            if (f.Text == AnaEkranText)
                Palet3Screen.Show();
            else
            {
                f.Hide();
                Palet3Screen.Show();
            }
        }
        public static void OpenPressOransalAyarScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                PresOransalScreen.Show();
            else
            {
                f.Hide();
                PresOransalScreen.Show();
            }
        }
        public static void OpenReceteScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                ReceteScreen.Show();
            else
            {
                f.Hide();
                ReceteScreen.Show();
            }
        }
        public static void OpenSistemScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                SistemScreen.Show();
            else
            {
                f.Hide();
                SistemScreen.Show();
            }
        }
        public static void OpenToplamaOransalScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                ToplamaOransalScreen.Show();
            else
            {
                f.Hide();
                ToplamaOransalScreen.Show();
            }
        }
        public static void OpenToplamaParamScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                ToplamaParamScreen.Show();
            else
            {
                f.Hide();
                ToplamaParamScreen.Show();
            }
        }
        public static void OpenToplamaYukAsgScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                ToplamaYukAsgScreen.Show();
            else
            {
                f.Hide();
                ToplamaYukAsgScreen.Show();
            }
        }
        public static void OpenVardiyaScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                VardiyaScreen.Show();
            else
            {
                f.Hide();
                VardiyaScreen.Show();
            }
        }
        public static void OpenVibrasyonScreen(Form f)
        {
            if (f.Text == AnaEkranText)
                VibrasyonScreen.Show();
            else
            {
                f.Hide();
                VibrasyonScreen.Show();
            }
        }




    }
    public class FormProvider
    {
        public static Form1 MainForm
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = new Form1();
                }
                return _mainMenu;
            }
        }
        private static Form1 _mainMenu;
    }

   
}
