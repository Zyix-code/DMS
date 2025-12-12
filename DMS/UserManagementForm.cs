using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS
{
    public partial class UserManagementForm : BaseForm
    {
        public UserManagementForm()
        {
            InitializeComponent();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
            LoadUserPanel();
            txtUserCurrentPassword.UseSystemPasswordChar = true;
        }
        private bool IsPasswordStrong(string password)
        {
            if (password.Length < 8) return false;
            if (!password.Any(char.IsDigit)) return false;
            if (!password.Any(char.IsUpper)) return false;
            return true;
        }

        private void LoadUserPanel()
        {
            label1.Location = new Point(12, 434);
            logoPictureBox.Location = new Point(0, y: 0);   
            closeLabel.Location = new Point(997, 9);
            minimanizeLabel.Location = new Point(976, 9);
            btnMainMenu.Location = new Point(813, 462);
            btnLogout.Location = new Point(924, 462);
            usersProfilePage.Size = new Size(454, 406);
            this.Size = new Size(1041, 508);
        }
        private void RefreshAllUsers()
        {
            string query = "SELECT KullaniciID, KullaniciAdi, AdSoyad, Eposta, Sifre, Telefon, Departman, YetkiSeviyesi FROM Kullanicilar";
            DataTable dt = Database.ExecuteQuery(query);
            dgvAllUsers.DataSource = dt;

            if (dgvAllUsers.Columns.Contains("KullaniciID"))
                dgvAllUsers.Columns["KullaniciID"].Visible = false;

            dgvAllUsers.ReadOnly = true;
            dgvAllUsers.AllowUserToAddRows = false;
            dgvAllUsers.AllowUserToDeleteRows = false;
            dgvAllUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllUsers.MultiSelect = false;
            dgvAllUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAllUsers.Columns["KullaniciAdi"].HeaderText = "Kullanıcı Adı";
            dgvAllUsers.Columns["AdSoyad"].HeaderText = "Ad Soyad";
            dgvAllUsers.Columns["Eposta"].HeaderText = "E-Posta";
            dgvAllUsers.Columns["Sifre"].HeaderText = "Şifre";
            dgvAllUsers.Columns["Telefon"].HeaderText = "Telefon";
            dgvAllUsers.Columns["Departman"].HeaderText = "Departman";
            dgvAllUsers.Columns["YetkiSeviyesi"].HeaderText = "Yetki Seviyesi";

           dgvAllUsers.CellFormatting += DgvAllUsers_CellFormatting;
        }
        private void DgvAllUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAllUsers.Columns[e.ColumnIndex].Name == "Sifre" && e.Value != null)
            {
                string value = e.Value.ToString();
                e.Value = new string('*', value.Length);
                e.FormattingApplied = true;
            }
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == allUsersProfilePage && UserSession.YetkiSeviyesi < 4)
            {
                LogHelper.AddLog(
                    UserSession.KullaniciID,
                    "Yetkisiz İşlem",
                    $"{UserSession.KullaniciAdi} 'Tüm Kullanıcılar' sekmesine yetkisiz erişim girişiminde bulundu."
                );

                MessageBox.Show(
                    "Bu alana erişim yetkiniz bulunmamaktadır.",
                    "Yetkisiz İşlem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                e.Cancel = true;
                return;
            }
            if (e.TabPage == allUsersProfilePage)
            {
                label1.Location = new Point(86, 590);
                logoPictureBox.Location = new Point(10, 84);
                closeLabel.Location = new Point(1452, 9);
                minimanizeLabel.Location = new Point(1431, 9);
                btnMainMenu.Location = new Point(1216, 728);
                btnLogout.Location = new Point(1327, 728);
                usersProfilePage.Size = new Size(909, 710);
                this.Size = new Size(1492, 771);
                RefreshAllUsers();
            }
            else if (e.TabPage == userProfilePage)
            {
                label1.Location = new Point(12, 434);
                logoPictureBox.Location = new Point(0, y: 0);
                closeLabel.Location = new Point(997, 9);
                minimanizeLabel.Location = new Point(976, 9);
                btnMainMenu.Location = new Point(813, 462);
                btnLogout.Location = new Point(924, 462);
                usersProfilePage.Size = new Size(454, 406);
                UserManagementForm userManagementForm = new UserManagementForm();
                this.Size = new Size(1041, 508);
            }
        }
        private void LoadUserProfile()
        {
            string query = @"SELECT KullaniciAdi, AdSoyad, Eposta, Telefon, Departman, YetkiSeviyesi, KayitTarihi
                     FROM Kullanicilar WHERE KullaniciID = @KullaniciID";

            SqlParameter[] parameters = { new SqlParameter("@KullaniciID", UserSession.KullaniciID) };
            DataTable dt = Database.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];

            txtProfileUsername.Text = row["KullaniciAdi"].ToString();
            txtProfileFullName.Text = row["AdSoyad"].ToString();
            txtProfileEmail.Text = row["Eposta"].ToString();
            txtProfilePhone.Text = row["Telefon"].ToString();
            txtProfileDepartment.Text = row["Departman"].ToString();
            txtProfileAuthorityLevel.Text = row["YetkiSeviyesi"].ToString();
            txtProfileRegisterDate.Text = Convert.ToDateTime(row["KayitTarihi"]).ToString("dd.MM.yyyy");

           string oldUsername = txtProfileUsername.Text;
           string oldPassword = txtProfileCurrentPassword.Text;
           string oldFullName = txtProfileFullName.Text;
           string oldEmail = txtProfileEmail.Text;
           string oldPhone = txtProfilePhone.Text;
        }
        ToolTip passwordToolTip = new ToolTip();
        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            string newPass = txtProfileNewPassword.Text;

            if (string.IsNullOrEmpty(newPass))
            {
                lblNewPasswordStatus.Visible = false;
                passwordToolTip.SetToolTip(txtProfileNewPassword, "");
            }
            else
            {
                lblNewPasswordStatus.Visible = true;
                if (IsPasswordStrong(newPass))
                {
                    lblNewPasswordStatus.Text = "✓";
                    lblNewPasswordStatus.ForeColor = Color.Green;
                    passwordToolTip.SetToolTip(txtProfileNewPassword, "Şifre güçlü.");
                }
                else
                {
                    lblNewPasswordStatus.Text = "✗";
                    lblNewPasswordStatus.ForeColor = Color.Red;
                    passwordToolTip.SetToolTip(txtProfileNewPassword, "Şifre en az 8 karakter, 1 büyük harf ve 1 rakam içermeli.");
                }
            }

            ValidateConfirmPassword();
        }
        private void ValidateConfirmPassword()
        {
            string newPass = txtProfileNewPassword.Text;
            string confirmPass = txtProfileConfirmNewPassword.Text;

            if (string.IsNullOrEmpty(confirmPass))
            {
                lblConfirmPasswordStatus.Visible = false;
                passwordToolTip.SetToolTip(txtProfileConfirmNewPassword, "");
                return;
            }

            lblConfirmPasswordStatus.Visible = true;

            if (newPass == confirmPass && IsPasswordStrong(newPass))
            {
                lblConfirmPasswordStatus.Text = "✓";
                lblConfirmPasswordStatus.ForeColor = Color.Green;
                passwordToolTip.SetToolTip(txtProfileConfirmNewPassword, "Şifreler eşleşiyor.");
            }
            else
            {
                lblConfirmPasswordStatus.Text = "✗";
                lblConfirmPasswordStatus.ForeColor = Color.Red;
                passwordToolTip.SetToolTip(txtProfileConfirmNewPassword, "Şifreler eşleşmiyor veya şifre güçlü değil.");
            }
        }

        private void txtConfirmNewPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateConfirmPassword();
        }

        private async void btnSaveProfile_Click(object sender, EventArgs e)
        {
            string currentPassInput = txtProfileCurrentPassword.Text.Trim();

            if (string.IsNullOrEmpty(currentPassInput))
            {
                MessageBox.Show("Bilgilerinizi güncellemek için mevcut şifrenizi girmeniz gerekiyor.",
                    "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string queryCurrentUser = "SELECT KullaniciAdi, AdSoyad, Eposta, Telefon, Sifre FROM Kullanicilar WHERE KullaniciID = @id";
            DataTable dtCurrentUser = Database.ExecuteQuery(queryCurrentUser, new SqlParameter[] { new SqlParameter("@id", UserSession.KullaniciID) });

            if (dtCurrentUser.Rows.Count == 0)
            {
                MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow currentUser = dtCurrentUser.Rows[0];
            string dbUsername = currentUser["KullaniciAdi"].ToString();
            string dbFullName = currentUser["AdSoyad"].ToString();
            string dbEmail = currentUser["Eposta"].ToString();
            string dbPhone = currentUser["Telefon"].ToString();
            string dbPassword = currentUser["Sifre"].ToString();

            if (currentPassInput != dbPassword)
            {
                MessageBox.Show("Mevcut şifre yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newUsername = txtProfileUsername.Text.Trim();
            string newFullName = txtProfileFullName.Text.Trim();
            string newEmail = txtProfileEmail.Text.Trim();
            string newPhone = txtProfilePhone.Text.Trim();

            string newPass = txtProfileNewPassword.Text.Trim();
            string confirmPass = txtProfileConfirmNewPassword.Text.Trim();

            if (!string.IsNullOrEmpty(newPass) || !string.IsNullOrEmpty(confirmPass))
            {
                if (newPass != confirmPass)
                {
                    MessageBox.Show("Yeni şifreler eşleşmiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!IsPasswordStrong(newPass))
                {
                    MessageBox.Show("Yeni şifre yeterince güçlü değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (newPass == dbPassword)
                {
                    MessageBox.Show("Yeni şifre mevcut şifreyle aynı olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                newPass = null;
            }

            if (newUsername != dbUsername)
            {
                string queryCheckUsername = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @kadi AND KullaniciID <> @id";
                int count = Convert.ToInt32(Database.ExecuteScalar(queryCheckUsername, new SqlParameter[]
                {
                    new SqlParameter("@kadi", newUsername),
                    new SqlParameter("@id", UserSession.KullaniciID)
                }));

                if (count > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı başka biri tarafından kullanılıyor. Lütfen farklı bir kullanıcı adı seçin.",
                        "Kullanıcı Adı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadUserProfile();
                    return;
                }
            }

            bool isDataChanged = newUsername != dbUsername
                || newFullName != dbFullName
                || newEmail != dbEmail
                || newPhone != dbPhone
                || !string.IsNullOrEmpty(newPass);

            if (!isDataChanged)
            {
                MessageBox.Show("Güncellenecek herhangi bir bilgi bulunamadı. Bilgiler zaten güncel.",
                    "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserProfile();
                return;
            }

            string sql = @"
                UPDATE Kullanicilar
                SET
                    KullaniciAdi = @kadi,
                    AdSoyad = @adsoyad,
                    Eposta = @eposta,
                    Telefon = @telefon,
                    Sifre = CASE WHEN @yeniSifre IS NOT NULL AND @yeniSifre <> '' THEN @yeniSifre ELSE Sifre END
                WHERE KullaniciID = @id
            ";
                SqlParameter[] updateParams = new SqlParameter[]
                {
                    new SqlParameter("@kadi", newUsername),
                    new SqlParameter("@adsoyad", newFullName),
                    new SqlParameter("@eposta", newEmail),
                    new SqlParameter("@telefon", newPhone),
                    new SqlParameter("@yeniSifre", (object)newPass ?? DBNull.Value),
                    new SqlParameter("@id", UserSession.KullaniciID)
                };

            int rows = Database.ExecuteNonQuery(sql, updateParams);

            if (rows > 0)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Profil Güncellendi", "Kullanıcı bilgilerini güncelledi.");
                MessageBox.Show("Bilgiler başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var degisenler = new List<string>();

                if (newUsername != dbUsername)
                    degisenler.Add($"Kullanıcı Adı: {newUsername}");
                if (newFullName != dbFullName)
                    degisenler.Add($"Ad Soyad: {newFullName}");
                if (newEmail != dbEmail)
                    degisenler.Add($"E-posta: {newEmail}");
                if (newPhone != dbPhone)
                    degisenler.Add($"Telefon: {newPhone}");
                if (!string.IsNullOrEmpty(newPass))
                    degisenler.Add("Şifre: Değiştirildi");

                if (degisenler.Count > 0)
                {
                    await EmailHelper.SendTemplateMailAsync(
                        "Profil Güncelleme Bildirimi",
                        $"Merhaba {newFullName}, hesabınızda {DateTime.Now:dd MMMM yyyy HH:mm} tarihinde bazı bilgiler güncellendi.",
                        degisenler,
                        "info",
                        UserSession.KullaniciID
                    );
                }

                LoadUserProfile();
            }
            else
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
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

        private void UserManagementForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        private void logoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            logoPictureBox.MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        private void dgvAllUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAllUsers.SelectedRows.Count == 0) return;

            int userId = Convert.ToInt32(dgvAllUsers.SelectedRows[0].Cells["KullaniciID"].Value);

            string query = "SELECT * FROM Kullanicilar WHERE KullaniciID = @id";
            SqlParameter[] prms = { new SqlParameter("@id", userId) };
            DataTable dt = Database.ExecuteQuery(query, prms);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtUserFullName.Text = row["AdSoyad"].ToString();
                txtUserUsername.Text = row["KullaniciAdi"].ToString();
                txtUserEmail.Text = row["Eposta"].ToString();
                txtUserPhone.Text = row["Telefon"].ToString();
                txtUserCurrentPassword.Text = row["Sifre"].ToString();
                cmbUserDepartment.Text = row["Departman"].ToString();
                cmbUserAuthorityLevel.Text = row["YetkiSeviyesi"].ToString();
            }
            txtUserNewPassword.Clear();
            txtUserConfirmNewPassword.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAllUsers.SelectedRows.Count == 0) return;

            int selectedUserId = Convert.ToInt32(dgvAllUsers.SelectedRows[0].Cells["KullaniciID"].Value);
            string selectedUserName = dgvAllUsers.SelectedRows[0].Cells["KullaniciAdi"].Value.ToString();

            if (selectedUserId == UserSession.KullaniciID)
            {
                MessageBox.Show("Kendi hesabınızı silemezsiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"'{selectedUserName}' kullanıcısını silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string delete = "DELETE FROM Kullanicilar WHERE KullaniciID = @id";
                SqlParameter[] parameters = { new SqlParameter("@id", selectedUserId) };
                int rows = Database.ExecuteNonQuery(delete, parameters);

                if (rows > 0)
                {
                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogHelper.AddLog(UserSession.KullaniciID, "Kullanıcı Silme", $"Admin {UserSession.KullaniciAdi}, '{selectedUserName}' kullanıcısını sildi.");
                    RefreshAllUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAllUsers.SelectedRows.Count == 0) return;

            int selectedUserId = Convert.ToInt32(dgvAllUsers.SelectedRows[0].Cells["KullaniciID"].Value);

            string newUsername = txtUserUsername.Text.Trim();
            string newFullName = txtUserFullName.Text.Trim();
            string newEmail = txtUserEmail.Text.Trim();
            string newPhone = txtUserPhone.Text.Trim();
            string newPass = txtUserNewPassword.Text.Trim();
            string confirmPass = txtUserConfirmNewPassword.Text.Trim();

            int newAuthority = Convert.ToInt32(cmbUserAuthorityLevel.Text.Trim());
            string newDepartment = cmbUserDepartment.Text.Trim();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newFullName) || string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("Kullanıcı Adı, Ad Soyad ve E-posta boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string checkUsername = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@username AND KullaniciID<>@id";
            if ((int)Database.ExecuteScalar(checkUsername, new SqlParameter[]
            {
                new SqlParameter("@username", newUsername),
                new SqlParameter("@id", selectedUserId)
            }) > 0)
            {
                MessageBox.Show("Bu kullanıcı adı başkası tarafından kullanılıyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string checkEmail = "SELECT COUNT(*) FROM Kullanicilar WHERE Eposta=@email AND KullaniciID<>@id";
            if ((int)Database.ExecuteScalar(checkEmail, new SqlParameter[]
            {
                new SqlParameter("@email", newEmail),
                new SqlParameter("@id", selectedUserId)
            }) > 0)
            {
                MessageBox.Show("Bu e-posta başkası tarafından kullanılıyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string checkPhone = "SELECT COUNT(*) FROM Kullanicilar WHERE Telefon=@phone AND KullaniciID<>@id";
            if ((int)Database.ExecuteScalar(checkPhone, new SqlParameter[]
            {
                new SqlParameter("@phone", newPhone),
                new SqlParameter("@id", selectedUserId)
            }) > 0)
            {
                MessageBox.Show("Bu telefon numarası başkası tarafından kullanılıyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string oldPass = dgvAllUsers.SelectedRows[0].Cells["Sifre"].Value.ToString();
            if (!string.IsNullOrEmpty(newPass) || !string.IsNullOrEmpty(confirmPass))
            {
                if (newPass != confirmPass)
                {
                    MessageBox.Show("Yeni şifreler eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (newPass == oldPass)
                {
                    MessageBox.Show("Yeni şifre mevcut şifre ile aynı olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsPasswordStrong(newPass))
                {
                    MessageBox.Show("Yeni şifre yeterince güçlü değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataGridViewRow selectedRow = dgvAllUsers.SelectedRows[0];
            bool isSame = newUsername == selectedRow.Cells["KullaniciAdi"].Value.ToString() &&
                          newFullName == selectedRow.Cells["AdSoyad"].Value.ToString() &&
                          newEmail == selectedRow.Cells["Eposta"].Value.ToString() &&
                          newPhone == selectedRow.Cells["Telefon"].Value.ToString() &&
                          newDepartment == selectedRow.Cells["Departman"].Value.ToString() &&
                          newAuthority == Convert.ToInt32(selectedRow.Cells["YetkiSeviyesi"].Value) &&
                          (string.IsNullOrEmpty(newPass) || newPass == oldPass);

            if (isSame)
            {
                MessageBox.Show("Güncelleme yapmak için bilgilerde değişiklik yapmalısınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = @"
            UPDATE Kullanicilar
            SET KullaniciAdi=@username,
                AdSoyad=@fullName,
                Eposta=@email,
                Telefon=@phone,
                Departman=@department,
                YetkiSeviyesi=@authority,
                Sifre = CASE WHEN @newPass IS NOT NULL AND @newPass <> '' THEN @newPass ELSE Sifre END
            WHERE KullaniciID=@id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", newUsername),
                new SqlParameter("@fullName", newFullName),
                new SqlParameter("@email", newEmail),
                new SqlParameter("@phone", newPhone),
                new SqlParameter("@department", newDepartment),
                new SqlParameter("@authority", newAuthority),
                new SqlParameter("@newPass", string.IsNullOrEmpty(newPass) ? (object)DBNull.Value : newPass),
                new SqlParameter("@id", selectedUserId)
            };

            int rows = Database.ExecuteNonQuery(sql, parameters);

            if (rows > 0)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Kullanıcı Güncellendi", $"Admin {UserSession.KullaniciAdi}, '{newUsername}' kullanıcısını güncelledi.");
                MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAllUsers();
            }
            else
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu veya bilgiler zaten güncel.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserNewPassword_TextChanged(object sender, EventArgs e)
        {
            string newPass = txtUserNewPassword.Text;

            if (string.IsNullOrEmpty(newPass))
            {
                lblUserNewPasswordStatus.Visible = false;
                passwordToolTip.SetToolTip(txtUserNewPassword, "");
            }
            else
            {
                lblUserNewPasswordStatus.Visible = true;
                if (IsPasswordStrong(newPass))
                {
                    lblUserNewPasswordStatus.Text = "✓";
                    lblUserNewPasswordStatus.ForeColor = Color.Green;
                    passwordToolTip.SetToolTip(txtUserNewPassword, "Şifre güçlü.");
                }
                else
                {
                    lblUserNewPasswordStatus.Text = "✗";
                    lblUserNewPasswordStatus.ForeColor = Color.Red;
                    passwordToolTip.SetToolTip(txtUserNewPassword, "Şifre en az 8 karakter, 1 büyük harf ve 1 rakam içermeli.");
                }
            }

            ValidateUserConfirmPassword();
        }

        private void txtUserConfirmNewPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateUserConfirmPassword();

        }
        private void ValidateUserConfirmPassword()
        {
            string newPass = txtUserNewPassword.Text;
            string confirmPass = txtUserConfirmNewPassword.Text;

            if (string.IsNullOrEmpty(confirmPass))
            {
                lblUserConfirmPasswordStatus.Visible = false;
                passwordToolTip.SetToolTip(txtUserConfirmNewPassword, "");
                return;
            }

            lblUserConfirmPasswordStatus.Visible = true;

            if (newPass == confirmPass && IsPasswordStrong(newPass))
            {
                lblUserConfirmPasswordStatus.Text = "✓";
                lblUserConfirmPasswordStatus.ForeColor = Color.Green;
                passwordToolTip.SetToolTip(txtUserConfirmNewPassword, "Şifreler eşleşiyor.");
            }
            else
            {
                lblUserConfirmPasswordStatus.Text = "✗";
                lblUserConfirmPasswordStatus.ForeColor = Color.Red;
                passwordToolTip.SetToolTip(txtUserConfirmNewPassword, "Şifreler eşleşmiyor veya şifre güçlü değil.");
            }
        }

        private void lblShowPassword_Click(object sender, EventArgs e)
        {
            ToolTip showPasswordToolTip = new ToolTip();

            if (dgvAllUsers.SelectedRows.Count == 0)
            {
                showPasswordToolTip.SetToolTip(lblShowPassword, "İlk önce bir kullanıcı seçiniz!");
                return;
            }
            else
            {
                showPasswordToolTip.SetToolTip(lblShowPassword, "Şifreyi gizler veya gösterir.");
                if (txtUserCurrentPassword.UseSystemPasswordChar)
                {
                    txtUserCurrentPassword.UseSystemPasswordChar = false;
                    lblShowPassword.Text = "🐵";
                }
                else
                {
                    txtUserCurrentPassword.UseSystemPasswordChar = true;
                    lblShowPassword.Text = "🙈";
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string usernameOrEmail = string.IsNullOrWhiteSpace(txtUsernameOrEmail.Text) ? null : txtUsernameOrEmail.Text.Trim();
                string fullName = string.IsNullOrWhiteSpace(txtFullName.Text) ? null : txtFullName.Text.Trim();
                string departman = string.IsNullOrWhiteSpace(cmbDepartment.Text) ? null : cmbDepartment.Text.Trim();
                string yetki = string.IsNullOrWhiteSpace(cmbAuthorityLevel.Text) ? null : cmbAuthorityLevel.Text.Trim();

                string query = @"
                SELECT 
                    KullaniciID,
                    KullaniciAdi,
                    AdSoyad,
                    Eposta,
                    Departman,
                    YetkiSeviyesi,
                    KayitTarihi
                FROM Kullanicilar
                WHERE
                    (@usernameOrEmail IS NULL OR (KullaniciAdi LIKE '%' + @usernameOrEmail + '%' OR Eposta LIKE '%' + @usernameOrEmail + '%'))
                    AND (@fullName IS NULL OR AdSoyad LIKE '%' + @fullName + '%')
                    AND (@departman IS NULL OR Departman = @departman)
                    AND (@yetki IS NULL OR YetkiSeviyesi = @yetki)
                ORDER BY KayitTarihi DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@usernameOrEmail", (object)usernameOrEmail ?? DBNull.Value),
            new SqlParameter("@fullName", (object)fullName ?? DBNull.Value),
            new SqlParameter("@departman", (object)departman ?? DBNull.Value),
            new SqlParameter("@yetki", (object)yetki ?? DBNull.Value)
                };

                DataTable dt = Database.ExecuteQuery(query, parameters);
                dgvAllUsers.DataSource = dt;

                if (dgvAllUsers.Columns.Contains("KullaniciID"))
                    dgvAllUsers.Columns["KullaniciID"].Visible = false;

                dgvAllUsers.ReadOnly = true;
                dgvAllUsers.AllowUserToAddRows = false;
                dgvAllUsers.AllowUserToDeleteRows = false;
                dgvAllUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvAllUsers.MultiSelect = false;
                dgvAllUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Aramanıza uygun kullanıcı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshAllUsers();
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Kullanıcı Arama Hatası", ex.Message);
                MessageBox.Show("Kullanıcılar aranırken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsernameOrEmail.Clear();
            txtFullName.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbAuthorityLevel.SelectedIndex = -1;
        }
    }
}
