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
            employeesGrid = new DataGridView();
            columnUsername = new DataGridViewTextBoxColumn();
            columnFullName = new DataGridViewTextBoxColumn();
            columnEmail = new DataGridViewTextBoxColumn();
            columnPhone = new DataGridViewTextBoxColumn();
            columnRole = new DataGridViewTextBoxColumn();
            columnStatus = new DataGridViewTextBoxColumn();
            panelToolbar = new RoundedPanel();
            buttonLockEmployee = new RoundedButton();
            buttonEditEmployee = new RoundedButton();
            buttonAddEmployee = new RoundedButton();
            comboRoleFilter = new ComboBox();
            labelRoleFilter = new Label();
            comboStatusFilter = new ComboBox();
            labelStatusFilter = new Label();
            textSearchEmployee = new RoundedTextBox();
            labelSearchEmployee = new Label();
            panelIntro = new RoundedPanel();
            labelIntroTitle = new Label();
            labelIntroDescription = new Label();
            panelRoot.SuspendLayout();
            panelTable.SuspendLayout();
            ((ISupportInitialize)employeesGrid).BeginInit();
            panelToolbar.SuspendLayout();
            panelIntro.SuspendLayout();
            SuspendLayout();

            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(panelRoot);
            Dock = DockStyle.Fill;
            Name = "EmployeeManagementView";
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
            panelIntro.Name = "panelIntro";
            panelIntro.Size = new Size(876, 108);
            panelIntro.TabIndex = 0;

            labelIntroTitle.AutoSize = true;
            labelIntroTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
            labelIntroTitle.ForeColor = Color.FromArgb(51, 51, 51);
            labelIntroTitle.Location = new Point(28, 22);
            labelIntroTitle.Name = "labelIntroTitle";
            labelIntroTitle.Size = new Size(221, 31);
            labelIntroTitle.TabIndex = 0;
            labelIntroTitle.Text = "Quản lý nhân viên";

            labelIntroDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            labelIntroDescription.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelIntroDescription.ForeColor = Color.FromArgb(102, 102, 102);
            labelIntroDescription.Location = new Point(31, 62);
            labelIntroDescription.Name = "labelIntroDescription";
            labelIntroDescription.Size = new Size(812, 24);
            labelIntroDescription.TabIndex = 1;
            labelIntroDescription.Text = "Quản lý tài khoản, phân quyền và trạng thái hoạt động của nhân viên.";

            panelToolbar.BackColor = Color.White;
            panelToolbar.BorderColor = Color.FromArgb(224, 229, 235);
            panelToolbar.BorderRadius = 16;
            panelToolbar.BorderSize = 1;
            panelToolbar.Controls.Add(buttonLockEmployee);
            panelToolbar.Controls.Add(buttonEditEmployee);
            panelToolbar.Controls.Add(buttonAddEmployee);
            panelToolbar.Controls.Add(comboRoleFilter);
            panelToolbar.Controls.Add(labelRoleFilter);
            panelToolbar.Controls.Add(comboStatusFilter);
            panelToolbar.Controls.Add(labelStatusFilter);
            panelToolbar.Controls.Add(textSearchEmployee);
            panelToolbar.Controls.Add(labelSearchEmployee);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 108);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Size = new Size(876, 112);
            panelToolbar.TabIndex = 1;

            labelSearchEmployee.AutoSize = true;
            labelSearchEmployee.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelSearchEmployee.ForeColor = Color.FromArgb(51, 51, 51);
            labelSearchEmployee.Location = new Point(24, 18);
            labelSearchEmployee.Name = "labelSearchEmployee";
            labelSearchEmployee.Size = new Size(64, 17);
            labelSearchEmployee.TabIndex = 0;
            labelSearchEmployee.Text = "Tìm kiếm";

            textSearchEmployee.BackColor = Color.White;
            textSearchEmployee.BorderColor = Color.FromArgb(170, 183, 196);
            textSearchEmployee.BorderRadius = 10;
            textSearchEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textSearchEmployee.ForeColor = Color.FromArgb(51, 51, 51);
            textSearchEmployee.Location = new Point(24, 42);
            textSearchEmployee.Name = "textSearchEmployee";
            textSearchEmployee.PlaceholderText = "Tên nhân viên, username...";
            textSearchEmployee.Size = new Size(250, 38);
            textSearchEmployee.TabIndex = 1;

            labelStatusFilter.AutoSize = true;
            labelStatusFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelStatusFilter.ForeColor = Color.FromArgb(51, 51, 51);
            labelStatusFilter.Location = new Point(292, 18);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Size = new Size(70, 17);
            labelStatusFilter.TabIndex = 2;
            labelStatusFilter.Text = "Trạng thái";

            comboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStatusFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboStatusFilter.FormattingEnabled = true;
            comboStatusFilter.Items.AddRange(new object[] { "Tất cả", "Đang hoạt động", "Đã khóa" });
            comboStatusFilter.Location = new Point(292, 47);
            comboStatusFilter.Name = "comboStatusFilter";
            comboStatusFilter.Size = new Size(150, 25);
            comboStatusFilter.TabIndex = 3;

            labelRoleFilter.AutoSize = true;
            labelRoleFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            labelRoleFilter.ForeColor = Color.FromArgb(51, 51, 51);
            labelRoleFilter.Location = new Point(460, 18);
            labelRoleFilter.Name = "labelRoleFilter";
            labelRoleFilter.Size = new Size(44, 17);
            labelRoleFilter.TabIndex = 4;
            labelRoleFilter.Text = "Vai trò";

            comboRoleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRoleFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboRoleFilter.FormattingEnabled = true;
            comboRoleFilter.Items.AddRange(new object[] { "Tất cả", "Admin", "Staff" });
            comboRoleFilter.Location = new Point(460, 47);
            comboRoleFilter.Name = "comboRoleFilter";
            comboRoleFilter.Size = new Size(130, 25);
            comboRoleFilter.TabIndex = 5;

            buttonAddEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddEmployee.BackColor = Color.FromArgb(0, 123, 255);
            buttonAddEmployee.BorderRadius = 12;
            buttonAddEmployee.BorderSize = 0;
            buttonAddEmployee.FlatAppearance.BorderSize = 0;
            buttonAddEmployee.FlatStyle = FlatStyle.Flat;
            buttonAddEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAddEmployee.ForeColor = Color.White;
            buttonAddEmployee.HoverBackColor = Color.FromArgb(0, 113, 235);
            buttonAddEmployee.Location = new Point(612, 42);
            buttonAddEmployee.Name = "buttonAddEmployee";
            buttonAddEmployee.Size = new Size(92, 38);
            buttonAddEmployee.TabIndex = 6;
            buttonAddEmployee.Text = "Thêm";
            buttonAddEmployee.UseVisualStyleBackColor = false;

            buttonEditEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEditEmployee.BackColor = Color.FromArgb(40, 167, 69);
            buttonEditEmployee.BorderRadius = 12;
            buttonEditEmployee.BorderSize = 0;
            buttonEditEmployee.FlatAppearance.BorderSize = 0;
            buttonEditEmployee.FlatStyle = FlatStyle.Flat;
            buttonEditEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEditEmployee.ForeColor = Color.White;
            buttonEditEmployee.HoverBackColor = Color.FromArgb(37, 154, 64);
            buttonEditEmployee.Location = new Point(714, 42);
            buttonEditEmployee.Name = "buttonEditEmployee";
            buttonEditEmployee.Size = new Size(72, 38);
            buttonEditEmployee.TabIndex = 7;
            buttonEditEmployee.Text = "Sửa";
            buttonEditEmployee.UseVisualStyleBackColor = false;

            buttonLockEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLockEmployee.BackColor = Color.FromArgb(220, 53, 69);
            buttonLockEmployee.BorderRadius = 12;
            buttonLockEmployee.BorderSize = 0;
            buttonLockEmployee.FlatAppearance.BorderSize = 0;
            buttonLockEmployee.FlatStyle = FlatStyle.Flat;
            buttonLockEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLockEmployee.ForeColor = Color.White;
            buttonLockEmployee.HoverBackColor = Color.FromArgb(201, 48, 62);
            buttonLockEmployee.Location = new Point(796, 42);
            buttonLockEmployee.Name = "buttonLockEmployee";
            buttonLockEmployee.Size = new Size(56, 38);
            buttonLockEmployee.TabIndex = 8;
            buttonLockEmployee.Text = "Khóa";
            buttonLockEmployee.UseVisualStyleBackColor = false;

            panelTable.BackColor = Color.White;
            panelTable.BorderColor = Color.FromArgb(224, 229, 235);
            panelTable.BorderRadius = 16;
            panelTable.BorderSize = 1;
            panelTable.Controls.Add(employeesGrid);
            panelTable.Dock = DockStyle.Fill;
            panelTable.Location = new Point(0, 220);
            panelTable.Name = "panelTable";
            panelTable.Padding = new Padding(16);
            panelTable.Size = new Size(876, 390);
            panelTable.TabIndex = 2;

            employeesGrid.AllowUserToAddRows = false;
            employeesGrid.AllowUserToDeleteRows = false;
            employeesGrid.AllowUserToResizeColumns = false;
            employeesGrid.AllowUserToResizeRows = false;
            employeesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            employeesGrid.BackgroundColor = Color.White;
            employeesGrid.BorderStyle = BorderStyle.None;
            employeesGrid.ColumnHeadersHeight = 42;
            employeesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            employeesGrid.Columns.AddRange(new DataGridViewColumn[] { columnUsername, columnFullName, columnEmail, columnPhone, columnRole, columnStatus });
            foreach (DataGridViewColumn col in employeesGrid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            employeesGrid.Dock = DockStyle.Fill;
            employeesGrid.EnableHeadersVisualStyles = false;
            employeesGrid.GridColor = Color.FromArgb(233, 236, 239);
            employeesGrid.Location = new Point(16, 16);
            employeesGrid.MultiSelect = false;
            employeesGrid.Name = "employeesGrid";
            employeesGrid.ReadOnly = true;
            employeesGrid.RowHeadersVisible = false;
            employeesGrid.RowTemplate.Height = 40;
            employeesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeesGrid.Size = new Size(844, 358);
            employeesGrid.TabIndex = 0;

            columnUsername.HeaderText = "Tài khoản";
            columnUsername.Name = "columnUsername";
            columnUsername.ReadOnly = true;

            columnFullName.HeaderText = "Họ tên";
            columnFullName.Name = "columnFullName";
            columnFullName.ReadOnly = true;

            columnEmail.HeaderText = "Email";
            columnEmail.Name = "columnEmail";
            columnEmail.ReadOnly = true;

            columnPhone.HeaderText = "Số điện thoại";
            columnPhone.Name = "columnPhone";
            columnPhone.ReadOnly = true;

            columnRole.HeaderText = "Vai trò";
            columnRole.Name = "columnRole";
            columnRole.ReadOnly = true;

            columnStatus.HeaderText = "Trạng thái";
            columnStatus.Name = "columnStatus";
            columnStatus.ReadOnly = true;

            panelRoot.ResumeLayout(false);
            panelTable.ResumeLayout(false);
            ((ISupportInitialize)employeesGrid).EndInit();
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
        private Label labelSearchEmployee;
        private RoundedTextBox textSearchEmployee;
        private Label labelStatusFilter;
        private ComboBox comboStatusFilter;
        private Label labelRoleFilter;
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
