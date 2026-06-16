# Pharmacy Management System

Ứng dụng desktop quản lý nhà thuốc xây dựng trên **Windows Forms (.NET 8)**. Hỗ trợ hai vai trò Admin và Staff với đầy đủ luồng bán hàng: quản lý thuốc, lập hóa đơn, tra cứu khách hàng và thống kê tổng quan.

---

## Tính Năng

- **Xác thực** — Đăng nhập, đăng ký, ghi nhớ đăng nhập tự động (PBKDF2-SHA256 + DPAPI)
- **Phân quyền** — Admin có toàn quyền; Staff chỉ truy cập khu vực bán hàng
- **Dashboard** — Thống kê thuốc, tồn kho, cảnh báo sắp hết / sắp hết hạn, số lượng nhân viên và khách hàng
- **Quản lý thuốc** — Thêm, sửa, ngừng kinh doanh, lọc theo trạng thái, xem lịch sử lô hàng nhập
- **Quản lý nhân viên** — Thêm, sửa, khóa / mở khóa tài khoản, lọc theo vai trò và trạng thái
- **Quản lý khách hàng** — Thêm, sửa, xóa, tra cứu lịch sử mua hàng theo số điện thoại
- **Lập hóa đơn** — Tra cứu khách theo SĐT, thêm thuốc vào giỏ, chiết khấu, tự sinh mã hóa đơn, trừ tồn kho tự động
- **Lịch sử hóa đơn** — Tìm kiếm, lọc theo trạng thái và khoảng ngày, xem chi tiết từng hóa đơn

---

## Tech Stack

| Thành phần | Công nghệ |
|-----------|-----------|
| UI | Windows Forms (.NET 8) |
| ORM | Entity Framework Core 8 (SQL Server) |
| Database | SQL Server (LocalDB / Express / Developer) |
| Mật khẩu | PBKDF2-SHA256, 100.000 iterations |
| Remember Me | Token ngẫu nhiên + DPAPI (CurrentUser) |
| Cấu hình | `System.Configuration` — `App.config` |

---

## Yêu Cầu

- Windows 10/11
- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (LocalDB, Express, Developer hoặc tương đương)
- Visual Studio 2022+ hoặc CLI `dotnet`

---

## Getting Started

### 1. Clone & mở solution

```bash
git clone <repo-url>
```

Mở `PharmacyManagementSystem.slnx` bằng Visual Studio.

### 2. Tạo database

Tạo database `PharmacyManagementSystemDb` trong SQL Server, sau đó chạy các script trong `SQL_Database/` **theo đúng thứ tự**:

```
1. User.sql
2. Medicines.sql
3. Customers.sql
4. Invoices.sql
5. RememberMeTokens.sql
6. SeedData.sql
7. MedicineBatches.sql        ← phải chạy sau SeedData.sql
```

### 3. Cấu hình connection string

Sao chép file mẫu rồi chỉnh lại tên server:

```bash
cp PharmacyManagementSystem/App.config.example PharmacyManagementSystem/App.config
```

Sửa giá trị `Data Source` trong `App.config` cho khớp với SQL Server trên máy.

> `App.config` là file cục bộ — không commit vào repository.

### 4. Chạy ứng dụng

**Visual Studio:** nhấn `F5`.

**CLI:**

```powershell
dotnet run --project PharmacyManagementSystem/PharmacyManagementSystem.csproj
```

### Tài Khoản Test

| Username | Mật khẩu | Vai trò | Trạng thái |
|----------|-----------|---------|------------|
| `admin` | `Admin@123` | Admin | Hoạt động |
| `nhanvien01` | `Staff@123` | Staff | Hoạt động |
| `nhanvien02` | `Staff@123` | Staff | Hoạt động |
| `nhanvien_off` | `Staff@123` | Staff | Bị khóa |

---

## Cấu Trúc Dự Án

```
PharmacyManagementSystem/
├── PharmacyManagementSystem.slnx
├── SQL_Database/               # Script tạo bảng và dữ liệu mẫu
└── PharmacyManagementSystem/
    ├── Program.cs
    ├── App.config.example
    ├── Entities/               # EF Core entities
    ├── DTO/
    │   ├── Input/
    │   └── Output/
    ├── Interfaces/
    │   ├── IBLL/
    │   ├── IDAL/
    │   └── IView/
    ├── DAL/                    # Data Access Layer (EF Core + LINQ)
    ├── BLL/                    # Business Logic + Validations
    │   └── Validations/
    ├── Presenters/             # MVP Presenter layer
    └── GUI/                    # Windows Forms views & dialogs
        └── Controls/           # Custom controls
```

---

## Kiến Trúc

Project theo kiến trúc **3-layer kết hợp MVP**:

```
GUI (View)  →  Presenter  →  BLL  →  DAL  →  SQL Server
```

- **GUI** chỉ xử lý hiển thị, đọc input và gọi Presenter.
- **Presenter** điều phối luồng dữ liệu giữa View và BLL.
- **BLL** chứa nghiệp vụ và validation, gọi DAL qua interface.
- **DAL** truy xuất dữ liệu bằng EF Core / LINQ.
- **DTO** truyền dữ liệu giữa các tầng; **Entity** dùng cho EF mapping.

Schema database được quản lý thủ công bằng SQL script (chưa dùng EF Core migration).
