namespace DMS
{
    partial class LoginForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userNamePanel = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.minimanizeLabel = new System.Windows.Forms.Label();
            this.closeLabel = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.forgotPasswordLinkLabel = new System.Windows.Forms.LinkLabel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.lblShowPassword = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(506, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bu program SELÇUK ŞAHİN tarafından geliştirilmiştir.\r\nHerhangi bir arıza, öneri, " +
    "şikayet için.\r\nselcuksahin158@gmail.com\'a mail gönderebilirsiniz.\r\n";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtUsername.Location = new System.Drawing.Point(716, 210);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(264, 18);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Text = "Kullanıcı adı yada e-posta adresinizi giriniz";
            this.txtUsername.Enter += new System.EventHandler(this.userNameTxtBox_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.userNameTxtBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(506, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kullanıcı adı / e-posta adresiniz: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.label3.Location = new System.Drawing.Point(656, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parola: ";
            // 
            // userNamePanel
            // 
            this.userNamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.userNamePanel.Location = new System.Drawing.Point(716, 229);
            this.userNamePanel.Name = "userNamePanel";
            this.userNamePanel.Size = new System.Drawing.Size(264, 1);
            this.userNamePanel.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtPassword.Location = new System.Drawing.Point(716, 237);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(264, 18);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Text = "Parolanızı giriniz";
            this.txtPassword.Enter += new System.EventHandler(this.passwordTxtBox_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.passwordTxtBox_Leave);
            // 
            // passwordPanel
            // 
            this.passwordPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.passwordPanel.Location = new System.Drawing.Point(716, 257);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(264, 1);
            this.passwordPanel.TabIndex = 8;
            // 
            // minimanizeLabel
            // 
            this.minimanizeLabel.AutoSize = true;
            this.minimanizeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimanizeLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.minimanizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.minimanizeLabel.Location = new System.Drawing.Point(970, 9);
            this.minimanizeLabel.Name = "minimanizeLabel";
            this.minimanizeLabel.Size = new System.Drawing.Size(22, 25);
            this.minimanizeLabel.TabIndex = 12;
            this.minimanizeLabel.Text = "-";
            this.minimanizeLabel.Click += new System.EventHandler(this.minimanizeLabel_Click);
            // 
            // closeLabel
            // 
            this.closeLabel.AutoSize = true;
            this.closeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeLabel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.closeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.closeLabel.Location = new System.Drawing.Point(991, 9);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(28, 25);
            this.closeLabel.TabIndex = 11;
            this.closeLabel.Text = "X";
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnLogin.Location = new System.Drawing.Point(716, 264);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(98, 29);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // forgotPasswordLinkLabel
            // 
            this.forgotPasswordLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.forgotPasswordLinkLabel.AutoSize = true;
            this.forgotPasswordLinkLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.forgotPasswordLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.forgotPasswordLinkLabel.Location = new System.Drawing.Point(766, 296);
            this.forgotPasswordLinkLabel.Name = "forgotPasswordLinkLabel";
            this.forgotPasswordLinkLabel.Size = new System.Drawing.Size(160, 19);
            this.forgotPasswordLinkLabel.TabIndex = 18;
            this.forgotPasswordLinkLabel.TabStop = true;
            this.forgotPasswordLinkLabel.Text = "Parolanızı mı unuttunuz?";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(235)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.btnRegister.Location = new System.Drawing.Point(877, 264);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(103, 29);
            this.btnRegister.TabIndex = 20;
            this.btnRegister.Text = "Kayıt Ol";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(500, 500);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 19;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logoPictureBox_MouseDown);
            // 
            // lblShowPassword
            // 
            this.lblShowPassword.AutoSize = true;
            this.lblShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblShowPassword.Location = new System.Drawing.Point(986, 236);
            this.lblShowPassword.Name = "lblShowPassword";
            this.lblShowPassword.Size = new System.Drawing.Size(28, 19);
            this.lblShowPassword.TabIndex = 104;
            this.lblShowPassword.Text = "🙈";
            this.toolTip1.SetToolTip(this.lblShowPassword, "Şifreyi gizler veya gösterir.");
            this.lblShowPassword.Click += new System.EventHandler(this.lblShowPassword_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(252)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1031, 500);
            this.Controls.Add(this.lblShowPassword);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.forgotPasswordLinkLabel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.minimanizeLabel);
            this.Controls.Add(this.closeLabel);
            this.Controls.Add(this.passwordPanel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.userNamePanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Panel";
            this.Load += new System.EventHandler(this.loginPanel_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loginPanel_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel userNamePanel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.Label minimanizeLabel;
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel forgotPasswordLinkLabel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblShowPassword;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

