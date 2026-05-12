namespace PharmacyManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            buttonExit.Click += HandleExitClick;
            buttonRegister.Click += HandleRegisterClick;
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
    }
}
