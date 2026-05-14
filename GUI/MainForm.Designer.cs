namespace PharmacyManagementSystem
{
    partial class MainForm
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
            labelStatus = new System.Windows.Forms.Label();
            panelStats = new System.Windows.Forms.Panel();
            cardTotalMedicine = new RoundedPanel();
            accentTotalMedicine = new System.Windows.Forms.Panel();
            labelTotalMedicineTitle = new System.Windows.Forms.Label();
            labelTotalMedicineValue = new System.Windows.Forms.Label();
            labelTotalMedicineDescription = new System.Windows.Forms.Label();
            cardActiveMedicine = new RoundedPanel();
            accentActiveMedicine = new System.Windows.Forms.Panel();
            labelActiveMedicineTitle = new System.Windows.Forms.Label();
            labelActiveMedicineValue = new System.Windows.Forms.Label();
            labelActiveMedicineDescription = new System.Windows.Forms.Label();
            cardStockQuantity = new RoundedPanel();
            accentStockQuantity = new System.Windows.Forms.Panel();
            labelStockQuantityTitle = new System.Windows.Forms.Label();
            labelStockQuantityValue = new System.Windows.Forms.Label();
            labelStockQuantityDescription = new System.Windows.Forms.Label();
            cardLowStock = new RoundedPanel();
            accentLowStock = new System.Windows.Forms.Panel();
            labelLowStockTitle = new System.Windows.Forms.Label();
            labelLowStockValue = new System.Windows.Forms.Label();
            labelLowStockDescription = new System.Windows.Forms.Label();
            cardExpiringSoon = new RoundedPanel();
            accentExpiringSoon = new System.Windows.Forms.Panel();
            labelExpiringSoonTitle = new System.Windows.Forms.Label();
            labelExpiringSoonValue = new System.Windows.Forms.Label();
            labelExpiringSoonDescription = new System.Windows.Forms.Label();
            cardAdmin = new RoundedPanel();
            accentAdmin = new System.Windows.Forms.Panel();
            labelAdminTitle = new System.Windows.Forms.Label();
            labelAdminValue = new System.Windows.Forms.Label();
            labelAdminDescription = new System.Windows.Forms.Label();
            cardStaff = new RoundedPanel();
            accentStaff = new System.Windows.Forms.Panel();
            labelStaffTitle = new System.Windows.Forms.Label();
            labelStaffValue = new System.Windows.Forms.Label();
            labelStaffDescription = new System.Windows.Forms.Label();
            cardActiveUser = new RoundedPanel();
            accentActiveUser = new System.Windows.Forms.Panel();
            labelActiveUserTitle = new System.Windows.Forms.Label();
            labelActiveUserValue = new System.Windows.Forms.Label();
            labelActiveUserDescription = new System.Windows.Forms.Label();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            panelSummary.SuspendLayout();
            panelStats.SuspendLayout();
            cardTotalMedicine.SuspendLayout();
            cardActiveMedicine.SuspendLayout();
            cardStockQuantity.SuspendLayout();
            cardLowStock.SuspendLayout();
            cardExpiringSoon.SuspendLayout();
            cardAdmin.SuspendLayout();
            cardStaff.SuspendLayout();
            cardActiveUser.SuspendLayout();
            SuspendLayout();

            panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 86, 179);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Controls.Add(labelHeaderSubtitle);
            panelHeader.Controls.Add(buttonLogout);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new System.Windows.Forms.Padding(28, 18, 28, 18);
            panelHeader.Size = new System.Drawing.Size(1100, 92);
            panelHeader.TabIndex = 0;

            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeaderTitle.ForeColor = System.Drawing.Color.White;
            labelHeaderTitle.Location = new System.Drawing.Point(28, 16);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new System.Drawing.Size(135, 32);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "Dashboard";

            labelHeaderSubtitle.AutoSize = true;
            labelHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(224, 239, 255);
            labelHeaderSubtitle.Location = new System.Drawing.Point(31, 54);
            labelHeaderSubtitle.Name = "labelHeaderSubtitle";
            labelHeaderSubtitle.Size = new System.Drawing.Size(171, 17);
            labelHeaderSubtitle.TabIndex = 1;
            labelHeaderSubtitle.Text = "Xin chào, Admin | Vai trò";

            buttonLogout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonLogout.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            buttonLogout.BorderRadius = 12;
            buttonLogout.BorderSize = 0;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonLogout.ForeColor = System.Drawing.Color.FromArgb(0, 86, 179);
            buttonLogout.HoverBackColor = System.Drawing.Color.FromArgb(224, 239, 255);
            buttonLogout.Location = new System.Drawing.Point(946, 27);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new System.Drawing.Size(126, 38);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Đăng xuất";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += HandleLogoutClick;

            panelContent.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelContent.Controls.Add(panelStats);
            panelContent.Controls.Add(panelSummary);
            panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContent.Location = new System.Drawing.Point(0, 92);
            panelContent.Name = "panelContent";
            panelContent.Padding = new System.Windows.Forms.Padding(32);
            panelContent.Size = new System.Drawing.Size(1100, 628);
            panelContent.TabIndex = 1;

            panelSummary.BackColor = System.Drawing.Color.White;
            panelSummary.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            panelSummary.BorderRadius = 18;
            panelSummary.BorderSize = 1;
            panelSummary.Controls.Add(labelSummaryTitle);
            panelSummary.Controls.Add(labelAccount);
            panelSummary.Controls.Add(labelStatus);
            panelSummary.Location = new System.Drawing.Point(32, 32);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new System.Drawing.Size(1036, 128);
            panelSummary.TabIndex = 0;

            labelSummaryTitle.AutoSize = true;
            labelSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelSummaryTitle.Location = new System.Drawing.Point(28, 24);
            labelSummaryTitle.Name = "labelSummaryTitle";
            labelSummaryTitle.Size = new System.Drawing.Size(239, 31);
            labelSummaryTitle.TabIndex = 0;
            labelSummaryTitle.Text = "Tổng quan nhà thuốc";

            labelAccount.AutoSize = true;
            labelAccount.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelAccount.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelAccount.Location = new System.Drawing.Point(31, 68);
            labelAccount.Name = "labelAccount";
            labelAccount.Size = new System.Drawing.Size(133, 19);
            labelAccount.TabIndex = 1;
            labelAccount.Text = "Tài khoản: admin";

            labelStatus.AutoSize = true;
            labelStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelStatus.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelStatus.Location = new System.Drawing.Point(31, 94);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new System.Drawing.Size(109, 19);
            labelStatus.TabIndex = 2;
            labelStatus.Text = "Đang tải dữ liệu...";

            panelStats.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelStats.Controls.Add(cardTotalMedicine);
            panelStats.Controls.Add(cardActiveMedicine);
            panelStats.Controls.Add(cardStockQuantity);
            panelStats.Controls.Add(cardLowStock);
            panelStats.Controls.Add(cardExpiringSoon);
            panelStats.Controls.Add(cardAdmin);
            panelStats.Controls.Add(cardStaff);
            panelStats.Controls.Add(cardActiveUser);
            panelStats.Location = new System.Drawing.Point(32, 184);
            panelStats.Name = "panelStats";
            panelStats.Size = new System.Drawing.Size(1036, 456);
            panelStats.TabIndex = 1;

            cardTotalMedicine.BackColor = System.Drawing.Color.White;
            cardTotalMedicine.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardTotalMedicine.BorderRadius = 16;
            cardTotalMedicine.BorderSize = 1;
            cardTotalMedicine.Controls.Add(accentTotalMedicine);
            cardTotalMedicine.Controls.Add(labelTotalMedicineTitle);
            cardTotalMedicine.Controls.Add(labelTotalMedicineValue);
            cardTotalMedicine.Controls.Add(labelTotalMedicineDescription);
            cardTotalMedicine.Location = new System.Drawing.Point(0, 0);
            cardTotalMedicine.Name = "cardTotalMedicine";
            cardTotalMedicine.Size = new System.Drawing.Size(244, 164);
            cardTotalMedicine.TabIndex = 0;

            accentTotalMedicine.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            accentTotalMedicine.Location = new System.Drawing.Point(22, 24);
            accentTotalMedicine.Name = "accentTotalMedicine";
            accentTotalMedicine.Size = new System.Drawing.Size(44, 6);
            accentTotalMedicine.TabIndex = 0;

            labelTotalMedicineTitle.AutoSize = true;
            labelTotalMedicineTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTotalMedicineTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelTotalMedicineTitle.Location = new System.Drawing.Point(22, 42);
            labelTotalMedicineTitle.Name = "labelTotalMedicineTitle";
            labelTotalMedicineTitle.Size = new System.Drawing.Size(80, 19);
            labelTotalMedicineTitle.TabIndex = 1;
            labelTotalMedicineTitle.Text = "Loại thuốc";

            labelTotalMedicineValue.AutoSize = true;
            labelTotalMedicineValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTotalMedicineValue.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelTotalMedicineValue.Location = new System.Drawing.Point(20, 70);
            labelTotalMedicineValue.Name = "labelTotalMedicineValue";
            labelTotalMedicineValue.Size = new System.Drawing.Size(41, 47);
            labelTotalMedicineValue.TabIndex = 2;
            labelTotalMedicineValue.Text = "0";

            labelTotalMedicineDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelTotalMedicineDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelTotalMedicineDescription.Location = new System.Drawing.Point(23, 124);
            labelTotalMedicineDescription.Name = "labelTotalMedicineDescription";
            labelTotalMedicineDescription.Size = new System.Drawing.Size(196, 24);
            labelTotalMedicineDescription.TabIndex = 3;
            labelTotalMedicineDescription.Text = "Tất cả mã thuốc";

            cardActiveMedicine.BackColor = System.Drawing.Color.White;
            cardActiveMedicine.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardActiveMedicine.BorderRadius = 16;
            cardActiveMedicine.BorderSize = 1;
            cardActiveMedicine.Controls.Add(accentActiveMedicine);
            cardActiveMedicine.Controls.Add(labelActiveMedicineTitle);
            cardActiveMedicine.Controls.Add(labelActiveMedicineValue);
            cardActiveMedicine.Controls.Add(labelActiveMedicineDescription);
            cardActiveMedicine.Location = new System.Drawing.Point(264, 0);
            cardActiveMedicine.Name = "cardActiveMedicine";
            cardActiveMedicine.Size = new System.Drawing.Size(244, 164);
            cardActiveMedicine.TabIndex = 1;

            accentActiveMedicine.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            accentActiveMedicine.Location = new System.Drawing.Point(22, 24);
            accentActiveMedicine.Name = "accentActiveMedicine";
            accentActiveMedicine.Size = new System.Drawing.Size(44, 6);
            accentActiveMedicine.TabIndex = 0;

            labelActiveMedicineTitle.AutoSize = true;
            labelActiveMedicineTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelActiveMedicineTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelActiveMedicineTitle.Location = new System.Drawing.Point(22, 42);
            labelActiveMedicineTitle.Name = "labelActiveMedicineTitle";
            labelActiveMedicineTitle.Size = new System.Drawing.Size(131, 19);
            labelActiveMedicineTitle.TabIndex = 1;
            labelActiveMedicineTitle.Text = "Đang kinh doanh";

            labelActiveMedicineValue.AutoSize = true;
            labelActiveMedicineValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelActiveMedicineValue.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelActiveMedicineValue.Location = new System.Drawing.Point(20, 70);
            labelActiveMedicineValue.Name = "labelActiveMedicineValue";
            labelActiveMedicineValue.Size = new System.Drawing.Size(41, 47);
            labelActiveMedicineValue.TabIndex = 2;
            labelActiveMedicineValue.Text = "0";

            labelActiveMedicineDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelActiveMedicineDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelActiveMedicineDescription.Location = new System.Drawing.Point(23, 124);
            labelActiveMedicineDescription.Name = "labelActiveMedicineDescription";
            labelActiveMedicineDescription.Size = new System.Drawing.Size(196, 24);
            labelActiveMedicineDescription.TabIndex = 3;
            labelActiveMedicineDescription.Text = "Mã thuốc còn hiệu lực";

            cardStockQuantity.BackColor = System.Drawing.Color.White;
            cardStockQuantity.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardStockQuantity.BorderRadius = 16;
            cardStockQuantity.BorderSize = 1;
            cardStockQuantity.Controls.Add(accentStockQuantity);
            cardStockQuantity.Controls.Add(labelStockQuantityTitle);
            cardStockQuantity.Controls.Add(labelStockQuantityValue);
            cardStockQuantity.Controls.Add(labelStockQuantityDescription);
            cardStockQuantity.Location = new System.Drawing.Point(528, 0);
            cardStockQuantity.Name = "cardStockQuantity";
            cardStockQuantity.Size = new System.Drawing.Size(244, 164);
            cardStockQuantity.TabIndex = 2;

            accentStockQuantity.BackColor = System.Drawing.Color.FromArgb(23, 162, 184);
            accentStockQuantity.Location = new System.Drawing.Point(22, 24);
            accentStockQuantity.Name = "accentStockQuantity";
            accentStockQuantity.Size = new System.Drawing.Size(44, 6);
            accentStockQuantity.TabIndex = 0;

            labelStockQuantityTitle.AutoSize = true;
            labelStockQuantityTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelStockQuantityTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelStockQuantityTitle.Location = new System.Drawing.Point(22, 42);
            labelStockQuantityTitle.Name = "labelStockQuantityTitle";
            labelStockQuantityTitle.Size = new System.Drawing.Size(98, 19);
            labelStockQuantityTitle.TabIndex = 1;
            labelStockQuantityTitle.Text = "Tổng tồn kho";

            labelStockQuantityValue.AutoSize = true;
            labelStockQuantityValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelStockQuantityValue.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelStockQuantityValue.Location = new System.Drawing.Point(20, 70);
            labelStockQuantityValue.Name = "labelStockQuantityValue";
            labelStockQuantityValue.Size = new System.Drawing.Size(41, 47);
            labelStockQuantityValue.TabIndex = 2;
            labelStockQuantityValue.Text = "0";

            labelStockQuantityDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelStockQuantityDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelStockQuantityDescription.Location = new System.Drawing.Point(23, 124);
            labelStockQuantityDescription.Name = "labelStockQuantityDescription";
            labelStockQuantityDescription.Size = new System.Drawing.Size(196, 24);
            labelStockQuantityDescription.TabIndex = 3;
            labelStockQuantityDescription.Text = "Số lượng thuốc hiện có";

            cardLowStock.BackColor = System.Drawing.Color.White;
            cardLowStock.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardLowStock.BorderRadius = 16;
            cardLowStock.BorderSize = 1;
            cardLowStock.Controls.Add(accentLowStock);
            cardLowStock.Controls.Add(labelLowStockTitle);
            cardLowStock.Controls.Add(labelLowStockValue);
            cardLowStock.Controls.Add(labelLowStockDescription);
            cardLowStock.Location = new System.Drawing.Point(792, 0);
            cardLowStock.Name = "cardLowStock";
            cardLowStock.Size = new System.Drawing.Size(244, 164);
            cardLowStock.TabIndex = 3;

            accentLowStock.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            accentLowStock.Location = new System.Drawing.Point(22, 24);
            accentLowStock.Name = "accentLowStock";
            accentLowStock.Size = new System.Drawing.Size(44, 6);
            accentLowStock.TabIndex = 0;

            labelLowStockTitle.AutoSize = true;
            labelLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelLowStockTitle.Location = new System.Drawing.Point(22, 42);
            labelLowStockTitle.Name = "labelLowStockTitle";
            labelLowStockTitle.Size = new System.Drawing.Size(107, 19);
            labelLowStockTitle.TabIndex = 1;
            labelLowStockTitle.Text = "Sắp hết hàng";

            labelLowStockValue.AutoSize = true;
            labelLowStockValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelLowStockValue.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelLowStockValue.Location = new System.Drawing.Point(20, 70);
            labelLowStockValue.Name = "labelLowStockValue";
            labelLowStockValue.Size = new System.Drawing.Size(41, 47);
            labelLowStockValue.TabIndex = 2;
            labelLowStockValue.Text = "0";

            labelLowStockDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelLowStockDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelLowStockDescription.Location = new System.Drawing.Point(23, 124);
            labelLowStockDescription.Name = "labelLowStockDescription";
            labelLowStockDescription.Size = new System.Drawing.Size(196, 24);
            labelLowStockDescription.TabIndex = 3;
            labelLowStockDescription.Text = "Tồn kho từ 10 trở xuống";

            cardExpiringSoon.BackColor = System.Drawing.Color.White;
            cardExpiringSoon.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardExpiringSoon.BorderRadius = 16;
            cardExpiringSoon.BorderSize = 1;
            cardExpiringSoon.Controls.Add(accentExpiringSoon);
            cardExpiringSoon.Controls.Add(labelExpiringSoonTitle);
            cardExpiringSoon.Controls.Add(labelExpiringSoonValue);
            cardExpiringSoon.Controls.Add(labelExpiringSoonDescription);
            cardExpiringSoon.Location = new System.Drawing.Point(0, 196);
            cardExpiringSoon.Name = "cardExpiringSoon";
            cardExpiringSoon.Size = new System.Drawing.Size(244, 164);
            cardExpiringSoon.TabIndex = 4;

            accentExpiringSoon.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            accentExpiringSoon.Location = new System.Drawing.Point(22, 24);
            accentExpiringSoon.Name = "accentExpiringSoon";
            accentExpiringSoon.Size = new System.Drawing.Size(44, 6);
            accentExpiringSoon.TabIndex = 0;

            labelExpiringSoonTitle.AutoSize = true;
            labelExpiringSoonTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelExpiringSoonTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelExpiringSoonTitle.Location = new System.Drawing.Point(22, 42);
            labelExpiringSoonTitle.Name = "labelExpiringSoonTitle";
            labelExpiringSoonTitle.Size = new System.Drawing.Size(100, 19);
            labelExpiringSoonTitle.TabIndex = 1;
            labelExpiringSoonTitle.Text = "Sắp hết hạn";

            labelExpiringSoonValue.AutoSize = true;
            labelExpiringSoonValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelExpiringSoonValue.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelExpiringSoonValue.Location = new System.Drawing.Point(20, 70);
            labelExpiringSoonValue.Name = "labelExpiringSoonValue";
            labelExpiringSoonValue.Size = new System.Drawing.Size(41, 47);
            labelExpiringSoonValue.TabIndex = 2;
            labelExpiringSoonValue.Text = "0";

            labelExpiringSoonDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelExpiringSoonDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelExpiringSoonDescription.Location = new System.Drawing.Point(23, 124);
            labelExpiringSoonDescription.Name = "labelExpiringSoonDescription";
            labelExpiringSoonDescription.Size = new System.Drawing.Size(196, 24);
            labelExpiringSoonDescription.TabIndex = 3;
            labelExpiringSoonDescription.Text = "Hạn dùng trong 30 ngày";

            cardAdmin.BackColor = System.Drawing.Color.White;
            cardAdmin.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardAdmin.BorderRadius = 16;
            cardAdmin.BorderSize = 1;
            cardAdmin.Controls.Add(accentAdmin);
            cardAdmin.Controls.Add(labelAdminTitle);
            cardAdmin.Controls.Add(labelAdminValue);
            cardAdmin.Controls.Add(labelAdminDescription);
            cardAdmin.Location = new System.Drawing.Point(264, 196);
            cardAdmin.Name = "cardAdmin";
            cardAdmin.Size = new System.Drawing.Size(244, 164);
            cardAdmin.TabIndex = 5;

            accentAdmin.BackColor = System.Drawing.Color.FromArgb(111, 66, 193);
            accentAdmin.Location = new System.Drawing.Point(22, 24);
            accentAdmin.Name = "accentAdmin";
            accentAdmin.Size = new System.Drawing.Size(44, 6);
            accentAdmin.TabIndex = 0;

            labelAdminTitle.AutoSize = true;
            labelAdminTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelAdminTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelAdminTitle.Location = new System.Drawing.Point(22, 42);
            labelAdminTitle.Name = "labelAdminTitle";
            labelAdminTitle.Size = new System.Drawing.Size(103, 19);
            labelAdminTitle.TabIndex = 1;
            labelAdminTitle.Text = "Quản trị viên";

            labelAdminValue.AutoSize = true;
            labelAdminValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelAdminValue.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelAdminValue.Location = new System.Drawing.Point(20, 70);
            labelAdminValue.Name = "labelAdminValue";
            labelAdminValue.Size = new System.Drawing.Size(41, 47);
            labelAdminValue.TabIndex = 2;
            labelAdminValue.Text = "0";

            labelAdminDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelAdminDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelAdminDescription.Location = new System.Drawing.Point(23, 124);
            labelAdminDescription.Name = "labelAdminDescription";
            labelAdminDescription.Size = new System.Drawing.Size(196, 24);
            labelAdminDescription.TabIndex = 3;
            labelAdminDescription.Text = "Tài khoản Admin đang hoạt động";

            cardStaff.BackColor = System.Drawing.Color.White;
            cardStaff.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardStaff.BorderRadius = 16;
            cardStaff.BorderSize = 1;
            cardStaff.Controls.Add(accentStaff);
            cardStaff.Controls.Add(labelStaffTitle);
            cardStaff.Controls.Add(labelStaffValue);
            cardStaff.Controls.Add(labelStaffDescription);
            cardStaff.Location = new System.Drawing.Point(528, 196);
            cardStaff.Name = "cardStaff";
            cardStaff.Size = new System.Drawing.Size(244, 164);
            cardStaff.TabIndex = 6;

            accentStaff.BackColor = System.Drawing.Color.FromArgb(0, 86, 179);
            accentStaff.Location = new System.Drawing.Point(22, 24);
            accentStaff.Name = "accentStaff";
            accentStaff.Size = new System.Drawing.Size(44, 6);
            accentStaff.TabIndex = 0;

            labelStaffTitle.AutoSize = true;
            labelStaffTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelStaffTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelStaffTitle.Location = new System.Drawing.Point(22, 42);
            labelStaffTitle.Name = "labelStaffTitle";
            labelStaffTitle.Size = new System.Drawing.Size(81, 19);
            labelStaffTitle.TabIndex = 1;
            labelStaffTitle.Text = "Nhân viên";

            labelStaffValue.AutoSize = true;
            labelStaffValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelStaffValue.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelStaffValue.Location = new System.Drawing.Point(20, 70);
            labelStaffValue.Name = "labelStaffValue";
            labelStaffValue.Size = new System.Drawing.Size(41, 47);
            labelStaffValue.TabIndex = 2;
            labelStaffValue.Text = "0";

            labelStaffDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelStaffDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelStaffDescription.Location = new System.Drawing.Point(23, 124);
            labelStaffDescription.Name = "labelStaffDescription";
            labelStaffDescription.Size = new System.Drawing.Size(196, 24);
            labelStaffDescription.TabIndex = 3;
            labelStaffDescription.Text = "Tài khoản Staff đang hoạt động";

            cardActiveUser.BackColor = System.Drawing.Color.White;
            cardActiveUser.BorderColor = System.Drawing.Color.FromArgb(224, 229, 235);
            cardActiveUser.BorderRadius = 16;
            cardActiveUser.BorderSize = 1;
            cardActiveUser.Controls.Add(accentActiveUser);
            cardActiveUser.Controls.Add(labelActiveUserTitle);
            cardActiveUser.Controls.Add(labelActiveUserValue);
            cardActiveUser.Controls.Add(labelActiveUserDescription);
            cardActiveUser.Location = new System.Drawing.Point(792, 196);
            cardActiveUser.Name = "cardActiveUser";
            cardActiveUser.Size = new System.Drawing.Size(244, 164);
            cardActiveUser.TabIndex = 7;

            accentActiveUser.BackColor = System.Drawing.Color.FromArgb(52, 58, 64);
            accentActiveUser.Location = new System.Drawing.Point(22, 24);
            accentActiveUser.Name = "accentActiveUser";
            accentActiveUser.Size = new System.Drawing.Size(44, 6);
            accentActiveUser.TabIndex = 0;

            labelActiveUserTitle.AutoSize = true;
            labelActiveUserTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelActiveUserTitle.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelActiveUserTitle.Location = new System.Drawing.Point(22, 42);
            labelActiveUserTitle.Name = "labelActiveUserTitle";
            labelActiveUserTitle.Size = new System.Drawing.Size(91, 19);
            labelActiveUserTitle.TabIndex = 1;
            labelActiveUserTitle.Text = "Người dùng";

            labelActiveUserValue.AutoSize = true;
            labelActiveUserValue.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelActiveUserValue.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            labelActiveUserValue.Location = new System.Drawing.Point(20, 70);
            labelActiveUserValue.Name = "labelActiveUserValue";
            labelActiveUserValue.Size = new System.Drawing.Size(41, 47);
            labelActiveUserValue.TabIndex = 2;
            labelActiveUserValue.Text = "0";

            labelActiveUserDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelActiveUserDescription.ForeColor = System.Drawing.Color.FromArgb(102, 102, 102);
            labelActiveUserDescription.Location = new System.Drawing.Point(23, 124);
            labelActiveUserDescription.Name = "labelActiveUserDescription";
            labelActiveUserDescription.Size = new System.Drawing.Size(196, 24);
            labelActiveUserDescription.TabIndex = 3;
            labelActiveUserDescription.Text = "Tài khoản đang hoạt động";

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            ClientSize = new System.Drawing.Size(1100, 720);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Dashboard";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            panelStats.ResumeLayout(false);
            cardTotalMedicine.ResumeLayout(false);
            cardTotalMedicine.PerformLayout();
            cardActiveMedicine.ResumeLayout(false);
            cardActiveMedicine.PerformLayout();
            cardStockQuantity.ResumeLayout(false);
            cardStockQuantity.PerformLayout();
            cardLowStock.ResumeLayout(false);
            cardLowStock.PerformLayout();
            cardExpiringSoon.ResumeLayout(false);
            cardExpiringSoon.PerformLayout();
            cardAdmin.ResumeLayout(false);
            cardAdmin.PerformLayout();
            cardStaff.ResumeLayout(false);
            cardStaff.PerformLayout();
            cardActiveUser.ResumeLayout(false);
            cardActiveUser.PerformLayout();
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
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel panelStats;
        private RoundedPanel cardTotalMedicine;
        private System.Windows.Forms.Panel accentTotalMedicine;
        private System.Windows.Forms.Label labelTotalMedicineTitle;
        private System.Windows.Forms.Label labelTotalMedicineValue;
        private System.Windows.Forms.Label labelTotalMedicineDescription;
        private RoundedPanel cardActiveMedicine;
        private System.Windows.Forms.Panel accentActiveMedicine;
        private System.Windows.Forms.Label labelActiveMedicineTitle;
        private System.Windows.Forms.Label labelActiveMedicineValue;
        private System.Windows.Forms.Label labelActiveMedicineDescription;
        private RoundedPanel cardStockQuantity;
        private System.Windows.Forms.Panel accentStockQuantity;
        private System.Windows.Forms.Label labelStockQuantityTitle;
        private System.Windows.Forms.Label labelStockQuantityValue;
        private System.Windows.Forms.Label labelStockQuantityDescription;
        private RoundedPanel cardLowStock;
        private System.Windows.Forms.Panel accentLowStock;
        private System.Windows.Forms.Label labelLowStockTitle;
        private System.Windows.Forms.Label labelLowStockValue;
        private System.Windows.Forms.Label labelLowStockDescription;
        private RoundedPanel cardExpiringSoon;
        private System.Windows.Forms.Panel accentExpiringSoon;
        private System.Windows.Forms.Label labelExpiringSoonTitle;
        private System.Windows.Forms.Label labelExpiringSoonValue;
        private System.Windows.Forms.Label labelExpiringSoonDescription;
        private RoundedPanel cardAdmin;
        private System.Windows.Forms.Panel accentAdmin;
        private System.Windows.Forms.Label labelAdminTitle;
        private System.Windows.Forms.Label labelAdminValue;
        private System.Windows.Forms.Label labelAdminDescription;
        private RoundedPanel cardStaff;
        private System.Windows.Forms.Panel accentStaff;
        private System.Windows.Forms.Label labelStaffTitle;
        private System.Windows.Forms.Label labelStaffValue;
        private System.Windows.Forms.Label labelStaffDescription;
        private RoundedPanel cardActiveUser;
        private System.Windows.Forms.Panel accentActiveUser;
        private System.Windows.Forms.Label labelActiveUserTitle;
        private System.Windows.Forms.Label labelActiveUserValue;
        private System.Windows.Forms.Label labelActiveUserDescription;
    }
}
