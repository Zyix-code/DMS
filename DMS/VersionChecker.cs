using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using DMS;

public static class VersionChecker
{
    private const string UpdatePageUrl = "LOCALİP/VersionChecker/index.html";

    public static string GetCurrentVersion()
    {
        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }

    public static void CheckVersionFromDatabase()
    {
        try
        {
            string query = @"
                SELECT TOP 1 SurumNo, ZorunluGuncelleme
                FROM UygulamaSurumleri
                ORDER BY YayınTarihi DESC";

            DataTable dt = Database.ExecuteQuery(query);

            if (dt.Rows.Count == 0)
                return;

            string latestVersion = dt.Rows[0]["SurumNo"].ToString();
            bool isMandatory = Convert.ToBoolean(dt.Rows[0]["ZorunluGuncelleme"]);
            string currentVersion = GetCurrentVersion();

            Version cv = new Version(currentVersion);
            Version lv = new Version(latestVersion);

            if (cv >= lv)
                return;

            string message = $"Yeni bir sürüm mevcut: {latestVersion}\nMevcut sürüm: {currentVersion}";

            if (isMandatory)
            {
                MessageBox.Show(
                    message + "\nBu güncelleme zorunludur. Güncelleme sayfasına yönlendiriliyorsunuz.",
                    "Zorunlu Güncelleme",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Process.Start(new ProcessStartInfo
                {
                    FileName = UpdatePageUrl,
                    UseShellExecute = true
                });

                Application.Exit();
                return;
            }

            DialogResult result = MessageBox.Show(
                message + "\nGüncelleme sayfasına gitmek ister misiniz?",
                "Güncelleme Mevcut",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = UpdatePageUrl,
                    UseShellExecute = true
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Sürüm kontrolü sırasında hata oluştu:\n" + ex.Message,
                "Hata",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            Process.Start(new ProcessStartInfo
            {
                FileName = UpdatePageUrl,
                UseShellExecute = true
            });
        }
    }
}
