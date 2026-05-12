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
            panelHeader = new System.Windows.Forms.Panel();
            labelAppName = new System.Windows.Forms.Label();
            panelCard = new System.Windows.Forms.Panel();
            labelTitle = new System.Windows.Forms.Label();
            labelSubtitle = new System.Windows.Forms.Label();
            labelUsername = new System.Windows.Forms.Label();
            textBoxUsername = new System.Windows.Forms.TextBox();
            labelPassword = new System.Windows.Forms.Label();
            textBoxPassword = new System.Windows.Forms.TextBox();
            buttonLogin = new System.Windows.Forms.Button();
            buttonExit = new System.Windows.Forms.Button();
            buttonRegister = new System.Windows.Forms.Button();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            SuspendLayout();

            panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            panelHeader.Controls.Add(labelAppName);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(900, 80);
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
            panelCard.Controls.Add(buttonExit);
            panelCard.Controls.Add(buttonRegister);
            panelCard.Controls.Add(buttonLogin);
            panelCard.Controls.Add(textBoxPassword);
            panelCard.Controls.Add(labelPassword);
            panelCard.Controls.Add(textBoxUsername);
            panelCard.Controls.Add(labelUsername);
            panelCard.Controls.Add(labelSubtitle);
            panelCard.Controls.Add(labelTitle);
            panelCard.Location = new System.Drawing.Point(240, 140);
            panelCard.Name = "panelCard";
            panelCard.Size = new System.Drawing.Size(420, 320);
            panelCard.TabIndex = 1;

            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelTitle.Location = new System.Drawing.Point(24, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(114, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Dang nhap";

            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelSubtitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelSubtitle.Location = new System.Drawing.Point(24, 54);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new System.Drawing.Size(182, 15);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "He thong quan ly nha thuoc";

            labelUsername.AutoSize = true;
            labelUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelUsername.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelUsername.Location = new System.Drawing.Point(24, 92);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new System.Drawing.Size(89, 15);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Ten dang nhap";

            textBoxUsername.BackColor = System.Drawing.Color.White;
            textBoxUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxUsername.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxUsername.Location = new System.Drawing.Point(24, 112);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new System.Drawing.Size(360, 25);
            textBoxUsername.TabIndex = 3;

            labelPassword.AutoSize = true;
            labelPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelPassword.Location = new System.Drawing.Point(24, 152);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new System.Drawing.Size(62, 15);
            labelPassword.TabIndex = 4;
            labelPassword.Text = "Mat khau";

            textBoxPassword.BackColor = System.Drawing.Color.White;
            textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            textBoxPassword.Location = new System.Drawing.Point(24, 172);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new System.Drawing.Size(360, 25);
            textBoxPassword.TabIndex = 5;
            textBoxPassword.UseSystemPasswordChar = true;

            buttonLogin.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonLogin.ForeColor = System.Drawing.Color.White;
            buttonLogin.Location = new System.Drawing.Point(24, 228);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new System.Drawing.Size(170, 36);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "Dang nhap";
            buttonLogin.UseVisualStyleBackColor = false;

            buttonRegister.BackColor = System.Drawing.Color.White;
            buttonRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 123, 255);
            buttonRegister.FlatAppearance.BorderSize = 1;
            buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonRegister.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            buttonRegister.Location = new System.Drawing.Point(24, 274);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new System.Drawing.Size(360, 34);
            buttonRegister.TabIndex = 7;
            buttonRegister.Text = "Dang ky tai khoan";
            buttonRegister.UseVisualStyleBackColor = false;

            buttonExit.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonExit.ForeColor = System.Drawing.Color.White;
            buttonExit.Location = new System.Drawing.Point(214, 228);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new System.Drawing.Size(170, 36);
            buttonExit.TabIndex = 8;
            buttonExit.Text = "Thoat";
            buttonExit.UseVisualStyleBackColor = false;

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            ClientSize = new System.Drawing.Size(900, 560);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Dang nhap";
            AcceptButton = buttonLogin;
            CancelButton = buttonExit;
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
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonRegister;
    }
}
