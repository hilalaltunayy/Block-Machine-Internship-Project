using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;
using LINQtoCSV;

namespace denem2
{

	public class PLCTag : Object
	{
		public String ad;
		public String Area;
		public String Tip;
		public int no;
		public int DB_No;
		public int Offset;
		public int BitNo;
		public Object Value;
		public PLCTag(int no, String ad, String Area, String Tip,  int DB_No, int Offset, int BitNo, Object value)
		{

			this.no = no;
			this.ad = ad;
			this.Area = Area;
			this.Tip = Tip;
			this.DB_No = DB_No;
			this.Offset = Offset;
			this.BitNo = BitNo;
			this.Value = value;
		}
		public override string ToString()
		{
			return base.ToString() + ": " + ad.ToString();
		}

	}
	public class UretimKayitClassMap : ClassMap<UretimKayit>
	{
		public UretimKayitClassMap(){
			Map(r => r.MakineOtomatikCalısmaSure).Name("Otomatik Calisma Suresi");
			Map(r => r.MakinePakBeklemeSureDk).Name("Otomatik Calisma Suresi DK");
			Map(r => r.UretimBaskiAdedi).Name("Uretim Baski Adet");
			Map(r => r.YapilanKarisimAdedi).Name("Yapilan Karisim Adet");
			Map(r => r.KullanilanCimMiktari).Name("Kullanilan Cimento Mik.");
			Map(r => r.PaketAdedi).Name("Disari Cikan Paket");
			Map(r => r.KalanCimMiktari).Name("Kalan Cim Mik.");
			Map(r => r.MakineHarcBeklemeSureSaat).Name("Harc Bekleme Suresi Saat");
			Map(r => r.MakineHarcBeklemeSureDk).Name("Harc Bekleme Suresi Dk");
			Map(r => r.MakinePakBeklemeSureSaat).Name("Paketleme Bek. Suresi Saat");
			Map(r => r.MakinePakBeklemeSureDk).Name("Paketleme Bek. Suresi Dk.");
			Map(r => r.MakinePaletBeklemeSureSaat).Name("Palet Be. Suresi Saat");
			Map(r => r.MakinePaletBeklemeSureDk).Name("Palet Be. Suresi Dk");
			

		}
}
	public class UretimKayit : Object
    {
		[CsvColumn(Name = "Makine Otomatik Calısma Sure",FieldIndex =1)]
		public int MakineOtomatikCalısmaSure { get; set; }
		[CsvColumn(Name = "Uretim Baski Adedi", FieldIndex = 2)]
		public int UretimBaskiAdedi { get; set; }
		[CsvColumn(Name = "Yapilan Karisim Adedi", FieldIndex = 3)]
		public int YapilanKarisimAdedi { get; set; }
		[CsvColumn(Name = "Kullanilan Cim Miktari", FieldIndex = 4)]
		public double KullanilanCimMiktari { get; set; }
		[CsvColumn(Name = "Kalan Cim Miktari", FieldIndex = 5)]
		public double KalanCimMiktari { get; set; }
		[CsvColumn(Name = "Paket Adedi", FieldIndex = 6)]
		public int PaketAdedi { get; set; }
		[CsvColumn(Name = "Harc Bekleme Sure Saat", FieldIndex = 7)]
		public int MakineHarcBeklemeSureSaat { get; set; }
		[CsvColumn(Name = "Harc Bekleme Sure Dk", FieldIndex = 8)]
		public int MakineHarcBeklemeSureDk { get; set; }
		[CsvColumn(Name = "Pak Bekleme Sure Saat", FieldIndex = 9)]
		public int MakinePakBeklemeSureSaat { get; set; }
		[CsvColumn(Name = "Pak Bekleme Sure Dk", FieldIndex = 10)]
		public int MakinePakBeklemeSureDk { get; set; }
		[CsvColumn(Name = "Palet Bekleme Sure Saat", FieldIndex = 11)]
		public int MakinePaletBeklemeSureSaat { get; set; }
		[CsvColumn(Name = "Palet Bekleme Sure Dk", FieldIndex = 12)]
		public int MakinePaletBeklemeSureDk { get; set; }
		[CsvColumn(Name = "Otomatik Calisma Sure Dk", FieldIndex = 13)]
		public int MakineOtomatikCalismaSureDk { get; set; }


		public UretimKayit(int MakineOtomatikCalısmaSure ,int MakineOtomatikCalismaSureDk, int UretimBaskiAdedi,int YapilanKarisimAdedi,double KullanilanCimMiktari,
			double KalanCimMiktari,int PaketAdedi,int MakineHarcBeklemeSureSaat,int MakineHarcBeklemeSureDk,int MakinePakBeklemeSureSaat,
			int MakinePakBeklemeSureDk,int MakinePaletBeklemeSureSaat,int MakinePaletBeklemeSureDk)
        {
			
			this.MakineOtomatikCalısmaSure = MakineOtomatikCalısmaSure;
			this.MakineOtomatikCalismaSureDk = MakineOtomatikCalismaSureDk;
			this.UretimBaskiAdedi = UretimBaskiAdedi;
			this.YapilanKarisimAdedi = YapilanKarisimAdedi;
			this.KullanilanCimMiktari = KullanilanCimMiktari;
			this.KalanCimMiktari = KalanCimMiktari;
			this.PaketAdedi = PaketAdedi;
			this.MakineHarcBeklemeSureSaat = MakineHarcBeklemeSureSaat;
			this.MakineHarcBeklemeSureDk = MakineHarcBeklemeSureDk;
			this.MakinePakBeklemeSureSaat = MakinePakBeklemeSureSaat;
			this.MakinePakBeklemeSureDk = MakinePakBeklemeSureDk;
			this.MakinePaletBeklemeSureSaat = MakinePaletBeklemeSureSaat;
			this.MakinePaletBeklemeSureDk = MakinePaletBeklemeSureDk;
		

		}
	}
	public class AlarmTag :Object
    {
		public int no;
		public DateTime Gun;
		public DateTime Saat;
		public string  PLCadres;
		public string Aciklama;
		public bool showed;
		
		public AlarmTag(int no, string PLCadres,string Aciklama)
        {

			this.no = no;
			this.Gun = Gun;
			this.Saat = Saat;
			this.PLCadres = PLCadres;
			this.Aciklama = Aciklama;
			this.showed = showed;
			
		}
	}
}
