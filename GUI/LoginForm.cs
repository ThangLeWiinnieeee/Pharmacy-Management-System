using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem
{
    public partial class LoginForm : Form, ILoginView
    {
        private readonly AuthPresenter _presenter;

        public LoginForm()
        {
            InitializeComponent();

            _presenter = new AuthPresenter(this);

            buttonLogin.Click += HandleLoginClick;
            buttonExit.Click += HandleExitClick;
            buttonRegister.Click += HandleRegisterClick;
        }

        public string Username => textBoxUsername.Text.Trim();

        public string Password => textBoxPassword.Text;

        private void HandleLoginClick(object? sender, EventArgs e)
        {
            buttonLogin.Enabled = false;

            try
            {
                _presenter.Login();
            }
            finally
            {
                if (!IsDisposed)
                {
                    buttonLogin.Enabled = true;
                }
            }
        }

        private void HandleExitClick(object? sender, EventArgs e)
        {
            Close();
        }

        private void HandleRegisterClick(object? sender, EventArgs e)
        {
            using var registerForm = new RegisterForm();
            registerForm.ShowDialog(this);
        }

        public void ShowLoginError(string message)
        {
            MessageBox.Show(this, message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void OpenAdminDashboard(UserDTO user)
        {
            Hide();

            using var mainForm = new MainForm(user);
            var dialogResult = mainForm.ShowDialog(this);

            if (dialogResult == DialogResult.Retry)
            {
                ShowForNextLogin();
                return;
            }

            Close();
        }

        public void OpenStaffWorkspace(UserDTO user)
        {
            Hide();

            using var staffHomeForm = new StaffHomeForm(user);
            var dialogResult = staffHomeForm.ShowDialog(this);

            if (dialogResult == DialogResult.Retry)
            {
                ShowForNextLogin();
                return;
            }

            Close();
        }

        private void ShowForNextLogin()
        {
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            Show();
            Activate();
            textBoxUsername.Focus();
        }
    }
}
