using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DMS
{
    public static class EmailHelper
    {
        private static readonly string FromAddress = "Sizlerin mail adresi";
        private static readonly string Password = "sizin mail şifreniz";
        private static readonly string SmtpHost = "host adresiniz";
        private static readonly int SmtpPort = 587;

        public static async Task SendMailAsync(string to, string subject, string htmlBody)
        {
            try
            {
                if (!IsEmailNotificationEnabled(UserSession.KullaniciID))
                    return;

                using (SmtpClient smtp = new SmtpClient(SmtpHost, SmtpPort))
                {
                    smtp.Credentials = new NetworkCredential(FromAddress, Password);
                    smtp.EnableSsl = true;

                    using (MailMessage mail = new MailMessage(FromAddress, to, subject, htmlBody))
                    {
                        mail.IsBodyHtml = true;
                        mail.BodyEncoding = Encoding.UTF8;
                        mail.SubjectEncoding = Encoding.UTF8;

                        await smtp.SendMailAsync(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "E-posta Gönderim Hatası", ex.Message);
            }
        }

        private static bool IsEmailNotificationEnabled(int kullaniciId)
        {
            try
            {
                string query = "SELECT EmailNotification FROM Kullanicilar WHERE KullaniciID = @id";
                SqlParameter[] parameters = { new SqlParameter("@id", kullaniciId) };

                object result = Database.ExecuteScalar(query, parameters);

                if (result == DBNull.Value || result == null)
                    return false;

                return Convert.ToBoolean(result);
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(kullaniciId, "E-posta Bildirim Kontrol Hatası", ex.Message);
                return false;
            }
        }

        public static async Task SendTemplateMailAsync(
            string title,
            string mainMessage,
            List<string> detailList = null,
            string type = "info",
            int? targetUserId = null
        )
        {
            string color = "#0078d7";
            string emoji = "🔔";

            switch (type.ToLower())
            {
                case "success": color = "#28a745"; emoji = "✅"; break;
                case "warning": color = "#ffc107"; emoji = "⚠️"; break;
                case "error": color = "#dc3545"; emoji = "❌"; break;
                case "security": color = "#c82333"; emoji = "🔒"; break;
            }

            string detailsHtml = "";
            if (detailList != null && detailList.Count > 0)
            {
                StringBuilder sb = new StringBuilder("<ul>");
                foreach (var item in detailList)
                    sb.Append($"<li>{item}</li>");
                sb.Append("</ul>");
                detailsHtml = sb.ToString();
            }

            string subject = $"{emoji} {title}";
            string htmlBody = $@"
            <html>
            <head>
              <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f5f6fa;
                    margin: 0;
                    padding: 0;
                }}
                .container {{
                    max-width: 600px;
                    background-color: #ffffff;
                    margin: 40px auto;
                    padding: 30px;
                    border-radius: 10px;
                    box-shadow: 0 4px 10px rgba(0,0,0,0.1);
                }}
                .header {{
                    text-align: center;
                    border-bottom: 2px solid {color};
                    padding-bottom: 15px;
                    margin-bottom: 25px;
                }}
                .title {{
                    color: {color};
                    font-size: 22px;
                    margin-top: 0;
                }}
                .content {{
                    color: #333;
                    line-height: 1.6;
                    font-size: 15px;
                }}
                ul {{
                    background-color: #f9fafc;
                    padding: 15px;
                    border-radius: 6px;
                    list-style-type: none;
                }}
                ul li::before {{
                    content: '•';
                    color: {color};
                    font-weight: bold;
                    display: inline-block; 
                    width: 1em;
                    margin-left: -1em;
                }}
                .footer {{
                    text-align: center;
                    font-size: 13px;
                    color: #777;
                    margin-top: 30px;
                    border-top: 1px solid #eee;
                    padding-top: 15px;
                }}
              </style>
            </head>
            <body>
              <div class='container'>
                <div class='header'>
                  <h2 class='title'>{emoji} {title}</h2>
                </div>
                <div class='content'>
                  <p>{mainMessage}</p>
                  {detailsHtml}
                  <p style='margin-top:20px;'>Saygılarımızla,<br><b>DMS Otomasyon Sistemi</b></p>
                </div>
                <div class='footer'>
                  © 2025 DMS | Bu mesaj otomatik gönderilmiştir.
                </div>
              </div>
            </body>
            </html>";

            if (targetUserId.HasValue)
            {
                try
                {
                    string query = "SELECT Eposta FROM Kullanicilar WHERE KullaniciID = @id AND EmailNotification = 1";
                    SqlParameter[] parameters = { new SqlParameter("@id", targetUserId.Value) };

                    object epostaObj = Database.ExecuteScalar(query, parameters);
                    if (epostaObj != null && epostaObj != DBNull.Value)
                    {
                        string eposta = epostaObj.ToString();
                        await SendMailAsync(eposta, subject, htmlBody);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.AddLog(UserSession.KullaniciID, "E-posta Gönderim Hatası (Tek Kullanıcı)", ex.Message);
                }

                return;
            }

            try
            {
                string query = "SELECT Eposta FROM Kullanicilar WHERE EmailNotification = 1 AND Eposta IS NOT NULL";
                List<string> epostaList = new List<string>();

                using (SqlDataReader reader = Database.ExecuteReader(query, null))
                {
                    while (reader.Read())
                    {
                        string eposta = reader["Eposta"]?.ToString();
                        if (!string.IsNullOrEmpty(eposta))
                            epostaList.Add(eposta);
                    }
                }

                foreach (var eposta in epostaList)
                    await SendMailAsync(eposta, subject, htmlBody);

                LogHelper.AddLog(UserSession.KullaniciID, "Toplu E-posta", $"{epostaList.Count} kullanıcıya '{title}' konulu bildirim gönderildi.");
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Toplu E-posta Hatası", ex.Message);
            }
        }
    }
}

/*
 * 🔸 Tek kullanıcıya:
        await EmailHelper.SendTemplateMailAsync(
            "Yeni Sipariş Oluşturuldu",
            "Sistemde yeni bir sipariş oluşturuldu.",
            new List<string> { $"Sipariş No: {orderNo}", $"Tür: {transactionType}" },
            "success",
            targetUserId: UserSession.KullaniciID
        );
*/

/*
 * 🔸 Tüm bildirim açık kullanıcılara:
        await EmailHelper.SendTemplateMailAsync(
            "Yeni Sipariş Oluşturuldu",
            "Sistemde yeni bir sipariş oluşturuldu.",
            new List<string> { $"Sipariş No: {orderNo}", $"Tür: {transactionType}" },
            "success"
        );
*/
