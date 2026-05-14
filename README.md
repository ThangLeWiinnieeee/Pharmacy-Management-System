# PharmacyManagementSystem

Ung dung desktop Windows Forms de quan ly nha thuoc. Project dang di theo kien truc 3-layer va MVP:

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
3. Chay cac script trong folder `SQL_Database/` de tao bang hien co:
   - `User.sql`
   - `Medicines.sql`
4. Tao file `PharmacyManagementSystem/App.config` tu file mau `PharmacyManagementSystem/App.config.example`.
5. Sua connection string `PharmacyDb` trong `App.config` cho dung SQL Server tren may dang chay.
6. Restore NuGet packages neu IDE chua tu dong restore.

`App.config` la cau hinh cuc bo. Khong dua connection string that, ten may noi bo, tai khoan hoac mat khau vao README.

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
    |-- GUI/            # Windows Forms views
    |   `-- Controls/   # RoundedButton, RoundedPanel, RoundedTextBox
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

| Chuc nang | Man hinh | Trang thai |
|-----------|----------|------------|
| Dang nhap | `LoginForm` | Validate input, verify mat khau PBKDF2, kiem tra active, dieu huong theo role |
| Dang ky | `RegisterForm` | Validate input, hash mat khau PBKDF2, tao tai khoan role `Staff` |
| Dashboard Admin | `MainForm` | Thong ke thuoc, ton kho, sap het hang, sap het han, Admin, Staff, user active |
| Khu vuc Staff | `StaffHomeForm` | Man hinh lam viec co ban cho tai khoan Staff |
| Dang xuat | `MainForm`, `StaffHomeForm` | Quay lai `LoginForm` de dang nhap tai khoan khac |
| Database check | `Program.cs`, `DatabaseInitializer` | Kiem tra ket noi database khi khoi dong app |

## Luong Chay

1. App chay tu `Program.cs`.
2. `DatabaseInitializer` kiem tra ket noi database.
3. Neu ket noi thanh cong, app mo `LoginForm`.
4. Nguoi dung co the dang nhap hoac mo `RegisterForm` de dang ky.
5. Tai khoan dang ky moi mac dinh role `Staff`.
6. Dang nhap thanh cong se dieu huong theo role:
   - `Admin` mo `MainForm`
   - `Staff` mo `StaffHomeForm`
7. Nut dang xuat tren `MainForm`/`StaffHomeForm` dong man hinh hien tai va hien lai `LoginForm`.

## Database

`AppDbContext` hien co:

- `DbSet<User>` mapping bang `Users`
- `DbSet<Medicine>` mapping bang `Medicines`

Project hien chua dung EF Core migration. Schema database duoc tao/cap nhat thu cong bang SQL Server Management Studio va cac script trong `SQL_Database/`.

## Quy Uoc Chinh

- GUI chi xu ly UI, doc input, bind data va goi Presenter.
- Presenter dieu phoi giua View va BLL.
- BLL chua nghiep vu, validation va goi DAL qua interface.
- DAL chi truy xuat du lieu bang EF/LINQ, khong viet SQL thuan trong C#.
- DTO dung de truyen du lieu giua cac tang.
- Entity dung cho EF Core/database mapping.
- Role hien tai chi gom `Admin` va `Staff`.
- Mat khau khong luu plain text; login/register dung PBKDF2.

## Trang Thai Chua Hoan Thien

- Chua co EF Core migration.
- Chua co report/RDLC.
- Chua co Guna UI.
- Chua implement day du quan ly thuoc, hoa don, khach hang va nhan vien.
- `MedicineForm.cs`, `ReportForm.cs`, `SearchBarControl.cs` va mot so file Presenter/BLL/DAL/interface lien quan den Medicine/Invoice/Employee/Customer van dang la placeholder rong.

## Ghi Chu

- Xem them quy tac lam viec trong `AGENTS.md`.
- Neu cap nhat schema khi chua dung migration, can cap nhat dong bo SQL script, Entity, DTO, DAL va BLL lien quan.
- Neu app khong khoi dong duoc, kiem tra `App.config`, database `PharmacyManagementSystemDb` va cac bang `Users`, `Medicines`.
