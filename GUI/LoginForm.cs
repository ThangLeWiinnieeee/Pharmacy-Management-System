using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem
{
    public partial class LoginForm : Form, ILoginView
    {
        private readonly AuthPresenter _presenter;
        private readonly CheckBox _checkBoxRemember;
        private bool _autoLoginHandled;

        public LoginForm()
        {
            InitializeComponent();

            _presenter = new AuthPresenter(this);

            // Thêm checkbox "Ghi nhớ đăng nhập" vào panelCard (giữa password và nút login)
            _checkBoxRemember = new CheckBox
            {
                AutoSize = true,
                Font     = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(51, 51, 51),
                Location  = new Point(32, 278),
                Text      = "Ghi nhớ đăng nhập",
                TabIndex  = 10
            };
            panelCard.Controls.Add(_checkBoxRemember);

            buttonLogin.Click    += HandleLoginClick;
            buttonExit.Click     += HandleExitClick;
            buttonRegister.Click += HandleRegisterClick;
            this.WireClickOutsideToBlur();
        }

        // ── ILoginView ───────────────────────────────────────────────────────

        public string Username   => textBoxUsername.Text.Trim();
        public string Password   => textBoxPassword.Text;
        public bool   RememberMe => _checkBoxRemember.Checked;

        // ── Auto-login: chặn form hiện ra nếu có token hợp lệ ───────────────

        protected override void SetVisibleCore(bool value)
        {
            if (value && !_autoLoginHandled)
            {
                _autoLoginHandled = true;
                if (!IsHandleCreated) CreateHandle(); // cần handle để ShowDialog hoạt động
                if (_presenter.TryAutoLogin()) return; // không gọi base → form không hiện
            }
            base.SetVisibleCore(value);
        }

        // ── Event handlers ───────────────────────────────────────────────────

        private void HandleLoginClick(object? sender, EventArgs e)
        {
            buttonLogin.Enabled = false;
            try     { _presenter.Login(); }
            finally { if (!IsDisposed) buttonLogin.Enabled = true; }
        }

        private void HandleExitClick(object? sender, EventArgs e) => Close();

        private void HandleRegisterClick(object? sender, EventArgs e)
        {
            using var registerForm = new RegisterForm();
            registerForm.ShowDialog(this);
        }

        // ── ILoginView callbacks ─────────────────────────────────────────────

        public void ShowLoginError(string message)
        {
            MessageBox.Show(this, message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void OpenAdminDashboard(UserDTO user)
        {
            Hide();
            using var mainForm = new MainForm(user);
            var result = mainForm.ShowDialog(this);
            if (result == DialogResult.Retry) { ShowForNextLogin(); return; }
            Close();
        }

        public void OpenStaffWorkspace(UserDTO user)
        {
            Hide();
            using var staffHomeForm = new StaffHomeForm(user);
            var result = staffHomeForm.ShowDialog(this);
            if (result == DialogResult.Retry) { ShowForNextLogin(); return; }
            Close();
        }

        // ── Logout ───────────────────────────────────────────────────────────

        private void ShowForNextLogin()
        {
            _presenter.Logout(); // revoke token DB + xóa file DPAPI
            textBoxUsername.Text   = string.Empty;
            textBoxPassword.Text   = string.Empty;
            _checkBoxRemember.Checked = false;
            Show();
            Activate();
            textBoxUsername.Focus();
        }
    }
}
