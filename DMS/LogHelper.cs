using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS   
{
    public static class LogHelper
    {
        public static void AddLog(int? userId, string action, string description)
        {
            string computerName = Environment.MachineName;
            string userName = Environment.UserName;

            try
            {
                string query = @"
                INSERT INTO LogKayitlari (KullaniciID, KullaniciAdi, BilgisayarAdi, Islem, Tarih, Aciklama)
                VALUES (@userId, @userName, @computer, @action, GETDATE(), @desc);";

                SqlParameter[] prms = {
                new SqlParameter("@userId", userId != null ? (object)userId : DBNull.Value),
                new SqlParameter("@userName", userName),
                new SqlParameter("@computer", computerName),
                new SqlParameter("@action", action),
                new SqlParameter("@desc", description)
            };

                Database.ExecuteNonQuery(query, prms);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log error: " + ex.Message);
            }
        }
    }

}
