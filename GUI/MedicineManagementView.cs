using System.Globalization;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public partial class MedicineManagementView : UserControl, IMedicineManagementView
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");
    private readonly MedicinePresenter _presenter;

    // Cache danh sách hiện tại để mở detail mà không cần gọi lại DB
    private IReadOnlyList<MedicineDTO> _currentMedicines = [];

    public bool IsAdmin { get; set; }

    public MedicineManagementView()
    {
        InitializeComponent();

        _presenter = new MedicinePresenter(this);
        comboStatusFilter.SelectedIndex = 0;

        Load                            += (_, _) => _presenter.LoadMedicines();
        textSearchMedicine.TextChanged  += (_, _) => _presenter.LoadMedicines();
        comboStatusFilter.SelectedIndexChanged += (_, _) => _presenter.LoadMedicines();

        buttonAddMedicine.Click    += (_, _) => _presenter.AddMedicine();
        buttonEditMedicine.Click   += (_, _) => _presenter.EditMedicine();
        buttonDeleteMedicine.Click += (_, _) => _presenter.DeactivateMedicine();
        buttonLookupDetail.Click   += (_, _) => OpenBatchDetail();

        // Double-click hàng cũng mở chi tiết lô
        medicinesGrid.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0) OpenBatchDetail();
        };
    }

    // ─── IMedicineManagementView ────────────────────────────────────────────

    public string SearchKeyword => textSearchMedicine.Text.Trim();
    public string StatusFilter  => comboStatusFilter.SelectedItem?.ToString() ?? "Tất cả";

    public int? SelectedMedicineId
    {
        get
        {
            if (medicinesGrid.CurrentRow?.Tag is MedicineDTO m)
                return m.Id;
            return null;
        }
    }

    public void ShowMedicines(IReadOnlyList<MedicineDTO> medicines)
    {
        _currentMedicines = medicines;
        medicinesGrid.SuspendLayout();
        medicinesGrid.Rows.Clear();

        foreach (var m in medicines)
        {
            var status = MedicineStatusHelper.Evaluate(m);

            var rowIndex = medicinesGrid.Rows.Add(
                m.Code,
                m.Name,
                m.Unit,
                m.Quantity > 0 ? m.Quantity.ToString("N0", Vi) : "0",
                m.SellPrice.ToString("N0", Vi),
                m.ExpiryDate?.ToString("dd/MM/yyyy") ?? string.Empty,
                status.Text);

            var row = medicinesGrid.Rows[rowIndex];
            row.Tag = m;     // giữ toàn bộ DTO để mở detail

            // Tô màu cột Trạng thái
            row.Cells["columnStatus"].Style.ForeColor = status.ForeColor;
            row.Cells["columnStatus"].Style.Font      =
                new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);

            // Tô nhạt cả hàng nếu không khả dụng
            if (!status.CanOrder)
                row.DefaultCellStyle.ForeColor = Color.FromArgb(160, 160, 160);

            // Highlight hạn dùng sắp hết / đã hết
            if (m.ExpiryDate.HasValue)
            {
                var diff = (m.ExpiryDate.Value.Date - DateTime.Today).TotalDays;
                if (diff < 0)
                    row.Cells["columnExpiryDate"].Style.ForeColor = Color.FromArgb(140, 20, 40);
                else if (diff < 90)
                    row.Cells["columnExpiryDate"].Style.ForeColor = Color.FromArgb(200, 100, 0);
            }
        }

        medicinesGrid.ResumeLayout();
    }

    public SaveMedicineDTO? RequestMedicineInput(SaveMedicineDTO? currentMedicine)
    {
        using var editorForm = new MedicineEditorForm(currentMedicine);
        return editorForm.ShowDialog(this) == DialogResult.OK
            ? editorForm.MedicineInput
            : null;
    }

    public bool Confirm(string message) =>
        MessageBox.Show(this, message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    public void ShowMessage(string message) =>
        MessageBox.Show(this, message, "Quản lý thuốc", MessageBoxButtons.OK, MessageBoxIcon.Information);

    public void ShowError(string message) =>
        MessageBox.Show(this, message, "Quản lý thuốc", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public void EnableReadOnlyMode()
    {
        buttonAddMedicine.Visible    = false;
        buttonEditMedicine.Visible   = false;
        buttonDeleteMedicine.Visible = false;
    }

    // ─── Private ───────────────────────────────────────────────────────────

    private void OpenBatchDetail()
    {
        if (medicinesGrid.CurrentRow?.Tag is not MedicineDTO m) return;
        using var dlg = new MedicineBatchDetailDialog(m, IsAdmin);
        dlg.ShowDialog(this);
        if (dlg.NeedRefresh)
            _presenter.LoadMedicines();
    }
}
