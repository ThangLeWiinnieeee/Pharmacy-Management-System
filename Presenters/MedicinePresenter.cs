using PharmacyManagementSystem.BLL;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IView;

namespace PharmacyManagementSystem.Presenters;

public class MedicinePresenter
{
    private readonly IMedicineBLL _medicineBLL;
    private readonly IMedicineManagementView _view;

    public MedicinePresenter(IMedicineManagementView view)
        : this(view, new MedicineBLL(new MedicineDAL()))
    {
    }

    public MedicinePresenter(IMedicineManagementView view, IMedicineBLL medicineBLL)
    {
        _view = view;
        _medicineBLL = medicineBLL;
    }

    public void LoadMedicines()
    {
        try
        {
            _view.ShowMedicines(_medicineBLL.GetMedicines(CreateQuery()));
        }
        catch
        {
            _view.ShowError("Không thể tải danh sách thuốc. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }

    public void AddMedicine()
    {
        var request = _view.RequestMedicineInput(null);
        if (request is null)
        {
            return;
        }

        SaveMedicine(request);
    }

    public void EditMedicine()
    {
        var selectedId = _view.SelectedMedicineId;
        if (!selectedId.HasValue)
        {
            _view.ShowError("Vui lòng chọn thuốc cần sửa.");
            return;
        }

        var currentMedicine = _medicineBLL.GetMedicineForEdit(selectedId.Value);
        if (currentMedicine is null)
        {
            _view.ShowError("Không tìm thấy thuốc cần sửa.");
            LoadMedicines();
            return;
        }

        var request = _view.RequestMedicineInput(currentMedicine);
        if (request is null)
        {
            return;
        }

        SaveMedicine(request);
    }

    public void DeactivateMedicine()
    {
        var selectedId = _view.SelectedMedicineId;
        if (!selectedId.HasValue)
        {
            _view.ShowError("Vui lòng chọn thuốc cần xóa.");
            return;
        }

        if (!_view.Confirm("Bạn có chắc muốn ngừng kinh doanh thuốc được chọn?"))
        {
            return;
        }

        var result = _medicineBLL.DeactivateMedicine(selectedId.Value);
        ShowResult(result.Message, result.IsSuccess);
    }

    private void SaveMedicine(SaveMedicineDTO request)
    {
        var result = _medicineBLL.SaveMedicine(request);
        ShowResult(result.Message, result.IsSuccess);
    }

    private void ShowResult(string message, bool isSuccess)
    {
        if (isSuccess)
        {
            _view.ShowMessage(message);
            LoadMedicines();
            return;
        }

        _view.ShowError(message);
    }

    private MedicineQueryDTO CreateQuery()
    {
        return new MedicineQueryDTO
        {
            Keyword = _view.SearchKeyword,
            StatusFilter = _view.StatusFilter
        };
    }
}
