using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DMS
{
    public partial class SettingsForm : BaseForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadUserSettings();
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Hata", $"Ayarlar yüklenirken hata: {ex.Message}");
                MessageBox.Show("Ayarlar yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void usersProfilePage_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (e.TabPage == tabAdminSettings && UserSession.YetkiSeviyesi < 4)
                {
                    LogHelper.AddLog(UserSession.KullaniciID, "Yetkisiz İşlem", $"{UserSession.KullaniciAdi} 'Tüm Kullanıcılar' sekmesine yetkisiz erişim girişiminde bulundu.");
                    MessageBox.Show("Bu alana erişim yetkiniz bulunmamaktadır.", "Yetkisiz İşlem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                if (e.TabPage == tabAdminSettings)
                {
                    label1.Location = new Point(86, 590);
                    logoPictureBox.Location = new Point(10, 84);
                    closeLabel.Location = new Point(1452, 9);
                    minimanizeLabel.Location = new Point(1431, 9);
                    btnMainMenu.Location = new Point(1216, 728);
                    btnLogout.Location = new Point(1327, 728);
                    usersProfilePage.Size = new Size(909, 710);
                    this.Size = new Size(1492, 771);
                }
                else if (e.TabPage == tabUserSettings)
                {
                    label1.Location = new Point(87, 592);
                    logoPictureBox.Location = new Point(0, 0);
                    closeLabel.Location = new Point(891, 9);
                    minimanizeLabel.Location = new Point(870,9);
                    btnMainMenu.Location = new Point(645, 468);
                    btnLogout.Location = new Point(756, 468);
                    usersProfilePage.Size = new Size(341, 448);
                    this.Size = new Size(931, 569);
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Hata", $"Sekme geçişinde hata oluştu: {ex.Message}");
            }
        }
        private void LoadUserSettings()
        {
            try
            {
                chkStartWithWindows.Checked = Properties.userSettings.Default.StartWithWindows;
                chkAutoLogin.Checked = Properties.userSettings.Default.AutoLogin;
                chkKeepSession.Checked = Properties.userSettings.Default.KeepSession;
                cmbTheme.SelectedItem = Properties.userSettings.Default.Theme;

                string query = "SELECT EmailNotification, SoundNotification FROM Kullanicilar WHERE KullaniciID = @id";
                SqlParameter[] parameters = { new SqlParameter("@id", UserSession.KullaniciID) };
                DataTable dt = Database.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    object emailVal = dt.Rows[0]["EmailNotification"];
                    object soundVal = dt.Rows[0]["SoundNotification"];

                    chkEmail.Checked = (emailVal != DBNull.Value) ? Convert.ToBoolean(emailVal) : false;
                    chkSound.Checked = (soundVal != DBNull.Value) ? Convert.ToBoolean(soundVal) : false;
                }
                else
                {
                    chkEmail.Checked = false;
                    chkSound.Checked = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Hata",
                    $"Ayarlar yüklenirken hata: {ex.Message}");
                MessageBox.Show("Ayarlar yüklenirken hata oluştu:\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //cmbLanguage.SelectedItem = Properties.userSettings.Default.Language; Dil seçeneği aktif olarak kullanılmıyor ondan dolayı yorum satırı
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateAutoLoginSettings())
                    return;

                SaveStartupSettings();
                SaveLoginSettings();
                SaveThemeAndLanguage();
                SaveNotifications();

                Properties.userSettings.Default.Save();

                LogHelper.AddLog(UserSession.KullaniciID, "Ayarlar Kaydedildi", "Tüm kullanıcı ayarları başarıyla kaydedildi.");
                MessageBox.Show("Tüm ayarlar başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Hata", $"Ayarlar kaydedilirken hata: {ex.Message}");
                MessageBox.Show("Ayarlar kaydedilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateAutoLoginSettings()
        {
            string savedUsername = Properties.userSettings.Default.username;
            string savedPassword = Properties.userSettings.Default.password;

            if (chkAutoLogin.Checked && !chkKeepSession.Checked)
            {
                MessageBox.Show("Otomatik giriş yapabilmek için 'Oturum açık kalsın' seçeneğini de işaretlemelisiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkAutoLogin.Checked = false;
                return false;
            }

            if (chkAutoLogin.Checked && (string.IsNullOrEmpty(savedUsername) || string.IsNullOrEmpty(savedPassword)))
            {
                MessageBox.Show("Otomatik giriş için önce geçerli bir kullanıcı ile giriş yapıp 'Oturum açık kalsın' seçeneğini işaretlemelisiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkAutoLogin.Checked = false;
                return false;
            }

            return true;
        }
        private void SaveStartupSettings()
        {
            try
            {
                Properties.userSettings.Default.StartWithWindows = chkStartWithWindows.Checked;

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    if (chkStartWithWindows.Checked)
                        key?.SetValue("DMS", Application.ExecutablePath);
                    else
                        key?.DeleteValue("DMS", false);
                }

                LogHelper.AddLog(UserSession.KullaniciID, "Başlangıç Ayarları", $"Windows ile başlatma: {chkStartWithWindows.Checked}");
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Hata", $"Başlangıç ayarları kaydedilirken hata: {ex.Message}");
            }
        }
        private void SaveLoginSettings()
        {
            try
            {
                Properties.userSettings.Default.KeepSession = chkKeepSession.Checked;
                Properties.userSettings.Default.AutoLogin = chkAutoLogin.Checked;

                if (chkKeepSession.Checked)
                {
                    Properties.userSettings.Default.username = UserSession.KullaniciAdi;
                    Properties.userSettings.Default.password = UserSession.Sifre;
                }
                else
                {
                    Properties.userSettings.Default.username = "";
                    Properties.userSettings.Default.password = "";
                }

                LogHelper.AddLog(UserSession.KullaniciID, "Giriş Ayarları", $"KeepSession: {chkKeepSession.Checked}, AutoLogin: {chkAutoLogin.Checked}");
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Hata", $"Giriş ayarları kaydedilirken hata: {ex.Message}");
            }
        }
        private void SaveThemeAndLanguage()
        {
            try
            {
                Properties.userSettings.Default.Theme = cmbTheme.SelectedItem?.ToString() ?? "Sistem Varsayılanı";

                string theme = Properties.userSettings.Default.Theme;
                ThemeManager.ApplyTheme(this, theme);
                LogHelper.AddLog(UserSession.KullaniciID, "Tema/Dil", $"Tema: {theme}");

                /* 
                 * KULLANIM
                 * DİL SEÇENEĞİ AKTİF OLMADIĞI AŞŞAĞIDA Kİ KODLAR YORUM SATIRIDIR
                 * KULLANILMAK İSTENİRSE YUKARIDA Kİ LOGHELPER DÜZELTİLMELİ VE DİĞER KODLAR SADECE YORUM SATIRINDAN ÇIKARILMALIDIR
                    
                    //Properties.userSettings.Default.Language = cmbLanguage.SelectedItem?.ToString() ?? "Türkçe"; Dil seçeneği aktif olarak kullanılmıyor ondan dolayı yorum satırı
                    //string lang = Properties.userSettings.Default.Language; Dil seçeneği aktif olarak kullanılmıyor ondan dolayı yorum satırı
                    //LanguageManager.ChangeLanguage(lang, this); Dil seçeneği aktif olarak kullanılmıyor ondan dolayı yorum satırı
                    //LogHelper.AddLog(UserSession.KullaniciID, "Tema/Dil", $"Tema: {theme}, Dil: {lang}"); Dil seçeneği aktif olarak kullanılmıyor ondan dolayı yorum satırı
                */
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Hata", $"Tema/Dil ayarları kaydedilirken hata: {ex.Message}");
            }
        }
        private void SaveNotifications()
        {
            try
            {
                bool emailNoti = chkEmail.Checked;
                bool soundNoti = chkSound.Checked;

                string query = @"UPDATE Kullanicilar 
                         SET EmailNotification = @mail, 
                             SoundNotification = @sound 
                         WHERE KullaniciID = @id";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@mail", emailNoti),
                    new SqlParameter("@sound", soundNoti),
                    new SqlParameter("@id", UserSession.KullaniciID)
                };

                int affected = Database.ExecuteNonQuery(query, parameters);

                if (affected > 0)
                {
                    LogHelper.AddLog(UserSession.KullaniciID, "Bildirim Ayarları Güncellendi",
                        $"E-posta: {emailNoti}, Ses: {soundNoti}");
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Hata",
                    $"Bildirim ayarları kaydedilirken hata: {ex.Message}");
            }
        }
        private void btnResetDefaults_Click(object sender, EventArgs e)
        {
            try
            {
                var confirm = MessageBox.Show(
                    "Tüm ayarlar varsayılana döndürülsün mü?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                    return;

                chkStartWithWindows.Checked = false;
                chkAutoLogin.Checked = false;
                chkKeepSession.Checked = false;
                chkEmail.Checked = false;
                chkSound.Checked = false;
                cmbTheme.SelectedItem = "Sistem Varsayılanı";
                cmbLanguage.SelectedItem = "Türkçe";

                Properties.userSettings.Default.StartWithWindows = false;
                Properties.userSettings.Default.AutoLogin = false;
                Properties.userSettings.Default.KeepSession = false;
                Properties.userSettings.Default.Theme = "Sistem Varsayılanı";
                Properties.userSettings.Default.Language = "Türkçe";
                Properties.userSettings.Default.username = "";
                Properties.userSettings.Default.password = "";
                Properties.userSettings.Default.Save();

                ThemeManager.ApplyTheme(this, "Sistem Varsayılanı");
                LanguageManager.ChangeLanguage("Türkçe", this);

                string query = @"
                UPDATE Kullanicilar
                SET EmailNotification = 0,
                    SoundNotification = 0
                WHERE KullaniciID = @id";
                SqlParameter[] parameters = { new SqlParameter("@id", UserSession.KullaniciID) };
                Database.ExecuteNonQuery(query, parameters);

                LogHelper.AddLog(UserSession.KullaniciID, "Varsayılana Döndürme", "Tüm ayarlar (DB + Lokal) sıfırlandı ve kaydedildi.");

                MessageBox.Show("Tüm ayarlar varsayılana döndürüldü ve kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Hata", $"Ayarlar sıfırlanırken hata oluştu: {ex.Message}");
                MessageBox.Show("Ayarlar sıfırlanırken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            Close();
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimanizeLabel_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void SettingsForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown += new MouseEventHandler(Form_MouseDown);

        }

        private void logoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            logoPictureBox.MouseDown += new MouseEventHandler(Form_MouseDown);
        }
    }
}