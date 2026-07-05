# Pharmacy Management System

Ứng dụng desktop quản lý nhà thuốc xây dựng trên **Windows Forms (.NET 8)**, kiến trúc **MVP + 3 lớp**. Hỗ trợ hai vai trò Admin và Staff với đầy đủ luồng bán hàng: quản lý thuốc, lập hóa đơn, tích điểm khách hàng, thanh toán & in hóa đơn, báo cáo doanh thu. Dữ liệu lưu trên **PostgreSQL** (host trên Supabase).

---

## Tính Năng

- **Xác thực** — Đăng nhập, đăng ký, ghi nhớ đăng nhập tự động (PBKDF2-SHA256 + remember-me token)
- **Phân quyền** — Admin có toàn quyền; Staff chỉ truy cập khu vực bán hàng
- **Dashboard (Admin)** — Thống kê thuốc, tồn kho, cảnh báo sắp hết / sắp hết hạn, số nhân viên & khách hàng, **biểu đồ tổng doanh thu 12 tháng**
- **Quản lý thuốc** — Thêm, sửa, ngừng kinh doanh, lọc theo trạng thái, xem lịch sử lô hàng nhập
- **Quản lý nhân viên** — Thêm, sửa, khóa / mở khóa tài khoản, lọc theo vai trò và trạng thái
- **Quản lý khách hàng** — Thêm, sửa, xóa, tra cứu lịch sử mua hàng theo số điện thoại
- **Lập hóa đơn** — Tra cứu khách theo SĐT, thêm thuốc vào giỏ, tự sinh mã hóa đơn, trừ tồn kho tự động
- **Tích điểm** — Mua hàng cộng điểm theo SĐT khách (1 điểm / 1.000đ trên số tiền thực trả); dùng điểm trừ trực tiếp vào hóa đơn (1 điểm = 1đ)
- **Thanh toán & in hóa đơn** — Nút *Thanh toán* mở popup tổng kết; in hóa đơn khi đã / chưa thanh toán
- **Lịch sử hóa đơn** — Tìm kiếm, lọc theo trạng thái và khoảng ngày, xem chi tiết từng hóa đơn
- **Báo cáo doanh thu (Admin)** — Doanh thu của từng nhân viên theo tháng

---

## Tech Stack

| Thành phần | Công nghệ |
|-----------|-----------|
| UI | Windows Forms (.NET 8) |
| ORM | Entity Framework Core 8 + **Npgsql** |
| Database | **PostgreSQL** (host trên Supabase) |
| Biểu đồ | ScottPlot.WinForms |
| Mật khẩu | PBKDF2-SHA256, 100.000 iterations |
| In hóa đơn | System.Drawing.Printing |
| Cấu hình | Biến môi trường `PHARMACY_DB` hoặc `App.config` |

---

## Yêu Cầu

- Windows 10/11
- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- Một database PostgreSQL (ví dụ project miễn phí trên [Supabase](https://supabase.com))
- Visual Studio 2022+ hoặc CLI `dotnet`

---

## Getting Started

### 1. Clone & mở solution

```bash
git clone <repo-url>
```

Mở `PharmacyManagementSystem.slnx` bằng Visual Studio.

### 2. Tạo database

Tạo project PostgreSQL trên Supabase (nên chọn region gần Việt Nam, ví dụ Singapore). Vào **SQL Editor** và chạy một lần file:

```
SQL_Database/Supabase_Migrate.sql
```

Script này tạo toàn bộ bảng (đúng theo model EF Core) + dữ liệu và reset lại IDENTITY sequence.

### 3. Cấu hình connection string

App đọc chuỗi kết nối theo thứ tự: **biến môi trường `PHARMACY_DB`** → `App.config` → fallback localhost. Chọn 1 trong 2 cách:

**Cách A — biến môi trường (khuyên dùng, không lộ mật khẩu):**

```powershell
setx PHARMACY_DB "Host=aws-0-<region>.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.<ref>;Password=<pass>;SSL Mode=Require;Trust Server Certificate=true"
```

**Cách B — App.config:**

```bash
cp PharmacyManagementSystem/App.config.example PharmacyManagementSystem/App.config
```

Rồi điền chuỗi kết nối Npgsql (Supabase) vào `App.config`.

> - `App.config` đã bị `.gitignore` — **không commit mật khẩu** vào repository.
> - Dùng **Session pooler** của Supabase (IPv4, port 5432); kết nối Direct là IPv6, mạng thông thường ở Việt Nam không kết nối được.

### 4. Chạy ứng dụng

**Visual Studio:** nhấn `F5`.

**CLI:**

```powershell
dotnet run --project PharmacyManagementSystem/PharmacyManagementSystem.csproj
```

Đăng nhập bằng tài khoản có sẵn trong dữ liệu đã nạp.

---

## Cấu Trúc Dự Án

```
PharmacyManagementSystem/                 # thư mục gốc solution
├── PharmacyManagementSystem.slnx
├── SQL_Database/                         # Supabase_Migrate.sql + script tham khảo
└── PharmacyManagementSystem/             # ← Git repository root
    ├── Program.cs
    ├── App.config.example                # mẫu cấu hình (App.config thật bị .gitignore)
    ├── Entities/                         # EF Core entities
    ├── DTO/  (Input/ , Output/)
    ├── Interfaces/  (IBLL/ , IDAL/ , IView/)
    ├── DAL/                              # Data Access Layer (EF Core + Npgsql)
    ├── BLL/  (+ Validations/)            # Business Logic
    ├── Presenters/                       # MVP Presenter layer
    └── GUI/  (+ Controls/)               # Windows Forms views & dialogs
```

---

## Kiến Trúc

Project theo kiến trúc **3 lớp kết hợp MVP**:

```
GUI (View)  →  Presenter  →  BLL  →  DAL  →  PostgreSQL
```

- **GUI** chỉ xử lý hiển thị, đọc input và gọi Presenter.
- **Presenter** điều phối luồng dữ liệu giữa View và BLL.
- **BLL** chứa nghiệp vụ và validation, gọi DAL qua interface.
- **DAL** truy xuất dữ liệu bằng EF Core / LINQ (Npgsql).
- **DTO** truyền dữ liệu giữa các tầng; **Entity** dùng cho EF mapping.

Schema database quản lý thủ công bằng SQL script (`SQL_Database/Supabase_Migrate.sql`), chưa dùng EF Core migration.
