# PharmacyManagementSystem

Ứng dụng desktop WinForms quản lý thuốc, nhân viên và hóa đơn cho nhà thuốc. Dự án theo kiến trúc 3-layer và MVP: GUI -> Presenter -> BLL -> DAL.

## Tech Stack
- .NET 8 (net8.0-windows)
- Windows Forms
- Entity Framework Core 8
- BCrypt.Net-Next (hash mật khẩu)

## Yêu Cầu
- Windows
- .NET SDK 8
- SQL Server LocalDB/Express

## Cài Đặt
1. Mở solution `PharmacyManagementSystem.slnx`.
2. Kiểm tra connection string trong `PharmacyManagementSystem/App.config`.
3. Restore packages (Visual Studio sẽ tự động restore).

## Chạy Dự Án

### Visual Studio
1. Mở `PharmacyManagementSystem.slnx`.
2. Set project `PharmacyManagementSystem` làm startup.
3. Run (F5).

### CLI
Từ thư mục gốc:
```
dotnet build PharmacyManagementSystem/PharmacyManagementSystem.csproj
dotnet run --project PharmacyManagementSystem/PharmacyManagementSystem.csproj
```

## Cấu Trúc Chính
```
PharmacyManagementSystem/
├── PharmacyManagementSystem.slnx
└── PharmacyManagementSystem/
    ├── GUI/            # WinForms (View)
    ├── Presenters/     # Presenter (MVP)
    ├── BLL/            # Business Logic
    ├── DAL/            # Data Access (EF Core)
    ├── Interfaces/
    ├── DTO/
    ├── Entities/
    ├── Reports/
    ├── Utils/
    └── Program.cs      # Entry point
```

## Chức Năng Chính

### Customer
| Chức năng | Form |
|----------|------|
| Đăng ký tài khoản | RegisterForm |
| Đăng nhập | LoginForm |

### Admin
| Chức năng | Form |
|----------|------|
| Quản lý thuốc | MedicineForm |
| Quản lý nhân viên | EmployeeForm |
| Quản lý hóa đơn | InvoiceForm |
| Xem báo cáo | ReportForm |

### Staff
| Chức năng | Form |
|----------|------|
| Tìm kiếm thuốc | MedicineForm |
| Bán thuốc / lập hóa đơn | InvoiceForm |

## Luồng Nghiệp Vụ Chính
- Đăng nhập: kiểm tra thông tin và điều hướng vào màn hình chính.
- Đăng ký: tạo tài khoản khách hàng, lưu thông tin cơ bản.
- Lập hóa đơn: nhập thuốc, tính tổng tiền, lưu hóa đơn.

## Quy Ước Code
- GUI chỉ xử lý UI, không viết business logic.
- Presenter điều phối giữa View và BLL.
- BLL chứa nghiệp vụ, gọi DAL; DAL chỉ truy vấn EF Core.
- Không dùng ADO.NET raw SQL, chỉ dùng `AppDbContext`.
- Hash mật khẩu thông qua `PasswordHelper`.

## Ghi Chú
- Entry point: `PharmacyManagementSystem/Program.cs`.
- Kiểm tra các file cấu hình (App.config) trước khi chạy.
