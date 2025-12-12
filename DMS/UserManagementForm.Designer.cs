namespace DMS
{
    partial class UserManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagementForm));
            this.btnLogout = new System.Windows.Forms.Button();
            this.minimanizeLabel = new System.Windows.Forms.Label();
            this.closeLabel = new System.Windows.Forms.Label();
            this.usersProfilePage = new System.Windows.Forms.TabControl();
            this.userProfilePage = new System.Windows.Forms.TabPage();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.lblConfirmPasswordStatus = new System.Windows.Forms.Label();
            this.lblNewPasswordStatus = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProfileNewPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProfileRegisterDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProfileAuthorityLevel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProfileDepartment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProfilePhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProfileEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProfileFullName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProfileConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.txtProfileCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtProfileUsername = new System.Windows.Forms.TextBox();
            this.allUsersProfilePage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblShowPassword = new System.Windows.Forms.Label();
            this.cmbUserAuthorityLevel = new System.Windows.Forms.ComboBox();
            this.lblUserConfirmPasswordStatus = new System.Windows.Forms.Label();
            this.lblUserNewPasswordStatus = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbUserDepartment = new System.Windows.Forms.ComboBox();
            this.txtUserConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtUserNewPassword = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUserCurrentPassword = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtUserPhone = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtUserUsername = new System.Windows.Forms.TextBox();
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAllUsers = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAuthorityLevel = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtUsernameOrEmail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.usersProfilePage.SuspendLayout();
            this.userProfilePage.SuspendLayout();
            this.allUsersProfilePage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllUsers)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnLogout.Location = new System.Drawing.Point(1327, 728);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(98, 29);
            this.btnLogout.TabIndex = 44;
            this.btnLogout.Text = "✖ Çıkış Yap";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // minimanizeLabel
            // 
            this.minimanizeLabel.AutoSize = true;
            this.minimanizeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimanizeLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.minimanizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.minimanizeLabel.Location = new System.Drawing.Point(1431, 9);
            this.minimanizeLabel.Name = "minimanizeLabel";
            this.minimanizeLabel.Size = new System.Drawing.Size(22, 25);
            this.minimanizeLabel.TabIndex = 42;
            this.minimanizeLabel.Text = "-";
            this.minimanizeLabel.Click += new System.EventHandler(this.minimanizeLabel_Click);
            // 
            // closeLabel
            // 
            this.closeLabel.AutoSize = true;
            this.closeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.closeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.closeLabel.Location = new System.Drawing.Point(1452, 9);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(28, 25);
            this.closeLabel.TabIndex = 41;
            this.closeLabel.Text = "X";
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            // 
            // usersProfilePage
            // 
            this.usersProfilePage.Controls.Add(this.userProfilePage);
            this.usersProfilePage.Controls.Add(this.allUsersProfilePage);
            this.usersProfilePage.Location = new System.Drawing.Point(516, 12);
            this.usersProfilePage.Name = "usersProfilePage";
            this.usersProfilePage.SelectedIndex = 0;
            this.usersProfilePage.Size = new System.Drawing.Size(909, 710);
            this.usersProfilePage.TabIndex = 45;
            this.usersProfilePage.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // userProfilePage
            // 
            this.userProfilePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.userProfilePage.Controls.Add(this.btnSaveProfile);
            this.userProfilePage.Controls.Add(this.lblConfirmPasswordStatus);
            this.userProfilePage.Controls.Add(this.lblNewPasswordStatus);
            this.userProfilePage.Controls.Add(this.label11);
            this.userProfilePage.Controls.Add(this.txtProfileNewPassword);
            this.userProfilePage.Controls.Add(this.label9);
            this.userProfilePage.Controls.Add(this.txtProfileRegisterDate);
            this.userProfilePage.Controls.Add(this.label8);
            this.userProfilePage.Controls.Add(this.txtProfileAuthorityLevel);
            this.userProfilePage.Controls.Add(this.label7);
            this.userProfilePage.Controls.Add(this.txtProfileDepartment);
            this.userProfilePage.Controls.Add(this.label6);
            this.userProfilePage.Controls.Add(this.txtProfilePhone);
            this.userProfilePage.Controls.Add(this.label5);
            this.userProfilePage.Controls.Add(this.txtProfileEmail);
            this.userProfilePage.Controls.Add(this.label10);
            this.userProfilePage.Controls.Add(this.txtProfileFullName);
            this.userProfilePage.Controls.Add(this.label3);
            this.userProfilePage.Controls.Add(this.label2);
            this.userProfilePage.Controls.Add(this.label4);
            this.userProfilePage.Controls.Add(this.txtProfileConfirmNewPassword);
            this.userProfilePage.Controls.Add(this.txtProfileCurrentPassword);
            this.userProfilePage.Controls.Add(this.txtProfileUsername);
            this.userProfilePage.Location = new System.Drawing.Point(4, 26);
            this.userProfilePage.Name = "userProfilePage";
            this.userProfilePage.Padding = new System.Windows.Forms.Padding(3);
            this.userProfilePage.Size = new System.Drawing.Size(901, 680);
            this.userProfilePage.TabIndex = 0;
            this.userProfilePage.Text = "Profilim";
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnSaveProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnSaveProfile.Location = new System.Drawing.Point(125, 325);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(199, 29);
            this.btnSaveProfile.TabIndex = 99;
            this.btnSaveProfile.Text = "✅ Bilgilerini Güncelle";
            this.btnSaveProfile.UseVisualStyleBackColor = false;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            // 
            // lblConfirmPasswordStatus
            // 
            this.lblConfirmPasswordStatus.AutoSize = true;
            this.lblConfirmPasswordStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.lblConfirmPasswordStatus.Location = new System.Drawing.Point(330, 102);
            this.lblConfirmPasswordStatus.Name = "lblConfirmPasswordStatus";
            this.lblConfirmPasswordStatus.Size = new System.Drawing.Size(0, 19);
            this.lblConfirmPasswordStatus.TabIndex = 98;
            // 
            // lblNewPasswordStatus
            // 
            this.lblNewPasswordStatus.AutoSize = true;
            this.lblNewPasswordStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.lblNewPasswordStatus.Location = new System.Drawing.Point(330, 71);
            this.lblNewPasswordStatus.Name = "lblNewPasswordStatus";
            this.lblNewPasswordStatus.Size = new System.Drawing.Size(0, 19);
            this.lblNewPasswordStatus.TabIndex = 97;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label11.Location = new System.Drawing.Point(47, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 19);
            this.label11.TabIndex = 96;
            this.label11.Text = "Yeni Şifre: ";
            // 
            // txtProfileNewPassword
            // 
            this.txtProfileNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfileNewPassword.Location = new System.Drawing.Point(124, 68);
            this.txtProfileNewPassword.Name = "txtProfileNewPassword";
            this.txtProfileNewPassword.PasswordChar = '*';
            this.txtProfileNewPassword.Size = new System.Drawing.Size(200, 25);
            this.txtProfileNewPassword.TabIndex = 95;
            this.txtProfileNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label9.Location = new System.Drawing.Point(37, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 19);
            this.label9.TabIndex = 94;
            this.label9.Text = "Kayıt Tarihi: ";
            // 
            // txtProfileRegisterDate
            // 
            this.txtProfileRegisterDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfileRegisterDate.Location = new System.Drawing.Point(124, 285);
            this.txtProfileRegisterDate.Name = "txtProfileRegisterDate";
            this.txtProfileRegisterDate.ReadOnly = true;
            this.txtProfileRegisterDate.Size = new System.Drawing.Size(200, 25);
            this.txtProfileRegisterDate.TabIndex = 93;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label8.Location = new System.Drawing.Point(22, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 19);
            this.label8.TabIndex = 92;
            this.label8.Text = "Yetki Seviyesi: ";
            // 
            // txtProfileAuthorityLevel
            // 
            this.txtProfileAuthorityLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfileAuthorityLevel.Location = new System.Drawing.Point(124, 254);
            this.txtProfileAuthorityLevel.Name = "txtProfileAuthorityLevel";
            this.txtProfileAuthorityLevel.ReadOnly = true;
            this.txtProfileAuthorityLevel.Size = new System.Drawing.Size(200, 25);
            this.txtProfileAuthorityLevel.TabIndex = 91;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label7.Location = new System.Drawing.Point(33, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 90;
            this.label7.Text = "Departman: ";
            // 
            // txtProfileDepartment
            // 
            this.txtProfileDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfileDepartment.Location = new System.Drawing.Point(124, 223);
            this.txtProfileDepartment.Name = "txtProfileDepartment";
            this.txtProfileDepartment.ReadOnly = true;
            this.txtProfileDepartment.Size = new System.Drawing.Size(200, 25);
            this.txtProfileDepartment.TabIndex = 89;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label6.Location = new System.Drawing.Point(59, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 19);
            this.label6.TabIndex = 88;
            this.label6.Text = "Telefon: ";
            // 
            // txtProfilePhone
            // 
            this.txtProfilePhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfilePhone.Location = new System.Drawing.Point(124, 192);
            this.txtProfilePhone.Name = "txtProfilePhone";
            this.txtProfilePhone.Size = new System.Drawing.Size(200, 25);
            this.txtProfilePhone.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(55, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 19);
            this.label5.TabIndex = 86;
            this.label5.Text = "E-posta: ";
            // 
            // txtProfileEmail
            // 
            this.txtProfileEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfileEmail.Location = new System.Drawing.Point(124, 161);
            this.txtProfileEmail.Name = "txtProfileEmail";
            this.txtProfileEmail.Size = new System.Drawing.Size(200, 25);
            this.txtProfileEmail.TabIndex = 85;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label10.Location = new System.Drawing.Point(43, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 19);
            this.label10.TabIndex = 84;
            this.label10.Text = "Ad/Soyad: ";
            // 
            // txtProfileFullName
            // 
            this.txtProfileFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfileFullName.Location = new System.Drawing.Point(124, 130);
            this.txtProfileFullName.Name = "txtProfileFullName";
            this.txtProfileFullName.Size = new System.Drawing.Size(200, 25);
            this.txtProfileFullName.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label3.Location = new System.Drawing.Point(30, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 82;
            this.label3.Text = "Mevcut Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(31, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 81;
            this.label2.Text = "Kullanıcı adı: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 80;
            this.label4.Text = "Yeni Şifre Tekrar: ";
            // 
            // txtProfileConfirmNewPassword
            // 
            this.txtProfileConfirmNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfileConfirmNewPassword.Location = new System.Drawing.Point(124, 99);
            this.txtProfileConfirmNewPassword.Name = "txtProfileConfirmNewPassword";
            this.txtProfileConfirmNewPassword.PasswordChar = '*';
            this.txtProfileConfirmNewPassword.Size = new System.Drawing.Size(200, 25);
            this.txtProfileConfirmNewPassword.TabIndex = 79;
            this.txtProfileConfirmNewPassword.TextChanged += new System.EventHandler(this.txtConfirmNewPassword_TextChanged);
            // 
            // txtProfileCurrentPassword
            // 
            this.txtProfileCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfileCurrentPassword.Location = new System.Drawing.Point(124, 37);
            this.txtProfileCurrentPassword.Name = "txtProfileCurrentPassword";
            this.txtProfileCurrentPassword.PasswordChar = '*';
            this.txtProfileCurrentPassword.Size = new System.Drawing.Size(200, 25);
            this.txtProfileCurrentPassword.TabIndex = 78;
            // 
            // txtProfileUsername
            // 
            this.txtProfileUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtProfileUsername.Location = new System.Drawing.Point(124, 6);
            this.txtProfileUsername.Name = "txtProfileUsername";
            this.txtProfileUsername.Size = new System.Drawing.Size(200, 25);
            this.txtProfileUsername.TabIndex = 77;
            // 
            // allUsersProfilePage
            // 
            this.allUsersProfilePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.allUsersProfilePage.Controls.Add(this.groupBox3);
            this.allUsersProfilePage.Controls.Add(this.groupBox2);
            this.allUsersProfilePage.Controls.Add(this.groupBox1);
            this.allUsersProfilePage.Location = new System.Drawing.Point(4, 26);
            this.allUsersProfilePage.Name = "allUsersProfilePage";
            this.allUsersProfilePage.Padding = new System.Windows.Forms.Padding(3);
            this.allUsersProfilePage.Size = new System.Drawing.Size(901, 680);
            this.allUsersProfilePage.TabIndex = 1;
            this.allUsersProfilePage.Text = "Tüm Kullanıcılar";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblShowPassword);
            this.groupBox3.Controls.Add(this.cmbUserAuthorityLevel);
            this.groupBox3.Controls.Add(this.lblUserConfirmPasswordStatus);
            this.groupBox3.Controls.Add(this.lblUserNewPasswordStatus);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.cmbUserDepartment);
            this.groupBox3.Controls.Add(this.txtUserConfirmNewPassword);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtUserNewPassword);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtUserCurrentPassword);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.txtUserPhone);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtUserEmail);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txtUserUsername);
            this.groupBox3.Controls.Add(this.txtUserFullName);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.groupBox3.Location = new System.Drawing.Point(398, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 375);
            this.groupBox3.TabIndex = 89;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "🙍‍♂️ Kullanıcı Paneli";
            // 
            // lblShowPassword
            // 
            this.lblShowPassword.AutoSize = true;
            this.lblShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowPassword.Location = new System.Drawing.Point(351, 145);
            this.lblShowPassword.Name = "lblShowPassword";
            this.lblShowPassword.Size = new System.Drawing.Size(28, 19);
            this.lblShowPassword.TabIndex = 103;
            this.lblShowPassword.Text = "🙈";
            this.lblShowPassword.Click += new System.EventHandler(this.lblShowPassword_Click);
            // 
            // cmbUserAuthorityLevel
            // 
            this.cmbUserAuthorityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserAuthorityLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUserAuthorityLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.cmbUserAuthorityLevel.FormattingEnabled = true;
            this.cmbUserAuthorityLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbUserAuthorityLevel.Location = new System.Drawing.Point(122, 266);
            this.cmbUserAuthorityLevel.Name = "cmbUserAuthorityLevel";
            this.cmbUserAuthorityLevel.Size = new System.Drawing.Size(226, 25);
            this.cmbUserAuthorityLevel.TabIndex = 91;
            // 
            // lblUserConfirmPasswordStatus
            // 
            this.lblUserConfirmPasswordStatus.AutoSize = true;
            this.lblUserConfirmPasswordStatus.Location = new System.Drawing.Point(351, 207);
            this.lblUserConfirmPasswordStatus.Name = "lblUserConfirmPasswordStatus";
            this.lblUserConfirmPasswordStatus.Size = new System.Drawing.Size(0, 19);
            this.lblUserConfirmPasswordStatus.TabIndex = 102;
            // 
            // lblUserNewPasswordStatus
            // 
            this.lblUserNewPasswordStatus.AutoSize = true;
            this.lblUserNewPasswordStatus.Location = new System.Drawing.Point(351, 176);
            this.lblUserNewPasswordStatus.Name = "lblUserNewPasswordStatus";
            this.lblUserNewPasswordStatus.Size = new System.Drawing.Size(0, 19);
            this.lblUserNewPasswordStatus.TabIndex = 101;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 207);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(110, 19);
            this.label24.TabIndex = 100;
            this.label24.Text = "Yeni şifre tekrar: ";
            // 
            // cmbUserDepartment
            // 
            this.cmbUserDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUserDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.cmbUserDepartment.FormattingEnabled = true;
            this.cmbUserDepartment.Items.AddRange(new object[] {
            "Teknisyen",
            "Depo Görevlisi",
            "Müdür",
            "Yönetici",
            "Admin"});
            this.cmbUserDepartment.Location = new System.Drawing.Point(122, 235);
            this.cmbUserDepartment.Name = "cmbUserDepartment";
            this.cmbUserDepartment.Size = new System.Drawing.Size(226, 25);
            this.cmbUserDepartment.TabIndex = 90;
            // 
            // txtUserConfirmNewPassword
            // 
            this.txtUserConfirmNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtUserConfirmNewPassword.Location = new System.Drawing.Point(122, 204);
            this.txtUserConfirmNewPassword.Name = "txtUserConfirmNewPassword";
            this.txtUserConfirmNewPassword.Size = new System.Drawing.Size(226, 25);
            this.txtUserConfirmNewPassword.TabIndex = 99;
            this.txtUserConfirmNewPassword.TextChanged += new System.EventHandler(this.txtUserConfirmNewPassword_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(46, 176);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 19);
            this.label23.TabIndex = 98;
            this.label23.Text = "Yeni şifre: ";
            // 
            // txtUserNewPassword
            // 
            this.txtUserNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtUserNewPassword.Location = new System.Drawing.Point(122, 173);
            this.txtUserNewPassword.Name = "txtUserNewPassword";
            this.txtUserNewPassword.Size = new System.Drawing.Size(226, 25);
            this.txtUserNewPassword.TabIndex = 97;
            this.txtUserNewPassword.TextChanged += new System.EventHandler(this.txtUserNewPassword_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(74, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 19);
            this.label16.TabIndex = 96;
            this.label16.Text = "Şifre: ";
            // 
            // txtUserCurrentPassword
            // 
            this.txtUserCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtUserCurrentPassword.Location = new System.Drawing.Point(122, 142);
            this.txtUserCurrentPassword.Name = "txtUserCurrentPassword";
            this.txtUserCurrentPassword.Size = new System.Drawing.Size(226, 25);
            this.txtUserCurrentPassword.TabIndex = 95;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnDelete.Location = new System.Drawing.Point(122, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(226, 29);
            this.btnDelete.TabIndex = 94;
            this.btnDelete.Text = "🗑 Kullanıcıyı Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnUpdate.Location = new System.Drawing.Point(122, 297);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(226, 29);
            this.btnUpdate.TabIndex = 93;
            this.btnUpdate.Text = "✅ Kullanıcı Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(57, 114);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 19);
            this.label22.TabIndex = 92;
            this.label22.Text = "Telefon: ";
            // 
            // txtUserPhone
            // 
            this.txtUserPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtUserPhone.Location = new System.Drawing.Point(122, 111);
            this.txtUserPhone.Name = "txtUserPhone";
            this.txtUserPhone.Size = new System.Drawing.Size(226, 25);
            this.txtUserPhone.TabIndex = 91;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(53, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 19);
            this.label21.TabIndex = 90;
            this.label21.Text = "E-posta: ";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtUserEmail.Location = new System.Drawing.Point(122, 80);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(226, 25);
            this.txtUserEmail.TabIndex = 89;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(29, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 19);
            this.label20.TabIndex = 88;
            this.label20.Text = "Kullanıcı adı: ";
            // 
            // txtUserUsername
            // 
            this.txtUserUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtUserUsername.Location = new System.Drawing.Point(122, 49);
            this.txtUserUsername.Name = "txtUserUsername";
            this.txtUserUsername.Size = new System.Drawing.Size(226, 25);
            this.txtUserUsername.TabIndex = 87;
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtUserFullName.Location = new System.Drawing.Point(122, 18);
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Size = new System.Drawing.Size(226, 25);
            this.txtUserFullName.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 269);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 19);
            this.label17.TabIndex = 84;
            this.label17.Text = "Yetki seviyesi: ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(40, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 19);
            this.label18.TabIndex = 82;
            this.label18.Text = "Ad-Soyad: ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(31, 238);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 19);
            this.label19.TabIndex = 83;
            this.label19.Text = "Departman: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAllUsers);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.groupBox2.Location = new System.Drawing.Point(10, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(885, 285);
            this.groupBox2.TabIndex = 88;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "👫 Kullanıcılar Listesi";
            // 
            // dgvAllUsers
            // 
            this.dgvAllUsers.AllowUserToAddRows = false;
            this.dgvAllUsers.AllowUserToDeleteRows = false;
            this.dgvAllUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.dgvAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllUsers.Location = new System.Drawing.Point(6, 24);
            this.dgvAllUsers.Name = "dgvAllUsers";
            this.dgvAllUsers.ReadOnly = true;
            this.dgvAllUsers.Size = new System.Drawing.Size(873, 255);
            this.dgvAllUsers.TabIndex = 0;
            this.dgvAllUsers.SelectionChanged += new System.EventHandler(this.dgvAllUsers_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAuthorityLevel);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.cmbDepartment);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtUsernameOrEmail);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 181);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "🔍 Arama Paneli";
            // 
            // cmbAuthorityLevel
            // 
            this.cmbAuthorityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthorityLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAuthorityLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.cmbAuthorityLevel.FormattingEnabled = true;
            this.cmbAuthorityLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbAuthorityLevel.Location = new System.Drawing.Point(151, 111);
            this.cmbAuthorityLevel.Name = "cmbAuthorityLevel";
            this.cmbAuthorityLevel.Size = new System.Drawing.Size(226, 25);
            this.cmbAuthorityLevel.TabIndex = 93;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnClear.Location = new System.Drawing.Point(267, 142);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 29);
            this.btnClear.TabIndex = 88;
            this.btnClear.Text = "🧹 Temizle";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Items.AddRange(new object[] {
            "Teknisyen",
            "Depo Görevlisi",
            "Müdür",
            "Yönetici",
            "Admin"});
            this.cmbDepartment.Location = new System.Drawing.Point(151, 80);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(226, 25);
            this.cmbDepartment.TabIndex = 92;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnSearch.Location = new System.Drawing.Point(151, 142);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 29);
            this.btnSearch.TabIndex = 87;
            this.btnSearch.Text = "🔍 Arama Yap";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtUsernameOrEmail
            // 
            this.txtUsernameOrEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtUsernameOrEmail.Location = new System.Drawing.Point(151, 18);
            this.txtUsernameOrEmail.Name = "txtUsernameOrEmail";
            this.txtUsernameOrEmail.Size = new System.Drawing.Size(226, 25);
            this.txtUsernameOrEmail.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(69, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 19);
            this.label15.TabIndex = 86;
            this.label15.Text = "Ad-Soyad: ";
            // 
            // txtFullName
            // 
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtFullName.Location = new System.Drawing.Point(151, 49);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(226, 25);
            this.txtFullName.TabIndex = 85;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 19);
            this.label14.TabIndex = 84;
            this.label14.Text = "Yetki seviyesi: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 19);
            this.label12.TabIndex = 82;
            this.label12.Text = "Kullanıcı adı/E-posta: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 19);
            this.label13.TabIndex = 83;
            this.label13.Text = "Departman: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(86, 590);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 57);
            this.label1.TabIndex = 46;
            this.label1.Text = "Bu program SELÇUK ŞAHİN tarafından geliştirilmiştir.\r\nHerhangi bir arıza, öneri, " +
    "şikayet için.\r\nselcuksahin158@gmail.com\'a mail gönderebilirsiniz.\r\n";
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnMainMenu.Location = new System.Drawing.Point(1216, 728);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(105, 29);
            this.btnMainMenu.TabIndex = 67;
            this.btnMainMenu.Text = "🏠 Ana Menü";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::DMS.Properties.Resources.WareHouseManagamentSystem;
            this.logoPictureBox.Location = new System.Drawing.Point(10, 84);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(500, 500);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 43;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logoPictureBox_MouseDown);
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1492, 771);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usersProfilePage);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.minimanizeLabel);
            this.Controls.Add(this.closeLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.UserManagementForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserManagementForm_MouseDown);
            this.usersProfilePage.ResumeLayout(false);
            this.userProfilePage.ResumeLayout(false);
            this.userProfilePage.PerformLayout();
            this.allUsersProfilePage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllUsers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label minimanizeLabel;
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.TabControl usersProfilePage;
        private System.Windows.Forms.TabPage userProfilePage;
        private System.Windows.Forms.TabPage allUsersProfilePage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProfileFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProfileConfirmNewPassword;
        private System.Windows.Forms.TextBox txtProfileCurrentPassword;
        private System.Windows.Forms.TextBox txtProfileUsername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProfileDepartment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProfilePhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProfileEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProfileRegisterDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProfileAuthorityLevel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProfileNewPassword;
        private System.Windows.Forms.Label lblNewPasswordStatus;
        private System.Windows.Forms.Label lblConfirmPasswordStatus;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.TextBox txtUsernameOrEmail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAllUsers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtUserFullName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtUserEmail;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtUserUsername;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtUserPhone;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtUserCurrentPassword;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtUserConfirmNewPassword;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtUserNewPassword;
        private System.Windows.Forms.Label lblUserConfirmPasswordStatus;
        private System.Windows.Forms.Label lblUserNewPasswordStatus;
        private System.Windows.Forms.ComboBox cmbUserAuthorityLevel;
        private System.Windows.Forms.ComboBox cmbUserDepartment;
        private System.Windows.Forms.ComboBox cmbAuthorityLevel;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblShowPassword;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}