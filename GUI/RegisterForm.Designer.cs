namespace PharmacyManagementSystem
{
    partial class RegisterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelHero = new System.Windows.Forms.Panel();
            labelHeroNote = new System.Windows.Forms.Label();
            labelHeroSubtitle = new System.Windows.Forms.Label();
            labelHeroTitle = new System.Windows.Forms.Label();
            panelContent = new System.Windows.Forms.Panel();
            panelCard = new RoundedPanel();
            buttonBack = new RoundedButton();
            buttonRegister = new RoundedButton();
            textBoxConfirmPassword = new RoundedTextBox();
            labelConfirmPassword = new System.Windows.Forms.Label();
            textBoxPassword = new RoundedTextBox();
            labelPassword = new System.Windows.Forms.Label();
            textBoxUsername = new RoundedTextBox();
            labelUsername = new System.Windows.Forms.Label();
            textBoxEmail = new RoundedTextBox();
            labelEmail = new System.Windows.Forms.Label();
            textBoxPhone = new RoundedTextBox();
            labelPhone = new System.Windows.Forms.Label();
            textBoxFullName = new RoundedTextBox();
            labelFullName = new System.Windows.Forms.Label();
            labelSubtitle = new System.Windows.Forms.Label();
            labelTitle = new System.Windows.Forms.Label();
            panelHero.SuspendLayout();
            panelContent.SuspendLayout();
            panelCard.SuspendLayout();
            SuspendLayout();

            panelHero.BackColor = System.Drawing.Color.FromArgb(0, 86, 179);
            panelHero.Controls.Add(labelHeroNote);
            panelHero.Controls.Add(labelHeroSubtitle);
            panelHero.Controls.Add(labelHeroTitle);
            panelHero.Dock = System.Windows.Forms.DockStyle.Left;
            panelHero.Location = new System.Drawing.Point(0, 0);
            panelHero.Name = "panelHero";
            panelHero.Padding = new System.Windows.Forms.Padding(36);
            panelHero.Size = new System.Drawing.Size(360, 720);
            panelHero.TabIndex = 0;

            labelHeroNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelHeroNote.ForeColor = System.Drawing.Color.FromArgb(224, 239, 255);
            labelHeroNote.Location = new System.Drawing.Point(40, 602);
            labelHeroNote.Name = "labelHeroNote";
            labelHeroNote.Size = new System.Drawing.Size(270, 62);
            labelHeroNote.TabIndex = 2;
            labelHeroNote.Text = "Tài khoản nhân viên giúp quản lý dữ liệu và thao tác bán hàng trong hệ thống.";

            labelHeroSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelHeroSubtitle.ForeColor = System.Drawing.Color.White;
            labelHeroSubtitle.Location = new System.Drawing.Point(40, 194);
            labelHeroSubtitle.Name = "labelHeroSubtitle";
            labelHeroSubtitle.Size = new System.Drawing.Size(270, 72);
            labelHeroSubtitle.TabIndex = 1;
            labelHeroSubtitle.Text = "Tạo tài khoản nhân viên mới với thông tin cần thiết cho nhà thuốc.";

            labelHeroTitle.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeroTitle.ForeColor = System.Drawing.Color.White;
            labelHeroTitle.Location = new System.Drawing.Point(36, 92);
            labelHeroTitle.Name = "labelHeroTitle";
            labelHeroTitle.Size = new System.Drawing.Size(288, 96);
            labelHeroTitle.TabIndex = 0;
            labelHeroTitle.Text = "Đăng ký\r\ntài khoản";

            panelContent.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelContent.Controls.Add(panelCard);
            panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContent.Location = new System.Drawing.Point(360, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new System.Drawing.Size(680, 720);
            panelContent.TabIndex = 1;

            panelCard.BackColor = System.Drawing.Color.White;
            panelCard.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            panelCard.BorderRadius = 22;
            panelCard.BorderSize = 1;
            panelCard.Controls.Add(buttonBack);
            panelCard.Controls.Add(buttonRegister);
            panelCard.Controls.Add(textBoxConfirmPassword);
            panelCard.Controls.Add(labelConfirmPassword);
            panelCard.Controls.Add(textBoxPassword);
            panelCard.Controls.Add(labelPassword);
            panelCard.Controls.Add(textBoxUsername);
            panelCard.Controls.Add(labelUsername);
            panelCard.Controls.Add(textBoxEmail);
            panelCard.Controls.Add(labelEmail);
            panelCard.Controls.Add(textBoxPhone);
            panelCard.Controls.Add(labelPhone);
            panelCard.Controls.Add(textBoxFullName);
            panelCard.Controls.Add(labelFullName);
            panelCard.Controls.Add(labelSubtitle);
            panelCard.Controls.Add(labelTitle);
            panelCard.Location = new System.Drawing.Point(80, 56);
            panelCard.Name = "panelCard";
            panelCard.Size = new System.Drawing.Size(520, 608);
            panelCard.TabIndex = 0;

            buttonBack.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            buttonBack.BorderRadius = 12;
            buttonBack.BorderSize = 0;
            buttonBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonBack.ForeColor = System.Drawing.Color.White;
            buttonBack.HoverBackColor = System.Drawing.Color.FromArgb(200, 35, 51);
            buttonBack.Location = new System.Drawing.Point(274, 536);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new System.Drawing.Size(214, 40);
            buttonBack.TabIndex = 15;
            buttonBack.Text = "Quay lại";
            buttonBack.UseVisualStyleBackColor = false;

            buttonRegister.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            buttonRegister.BorderRadius = 12;
            buttonRegister.BorderSize = 0;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonRegister.ForeColor = System.Drawing.Color.White;
            buttonRegister.HoverBackColor = System.Drawing.Color.FromArgb(0, 103, 215);
            buttonRegister.Location = new System.Drawing.Point(32, 536);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new System.Drawing.Size(214, 40);
            buttonRegister.TabIndex = 14;
            buttonRegister.Text = "Đăng ký";
            buttonRegister.UseVisualStyleBackColor = false;

            textBoxConfirmPassword.BackColor = System.Drawing.Color.White;
            textBoxConfirmPassword.BorderColor = System.Drawing.Color.FromArgb(170, 183, 196);
            textBoxConfirmPassword.BorderRadius = 12;
            textBoxConfirmPassword.FocusBackColor = System.Drawing.Color.FromArgb(248, 252, 255);
            textBoxConfirmPassword.FocusBorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            textBoxConfirmPassword.FocusBorderSize = 2;
            textBoxConfirmPassword.HoverBorderColor = System.Drawing.Color.FromArgb(104, 133, 163);
            textBoxConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxConfirmPassword.Location = new System.Drawing.Point(32, 478);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new System.Drawing.Size(456, 40);
            textBoxConfirmPassword.TabIndex = 13;
            textBoxConfirmPassword.UseSystemPasswordChar = true;

            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelConfirmPassword.Location = new System.Drawing.Point(32, 454);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new System.Drawing.Size(119, 17);
            labelConfirmPassword.TabIndex = 12;
            labelConfirmPassword.Text = "Nhập lại mật khẩu";

            textBoxPassword.BackColor = System.Drawing.Color.White;
            textBoxPassword.BorderColor = System.Drawing.Color.FromArgb(170, 183, 196);
            textBoxPassword.BorderRadius = 12;
            textBoxPassword.FocusBackColor = System.Drawing.Color.FromArgb(248, 252, 255);
            textBoxPassword.FocusBorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            textBoxPassword.FocusBorderSize = 2;
            textBoxPassword.HoverBorderColor = System.Drawing.Color.FromArgb(104, 133, 163);
            textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxPassword.Location = new System.Drawing.Point(32, 414);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new System.Drawing.Size(456, 40);
            textBoxPassword.TabIndex = 11;
            textBoxPassword.UseSystemPasswordChar = true;

            labelPassword.AutoSize = true;
            labelPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelPassword.Location = new System.Drawing.Point(32, 390);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(64, 17);
            labelPassword.TabIndex = 10;
            labelPassword.Text = "Mật khẩu";

            textBoxUsername.BackColor = System.Drawing.Color.White;
            textBoxUsername.BorderColor = System.Drawing.Color.FromArgb(170, 183, 196);
            textBoxUsername.BorderRadius = 12;
            textBoxUsername.FocusBackColor = System.Drawing.Color.FromArgb(248, 252, 255);
            textBoxUsername.FocusBorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            textBoxUsername.FocusBorderSize = 2;
            textBoxUsername.HoverBorderColor = System.Drawing.Color.FromArgb(104, 133, 163);
            textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxUsername.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxUsername.Location = new System.Drawing.Point(32, 350);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new System.Drawing.Size(456, 40);
            textBoxUsername.TabIndex = 9;

            labelUsername.AutoSize = true;
            labelUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUsername.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelUsername.Location = new System.Drawing.Point(32, 326);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new System.Drawing.Size(95, 17);
            labelUsername.TabIndex = 8;
            labelUsername.Text = "Tên đăng nhập";

            textBoxEmail.BackColor = System.Drawing.Color.White;
            textBoxEmail.BorderColor = System.Drawing.Color.FromArgb(170, 183, 196);
            textBoxEmail.BorderRadius = 12;
            textBoxEmail.FocusBackColor = System.Drawing.Color.FromArgb(248, 252, 255);
            textBoxEmail.FocusBorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            textBoxEmail.FocusBorderSize = 2;
            textBoxEmail.HoverBorderColor = System.Drawing.Color.FromArgb(104, 133, 163);
            textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxEmail.Location = new System.Drawing.Point(32, 286);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new System.Drawing.Size(456, 40);
            textBoxEmail.TabIndex = 7;

            labelEmail.AutoSize = true;
            labelEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelEmail.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelEmail.Location = new System.Drawing.Point(32, 262);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new System.Drawing.Size(41, 17);
            labelEmail.TabIndex = 6;
            labelEmail.Text = "Email";

            textBoxPhone.BackColor = System.Drawing.Color.White;
            textBoxPhone.BorderColor = System.Drawing.Color.FromArgb(170, 183, 196);
            textBoxPhone.BorderRadius = 12;
            textBoxPhone.FocusBackColor = System.Drawing.Color.FromArgb(248, 252, 255);
            textBoxPhone.FocusBorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            textBoxPhone.FocusBorderSize = 2;
            textBoxPhone.HoverBorderColor = System.Drawing.Color.FromArgb(104, 133, 163);
            textBoxPhone.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPhone.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxPhone.Location = new System.Drawing.Point(32, 222);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new System.Drawing.Size(456, 40);
            textBoxPhone.TabIndex = 5;

            labelPhone.AutoSize = true;
            labelPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPhone.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelPhone.Location = new System.Drawing.Point(32, 198);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new System.Drawing.Size(88, 17);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "Số điện thoại";

            textBoxFullName.BackColor = System.Drawing.Color.White;
            textBoxFullName.BorderColor = System.Drawing.Color.FromArgb(170, 183, 196);
            textBoxFullName.BorderRadius = 12;
            textBoxFullName.FocusBackColor = System.Drawing.Color.FromArgb(248, 252, 255);
            textBoxFullName.FocusBorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            textBoxFullName.FocusBorderSize = 2;
            textBoxFullName.HoverBorderColor = System.Drawing.Color.FromArgb(104, 133, 163);
            textBoxFullName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFullName.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxFullName.Location = new System.Drawing.Point(32, 158);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new System.Drawing.Size(456, 40);
            textBoxFullName.TabIndex = 3;

            labelFullName.AutoSize = true;
            labelFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelFullName.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelFullName.Location = new System.Drawing.Point(32, 134);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new System.Drawing.Size(48, 17);
            labelFullName.TabIndex = 2;
            labelFullName.Text = "Họ tên";

            labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelSubtitle.Location = new System.Drawing.Point(32, 70);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new System.Drawing.Size(456, 48);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Nhập thông tin nhân viên để tạo tài khoản mới.";

            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelTitle.Location = new System.Drawing.Point(32, 28);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(102, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Đăng ký";

            AcceptButton = buttonRegister;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            CancelButton = buttonBack;
            ClientSize = new System.Drawing.Size(1040, 720);
            Controls.Add(panelContent);
            Controls.Add(panelHero);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Đăng ký";
            panelHero.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHero;
        private System.Windows.Forms.Label labelHeroNote;
        private System.Windows.Forms.Label labelHeroSubtitle;
        private System.Windows.Forms.Label labelHeroTitle;
        private System.Windows.Forms.Panel panelContent;
        private RoundedPanel panelCard;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Label labelFullName;
        private RoundedTextBox textBoxFullName;
        private System.Windows.Forms.Label labelPhone;
        private RoundedTextBox textBoxPhone;
        private System.Windows.Forms.Label labelEmail;
        private RoundedTextBox textBoxEmail;
        private System.Windows.Forms.Label labelUsername;
        private RoundedTextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private RoundedTextBox textBoxPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private RoundedTextBox textBoxConfirmPassword;
        private RoundedButton buttonRegister;
        private RoundedButton buttonBack;
    }
}
