using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    partial class InvoiceHistoryView
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            panelRoot = new Panel();
            panelTable = new RoundedPanel();
            invoicesGrid = new DataGridView();
            columnCreatedAt = new DataGridViewTextBoxColumn();
            columnInvoiceCode = new DataGridViewTextBoxColumn();
            columnCustomerName = new DataGridViewTextBoxColumn();
            columnCustomerPhone = new DataGridViewTextBoxColumn();
            columnCreatedBy = new DataGridViewTextBoxColumn();
            columnTotalAmount = new DataGridViewTextBoxColumn();
            columnDiscount = new DataGridViewTextBoxColumn();
            columnFinalAmount = new DataGridViewTextBoxColumn();
            columnViewDetail = new DataGridViewButtonColumn();
            panelToolbar = new RoundedPanel();
            buttonRefresh = new RoundedButton();
            dateToPicker = new DateTimePicker();
            labelDateTo = new Label();
            dateFromPicker = new DateTimePicker();
            labelDateFrom = new Label();
            comboStatusFilter = new ComboBox();
            labelStatusFilter = new Label();
            textSearchInvoice = new RoundedTextBox();
            labelSearchInvoice = new Label();
            panelIntro = new RoundedPanel();
            labelIntroTitle = new Label();
            labelIntroDescription = new Label();
            tableSummary = new TableLayoutPanel();
            panelInvoiceCount = new Panel();
            labelInvoiceCountTitle = new Label();
            labelInvoiceCountValue = new Label();
            panelItemCount = new Panel();
            labelItemCountTitle = new Label();
            labelItemCountValue = new Label();
            panelTotalAmount = new Panel();
            labelTotalAmountTitle = new Label();
            labelTotalAmountValue = new Label();
            panelDiscount = new Panel();
            labelDiscountTitle = new Label();
            labelDiscountValue = new Label();
            panelFinalAmount = new Panel();
            labelFinalAmountTitle = new Label();
            labelFinalAmountValue = new Label();
            panelRoot.SuspendLayout();
            panelTable.SuspendLayout();
            ((ISupportInitialize)invoicesGrid).BeginInit();
            panelToolbar.SuspendLayout();
            panelIntro.SuspendLayout();
            tableSummary.SuspendLayout();
            panelInvoiceCount.SuspendLayout();
            panelItemCount.SuspendLayout();
            panelTotalAmount.SuspendLayout();
            panelDiscount.SuspendLayout();
            panelFinalAmount.SuspendLayout();
            SuspendLayout();

            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(panelRoot);
            Dock = DockStyle.Fill;
            Name = "InvoiceHistoryView";
            Size = new Size(876, 610);

            panelRoot.BackColor = Color.FromArgb(248, 249, 250);
            panelRoot.Controls.Add(panelTable);
            panelRoot.Controls.Add(panelToolbar);
            panelRoot.Controls.Add(panelIntro);
            panelRoot.Dock = DockStyle.Fill;
            panelRoot.Location = new Point(0, 0);
            panelRoot.Name = "panelRoot";
            panelRoot.Size = new Size(876, 610);
            panelRoot.TabIndex = 0;

            panelIntro.BackColor = Color.White;
            panelIntro.BorderColor = Color.FromArgb(224, 229, 235);
            panelIntro.BorderRadius = 18;
            panelIntro.BorderSize = 1;
            panelIntro.Controls.Add(tableSummary);
            panelIntro.Controls.Add(labelIntroTitle);
            panelIntro.Controls.Add(labelIntroDescription);
            panelIntro.Dock = DockStyle.Top;
            panelIntro.Location = new Point(0, 0);
            panelIntro.Name = "panelIntro";
            panelIntro.Size = new Size(876, 108);
            panelIntro.TabIndex = 0;

            labelIntroTitle.AutoSize = true;
            labelIntroTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
            labelIntroTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelIntroTitle.Location = new Point(28, 20);
            labelIntroTitle.Name = "labelIntroTitle";
            labelIntroTitle.Size = new Size(209, 31);
            labelIntroTitle.TabIndex = 0;
            labelIntroTitle.Text = "Lịch sử bán hàng";

            labelIntroDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            labelIntroDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelIntroDescription.ForeColor = Color.FromArgb(102, 102, 102);
            labelIntroDescription.Location = new Point(31, 62);
            labelIntroDescription.Name = "labelIntroDescription";
            labelIntroDescription.Size = new Size(342, 24);
            labelIntroDescription.TabIndex = 1;
            labelIntroDescription.Text = "Tra cứu hóa đơn, doanh thu và thuốc đã bán.";

            tableSummary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableSummary.ColumnCount = 5;
            tableSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableSummary.Controls.Add(panelInvoiceCount, 0, 0);
            tableSummary.Controls.Add(panelItemCount, 1, 0);
            tableSummary.Controls.Add(panelTotalAmount, 2, 0);
            tableSummary.Controls.Add(panelDiscount, 3, 0);
            tableSummary.Controls.Add(panelFinalAmount, 4, 0);
            tableSummary.Location = new Point(382, 18);
            tableSummary.Name = "tableSummary";
            tableSummary.RowCount = 1;
            tableSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableSummary.Size = new Size(466, 70);
            tableSummary.TabIndex = 2;

            ConfigureSummaryPanel(panelInvoiceCount, labelInvoiceCountTitle, labelInvoiceCountValue, "Hóa đơn");
            ConfigureSummaryPanel(panelItemCount, labelItemCountTitle, labelItemCountValue, "Mặt hàng");
            ConfigureSummaryPanel(panelTotalAmount, labelTotalAmountTitle, labelTotalAmountValue, "Tiền hàng");
            ConfigureSummaryPanel(panelDiscount, labelDiscountTitle, labelDiscountValue, "Giảm giá");
            ConfigureSummaryPanel(panelFinalAmount, labelFinalAmountTitle, labelFinalAmountValue, "Thanh toán");

            panelToolbar.BackColor = Color.White;
            panelToolbar.BorderColor = Color.FromArgb(224, 229, 235);
            panelToolbar.BorderRadius = 16;
            panelToolbar.BorderSize = 1;
            panelToolbar.Controls.Add(buttonRefresh);
            panelToolbar.Controls.Add(dateToPicker);
            panelToolbar.Controls.Add(labelDateTo);
            panelToolbar.Controls.Add(dateFromPicker);
            panelToolbar.Controls.Add(labelDateFrom);
            panelToolbar.Controls.Add(comboStatusFilter);
            panelToolbar.Controls.Add(labelStatusFilter);
            panelToolbar.Controls.Add(textSearchInvoice);
            panelToolbar.Controls.Add(labelSearchInvoice);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 108);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(876, 92);
            panelToolbar.TabIndex = 1;

            labelSearchInvoice.AutoSize = true;
            labelSearchInvoice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelSearchInvoice.ForeColor = Color.FromArgb(51, 51, 51);
            labelSearchInvoice.Location = new Point(24, 16);
            labelSearchInvoice.Name = "labelSearchInvoice";
            labelSearchInvoice.Size = new Size(64, 17);
            labelSearchInvoice.TabIndex = 0;
            labelSearchInvoice.Text = "Tìm kiếm";

            textSearchInvoice.BackColor = Color.White;
            textSearchInvoice.BorderColor = Color.FromArgb(170, 183, 196);
            textSearchInvoice.BorderRadius = 10;
            textSearchInvoice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textSearchInvoice.ForeColor = Color.FromArgb(51, 51, 51);
            textSearchInvoice.Location = new Point(24, 40);
            textSearchInvoice.Name = "textSearchInvoice";
            textSearchInvoice.PlaceholderText = "Mã hóa đơn, tên khách...";
            textSearchInvoice.Size = new Size(224, 38);
            textSearchInvoice.TabIndex = 1;

            labelStatusFilter.AutoSize = true;
            labelStatusFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelStatusFilter.ForeColor = Color.FromArgb(51, 51, 51);
            labelStatusFilter.Location = new Point(266, 16);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Size = new Size(70, 17);
            labelStatusFilter.TabIndex = 2;
            labelStatusFilter.Text = "Trạng thái";

            comboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStatusFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboStatusFilter.FormattingEnabled = true;
            comboStatusFilter.Items.AddRange(new object[] { "Tất cả", "Hoàn tất", "Đã hủy" });
            comboStatusFilter.Location = new Point(266, 46);
            comboStatusFilter.Name = "comboStatusFilter";
            comboStatusFilter.Size = new Size(124, 25);
            comboStatusFilter.TabIndex = 3;

            labelDateFrom.AutoSize = true;
            labelDateFrom.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelDateFrom.ForeColor = Color.FromArgb(51, 51, 51);
            labelDateFrom.Location = new Point(408, 16);
            labelDateFrom.Name = "labelDateFrom";
            labelDateFrom.Size = new Size(54, 17);
            labelDateFrom.TabIndex = 4;
            labelDateFrom.Text = "Từ ngày";

            dateFromPicker.CustomFormat = "dd/MM/yyyy";
            dateFromPicker.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateFromPicker.Format = DateTimePickerFormat.Custom;
            dateFromPicker.Location = new Point(408, 46);
            dateFromPicker.Name = "dateFromPicker";
            dateFromPicker.ShowCheckBox = true;
            dateFromPicker.Size = new Size(128, 25);
            dateFromPicker.TabIndex = 5;

            labelDateTo.AutoSize = true;
            labelDateTo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelDateTo.ForeColor = Color.FromArgb(51, 51, 51);
            labelDateTo.Location = new Point(554, 16);
            labelDateTo.Name = "labelDateTo";
            labelDateTo.Size = new Size(63, 17);
            labelDateTo.TabIndex = 6;
            labelDateTo.Text = "Đến ngày";

            dateToPicker.CustomFormat = "dd/MM/yyyy";
            dateToPicker.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dateToPicker.Format = DateTimePickerFormat.Custom;
            dateToPicker.Location = new Point(554, 46);
            dateToPicker.Name = "dateToPicker";
            dateToPicker.ShowCheckBox = true;
            dateToPicker.Size = new Size(128, 25);
            dateToPicker.TabIndex = 7;

            buttonRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRefresh.BackColor = Color.FromArgb(0, 123, 255);
            buttonRefresh.BorderRadius = 12;
            buttonRefresh.BorderSize = 0;
            buttonRefresh.FlatAppearance.BorderSize = 0;
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRefresh.ForeColor = Color.White;
            buttonRefresh.HoverBackColor = Color.FromArgb(0, 113, 235);
            buttonRefresh.Location = new Point(740, 40);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(108, 38);
            buttonRefresh.TabIndex = 8;
            buttonRefresh.Text = "Làm mới";
            buttonRefresh.UseVisualStyleBackColor = false;

            panelTable.BackColor = Color.White;
            panelTable.BorderColor = Color.FromArgb(224, 229, 235);
            panelTable.BorderRadius = 16;
            panelTable.BorderSize = 1;
            panelTable.Controls.Add(invoicesGrid);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Location = new Point(0, 200);
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(16);
            panelTable.Size = new Size(876, 410);
            panelTable.TabIndex = 2;

            invoicesGrid.AllowUserToAddRows = false;
            invoicesGrid.AllowUserToDeleteRows = false;
            invoicesGrid.AllowUserToResizeRows = false;
            invoicesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            invoicesGrid.BackgroundColor = Color.White;
            invoicesGrid.BorderStyle = BorderStyle.None;
            invoicesGrid.ColumnHeadersHeight = 42;
            invoicesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            invoicesGrid.Columns.AddRange(new DataGridViewColumn[] { columnCreatedAt, columnInvoiceCode, columnCustomerName, columnCustomerPhone, columnCreatedBy, columnTotalAmount, columnDiscount, columnFinalAmount, columnViewDetail });
            ConfigureGrid(invoicesGrid);
            invoicesGrid.Dock = DockStyle.Fill;
            invoicesGrid.Location = new Point(16, 16);
            invoicesGrid.MultiSelect = false;
            invoicesGrid.Name = "invoicesGrid";
            invoicesGrid.ReadOnly = true;
            invoicesGrid.RowHeadersVisible = false;
            invoicesGrid.RowTemplate.Height = 38;
            invoicesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            invoicesGrid.Size = new Size(844, 378);
            invoicesGrid.TabIndex = 0;

            columnCreatedAt.FillWeight = 105F;
            columnCreatedAt.HeaderText = "Thời gian";
            columnCreatedAt.Name = "columnCreatedAt";
            columnCreatedAt.ReadOnly = true;

            columnInvoiceCode.FillWeight = 86F;
            columnInvoiceCode.HeaderText = "Mã hóa đơn";
            columnInvoiceCode.Name = "columnInvoiceCode";
            columnInvoiceCode.ReadOnly = true;

            columnCustomerName.FillWeight = 120F;
            columnCustomerName.HeaderText = "Khách hàng";
            columnCustomerName.Name = "columnCustomerName";
            columnCustomerName.ReadOnly = true;

            columnCustomerPhone.FillWeight = 90F;
            columnCustomerPhone.HeaderText = "Số điện thoại";
            columnCustomerPhone.Name = "columnCustomerPhone";
            columnCustomerPhone.ReadOnly = true;

            columnCreatedBy.FillWeight = 105F;
            columnCreatedBy.HeaderText = "Nhân viên";
            columnCreatedBy.Name = "columnCreatedBy";
            columnCreatedBy.ReadOnly = true;

            columnTotalAmount.FillWeight = 86F;
            columnTotalAmount.HeaderText = "Tiền hàng";
            columnTotalAmount.Name = "columnTotalAmount";
            columnTotalAmount.ReadOnly = true;

            columnDiscount.FillWeight = 72F;
            columnDiscount.HeaderText = "Giảm giá";
            columnDiscount.Name = "columnDiscount";
            columnDiscount.ReadOnly = true;

            columnFinalAmount.FillWeight = 92F;
            columnFinalAmount.HeaderText = "Thanh toán";
            columnFinalAmount.Name = "columnFinalAmount";
            columnFinalAmount.ReadOnly = true;

            columnViewDetail.FillWeight = 90F;
            columnViewDetail.HeaderText = "Chi tiết";
            columnViewDetail.Name = "columnViewDetail";
            columnViewDetail.Text = "Xem chi tiết";
            columnViewDetail.UseColumnTextForButtonValue = true;
            columnViewDetail.ReadOnly = false;

            panelRoot.ResumeLayout(false);
            panelTable.ResumeLayout(false);
            ((ISupportInitialize)invoicesGrid).EndInit();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            panelIntro.ResumeLayout(false);
            panelIntro.PerformLayout();
            tableSummary.ResumeLayout(false);
            panelInvoiceCount.ResumeLayout(false);
            panelInvoiceCount.PerformLayout();
            panelItemCount.ResumeLayout(false);
            panelItemCount.PerformLayout();
            panelTotalAmount.ResumeLayout(false);
            panelTotalAmount.PerformLayout();
            panelDiscount.ResumeLayout(false);
            panelDiscount.PerformLayout();
            panelFinalAmount.ResumeLayout(false);
            panelFinalAmount.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private static void ConfigureGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Color.FromArgb(233, 236, 239);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 239, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(51, 51, 51);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 253, 255);

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private static void ConfigureSummaryPanel(Panel panel, Label titleLabel, Label valueLabel, string title)
        {
            panel.Controls.Add(valueLabel);
            panel.Controls.Add(titleLabel);
            panel.Dock = DockStyle.Fill;
            panel.Margin = new Padding(4, 0, 0, 0);

            titleLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            titleLabel.AutoEllipsis = true;
            titleLabel.AutoSize = false;
            titleLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.FromArgb(102, 102, 102);
            titleLabel.Location = new Point(4, 6);
            titleLabel.Size = new Size(84, 18);
            titleLabel.TabIndex = 0;
            titleLabel.Text = title;

            valueLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            valueLabel.AutoEllipsis = true;
            valueLabel.AutoSize = false;
            valueLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            valueLabel.ForeColor = Color.FromArgb(51, 51, 51);
            valueLabel.Location = new Point(3, 32);
            valueLabel.Size = new Size(85, 24);
            valueLabel.TabIndex = 1;
            valueLabel.Text = "0";
        }

        private Panel panelRoot;
        private RoundedPanel panelIntro;
        private Label labelIntroTitle;
        private Label labelIntroDescription;
        private TableLayoutPanel tableSummary;
        private Panel panelInvoiceCount;
        private Label labelInvoiceCountTitle;
        private Label labelInvoiceCountValue;
        private Panel panelItemCount;
        private Label labelItemCountTitle;
        private Label labelItemCountValue;
        private Panel panelTotalAmount;
        private Label labelTotalAmountTitle;
        private Label labelTotalAmountValue;
        private Panel panelDiscount;
        private Label labelDiscountTitle;
        private Label labelDiscountValue;
        private Panel panelFinalAmount;
        private Label labelFinalAmountTitle;
        private Label labelFinalAmountValue;
        private RoundedPanel panelToolbar;
        private Label labelSearchInvoice;
        private RoundedTextBox textSearchInvoice;
        private Label labelStatusFilter;
        private ComboBox comboStatusFilter;
        private Label labelDateFrom;
        private DateTimePicker dateFromPicker;
        private Label labelDateTo;
        private DateTimePicker dateToPicker;
        private RoundedButton buttonRefresh;
        private RoundedPanel panelTable;
        private DataGridView invoicesGrid;
        private DataGridViewTextBoxColumn columnCreatedAt;
        private DataGridViewTextBoxColumn columnInvoiceCode;
        private DataGridViewTextBoxColumn columnCustomerName;
        private DataGridViewTextBoxColumn columnCustomerPhone;
        private DataGridViewTextBoxColumn columnCreatedBy;
        private DataGridViewTextBoxColumn columnTotalAmount;
        private DataGridViewTextBoxColumn columnDiscount;
        private DataGridViewTextBoxColumn columnFinalAmount;
        private DataGridViewButtonColumn columnViewDetail;
    }
}
