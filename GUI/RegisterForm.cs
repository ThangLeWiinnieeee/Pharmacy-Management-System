namespace PharmacyManagementSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            buttonBack.Click += HandleBackClick;
        }

        private void HandleBackClick(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
