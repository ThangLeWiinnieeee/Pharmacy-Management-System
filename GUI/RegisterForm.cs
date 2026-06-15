using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem
{
    public partial class RegisterForm : Form, IRegisterView
    {
        private readonly AuthPresenter _presenter;

        public RegisterForm()
        {
            InitializeComponent();

            _presenter = new AuthPresenter(this);

            buttonBack.Click += HandleBackClick;
            buttonRegister.Click += HandleRegisterClick;
            this.WireClickOutsideToBlur();
        }

        public string FullName => textBoxFullName.Text.Trim();

        public string Phone => textBoxPhone.Text.Trim();

        public string Email => textBoxEmail.Text.Trim();

        public string Username => textBoxUsername.Text.Trim();

        public string Password => textBoxPassword.Text;

        public string ConfirmPassword => textBoxConfirmPassword.Text;

        private void HandleBackClick(object? sender, EventArgs e)
        {
            Close();
        }

        private void HandleRegisterClick(object? sender, EventArgs e)
        {
            buttonRegister.Enabled = false;

            try
            {
                _presenter.Register();
            }
            finally
            {
                if (!IsDisposed)
                {
                    buttonRegister.Enabled = true;
                }
            }
        }

        public void ShowRegisterSuccess(string message)
        {
            MessageBox.Show(this, message, "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowRegisterError(string message)
        {
            MessageBox.Show(this, message, "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void CloseView()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
