using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;

namespace DMS
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginPanel_Load(object sender, EventArgs e)
        {
            VersionChecker.CheckVersionFromDatabase();
            userNameandPasswordCheck();
            autoLogin();
        }
        private void autoLogin()
        {
            try
            {
                bool autoLogin = Properties.userSettings.Default.AutoLogin;
                if (autoLogin)
                {
                    bool keepSession = Properties.userSettings.Default.KeepSession;
                    string savedUsername = Properties.userSettings.Default.username;
                    string savedPassword = Properties.userSettings.Default.password;

                    txtUsername.Text = savedUsername;
                    txtPassword.Text = savedPassword;

                    if (autoLogin &&
                        keepSession &&
                        !string.IsNullOrEmpty(savedUsername) &&
                        !string.IsNullOrEmpty(savedPassword))
                    {
                        Task.Delay(500).ContinueWith(_ =>
                        {
                            this.Invoke((MethodInvoker)(() =>
                            {
                                btnLogin.PerformClick();
                            }));
                        });
                    }
                    else
                    {
                        LogHelper.AddLog(null, "Otomatik Giriş Atlandı",
                            "AutoLogin aktif değil veya kullanıcı bilgileri eksik olduğu için giriş yapılmadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Otomatik giriş kontrol edilirken hata oluştu:\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogHelper.AddLog(null, "Otomatik Giriş Hatası", ex.Message);
            }
        }
        private void closeLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimanizeLabel_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Geçerli kullanıcı adı ve/veya Parolanızı giriniz.", "Warehouse Managament System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.AddLog(null, "Boş Giriş", "Kullanıcı adı ve parola alanı boş bırakıldı.");
                return;
            }
            else if (txtUsername.Text == "Kullanıcı adı yada e-posta adresinizi giriniz" && txtPassword.Text == "Parolanızı giriniz")
            {
                MessageBox.Show("Geçerli kullanıcı adı ve/veya Parolanızı giriniz.", "Warehouse Managament System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.AddLog(null, "Varsayılan Giriş", "Varsayılan kullanıcı adı ve parola ile giriş denemesi.");
                return;
            }
            string sql = "SELECT * FROM Kullanicilar WHERE KullaniciAdi=@k AND Sifre=@s";
            SqlParameter[] prms = {
            new SqlParameter("@k", txtUsername.Text.Trim()),
            new SqlParameter("@s", txtPassword.Text.Trim())
            };
            using (SqlDataReader reader = Database.ExecuteReader(sql, prms))
            {
                if (reader.Read())
                {
                    UserSession.KullaniciID = Convert.ToInt32(reader["KullaniciID"]);
                    UserSession.KullaniciAdi = reader["KullaniciAdi"].ToString();
                    UserSession.Sifre = reader["Sifre"].ToString();
                    UserSession.AdSoyad = reader["AdSoyad"].ToString();
                    UserSession.Eposta = reader["Eposta"].ToString();
                    UserSession.Telefon = reader["Telefon"].ToString();
                    UserSession.Departman = reader["Departman"].ToString();
                    UserSession.YetkiSeviyesi = Convert.ToInt32(reader["YetkiSeviyesi"]);
                    UserSession.KayitTarihi = Convert.ToDateTime(reader["KayitTarihi"]);
                    UserSession.Aktif = Convert.ToBoolean(reader["Aktif"]);
                    MessageBox.Show("Giriş başarılı.", "Warehouse Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogHelper.AddLog(UserSession.KullaniciID, "Giriş Başarılı", $"Kullanıcı {UserSession.KullaniciAdi} başarılı şekilde giriş yaptı.");
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Warehouse Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogHelper.AddLog(null, "Giriş Başarısız", $"Başarısız giriş denemesi. Kullanıcı Adı: {txtUsername.Text.Trim()}");
                }
            }

        }
        private void userNameandPasswordCheck()
        {
            if (Properties.userSettings.Default.KeepSession)
            {
                txtUsername.Text = Properties.userSettings.Default.username;
                txtPassword.Text = Properties.userSettings.Default.password;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void userNameTxtBox_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            { txtUsername.Text = "Kullanıcı adı yada e-posta adresinizi giriniz"; }
        }

        private void userNameTxtBox_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Kullanıcı adı yada e-posta adresinizi giriniz")
            { txtUsername.Text = ""; }
        }

        private void passwordTxtBox_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            { txtPassword.Text = "Parolanızı giriniz"; txtPassword.UseSystemPasswordChar = false; }
        }

        private void passwordTxtBox_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Parolanızı giriniz")
            { txtPassword.Text = ""; txtPassword.UseSystemPasswordChar = true; }
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

        private void loginPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown += new MouseEventHandler(Form_MouseDown); 
        }

        private void logoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            logoPictureBox.MouseDown += new MouseEventHandler(Form_MouseDown);
        }
        private void lblShowPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == "Parolanızı giriniz")
                {
                    txtPassword.UseSystemPasswordChar = false;
                    lblShowPassword.Text = "🙈";
                    return;
                }
                if (txtPassword.UseSystemPasswordChar)
                {
                    txtPassword.UseSystemPasswordChar = false;
                    lblShowPassword.Text = "🐵"; 
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true;
                    lblShowPassword.Text = "🙈";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Şifre göster/gizle işlemi sırasında hata oluştu:\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
