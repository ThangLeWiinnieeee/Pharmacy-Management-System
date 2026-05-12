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
            panelHeader = new System.Windows.Forms.Panel();
            labelAppName = new System.Windows.Forms.Label();
            panelCard = new System.Windows.Forms.Panel();
            labelTitle = new System.Windows.Forms.Label();
            labelSubtitle = new System.Windows.Forms.Label();
            labelFullName = new System.Windows.Forms.Label();
            textBoxFullName = new System.Windows.Forms.TextBox();
            labelPhone = new System.Windows.Forms.Label();
            textBoxPhone = new System.Windows.Forms.TextBox();
            labelEmail = new System.Windows.Forms.Label();
            textBoxEmail = new System.Windows.Forms.TextBox();
            labelUsername = new System.Windows.Forms.Label();
            textBoxUsername = new System.Windows.Forms.TextBox();
            labelPassword = new System.Windows.Forms.Label();
            textBoxPassword = new System.Windows.Forms.TextBox();
            labelConfirmPassword = new System.Windows.Forms.Label();
            textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            buttonRegister = new System.Windows.Forms.Button();
            buttonBack = new System.Windows.Forms.Button();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            SuspendLayout();

            panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            panelHeader.Controls.Add(labelAppName);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(980, 80);
            panelHeader.TabIndex = 0;

            labelAppName.AutoSize = true;
            labelAppName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelAppName.ForeColor = System.Drawing.Color.White;
            labelAppName.Location = new System.Drawing.Point(24, 22);
            labelAppName.Name = "labelAppName";
            labelAppName.Size = new System.Drawing.Size(255, 30);
            labelAppName.TabIndex = 0;
            labelAppName.Text = "Pharmacy Management";

            panelCard.BackColor = System.Drawing.Color.White;
            panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            panelCard.Location = new System.Drawing.Point(230, 130);
            panelCard.Name = "panelCard";
            panelCard.Size = new System.Drawing.Size(520, 520);
            panelCard.TabIndex = 1;

            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelTitle.Location = new System.Drawing.Point(24, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(86, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Dang ky";

            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelSubtitle.Location = new System.Drawing.Point(24, 54);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new System.Drawing.Size(164, 15);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Tao tai khoan khach hang";

            labelFullName.AutoSize = true;
            labelFullName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelFullName.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelFullName.Location = new System.Drawing.Point(24, 90);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new System.Drawing.Size(44, 15);
            labelFullName.TabIndex = 2;
            labelFullName.Text = "Ho ten";

            textBoxFullName.BackColor = System.Drawing.Color.White;
            textBoxFullName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFullName.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxFullName.Location = new System.Drawing.Point(24, 110);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new System.Drawing.Size(472, 25);
            textBoxFullName.TabIndex = 3;

            labelPhone.AutoSize = true;
            labelPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPhone.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelPhone.Location = new System.Drawing.Point(24, 145);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new System.Drawing.Size(77, 15);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "So dien thoai";

            textBoxPhone.BackColor = System.Drawing.Color.White;
            textBoxPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPhone.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxPhone.Location = new System.Drawing.Point(24, 165);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new System.Drawing.Size(472, 25);
            textBoxPhone.TabIndex = 5;

            labelEmail.AutoSize = true;
            labelEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelEmail.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelEmail.Location = new System.Drawing.Point(24, 200);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new System.Drawing.Size(38, 15);
            labelEmail.TabIndex = 6;
            labelEmail.Text = "Email";

            textBoxEmail.BackColor = System.Drawing.Color.White;
            textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxEmail.Location = new System.Drawing.Point(24, 220);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new System.Drawing.Size(472, 25);
            textBoxEmail.TabIndex = 7;

            labelUsername.AutoSize = true;
            labelUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUsername.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelUsername.Location = new System.Drawing.Point(24, 255);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new System.Drawing.Size(89, 15);
            labelUsername.TabIndex = 8;
            labelUsername.Text = "Ten dang nhap";

            textBoxUsername.BackColor = System.Drawing.Color.White;
            textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxUsername.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxUsername.Location = new System.Drawing.Point(24, 275);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new System.Drawing.Size(472, 25);
            textBoxUsername.TabIndex = 9;

            labelPassword.AutoSize = true;
            labelPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelPassword.Location = new System.Drawing.Point(24, 310);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(62, 15);
            labelPassword.TabIndex = 10;
            labelPassword.Text = "Mat khau";

            textBoxPassword.BackColor = System.Drawing.Color.White;
            textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxPassword.Location = new System.Drawing.Point(24, 330);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new System.Drawing.Size(472, 25);
            textBoxPassword.TabIndex = 11;
            textBoxPassword.UseSystemPasswordChar = true;

            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelConfirmPassword.Location = new System.Drawing.Point(24, 365);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new System.Drawing.Size(106, 15);
            labelConfirmPassword.TabIndex = 12;
            labelConfirmPassword.Text = "Nhap lai mat khau";

            textBoxConfirmPassword.BackColor = System.Drawing.Color.White;
            textBoxConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxConfirmPassword.Location = new System.Drawing.Point(24, 385);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new System.Drawing.Size(472, 25);
            textBoxConfirmPassword.TabIndex = 13;
            textBoxConfirmPassword.UseSystemPasswordChar = true;

            buttonRegister.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonRegister.ForeColor = System.Drawing.Color.White;
            buttonRegister.Location = new System.Drawing.Point(24, 430);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new System.Drawing.Size(220, 36);
            buttonRegister.TabIndex = 14;
            buttonRegister.Text = "Dang ky";
            buttonRegister.UseVisualStyleBackColor = false;

            buttonBack.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            buttonBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonBack.ForeColor = System.Drawing.Color.White;
            buttonBack.Location = new System.Drawing.Point(276, 430);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new System.Drawing.Size(220, 36);
            buttonBack.TabIndex = 15;
            buttonBack.Text = "Quay lai";
            buttonBack.UseVisualStyleBackColor = false;

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            ClientSize = new System.Drawing.Size(980, 700);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Dang ky";
            AcceptButton = buttonRegister;
            CancelButton = buttonBack;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonBack;
    }
}
