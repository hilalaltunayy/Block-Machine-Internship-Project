using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Sharp7;

namespace denem2
{
	public class ALLAlarmListClass
	{

		public static AlarmTag[] ALLAlarmList;
		public static byte[] MarkersDB = new byte[65536];
		public static List<AlarmTag> AktifAlarmList = new List<AlarmTag>();

		public ALLAlarmListClass()
		{
			ALLAlarmList = new AlarmTag[]{
				new AlarmTag(no  : 0, PLCadres : "Test", Aciklama : "Test"),
				new AlarmTag(no  : 1, PLCadres : "M200.0", Aciklama : "Alt Kalıp Yukarı Hareket Süre Aşımı"),
				new AlarmTag(no  : 2, PLCadres : "M200.1", Aciklama : "Alt Kalıp Aşağı Hareket Süre Aşımı"),
				new AlarmTag(no  : 3, PLCadres : "M200.2", Aciklama : "Üst Kalıp Yukarı Hareket Süre Aşımı"),
				new AlarmTag(no  : 4, PLCadres : "M200.3", Aciklama : "Üst Kalıp Aşağı Hareket Süre Aşımı"),
				new AlarmTag(no  : 5, PLCadres : "M200.4", Aciklama : "Harç Teknesi İleri Hareket Süre Aşımı"),
				new AlarmTag(no  : 6, PLCadres : "M200.5", Aciklama : "Harç Teknesi Geri Hareket Süre Aşımı"),
				new AlarmTag(no  : 7, PLCadres : "M200.6", Aciklama : "Palet 1 İleri Hareket Süre Aşımı"),
				new AlarmTag(no  : 8, PLCadres : "M200.7", Aciklama : "Palet 1 Geri Hareket Süre Aşımı"),
				new AlarmTag(no  : 9, PLCadres : "M201.0", Aciklama : "Palet 2 İleri Hareket Süre Aşımı"),
				new AlarmTag(no  : 10, PLCadres : "M201.1", Aciklama : "Palet 2 Geri Hareket Süre Aşımı"),
				new AlarmTag(no  : 11, PLCadres : "M201.2", Aciklama : "Palet 3 İleri Hareket Süre Aşımı"),
				new AlarmTag(no  : 12, PLCadres : "M201.3", Aciklama : "Palet 3 Geri Hareket Süre Aşımı"),
				new AlarmTag(no  : 13, PLCadres : "M201.4", Aciklama : "İndirme Asansörü Yukarı Hareket Süre Aşımı"),
				new AlarmTag(no  : 14, PLCadres : "M201.5", Aciklama : "İndirme Asansörü Aşağı Hareket Süre Aşımı"),
				new AlarmTag(no  : 15, PLCadres : "M201.6", Aciklama : "Kaldırma Asansörü Yukarı Hareket Süre Aşımı"),
				new AlarmTag(no  : 16, PLCadres : "M201.7", Aciklama : "Kaldırma Asansörü Aşağı Hareket Süre Aşımı"),
				new AlarmTag(no  : 17, PLCadres : "M202.0", Aciklama : "Ön Bant Max. Taşıma Süresi Aşımı"),
				new AlarmTag(no  : 18, PLCadres : "M202.1", Aciklama : "Ters Çevirme Motoru Hareket Süre Aşımı"),
				new AlarmTag(no  : 19, PLCadres : "M202.2", Aciklama : "Çimento Dolumunda Gecikme "),
				new AlarmTag(no  : 20, PLCadres : "M202.3", Aciklama : "Çimento Boşaltmada Gecikme"),
				new AlarmTag(no  : 21, PLCadres : "M202.4", Aciklama : "A_1"                   ),
				new AlarmTag(no  : 22, PLCadres : "M202.5", Aciklama : "Asansör Yukarı Hareket Süre Aşımı"),
				new AlarmTag(no  : 23, PLCadres : "M202.6", Aciklama : "Asansör Aşağı Hareket Süre Aşımı"),
				new AlarmTag(no  : 24, PLCadres : "M202.7", Aciklama : "Mikser Klepe Açma Süre Aşımı"),
				new AlarmTag(no  : 25, PLCadres : "M203.0", Aciklama : "Mikser Klepe Kapama Süre Aşımı"),
				new AlarmTag(no  : 26, PLCadres : "M203.1", Aciklama : "Zincirli İtici İleri Hareket Süre Aşımı"),
				new AlarmTag(no  : 27, PLCadres : "M203.2", Aciklama : "Zincirli İtici Geri Hareket Süre Aşımı"),
				new AlarmTag(no  : 28, PLCadres : "M203.3", Aciklama : "Dikey İtici İleri Hareket Süre Aşımı"),
				new AlarmTag(no  : 29, PLCadres : "M203.4", Aciklama : "Dikey İtici Geri Hareket Süre Aşımı"),
				new AlarmTag(no  : 30, PLCadres : "M203.5", Aciklama : "Masa İleri Hareket Süre Aşımı"),
				new AlarmTag(no  : 31, PLCadres : "M203.6", Aciklama : "Masa Geri Hareket Süre Aşımı"),
				new AlarmTag(no  : 32, PLCadres : "M203.7", Aciklama : "Toplama Yukarı Hareket Süre Aşımı"),
				new AlarmTag(no  : 33, PLCadres : "M204.0", Aciklama : "Toplama Aşağı Hareket Süre Aşımı"),
				new AlarmTag(no  : 34, PLCadres : "M204.1", Aciklama : "Toplama İleri Hareket Süre Aşımı"),
				new AlarmTag(no  : 35, PLCadres : "M204.2", Aciklama : "Toplama Geri Hareket Süre Aşımı"),
				new AlarmTag(no  : 36, PLCadres : "M204.3", Aciklama : "Toplama Çevirme İleri Hareket Süre Aşımı"),
				new AlarmTag(no  : 37, PLCadres : "M204.4", Aciklama : "Toplama Çevirme Geri Hareket Süre Aşımı"),
				new AlarmTag(no  : 38, PLCadres : "M204.5", Aciklama : "Bims Kovası Emniyet Sensörü Alarmı"),
				new AlarmTag(no  : 39, PLCadres : "M204.6", Aciklama : "Bims Kovası Halat Boşaldı Alarmı"),
				new AlarmTag(no  : 40, PLCadres : "M204.7", Aciklama : "Pres Sensör Arıza Alarmı"),
				new AlarmTag(no  : 41, PLCadres : "M205.0", Aciklama : "Palet Sensör Arıza Alarmı"),
				new AlarmTag(no  : 42, PLCadres : "M205.1", Aciklama : "Paketleme Sensör Arıza Alarmı"),
				new AlarmTag(no  : 43, PLCadres : "M205.2", Aciklama : "Toplama Sensör Arıza Alarmı"),
				new AlarmTag(no  : 44, PLCadres : "M205.3", Aciklama : "Pres Hidrolik Basınç Filtresi Alarmı"),
				new AlarmTag(no  : 45, PLCadres : "M205.4", Aciklama : "Mikser Sensör Arıza Alarmı"),
				new AlarmTag(no  : 46, PLCadres : "M205.5", Aciklama : "A_2"                  ),
				new AlarmTag(no  : 47, PLCadres : "M205.6", Aciklama : "A_3"                   ),
				new AlarmTag(no  : 48, PLCadres : "M205.7", Aciklama : "A_4"                   ),
				new AlarmTag(no  : 49, PLCadres : "M206.1", Aciklama : "Acil Stop Basıldı veya Kontrol Voltaj Yok !.."               ),
				new AlarmTag(no  : 50, PLCadres : "M206.2", Aciklama : "Sensör Voltaj Yok !.."                 ),
				new AlarmTag(no  : 51, PLCadres : "M206.3", Aciklama : "Mikser Çalıştı Sinyali Kayıp"),
				new AlarmTag(no  : 52, PLCadres : "M206.0", Aciklama : "Termik Attı Alarmı"),
				new AlarmTag(no  : 53, PLCadres : "M206.4", Aciklama : "Pres Hidrolik Yağ Değişim Zamanı"),
				new AlarmTag(no  : 54, PLCadres : "M206.5", Aciklama : "Toplama Hidrolik Yağ Değişim Zamanı"),
				new AlarmTag(no  : 55, PLCadres : "M206.6", Aciklama : "Su Alım Sure Aşımı"),
				new AlarmTag(no  : 56, PLCadres : "M206.7", Aciklama : "Pres Hidrolik Geri Dönüş Filtre Kirli !.."                 ),
				new AlarmTag(no  : 57, PLCadres : "M207.0", Aciklama : "Toplama Hidrolik Basınç Filtre Kirli !.."  ),
				new AlarmTag(no  : 58, PLCadres : "M207.1", Aciklama : "Çatal Açma Hatalı Parametre"),

				new AlarmTag(no  : 59, PLCadres : "M207.2", Aciklama : "Çatal Açma Yukarı Hareket Süre Aşımı Alarmı"),
				new AlarmTag(no  : 60, PLCadres : "M207.3", Aciklama : "Çatal Açma Aşağı Hareket Süre Aşımı Alarmı"),
				new AlarmTag(no  : 61, PLCadres : "M207.4", Aciklama : "Çatal Açma İleri Hareket Süre Aşımı Alarmı"),
				new AlarmTag(no  : 62, PLCadres : "M207.5", Aciklama : "Çatal Açma İleri Hareket Süre Aşımı Alarmı"),
				new AlarmTag(no  : 63, PLCadres : "M207.6", Aciklama : "Çatal Açma Enkoder Hatalı Alarmı"),
				new AlarmTag(no  : 64, PLCadres : "M207.7", Aciklama : "A_23"                  ),
				new AlarmTag(no  : 65, PLCadres : "M208.0", Aciklama : "Palet3 (Ters Çevirme), Sensor Alarm"                   ),
				new AlarmTag(no  : 66, PLCadres : "M208.1", Aciklama : "Palet3 (Sonda), Sensor Alarm"                  ),
				new AlarmTag(no  : 67, PLCadres : "M208.2", Aciklama : "Vibrasyon Yağ Kontrol Alarm"                   ),
				new AlarmTag(no  : 68, PLCadres : "M208.3", Aciklama : "Vibrasyon Yağ Değişim Alarm"                   ),

				new AlarmTag(no  : 69, PLCadres : "M208.4", Aciklama : "Toprak Bandı Toprak Gelmiyor.. Kontrol Ediniz. "                    ),
				new AlarmTag(no  : 70, PLCadres : "M208.5", Aciklama : "A_29"  ),
				new AlarmTag(no  : 71, PLCadres : "M208.6", Aciklama : "A_30"  ),
				new AlarmTag(no  : 72, PLCadres : "M208.7", Aciklama : "A_31"  ),
				new AlarmTag(no  : 73, PLCadres : "M209.0", Aciklama : "A_32"  ),
				new AlarmTag(no  : 74, PLCadres : "M209.1", Aciklama : "A_33"  ),
				new AlarmTag(no  : 75, PLCadres : "M209.2", Aciklama : "A_34"  ),
				new AlarmTag(no  : 76, PLCadres : "M209.3", Aciklama : "A_35"  ),
				new AlarmTag(no  : 77, PLCadres : "M209.4", Aciklama : "A_36"  ),
				new AlarmTag(no  : 78, PLCadres : "M209.5", Aciklama : "A_37"  ),
				new AlarmTag(no  : 79, PLCadres : "M209.6", Aciklama : "A_38"  ),
				new AlarmTag(no  : 80, PLCadres : "M209.7", Aciklama : "A_39" ),


			};
		}
		public static void AlarmlariOku(S7Client Client)
		{
			int Result=0;
            try
            {
				 Result = Client.ReadArea(S7Consts.S7AreaMK, 0, 200, 10, S7Consts.S7WLByte, MarkersDB);

				if (Result == 0)
				{

					AktifAlarmList.Clear();
					if (S7.GetBitAt(MarkersDB, 0, 0))
						AktifAlarmList.Add(ALLAlarmList[1]);


					if (S7.GetBitAt(MarkersDB, 0, 1))
						AktifAlarmList.Add(ALLAlarmList[2]);


					if (S7.GetBitAt(MarkersDB, 0, 2))
						AktifAlarmList.Add(ALLAlarmList[3]);


					if (S7.GetBitAt(MarkersDB, 0, 3))
						AktifAlarmList.Add(ALLAlarmList[4]);


					if (S7.GetBitAt(MarkersDB, 0, 4))
						AktifAlarmList.Add(ALLAlarmList[5]);


					if (S7.GetBitAt(MarkersDB, 0, 5))
						AktifAlarmList.Add(ALLAlarmList[6]);



					if (S7.GetBitAt(MarkersDB, 0, 6))
						AktifAlarmList.Add(ALLAlarmList[7]);


					if (S7.GetBitAt(MarkersDB, 0, 7))
						AktifAlarmList.Add(ALLAlarmList[8]);


					if (S7.GetBitAt(MarkersDB, 1, 0))
						AktifAlarmList.Add(ALLAlarmList[9]);


					if (S7.GetBitAt(MarkersDB, 1, 1))
						AktifAlarmList.Add(ALLAlarmList[10]);


					if (S7.GetBitAt(MarkersDB, 1, 2))
						AktifAlarmList.Add(ALLAlarmList[11]);


					if (S7.GetBitAt(MarkersDB, 1, 3))
						AktifAlarmList.Add(ALLAlarmList[12]);


					if (S7.GetBitAt(MarkersDB, 1, 4))
						AktifAlarmList.Add(ALLAlarmList[13]);


					if (S7.GetBitAt(MarkersDB, 1, 5))
						AktifAlarmList.Add(ALLAlarmList[14]);


					if (S7.GetBitAt(MarkersDB, 1, 6))
						AktifAlarmList.Add(ALLAlarmList[15]);


					if (S7.GetBitAt(MarkersDB, 1, 7))
						AktifAlarmList.Add(ALLAlarmList[16]);






					if (S7.GetBitAt(MarkersDB, 2, 0))
						AktifAlarmList.Add(ALLAlarmList[17]);


					if (S7.GetBitAt(MarkersDB, 2, 1))
						AktifAlarmList.Add(ALLAlarmList[18]);


					if (S7.GetBitAt(MarkersDB, 2, 2))
						AktifAlarmList.Add(ALLAlarmList[19]);


					if (S7.GetBitAt(MarkersDB, 2, 3))
						AktifAlarmList.Add(ALLAlarmList[20]);


					if (S7.GetBitAt(MarkersDB, 2, 4))
						AktifAlarmList.Add(ALLAlarmList[21]);


					if (S7.GetBitAt(MarkersDB, 2, 5))
						AktifAlarmList.Add(ALLAlarmList[22]);


					if (S7.GetBitAt(MarkersDB, 2, 6))
						AktifAlarmList.Add(ALLAlarmList[23]);



					if (S7.GetBitAt(MarkersDB, 2, 7))
						AktifAlarmList.Add(ALLAlarmList[24]);


					if (S7.GetBitAt(MarkersDB, 3, 0))
						AktifAlarmList.Add(ALLAlarmList[25]);


					if (S7.GetBitAt(MarkersDB, 3, 1))
						AktifAlarmList.Add(ALLAlarmList[26]);


					if (S7.GetBitAt(MarkersDB, 3, 2))
						AktifAlarmList.Add(ALLAlarmList[27]);


					if (S7.GetBitAt(MarkersDB, 3, 3))
						AktifAlarmList.Add(ALLAlarmList[28]);


					if (S7.GetBitAt(MarkersDB, 3, 4))
						AktifAlarmList.Add(ALLAlarmList[29]);


					if (S7.GetBitAt(MarkersDB, 3, 5))
						AktifAlarmList.Add(ALLAlarmList[30]);


					if (S7.GetBitAt(MarkersDB, 3, 6))
						AktifAlarmList.Add(ALLAlarmList[31]);




					if (S7.GetBitAt(MarkersDB, 3, 7))
						AktifAlarmList.Add(ALLAlarmList[32]);


					if (S7.GetBitAt(MarkersDB, 4, 0))
						AktifAlarmList.Add(ALLAlarmList[33]);


					if (S7.GetBitAt(MarkersDB, 4, 1))
						AktifAlarmList.Add(ALLAlarmList[34]);


					if (S7.GetBitAt(MarkersDB, 4, 2))
						AktifAlarmList.Add(ALLAlarmList[35]);


					if (S7.GetBitAt(MarkersDB, 4, 3))
						AktifAlarmList.Add(ALLAlarmList[36]);


					if (S7.GetBitAt(MarkersDB, 4, 4))
						AktifAlarmList.Add(ALLAlarmList[37]);


					if (S7.GetBitAt(MarkersDB, 4, 5))
						AktifAlarmList.Add(ALLAlarmList[38]);


					if (S7.GetBitAt(MarkersDB, 4, 6))
						AktifAlarmList.Add(ALLAlarmList[39]);




					if (S7.GetBitAt(MarkersDB, 4, 7))
						AktifAlarmList.Add(ALLAlarmList[40]);


					if (S7.GetBitAt(MarkersDB, 5, 0))
						AktifAlarmList.Add(ALLAlarmList[41]);


					if (S7.GetBitAt(MarkersDB, 5, 1))
						AktifAlarmList.Add(ALLAlarmList[42]);


					if (S7.GetBitAt(MarkersDB, 5, 2))
						AktifAlarmList.Add(ALLAlarmList[43]);


					if (S7.GetBitAt(MarkersDB, 5, 3))
						AktifAlarmList.Add(ALLAlarmList[44]);


					if (S7.GetBitAt(MarkersDB, 5, 4))
						AktifAlarmList.Add(ALLAlarmList[45]);


					if (S7.GetBitAt(MarkersDB, 5, 5))
						AktifAlarmList.Add(ALLAlarmList[46]);


					if (S7.GetBitAt(MarkersDB, 5, 6))
						AktifAlarmList.Add(ALLAlarmList[47]);




					if (S7.GetBitAt(MarkersDB, 5, 7))
						AktifAlarmList.Add(ALLAlarmList[48]);


					if (S7.GetBitAt(MarkersDB, 6, 1))
						AktifAlarmList.Add(ALLAlarmList[49]);


					if (S7.GetBitAt(MarkersDB, 6, 2))
						AktifAlarmList.Add(ALLAlarmList[50]);


					if (S7.GetBitAt(MarkersDB, 6, 3))
						AktifAlarmList.Add(ALLAlarmList[51]);


					if (S7.GetBitAt(MarkersDB, 6, 0))
						AktifAlarmList.Add(ALLAlarmList[52]);


					if (S7.GetBitAt(MarkersDB, 6, 4))
						AktifAlarmList.Add(ALLAlarmList[53]);


					if (S7.GetBitAt(MarkersDB, 6, 5))
						AktifAlarmList.Add(ALLAlarmList[54]);


					if (S7.GetBitAt(MarkersDB, 6, 6))
						AktifAlarmList.Add(ALLAlarmList[55]);


					if (S7.GetBitAt(MarkersDB, 6, 7))
						AktifAlarmList.Add(ALLAlarmList[56]);



					if (S7.GetBitAt(MarkersDB, 7, 0))
						AktifAlarmList.Add(ALLAlarmList[57]);


					if (S7.GetBitAt(MarkersDB, 7, 1))
						AktifAlarmList.Add(ALLAlarmList[58]);


					if (S7.GetBitAt(MarkersDB, 7, 2))
						AktifAlarmList.Add(ALLAlarmList[59]);


					if (S7.GetBitAt(MarkersDB, 7, 3))
						AktifAlarmList.Add(ALLAlarmList[60]);


					if (S7.GetBitAt(MarkersDB, 7, 4))
						AktifAlarmList.Add(ALLAlarmList[61]);


					if (S7.GetBitAt(MarkersDB, 7, 5))
						AktifAlarmList.Add(ALLAlarmList[62]);


					if (S7.GetBitAt(MarkersDB, 7, 6))
						AktifAlarmList.Add(ALLAlarmList[63]);


					if (S7.GetBitAt(MarkersDB, 7, 7))
						AktifAlarmList.Add(ALLAlarmList[64]);



					if (S7.GetBitAt(MarkersDB, 8, 0))
						AktifAlarmList.Add(ALLAlarmList[65]);


					if (S7.GetBitAt(MarkersDB, 8, 1))
						AktifAlarmList.Add(ALLAlarmList[66]);


					if (S7.GetBitAt(MarkersDB, 8, 2))
						AktifAlarmList.Add(ALLAlarmList[67]);


					if (S7.GetBitAt(MarkersDB, 8, 3))
						AktifAlarmList.Add(ALLAlarmList[68]);


					if (S7.GetBitAt(MarkersDB, 8, 4))
						AktifAlarmList.Add(ALLAlarmList[69]);


					if (S7.GetBitAt(MarkersDB, 8, 5))
						AktifAlarmList.Add(ALLAlarmList[70]);


					if (S7.GetBitAt(MarkersDB, 8, 6))
						AktifAlarmList.Add(ALLAlarmList[71]);


					if (S7.GetBitAt(MarkersDB, 8, 7))
						AktifAlarmList.Add(ALLAlarmList[72]);



					if (S7.GetBitAt(MarkersDB, 9, 0))
						AktifAlarmList.Add(ALLAlarmList[73]);


					if (S7.GetBitAt(MarkersDB, 9, 1))
						AktifAlarmList.Add(ALLAlarmList[74]);


					if (S7.GetBitAt(MarkersDB, 9, 2))
						AktifAlarmList.Add(ALLAlarmList[75]);


					if (S7.GetBitAt(MarkersDB, 9, 3))
						AktifAlarmList.Add(ALLAlarmList[76]);


					if (S7.GetBitAt(MarkersDB, 9, 4))
						AktifAlarmList.Add(ALLAlarmList[77]);


					if (S7.GetBitAt(MarkersDB, 9, 5))
						AktifAlarmList.Add(ALLAlarmList[78]);


					if (S7.GetBitAt(MarkersDB, 9, 6))
						AktifAlarmList.Add(ALLAlarmList[79]);


					if (S7.GetBitAt(MarkersDB, 9, 7))
						AktifAlarmList.Add(ALLAlarmList[80]);




				}
			}
			catch(Exception err)
            {

            }
			
			


		}
	}
}
