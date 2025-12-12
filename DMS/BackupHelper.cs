using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS
{
    public static class BackupHelper
    {
        private static string BackupFolder = @"D:\DMS_Yedek";

        public static void RunDailyBackup()
        {
            try
            {
                if (UserSession.YetkiSeviyesi < 4)
                {
                    return; 
                }

                Directory.CreateDirectory(BackupFolder);

                FileInfo[] bakFiles = new DirectoryInfo(BackupFolder).GetFiles("*.bak");
                FileInfo[] excelFiles = new DirectoryInfo(BackupFolder).GetFiles("*.csv");

                bool needsBackup =
                    bakFiles.Length == 0 ||
                    (DateTime.Now - bakFiles.Max(f => f.CreationTime)).TotalDays >= 1 ||
                    excelFiles.Length == 0 ||
                    (DateTime.Now - excelFiles.Max(f => f.CreationTime)).TotalDays >= 1;

                if (!needsBackup)
                    return;

                BackupDatabase();
                ExportOrdersToExcel();
                SendBackupMail();
                MessageBox.Show("Günlük otomatik yedekleme başarıyla tamamlandı.", "Yedekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogHelper.AddLog(UserSession.KullaniciID, "Yedekleme", "Günlük otomatik yedekleme başarıyla tamamlandı.");
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Yedekleme Hatası", ex.Message);
            }
        }

        private static void BackupDatabase()
        {
            string dbName;
            using (var conn = Database.GetConnection())
            {
                dbName = conn.Database;
            }

            string fileName = $"{DateTime.Now:dd.MM.yyyy}-DMS-Database.bak";
            string fullPath = Path.Combine(BackupFolder, fileName);

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string cmd = $"BACKUP DATABASE [{dbName}] TO DISK='{fullPath}'";

                using (SqlCommand command = new SqlCommand(cmd, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void ExportOrdersToExcel()
        {
            string file = Path.Combine(BackupFolder, $"{DateTime.Now:dd.MM.yyyy}-DMS-TumVeriler.csv");

            using (StreamWriter writer = new StreamWriter(file, false, Encoding.UTF8))
            {
                writer.WriteLine("== SiparisBilgileri ==");

                string siparisQuery = "SELECT * FROM Siparisler";
                DataTable siparisDt = Database.ExecuteQuery(siparisQuery);

                for (int i = 0; i < siparisDt.Columns.Count; i++)
                {
                    writer.Write(siparisDt.Columns[i].ColumnName);
                    if (i < siparisDt.Columns.Count - 1)
                        writer.Write(";");
                }
                writer.WriteLine();

                foreach (DataRow row in siparisDt.Rows)
                {
                    for (int i = 0; i < siparisDt.Columns.Count; i++)
                    {
                        string val = row[i]?.ToString().Replace(";", " ");
                        writer.Write(val);
                        if (i < siparisDt.Columns.Count - 1)
                            writer.Write(";");
                    }
                    writer.WriteLine();
                }

                writer.WriteLine();

                writer.WriteLine("== UrunHareketleri ==");

                string hareketQuery = @"
                SELECT 
                    UH.HareketID,
                    UH.SiparisID,
                    M.MarkaAdi AS [Marka],
                    UH.Model,
                    C.CinsAdi AS [Cins],
                    UH.GirisCikis AS [İşlem Türü],
                    UH.Adet,
                    UH.Tarih,
                    UH.Aciklama
                FROM UrunHareketleri UH
                LEFT JOIN Markalar M ON M.MarkaID = UH.MarkaID
                LEFT JOIN Cinsler C ON C.CinsID = UH.CinsID";

                DataTable hareketDt = Database.ExecuteQuery(hareketQuery);

                for (int i = 0; i < hareketDt.Columns.Count; i++)
                {
                    writer.Write(hareketDt.Columns[i].ColumnName);
                    if (i < hareketDt.Columns.Count - 1)
                        writer.Write(";");
                }
                writer.WriteLine();

                foreach (DataRow row in hareketDt.Rows)
                {
                    for (int i = 0; i < hareketDt.Columns.Count; i++)
                    {
                        string val = row[i]?.ToString().Replace(";", " ");
                        writer.Write(val);
                        if (i < hareketDt.Columns.Count - 1)
                            writer.Write(";");
                    }
                    writer.WriteLine();
                }
            }

        }

        private static void SendBackupMail()
        {
            string dbFile = Path.Combine(BackupFolder, $"{DateTime.Now:dd.MM.yyyy}-DMS-Database.bak");
            string excelFile = Path.Combine(BackupFolder, $"{DateTime.Now:dd.MM.yyyy}-DMS-Siparisler.csv");

            string subject = "DMS Günlük Otomatik Yedek";
            string body = $@"
                <p>DMS otomatik günlük yedeği başarıyla tamamlandı.</p>
                <p><b>Tarih:</b> {DateTime.Now}</p>
                <p>Eklerde veritabanı ve sipariş listesi bulunmaktadır.</p>
                <p>Bu mail otomatik oluşturulmuştur.</p>
            ";
        }
    }
}
