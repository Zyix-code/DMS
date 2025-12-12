using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS
{
    public partial class EditProductMovementForm : BaseForm
    {
        private int HareketID;

        public EditProductMovementForm(
    int hareketId, string siparisNo, string aliciAdi, string firma, string pazaryeri,
    string marka, string model, string cins, string girisCikis, int adet, string aciklama)
        {
            InitializeComponent();

            txtOrderNo.Text = siparisNo;
            txtCustomer.Text = aliciAdi;
            cmbCompany.Text = firma;
            cmbMarketplace.Text = pazaryeri;

            txtModel.Text = model;
            cmbTransactionType.Text = girisCikis;
            txtQuantity.Text = adet.ToString();
            txtDescription.Text = aciklama;

            txtOrderNo.ReadOnly = true;
            txtCustomer.ReadOnly = true;
            this.HareketID = hareketId;
            this._marka = marka;
            this._cins = cins;
        }

        private string _marka;
        private string _cins;

        private void EditProductMovementForm_Load(object sender, EventArgs e)
        {
            LoadBrandComboBox();
            LoadCategoryComboBox();

            SetComboBoxSelectedItemByDisplayText(cmbBrand, _marka);
            SetComboBoxSelectedItemByDisplayText(cmbCategory, _cins);
        }

        private void SetComboBoxSelectedItemByDisplayText(ComboBox comboBox, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                comboBox.SelectedIndex = -1;
                return;
            }
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i] is DataRowView row)
                {
                    if (row[comboBox.DisplayMember].ToString().Equals(text, StringComparison.OrdinalIgnoreCase))
                    {
                        comboBox.SelectedIndex = i;
                        return;
                    }
                }
            }
            comboBox.SelectedIndex = -1;
        }

        private void LoadBrandComboBox()
        {
            try
            {
                string query = "SELECT MarkaID, MarkaAdi FROM Markalar ORDER BY MarkaAdi ASC";
                DataTable brandTable = Database.ExecuteQuery(query);
                cmbBrand.DataSource = brandTable;
                cmbBrand.DisplayMember = "MarkaAdi";
                cmbBrand.ValueMember = "MarkaID";
                cmbBrand.SelectedIndex = -1;
                cmbBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Marka sütunu yüklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.AddLog(UserSession.KullaniciID, "Marka Yükleme Hatası", $"Hata: {ex.Message}");
            }
        }

        private void LoadCategoryComboBox()
        {
            try
            {
                string query = "SELECT CinsID, CinsAdi FROM Cinsler ORDER BY CinsAdi ASC";
                DataTable categoryTable = Database.ExecuteQuery(query);
                cmbCategory.DataSource = categoryTable;
                cmbCategory.DisplayMember = "CinsAdi";
                cmbCategory.ValueMember = "CinsID";
                cmbCategory.SelectedIndex = -1;
                cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cins (kategori) sütunu yüklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.AddLog(UserSession.KullaniciID, "Kategori Yükleme Hatası", $"Hata: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int brandId = Convert.ToInt32(cmbBrand.SelectedValue);
            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            string model = txtModel.Text.Trim();
            string transactionType = cmbTransactionType.Text.Trim();
            int quantity = int.Parse(txtQuantity.Text.Trim());
            string description = txtDescription.Text.Trim();

            try
            {
                if (cmbBrand.SelectedIndex < 0)
                {
                    MessageBox.Show("Lütfen bir marka seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbCategory.SelectedIndex < 0)
                {
                    MessageBox.Show("Lütfen bir cins seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtQuantity.Text.Trim(), out int adet) || adet <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir adet girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string checkQueryUH = @"
                    SELECT MarkaID, Model, CinsID, GirisCikis, Adet, Aciklama
                    FROM UrunHareketleri
                    WHERE HareketID = @hareketId";

                DataTable dtUH = Database.ExecuteQuery(
                    checkQueryUH,
                    new SqlParameter[] { new SqlParameter("@hareketId", this.HareketID) }
                );

                string checkQueryS = @"
                    SELECT Firma, PazarYeri
                    FROM Siparisler
                    WHERE SiparisNo = @siparisNo";

                DataTable dtS = Database.ExecuteQuery(
                    checkQueryS,
                    new SqlParameter[] { new SqlParameter("@siparisNo", txtOrderNo.Text.Trim()) }
                );

                if (dtUH.Rows.Count == 0 || dtS.Rows.Count == 0)
                {
                    MessageBox.Show("Güncellenecek kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow rowUH = dtUH.Rows[0];
                DataRow rowS = dtS.Rows[0];

                bool changed =
                    brandId != Convert.ToInt32(rowUH["MarkaID"]) ||
                    model != rowUH["Model"].ToString() ||
                    categoryId != Convert.ToInt32(rowUH["CinsID"]) ||
                    transactionType != rowUH["GirisCikis"].ToString() ||
                    adet != Convert.ToInt32(rowUH["Adet"]) ||
                    description != rowUH[columnName: "Aciklama"].ToString() ||
                    cmbCompany.Text.Trim() != rowS["Firma"].ToString() ||
                    cmbMarketplace.Text.Trim() != rowS["PazarYeri"].ToString();

                if (!changed)
                {
                    MessageBox.Show("Kayıtta herhangi bir değişiklik yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string queryUrunHareketleri = @"
                    UPDATE UrunHareketleri
                    SET MarkaID = @markaId,
                        Model = @model,
                        CinsID = @cinsId,
                        GirisCikis = @girisCikis,
                        Aciklama = @aciklama,
                        Adet = @adet
                    WHERE HareketID = @hareketId";

                SqlParameter[] parametersUH = new SqlParameter[]
                {
                    new SqlParameter("@markaId", brandId),
                    new SqlParameter("@model", model),
                    new SqlParameter("@cinsId", categoryId),
                    new SqlParameter("@girisCikis", transactionType),
                    new SqlParameter("@adet", adet),
                    new SqlParameter("@aciklama", description),
                    new SqlParameter("@hareketId", this.HareketID)
                };

                int rowsAffectedUH = Database.ExecuteNonQuery(queryUrunHareketleri, parametersUH);

                string querySiparisler = @"
                UPDATE Siparisler
                SET Firma = @firma,
                    PazarYeri = @pazarYeri
                WHERE SiparisNo = @siparisNo";

                SqlParameter[] parametersS = new SqlParameter[]
                {
                    new SqlParameter("@firma", cmbCompany.Text.Trim()),
                    new SqlParameter("@pazarYeri", cmbMarketplace.Text.Trim()),
                    new SqlParameter("@siparisNo", txtOrderNo.Text.Trim())
                };

                int rowsAffectedS = Database.ExecuteNonQuery(querySiparisler, parametersS);

                if (rowsAffectedUH > 0 || rowsAffectedS > 0)
                {
                    string logMessage =
                    "=== Ürün Hareketi Güncelleme ===\n " +
                    $"Hareket ID   : {HareketID}\n /" +
                    $"Sipariş No   : {txtOrderNo.Text}\n /" +
                    $"Alıcı Adı    : {txtCustomer.Text}\n /" +
                    $"Firma        : {cmbCompany.Text}\n /" +
                    $"Pazar Yeri   : {cmbMarketplace.Text}\n\n " +

                    "--- Ürün Bilgileri ---\n " +
                    $"Marka        : {cmbBrand.Text} (ID: {brandId})\n /" +
                    $"Model        : {model}\n /" +
                    $"Cins         : {cmbCategory.Text} (ID: {categoryId})\n /" +
                    $"Giriş/Çıkış  : {transactionType}\n /" +
                    $"Adet         : {quantity}\n /" +
                    $"Açıklama     : {description}\n /"; 

                    LogHelper.AddLog(UserSession.KullaniciID, "Ürün Hareketi Güncellendi", logMessage);
                    MessageBox.Show("Güncelleme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Güncelleme sırasında bir sorun oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogHelper.AddLog(UserSession.KullaniciID, "Ürün Hareketi Güncelleme Hatası",
                        $"HareketID: {this.HareketID} için güncelleme başarısız oldu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.AddLog(UserSession.KullaniciID, "Ürün Hareketi Güncelleme İstisnası", ex.Message);
            }
        }
        private void closeLabel_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void EditProductMovementForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown += new MouseEventHandler(Form_MouseDown);

        }
    }
}
