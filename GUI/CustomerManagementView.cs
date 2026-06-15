using System.Globalization;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public partial class CustomerManagementView : UserControl, ICustomerManagementView
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");
    private readonly CustomerManagementPresenter _presenter;

    public CustomerManagementView()
    {
        InitializeComponent();

        _presenter = new CustomerManagementPresenter(this);

        Load += (_, _) => _presenter.LoadCustomers();
        textSearch.TextChanged += (_, _) => _presenter.LoadCustomers();
        buttonAdd.Click += (_, _) => _presenter.AddCustomer();
        buttonEdit.Click += (_, _) => _presenter.EditCustomer();
        buttonDelete.Click += (_, _) => _presenter.DeleteCustomer();
    }

    public string SearchKeyword => textSearch.Text.Trim();

    public CustomerListDTO? SelectedCustomer =>
        customersGrid.CurrentRow?.Tag as CustomerListDTO;

    public void ShowCustomers(IReadOnlyList<CustomerListDTO> customers)
    {
        customersGrid.Rows.Clear();
        foreach (var c in customers)
        {
            var idx = customersGrid.Rows.Add(
                c.Name,
                c.Phone ?? "—",
                c.Address ?? "—",
                c.CreatedAt.ToString("dd/MM/yyyy", Vi),
                c.TotalPurchases.ToString("N0", Vi),
                c.InvoiceCount);
            customersGrid.Rows[idx].Tag = c;
        }
    }

    public bool RequestCustomerAdd()
    {
        using var dlg = new CreateCustomerDialog(string.Empty);
        return dlg.ShowDialog(this) == DialogResult.OK;
    }

    public bool RequestCustomerEdit(CustomerListDTO customer)
    {
        using var dlg = new EditCustomerDialog(customer.Name, customer.Phone ?? string.Empty, customer.Address);
        return dlg.ShowDialog(this) == DialogResult.OK;
    }

    public bool Confirm(string message) =>
        MessageBox.Show(this, message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    public void ShowMessage(string message) =>
        MessageBox.Show(this, message, "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);

    public void ShowError(string message) =>
        MessageBox.Show(this, message, "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public void Reload() => _presenter.LoadCustomers();
}
