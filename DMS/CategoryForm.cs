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
    public partial class CategoryForm : BaseForm
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void LoadCategories()
        {
            string query = "SELECT CinsID, CinsAdi FROM Cinsler ORDER BY CinsID";
            DataTable dt = Database.ExecuteQuery(query);

            lstCategories.DisplayMember = "CinsAdi";
            lstCategories.ValueMember = "CinsID";
            lstCategories.DataSource = dt;
        }
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            VersionChecker.CheckVersionFromDatabase();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                string categoryName = txtCategoryName.Text.Trim();

                string checkQuery = "SELECT COUNT(*) FROM Cinsler WHERE LOWER(CinsAdi) = LOWER(@name)";
                SqlParameter[] checkParams = {
                    new SqlParameter("@name", categoryName)
                };

                try
                {
                    int existing = Convert.ToInt32(Database.ExecuteScalar(checkQuery, checkParams));
                    if (existing > 0)
                    {
                        MessageBox.Show("Bu cins zaten veritabanında mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string insertQuery = "INSERT INTO Cinsler (CinsAdi) VALUES (@name)";
                    SqlParameter[] insertParams = {
                        new SqlParameter("@name", categoryName)
                    };

                    Database.ExecuteNonQuery(insertQuery, insertParams);
                    LogHelper.AddLog(UserSession.KullaniciID, "Cins Ekleme", $"Yeni cins eklendi: {categoryName}");

                    LoadCategories();
                    txtCategoryName.Clear();

                    MessageBox.Show("Cins başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        LogHelper.AddLog(UserSession.KullaniciID, "Cins Ekleme Hatası", $"Hata Mesajı: {ex.Message}");
                        MessageBox.Show("Bu cins zaten veritabanında mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        LogHelper.AddLog(UserSession.KullaniciID, "Cins Ekleme Hatası", $"Hata Mesajı: {ex.Message}");
                        MessageBox.Show("ciCinsns eklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.AddLog(UserSession.KullaniciID, "Cins Ekleme Hatası", $"Hata Mesajı: {ex.Message}");
                    MessageBox.Show("Cins eklenirken beklenmeyen bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir cins adı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem != null && !string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                string newCategoryName = txtCategoryName.Text.Trim();

                if (int.TryParse(lstCategories.SelectedValue?.ToString(), out int CinsID))
                {
                    try
                    {
                        string checkQuery = "SELECT COUNT(*) FROM Cinsler WHERE LOWER(CinsAdi) = LOWER(@name)";
                        SqlParameter[] checkParams = {
                            new SqlParameter("@name", newCategoryName),
                        };

                        int existing = Convert.ToInt32(Database.ExecuteScalar(checkQuery, checkParams));
                        if (existing > 0)
                        {
                            MessageBox.Show("Bu cins zaten veritabanında mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string updateQuery = "UPDATE Cinsler SET CinsAdi = @name WHERE CinsID = @id";
                        SqlParameter[] updateParams = {
                            new SqlParameter("@name", newCategoryName),
                            new SqlParameter("@id", CinsID)
                        };

                        Database.ExecuteNonQuery(updateQuery, updateParams);
                        string oldCategoryName = lstCategories.Text.Trim();
                        LogHelper.AddLog(UserSession.KullaniciID, "Cins Güncelleme", $"ID: {CinsID}, eski ad: {oldCategoryName}, yeni ad: {newCategoryName}");

                        LoadCategories();
                        txtCategoryName.Clear();

                        MessageBox.Show("Cins güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.AddLog(UserSession.KullaniciID, "Cins Güncelleme Hatası", $"Hata Mesajı: {ex.Message}");
                        MessageBox.Show("Cins güncellenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seçili cins'in ID'si okunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir cins seçin ve geçerli bir ad girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem != null)
            {
                int CinsID = Convert.ToInt32(lstCategories.SelectedValue);
                string cinsAdı = lstCategories.Text;

                DialogResult result = MessageBox.Show(
                    $"{cinsAdı} markasını silmek istiyor musunuz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM Cinsler WHERE CinsID = @id";
                        SqlParameter[] prms = {
                            new SqlParameter("@id", CinsID)
                        };

                        int affectedRows = Database.ExecuteNonQuery(query, prms);

                        if (affectedRows > 0)
                        {
                            LogHelper.AddLog(UserSession.KullaniciID, "Marka Silme", $"Marka silindi: ID={CinsID}, Ad={cinsAdı}");
                            LoadCategories();
                            txtCategoryName.Clear();
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

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();  
            loginForm.Show();
            Close();
        }

        private void minimanizeLabel_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem != null)
            {
                txtCategoryName.Text = lstCategories.Text;
            }
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

        private void CategoryForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        private void logoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            logoPictureBox.MouseDown += new MouseEventHandler(Form_MouseDown);
        }
    }
}
