using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    partial class EmployeeManagementView
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
            employeesGrid = new DataGridView();
            columnUsername = new DataGridViewTextBoxColumn();
            columnFullName = new DataGridViewTextBoxColumn();
            columnEmail = new DataGridViewTextBoxColumn();
            columnPhone = new DataGridViewTextBoxColumn();
            columnRole = new DataGridViewTextBoxColumn();
            columnStatus = new DataGridViewTextBoxColumn();
            panelGap = new Panel();
            panelToolbar = new RoundedPanel();
            buttonLockEmployee = new RoundedButton();
            buttonEditEmployee = new RoundedButton();
            buttonAddEmployee = new RoundedButton();
            comboRoleFilter = new ComboBox();
            comboStatusFilter = new ComboBox();
            textSearchEmployee = new RoundedTextBox();
            panelRoot.SuspendLayout();
            panelTable.SuspendLayout();
            ((ISupportInitialize)employeesGrid).BeginInit();
            panelToolbar.SuspendLayout();
            SuspendLayout();

            // UserControl
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(panelRoot);
            Dock = DockStyle.Fill;
            Name = "EmployeeManagementView";
            Size = new Size(876, 610);

            // panelRoot — outer padding gives breathing room
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
            panelToolbar.Controls.Add(buttonLockEmployee);
            panelToolbar.Controls.Add(buttonEditEmployee);
            panelToolbar.Controls.Add(buttonAddEmployee);
            panelToolbar.Controls.Add(comboRoleFilter);
            panelToolbar.Controls.Add(comboStatusFilter);
            panelToolbar.Controls.Add(textSearchEmployee);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(844, 68);
            panelToolbar.TabIndex = 0;

            // textSearchEmployee — vertically centered in 68px toolbar
            textSearchEmployee.BackColor = Color.White;
            textSearchEmployee.BorderColor = Color.FromArgb(180, 190, 200);
            textSearchEmployee.BorderRadius = 10;
            textSearchEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textSearchEmployee.ForeColor = Color.FromArgb(51, 51, 51);
            textSearchEmployee.Location = new Point(20, 15);
            textSearchEmployee.Name = "textSearchEmployee";
            textSearchEmployee.PlaceholderText = "Tìm kiếm tên, tài khoản...";
            textSearchEmployee.Size = new Size(230, 38);
            textSearchEmployee.TabIndex = 0;

            // comboStatusFilter
            comboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStatusFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboStatusFilter.FormattingEnabled = true;
            comboStatusFilter.Items.AddRange(new object[] { "Tất cả", "Đang hoạt động", "Đã khóa" });
            comboStatusFilter.Location = new Point(262, 19);
            comboStatusFilter.Name = "comboStatusFilter";
            comboStatusFilter.Size = new Size(148, 25);
            comboStatusFilter.TabIndex = 1;

            // comboRoleFilter
            comboRoleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRoleFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboRoleFilter.FormattingEnabled = true;
            comboRoleFilter.Items.AddRange(new object[] { "Tất cả", "Admin", "Staff" });
            comboRoleFilter.Location = new Point(422, 19);
            comboRoleFilter.Name = "comboRoleFilter";
            comboRoleFilter.Size = new Size(120, 25);
            comboRoleFilter.TabIndex = 2;

            // buttonAddEmployee — success green
            buttonAddEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddEmployee.BackColor = Color.FromArgb(25, 135, 84);
            buttonAddEmployee.BorderRadius = 12;
            buttonAddEmployee.BorderSize = 0;
            buttonAddEmployee.FlatAppearance.BorderSize = 0;
            buttonAddEmployee.FlatStyle = FlatStyle.Flat;
            buttonAddEmployee.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAddEmployee.ForeColor = Color.White;
            buttonAddEmployee.HoverBackColor = Color.FromArgb(20, 115, 72);
            buttonAddEmployee.Location = new Point(550, 15);
            buttonAddEmployee.Name = "buttonAddEmployee";
            buttonAddEmployee.Size = new Size(90, 38);
            buttonAddEmployee.TabIndex = 3;
            buttonAddEmployee.Text = "Thêm";
            buttonAddEmployee.UseVisualStyleBackColor = false;

            // buttonEditEmployee — warning amber
            buttonEditEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEditEmployee.BackColor = Color.FromArgb(255, 153, 0);
            buttonEditEmployee.BorderRadius = 12;
            buttonEditEmployee.BorderSize = 0;
            buttonEditEmployee.FlatAppearance.BorderSize = 0;
            buttonEditEmployee.FlatStyle = FlatStyle.Flat;
            buttonEditEmployee.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEditEmployee.ForeColor = Color.White;
            buttonEditEmployee.HoverBackColor = Color.FromArgb(230, 138, 0);
            buttonEditEmployee.Location = new Point(648, 15);
            buttonEditEmployee.Name = "buttonEditEmployee";
            buttonEditEmployee.Size = new Size(80, 38);
            buttonEditEmployee.TabIndex = 4;
            buttonEditEmployee.Text = "Sửa";
            buttonEditEmployee.UseVisualStyleBackColor = false;

            // buttonLockEmployee — danger red; text toggles "Khóa"/"Mở" at runtime
            buttonLockEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLockEmployee.BackColor = Color.FromArgb(220, 53, 69);
            buttonLockEmployee.BorderRadius = 12;
            buttonLockEmployee.BorderSize = 0;
            buttonLockEmployee.FlatAppearance.BorderSize = 0;
            buttonLockEmployee.FlatStyle = FlatStyle.Flat;
            buttonLockEmployee.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLockEmployee.ForeColor = Color.White;
            buttonLockEmployee.HoverBackColor = Color.FromArgb(201, 48, 62);
            buttonLockEmployee.Location = new Point(736, 15);
            buttonLockEmployee.Name = "buttonLockEmployee";
            buttonLockEmployee.Size = new Size(88, 38);
            buttonLockEmployee.TabIndex = 5;
            buttonLockEmployee.Text = "Khóa";
            buttonLockEmployee.UseVisualStyleBackColor = false;

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
            panelTable.Controls.Add(employeesGrid);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(1);
            panelTable.TabIndex = 2;

            // employeesGrid
            employeesGrid.AllowUserToAddRows = false;
            employeesGrid.AllowUserToDeleteRows = false;
            employeesGrid.AllowUserToResizeColumns = false;
            employeesGrid.AllowUserToResizeRows = false;
            employeesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            employeesGrid.BackgroundColor = Color.White;
            employeesGrid.BorderStyle = BorderStyle.None;
            employeesGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            employeesGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            employeesGrid.ColumnHeadersHeight = 44;
            employeesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            employeesGrid.Columns.AddRange(new DataGridViewColumn[] { columnUsername, columnFullName, columnEmail, columnPhone, columnRole, columnStatus });
            foreach (DataGridViewColumn col in employeesGrid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            employeesGrid.Dock = DockStyle.Fill;
            employeesGrid.EnableHeadersVisualStyles = false;
            employeesGrid.GridColor = Color.FromArgb(233, 236, 239);
            employeesGrid.MultiSelect = false;
            employeesGrid.Name = "employeesGrid";
            employeesGrid.ReadOnly = true;
            employeesGrid.RowHeadersVisible = false;
            employeesGrid.RowTemplate.Height = 42;
            employeesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeesGrid.TabIndex = 0;

            // Header style
            employeesGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            employeesGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(73, 80, 87);
            employeesGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            employeesGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 249, 250);
            employeesGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            // Cell style
            employeesGrid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            employeesGrid.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
            employeesGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            employeesGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            employeesGrid.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            employeesGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);

            // columnUsername
            columnUsername.HeaderText = "Tài khoản";
            columnUsername.Name = "columnUsername";
            columnUsername.ReadOnly = true;
            columnUsername.FillWeight = 100;

            // columnFullName
            columnFullName.HeaderText = "Họ tên";
            columnFullName.Name = "columnFullName";
            columnFullName.ReadOnly = true;
            columnFullName.FillWeight = 155;

            // columnEmail
            columnEmail.HeaderText = "Email";
            columnEmail.Name = "columnEmail";
            columnEmail.ReadOnly = true;
            columnEmail.FillWeight = 195;

            // columnPhone
            columnPhone.HeaderText = "Số điện thoại";
            columnPhone.Name = "columnPhone";
            columnPhone.ReadOnly = true;
            columnPhone.FillWeight = 105;

            // columnRole — centered, bold for Admin at runtime
            columnRole.HeaderText = "Vai trò";
            columnRole.Name = "columnRole";
            columnRole.ReadOnly = true;
            columnRole.FillWeight = 80;
            columnRole.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnRole.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // columnStatus — color-coded at runtime
            columnStatus.HeaderText = "Trạng thái";
            columnStatus.Name = "columnStatus";
            columnStatus.ReadOnly = true;
            columnStatus.FillWeight = 115;

            panelRoot.ResumeLayout(false);
            panelTable.ResumeLayout(false);
            ((ISupportInitialize)employeesGrid).EndInit();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRoot;
        private Panel panelGap;
        private RoundedPanel panelToolbar;
        private RoundedTextBox textSearchEmployee;
        private ComboBox comboStatusFilter;
        private ComboBox comboRoleFilter;
        private RoundedButton buttonAddEmployee;
        private RoundedButton buttonEditEmployee;
        private RoundedButton buttonLockEmployee;
        private RoundedPanel panelTable;
        private DataGridView employeesGrid;
        private DataGridViewTextBoxColumn columnUsername;
        private DataGridViewTextBoxColumn columnFullName;
        private DataGridViewTextBoxColumn columnEmail;
        private DataGridViewTextBoxColumn columnPhone;
        private DataGridViewTextBoxColumn columnRole;
        private DataGridViewTextBoxColumn columnStatus;
    }
}
