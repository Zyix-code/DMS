using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DMS
{
    public partial class ProductEntryForm : BaseForm
    {
        public ProductEntryForm()
        {
            InitializeComponent();
        }

        private void ProductEntryForm_Load(object sender, EventArgs e)
        {
            VersionChecker.CheckVersionFromDatabase();
            LoadBrandColumn();
            LoadCategoryColumn();
        }
        private void LoadBrandColumn()
        {
            try
            {
                string query = "SELECT MarkaID, MarkaAdi FROM Markalar ORDER BY MarkaAdi ASC";
                DataTable brandTable = Database.ExecuteQuery(query);

                DataGridViewComboBoxColumn brandColumn = dgvProducts.Columns["colBrand"] as DataGridViewComboBoxColumn;
                if (brandColumn != null)
                {
                    brandColumn.DataSource = brandTable;
                    brandColumn.DisplayMember = "MarkaAdi";
                    brandColumn.ValueMember = "MarkaID";
                    brandColumn.FlatStyle = FlatStyle.Flat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Marka sütunu yüklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.AddLog(UserSession.KullaniciID, "Marka Yükleme Hatası", $"Hata: {ex.Message}");
            }
        }

        private void LoadCategoryColumn()
        {
            try
            {
                string query = "SELECT CinsID, CinsAdi FROM Cinsler ORDER BY CinsAdi ASC";
                DataTable categoryTable = Database.ExecuteQuery(query);

                DataGridViewComboBoxColumn categoryColumn = dgvProducts.Columns["colCategory"] as DataGridViewComboBoxColumn;
                if (categoryColumn != null)
                {
                    categoryColumn.DataSource = categoryTable;
                    categoryColumn.DisplayMember = "CinsAdi";
                    categoryColumn.ValueMember = "CinsID";
                    categoryColumn.FlatStyle = FlatStyle.Flat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cins (kategori) sütunu yüklenirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.AddLog(UserSession.KullaniciID, "Kategori Yükleme Hatası", $"Hata: {ex.Message}");
            }
        }

        private void dgvProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress -= Quantity_KeyPress;

                if (dgvProducts.CurrentCell.OwningColumn.Name == "colQuantity")
                {
                    tb.KeyPress += Quantity_KeyPress;
                }
            }
        }

        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dgvProducts.Rows.Add();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                dgvProducts.Rows.RemoveAt(dgvProducts.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Kaydedilmemiş veya seçilmemiş yeni satır silinemez.", "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
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

        private void cmbMarketplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAutoOrderNumber();
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAutoOrderNumber();
        }
        private string _lastMarketplace = string.Empty;

        private void CheckAutoOrderNumber()
        {
            string marketplace = cmbMarketplace.Text.Trim();

            string transactionType = "";
            if (dgvProducts.CurrentRow != null && dgvProducts.Columns.Contains("colTxnType"))
            {
                transactionType = dgvProducts.CurrentRow.Cells["colTxnType"].Value?.ToString();
            }

            bool isManualNew = IsManualMarketplace(marketplace);
            bool isManualOld = IsManualMarketplace(_lastMarketplace);

            if (isManualNew)
            {
                if (!isManualOld)
                {
                    txtOrderNumber.Clear();
                    txtCustomerName.Clear();
                }

                if (!string.IsNullOrEmpty(transactionType))
                    SetNextOrAvailableManualOrderNumber(marketplace, transactionType);
            }
            else
            {
                if (isManualOld)
                {
                    txtOrderNumber.Clear();
                    txtCustomerName.Clear();
                }
            }

            _lastMarketplace = marketplace;
        }
        private bool IsManualMarketplace(string marketplace)
        {
            return marketplace == "DMO" || marketplace == "OS DİREKT SATIŞ" || marketplace == "TRENTA DİREKT SATIŞ" || marketplace == "İÇ KULLANIM";
        }

        private void SetNextOrAvailableManualOrderNumber(string marketplace, string transactionType)
        {
            try
            {
                string prefix = GetPrefix(marketplace);

                string query = @"SELECT TOP 1 S.SiparisNo, S.AliciAd FROM Siparisler S
                 LEFT JOIN UrunHareketleri U_G ON S.SiparisID = U_G.SiparisID AND U_G.GirisCikis = 'Giriş'
                 LEFT JOIN UrunHareketleri U_C ON S.SiparisID = U_C.SiparisID AND U_C.GirisCikis = 'Çıkış'
                 WHERE S.Pazaryeri = @pazaryeri AND S.Tamamlandi = 0
                 GROUP BY S.SiparisID, S.SiparisNo, S.AliciAd
                 HAVING (@type = 'G' AND COUNT(U_G.GirisCikis) = 0)
                     OR (@type = 'Ç' AND COUNT(U_C.GirisCikis) = 0)
                 ORDER BY TRY_CAST(SUBSTRING(S.SiparisNo, LEN(@prefix)+1, LEN(S.SiparisNo)) AS INT) ASC";

                SqlParameter[] parameters = {
                    new SqlParameter("@pazaryeri", marketplace),
                    new SqlParameter("@type", transactionType),
                    new SqlParameter("@prefix", prefix)
                };

                DataTable dt = Database.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    txtOrderNumber.Text = dt.Rows[0]["SiparisNo"].ToString();
                    txtCustomerName.Text = dt.Rows[0]["AliciAd"].ToString();
                    return;
                }

                string lastQuery = @"SELECT TOP 1 SiparisNo FROM Siparisler WHERE Pazaryeri = @pazaryeri AND SiparisNo LIKE @prefixLike ORDER BY TRY_CAST(SUBSTRING(SiparisNo, LEN(@prefix)+1, LEN(SiparisNo)) AS INT) DESC";
                SqlParameter[] lastParams = {
                    new SqlParameter("@pazaryeri", marketplace),
                    new SqlParameter("@prefix", prefix),
                    new SqlParameter("@prefixLike", prefix + "%")
                };

                object lastObj = Database.ExecuteScalar(lastQuery, lastParams);
                int nextNumber = 1;
                if (lastObj != null && lastObj != DBNull.Value)
                {
                    string last = lastObj.ToString();
                    int.TryParse(last.Substring(prefix.Length), out nextNumber);
                    nextNumber++;
                }

                txtOrderNumber.Text = prefix + nextNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş numarası oluşturulurken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.AddLog(UserSession.KullaniciID, "Sipariş No Oluşturma Hatası", $"Hata: {ex.Message}");
            }
        }
        private string GetPrefix(string marketplace)
        {
            switch (marketplace)
            {
                case "DMO": return "DMO-";
                case "OS DİREKT SATIŞ": return "OS-";
                case "TRENTA DİREKT SATIŞ": return "TRENTA-";
                case "İÇ KULLANIM": return "IC-";
                default: return string.Empty;
            }
        }
        private void ClearForm()
        {
            txtOrderNumber.Clear();
            txtCustomerName.Clear();
            cmbCompany.SelectedIndex = -1;
            cmbMarketplace.SelectedIndex = -1;
            dgvProducts.Rows.Clear();
            dtpOrderDate.Value = DateTime.Today;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtOrderNumber.Text) ||
                    string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                    cmbCompany.SelectedIndex == -1 ||
                    cmbMarketplace.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen tüm sipariş bilgilerini doldurun.", "Eksik Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var productRows = dgvProducts.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow).ToList();
                if (!productRows.Any())
                {
                    MessageBox.Show("Lütfen en az bir ürün girin.", "Eksik Ürün",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (var row in productRows)
                {
                    if (row.Cells["colBrand"].Value == null ||
                        row.Cells["colCategory"].Value == null ||
                        row.Cells["colTxnType"].Value == null ||
                        string.IsNullOrWhiteSpace(row.Cells["colModel"].Value?.ToString()) ||
                        !int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out int qty) || qty <= 0)
                    {
                        MessageBox.Show("Tüm ürün bilgilerini ve işlem türünü eksiksiz girin.",
                            "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string orderNo = txtOrderNumber.Text.Trim();
                string customerName = txtCustomerName.Text.Trim();
                string company = cmbCompany.Text;
                string marketplace = cmbMarketplace.Text;
                DateTime orderDate = dtpOrderDate.Value.Date + DateTime.Now.TimeOfDay;

                string txnCheckQuery = @"
                    SELECT 
                        SUM(CASE WHEN GirisCikis = 'Giriş' THEN 1 ELSE 0 END) AS GirisSayisi,
                        SUM(CASE WHEN GirisCikis = 'Çıkış' THEN 1 ELSE 0 END) AS CikisSayisi
                    FROM UrunHareketleri U
                    INNER JOIN Siparisler S ON S.SiparisID = U.SiparisID
                    WHERE S.SiparisNo = @no";

                DataTable txnDt = Database.ExecuteQuery(txnCheckQuery,
                    new SqlParameter[] { new SqlParameter("@no", orderNo) });

                int prevGiris = txnDt.Rows[0]["GirisSayisi"] == DBNull.Value ? 0 : Convert.ToInt32(txnDt.Rows[0]["GirisSayisi"]);
                int prevCikis = txnDt.Rows[0]["CikisSayisi"] == DBNull.Value ? 0 : Convert.ToInt32(txnDt.Rows[0]["CikisSayisi"]);

                int newGirisCount = productRows.Count(r =>
                    NormalizeTxnType(r.Cells["colTxnType"].Value.ToString()) == "Giriş");

                int newCikisCount = productRows.Count(r =>
                    NormalizeTxnType(r.Cells["colTxnType"].Value.ToString()) == "Çıkış");



                if (prevGiris > 0 && prevCikis > 0)
                {
                    MessageBox.Show("Bu siparişe giriş ve çıkış zaten yapılmış. Yeni işlem yapılamaz.",
                        "Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (prevGiris > 0 && newGirisCount > 0)
                {
                    MessageBox.Show("Bu siparişe daha önce GİRİŞ yapılmış. Tekrar giriş yapılamaz.",
                        "Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (prevCikis > 0 && newCikisCount > 0)
                {
                    MessageBox.Show("Bu siparişe daha önce ÇIKIŞ yapılmış. Tekrar çıkış yapılamaz.",
                        "Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string getOrderQuery = "SELECT TOP 1 SiparisID, AliciAd, Firma, Pazaryeri FROM Siparisler WHERE SiparisNo = @no";
                DataTable orderDt = Database.ExecuteQuery(getOrderQuery,
                    new SqlParameter[] { new SqlParameter("@no", orderNo) });

                int orderId;
                bool newOrderCreated = false;

                if (orderDt.Rows.Count > 0)
                {
                    var row = orderDt.Rows[0];

                    if (!row["AliciAd"].ToString().Trim().Equals(customerName, StringComparison.InvariantCultureIgnoreCase) ||
                        !row["Firma"].ToString().Trim().Equals(company, StringComparison.InvariantCultureIgnoreCase) ||
                        !row["Pazaryeri"].ToString().Trim().Equals(marketplace, StringComparison.InvariantCultureIgnoreCase))
                    {
                        MessageBox.Show("Bu sipariş numarası başka bilgilerle kayıtlı. Uyuşmazlık!",
                            "Hatalı Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    orderId = Convert.ToInt32(row["SiparisID"]);
                }
                else
                {
                    string insertOrder = @"
                INSERT INTO Siparisler (SiparisNo, AliciAd, Firma, Pazaryeri, Tarih)
                VALUES (@no, @name, @firm, @market, @date);
                SELECT SCOPE_IDENTITY();";

                    orderId = Convert.ToInt32(Database.ExecuteScalar(insertOrder,
                        new SqlParameter[]
                        {
                            new SqlParameter("@no", orderNo),
                            new SqlParameter("@name", customerName),
                            new SqlParameter("@firm", company),
                            new SqlParameter("@market", marketplace),
                            new SqlParameter("@date", orderDate)
                        }));

                    newOrderCreated = true;
                }


                int totalQuantity = 0;

                bool hasGiris = false;
                bool hasCikis = false;

                foreach (var row in productRows)
                {
                    string txnType = NormalizeTxnType(row.Cells["colTxnType"].Value.ToString());

                    if (txnType == "Giriş") hasGiris = true;
                    if (txnType == "Çıkış") hasCikis = true;

                    string insertProduct = @"
                        INSERT INTO UrunHareketleri
                        (SiparisID, MarkaID, Model, CinsID, GirisCikis, Adet, Tarih, Aciklama)
                        VALUES (@id, @brand, @model, @cat, @type, @qty, @date, @note)";

                    Database.ExecuteNonQuery(insertProduct,
                        new SqlParameter[]
                        {
                    new SqlParameter("@id", orderId),
                    new SqlParameter("@brand", Convert.ToInt32(row.Cells["colBrand"].Value)),
                    new SqlParameter("@model", row.Cells["colModel"].Value.ToString()),
                    new SqlParameter("@cat", Convert.ToInt32(row.Cells["colCategory"].Value)),
                    new SqlParameter("@type", txnType),
                    new SqlParameter("@qty", Convert.ToInt32(row.Cells["colQuantity"].Value)),
                    new SqlParameter("@date", orderDate),
                    new SqlParameter("@note", row.Cells["colNote"].Value?.ToString() ?? "")
                        });

                    totalQuantity += Convert.ToInt32(row.Cells["colQuantity"].Value);
                }

                string finalTxnType =
                    hasGiris && hasCikis ? "Giriş & Çıkış" :
                    hasGiris ? "Giriş" :
                    hasCikis ? "Çıkış" :
                    "Bilinmiyor";

                MessageBox.Show("Kayıt başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string logMessage = newOrderCreated
                    ? $"Yeni sipariş oluşturuldu. SiparişNo: {orderNo}, Toplam Ürün Adedi: {totalQuantity}, Tür: {finalTxnType}"
                    : $"Mevcut siparişe ürün eklendi. SiparişNo: {orderNo}, Toplam Ürün Adedi: {totalQuantity}, Tür: {finalTxnType}";

                LogHelper.AddLog(UserSession.KullaniciID, "Sipariş Kaydı", logMessage);

                await EmailHelper.SendTemplateMailAsync(
                    "Yeni Sipariş Oluşturuldu",
                    "Sistemde yeni bir işlem kaydedildi.",
                    new List<string> { logMessage },
                    "success"
                );

                SoundHelper.NotifyAllUsers(
                    "Yeni Sipariş Oluşturuldu",
                    $"Sipariş No: {orderNo}, Toplam Adet: {totalQuantity}, Tür: {finalTxnType}"
                );

                ClearForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.AddLog(UserSession.KullaniciID, "Sipariş Oluşturma Hatası", $"Hata: {ex.Message}");
            }
        }
        private string NormalizeTxnType(string input)
        {
            if (input == null) return "";

            string val = input.Trim().ToUpperInvariant();

            if (val == "GİRİŞ") return "Giriş";
            if (val == "ÇIKIŞ") return "Çıkış";

            return input;
        }

        private void btnHome_Click(object sender, EventArgs e)
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
        private void ProductEntryForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown += new MouseEventHandler(Form_MouseDown);
        }

        private void logoPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            logoPictureBox.MouseDown += new MouseEventHandler(Form_MouseDown);
        }
    }
}