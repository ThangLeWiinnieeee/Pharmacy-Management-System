using PharmacyManagementSystem.BLL.Validations;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Entities;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.BLL;

public class MedicineBLL : IMedicineBLL
{
    private readonly IMedicineDAL _medicineDAL;

    public MedicineBLL(IMedicineDAL medicineDAL)
    {
        _medicineDAL = medicineDAL;
    }

    public IReadOnlyList<MedicineDTO> GetMedicines(MedicineQueryDTO query)
    {
        return _medicineDAL.GetMedicines(query).Select(MapToDTO).ToList();
    }

    public SaveMedicineDTO? GetMedicineForEdit(int id)
    {
        var medicine = _medicineDAL.GetById(id);
        return medicine is null ? null : MapToInputDTO(medicine);
    }

    public OperationResultDTO SaveMedicine(SaveMedicineDTO request)
    {
        Normalize(request);

        var validationMessage = MedicineValidator.Validate(request);
        if (!string.IsNullOrEmpty(validationMessage))
        {
            return OperationResultDTO.Failure(validationMessage);
        }

        if (_medicineDAL.ExistsByCode(request.Code, request.Id))
        {
            return OperationResultDTO.Failure("Mã thuốc đã tồn tại.");
        }

        try
        {
            if (request.Id.HasValue)
            {
                return UpdateMedicine(request);
            }

            return CreateMedicine(request);
        }
        catch
        {
            return OperationResultDTO.Failure("Không thể lưu thông tin thuốc. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }

    public OperationResultDTO DeactivateMedicine(int id)
    {
        try
        {
            if (_medicineDAL.GetById(id) is null)
            {
                return OperationResultDTO.Failure("Không tìm thấy thuốc cần xóa.");
            }

            _medicineDAL.SetActive(id, false);
            return OperationResultDTO.Success("Đã ngừng kinh doanh thuốc được chọn.");
        }
        catch
        {
            return OperationResultDTO.Failure("Không thể cập nhật trạng thái thuốc. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }

    private OperationResultDTO CreateMedicine(SaveMedicineDTO request)
    {
        var medicine = new Medicine
        {
            Code = request.Code,
            Name = request.Name,
            Unit = request.Unit,
            Manufacturer = request.Manufacturer,
            ImportPrice = request.ImportPrice,
            SellPrice = request.SellPrice,
            Quantity = request.Quantity,
            ExpiryDate = request.ExpiryDate,
            Description = request.Description,
            IsActive = request.IsActive,
            CreatedAt = DateTime.Now
        };

        _medicineDAL.Add(medicine);
        return OperationResultDTO.Success("Đã thêm thuốc mới.");
    }

    private OperationResultDTO UpdateMedicine(SaveMedicineDTO request)
    {
        var existingMedicine = _medicineDAL.GetById(request.Id!.Value);
        if (existingMedicine is null)
        {
            return OperationResultDTO.Failure("Không tìm thấy thuốc cần cập nhật.");
        }

        existingMedicine.Code = request.Code;
        existingMedicine.Name = request.Name;
        existingMedicine.Unit = request.Unit;
        existingMedicine.Manufacturer = request.Manufacturer;
        existingMedicine.ImportPrice = request.ImportPrice;
        existingMedicine.SellPrice = request.SellPrice;
        existingMedicine.Quantity = request.Quantity;
        existingMedicine.ExpiryDate = request.ExpiryDate;
        existingMedicine.Description = request.Description;
        existingMedicine.IsActive = request.IsActive;

        _medicineDAL.Update(existingMedicine);
        return OperationResultDTO.Success("Đã cập nhật thông tin thuốc.");
    }

    private static void Normalize(SaveMedicineDTO request)
    {
        request.Code = request.Code.Trim();
        request.Name = request.Name.Trim();
        request.Unit = request.Unit.Trim();
        request.Manufacturer = string.IsNullOrWhiteSpace(request.Manufacturer)
            ? null
            : request.Manufacturer.Trim();
        request.Description = string.IsNullOrWhiteSpace(request.Description)
            ? null
            : request.Description.Trim();
    }

    private static MedicineDTO MapToDTO(Medicine medicine)
    {
        return new MedicineDTO
        {
            Id = medicine.Id,
            Code = medicine.Code,
            Name = medicine.Name,
            Unit = medicine.Unit,
            Manufacturer = medicine.Manufacturer,
            ImportPrice = medicine.ImportPrice,
            SellPrice = medicine.SellPrice,
            Quantity = medicine.Quantity,
            ExpiryDate = medicine.ExpiryDate,
            Description = medicine.Description,
            IsActive = medicine.IsActive,
            CreatedAt = medicine.CreatedAt
        };
    }

    private static SaveMedicineDTO MapToInputDTO(Medicine medicine)
    {
        return new SaveMedicineDTO
        {
            Id = medicine.Id,
            Code = medicine.Code,
            Name = medicine.Name,
            Unit = medicine.Unit,
            Manufacturer = medicine.Manufacturer,
            ImportPrice = medicine.ImportPrice,
            SellPrice = medicine.SellPrice,
            Quantity = medicine.Quantity,
            ExpiryDate = medicine.ExpiryDate,
            Description = medicine.Description,
            IsActive = medicine.IsActive
        };
    }
}
