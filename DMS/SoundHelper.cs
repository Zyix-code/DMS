using DMS;
using System.Data.SqlClient;
using System.Data;
using System.Media;
using System.Windows.Forms;
using System;

public static class SoundHelper
{
    private static NotifyIcon notifyIcon;

    static SoundHelper()
    {
        notifyIcon = new NotifyIcon
        {
            Visible = true,
            Icon = System.Drawing.SystemIcons.Information,
            Text = "DMS Bildirim Sistemi"
        };
    }

    private static void ResetNotifyIcon()
    {
        notifyIcon.Visible = false;
        notifyIcon.Visible = true;
    }

    public static void ShowNotification(string title, string message, ToolTipIcon icon = ToolTipIcon.Info, int timeout = 5000)
    {
        try
        {
            if (notifyIcon == null)
                return;

            ResetNotifyIcon();

            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = message;
            notifyIcon.BalloonTipIcon = icon;

            notifyIcon.ShowBalloonTip(timeout);
        }
        catch (Exception ex)
        {
            LogHelper.AddLog(UserSession.KullaniciID, "Bildirim Gösterme Hatası", ex.Message);
        }
    }

    private static bool IsNotificationEnabled(int kullaniciId)
    {
        try
        {
            string query = "SELECT SoundNotification FROM Kullanicilar WHERE KullaniciID = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", kullaniciId) };
            object result = Database.ExecuteScalar(query, parameters);

            return result != null && result != DBNull.Value && Convert.ToBoolean(result);
        }
        catch (Exception ex)
        {
            LogHelper.AddLog(kullaniciId, "Bildirim Ayar Kontrol Hatası", ex.Message);
            return false;
        }
    }

    public static void PlayNotificationSound(int kullaniciId)
    {
        if (!IsNotificationEnabled(kullaniciId)) return;
        try { SystemSounds.Asterisk.Play(); } catch (Exception ex) { LogHelper.AddLog(kullaniciId, "Ses Hatası", ex.Message); }
    }

    public static void PlayWarningSound(int kullaniciId)
    {
        if (!IsNotificationEnabled(kullaniciId)) return;
        try { SystemSounds.Exclamation.Play(); } catch (Exception ex) { LogHelper.AddLog(kullaniciId, "Ses Hatası", ex.Message); }
    }

    public static void PlayErrorSound(int kullaniciId)
    {
        if (!IsNotificationEnabled(kullaniciId)) return;
        try { SystemSounds.Hand.Play(); } catch (Exception ex) { LogHelper.AddLog(kullaniciId, "Ses Hatası", ex.Message); }
    }

    public static void PlaySuccessSound(int kullaniciId)
    {
        if (!IsNotificationEnabled(kullaniciId)) return;
        try { SystemSounds.Beep.Play(); } catch (Exception ex) { LogHelper.AddLog(kullaniciId, "Ses Hatası", ex.Message); }
    }

    public static void NotifyUser(int kullaniciId, string title, string message, ToolTipIcon icon = ToolTipIcon.Info)
    {
        if (!IsNotificationEnabled(kullaniciId)) return;

        PlayNotificationSound(kullaniciId);
        ShowNotification(title, message, icon);
    }

    public static void NotifyAllUsers(string title, string message, ToolTipIcon icon = ToolTipIcon.Info)
    {
        try
        {
            string query = "SELECT KullaniciID FROM Kullanicilar WHERE SoundNotification = 1";
            DataTable table = Database.ExecuteQuery(query);

            foreach (DataRow row in table.Rows)
            {
                int userId = Convert.ToInt32(row["KullaniciID"]);
                PlayNotificationSound(userId);
            }
            ShowNotification(title, message, icon);
        }
        catch (Exception ex)
        {
            LogHelper.AddLog(UserSession.KullaniciID, "Toplu Bildirim Hatası", ex.Message);
        }
    }
}
/*
    📘 Kullanım Örnekleri:
    SoundHelper.PlaySuccessSound(UserSession.KullaniciID);   // Başarılı işlem
    SoundHelper.PlayErrorSound(UserSession.KullaniciID);     // Hata
    SoundHelper.PlayWarningSound(UserSession.KullaniciID);   // Uyarı
    SoundHelper.PlayNotificationSound(UserSession.KullaniciID); // Yeni bildirim

    * Sipariş Oluşturulduğunda Tek Kullanıcıya
    SoundHelper.NotifyUser(
    UserSession.KullaniciID,
    "Sipariş Oluşturuldu",
    $"Sipariş No: {orderNo}"
    );

    Tüm Kullanıcılara
    SoundHelper.NotifyAllUsers(
    "Yeni Sipariş",
    $"Sipariş oluşturuldu: {orderNo}"
    );

*/
