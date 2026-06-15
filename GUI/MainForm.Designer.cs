using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            components = new Container();
            sideNavigationMenu = new SideNavigationMenu();
            panelMain = new Panel();
            panelHeader = new Panel();
            labelHeaderTitle = new Label();
            labelHeaderSubtitle = new Label();
            panelContent = new Panel();
            panelDashboard = new Panel();
            tableMedicine = new TableLayoutPanel();
            tablePeople = new TableLayoutPanel();
            medicineManagementView = new MedicineManagementView();
            employeeManagementView = new EmployeeManagementView();
            invoiceHistoryView = new InvoiceHistoryView();
            customerManagementView = new CustomerManagementView();
            panelPlaceholder = new Panel();
            panelPlaceholderCard = new RoundedPanel();
            labelPlaceholderTitle = new Label();
            labelPlaceholderDescription = new Label();
            panelMain.SuspendLayout();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            panelDashboard.SuspendLayout();
            tableMedicine.SuspendLayout();
            tablePeople.SuspendLayout();
            panelPlaceholder.SuspendLayout();
            panelPlaceholderCard.SuspendLayout();
            SuspendLayout();

            sideNavigationMenu.Dock = DockStyle.Left;
            sideNavigationMenu.Location = new Point(0, 0);
            sideNavigationMenu.Name = "sideNavigationMenu";
            sideNavigationMenu.Size = new Size(248, 760);
            sideNavigationMenu.TabIndex = 0;

            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(248, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(932, 760);
            panelMain.TabIndex = 1;

            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Controls.Add(labelHeaderSubtitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(30, 18, 30, 18);
            panelHeader.Size = new Size(932, 94);
            panelHeader.TabIndex = 0;

            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelHeaderTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelHeaderTitle.Location = new Point(30, 16);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(128, 32);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "Tổng quan";

            labelHeaderSubtitle.AutoSize = true;
            labelHeaderSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            labelHeaderSubtitle.ForeColor = Color.FromArgb(102, 102, 102);
            labelHeaderSubtitle.Location = new Point(33, 54);
            labelHeaderSubtitle.Name = "labelHeaderSubtitle";
            labelHeaderSubtitle.Size = new Size(296, 17);
            labelHeaderSubtitle.TabIndex = 1;
            labelHeaderSubtitle.Text = "Theo dõi nhanh tình trạng thuốc và tài khoản hệ thống";

            panelContent.BackColor = Color.FromArgb(248, 249, 250);
            panelContent.Controls.Add(panelPlaceholder);
            panelContent.Controls.Add(customerManagementView);
            panelContent.Controls.Add(invoiceHistoryView);
            panelContent.Controls.Add(employeeManagementView);
            panelContent.Controls.Add(medicineManagementView);
            panelContent.Controls.Add(panelDashboard);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 94);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(28);
            panelContent.Size = new Size(932, 666);
            panelContent.TabIndex = 1;

            // ── Section labels & gap (local — no field needed) ──────────────────────
            var labelMedicineSection = new Label
            {
                AutoSize = false, Dock = DockStyle.Top, Height = 36,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(51, 51, 51),
                Padding = new Padding(0, 0, 0, 8),
                TextAlign = ContentAlignment.BottomLeft,
                Text = "Thuốc"
            };
            var labelPeopleSection = new Label
            {
                AutoSize = false, Dock = DockStyle.Top, Height = 36,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(51, 51, 51),
                Padding = new Padding(0, 0, 0, 8),
                TextAlign = ContentAlignment.BottomLeft,
                Text = "Con người"
            };
            var panelSectionGap = new Panel
            {
                BackColor = Color.FromArgb(248, 249, 250),
                Dock = DockStyle.Top,
                Height = 20
            };

            panelDashboard.BackColor = Color.FromArgb(248, 249, 250);
            // Controls added in reverse — last added with Dock=Top appears topmost
            panelDashboard.Controls.Add(tablePeople);
            panelDashboard.Controls.Add(labelPeopleSection);
            panelDashboard.Controls.Add(panelSectionGap);
            panelDashboard.Controls.Add(tableMedicine);
            panelDashboard.Controls.Add(labelMedicineSection);
            panelDashboard.Dock = DockStyle.Fill;
            panelDashboard.Location = new Point(28, 28);
            panelDashboard.Name = "panelDashboard";
            panelDashboard.Size = new Size(876, 610);
            panelDashboard.TabIndex = 0;

            // ── tableMedicine — 4 cols × 2 rows (7 cards) ──────────────────────────
            tableMedicine.ColumnCount = 4;
            tableMedicine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableMedicine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableMedicine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableMedicine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableMedicine.Dock = DockStyle.Top;
            tableMedicine.Height = 276;   // row0: 146px (card 130 + margin 16) + row1: 130px
            tableMedicine.Margin = new Padding(0);
            tableMedicine.Name = "tableMedicine";
            tableMedicine.RowCount = 2;
            tableMedicine.RowStyles.Add(new RowStyle(SizeType.Absolute, 146F));
            tableMedicine.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            tableMedicine.TabIndex = 0;

            // ── tablePeople — 3 cols × 1 row (3 cards) ─────────────────────────────
            tablePeople.ColumnCount = 3;
            tablePeople.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tablePeople.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tablePeople.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tablePeople.Dock = DockStyle.Top;
            tablePeople.Height = 130;
            tablePeople.Margin = new Padding(0);
            tablePeople.Name = "tablePeople";
            tablePeople.RowCount = 1;
            tablePeople.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            tablePeople.TabIndex = 1;

            // ── Medicine cards ──────────────────────────────────────────────────────
            cardTotalMedicine = CreateStatCard(
                "cardTotalMedicine", Color.FromArgb(0, 123, 255),
                "Loại thuốc", "Tất cả mã thuốc",
                out accentTotalMedicine, out labelTotalMedicineTitle,
                out labelTotalMedicineValue, out labelTotalMedicineDescription);
            cardActiveMedicine = CreateStatCard(
                "cardActiveMedicine", Color.FromArgb(40, 167, 69),
                "Đang kinh doanh", "Mã thuốc còn hiệu lực",
                out accentActiveMedicine, out labelActiveMedicineTitle,
                out labelActiveMedicineValue, out labelActiveMedicineDescription);
            cardStockQuantity = CreateStatCard(
                "cardStockQuantity", Color.FromArgb(23, 162, 184),
                "Tổng tồn kho", "Số lượng thuốc hiện có",
                out accentStockQuantity, out labelStockQuantityTitle,
                out labelStockQuantityValue, out labelStockQuantityDescription);
            cardExpiringSoon = CreateStatCard(
                "cardExpiringSoon", Color.FromArgb(220, 130, 0),
                "Sắp hết hạn", "Hạn dùng trong 3 tháng",
                out accentExpiringSoon, out labelExpiringSoonTitle,
                out labelExpiringSoonValue, out labelExpiringSoonDescription);
            cardLowStock = CreateStatCard(
                "cardLowStock", Color.FromArgb(255, 193, 7),
                "Sắp hết hàng", "Tồn kho dưới 10 đơn vị",
                out accentLowStock, out labelLowStockTitle,
                out labelLowStockValue, out labelLowStockDescription);
            cardStopped = CreateStatCard(
                "cardStopped", Color.FromArgb(108, 117, 125),
                "Ngừng bán", "Thuốc không kinh doanh",
                out accentStopped, out labelStoppedTitle,
                out labelStoppedValue, out labelStoppedDescription);
            cardExpired = CreateStatCard(
                "cardExpired", Color.FromArgb(140, 20, 40),
                "Đã hết hạn", "Hạn dùng đã qua",
                out accentExpired, out labelExpiredTitle,
                out labelExpiredValue, out labelExpiredDescription);

            // Row 0: Loại thuốc | Đang kinh doanh | Tổng tồn kho | Sắp hết hạn
            AddStatCard(cardTotalMedicine,  0, 0, new Padding(0, 0, 16, 16), tableMedicine);
            AddStatCard(cardActiveMedicine, 1, 0, new Padding(0, 0, 16, 16), tableMedicine);
            AddStatCard(cardStockQuantity,  2, 0, new Padding(0, 0, 16, 16), tableMedicine);
            AddStatCard(cardExpiringSoon,   3, 0, new Padding(0, 0,  0, 16), tableMedicine);
            // Row 1: Sắp hết hàng | Ngừng bán | Đã hết hạn | (trống)
            AddStatCard(cardLowStock, 0, 1, new Padding(0, 0, 16, 0), tableMedicine);
            AddStatCard(cardStopped,  1, 1, new Padding(0, 0, 16, 0), tableMedicine);
            AddStatCard(cardExpired,  2, 1, new Padding(0, 0, 16, 0), tableMedicine);

            // ── People cards ────────────────────────────────────────────────────────
            cardAdmin = CreateStatCard(
                "cardAdmin", Color.FromArgb(111, 66, 193),
                "Quản trị viên", "Tài khoản Admin",
                out accentAdmin, out labelAdminTitle,
                out labelAdminValue, out labelAdminDescription);
            cardStaff = CreateStatCard(
                "cardStaff", Color.FromArgb(0, 86, 179),
                "Nhân viên", "Tài khoản Staff",
                out accentStaff, out labelStaffTitle,
                out labelStaffValue, out labelStaffDescription);
            cardActiveUser = CreateStatCard(
                "cardActiveUser", Color.FromArgb(23, 162, 100),
                "Khách hàng", "Khách hàng đã đăng ký",
                out accentActiveUser, out labelActiveUserTitle,
                out labelActiveUserValue, out labelActiveUserDescription);

            AddStatCard(cardAdmin,      0, 0, new Padding(0, 0, 16, 0), tablePeople);
            AddStatCard(cardStaff,      1, 0, new Padding(0, 0, 16, 0), tablePeople);
            AddStatCard(cardActiveUser, 2, 0, new Padding(0, 0,  0, 0), tablePeople);

            medicineManagementView.Dock = DockStyle.Fill;
            medicineManagementView.Location = new Point(28, 28);
            medicineManagementView.Name = "medicineManagementView";
            medicineManagementView.Size = new Size(876, 610);
            medicineManagementView.TabIndex = 1;
            medicineManagementView.Visible = false;

            employeeManagementView.Dock = DockStyle.Fill;
            employeeManagementView.Location = new Point(28, 28);
            employeeManagementView.Name = "employeeManagementView";
            employeeManagementView.Size = new Size(876, 610);
            employeeManagementView.TabIndex = 2;
            employeeManagementView.Visible = false;

            invoiceHistoryView.Dock = DockStyle.Fill;
            invoiceHistoryView.Location = new Point(28, 28);
            invoiceHistoryView.Name = "invoiceHistoryView";
            invoiceHistoryView.Size = new Size(876, 610);
            invoiceHistoryView.TabIndex = 3;
            invoiceHistoryView.Visible = false;

            customerManagementView.Dock = DockStyle.Fill;
            customerManagementView.Location = new Point(28, 28);
            customerManagementView.Name = "customerManagementView";
            customerManagementView.Size = new Size(876, 610);
            customerManagementView.TabIndex = 5;
            customerManagementView.Visible = false;

            panelPlaceholder.BackColor = Color.FromArgb(248, 249, 250);
            panelPlaceholder.Controls.Add(panelPlaceholderCard);
            panelPlaceholder.Dock = DockStyle.Fill;
            panelPlaceholder.Location = new Point(28, 28);
            panelPlaceholder.Name = "panelPlaceholder";
            panelPlaceholder.Size = new Size(876, 610);
            panelPlaceholder.TabIndex = 4;
            panelPlaceholder.Visible = false;

            panelPlaceholderCard.BackColor = Color.White;
            panelPlaceholderCard.BorderColor = Color.FromArgb(224, 229, 235);
            panelPlaceholderCard.BorderRadius = 18;
            panelPlaceholderCard.BorderSize = 1;
            panelPlaceholderCard.Controls.Add(labelPlaceholderTitle);
            panelPlaceholderCard.Controls.Add(labelPlaceholderDescription);
            panelPlaceholderCard.Dock = DockStyle.Top;
            panelPlaceholderCard.Location = new Point(0, 0);
            panelPlaceholderCard.Name = "panelPlaceholderCard";
            panelPlaceholderCard.Size = new Size(876, 170);
            panelPlaceholderCard.TabIndex = 0;

            labelPlaceholderTitle.AutoSize = true;
            labelPlaceholderTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlaceholderTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelPlaceholderTitle.Location = new Point(28, 28);
            labelPlaceholderTitle.Name = "labelPlaceholderTitle";
            labelPlaceholderTitle.Size = new Size(119, 31);
            labelPlaceholderTitle.TabIndex = 0;
            labelPlaceholderTitle.Text = "Trang mới";

            labelPlaceholderDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            labelPlaceholderDescription.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlaceholderDescription.ForeColor = Color.FromArgb(102, 102, 102);
            labelPlaceholderDescription.Location = new Point(31, 76);
            labelPlaceholderDescription.Name = "labelPlaceholderDescription";
            labelPlaceholderDescription.Size = new Size(812, 48);
            labelPlaceholderDescription.TabIndex = 1;
            labelPlaceholderDescription.Text = "Chức năng đang được chuẩn bị.";

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1180, 760);
            Controls.Add(panelMain);
            Controls.Add(sideNavigationMenu);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MinimumSize = new Size(1060, 680);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            panelMain.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelDashboard.ResumeLayout(false);
            tableMedicine.ResumeLayout(false);
            tablePeople.ResumeLayout(false);
            cardTotalMedicine.ResumeLayout(false);
            cardTotalMedicine.PerformLayout();
            cardActiveMedicine.ResumeLayout(false);
            cardActiveMedicine.PerformLayout();
            cardStockQuantity.ResumeLayout(false);
            cardStockQuantity.PerformLayout();
            cardExpiringSoon.ResumeLayout(false);
            cardExpiringSoon.PerformLayout();
            cardLowStock.ResumeLayout(false);
            cardLowStock.PerformLayout();
            cardStopped.ResumeLayout(false);
            cardStopped.PerformLayout();
            cardExpired.ResumeLayout(false);
            cardExpired.PerformLayout();
            cardAdmin.ResumeLayout(false);
            cardAdmin.PerformLayout();
            cardStaff.ResumeLayout(false);
            cardStaff.PerformLayout();
            cardActiveUser.ResumeLayout(false);
            cardActiveUser.PerformLayout();
            panelPlaceholder.ResumeLayout(false);
            panelPlaceholderCard.ResumeLayout(false);
            panelPlaceholderCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel CreateStatCard(
            string name,
            Color accentColor,
            string title,
            string description,
            out Panel accentPanel,
            out Label titleLabel,
            out Label valueLabel,
            out Label descriptionLabel)
        {
            var card = new RoundedPanel
            {
                BackColor = Color.White,
                BorderColor = Color.FromArgb(224, 229, 235),
                BorderRadius = 16,
                BorderSize = 1,
                Name = name,
                Size = new Size(203, 130)
            };

            accentPanel = new Panel
            {
                BackColor = accentColor,
                Location = new Point(20, 12),
                Name = $"accent{name}",
                Size = new Size(32, 5),
                TabIndex = 0
            };

            titleLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(51, 51, 51),
                Location = new Point(20, 24),
                Name = $"label{name}Title",
                TabIndex = 1,
                Text = title
            };

            valueLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(51, 51, 51),
                Location = new Point(18, 46),
                Name = $"label{name}Value",
                TabIndex = 2,
                Text = "0"
            };

            descriptionLabel = new Label
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(130, 130, 130),
                Location = new Point(20, 104),
                Name = $"label{name}Description",
                Size = new Size(160, 18),
                TabIndex = 3,
                Text = description
            };

            card.Controls.Add(accentPanel);
            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);
            card.Controls.Add(descriptionLabel);
            return card;
        }

        private static void AddStatCard(RoundedPanel card, int column, int row, Padding margin, TableLayoutPanel table)
        {
            card.Dock = DockStyle.Fill;
            card.Margin = margin;
            table.Controls.Add(card, column, row);
        }

        private SideNavigationMenu sideNavigationMenu;
        private Panel panelMain;
        private Panel panelHeader;
        private Label labelHeaderTitle;
        private Label labelHeaderSubtitle;
        private Panel panelContent;
        private Panel panelDashboard;
        private TableLayoutPanel tableMedicine;
        private TableLayoutPanel tablePeople;
        private MedicineManagementView medicineManagementView;
        private EmployeeManagementView employeeManagementView;
        private InvoiceHistoryView invoiceHistoryView;
        private CustomerManagementView customerManagementView;
        // Medicine cards
        private RoundedPanel cardTotalMedicine;
        private Panel accentTotalMedicine;
        private Label labelTotalMedicineTitle;
        private Label labelTotalMedicineValue;
        private Label labelTotalMedicineDescription;
        private RoundedPanel cardActiveMedicine;
        private Panel accentActiveMedicine;
        private Label labelActiveMedicineTitle;
        private Label labelActiveMedicineValue;
        private Label labelActiveMedicineDescription;
        private RoundedPanel cardStockQuantity;
        private Panel accentStockQuantity;
        private Label labelStockQuantityTitle;
        private Label labelStockQuantityValue;
        private Label labelStockQuantityDescription;
        private RoundedPanel cardExpiringSoon;
        private Panel accentExpiringSoon;
        private Label labelExpiringSoonTitle;
        private Label labelExpiringSoonValue;
        private Label labelExpiringSoonDescription;
        private RoundedPanel cardLowStock;
        private Panel accentLowStock;
        private Label labelLowStockTitle;
        private Label labelLowStockValue;
        private Label labelLowStockDescription;
        private RoundedPanel cardStopped;
        private Panel accentStopped;
        private Label labelStoppedTitle;
        private Label labelStoppedValue;
        private Label labelStoppedDescription;
        private RoundedPanel cardExpired;
        private Panel accentExpired;
        private Label labelExpiredTitle;
        private Label labelExpiredValue;
        private Label labelExpiredDescription;
        // People cards
        private RoundedPanel cardAdmin;
        private Panel accentAdmin;
        private Label labelAdminTitle;
        private Label labelAdminValue;
        private Label labelAdminDescription;
        private RoundedPanel cardStaff;
        private Panel accentStaff;
        private Label labelStaffTitle;
        private Label labelStaffValue;
        private Label labelStaffDescription;
        private RoundedPanel cardActiveUser;
        private Panel accentActiveUser;
        private Label labelActiveUserTitle;
        private Label labelActiveUserValue;
        private Label labelActiveUserDescription;
        private Panel panelPlaceholder;
        private RoundedPanel panelPlaceholderCard;
        private Label labelPlaceholderTitle;
        private Label labelPlaceholderDescription;
    }
}
