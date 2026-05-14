namespace PharmacyManagementSystem
{
    partial class LoginForm
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
            labelHelpText = new System.Windows.Forms.Label();
            buttonExit = new RoundedButton();
            buttonRegister = new RoundedButton();
            buttonLogin = new RoundedButton();
            textBoxPassword = new RoundedTextBox();
            labelPassword = new System.Windows.Forms.Label();
            textBoxUsername = new RoundedTextBox();
            labelUsername = new System.Windows.Forms.Label();
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
            panelHero.Size = new System.Drawing.Size(360, 620);
            panelHero.TabIndex = 0;

            labelHeroNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelHeroNote.ForeColor = System.Drawing.Color.FromArgb(224, 239, 255);
            labelHeroNote.Location = new System.Drawing.Point(40, 510);
            labelHeroNote.Name = "labelHeroNote";
            labelHeroNote.Size = new System.Drawing.Size(270, 60);
            labelHeroNote.TabIndex = 2;
            labelHeroNote.Text = "Theo dõi thuốc, nhân viên và hóa đơn trong cùng một hệ thống.";

            labelHeroSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelHeroSubtitle.ForeColor = System.Drawing.Color.White;
            labelHeroSubtitle.Location = new System.Drawing.Point(40, 194);
            labelHeroSubtitle.Name = "labelHeroSubtitle";
            labelHeroSubtitle.Size = new System.Drawing.Size(270, 72);
            labelHeroSubtitle.TabIndex = 1;
            labelHeroSubtitle.Text = "Đăng nhập để tiếp tục quản lý hoạt động bán hàng của nhà thuốc.";

            labelHeroTitle.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeroTitle.ForeColor = System.Drawing.Color.White;
            labelHeroTitle.Location = new System.Drawing.Point(36, 92);
            labelHeroTitle.Name = "labelHeroTitle";
            labelHeroTitle.Size = new System.Drawing.Size(288, 96);
            labelHeroTitle.TabIndex = 0;
            labelHeroTitle.Text = "Quản lý\r\nnhà thuốc";

            panelContent.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelContent.Controls.Add(panelCard);
            panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContent.Location = new System.Drawing.Point(360, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new System.Drawing.Size(600, 620);
            panelContent.TabIndex = 1;

            panelCard.BackColor = System.Drawing.Color.White;
            panelCard.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            panelCard.BorderRadius = 22;
            panelCard.BorderSize = 1;
            panelCard.Controls.Add(labelHelpText);
            panelCard.Controls.Add(buttonExit);
            panelCard.Controls.Add(buttonRegister);
            panelCard.Controls.Add(buttonLogin);
            panelCard.Controls.Add(textBoxPassword);
            panelCard.Controls.Add(labelPassword);
            panelCard.Controls.Add(textBoxUsername);
            panelCard.Controls.Add(labelUsername);
            panelCard.Controls.Add(labelSubtitle);
            panelCard.Controls.Add(labelTitle);
            panelCard.Location = new System.Drawing.Point(90, 90);
            panelCard.Name = "panelCard";
            panelCard.Size = new System.Drawing.Size(420, 448);
            panelCard.TabIndex = 0;

            labelHelpText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelHelpText.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelHelpText.Location = new System.Drawing.Point(32, 388);
            labelHelpText.Name = "labelHelpText";
            labelHelpText.Size = new System.Drawing.Size(356, 34);
            labelHelpText.TabIndex = 9;
            labelHelpText.Text = "Chưa có tài khoản? Chọn đăng ký để tạo tài khoản khách hàng.";
            labelHelpText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            buttonExit.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            buttonExit.BorderRadius = 12;
            buttonExit.BorderSize = 0;
            buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonExit.ForeColor = System.Drawing.Color.White;
            buttonExit.HoverBackColor = System.Drawing.Color.FromArgb(200, 35, 51);
            buttonExit.Location = new System.Drawing.Point(218, 302);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new System.Drawing.Size(170, 40);
            buttonExit.TabIndex = 7;
            buttonExit.Text = "Thoát";
            buttonExit.UseVisualStyleBackColor = false;

            buttonRegister.BackColor = System.Drawing.Color.White;
            buttonRegister.BorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            buttonRegister.BorderRadius = 12;
            buttonRegister.BorderSize = 1;
            buttonRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            buttonRegister.FlatAppearance.BorderSize = 1;
            buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonRegister.ForeColor = System.Drawing.Color.FromArgb(0, 86, 179);
            buttonRegister.HoverBackColor = System.Drawing.Color.FromArgb(235, 245, 255);
            buttonRegister.Location = new System.Drawing.Point(32, 350);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new System.Drawing.Size(356, 36);
            buttonRegister.TabIndex = 8;
            buttonRegister.Text = "Đăng ký tài khoản";
            buttonRegister.UseVisualStyleBackColor = false;

            buttonLogin.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            buttonLogin.BorderRadius = 12;
            buttonLogin.BorderSize = 0;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonLogin.ForeColor = System.Drawing.Color.White;
            buttonLogin.HoverBackColor = System.Drawing.Color.FromArgb(0, 103, 215);
            buttonLogin.Location = new System.Drawing.Point(32, 302);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new System.Drawing.Size(170, 40);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "Đăng nhập";
            buttonLogin.UseVisualStyleBackColor = false;

            textBoxPassword.BackColor = System.Drawing.Color.White;
            textBoxPassword.BorderColor = System.Drawing.Color.FromArgb(170, 183, 196);
            textBoxPassword.BorderRadius = 12;
            textBoxPassword.FocusBackColor = System.Drawing.Color.FromArgb(248, 252, 255);
            textBoxPassword.FocusBorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            textBoxPassword.FocusBorderSize = 2;
            textBoxPassword.HoverBorderColor = System.Drawing.Color.FromArgb(104, 133, 163);
            textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxPassword.Location = new System.Drawing.Point(32, 232);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new System.Drawing.Size(356, 40);
            textBoxPassword.TabIndex = 5;
            textBoxPassword.UseSystemPasswordChar = true;

            labelPassword.AutoSize = true;
            labelPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelPassword.Location = new System.Drawing.Point(32, 208);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(64, 17);
            labelPassword.TabIndex = 4;
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
            textBoxUsername.Location = new System.Drawing.Point(32, 150);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new System.Drawing.Size(356, 40);
            textBoxUsername.TabIndex = 3;

            labelUsername.AutoSize = true;
            labelUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUsername.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelUsername.Location = new System.Drawing.Point(32, 126);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new System.Drawing.Size(95, 17);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Tên đăng nhập";

            labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelSubtitle.Location = new System.Drawing.Point(32, 70);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new System.Drawing.Size(356, 42);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Nhập thông tin tài khoản để vào hệ thống.";

            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelTitle.Location = new System.Drawing.Point(32, 28);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(137, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Đăng nhập";

            AcceptButton = buttonLogin;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            CancelButton = buttonExit;
            ClientSize = new System.Drawing.Size(960, 620);
            Controls.Add(panelContent);
            Controls.Add(panelHero);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
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
        private System.Windows.Forms.Label labelHelpText;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Label labelUsername;
        private RoundedTextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private RoundedTextBox textBoxPassword;
        private RoundedButton buttonLogin;
        private RoundedButton buttonExit;
        private RoundedButton buttonRegister;
    }
}
