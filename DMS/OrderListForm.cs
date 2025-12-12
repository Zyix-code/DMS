using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS
{
    public partial class OrderListForm : BaseForm
    {
        public OrderListForm()
        {
            InitializeComponent();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            VersionChecker.CheckVersionFromDatabase();
            LoadOrders();
            LoadBrandComboBox();
            LoadCategoryComboBox();
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
        private void btnHome_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Close();
        }

        private void LoadOrders()
        {
            try
            {
                string query = @"
                    SELECT 
                        S.SiparisID, 
                        S.SiparisNo AS [Sipariş No], 
                        S.AliciAd AS [Alıcı Adı], 
                        S.Firma AS [Firma], 
                        S.Pazaryeri AS [Pazaryeri], 
                        S.Tarih AS [Tarih]
                    FROM 
                        Siparisler S
                    WHERE 
                        (@siparisNo = '' OR S.SiparisNo LIKE '%' + @siparisNo + '%') AND
                        (@aliciAd = '' OR S.AliciAd LIKE '%' + @aliciAd + '%') AND
                        (@firma = '' OR S.Firma = @firma)
                    ORDER BY 
                        S.Tarih DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@siparisNo", txtOrderNo.Text.Trim()),
                    new SqlParameter("@aliciAd", txtCustomer.Text.Trim()),
                    new SqlParameter("@firma", cmbCompany.Text.Trim())
                };

                DataTable dt = Database.ExecuteQuery(query, parameters);
                dgvOrders.DataSource = dt;

                if (dgvOrders.Columns.Contains("SiparisID"))
                    dgvOrders.Columns["SiparisID"].Visible = false;

                dgvOrders.ReadOnly = true;
                dgvOrders.AllowUserToAddRows = false;
                dgvOrders.AllowUserToDeleteRows = false;
                dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvOrders.MultiSelect = false;
                dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Siparişler yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogHelper.AddLog(UserSession.KullaniciID, "Sipariş Yükleme Hatası", ex.Message);
            }
        }
        private void btnRefreshOrders_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }
        private void LoadDetails()
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 0) return;

                int siparisId;
                if (!int.TryParse(dgvOrders.SelectedRows[0].Cells["SiparisID"].Value?.ToString(), out siparisId))
                {
                    MessageBox.Show("Sipariş ID alınamadı.");
                    return;
                }
                string query = @"
            SELECT 
                UH.HareketID,
                M.MarkaAdi AS [Marka], 
                UH.Model AS [Model], 
                C.CinsAdi AS [Cins], 
                UH.GirisCikis AS [Giriş/Çıkış], 
                UH.Adet AS [Adet], 
                UH.Tarih AS [Tarih], 
                UH.Aciklama AS [Açıklama]
            FROM UrunHareketleri UH
            LEFT JOIN Markalar M ON M.MarkaID = UH.MarkaID
            LEFT JOIN Cinsler C ON C.CinsID = UH.CinsID
            WHERE UH.SiparisID = @id
            ORDER BY UH.Tarih ASC";

                SqlParameter[] parameters = { new SqlParameter("@id", siparisId) };

                DataTable dt = Database.ExecuteQuery(query, parameters);
                dgvDetails.DataSource = dt;

                if (dgvDetails.Columns.Contains("HareketID"))
                    dgvDetails.Columns["HareketID"].Visible = false;

                dgvDetails.ReadOnly = true;
                dgvDetails.AllowUserToAddRows = false;
                dgvDetails.AllowUserToDeleteRows = false;
                dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDetails.MultiSelect = false;
                dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                UpdateStockInfo(siparisId);
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Detaylar Yükleme Hatası", ex.Message);
                MessageBox.Show("Detaylar yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateStockInfo(int siparisId)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 0)
                {
                    lblTotalIn.Text = "Toplam Giriş: 0";
                    lblTotalOut.Text = "Toplam Çıkış: 0";
                    lblNetStock.Text = "Net Stok: 0";
                    return;
                }

                string query = @"
                SELECT
                    SUM(CASE WHEN GirisCikis = 'G' THEN Adet ELSE 0 END) AS ToplamGiris,
                    SUM(CASE WHEN GirisCikis = 'Ç' THEN Adet ELSE 0 END) AS ToplamCikis
                FROM UrunHareketleri
                WHERE SiparisID = @id";

                SqlParameter[] parameters = { new SqlParameter("@id", siparisId) };
                DataTable dt = Database.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    object girisObj = dt.Rows[0]["ToplamGiris"];
                    object cikisObj = dt.Rows[0]["ToplamCikis"];

                    int giris = girisObj != DBNull.Value ? Convert.ToInt32(girisObj) : 0;
                    int cikis = cikisObj != DBNull.Value ? Convert.ToInt32(cikisObj) : 0;

                    int net = giris - cikis;

                    lblTotalIn.Text = $"Toplam Giriş: {giris}";
                    lblTotalOut.Text = $"Toplam Çıkış: {cikis}";
                    lblNetStock.Text = $"Net Stok: {net}";
                }
                else
                {
                    lblTotalIn.Text = "Toplam Giriş: 0";
                    lblTotalOut.Text = "Toplam Çıkış: 0";
                    lblNetStock.Text = "Net Stok: 0";
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Stok Bilgisi Güncelleme Hatası", ex.Message);
                MessageBox.Show("Stok bilgisi güncellenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteSelectedOrder()
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek siparişi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Seçili sipariş ve ona ait tüm ürün hareketleri kalıcı olarak silinecek. Devam etmek istiyor musunuz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            DataRowView selectedRow = dgvOrders.SelectedRows[0].DataBoundItem as DataRowView;
            if (selectedRow == null)
            {
                MessageBox.Show("Seçili siparişin verisine ulaşılamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int siparisId = Convert.ToInt32(selectedRow["SiparisID"]);
            string siparisNo = selectedRow["Sipariş No"]?.ToString();

            try
            {
                string deleteDetails = "DELETE FROM UrunHareketleri WHERE SiparisID = @id";
                string deleteOrder = "DELETE FROM Siparisler WHERE SiparisID = @id";

                SqlParameter[] param1 = { new SqlParameter("@id", siparisId) };
                SqlParameter[] param2 = { new SqlParameter("@id", siparisId) };

                Database.ExecuteNonQuery(deleteDetails, param1);
                Database.ExecuteNonQuery(deleteOrder, param2);

                MessageBox.Show("Sipariş ve detayları başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LogHelper.AddLog(UserSession.KullaniciID, "Sipariş Silme",
                    $"{UserSession.KullaniciAdi}, SiparişID: {siparisId}, SiparişNo: {siparisNo} olan siparişi ve ilgili ürün hareketlerini sildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogHelper.AddLog(UserSession.KullaniciID, "Silme Hatası",
                    $"{UserSession.KullaniciAdi}, SiparişID: {siparisId} silinirken hata aldı: {ex.Message}");
            }

            LoadOrders();
            dgvDetails.DataSource = null;
        }
        private void DeleteSelectedDetail()
        {
            if (dgvDetails.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek hareketi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Seçili ürün hareketi silinecek. Emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            DataRowView selectedRow = dgvDetails.SelectedRows[0].DataBoundItem as DataRowView;
            if (selectedRow == null)
            {
                MessageBox.Show("Seçili ürün hareketine ait veri alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int hareketId = Convert.ToInt32(selectedRow["HareketID"]);

            string selectQuery = @"
                SELECT m.MarkaAdi, uh.Model, c.CinsAdi, uh.Adet, uh.GirisCikis
                FROM UrunHareketleri uh
                JOIN Markalar m ON uh.MarkaID = m.MarkaID
                JOIN Cinsler c ON uh.CinsID = c.CinsID
                WHERE uh.HareketID = @id";
            SqlParameter[] selectParams = { new SqlParameter("@id", hareketId) };
            DataTable dt = Database.ExecuteQuery(selectQuery, selectParams);

            string urunBilgi = "Bilinmiyor";
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                urunBilgi = $"{row["MarkaAdi"]} - {row["Model"]} ({row["CinsAdi"]}), " +
                            $"{row["Adet"]} Adet, {row["GirisCikis"]}";
            }

            string delete = "DELETE FROM UrunHareketleri WHERE HareketID = @id";
            SqlParameter[] deleteParams = { new SqlParameter("@id", hareketId) };

            try
            {
                int rowsAffected = Database.ExecuteNonQuery(delete, deleteParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Ürün hareketi silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LogHelper.AddLog(
                        UserSession.KullaniciID,
                        "Ürün Hareketi Silme",
                        $"{UserSession.KullaniciAdi}, '{urunBilgi}' adlı ürün hareketini sildi."
                    );
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız oldu. Kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogHelper.AddLog(
                    UserSession.KullaniciID,
                    "Silme Hatası",
                    $"{UserSession.KullaniciAdi}, '{urunBilgi}' silinirken hata aldı: {ex.Message}"
                );
            }

            LoadDetails();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteSelectedOrder();
        }

        private void btnDeleteOrderDetail_Click(object sender, EventArgs e)
        {
            DeleteSelectedDetail();
        }

        private void btnRefreshDetails_Click(object sender, EventArgs e)
        {
            LoadDetails();
        }
        private void SearchOrders()
        {
            try
            {
                string girisCikis = string.IsNullOrWhiteSpace(cmbTransactionType.Text) ? null : cmbTransactionType.Text.Trim();

                int markaID = -1;
                if (cmbBrand.SelectedValue != null && int.TryParse(cmbBrand.SelectedValue.ToString(), out int mID))
                    markaID = mID;

                int cinsID = -1;
                if (cmbCategory.SelectedValue != null && int.TryParse(cmbCategory.SelectedValue.ToString(), out int cID))
                    cinsID = cID;

                DateTime? baslangicTarih = null;
                DateTime? bitisTarih = null;

                if (dtpStartDate.Checked)
                    baslangicTarih = dtpStartDate.Value.Date;

                if (dtpEndDate.Checked)
                    bitisTarih = dtpEndDate.Value.Date;

                if (baslangicTarih.HasValue && bitisTarih.HasValue && baslangicTarih > bitisTarih)
                {
                    MessageBox.Show("Başlangıç tarihi, bitiş tarihinden büyük olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"
                    SELECT 
                        S.SiparisID, 
                        S.SiparisNo AS [Sipariş No], 
                        S.AliciAd AS [Alıcı Adı], 
                        S.Firma AS [Firma], 
                        S.Pazaryeri AS [Pazaryeri], 
                        S.Tarih AS [Tarih]
                    FROM Siparisler S
                    INNER JOIN UrunHareketleri UH ON S.SiparisID = UH.SiparisID
                    WHERE 
                        (@siparisNo IS NULL OR S.SiparisNo LIKE '%' + @siparisNo + '%') AND
                        (@aliciAd IS NULL OR S.AliciAd LIKE '%' + @aliciAd + '%') AND
                        (@firma IS NULL OR S.Firma = @firma) AND
                        (@pazaryeri IS NULL OR S.Pazaryeri = @pazaryeri) AND
                        (@markaID = -1 OR UH.MarkaID = @markaID) AND
                        (@model IS NULL OR UH.Model LIKE '%' + @model + '%') AND
                        (@cinsID = -1 OR UH.CinsID = @cinsID) AND
                        (@girisCikis IS NULL OR UH.GirisCikis = @girisCikis) AND
                        (
                            (@baslangicTarih IS NULL AND @bitisTarih IS NULL)
                            OR (S.Tarih BETWEEN ISNULL(@baslangicTarih, S.Tarih) AND ISNULL(@bitisTarih, S.Tarih))
                        )
                    GROUP BY 
                        S.SiparisID, S.SiparisNo, S.AliciAd, S.Firma, S.Pazaryeri, S.Tarih
                    ORDER BY S.Tarih DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@siparisNo", string.IsNullOrWhiteSpace(txtOrderNo.Text) ? (object)DBNull.Value : txtOrderNo.Text.Trim()),
                    new SqlParameter("@aliciAd", string.IsNullOrWhiteSpace(txtCustomer.Text) ? (object)DBNull.Value : txtCustomer.Text.Trim()),
                    new SqlParameter("@firma", string.IsNullOrWhiteSpace(cmbCompany.Text) ? (object)DBNull.Value : cmbCompany.Text.Trim()),
                    new SqlParameter("@pazaryeri", string.IsNullOrWhiteSpace(cmbMarketplace.Text) ? (object)DBNull.Value : cmbMarketplace.Text.Trim()),
                    new SqlParameter("@markaID", markaID),
                    new SqlParameter("@model", string.IsNullOrWhiteSpace(txtModel.Text) ? (object)DBNull.Value : txtModel.Text.Trim()),
                    new SqlParameter("@cinsID", cinsID),
                    new SqlParameter("@girisCikis", string.IsNullOrEmpty(girisCikis) ? (object)DBNull.Value : girisCikis),
                    new SqlParameter("@baslangicTarih", baslangicTarih.HasValue ? (object)baslangicTarih.Value : DBNull.Value),
                    new SqlParameter("@bitisTarih", bitisTarih.HasValue ? (object)bitisTarih.Value : DBNull.Value)
                };

                DataTable dt = Database.ExecuteQuery(query, parameters);
                dgvOrders.DataSource = dt;

                if (dgvOrders.Columns.Contains("SiparisID"))
                    dgvOrders.Columns["SiparisID"].Visible = false;

                dgvOrders.ReadOnly = true;
                dgvOrders.AllowUserToAddRows = false;
                dgvOrders.AllowUserToDeleteRows = false;
                dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvOrders.MultiSelect = false;
                dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dt.Rows.Count == 0)
                    dgvDetails.DataSource = null;
            }
            catch (Exception ex)
            {
                LogHelper.AddLog(UserSession.KullaniciID, "Sipariş Arama Hatası", ex.Message);
                MessageBox.Show("Siparişler aranırken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SearchOrders();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbBrand.SelectedIndex = -1;
            txtModel.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbTransactionType.SelectedIndex = -1;
            txtOrderNo.Text = "";
            txtCustomer.Text = "";
            cmbCompany.SelectedIndex = -1;
            cmbMarketplace.SelectedIndex = -1;

        }

        private void btnExport_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextExportMenu.Show(btnExport, new Point(0, btnExport.Height));
            }
        }
        private void exportSelectedMenuItem_Click(object sender, EventArgs e)
        {
            ExportSelectedOrderToExcel();
        }
        private void exportFilteredMenuItem_Click(object sender, EventArgs e)
        {
            ExportFilteredOrdersToExcel();
        }
        private void exportAllMenuItem_Click(object sender, EventArgs e)
        {
            ExportAllToExcel();

        }
        private void ExportAllToExcel()
        {
            DataSet exportData = new DataSet();

            string siparisQuery = "SELECT SiparisNo, AliciAd, Firma, Pazaryeri, Tarih FROM Siparisler";

            string hareketQuery = @"
                SELECT 
                    S.SiparisNo AS [Sipariş No],
                    M.MarkaAdi AS [Marka],
                    UH.Model,
                    C.CinsAdi AS [Cins],
                    UH.GirisCikis AS [İşlem Türü],
                    UH.Adet,
                    UH.Tarih,
                    UH.Aciklama
                FROM UrunHareketleri UH
                INNER JOIN Siparisler S ON S.SiparisID = UH.SiparisID
                LEFT JOIN Markalar M ON M.MarkaID = UH.MarkaID
                LEFT JOIN Cinsler C ON C.CinsID = UH.CinsID";

            exportData.Tables.Add(Database.ExecuteQuery(siparisQuery).Copy());
            exportData.Tables[0].TableName = "SiparisBilgileri";

            exportData.Tables.Add(Database.ExecuteQuery(hareketQuery).Copy());
            exportData.Tables[1].TableName = "UrunHareketleri";

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Dosyası (*.csv)|*.csv";
                saveDialog.FileName = "TumSiparisler.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                        {
                            foreach (DataTable table in exportData.Tables)
                            {
                                writer.WriteLine($"== {table.TableName} ==");

                                for (int i = 0; i < table.Columns.Count; i++)
                                {
                                    writer.Write(table.Columns[i].ColumnName);
                                    if (i < table.Columns.Count - 1)
                                        writer.Write(";");
                                }
                                writer.WriteLine();

                                foreach (DataRow row in table.Rows)
                                {
                                    for (int i = 0; i < table.Columns.Count; i++)
                                    {
                                        var value = row[i]?.ToString().Replace(";", " ");
                                        writer.Write(value);
                                        if (i < table.Columns.Count - 1)
                                            writer.Write(";");
                                    }
                                    writer.WriteLine();
                                }

                                writer.WriteLine();
                            }
                        }

                        MessageBox.Show("Tüm veriler başarıyla aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogHelper.AddLog(UserSession.KullaniciID, "Excel Aktarımı", $"{UserSession.KullaniciAdi}, tüm sipariş ve hareket verilerini Excel olarak aktardı.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Aktarma sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogHelper.AddLog(UserSession.KullaniciID, "Excel Aktarım Hatası", $"{UserSession.KullaniciAdi}, tüm verileri aktarırken hata aldı: {ex.Message}");
                    }
                }
            }
        }
        private void ExportSelectedOrderToExcel()
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen aktarılacak siparişi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogHelper.AddLog(UserSession.KullaniciID, "Sipariş Aktarımı - Uyarı", $"{UserSession.KullaniciAdi} sipariş seçmeden Excel aktarımı yapmaya çalıştı.");
                return;
            }

            DataSet exportData = new DataSet();
            var siparisID = dgvOrders.SelectedRows[0].Cells["SiparisID"].Value;

            string siparisQuery = "SELECT SiparisNo, AliciAd, Firma, Pazaryeri, Tarih FROM Siparisler WHERE SiparisID = @id";

            string hareketQuery = @"
                SELECT 
                    S.SiparisNo AS [Sipariş No],
                    M.MarkaAdi AS [Marka],
                    UH.Model,
                    C.CinsAdi AS [Cins],
                    UH.GirisCikis AS [İşlem Türü],
                    UH.Adet,
                    UH.Tarih,
                    UH.Aciklama
                FROM UrunHareketleri UH
                INNER JOIN Siparisler S ON S.SiparisID = UH.SiparisID
                LEFT JOIN Markalar M ON M.MarkaID = UH.MarkaID
                LEFT JOIN Cinsler C ON C.CinsID = UH.CinsID
                WHERE UH.SiparisID = @id";

            SqlParameter[] parameters = { new SqlParameter("@id", siparisID) };

            exportData.Tables.Add(Database.ExecuteQuery(siparisQuery, parameters).Copy());
            exportData.Tables[0].TableName = "SiparisBilgileri";

            exportData.Tables.Add(Database.ExecuteQuery(hareketQuery, parameters).Copy());
            exportData.Tables[1].TableName = "UrunHareketleri";

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Dosyası (*.csv)|*.csv";
                saveDialog.FileName = $"Siparis_{siparisID}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                        {
                            foreach (DataTable table in exportData.Tables)
                            {
                                writer.WriteLine($"== {table.TableName} ==");

                                for (int i = 0; i < table.Columns.Count; i++)
                                {
                                    writer.Write(table.Columns[i].ColumnName);
                                    if (i < table.Columns.Count - 1)
                                        writer.Write(";");
                                }
                                writer.WriteLine();

                                foreach (DataRow row in table.Rows)
                                {
                                    for (int i = 0; i < table.Columns.Count; i++)
                                    {
                                        var value = row[i]?.ToString().Replace(";", " ");
                                        writer.Write(value);
                                        if (i < table.Columns.Count - 1)
                                            writer.Write(";");
                                    }
                                    writer.WriteLine();
                                }

                                writer.WriteLine();
                            }
                        }

                        MessageBox.Show("Seçili sipariş başarıyla aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogHelper.AddLog(UserSession.KullaniciID, "Excel Aktarımı", $"{UserSession.KullaniciAdi}, SiparişID: {siparisID} için Excel aktarımı gerçekleştirdi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Aktarma sırasında bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogHelper.AddLog(UserSession.KullaniciID, "Excel Aktarım Hatası", $"{UserSession.KullaniciAdi}, SiparişID: {siparisID} aktarımında hata aldı: {ex.Message}");
                    }
                }
            }
        }
        private void ExportFilteredOrdersToExcel()
        {
            string girisCikis = null;
            if (!string.IsNullOrWhiteSpace(cmbTransactionType.Text))
            {
                if (cmbTransactionType.Text.ToUpper().Contains("GİRİŞ"))
                    girisCikis = "Giriş";
                else if (cmbTransactionType.Text.ToUpper().Contains("ÇIKIŞ"))
                    girisCikis = "Çıkış";
            }

            string query = @"
            SELECT 
                S.SiparisNo,
                S.AliciAd,
                S.Firma,
                S.Pazaryeri,
                S.Tarih
            FROM Siparisler S
            INNER JOIN UrunHareketleri UH ON S.SiparisID = UH.SiparisID
            WHERE
                (@siparisNo IS NULL OR S.SiparisNo LIKE '%' + @siparisNo + '%') AND
                (@aliciAd IS NULL OR S.AliciAd LIKE '%' + @aliciAd + '%') AND
                (@firma IS NULL OR S.Firma = @firma) AND
                (@pazaryeri IS NULL OR S.Pazaryeri = @pazaryeri) AND
                (@markaID = -1 OR UH.MarkaID = @markaID) AND
                (@model IS NULL OR UH.Model LIKE '%' + @model + '%') AND
                (@cinsID = -1 OR UH.CinsID = @cinsID) AND
                (@girisCikis IS NULL OR UH.GirisCikis = @girisCikis) AND
                (@startDate IS NULL OR S.Tarih >= @startDate) AND
                (@endDate IS NULL OR S.Tarih < DATEADD(DAY, 1, @endDate))
            GROUP BY S.SiparisNo, S.AliciAd, S.Firma, S.Pazaryeri, S.Tarih
            ORDER BY S.Tarih DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@siparisNo", string.IsNullOrWhiteSpace(txtOrderNo.Text) ? (object)DBNull.Value : txtOrderNo.Text.Trim()),
                new SqlParameter("@aliciAd", string.IsNullOrWhiteSpace(txtCustomer.Text) ? (object)DBNull.Value : txtCustomer.Text.Trim()),
                new SqlParameter("@firma", string.IsNullOrWhiteSpace(cmbCompany.Text) ? (object)DBNull.Value : cmbCompany.Text.Trim()),
                new SqlParameter("@pazaryeri", string.IsNullOrWhiteSpace(cmbMarketplace.Text) ? (object)DBNull.Value : cmbMarketplace.Text.Trim()),
                new SqlParameter("@markaID", cmbBrand.SelectedValue ?? -1),
                new SqlParameter("@model", string.IsNullOrWhiteSpace(txtModel.Text) ? (object)DBNull.Value : txtModel.Text.Trim()),
                new SqlParameter("@cinsID", cmbCategory.SelectedValue ?? -1),
                new SqlParameter("@girisCikis", string.IsNullOrEmpty(girisCikis) ? (object)DBNull.Value : girisCikis),
                new SqlParameter("@startDate", dtpStartDate.Value.Date),
                new SqlParameter("@endDate", dtpEndDate.Value.Date)
            };

            DataTable filteredOrders = Database.ExecuteQuery(query, parameters);
            if (filteredOrders.Rows.Count == 0)
            {
                MessageBox.Show("Filtreye uygun sipariş bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string siparisNos = string.Join(",", filteredOrders.AsEnumerable().Select(r => $"'{r["SiparisNo"]}'"));

            string hareketQuery = $@"
            SELECT 
                S.SiparisNo AS [Sipariş No],
                M.MarkaAdi AS [Marka],
                UH.Model,
                C.CinsAdi AS [Cins],
                UH.GirisCikis AS [İşlem Türü],
                UH.Adet,
                UH.Tarih,
                UH.Aciklama
            FROM UrunHareketleri UH
            INNER JOIN Siparisler S ON S.SiparisID = UH.SiparisID
            LEFT JOIN Markalar M ON M.MarkaID = UH.MarkaID
            LEFT JOIN Cinsler C ON C.CinsID = UH.CinsID
            WHERE S.SiparisNo IN ({siparisNos})
            ORDER BY UH.Tarih DESC";

            DataTable hareketler = Database.ExecuteQuery(hareketQuery);

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel Dosyası (*.csv)|*.csv";
                saveDialog.FileName = "FiltreliSiparisler.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                        {
                            writer.WriteLine("== Filtreye Uygun Siparişler ==");

                            for (int i = 0; i < filteredOrders.Columns.Count; i++)
                            {
                                writer.Write(filteredOrders.Columns[i].ColumnName);
                                if (i < filteredOrders.Columns.Count - 1) writer.Write(";");
                            }
                            writer.WriteLine();

                            foreach (DataRow row in filteredOrders.Rows)
                            {
                                for (int i = 0; i < filteredOrders.Columns.Count; i++)
                                {
                                    writer.Write(row[i]?.ToString().Replace(";", " "));
                                    if (i < filteredOrders.Columns.Count - 1) writer.Write(";");
                                }
                                writer.WriteLine();
                            }

                            writer.WriteLine();
                            writer.WriteLine("== Ürün Hareketleri ==");

                            for (int i = 0; i < hareketler.Columns.Count; i++)
                            {
                                writer.Write(hareketler.Columns[i].ColumnName);
                                if (i < hareketler.Columns.Count - 1) writer.Write(";");
                            }
                            writer.WriteLine();

                            foreach (DataRow row in hareketler.Rows)
                            {
                                for (int i = 0; i < hareketler.Columns.Count; i++)
                                {
                                    writer.Write(row[i]?.ToString().Replace(";", " "));
                                    if (i < hareketler.Columns.Count - 1) writer.Write(";");
                                }
                                writer.WriteLine();
                            }
                        }

                        MessageBox.Show("Filtrelenmiş veriler başarıyla aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogHelper.AddLog(UserSession.KullaniciID, "Excel Aktarımı", $"{UserSession.KullaniciAdi} filtrelenmiş siparişleri Excel'e aktardı.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Aktarma sırasında hata:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogHelper.AddLog(UserSession.KullaniciID, "Excel Aktarım Hatası", $"{UserSession.KullaniciAdi} aktarım sırasında hata aldı: {ex.Message}");
                    }
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
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
        private void OrderListForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        private void logoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            logoPictureBox.MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        private void btnEditOrderDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetails.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek bir ürün hareketi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hareketId;
            if (!int.TryParse(dgvDetails.CurrentRow.Cells["HareketID"].Value?.ToString(), out hareketId))
            {
                MessageBox.Show("Hareket ID alınamadı.");
                return;
            }

            string siparisNo = dgvOrders.SelectedRows[0].Cells["Sipariş No"].Value?.ToString();
            string aliciAdi = dgvOrders.SelectedRows[0].Cells["Alıcı Adı"].Value?.ToString();
            string firma = dgvOrders.SelectedRows[0].Cells["Firma"].Value?.ToString();
            string pazaryeri = dgvOrders.SelectedRows[0].Cells["Pazaryeri"].Value?.ToString();

            string marka = dgvDetails.CurrentRow.Cells["Marka"].Value?.ToString();
            string model = dgvDetails.CurrentRow.Cells["Model"].Value?.ToString();
            string cins = dgvDetails.CurrentRow.Cells["Cins"].Value?.ToString();
            string girisCikis = dgvDetails.CurrentRow.Cells["Giriş/Çıkış"].Value?.ToString();
            int adet = Convert.ToInt32(dgvDetails.CurrentRow.Cells["Adet"].Value);
            string aciklama = dgvDetails.CurrentRow.Cells["Açıklama"].Value?.ToString();

            EditProductMovementForm frm = new EditProductMovementForm(
                hareketId, siparisNo, aliciAdi, firma, pazaryeri,
                marka, model, cins, girisCikis, adet, aciklama);
            frm.ShowDialog();
            LoadDetails();
            LoadOrders();
        }
    }
}

