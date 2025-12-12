using System;
using System.Drawing;
using System.Windows.Forms;

namespace DMS
{
    internal static class ThemeManager
    {
        public static event Action<string> ThemeChanged;

        public static void ApplyTheme(Form form, string theme)
        {
            if (string.IsNullOrEmpty(theme))
            {
                theme = "Varsayılan";
                Properties.userSettings.Default.Theme = theme;
                Properties.userSettings.Default.Save();
            }

            Color backColor, foreColor, controlBack, borderColor, dgvHeader, dgvAltRow;

            switch (theme)
            {
                case "Koyu":
                    backColor = Color.FromArgb(30, 30, 30);
                    foreColor = Color.WhiteSmoke;
                    controlBack = Color.FromArgb(45, 45, 48);
                    borderColor = Color.FromArgb(70, 70, 75);
                    dgvHeader = Color.FromArgb(55, 55, 60);
                    dgvAltRow = Color.FromArgb(38, 38, 40);
                    break;

                case "Açık":
                    backColor = Color.WhiteSmoke;
                    foreColor = Color.FromArgb(16, 50, 100);
                    controlBack = Color.White;
                    borderColor = Color.LightGray;
                    dgvHeader = Color.White;
                    dgvAltRow = Color.White;
                    break;

                default:
                    backColor = Color.FromArgb(230, 252, 222);
                    foreColor = Color.FromArgb(16, 50, 100);
                    controlBack = Color.FromArgb(240, 255, 235);
                    borderColor = Color.FromArgb(180, 220, 180);
                    dgvHeader = Color.FromArgb(210, 245, 210);
                    dgvAltRow = Color.FromArgb(230, 252, 222);
                    break;
            }

            form.BackColor = backColor;
            form.ForeColor = foreColor;

            UpdateLogo(form, theme);
            ApplyThemeToControls(form.Controls, theme, backColor, foreColor, controlBack, borderColor, dgvHeader, dgvAltRow);
        }

        private static void ApplyThemeToControls(Control.ControlCollection controls, string theme,
            Color back, Color fore, Color controlBack, Color border, Color dgvHeader, Color dgvAltRow)
        {
            foreach (Control ctrl in controls)
            {
                switch (ctrl)
                {
                    case Button btn:
                        btn.BackColor = controlBack;
                        btn.ForeColor = fore;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = border;
                        btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(controlBack, 0.1f);
                        break;

                    case TextBox txt:
                        if (txt.FindForm()?.Name == "LoginForm")
                        {
                            if (theme == "Koyu")
                            {
                                txt.BackColor = Color.FromArgb(30, 30, 30);
                                txt.ForeColor = Color.WhiteSmoke;
                            }
                            else if (theme == "Açık")
                            {
                                txt.BackColor = Color.WhiteSmoke;
                                txt.ForeColor = Color.Black;
                            }
                            else
                            {
                                txt.BackColor = Color.FromArgb(230, 252, 222);
                                txt.ForeColor = Color.FromArgb(16, 50, 100);
                            }
                            txt.BorderStyle = BorderStyle.None;
                        }
                        else
                        {
                            txt.BackColor = controlBack;
                            txt.ForeColor = fore;
                            txt.BorderStyle = BorderStyle.FixedSingle;
                        }
                        break;

                    case LinkLabel linkLabel:
                        if (linkLabel.FindForm()?.Name == "LoginForm")
                        {
                            if (theme == "Koyu")
                            {
                                linkLabel.LinkColor = Color.FromArgb(76, 166, 166);
                            }
                        }
                        break;

                    case Panel panel:
                        if (panel.FindForm()?.Name == "LoginForm" && theme == "Koyu")
                            panel.BackColor = Color.FromArgb(76, 166, 166);
                        break;

                    case ComboBox cmb:
                        cmb.BackColor = controlBack;
                        cmb.ForeColor = fore;
                        break;

                    case Label lbl:
                        lbl.ForeColor = fore;
                        break;

                    case CheckBox chk:
                        chk.ForeColor = fore;
                        break;

                    case GroupBox gb:
                        gb.ForeColor = fore;
                        gb.BackColor = back;
                        break;

                    case TabControl tab:
                        tab.BackColor = back;
                        tab.ForeColor = fore;

                        foreach (TabPage page in tab.TabPages)
                        {
                            if (tab.FindForm() != null)
                                page.BackColor = tab.FindForm().BackColor;
                            page.ForeColor = fore;
                        }
                        break;

                    case DataGridView dgv:
                        dgv.BackgroundColor = back;
                        dgv.BorderStyle = BorderStyle.None;
                        dgv.GridColor = border;

                        dgv.ColumnHeadersDefaultCellStyle.BackColor = dgvHeader;
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = fore;

                        if (theme == "Açık")
                        {
                            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 250);
                            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
                        }
                        else if (string.IsNullOrEmpty(theme) || theme == "Sistem Varsayılanı")
                        {
                            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(109, 242, 191);
                            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Pink;
                        }
                        else
                        {
                            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = ControlPaint.Dark(dgvHeader);
                            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
                        }

                        dgv.DefaultCellStyle.BackColor = controlBack;
                        dgv.DefaultCellStyle.ForeColor = fore;
                        dgv.DefaultCellStyle.SelectionBackColor = ControlPaint.Dark(controlBack);
                        dgv.DefaultCellStyle.SelectionForeColor = Color.White;

                        dgv.AlternatingRowsDefaultCellStyle.BackColor = dgvAltRow;
                        dgv.AlternatingRowsDefaultCellStyle.ForeColor = fore;
                        dgv.EnableHeadersVisualStyles = false;
                        break;
                }

                if (ctrl.HasChildren)
                    ApplyThemeToControls(ctrl.Controls, theme, back, fore, controlBack, border, dgvHeader, dgvAltRow);
            }
        }

        private static void UpdateLogo(Form form, string theme)
        {
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is PictureBox pic && pic.Name == "logoPictureBox")
                {
                    if (theme == "Koyu")
                        pic.Image = Properties.Resources.WareHouseManagamentSystemBlackTheme;
                    else if (theme == "Açık")
                        pic.Image = Properties.Resources.WareHouseManagamentSystemWhiteTheme;
                    else
                        pic.Image = Properties.Resources.WareHouseManagamentSystem;
                }

                if (ctrl.HasChildren)
                    UpdateLogoRecursive(ctrl.Controls, theme);
            }
        }

        private static void UpdateLogoRecursive(Control.ControlCollection controls, string theme)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is PictureBox pic && pic.Name == "logoPictureBox")
                {
                    if (theme == "Koyu")
                        pic.Image = Properties.Resources.WareHouseManagamentSystemBlackTheme;
                    else if (theme == "Açık")
                        pic.Image = Properties.Resources.WareHouseManagamentSystemWhiteTheme;
                    else
                        pic.Image = Properties.Resources.WareHouseManagamentSystem;
                }

                if (ctrl.HasChildren)
                    UpdateLogoRecursive(ctrl.Controls, theme);
            }
        }

        public static void ChangeTheme(string newTheme, Form form)
        {
            if (string.IsNullOrEmpty(newTheme))
                newTheme = "Sistem Varsayılanı";

            Properties.userSettings.Default.Theme = newTheme;
            Properties.userSettings.Default.Save();

            ApplyTheme(form, newTheme);
            ThemeChanged?.Invoke(newTheme);
        }
    }
}
