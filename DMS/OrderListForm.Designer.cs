namespace DMS
{
    partial class OrderListForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderListForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.minimanizeLabel = new System.Windows.Forms.Label();
            this.closeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMarketplace = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefreshOrders = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEditOrderDetail = new System.Windows.Forms.Button();
            this.btnRefreshDetails = new System.Windows.Forms.Button();
            this.btnDeleteOrderDetail = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblNetStock = new System.Windows.Forms.Label();
            this.lblTotalOut = new System.Windows.Forms.Label();
            this.lblTotalIn = new System.Windows.Forms.Label();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.contextExportMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFilteredMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.contextExportMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnExit.Location = new System.Drawing.Point(1172, 788);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 29);
            this.btnExit.TabIndex = 55;
            this.btnExit.Text = "✖ Çıkış Yap";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::DMS.Properties.Resources.WareHouseManagamentSystem;
            this.logoPictureBox.Location = new System.Drawing.Point(0, 185);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(500, 500);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 54;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logoPictureBox_MouseDown);
            // 
            // minimanizeLabel
            // 
            this.minimanizeLabel.AutoSize = true;
            this.minimanizeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimanizeLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.minimanizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.minimanizeLabel.Location = new System.Drawing.Point(1281, 9);
            this.minimanizeLabel.Name = "minimanizeLabel";
            this.minimanizeLabel.Size = new System.Drawing.Size(22, 25);
            this.minimanizeLabel.TabIndex = 53;
            this.minimanizeLabel.Text = "-";
            this.minimanizeLabel.Click += new System.EventHandler(this.minimanizeLabel_Click);
            // 
            // closeLabel
            // 
            this.closeLabel.AutoSize = true;
            this.closeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.closeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.closeLabel.Location = new System.Drawing.Point(1302, 9);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(28, 25);
            this.closeLabel.TabIndex = 52;
            this.closeLabel.Text = "X";
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(84, 688);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 57);
            this.label1.TabIndex = 51;
            this.label1.Text = "Bu program SELÇUK ŞAHİN tarafından geliştirilmiştir.\r\nHerhangi bir arıza, öneri, " +
    "şikayet için.\r\nselcuksahin158@gmail.com\'a mail gönderebilirsiniz.\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbMarketplace);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbTransactionType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbBrand);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCustomer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOrderNo);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.groupBox1.Location = new System.Drawing.Point(506, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 188);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "🔍 Arama Paneli";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 19);
            this.label11.TabIndex = 63;
            this.label11.Text = "Başlangıç Tarihi: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(326, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 19);
            this.label10.TabIndex = 62;
            this.label10.Text = "Bitiş Tarihi: ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(408, 148);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 25);
            this.dtpEndDate.TabIndex = 61;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(119, 148);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 25);
            this.dtpStartDate.TabIndex = 60;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnClear.Location = new System.Drawing.Point(614, 86);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(147, 29);
            this.btnClear.TabIndex = 59;
            this.btnClear.Text = "🧹 Temizle";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnSearch.Location = new System.Drawing.Point(614, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(147, 29);
            this.btnSearch.TabIndex = 58;
            this.btnSearch.Text = "🔍 Arama Yap";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(327, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 19);
            this.label9.TabIndex = 28;
            this.label9.Text = "Pazar Yeri: ";
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
            this.cmbMarketplace.Location = new System.Drawing.Point(408, 114);
            this.cmbMarketplace.Name = "cmbMarketplace";
            this.cmbMarketplace.Size = new System.Drawing.Size(200, 25);
            this.cmbMarketplace.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "Model: ";
            // 
            // txtModel
            // 
            this.txtModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtModel.Location = new System.Drawing.Point(119, 55);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(200, 25);
            this.txtModel.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 24;
            this.label8.Text = "Giriş/Çıkış";
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransactionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTransactionType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Items.AddRange(new object[] {
            "GİRİŞ",
            "ÇIKIŞ"});
            this.cmbTransactionType.Location = new System.Drawing.Point(119, 117);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(200, 25);
            this.cmbTransactionType.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 22;
            this.label6.Text = "Cins: ";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(119, 86);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 25);
            this.cmbCategory.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Firma: ";
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
            this.cmbCompany.Location = new System.Drawing.Point(408, 83);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(200, 25);
            this.cmbCompany.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Marka: ";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(119, 24);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(200, 25);
            this.cmbBrand.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Alıcı Adı: ";
            // 
            // txtCustomer
            // 
            this.txtCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtCustomer.Location = new System.Drawing.Point(408, 52);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(200, 25);
            this.txtCustomer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sipariş No: ";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtOrderNo.Location = new System.Drawing.Point(408, 21);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(200, 25);
            this.txtOrderNo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRefreshOrders);
            this.groupBox2.Controls.Add(this.btnDeleteOrder);
            this.groupBox2.Controls.Add(this.dgvOrders);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.groupBox2.Location = new System.Drawing.Point(506, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(771, 285);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "🗂️ Sipariş Listesi";
            // 
            // btnRefreshOrders
            // 
            this.btnRefreshOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnRefreshOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnRefreshOrders.Location = new System.Drawing.Point(614, 250);
            this.btnRefreshOrders.Name = "btnRefreshOrders";
            this.btnRefreshOrders.Size = new System.Drawing.Size(147, 29);
            this.btnRefreshOrders.TabIndex = 57;
            this.btnRefreshOrders.Text = "🔄 Siparişleri Yenile";
            this.btnRefreshOrders.UseVisualStyleBackColor = false;
            this.btnRefreshOrders.Click += new System.EventHandler(this.btnRefreshOrders_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnDeleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnDeleteOrder.Location = new System.Drawing.Point(6, 250);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(147, 29);
            this.btnDeleteOrder.TabIndex = 56;
            this.btnDeleteOrder.Text = "🗑 Seçili Siparişi Sil";
            this.btnDeleteOrder.UseVisualStyleBackColor = false;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(6, 24);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.Size = new System.Drawing.Size(755, 220);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEditOrderDetail);
            this.groupBox3.Controls.Add(this.btnRefreshDetails);
            this.groupBox3.Controls.Add(this.btnDeleteOrderDetail);
            this.groupBox3.Controls.Add(this.dgvDetails);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.groupBox3.Location = new System.Drawing.Point(506, 497);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(771, 285);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "📦 Ürün Detayları Paneli";
            // 
            // btnEditOrderDetail
            // 
            this.btnEditOrderDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnEditOrderDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOrderDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnEditOrderDetail.Location = new System.Drawing.Point(307, 250);
            this.btnEditOrderDetail.Name = "btnEditOrderDetail";
            this.btnEditOrderDetail.Size = new System.Drawing.Size(176, 29);
            this.btnEditOrderDetail.TabIndex = 60;
            this.btnEditOrderDetail.Text = "🖉 Seçili Ürünü Güncelle";
            this.btnEditOrderDetail.UseVisualStyleBackColor = false;
            this.btnEditOrderDetail.Click += new System.EventHandler(this.btnEditOrderDetail_Click);
            // 
            // btnRefreshDetails
            // 
            this.btnRefreshDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnRefreshDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnRefreshDetails.Location = new System.Drawing.Point(614, 250);
            this.btnRefreshDetails.Name = "btnRefreshDetails";
            this.btnRefreshDetails.Size = new System.Drawing.Size(147, 29);
            this.btnRefreshDetails.TabIndex = 59;
            this.btnRefreshDetails.Text = "🔄 Detayları Yenile";
            this.btnRefreshDetails.UseVisualStyleBackColor = false;
            this.btnRefreshDetails.Click += new System.EventHandler(this.btnRefreshDetails_Click);
            // 
            // btnDeleteOrderDetail
            // 
            this.btnDeleteOrderDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnDeleteOrderDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOrderDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnDeleteOrderDetail.Location = new System.Drawing.Point(6, 250);
            this.btnDeleteOrderDetail.Name = "btnDeleteOrderDetail";
            this.btnDeleteOrderDetail.Size = new System.Drawing.Size(147, 29);
            this.btnDeleteOrderDetail.TabIndex = 58;
            this.btnDeleteOrderDetail.Text = "🗑 Seçili Detayı Sil";
            this.btnDeleteOrderDetail.UseVisualStyleBackColor = false;
            this.btnDeleteOrderDetail.Click += new System.EventHandler(this.btnDeleteOrderDetail_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(6, 24);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.Size = new System.Drawing.Size(755, 220);
            this.dgvDetails.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnExport);
            this.groupBox4.Controls.Add(this.lblNetStock);
            this.groupBox4.Controls.Add(this.lblTotalOut);
            this.groupBox4.Controls.Add(this.lblTotalIn);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.groupBox4.Location = new System.Drawing.Point(506, 788);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 100);
            this.groupBox4.TabIndex = 59;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "📦 Sipariş Bilgileri";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnExport.Location = new System.Drawing.Point(199, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(147, 29);
            this.btnExport.TabIndex = 60;
            this.btnExport.Text = "📤 Excel’e Aktar";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnExport_MouseDown);
            // 
            // lblNetStock
            // 
            this.lblNetStock.AutoSize = true;
            this.lblNetStock.Location = new System.Drawing.Point(6, 72);
            this.lblNetStock.Name = "lblNetStock";
            this.lblNetStock.Size = new System.Drawing.Size(77, 19);
            this.lblNetStock.TabIndex = 17;
            this.lblNetStock.Text = "Net Stok: 0";
            // 
            // lblTotalOut
            // 
            this.lblTotalOut.AutoSize = true;
            this.lblTotalOut.Location = new System.Drawing.Point(6, 46);
            this.lblTotalOut.Name = "lblTotalOut";
            this.lblTotalOut.Size = new System.Drawing.Size(100, 19);
            this.lblTotalOut.TabIndex = 16;
            this.lblTotalOut.Text = "Toplam Çıkış: 0";
            // 
            // lblTotalIn
            // 
            this.lblTotalIn.AutoSize = true;
            this.lblTotalIn.Location = new System.Drawing.Point(6, 21);
            this.lblTotalIn.Name = "lblTotalIn";
            this.lblTotalIn.Size = new System.Drawing.Size(99, 19);
            this.lblTotalIn.TabIndex = 15;
            this.lblTotalIn.Text = "Toplam Giriş: 0";
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnMainMenu.Location = new System.Drawing.Point(1061, 788);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(105, 29);
            this.btnMainMenu.TabIndex = 60;
            this.btnMainMenu.Text = "🏠 Ana Menü";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // contextExportMenu
            // 
            this.contextExportMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportSelectedMenuItem,
            this.exportAllMenuItem,
            this.exportFilteredMenuItem});
            this.contextExportMenu.Name = "contextExportMenu";
            this.contextExportMenu.Size = new System.Drawing.Size(219, 70);
            // 
            // exportSelectedMenuItem
            // 
            this.exportSelectedMenuItem.Name = "exportSelectedMenuItem";
            this.exportSelectedMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exportSelectedMenuItem.Text = "Seçili Siparişi Aktar";
            this.exportSelectedMenuItem.Click += new System.EventHandler(this.exportSelectedMenuItem_Click);
            // 
            // exportAllMenuItem
            // 
            this.exportAllMenuItem.Name = "exportAllMenuItem";
            this.exportAllMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exportAllMenuItem.Text = "Tüm Siparişleri Aktar";
            this.exportAllMenuItem.Click += new System.EventHandler(this.exportAllMenuItem_Click);
            // 
            // exportFilteredMenuItem
            // 
            this.exportFilteredMenuItem.Name = "exportFilteredMenuItem";
            this.exportFilteredMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exportFilteredMenuItem.Text = "Filtrelenmiş Sonuçları Aktar";
            this.exportFilteredMenuItem.Click += new System.EventHandler(this.exportFilteredMenuItem_Click);
            // 
            // OrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1342, 900);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.minimanizeLabel);
            this.Controls.Add(this.closeLabel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrderListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sipariş Listesi\n\n";
            this.Load += new System.EventHandler(this.OrderListForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OrderListForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.contextExportMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnRefreshOrders;
        private System.Windows.Forms.Button btnRefreshDetails;
        private System.Windows.Forms.Button btnDeleteOrderDetail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTotalIn;
        private System.Windows.Forms.Label lblTotalOut;
        private System.Windows.Forms.Label lblNetStock;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMarketplace;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ContextMenuStrip contextExportMenu;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFilteredMenuItem;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Button btnEditOrderDetail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
    }
}