using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    partial class CustomerManagementView
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            panelRoot = new Panel();
            panelTable = new RoundedPanel();
            customersGrid = new DataGridView();
            columnName = new DataGridViewTextBoxColumn();
            columnPhone = new DataGridViewTextBoxColumn();
            columnAddress = new DataGridViewTextBoxColumn();
            columnCreatedAt = new DataGridViewTextBoxColumn();
            columnTotalPurchases = new DataGridViewTextBoxColumn();
            columnInvoiceCount = new DataGridViewTextBoxColumn();
            panelToolbar = new RoundedPanel();
            buttonDelete = new RoundedButton();
            buttonEdit = new RoundedButton();
            buttonAdd = new RoundedButton();
            textSearch = new RoundedTextBox();
            labelSearch = new Label();
            panelIntro = new RoundedPanel();
            labelIntroTitle = new Label();
            labelIntroDescription = new Label();
            panelRoot.SuspendLayout();
            panelTable.SuspendLayout();
            ((ISupportInitialize)customersGrid).BeginInit();
            panelToolbar.SuspendLayout();
            panelIntro.SuspendLayout();
            SuspendLayout();

            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(panelRoot);
            Dock = DockStyle.Fill;
            Name = "CustomerManagementView";
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

            // panelIntro
            panelIntro.BackColor = Color.White;
            panelIntro.BorderColor = Color.FromArgb(224, 229, 235);
            panelIntro.BorderRadius = 18;
            panelIntro.BorderSize = 1;
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
            labelIntroTitle.Location = new Point(28, 22);
            labelIntroTitle.Name = "labelIntroTitle";
            labelIntroTitle.TabIndex = 0;
            labelIntroTitle.Text = "Quản lý khách hàng";

            labelIntroDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            labelIntroDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelIntroDescription.ForeColor = Color.FromArgb(102, 102, 102);
            labelIntroDescription.Location = new Point(31, 62);
            labelIntroDescription.Name = "labelIntroDescription";
            labelIntroDescription.Size = new Size(812, 24);
            labelIntroDescription.TabIndex = 1;
            labelIntroDescription.Text = "Danh sách khách hàng, thông tin liên hệ và lịch sử mua hàng.";

            // panelToolbar
            panelToolbar.BackColor = Color.White;
            panelToolbar.BorderColor = Color.FromArgb(224, 229, 235);
            panelToolbar.BorderRadius = 16;
            panelToolbar.BorderSize = 1;
            panelToolbar.Controls.Add(buttonDelete);
            panelToolbar.Controls.Add(buttonEdit);
            panelToolbar.Controls.Add(buttonAdd);
            panelToolbar.Controls.Add(textSearch);
            panelToolbar.Controls.Add(labelSearch);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 108);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(876, 84);
            panelToolbar.TabIndex = 1;

            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelSearch.ForeColor = Color.FromArgb(51, 51, 51);
            labelSearch.Location = new Point(24, 14);
            labelSearch.Name = "labelSearch";
            labelSearch.TabIndex = 0;
            labelSearch.Text = "Tìm kiếm";

            textSearch.BackColor = Color.White;
            textSearch.BorderColor = Color.FromArgb(170, 183, 196);
            textSearch.BorderRadius = 10;
            textSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textSearch.ForeColor = Color.FromArgb(51, 51, 51);
            textSearch.Location = new Point(24, 36);
            textSearch.Name = "textSearch";
            textSearch.PlaceholderText = "Tên hoặc số điện thoại...";
            textSearch.Size = new Size(250, 38);
            textSearch.TabIndex = 1;

            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAdd.BackColor = Color.FromArgb(0, 123, 255);
            buttonAdd.BorderRadius = 12;
            buttonAdd.BorderSize = 0;
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAdd.ForeColor = Color.White;
            buttonAdd.HoverBackColor = Color.FromArgb(0, 113, 235);
            buttonAdd.Location = new Point(612, 36);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(92, 38);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Thêm";
            buttonAdd.UseVisualStyleBackColor = false;

            buttonEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEdit.BackColor = Color.FromArgb(40, 167, 69);
            buttonEdit.BorderRadius = 12;
            buttonEdit.BorderSize = 0;
            buttonEdit.FlatAppearance.BorderSize = 0;
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEdit.ForeColor = Color.White;
            buttonEdit.HoverBackColor = Color.FromArgb(37, 154, 64);
            buttonEdit.Location = new Point(714, 36);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(72, 38);
            buttonEdit.TabIndex = 3;
            buttonEdit.Text = "Sửa";
            buttonEdit.UseVisualStyleBackColor = false;

            buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDelete.BackColor = Color.FromArgb(220, 53, 69);
            buttonDelete.BorderRadius = 12;
            buttonDelete.BorderSize = 0;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.HoverBackColor = Color.FromArgb(201, 48, 62);
            buttonDelete.Location = new Point(796, 36);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(56, 38);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Xóa";
            buttonDelete.UseVisualStyleBackColor = false;

            // panelTable
            panelTable.BackColor = Color.White;
            panelTable.BorderColor = Color.FromArgb(224, 229, 235);
            panelTable.BorderRadius = 16;
            panelTable.BorderSize = 1;
            panelTable.Controls.Add(customersGrid);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Location = new Point(0, 192);
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(16);
            panelTable.Size = new Size(876, 418);
            panelTable.TabIndex = 2;

            customersGrid.AllowUserToAddRows = false;
            customersGrid.AllowUserToDeleteRows = false;
            customersGrid.AllowUserToResizeColumns = false;
            customersGrid.AllowUserToResizeRows = false;
            customersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customersGrid.BackgroundColor = Color.White;
            customersGrid.BorderStyle = BorderStyle.None;
            customersGrid.ColumnHeadersHeight = 42;
            customersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            customersGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                columnName, columnPhone, columnAddress,
                columnCreatedAt, columnTotalPurchases, columnInvoiceCount
            });
            foreach (DataGridViewColumn col in customersGrid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            customersGrid.Dock = DockStyle.Fill;
            customersGrid.EnableHeadersVisualStyles = false;
            customersGrid.GridColor = Color.FromArgb(233, 236, 239);
            customersGrid.Location = new Point(16, 16);
            customersGrid.MultiSelect = false;
            customersGrid.Name = "customersGrid";
            customersGrid.ReadOnly = true;
            customersGrid.RowHeadersVisible = false;
            customersGrid.RowTemplate.Height = 40;
            customersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customersGrid.Size = new Size(844, 386);
            customersGrid.TabIndex = 0;

            columnName.FillWeight = 180F;
            columnName.HeaderText = "Họ tên";
            columnName.Name = "columnName";
            columnName.ReadOnly = true;

            columnPhone.FillWeight = 90F;
            columnPhone.HeaderText = "Số điện thoại";
            columnPhone.Name = "columnPhone";
            columnPhone.ReadOnly = true;

            columnAddress.FillWeight = 150F;
            columnAddress.HeaderText = "Địa chỉ";
            columnAddress.Name = "columnAddress";
            columnAddress.ReadOnly = true;

            columnCreatedAt.FillWeight = 88F;
            columnCreatedAt.HeaderText = "Ngày đăng ký";
            columnCreatedAt.Name = "columnCreatedAt";
            columnCreatedAt.ReadOnly = true;

            columnTotalPurchases.FillWeight = 108F;
            columnTotalPurchases.HeaderText = "Tổng mua (₫)";
            columnTotalPurchases.Name = "columnTotalPurchases";
            columnTotalPurchases.ReadOnly = true;
            columnTotalPurchases.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            columnInvoiceCount.FillWeight = 64F;
            columnInvoiceCount.HeaderText = "Hóa đơn";
            columnInvoiceCount.Name = "columnInvoiceCount";
            columnInvoiceCount.ReadOnly = true;
            columnInvoiceCount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            panelRoot.ResumeLayout(false);
            panelTable.ResumeLayout(false);
            ((ISupportInitialize)customersGrid).EndInit();
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
        private Label labelSearch;
        private RoundedTextBox textSearch;
        private RoundedButton buttonAdd;
        private RoundedButton buttonEdit;
        private RoundedButton buttonDelete;
        private RoundedPanel panelTable;
        private DataGridView customersGrid;
        private DataGridViewTextBoxColumn columnName;
        private DataGridViewTextBoxColumn columnPhone;
        private DataGridViewTextBoxColumn columnAddress;
        private DataGridViewTextBoxColumn columnCreatedAt;
        private DataGridViewTextBoxColumn columnTotalPurchases;
        private DataGridViewTextBoxColumn columnInvoiceCount;
    }
}
