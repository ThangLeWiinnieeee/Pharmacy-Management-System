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
            medicinesGrid = new DataGridView();
            columnCode = new DataGridViewTextBoxColumn();
            columnName = new DataGridViewTextBoxColumn();
            columnUnit = new DataGridViewTextBoxColumn();
            columnQuantity = new DataGridViewTextBoxColumn();
            columnSellPrice = new DataGridViewTextBoxColumn();
            columnExpiryDate = new DataGridViewTextBoxColumn();
            columnStatus = new DataGridViewTextBoxColumn();
            panelToolbar = new RoundedPanel();
            buttonDeleteMedicine = new RoundedButton();
            buttonEditMedicine = new RoundedButton();
            buttonAddMedicine = new RoundedButton();
            comboStatusFilter = new ComboBox();
            labelStatusFilter = new Label();
            textSearchMedicine = new RoundedTextBox();
            labelSearchMedicine = new Label();
            panelIntro = new RoundedPanel();
            labelIntroTitle = new Label();
            labelIntroDescription = new Label();
            panelRoot.SuspendLayout();
            panelTable.SuspendLayout();
            ((ISupportInitialize)medicinesGrid).BeginInit();
            panelToolbar.SuspendLayout();
            panelIntro.SuspendLayout();
            SuspendLayout();

            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(panelRoot);
            Dock = DockStyle.Fill;
            Name = "MedicineManagementView";
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
            panelIntro.Controls.Add(labelIntroTitle);
            panelIntro.Controls.Add(labelIntroDescription);
            panelIntro.Dock = DockStyle.Top;
            panelIntro.Location = new Point(0, 0);
            panelIntro.Margin = new Padding(0, 0, 0, 18);
            panelIntro.Name = "panelIntro";
            panelIntro.Size = new Size(876, 108);
            panelIntro.TabIndex = 0;

            labelIntroTitle.AutoSize = true;
            labelIntroTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
            labelIntroTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelIntroTitle.Location = new Point(28, 22);
            labelIntroTitle.Name = "labelIntroTitle";
            labelIntroTitle.Size = new Size(165, 31);
            labelIntroTitle.TabIndex = 0;
            labelIntroTitle.Text = "Quản lý thuốc";

            labelIntroDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            labelIntroDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelIntroDescription.ForeColor = Color.FromArgb(102, 102, 102);
            labelIntroDescription.Location = new Point(31, 62);
            labelIntroDescription.Name = "labelIntroDescription";
            labelIntroDescription.Size = new Size(812, 24);
            labelIntroDescription.TabIndex = 1;
            labelIntroDescription.Text = "Theo dõi danh mục thuốc, tồn kho, giá bán và trạng thái kinh doanh.";

            panelToolbar.BackColor = Color.White;
            panelToolbar.BorderColor = Color.FromArgb(224, 229, 235);
            panelToolbar.BorderRadius = 16;
            panelToolbar.BorderSize = 1;
            panelToolbar.Controls.Add(buttonDeleteMedicine);
            panelToolbar.Controls.Add(buttonEditMedicine);
            panelToolbar.Controls.Add(buttonAddMedicine);
            panelToolbar.Controls.Add(comboStatusFilter);
            panelToolbar.Controls.Add(labelStatusFilter);
            panelToolbar.Controls.Add(textSearchMedicine);
            panelToolbar.Controls.Add(labelSearchMedicine);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 108);
            panelToolbar.Margin = new Padding(0, 18, 0, 18);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(876, 96);
            panelToolbar.TabIndex = 1;

            labelSearchMedicine.AutoSize = true;
            labelSearchMedicine.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelSearchMedicine.ForeColor = Color.FromArgb(51, 51, 51);
            labelSearchMedicine.Location = new Point(24, 18);
            labelSearchMedicine.Name = "labelSearchMedicine";
            labelSearchMedicine.Size = new Size(64, 17);
            labelSearchMedicine.TabIndex = 0;
            labelSearchMedicine.Text = "Tìm kiếm";

            textSearchMedicine.BackColor = Color.White;
            textSearchMedicine.BorderColor = Color.FromArgb(170, 183, 196);
            textSearchMedicine.BorderRadius = 10;
            textSearchMedicine.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textSearchMedicine.ForeColor = Color.FromArgb(51, 51, 51);
            textSearchMedicine.Location = new Point(24, 42);
            textSearchMedicine.Name = "textSearchMedicine";
            textSearchMedicine.Size = new Size(280, 38);
            textSearchMedicine.TabIndex = 1;

            labelStatusFilter.AutoSize = true;
            labelStatusFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelStatusFilter.ForeColor = Color.FromArgb(51, 51, 51);
            labelStatusFilter.Location = new Point(326, 18);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Size = new Size(70, 17);
            labelStatusFilter.TabIndex = 2;
            labelStatusFilter.Text = "Trạng thái";

            comboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStatusFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboStatusFilter.FormattingEnabled = true;
            comboStatusFilter.Items.AddRange(new object[] { "Tất cả", "Đang kinh doanh", "Ngừng bán", "Sắp hết hàng", "Sắp hết hạn" });
            comboStatusFilter.Location = new Point(326, 47);
            comboStatusFilter.Name = "comboStatusFilter";
            comboStatusFilter.Size = new Size(180, 25);
            comboStatusFilter.TabIndex = 3;

            buttonAddMedicine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddMedicine.BackColor = Color.FromArgb(0, 123, 255);
            buttonAddMedicine.BorderRadius = 12;
            buttonAddMedicine.BorderSize = 0;
            buttonAddMedicine.FlatAppearance.BorderSize = 0;
            buttonAddMedicine.FlatStyle = FlatStyle.Flat;
            buttonAddMedicine.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAddMedicine.ForeColor = Color.White;
            buttonAddMedicine.HoverBackColor = Color.FromArgb(0, 113, 235);
            buttonAddMedicine.Location = new Point(540, 42);
            buttonAddMedicine.Name = "buttonAddMedicine";
            buttonAddMedicine.Size = new Size(100, 38);
            buttonAddMedicine.TabIndex = 4;
            buttonAddMedicine.Text = "Thêm";
            buttonAddMedicine.UseVisualStyleBackColor = false;

            buttonEditMedicine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEditMedicine.BackColor = Color.FromArgb(40, 167, 69);
            buttonEditMedicine.BorderRadius = 12;
            buttonEditMedicine.BorderSize = 0;
            buttonEditMedicine.FlatAppearance.BorderSize = 0;
            buttonEditMedicine.FlatStyle = FlatStyle.Flat;
            buttonEditMedicine.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEditMedicine.ForeColor = Color.White;
            buttonEditMedicine.HoverBackColor = Color.FromArgb(37, 154, 64);
            buttonEditMedicine.Location = new Point(650, 42);
            buttonEditMedicine.Name = "buttonEditMedicine";
            buttonEditMedicine.Size = new Size(90, 38);
            buttonEditMedicine.TabIndex = 5;
            buttonEditMedicine.Text = "Sửa";
            buttonEditMedicine.UseVisualStyleBackColor = false;

            buttonDeleteMedicine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDeleteMedicine.BackColor = Color.FromArgb(220, 53, 69);
            buttonDeleteMedicine.BorderRadius = 12;
            buttonDeleteMedicine.BorderSize = 0;
            buttonDeleteMedicine.FlatAppearance.BorderSize = 0;
            buttonDeleteMedicine.FlatStyle = FlatStyle.Flat;
            buttonDeleteMedicine.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDeleteMedicine.ForeColor = Color.White;
            buttonDeleteMedicine.HoverBackColor = Color.FromArgb(201, 48, 62);
            buttonDeleteMedicine.Location = new Point(750, 42);
            buttonDeleteMedicine.Name = "buttonDeleteMedicine";
            buttonDeleteMedicine.Size = new Size(100, 38);
            buttonDeleteMedicine.TabIndex = 6;
            buttonDeleteMedicine.Text = "Xóa";
            buttonDeleteMedicine.UseVisualStyleBackColor = false;

            panelTable.BackColor = Color.White;
            panelTable.BorderColor = Color.FromArgb(224, 229, 235);
            panelTable.BorderRadius = 16;
            panelTable.BorderSize = 1;
            panelTable.Controls.Add(medicinesGrid);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Location = new Point(0, 204);
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(16);
            panelTable.Size = new Size(876, 406);
            panelTable.TabIndex = 2;

            medicinesGrid.AllowUserToAddRows = false;
            medicinesGrid.AllowUserToDeleteRows = false;
            medicinesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            medicinesGrid.BackgroundColor = Color.White;
            medicinesGrid.BorderStyle = BorderStyle.None;
            medicinesGrid.ColumnHeadersHeight = 42;
            medicinesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            medicinesGrid.Columns.AddRange(new DataGridViewColumn[] { columnCode, columnName, columnUnit, columnQuantity, columnSellPrice, columnExpiryDate, columnStatus });
            medicinesGrid.Dock = DockStyle.Fill;
            medicinesGrid.EnableHeadersVisualStyles = false;
            medicinesGrid.GridColor = Color.FromArgb(233, 236, 239);
            medicinesGrid.Location = new Point(16, 16);
            medicinesGrid.MultiSelect = false;
            medicinesGrid.Name = "medicinesGrid";
            medicinesGrid.ReadOnly = true;
            medicinesGrid.RowHeadersVisible = false;
            medicinesGrid.RowTemplate.Height = 40;
            medicinesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            medicinesGrid.Size = new Size(844, 374);
            medicinesGrid.TabIndex = 0;

            columnCode.HeaderText = "Mã thuốc";
            columnCode.Name = "columnCode";
            columnCode.ReadOnly = true;

            columnName.HeaderText = "Tên thuốc";
            columnName.Name = "columnName";
            columnName.ReadOnly = true;

            columnUnit.HeaderText = "Đơn vị";
            columnUnit.Name = "columnUnit";
            columnUnit.ReadOnly = true;

            columnQuantity.HeaderText = "Tồn kho";
            columnQuantity.Name = "columnQuantity";
            columnQuantity.ReadOnly = true;

            columnSellPrice.HeaderText = "Giá bán";
            columnSellPrice.Name = "columnSellPrice";
            columnSellPrice.ReadOnly = true;

            columnExpiryDate.HeaderText = "Hạn dùng";
            columnExpiryDate.Name = "columnExpiryDate";
            columnExpiryDate.ReadOnly = true;

            columnStatus.HeaderText = "Trạng thái";
            columnStatus.Name = "columnStatus";
            columnStatus.ReadOnly = true;

            panelRoot.ResumeLayout(false);
            panelTable.ResumeLayout(false);
            ((ISupportInitialize)medicinesGrid).EndInit();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            panelIntro.ResumeLayout(false);
            panelIntro.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRoot;
        private RoundedPanel panelIntro;
        private Label labelIntroTitle;
        private Label labelIntroDescription;
        private RoundedPanel panelToolbar;
        private Label labelSearchMedicine;
        private RoundedTextBox textSearchMedicine;
        private Label labelStatusFilter;
        private ComboBox comboStatusFilter;
        private RoundedButton buttonAddMedicine;
        private RoundedButton buttonEditMedicine;
        private RoundedButton buttonDeleteMedicine;
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
