using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    partial class MedicineManagementView
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            panelRoot = new Panel();
            panelTable = new RoundedPanel();
            medicinesGrid = new DataGridView();
            columnCode = new DataGridViewTextBoxColumn();
            columnName = new DataGridViewTextBoxColumn();
            columnUnit = new DataGridViewTextBoxColumn();
            columnQuantity = new DataGridViewTextBoxColumn();
            columnSellPrice = new DataGridViewTextBoxColumn();
            columnExpiryDate = new DataGridViewTextBoxColumn();
            columnStatus = new DataGridViewTextBoxColumn();
            panelGap = new Panel();
            panelToolbar = new RoundedPanel();
            buttonLookupDetail = new RoundedButton();
            buttonDeleteMedicine = new RoundedButton();
            buttonEditMedicine = new RoundedButton();
            buttonAddMedicine = new RoundedButton();
            comboStatusFilter = new ComboBox();
            textSearchMedicine = new RoundedTextBox();
            panelRoot.SuspendLayout();
            panelTable.SuspendLayout();
            ((ISupportInitialize)medicinesGrid).BeginInit();
            panelToolbar.SuspendLayout();
            SuspendLayout();

            // UserControl
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(panelRoot);
            Dock = DockStyle.Fill;
            Name = "MedicineManagementView";
            Size = new Size(876, 610);

            // panelRoot — outer padding gives breathing room around content
            panelRoot.BackColor = Color.FromArgb(248, 249, 250);
            panelRoot.Padding = new Padding(16);
            panelRoot.Controls.Add(panelTable);
            panelRoot.Controls.Add(panelGap);
            panelRoot.Controls.Add(panelToolbar);
            panelRoot.Dock = DockStyle.Fill;
            panelRoot.Location = new Point(0, 0);
            panelRoot.Name = "panelRoot";
            panelRoot.Size = new Size(876, 610);
            panelRoot.TabIndex = 0;

            // panelToolbar — single-row compact layout (68px)
            panelToolbar.BackColor = Color.White;
            panelToolbar.BorderColor = Color.FromArgb(224, 229, 235);
            panelToolbar.BorderRadius = 16;
            panelToolbar.BorderSize = 1;
            panelToolbar.Controls.Add(buttonLookupDetail);
            panelToolbar.Controls.Add(buttonDeleteMedicine);
            panelToolbar.Controls.Add(buttonEditMedicine);
            panelToolbar.Controls.Add(buttonAddMedicine);
            panelToolbar.Controls.Add(comboStatusFilter);
            panelToolbar.Controls.Add(textSearchMedicine);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(844, 68);
            panelToolbar.TabIndex = 0;

            // textSearchMedicine — vertically centered in 68px toolbar
            textSearchMedicine.BackColor = Color.White;
            textSearchMedicine.BorderColor = Color.FromArgb(180, 190, 200);
            textSearchMedicine.BorderRadius = 10;
            textSearchMedicine.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textSearchMedicine.ForeColor = Color.FromArgb(51, 51, 51);
            textSearchMedicine.Location = new Point(20, 15);
            textSearchMedicine.Name = "textSearchMedicine";
            textSearchMedicine.PlaceholderText = "Tìm kiếm mã thuốc, tên thuốc...";
            textSearchMedicine.Size = new Size(240, 38);
            textSearchMedicine.TabIndex = 0;

            // comboStatusFilter
            comboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStatusFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboStatusFilter.FormattingEnabled = true;
            comboStatusFilter.Items.AddRange(new object[] { "Tất cả", "Đang kinh doanh", "Ngừng bán", "Sắp hết hàng", "Sắp hết hạn" });
            comboStatusFilter.Location = new Point(272, 19);
            comboStatusFilter.Name = "comboStatusFilter";
            comboStatusFilter.Size = new Size(150, 25);
            comboStatusFilter.TabIndex = 1;

            // buttonLookupDetail — info blue
            buttonLookupDetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLookupDetail.BackColor = Color.FromArgb(13, 110, 253);
            buttonLookupDetail.BorderRadius = 12;
            buttonLookupDetail.BorderSize = 0;
            buttonLookupDetail.FlatAppearance.BorderSize = 0;
            buttonLookupDetail.FlatStyle = FlatStyle.Flat;
            buttonLookupDetail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLookupDetail.ForeColor = Color.White;
            buttonLookupDetail.HoverBackColor = Color.FromArgb(0, 100, 235);
            buttonLookupDetail.Location = new Point(440, 15);
            buttonLookupDetail.Name = "buttonLookupDetail";
            buttonLookupDetail.Size = new Size(108, 38);
            buttonLookupDetail.TabIndex = 2;
            buttonLookupDetail.Text = "Xem lô";
            buttonLookupDetail.UseVisualStyleBackColor = false;

            // buttonAddMedicine — success green
            buttonAddMedicine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddMedicine.BackColor = Color.FromArgb(25, 135, 84);
            buttonAddMedicine.BorderRadius = 12;
            buttonAddMedicine.BorderSize = 0;
            buttonAddMedicine.FlatAppearance.BorderSize = 0;
            buttonAddMedicine.FlatStyle = FlatStyle.Flat;
            buttonAddMedicine.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAddMedicine.ForeColor = Color.White;
            buttonAddMedicine.HoverBackColor = Color.FromArgb(20, 115, 72);
            buttonAddMedicine.Location = new Point(556, 15);
            buttonAddMedicine.Name = "buttonAddMedicine";
            buttonAddMedicine.Size = new Size(90, 38);
            buttonAddMedicine.TabIndex = 3;
            buttonAddMedicine.Text = "Thêm";
            buttonAddMedicine.UseVisualStyleBackColor = false;

            // buttonEditMedicine — warning amber
            buttonEditMedicine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEditMedicine.BackColor = Color.FromArgb(255, 153, 0);
            buttonEditMedicine.BorderRadius = 12;
            buttonEditMedicine.BorderSize = 0;
            buttonEditMedicine.FlatAppearance.BorderSize = 0;
            buttonEditMedicine.FlatStyle = FlatStyle.Flat;
            buttonEditMedicine.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEditMedicine.ForeColor = Color.White;
            buttonEditMedicine.HoverBackColor = Color.FromArgb(230, 138, 0);
            buttonEditMedicine.Location = new Point(654, 15);
            buttonEditMedicine.Name = "buttonEditMedicine";
            buttonEditMedicine.Size = new Size(80, 38);
            buttonEditMedicine.TabIndex = 4;
            buttonEditMedicine.Text = "Sửa";
            buttonEditMedicine.UseVisualStyleBackColor = false;

            // buttonDeleteMedicine — danger red
            buttonDeleteMedicine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDeleteMedicine.BackColor = Color.FromArgb(220, 53, 69);
            buttonDeleteMedicine.BorderRadius = 12;
            buttonDeleteMedicine.BorderSize = 0;
            buttonDeleteMedicine.FlatAppearance.BorderSize = 0;
            buttonDeleteMedicine.FlatStyle = FlatStyle.Flat;
            buttonDeleteMedicine.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDeleteMedicine.ForeColor = Color.White;
            buttonDeleteMedicine.HoverBackColor = Color.FromArgb(201, 48, 62);
            buttonDeleteMedicine.Location = new Point(742, 15);
            buttonDeleteMedicine.Name = "buttonDeleteMedicine";
            buttonDeleteMedicine.Size = new Size(82, 38);
            buttonDeleteMedicine.TabIndex = 5;
            buttonDeleteMedicine.Text = "Xóa";
            buttonDeleteMedicine.UseVisualStyleBackColor = false;

            // panelGap — spacer between toolbar and table
            panelGap.BackColor = Color.FromArgb(248, 249, 250);
            panelGap.Dock = DockStyle.Top;
            panelGap.Height = 10;
            panelGap.Name = "panelGap";
            panelGap.TabIndex = 1;

            // panelTable
            panelTable.BackColor = Color.White;
            panelTable.BorderColor = Color.FromArgb(224, 229, 235);
            panelTable.BorderRadius = 16;
            panelTable.BorderSize = 1;
            panelTable.Controls.Add(medicinesGrid);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(1);
            panelTable.TabIndex = 2;

            // medicinesGrid
            medicinesGrid.AllowUserToAddRows = false;
            medicinesGrid.AllowUserToDeleteRows = false;
            medicinesGrid.AllowUserToResizeColumns = false;
            medicinesGrid.AllowUserToResizeRows = false;
            medicinesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            medicinesGrid.BackgroundColor = Color.White;
            medicinesGrid.BorderStyle = BorderStyle.None;
            medicinesGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            medicinesGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            medicinesGrid.ColumnHeadersHeight = 44;
            medicinesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            medicinesGrid.Columns.AddRange(new DataGridViewColumn[] { columnCode, columnName, columnUnit, columnQuantity, columnSellPrice, columnExpiryDate, columnStatus });
            foreach (DataGridViewColumn col in medicinesGrid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            medicinesGrid.Dock = DockStyle.Fill;
            medicinesGrid.EnableHeadersVisualStyles = false;
            medicinesGrid.GridColor = Color.FromArgb(233, 236, 239);
            medicinesGrid.MultiSelect = false;
            medicinesGrid.Name = "medicinesGrid";
            medicinesGrid.ReadOnly = true;
            medicinesGrid.RowHeadersVisible = false;
            medicinesGrid.RowTemplate.Height = 42;
            medicinesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            medicinesGrid.TabIndex = 0;

            // Header style
            medicinesGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            medicinesGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(73, 80, 87);
            medicinesGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            medicinesGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 249, 250);
            medicinesGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            // Cell style
            medicinesGrid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            medicinesGrid.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
            medicinesGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            medicinesGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            medicinesGrid.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            medicinesGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);

            // columnCode
            columnCode.HeaderText = "Mã thuốc";
            columnCode.Name = "columnCode";
            columnCode.ReadOnly = true;
            columnCode.FillWeight = 90;

            // columnName
            columnName.HeaderText = "Tên thuốc";
            columnName.Name = "columnName";
            columnName.ReadOnly = true;
            columnName.FillWeight = 215;

            // columnUnit
            columnUnit.HeaderText = "Đơn vị";
            columnUnit.Name = "columnUnit";
            columnUnit.ReadOnly = true;
            columnUnit.FillWeight = 68;
            columnUnit.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnUnit.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // columnQuantity — right-aligned
            columnQuantity.HeaderText = "Tồn kho";
            columnQuantity.Name = "columnQuantity";
            columnQuantity.ReadOnly = true;
            columnQuantity.FillWeight = 85;
            columnQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnQuantity.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnQuantity.DefaultCellStyle.Padding = new Padding(0, 0, 14, 0);
            columnQuantity.HeaderCell.Style.Padding = new Padding(0, 0, 14, 0);

            // columnSellPrice — right-aligned
            columnSellPrice.HeaderText = "Giá bán";
            columnSellPrice.Name = "columnSellPrice";
            columnSellPrice.ReadOnly = true;
            columnSellPrice.FillWeight = 105;
            columnSellPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnSellPrice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            columnSellPrice.DefaultCellStyle.Padding = new Padding(0, 0, 14, 0);
            columnSellPrice.HeaderCell.Style.Padding = new Padding(0, 0, 14, 0);

            // columnExpiryDate
            columnExpiryDate.HeaderText = "Hạn dùng";
            columnExpiryDate.Name = "columnExpiryDate";
            columnExpiryDate.ReadOnly = true;
            columnExpiryDate.FillWeight = 95;

            // columnStatus
            columnStatus.HeaderText = "Trạng thái";
            columnStatus.Name = "columnStatus";
            columnStatus.ReadOnly = true;
            columnStatus.FillWeight = 100;

            panelRoot.ResumeLayout(false);
            panelTable.ResumeLayout(false);
            ((ISupportInitialize)medicinesGrid).EndInit();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRoot;
        private Panel panelGap;
        private RoundedPanel panelToolbar;
        private RoundedTextBox textSearchMedicine;
        private ComboBox comboStatusFilter;
        private RoundedButton buttonAddMedicine;
        private RoundedButton buttonEditMedicine;
        private RoundedButton buttonDeleteMedicine;
        private RoundedButton buttonLookupDetail;
        private RoundedPanel panelTable;
        private DataGridView medicinesGrid;
        private DataGridViewTextBoxColumn columnCode;
        private DataGridViewTextBoxColumn columnName;
        private DataGridViewTextBoxColumn columnUnit;
        private DataGridViewTextBoxColumn columnQuantity;
        private DataGridViewTextBoxColumn columnSellPrice;
        private DataGridViewTextBoxColumn columnExpiryDate;
        private DataGridViewTextBoxColumn columnStatus;
    }
}
