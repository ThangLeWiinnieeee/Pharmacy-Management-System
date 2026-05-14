namespace PharmacyManagementSystem
{
    partial class StaffHomeForm
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
            labelHeaderTitle = new System.Windows.Forms.Label();
            labelHeaderSubtitle = new System.Windows.Forms.Label();
            buttonLogout = new RoundedButton();
            panelContent = new System.Windows.Forms.Panel();
            panelSummary = new RoundedPanel();
            labelSummaryTitle = new System.Windows.Forms.Label();
            labelAccount = new System.Windows.Forms.Label();
            panelActions = new System.Windows.Forms.Panel();
            cardSearchMedicine = new RoundedPanel();
            accentSearchMedicine = new System.Windows.Forms.Panel();
            labelSearchMedicineTitle = new System.Windows.Forms.Label();
            labelSearchMedicineDescription = new System.Windows.Forms.Label();
            buttonSearchMedicineOpen = new RoundedButton();
            cardCreateInvoice = new RoundedPanel();
            accentCreateInvoice = new System.Windows.Forms.Panel();
            labelCreateInvoiceTitle = new System.Windows.Forms.Label();
            labelCreateInvoiceDescription = new System.Windows.Forms.Label();
            buttonCreateInvoiceOpen = new RoundedButton();
            cardInvoiceHistory = new RoundedPanel();
            accentInvoiceHistory = new System.Windows.Forms.Panel();
            labelInvoiceHistoryTitle = new System.Windows.Forms.Label();
            labelInvoiceHistoryDescription = new System.Windows.Forms.Label();
            buttonInvoiceHistoryOpen = new RoundedButton();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            panelSummary.SuspendLayout();
            panelActions.SuspendLayout();
            cardSearchMedicine.SuspendLayout();
            cardCreateInvoice.SuspendLayout();
            cardInvoiceHistory.SuspendLayout();
            SuspendLayout();

            panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 86, 179);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Controls.Add(labelHeaderSubtitle);
            panelHeader.Controls.Add(buttonLogout);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new System.Windows.Forms.Padding(28, 18, 28, 18);
            panelHeader.Size = new System.Drawing.Size(1000, 92);
            panelHeader.TabIndex = 0;

            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeaderTitle.ForeColor = System.Drawing.Color.White;
            labelHeaderTitle.Location = new System.Drawing.Point(28, 16);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new System.Drawing.Size(226, 32);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "Khu vực nhân viên";

            labelHeaderSubtitle.AutoSize = true;
            labelHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(224, 239, 255);
            labelHeaderSubtitle.Location = new System.Drawing.Point(31, 54);
            labelHeaderSubtitle.Name = "labelHeaderSubtitle";
            labelHeaderSubtitle.Size = new System.Drawing.Size(167, 17);
            labelHeaderSubtitle.TabIndex = 1;
            labelHeaderSubtitle.Text = "Xin chào, Staff | Vai trò";

            buttonLogout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonLogout.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            buttonLogout.BorderRadius = 12;
            buttonLogout.BorderSize = 0;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonLogout.ForeColor = System.Drawing.Color.FromArgb(0, 86, 179);
            buttonLogout.HoverBackColor = System.Drawing.Color.FromArgb(224, 239, 255);
            buttonLogout.Location = new System.Drawing.Point(846, 27);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new System.Drawing.Size(126, 38);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Đăng xuất";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += HandleLogoutClick;

            panelContent.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelContent.Controls.Add(panelActions);
            panelContent.Controls.Add(panelSummary);
            panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContent.Location = new System.Drawing.Point(0, 92);
            panelContent.Name = "panelContent";
            panelContent.Padding = new System.Windows.Forms.Padding(32);
            panelContent.Size = new System.Drawing.Size(1000, 548);
            panelContent.TabIndex = 1;

            panelSummary.BackColor = System.Drawing.Color.White;
            panelSummary.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            panelSummary.BorderRadius = 18;
            panelSummary.BorderSize = 1;
            panelSummary.Controls.Add(labelSummaryTitle);
            panelSummary.Controls.Add(labelAccount);
            panelSummary.Location = new System.Drawing.Point(32, 32);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new System.Drawing.Size(936, 132);
            panelSummary.TabIndex = 0;

            labelSummaryTitle.AutoSize = true;
            labelSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelSummaryTitle.Location = new System.Drawing.Point(28, 24);
            labelSummaryTitle.Name = "labelSummaryTitle";
            labelSummaryTitle.Size = new System.Drawing.Size(171, 31);
            labelSummaryTitle.TabIndex = 0;
            labelSummaryTitle.Text = "Quầy làm việc";

            labelAccount.AutoSize = true;
            labelAccount.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelAccount.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelAccount.Location = new System.Drawing.Point(31, 70);
            labelAccount.Name = "labelAccount";
            labelAccount.Size = new System.Drawing.Size(119, 19);
            labelAccount.TabIndex = 1;
            labelAccount.Text = "Tài khoản: staff";

            panelActions.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelActions.Controls.Add(cardSearchMedicine);
            panelActions.Controls.Add(cardCreateInvoice);
            panelActions.Controls.Add(cardInvoiceHistory);
            panelActions.Location = new System.Drawing.Point(32, 196);
            panelActions.Name = "panelActions";
            panelActions.Size = new System.Drawing.Size(936, 296);
            panelActions.TabIndex = 1;

            cardSearchMedicine.BackColor = System.Drawing.Color.White;
            cardSearchMedicine.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardSearchMedicine.BorderRadius = 16;
            cardSearchMedicine.BorderSize = 1;
            cardSearchMedicine.Controls.Add(accentSearchMedicine);
            cardSearchMedicine.Controls.Add(labelSearchMedicineTitle);
            cardSearchMedicine.Controls.Add(labelSearchMedicineDescription);
            cardSearchMedicine.Controls.Add(buttonSearchMedicineOpen);
            cardSearchMedicine.Location = new System.Drawing.Point(0, 0);
            cardSearchMedicine.Name = "cardSearchMedicine";
            cardSearchMedicine.Size = new System.Drawing.Size(300, 184);
            cardSearchMedicine.TabIndex = 0;

            accentSearchMedicine.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            accentSearchMedicine.Location = new System.Drawing.Point(24, 28);
            accentSearchMedicine.Name = "accentSearchMedicine";
            accentSearchMedicine.Size = new System.Drawing.Size(52, 6);
            accentSearchMedicine.TabIndex = 0;

            labelSearchMedicineTitle.AutoSize = true;
            labelSearchMedicineTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelSearchMedicineTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelSearchMedicineTitle.Location = new System.Drawing.Point(22, 52);
            labelSearchMedicineTitle.Name = "labelSearchMedicineTitle";
            labelSearchMedicineTitle.Size = new System.Drawing.Size(139, 28);
            labelSearchMedicineTitle.TabIndex = 1;
            labelSearchMedicineTitle.Text = "Tra cứu thuốc";

            labelSearchMedicineDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelSearchMedicineDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelSearchMedicineDescription.Location = new System.Drawing.Point(24, 92);
            labelSearchMedicineDescription.Name = "labelSearchMedicineDescription";
            labelSearchMedicineDescription.Size = new System.Drawing.Size(246, 28);
            labelSearchMedicineDescription.TabIndex = 2;
            labelSearchMedicineDescription.Text = "Xem thông tin thuốc";

            buttonSearchMedicineOpen.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            buttonSearchMedicineOpen.BorderRadius = 12;
            buttonSearchMedicineOpen.BorderSize = 0;
            buttonSearchMedicineOpen.FlatAppearance.BorderSize = 0;
            buttonSearchMedicineOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonSearchMedicineOpen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonSearchMedicineOpen.ForeColor = System.Drawing.Color.White;
            buttonSearchMedicineOpen.HoverBackColor = System.Drawing.Color.FromArgb(0, 113, 235);
            buttonSearchMedicineOpen.Location = new System.Drawing.Point(24, 128);
            buttonSearchMedicineOpen.Name = "buttonSearchMedicineOpen";
            buttonSearchMedicineOpen.Size = new System.Drawing.Size(132, 38);
            buttonSearchMedicineOpen.TabIndex = 3;
            buttonSearchMedicineOpen.Text = "Mở";
            buttonSearchMedicineOpen.UseVisualStyleBackColor = false;

            cardCreateInvoice.BackColor = System.Drawing.Color.White;
            cardCreateInvoice.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardCreateInvoice.BorderRadius = 16;
            cardCreateInvoice.BorderSize = 1;
            cardCreateInvoice.Controls.Add(accentCreateInvoice);
            cardCreateInvoice.Controls.Add(labelCreateInvoiceTitle);
            cardCreateInvoice.Controls.Add(labelCreateInvoiceDescription);
            cardCreateInvoice.Controls.Add(buttonCreateInvoiceOpen);
            cardCreateInvoice.Location = new System.Drawing.Point(318, 0);
            cardCreateInvoice.Name = "cardCreateInvoice";
            cardCreateInvoice.Size = new System.Drawing.Size(300, 184);
            cardCreateInvoice.TabIndex = 1;

            accentCreateInvoice.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            accentCreateInvoice.Location = new System.Drawing.Point(24, 28);
            accentCreateInvoice.Name = "accentCreateInvoice";
            accentCreateInvoice.Size = new System.Drawing.Size(52, 6);
            accentCreateInvoice.TabIndex = 0;

            labelCreateInvoiceTitle.AutoSize = true;
            labelCreateInvoiceTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelCreateInvoiceTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelCreateInvoiceTitle.Location = new System.Drawing.Point(22, 52);
            labelCreateInvoiceTitle.Name = "labelCreateInvoiceTitle";
            labelCreateInvoiceTitle.Size = new System.Drawing.Size(128, 28);
            labelCreateInvoiceTitle.TabIndex = 1;
            labelCreateInvoiceTitle.Text = "Lập hóa đơn";

            labelCreateInvoiceDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelCreateInvoiceDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelCreateInvoiceDescription.Location = new System.Drawing.Point(24, 92);
            labelCreateInvoiceDescription.Name = "labelCreateInvoiceDescription";
            labelCreateInvoiceDescription.Size = new System.Drawing.Size(246, 28);
            labelCreateInvoiceDescription.TabIndex = 2;
            labelCreateInvoiceDescription.Text = "Tạo giao dịch bán hàng";

            buttonCreateInvoiceOpen.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            buttonCreateInvoiceOpen.BorderRadius = 12;
            buttonCreateInvoiceOpen.BorderSize = 0;
            buttonCreateInvoiceOpen.FlatAppearance.BorderSize = 0;
            buttonCreateInvoiceOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonCreateInvoiceOpen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonCreateInvoiceOpen.ForeColor = System.Drawing.Color.White;
            buttonCreateInvoiceOpen.HoverBackColor = System.Drawing.Color.FromArgb(37, 154, 64);
            buttonCreateInvoiceOpen.Location = new System.Drawing.Point(24, 128);
            buttonCreateInvoiceOpen.Name = "buttonCreateInvoiceOpen";
            buttonCreateInvoiceOpen.Size = new System.Drawing.Size(132, 38);
            buttonCreateInvoiceOpen.TabIndex = 3;
            buttonCreateInvoiceOpen.Text = "Mở";
            buttonCreateInvoiceOpen.UseVisualStyleBackColor = false;

            cardInvoiceHistory.BackColor = System.Drawing.Color.White;
            cardInvoiceHistory.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardInvoiceHistory.BorderRadius = 16;
            cardInvoiceHistory.BorderSize = 1;
            cardInvoiceHistory.Controls.Add(accentInvoiceHistory);
            cardInvoiceHistory.Controls.Add(labelInvoiceHistoryTitle);
            cardInvoiceHistory.Controls.Add(labelInvoiceHistoryDescription);
            cardInvoiceHistory.Controls.Add(buttonInvoiceHistoryOpen);
            cardInvoiceHistory.Location = new System.Drawing.Point(636, 0);
            cardInvoiceHistory.Name = "cardInvoiceHistory";
            cardInvoiceHistory.Size = new System.Drawing.Size(300, 184);
            cardInvoiceHistory.TabIndex = 2;

            accentInvoiceHistory.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            accentInvoiceHistory.Location = new System.Drawing.Point(24, 28);
            accentInvoiceHistory.Name = "accentInvoiceHistory";
            accentInvoiceHistory.Size = new System.Drawing.Size(52, 6);
            accentInvoiceHistory.TabIndex = 0;

            labelInvoiceHistoryTitle.AutoSize = true;
            labelInvoiceHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelInvoiceHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelInvoiceHistoryTitle.Location = new System.Drawing.Point(22, 52);
            labelInvoiceHistoryTitle.Name = "labelInvoiceHistoryTitle";
            labelInvoiceHistoryTitle.Size = new System.Drawing.Size(180, 28);
            labelInvoiceHistoryTitle.TabIndex = 1;
            labelInvoiceHistoryTitle.Text = "Lịch sử bán hàng";

            labelInvoiceHistoryDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelInvoiceHistoryDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelInvoiceHistoryDescription.Location = new System.Drawing.Point(24, 92);
            labelInvoiceHistoryDescription.Name = "labelInvoiceHistoryDescription";
            labelInvoiceHistoryDescription.Size = new System.Drawing.Size(246, 28);
            labelInvoiceHistoryDescription.TabIndex = 2;
            labelInvoiceHistoryDescription.Text = "Theo dõi hóa đơn";

            buttonInvoiceHistoryOpen.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            buttonInvoiceHistoryOpen.BorderRadius = 12;
            buttonInvoiceHistoryOpen.BorderSize = 0;
            buttonInvoiceHistoryOpen.FlatAppearance.BorderSize = 0;
            buttonInvoiceHistoryOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonInvoiceHistoryOpen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonInvoiceHistoryOpen.ForeColor = System.Drawing.Color.White;
            buttonInvoiceHistoryOpen.HoverBackColor = System.Drawing.Color.FromArgb(21, 149, 169);
            buttonInvoiceHistoryOpen.Location = new System.Drawing.Point(24, 128);
            buttonInvoiceHistoryOpen.Name = "buttonInvoiceHistoryOpen";
            buttonInvoiceHistoryOpen.Size = new System.Drawing.Size(132, 38);
            buttonInvoiceHistoryOpen.TabIndex = 3;
            buttonInvoiceHistoryOpen.Text = "Mở";
            buttonInvoiceHistoryOpen.UseVisualStyleBackColor = false;

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            ClientSize = new System.Drawing.Size(1000, 640);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "StaffHomeForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Khu vực nhân viên";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            panelActions.ResumeLayout(false);
            cardSearchMedicine.ResumeLayout(false);
            cardSearchMedicine.PerformLayout();
            cardCreateInvoice.ResumeLayout(false);
            cardCreateInvoice.PerformLayout();
            cardInvoiceHistory.ResumeLayout(false);
            cardInvoiceHistory.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeaderTitle;
        private System.Windows.Forms.Label labelHeaderSubtitle;
        private RoundedButton buttonLogout;
        private System.Windows.Forms.Panel panelContent;
        private RoundedPanel panelSummary;
        private System.Windows.Forms.Label labelSummaryTitle;
        private System.Windows.Forms.Label labelAccount;
        private System.Windows.Forms.Panel panelActions;
        private RoundedPanel cardSearchMedicine;
        private System.Windows.Forms.Panel accentSearchMedicine;
        private System.Windows.Forms.Label labelSearchMedicineTitle;
        private System.Windows.Forms.Label labelSearchMedicineDescription;
        private RoundedButton buttonSearchMedicineOpen;
        private RoundedPanel cardCreateInvoice;
        private System.Windows.Forms.Panel accentCreateInvoice;
        private System.Windows.Forms.Label labelCreateInvoiceTitle;
        private System.Windows.Forms.Label labelCreateInvoiceDescription;
        private RoundedButton buttonCreateInvoiceOpen;
        private RoundedPanel cardInvoiceHistory;
        private System.Windows.Forms.Panel accentInvoiceHistory;
        private System.Windows.Forms.Label labelInvoiceHistoryTitle;
        private System.Windows.Forms.Label labelInvoiceHistoryDescription;
        private RoundedButton buttonInvoiceHistoryOpen;
    }
}
