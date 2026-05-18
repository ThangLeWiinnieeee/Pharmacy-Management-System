# PharmacyManagementSystem

Ung dung desktop Windows Forms de quan ly nha thuoc. Project su dung kien truc 3-layer ket hop MVP:

```text
GUI -> Presenter -> BLL -> DAL -> Database
```

## Tech Stack

- .NET 8 (`net8.0-windows`)
- Windows Forms
- Entity Framework Core SQL Server 8
- SQL Server
- `System.Configuration.ConfigurationManager` de doc connection string tu `App.config`

## Yeu Cau

- Windows
- .NET SDK 8
- SQL Server LocalDB/Express/Developer hoac SQL Server tuong duong
- Visual Studio hoac CLI `dotnet`

## Cai Dat

1. Mo solution `PharmacyManagementSystem.slnx`.
2. Tao database `PharmacyManagementSystemDb` trong SQL Server.
3. Chay cac script trong folder `SQL_Database/`:
   - `User.sql`
   - `Medicines.sql`
4. Tao file `PharmacyManagementSystem/App.config` tu file mau `PharmacyManagementSystem/App.config.example`.
5. Sua connection string `PharmacyDb` trong `App.config` cho dung SQL Server tren may dang chay.
6. Restore NuGet packages neu IDE chua tu dong restore.

`App.config` la cau hinh cuc bo. Khong dua connection string that, ten may noi bo, tai khoan hoac mat khau vao repository.

## Chay Du An

### Visual Studio

1. Mo `PharmacyManagementSystem.slnx`.
2. Set project `PharmacyManagementSystem` lam startup project.
3. Chay bang F5.

### CLI

Tu thu muc goc solution:

```powershell
dotnet build PharmacyManagementSystem/PharmacyManagementSystem.csproj
dotnet run --project PharmacyManagementSystem/PharmacyManagementSystem.csproj
```

Hoac tu thu muc project con `PharmacyManagementSystem/`:

```powershell
dotnet build
dotnet run
```

## Cau Truc Chinh

```text
PharmacyManagementSystem/
|-- PharmacyManagementSystem.slnx
|-- AGENTS.md
|-- SQL_Database/
|   |-- User.sql
|   `-- Medicines.sql
`-- PharmacyManagementSystem/
    |-- Program.cs
    |-- App.config.example
    |-- GUI/            # Windows Forms views, dialogs, admin shell
    |   `-- Controls/   # Custom controls
    |-- Presenters/     # Presenter layer
    |-- BLL/            # Business logic
    |   `-- Validations/
    |-- DAL/            # EF Core data access
    |-- Interfaces/
    |   |-- IBLL/
    |   |-- IDAL/
    |   `-- IView/
    |-- DTO/
    |   |-- Input/
    |   `-- Output/
    `-- Entities/
```

## Chuc Nang Hien Tai

| Chuc nang | Trang thai |
|-----------|------------|
| Dang nhap/Dang ky | Co validate input, hash mat khau PBKDF2, kiem tra trang thai tai khoan |
| Phan quyen | Dieu huong `Admin` vao dashboard, `Staff` vao khu vuc lam viec rieng |
| Dashboard Admin | Hien thong ke tong quan ve thuoc, ton kho va tai khoan |
| Side Navigation Admin | Dieu huong giua dashboard, quan ly thuoc, quan ly nhan vien va cac muc se phat trien tiep |
| Quan ly thuoc | Xem danh sach, tim kiem, loc trang thai, them, sua, ngung kinh doanh |
| Quan ly nhan vien | Xem danh sach, tim kiem, loc vai tro/trang thai, them, sua, khoa/mo khoa tai khoan |
| Khu vuc Staff | Man hinh lam viec co ban cho nhan vien |
| Database check | Kiem tra ket noi database khi khoi dong app |

## Luong Chay

1. App chay tu `Program.cs`.
2. `DatabaseInitializer` kiem tra ket noi database.
3. Neu ket noi thanh cong, app mo `LoginForm`.
4. Nguoi dung dang nhap hoac mo `RegisterForm` de dang ky.
5. Tai khoan dang ky moi mac dinh role `Staff`.
6. Dang nhap thanh cong se dieu huong theo role:
   - `Admin` mo `MainForm`
   - `Staff` mo `StaffHomeForm`
7. Nut dang xuat dong man hinh hien tai va hien lai `LoginForm`.

## Database

`AppDbContext` hien co:

- `DbSet<User>` mapping bang `Users`
- `DbSet<Medicine>` mapping bang `Medicines`

Project hien chua dung EF Core migration. Schema database duoc tao/cap nhat thu cong bang SQL script trong `SQL_Database/`.

## Quy Uoc Chinh

- GUI chi xu ly UI, doc input, bind data va goi Presenter.
- Presenter dieu phoi giua View va BLL.
- BLL chua nghiep vu, validation va goi DAL qua interface.
- DAL truy xuat du lieu bang EF/LINQ.
- DTO dung de truyen du lieu giua cac tang.
- Entity dung cho EF Core/database mapping.
- Role hien tai gom `Admin` va `Staff`.
- Mat khau khong luu plain text; he thong dung PBKDF2.

## Trang Thai Chua Hoan Thien

- Chua co EF Core migration.
- Chua co report/RDLC.
- Chua co module day du cho hoa don, chi tiet hoa don va khach hang.
- Quan ly thuoc va nhan vien moi o muc co ban; chua co phan trang, export/import, audit log, phan quyen chi tiet.

## Ghi Chu

- Xem quy tac lam viec danh cho AI/developer trong `AGENTS.md`.
- Neu app khong khoi dong duoc, kiem tra `App.config`, database `PharmacyManagementSystemDb` va cac bang `Users`, `Medicines`.
- Sau khi sua code, nen chay:

```powershell
dotnet build PharmacyManagementSystem/PharmacyManagementSystem.csproj
```
