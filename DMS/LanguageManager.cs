using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DMS
{
    /*
     *  == KULLANIM ===
     *  HERHANGİ BİR FORUMA GİRDİĞİNİZ DE LOAD KISMI 
     *  public partial class LoginForm : BaseForm
     *  BASEFORM EKLENMELİ AKSİ TAKTİRDE HEM TEMA HEM DE LANGUAGE KULLANILMAZ
     *  LANGUAGE ŞUAN ÇEVRİMDIŞI KULLANILMIYOR ÇÜNKÜ KULLANAN ARKADAŞLARIN HEPSİ TÜRK ^_^
     *   label2.Text = LanguageManager.GetText("UsernameLabel"); // BU DA BUTTON LABEL GİBİ DİĞER DEĞİŞKENLERİN DEĞİŞMESİNİ SAĞLAR
     *   this.Text = LanguageManager.GetText("LoginPanel"); // BU FORM ADINI DİLE GÖRE DEĞİŞTİRİR 
     */
    public static class LanguageManager
    {
        public static event Action<string> LanguageChanged;

        private static readonly Dictionary<string, Dictionary<string, string>> languages =
            new Dictionary<string, Dictionary<string, string>>()
            {
                ["Türkçe"] = new Dictionary<string, string>()
                {   
                    // === LOGİN PANEL ===
                    ["LoginPanel"] = "Giriş Paneli",
                    ["ProgramInfo"] = "Bu program SELÇUK ŞAHİN tarafından geliştirilmiştir.\r\nHerhangi bir arıza, öneri, şikayet için.\r\nselcuksahin158@gmail.com'a mail gönderebilirsiniz.",
                    ["UsernameLabel"] = "Kullanıcı adı / e-posta adresiniz:",
                    ["PasswordLabel"] = "Parola:",
                    ["UsernamePlaceholder"] = "Kullanıcı adı yada e-posta adresinizi giriniz",
                    ["PasswordPlaceholder"] = "Parolanızı giriniz",
                    ["LoginButton"] = "Giriş Yap",
                    ["ForgotPassword"] = "Parolanızı mı unuttunuz?",
                    ["RegisterButton"] = "Kayıt Ol",
                    ["ShowHidePassword"] = "Şifreyi gizler veya gösterir."
                    // === LOGİN PANEL ===
                },

                ["English"] = new Dictionary<string, string>()
                { 
                    // === LOGİN PANEL ===
                    ["LoginPanel"] = "Login Panel",
                    ["ProgramInfo"] = "This program was developed by SELÇUK ŞAHİN.\r\nFor any malfunction, suggestion, or complaint.\r\nYou can send an email to selcuksahin158@gmail.com.",
                    ["UsernameLabel"] = "Your username / email address:",
                    ["PasswordLabel"] = "Password:",
                    ["UsernamePlaceholder"] = "Enter your username or email address",
                    ["PasswordPlaceholder"] = "Enter your password",
                    ["LoginButton"] = "Login",
                    ["ForgotPassword"] = "Forgot your password?",
                    ["RegisterButton"] = "Register",
                    ["ShowHidePassword"] = "Hide or show password."
                    // === LOGİN PANEL ===
                }
            };

        public static string GetText(string key, string lang = null)
        {
            if (string.IsNullOrEmpty(lang))
                lang = Properties.userSettings.Default.Language;

            if (!languages.ContainsKey(lang))
                lang = "English";

            var dict = languages[lang];

            if (dict.ContainsKey(key))
                return dict[key];

            return key;
        }

        public static void ApplyLanguage(Form form, string lang = null)
        {
            if (string.IsNullOrEmpty(lang))
                lang = Properties.userSettings.Default.Language;

            foreach (Control ctrl in form.Controls)
                ApplyLanguageToControl(ctrl, lang);

            if (!string.IsNullOrEmpty(form.Text))
                form.Text = GetText(form.Text, lang);
        }

        private static void ApplyLanguageToControl(Control ctrl, string lang)
        {
            if (ctrl.Tag != null)
            {
                string key = ctrl.Tag.ToString();
                ctrl.Text = GetText(key, lang);

                if (ctrl is TextBox txt)
                {
                    if (string.IsNullOrEmpty(txt.Text))
                        txt.Text = GetText(key, lang);

                    txt.Enter += (s, e) =>
                    {
                        if (txt.Text == GetText(key, lang))
                            txt.Text = "";
                    };
                    txt.Leave += (s, e) =>
                    {
                        if (string.IsNullOrEmpty(txt.Text))
                            txt.Text = GetText(key, lang);
                    };
                }
            }

            if (ctrl.HasChildren)
            {
                foreach (Control child in ctrl.Controls)
                    ApplyLanguageToControl(child, lang);
            }

            if (ctrl is DataGridView dgv)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string colKey = col.Tag != null ? col.Tag.ToString() : col.HeaderText;
                    col.HeaderText = GetText(colKey, lang);
                }
            }

            if (ctrl is MenuStrip ms)
            {
                foreach (ToolStripMenuItem item in ms.Items)
                    ApplyLanguageToMenuItem(item, lang);
            }

            if (ctrl is TabControl tc)
            {
                foreach (TabPage tp in tc.TabPages)
                    tp.Text = GetText(tp.Tag?.ToString() ?? tp.Text, lang);
            }

            if (ctrl is GroupBox gb)
                gb.Text = GetText(gb.Tag?.ToString() ?? gb.Text, lang);
        }

        private static void ApplyLanguageToMenuItem(ToolStripMenuItem item, string lang)
        {
            item.Text = GetText(item.Tag?.ToString() ?? item.Text, lang);

            foreach (ToolStripMenuItem sub in item.DropDownItems.OfType<ToolStripMenuItem>())
                ApplyLanguageToMenuItem(sub, lang);
        }

        public static void ChangeLanguage(string newLang, Form form)
        {
            Properties.userSettings.Default.Language = newLang;
            Properties.userSettings.Default.Save();

            ApplyLanguage(form, newLang);
            LanguageChanged?.Invoke(newLang);
        }
    }
}