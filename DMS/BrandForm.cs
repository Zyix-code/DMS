using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS
{
    public partial class BrandForm : BaseForm
    {
        public BrandForm()
        {
            InitializeComponent();
        }
        private void LoadBrands()
        {
            string query = "SELECT MarkaID, MarkaAdi FROM Markalar ORDER BY MarkaAdi";
            DataTable dt = Database.ExecuteQuery(query);

            lstBrands.DisplayMember = "MarkaAdi";
            lstBrands.ValueMember = "MarkaID";
            lstBrands.DataSource = dt;
        }

        private void BrandModelForm_Load(object sender, EventArgs e)
        {
            VersionChecker.CheckVersionFromDatabase();
            LoadBrands();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBrandName.Text))
            {
                string brandName = txtBrandName.Text.Trim();

                string checkQuery = "SELECT COUNT(*) FROM Markalar WHERE LOWER(MarkaAdi) = LOWER(@name)";
                SqlParameter[] checkParams = {
                    new SqlParameter("@name", brandName)
                };

                try
                {
                    int existing = Convert.ToInt32(Database.ExecuteScalar(checkQuery, checkParams));
                    if (existing > 0)
                    {
                        MessageBox.Show("Bu marka zaten veritabanında mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string insertQuery = "INSERT INTO Markalar (MarkaAdi) VALUES (@name)";
                    SqlParameter[] insertParams = {
                        new SqlParameter("@name", brandName)
                    };

                    Database.ExecuteNonQuery(insertQuery, insertParams);
                    LogHelper.AddLog(UserSession.KullaniciID, "Marka Ekleme", $"Yeni marka eklendi: {brandName}");

                    LoadBrands();
                    txtBrandName.Clear();

                    MessageBox.Show("Marka başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        LogHelper.AddLog(UserSession.KullaniciID, "Marka Ekleme Hatası", $"Hata Mesajı: {ex.Message}");
                        MessageBox.Show("Bu marka zaten veritabanında mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        LogHelper.AddLog(UserSession.KullaniciID, "Marka Ekleme Hatası", $"Hata Mesajı: {ex.Message}");
                        MessageBox.Show("Marka eklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.AddLog(UserSession.KullaniciID, "Marka Ekleme Hatası", $"Hata Mesajı: {ex.Message}");
                    MessageBox.Show("Marka eklenirken beklenmeyen bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir marka adı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstBrands.SelectedItem != null && !string.IsNullOrWhiteSpace(txtBrandName.Text))
            {
                string newBrandName = txtBrandName.Text.Trim();

                if (int.TryParse(lstBrands.SelectedValue?.ToString(), out int markaId))
                {
                    try
                    {
                        string checkQuery = "SELECT COUNT(*) FROM Markalar WHERE LOWER(MarkaAdi) = LOWER(@name)";
                        SqlParameter[] checkParams = {
                            new SqlParameter("@name", newBrandName),
                        };

                        int existing = Convert.ToInt32(Database.ExecuteScalar(checkQuery, checkParams));
                        if (existing > 0)
                        {
                            MessageBox.Show("Bu marka zaten veritabanında mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string updateQuery = "UPDATE Markalar SET MarkaAdi = @name WHERE MarkaID = @id";
                        SqlParameter[] updateParams = {
                            new SqlParameter("@name", newBrandName),
                            new SqlParameter("@id", markaId)
                        };

                        Database.ExecuteNonQuery(updateQuery, updateParams);
                        string oldCBrandsName = lstBrands.Text.Trim();
                        LogHelper.AddLog(UserSession.KullaniciID, "Marka Güncelleme", $"ID: {markaId}, eski ad: {oldCBrandsName}, yeni ad: {newBrandName}");
                        LoadBrands();
                        txtBrandName.Clear();

                        MessageBox.Show("Marka güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.AddLog(UserSession.KullaniciID, "Marka Güncelleme Hatası", $"Hata Mesajı: {ex.Message}");
                        MessageBox.Show("Marka güncellenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seçili markanın ID'si okunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir marka seçin ve geçerli bir ad girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBrands.SelectedItem != null)
            {
                int markaId = Convert.ToInt32(lstBrands.SelectedValue);
                string markaAdi = lstBrands.Text;

                DialogResult result = MessageBox.Show(
                    $"{markaAdi} markasını silmek istiyor musunuz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM Markalar WHERE MarkaID = @id";
                        SqlParameter[] prms = {
                            new SqlParameter("@id", markaId)
                        };

                        int affectedRows = Database.ExecuteNonQuery(query, prms);

                        if (affectedRows > 0)
                        {
                            LogHelper.AddLog(UserSession.KullaniciID, "Marka Silme", $"Marka silindi: ID={markaId}, Ad={markaAdi}");
                            LoadBrands();
                            txtBrandName.Clear();
                            MessageBox.Show("Marka başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Marka bulunamadı ya da silinemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547)
                        {
                            LogHelper.AddLog(UserSession.KullaniciID, "Marka Silme Hatası", $"Hata Mesajı: {ex.Message}");
                            MessageBox.Show("Bu marka başka tablolarla ilişkili olduğu için silinemez.", "İlişkili Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            LogHelper.AddLog(UserSession.KullaniciID, "Marka Silme Hatası", $"Hata Mesajı: {ex.Message}");
                            MessageBox.Show("Veritabanı hatası:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.AddLog(UserSession.KullaniciID, "Marka Silme Hatası", $"Hata Mesajı: {ex.Message}");
                        MessageBox.Show("Silme sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir marka seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBrands.SelectedItem != null)
            {
                txtBrandName.Text = lstBrands.Text;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Close();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Close();
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
        private void BrandForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        private void logoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            logoPictureBox.MouseDown += new MouseEventHandler(Form_MouseDown);
        }
    }
}
