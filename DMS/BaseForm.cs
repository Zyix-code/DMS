using System;
using System.Windows.Forms;

namespace DMS
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.Load += BaseForm_Load;

            ThemeManager.ThemeChanged += (newTheme) =>
            {
                ThemeManager.ApplyTheme(this, newTheme);
            };

            LanguageManager.LanguageChanged += (newLang) =>
            {
                LanguageManager.ApplyLanguage(this, newLang);
            };
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            string theme = Properties.userSettings.Default.Theme;
            ThemeManager.ApplyTheme(this, theme);
            BackupHelper.RunDailyBackup();
            NotificationListener.Start();

            /* 
             * KULLANIM
             * DİL ŞUAN ÇEVRİM DIŞI AKTİF OLARAK KULLANILMIYOR AMA KULLANILMAK İSTERSENİZ 
             * AŞŞAĞIDAKİ KODU YORUM SATIRINDAN ÇIKARMANIZ YETERLİDİR.

                 string lang = Properties.userSettings.Default.Language;
                 LanguageManager.ApplyLanguage(this, lang);
            */

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);

        }
    }
}
