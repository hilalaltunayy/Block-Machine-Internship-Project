/*using System;
using System.IO; // Dosya işlemleri için gerekli

class Program
{
    static void Main(string[] args)
    {
        string filePath = "sensor_data.csv";

        // Eğer dosya yoksa başlık satırını yaz
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Tarih,Sıcaklık\n");
        }

        Random rnd = new Random();

        while (true)
        {
            // 20 ile 30 arasında rastgele sıcaklık üret
            // Normalde 20-30 °C, bazen anormal yüksek değer üret
            double temperature;
            if (rnd.Next(0, 20) == 0) // %5 ihtimalle
            {
                temperature = rnd.Next(90, 120); // anormal sıcaklık
            }
            else
            {
                temperature = 20 + rnd.NextDouble() * 10; // normal sıcaklık
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // CSV formatında satır oluştur
            string line = $"{timestamp},{temperature:F2}";

            // Dosyaya ekle
            File.AppendAllText(filePath, line + "\n");

            Console.WriteLine($"Kaydedildi: {line}");

            System.Threading.Thread.Sleep(1000); // 1 saniye bekle
        }
    }
}*/

using System;
using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        string dbPath = "sensor_data.db"; // exe ile aynı klasörde oluşur
        string connStr = $"Data Source={dbPath};Version=3;";

        using (var conn = new SQLiteConnection(connStr))
        {
            conn.Open();

            // ÖNEMLİ: WAL modunu etkinleştir (okuma/yazma uyumu için)
            using (var pragma = new SQLiteCommand("PRAGMA journal_mode=WAL;", conn))
            {
                var mode = pragma.ExecuteScalar();
                Console.WriteLine($"PRAGMA journal_mode result: {mode}");
            }

            // Tabloyu yoksa oluştur
            string createTable = @"
                CREATE TABLE IF NOT EXISTS SensorData (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Tarih TEXT NOT NULL,
                    Sicaklik REAL NOT NULL
                );";
            using (var cmd = new SQLiteCommand(createTable, conn))
                cmd.ExecuteNonQuery();

            var rnd = new Random();

            Console.WriteLine("SQLite yazma başladı. Durdurmak için Ctrl + C.");

            while (true)
            {
                // %95 normal (20–30 °C), %5 anormal (90–120 °C)
                double sicaklik = (rnd.Next(0, 20) == 0)
                    ? rnd.Next(90, 120)
                    : 20 + rnd.NextDouble() * 10;

                string zaman = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string insert = "INSERT INTO SensorData (Tarih, Sicaklik) VALUES (@t, @s)";
                using (var cmd = new SQLiteCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@t", zaman);
                    cmd.Parameters.AddWithValue("@s", sicaklik);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine($"Kaydedildi: {zaman}, {sicaklik:F2}");
                System.Threading.Thread.Sleep(1000); // 1 sn
            }
        }
    }
}

