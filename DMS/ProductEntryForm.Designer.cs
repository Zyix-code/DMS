namespace DMS
{
    partial class ProductEntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductEntryForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.minimanizeLabel = new System.Windows.Forms.Label();
            this.closeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMarketplace = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.colBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTxnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnExit.Location = new System.Drawing.Point(1019, 396);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 29);
            this.btnExit.TabIndex = 50;
            this.btnExit.Text = "✖ Çıkış Yap";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // minimanizeLabel
            // 
            this.minimanizeLabel.AutoSize = true;
            this.minimanizeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimanizeLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.minimanizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.minimanizeLabel.Location = new System.Drawing.Point(1237, 9);
            this.minimanizeLabel.Name = "minimanizeLabel";
            this.minimanizeLabel.Size = new System.Drawing.Size(22, 25);
            this.minimanizeLabel.TabIndex = 45;
            this.minimanizeLabel.Text = "-";
            this.minimanizeLabel.Click += new System.EventHandler(this.minimanizeLabel_Click);
            // 
            // closeLabel
            // 
            this.closeLabel.AutoSize = true;
            this.closeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.closeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.closeLabel.Location = new System.Drawing.Point(1258, 9);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(28, 25);
            this.closeLabel.TabIndex = 44;
            this.closeLabel.Text = "X";
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(80, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 57);
            this.label1.TabIndex = 43;
            this.label1.Text = "Bu program SELÇUK ŞAHİN tarafından geliştirilmiştir.\r\nHerhangi bir arıza, öneri, " +
    "şikayet için.\r\nselcuksahin158@gmail.com\'a mail gönderebilirsiniz.\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Controls.Add(this.dtpOrderDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbMarketplace);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOrderNumber);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.groupBox1.Location = new System.Drawing.Point(518, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 137);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "🗂️ Sipariş Bilgileri";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Pazar Yeri: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Firma: ";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Items.AddRange(new object[] {
            "OS BİLİŞİM",
            "TRENTA TEKNOLOJİ"});
            this.cmbCompany.Location = new System.Drawing.Point(370, 58);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(200, 25);
            this.cmbCompany.TabIndex = 10;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(370, 27);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 25);
            this.dtpOrderDate.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tarih: ";
            // 
            // cmbMarketplace
            // 
            this.cmbMarketplace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarketplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMarketplace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.cmbMarketplace.FormattingEnabled = true;
            this.cmbMarketplace.Items.AddRange(new object[] {
            "HEPSİ BURADA",
            "TRENDYOL",
            "N11",
            "AMAZON",
            "DMO",
            "OS DİREKT SATIŞ",
            "TRENTA DİREKT SATIŞ",
            "İÇ KULLANIM"});
            this.cmbMarketplace.Location = new System.Drawing.Point(89, 89);
            this.cmbMarketplace.Name = "cmbMarketplace";
            this.cmbMarketplace.Size = new System.Drawing.Size(200, 25);
            this.cmbMarketplace.TabIndex = 4;
            this.cmbMarketplace.SelectedIndexChanged += new System.EventHandler(this.cmbMarketplace_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Alıcı Adı: ";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtCustomerName.Location = new System.Drawing.Point(89, 58);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(200, 25);
            this.txtCustomerName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sipariş No: ";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtOrderNumber.Location = new System.Drawing.Point(89, 27);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(200, 25);
            this.txtOrderNumber.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveRow);
            this.groupBox2.Controls.Add(this.btnAddRow);
            this.groupBox2.Controls.Add(this.dgvProducts);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.groupBox2.Location = new System.Drawing.Point(518, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 235);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "📦 Ürün / Bileşen Girişi";
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnRemoveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnRemoveRow.Location = new System.Drawing.Point(664, 189);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(98, 29);
            this.btnRemoveRow.TabIndex = 52;
            this.btnRemoveRow.Text = "[-] Satır Sil";
            this.btnRemoveRow.UseVisualStyleBackColor = false;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnAddRow.Location = new System.Drawing.Point(12, 189);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(98, 29);
            this.btnAddRow.TabIndex = 51;
            this.btnAddRow.Text = "[+] Satır Ekle";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBrand,
            this.colModel,
            this.colCategory,
            this.colQuantity,
            this.colTxnType,
            this.colNote});
            this.dgvProducts.Location = new System.Drawing.Point(12, 33);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(750, 150);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvProducts_EditingControlShowing);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnSave.Location = new System.Drawing.Point(686, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 29);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "💾 Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnClear.Location = new System.Drawing.Point(797, 396);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 29);
            this.btnClear.TabIndex = 56;
            this.btnClear.Text = "🧹 Temizle";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::DMS.Properties.Resources.WareHouseManagamentSystem;
            this.logoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(500, 500);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 46;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logoPictureBox_MouseDown);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnMainMenu.Location = new System.Drawing.Point(908, 396);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(105, 29);
            this.btnMainMenu.TabIndex = 57;
            this.btnMainMenu.Text = "🏠 Ana Menü";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // colBrand
            // 
            this.colBrand.HeaderText = "Marka";
            this.colBrand.Name = "colBrand";
            this.colBrand.Width = 150;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "Model";
            this.colModel.Name = "colModel";
            this.colModel.Width = 150;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Cins";
            this.colCategory.Items.AddRange(new object[] {
            "AIO",
            "BARKOD YAZICI",
            "CPU",
            "EKRAN KARTI",
            "HDD",
            "KLAVYE",
            "MONİTÖR",
            "NOTEBOOK",
            "PC",
            "RAM",
            "SSD",
            "TABLET",
            "TARAYICI",
            "UPS",
            "YAZICI"});
            this.colCategory.Name = "colCategory";
            this.colCategory.Width = 150;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Adet";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Width = 50;
            // 
            // colTxnType
            // 
            this.colTxnType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colTxnType.HeaderText = "İşlem";
            this.colTxnType.Items.AddRange(new object[] {
            "GİRİŞ",
            "ÇIKIŞ"});
            this.colTxnType.Name = "colTxnType";
            // 
            // colNote
            // 
            this.colNote.HeaderText = "Açıklama";
            this.colNote.Name = "colNote";
            this.colNote.Width = 200;
            // 
            // ProductEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1298, 566);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.minimanizeLabel);
            this.Controls.Add(this.closeLabel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Giriş/Çıkış";
            this.Load += new System.EventHandler(this.ProductEntryForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProductEntryForm_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label minimanizeLabel;
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.ComboBox cmbMarketplace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTxnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
    }
}