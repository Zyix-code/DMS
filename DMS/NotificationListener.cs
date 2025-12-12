using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DMS
{
    public static class NotificationListener
    {
        private static Timer timer;
        private static int lastOrderId = 0;

        public static void Start()
        {
            timer = new Timer
            {
                Interval = 10000
            };
            timer.Tick += CheckForUpdates;
            timer.Start();

            InitializeLastOrder();
        }

        private static void InitializeLastOrder()
        {
            try
            {
                string query = "SELECT ISNULL(MAX(SiparisID), 0) FROM Siparisler";
                object result = Database.ExecuteScalar(query);

                lastOrderId = Convert.ToInt32(result);
            }
            catch { lastOrderId = 0; }
        }

        private static void CheckForUpdates(object sender, EventArgs e)
        {
            try
            {
                string query = @"SELECT TOP 1 SiparisID, SiparisNo, AliciAd
                                FROM Siparisler
                                ORDER BY SiparisID DESC";

                DataTable dt = Database.ExecuteQuery(query);

                if (dt.Rows.Count == 0)
                    return;

                int newId = Convert.ToInt32(dt.Rows[0]["SiparisID"]);

                if (newId > lastOrderId)
                {
                    string siparisNo = dt.Rows[0]["SiparisNo"].ToString();
                    string alici = dt.Rows[0]["AliciAd"].ToString();

                    SoundHelper.NotifyUser(
                        UserSession.KullaniciID,
                        "Yeni Sipariş",
                        $"Sipariş No: {siparisNo}\nAlıcı: {alici}"
                    );

                    lastOrderId = newId;
                }
            }
            catch
            {
              
            }
        }
    }
}
