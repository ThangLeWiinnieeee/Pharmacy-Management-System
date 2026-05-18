using PharmacyManagementSystem.DTO.Input;

namespace PharmacyManagementSystem.BLL.Validations;

public static class MedicineValidator
{
    public static string? Validate(SaveMedicineDTO request)
    {
        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return "Vui lòng nhập mã thuốc.";
        }

        if (request.Code.Trim().Length > 50)
        {
            return "Mã thuốc không được vượt quá 50 ký tự.";
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return "Vui lòng nhập tên thuốc.";
        }

        if (request.Name.Trim().Length > 150)
        {
            return "Tên thuốc không được vượt quá 150 ký tự.";
        }

        if (string.IsNullOrWhiteSpace(request.Unit))
        {
            return "Vui lòng nhập đơn vị tính.";
        }

        if (request.Unit.Trim().Length > 30)
        {
            return "Đơn vị tính không được vượt quá 30 ký tự.";
        }

        if (request.Manufacturer?.Trim().Length > 150)
        {
            return "Nhà sản xuất không được vượt quá 150 ký tự.";
        }

        if (request.ImportPrice < 0)
        {
            return "Giá nhập không được âm.";
        }

        if (request.SellPrice < 0)
        {
            return "Giá bán không được âm.";
        }

        if (request.SellPrice < request.ImportPrice)
        {
            return "Giá bán không được nhỏ hơn giá nhập.";
        }

        if (request.Quantity < 0)
        {
            return "Tồn kho không được âm.";
        }

        if (request.Description?.Trim().Length > 500)
        {
            return "Mô tả không được vượt quá 500 ký tự.";
        }

        return null;
    }
}
