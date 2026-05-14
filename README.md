# PharmacyManagementSystem

Ứng dụng desktop WinForms quản lý nhà thuốc. Dự án theo kiến trúc 3-layer và MVP:

```text
GUI -> Presenter -> BLL -> DAL -> Database
```

## Tech Stack

- .NET 8 (`net8.0-windows`)
- Windows Forms
- Entity Framework Core 8
- SQL Server

## Yêu Cầu

- Windows
- .NET SDK 8
- SQL Server

## Cài Đặt

1. Mở solution `PharmacyManagementSystem.slnx`.
2. Tạo file `PharmacyManagementSystem/App.config` từ file mẫu `PharmacyManagementSystem/App.config.example`.
3. Điền thông tin SQL Server của máy đang chạy vào `App.config`.
4. Tạo database và bảng trong SQL Server Management Studio theo schema tương ứng với `Entities` và `AppDbContext`.
5. Restore packages nếu IDE chưa tự động restore.

## Chạy Dự Án

### Visual Studio

1. Mở `PharmacyManagementSystem.slnx`.
2. Set project `PharmacyManagementSystem` làm startup project.
3. Run bằng F5.

### CLI

Từ thư mục gốc solution:

```powershell
dotnet build PharmacyManagementSystem/PharmacyManagementSystem.csproj
dotnet run --project PharmacyManagementSystem/PharmacyManagementSystem.csproj
```

## Cấu Trúc Chính

```text
PharmacyManagementSystem/
|-- PharmacyManagementSystem.slnx
`-- PharmacyManagementSystem/
    |-- GUI/            # WinForms (View)
    |-- Presenters/     # Presenter (MVP)
    |-- BLL/            # Business Logic
    |   `-- Validations/ # Validate nghiệp vụ/input
    |-- DAL/            # Data Access
    |-- Interfaces/
    |   |-- IBLL/
    |   |-- IDAL/
    |   `-- IView/
    |-- DTO/
    |   |-- Input/      # DTO nhận dữ liệu từ form/request
    |   `-- Output/     # DTO trả dữ liệu/kết quả ra ngoài
    |-- Entities/
    |-- App.config.example
    `-- Program.cs      # Entry point
```

## Chức Năng Hiện Tại

| Chức năng | Form | Trạng thái |
|-----------|------|------------|
| Đăng nhập | `LoginForm` | Đã xác thực tài khoản và mở `MainForm` |
| Đăng ký tài khoản | `RegisterForm` | Đã validate, hash mật khẩu và lưu vào `Users` |
| Dashboard | `MainForm` | Thống kê thuốc, tồn kho, Admin, Staff và người dùng |
| Khu vực nhân viên | `StaffHomeForm` | Màn hình làm việc cho tài khoản Staff |

## Luồng Chạy Hiện Tại

1. Ứng dụng chạy từ `Program.cs`.
2. Ứng dụng kiểm tra kết nối database.
3. Nếu kết nối thành công, màn hình `LoginForm` được mở.
4. Người dùng có thể chuyển từ `LoginForm` sang `RegisterForm`.
5. `RegisterForm` tạo tài khoản Staff mới khi database đã có bảng `Users`.
6. `LoginForm` xác thực tài khoản và điều hướng theo role.
7. Role `Admin` mở dashboard `MainForm`; role `Staff` mở `StaffHomeForm`.

## Luồng Nghiệp Vụ Mục Tiêu

- Đăng nhập: kiểm tra thông tin và điều hướng vào màn hình chính.
- Đăng ký: tạo tài khoản, lưu thông tin cơ bản.
- Quản lý thuốc: thêm, sửa, xóa, tìm kiếm và theo dõi số lượng thuốc.
- Lập hóa đơn: nhập thuốc, tính tổng tiền, lưu hóa đơn.

## Quy Ước Code

- GUI chỉ xử lý UI, không viết business logic.
- Presenter điều phối giữa View và BLL.
- BLL chứa nghiệp vụ và gọi DAL.
- DAL chỉ chịu trách nhiệm truy xuất dữ liệu bằng EF/LINQ, không viết SQL thuần trong code.
- DTO dùng để truyền dữ liệu giữa các tầng; `DTO/Input` nhận dữ liệu vào, `DTO/Output` trả dữ liệu ra.
- Entity dùng cho mapping database.
- Hệ thống chỉ dùng 2 role: `Admin` và `Staff`; tài khoản đăng ký mới mặc định là `Staff`.

## Ghi Chú

- `App.config` là file cấu hình cục bộ và không commit lên repository.
- Xem mẫu cấu hình trong `PharmacyManagementSystem/App.config.example`.
- Không đưa connection string thật, tên máy, tài khoản, mật khẩu hoặc thông tin môi trường nội bộ vào README.
- Database schema được tạo/cập nhật thủ công trong SQL Server Management Studio.
- `AppDbContext` hiện có `DbSet<User>` và `DbSet<Medicine>`.
- Đăng ký và đăng nhập đã dùng mật khẩu hash PBKDF2; migration, report/RDLC chưa implement.
