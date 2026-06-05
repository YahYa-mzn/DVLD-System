<div align="center">

# DVLD System
### Driver & Vehicle License Department

**A full-featured desktop application for managing the complete lifecycle of driving licenses**

`C#` `.NET Framework` `WinForms` `ADO.NET` `SQL Server`

**Version 1.2** — by [Yahya Mazini](https://github.com/YahYa-mzn)

</div>

---

## About This Project

This project is a complete implementation of the **DVLD (Driver & Vehicle License Department)** system, based on **Course 19 by Mohammed Abu Hadhoud ([Programming Advices](https://www.youtube.com/@ProgrammingAdvices))**.

It covers everything taught from the beginning of the course to the end — people management, applications, test scheduling, license issuance, detention, international licenses, user roles, and more.

### Development Timeline

**Version 1.0 — 28 days**

The core system was built in 28 days, working a minimum of 5 hours per day. Progress was tracked with daily notes throughout the entire build.

- **Days 1–1 (Database):** 3 days studying the database design (≈22 hours from the course), then 1 day (≈9 hours) to build it independently.
- **Days 2–28 (Implementation):** The remaining 23+ days were spent implementing the full system in C# — dividing the problem, designing and building each layer, debugging, and thinking through how to make every piece reusable and efficient.

The approach was disciplined: **always solve the problem before looking at the mentor's solution**. Every feature was independently designed and implemented first. Only after finishing was the course solution consulted — and in several cases, a different (and cleaner) approach was reached independently, most notably the `clsDBManager` class (see below).

Progress was noted every single day during v1.0.

**Version 1.2 — ~15 days of extensions**

After completing v1.0 and reviewing the mentor's solution, a second phase of enhancements was built over approximately 15 days. These extensions touched the UI, business logic, database, and added several features not present in the base course version:

- License serial number generation (database-backed, auto-incrementing with year prefix)
- International license serial number (same system, separate sequence)
- Today's Test Appointments screen (view and take tests directly from the dashboard)
- Screen-level access control (permissions assigned per screen, enforced at navigation)
- Login/register improvements

---

## Screenshots

### Login Screen
![Login](screenshot_login.png)

### Dashboard — Live Stats & Navigation
![Dashboard](screenshot_dashboard.png)
> Active licenses, expired licenses, detained licenses, pending applications, international licenses, and today's test appointments — all visible at a glance on the main screen.

### Today's Test Appointments
![Appointments](screenshot_appointments.png)
> Examiners can view all scheduled tests for the day, filter by status (locked/unlocked), and record results directly.

### People Management
![People](screenshot_people.png)
> Full CRUD with multi-field search and filtering. Right-click context menu: Show Details, Edit, Delete (soft/hard), Recover, Send Email, Phone Call.

---

## Architecture

The solution is split into **three strictly separated projects** plus a shared utilities library. No layer ever bypasses the one below it.

```
┌─────────────────────────────────────────────────────┐
│              DVLD  (Presentation Layer)              │
│        WinForms — Forms, Dialogs, Controls           │
│   Only simple validation & UI logic lives here.      │
└──────────────────────┬──────────────────────────────┘
                       │  references only
┌──────────────────────▼──────────────────────────────┐
│           DVLD-BLL  (Business Logic Layer)           │
│  Domain classes, workflow rules, DTO ↔ Object        │
│  conversion, enums, permission system, validation    │
└──────────────────────┬──────────────────────────────┘
                       │  references only
┌──────────────────────▼──────────────────────────────┐
│           DVLD-DAL  (Data Access Layer)              │
│  Static classes, inline SQL, SqlConnection,          │
│  SqlCommand, SqlDataReader, DTOs, clsDBManager       │
└──────────────────────┬──────────────────────────────┘
                       │
               [ SQL Server Database ]
```

Each layer communicates through **DTO (Data Transfer Object)** structs — domain objects never leak into the DAL and database types never leak into the BLL.

---

## clsDBManager — Generic Database Infrastructure

One of the key independent design decisions in this project is `clsDBManager` — a generic, centralized database handler in the DAL that eliminates boilerplate across all data access classes.

Instead of every DAL class opening connections and building commands manually, all database operations are routed through a small set of generic methods. Each DAL class just passes the SQL string and a delegate to fill the DTO:

```csharp
// Reading a single row — DAL only writes the query and the DTO filler
public static clsDriverDTO GetDriver_InDB(int DriverID)
{
    string Query = "SELECT TOP 1 * FROM Drivers WHERE DriverID = @DriverID";
    return clsDBManager.GetRowByColumn_InDB<clsDriverDTO, int>(Query, "DriverID", DriverID, FillDriverDTO);
}

// Adding a new row — DAL passes the INSERT and a parameter-binding action
public static int AddNewPerson_InDB(clsPersonDTO PersonDTO)
{
    string NonQuery = "INSERT INTO People (...) VALUES (...)";
    return clsDBManager.AddNewRow_InDB<clsPersonDTO>(NonQuery, ReplacePersonParameters, PersonDTO);
}
```

**What `clsDBManager` handles for every operation:**
- Opening and disposing `SqlConnection` and `SqlCommand` via `using` blocks
- Null-safe parameter binding (`DBNull.Value` for null values)
- `SCOPE_IDENTITY()` appended automatically on inserts to return the new row ID
- `ExecuteNonQuery` result validation (exactly 1 row affected = success)
- Consistent exception re-throwing without swallowing errors

**Available methods:**

| Method | Purpose |
|--------|---------|
| `GetAllRows_InDB` | Fetch all rows, no condition |
| `GetAllRowsWithCondition_InDB<T>` | Fetch rows with one WHERE parameter |
| `GetAllRowsWithConditions_InDB<T1,T2>` | Fetch rows with two WHERE parameters |
| `GetRowByColumn_InDB<T1,T2>` | Fetch single row by one column, fill via `Func<SqlDataReader, T>` |
| `GetRowByTwoColumns_InDB<T1,T2,T3>` | Fetch single row by two columns |
| `IsRowExistsByColumn_InDB<T>` | Existence check by one column |
| `IsRowExistsByTwoColumns_InDB<T1,T2>` | Existence check by two columns |
| `CountRecords_InDB<T>` | Count with optional filter (1 or 2 params) |
| `GetColumnRow_InDB<T1,T2>` | Fetch a single scalar value |
| `AddNewRow_InDB<T>` | INSERT — returns new row ID |
| `UpdateRow_InDB<T>` | UPDATE — returns bool (1 row affected) |
| `DeleteRow_InDB<T>` | DELETE — returns bool (1 row affected) |

This approach keeps every DAL class lean, consistent, and focused only on its own queries and DTO structure.

---

## Domain Model

| Class | Description |
|-------|-------------|
| `clsPerson` | Core identity. 4-part name, DOB, NationalNo, phone, email, address, nationality, photo. Unique field enforcement on NationalNo, Phone, and Email. |
| `clsDriver` | Created automatically on first license issuance. Linked to a person. |
| `clsUser` | System operator. Linked to a person. Holds username, password, bitmask permissions, and a role derived at runtime. |
| `clsLicenseClass` | One of 7 vehicle categories. Stores minimum age, validity length (years), and fees. |
| `clsLicense` | An issued local license. Serial number, issue/expiry dates, paid fees, issue reason, active/detained status. |
| `clsInternationalLicense` | Issued on top of a valid Class 3 local license. 1-year validity. Previous ones deactivated automatically. |
| `clsApplication` | Base class for all service requests. Tracks applicant, type, date, status, and fees. |
| `clsLocalDrivingLicenseApplication` | Extends `clsApplication`. Owns the test pipeline via a `PassedTests` counter (0 → 3). |
| `clsApplicationType` | 8 service types: New License, Renew, Replace Lost, Replace Damaged, Release Detained, International, Retake Test, Reactivate. |
| `clsTestType` | One of 3 test stages: Vision ($10), Written ($20), Practical (variable). |
| `clsTestAppointment` | Scheduled test slot. Tracks lock status, retake application ID, and examiner. |
| `clsTest` | Recorded result (pass/fail + notes) of an appointment. |
| `clsDetainedLicense` | Tracks seized licenses with fine fees, detain/release dates, and release application linkage. |
| `clsSerialNumber` | Generates formatted serial numbers (`PREFIX-YEAR-SEQUENCE`) backed by a DB counter. Used for both local and international licenses. |
| `clsCountry` | Static nationality reference data. No CRUD. |

---

## Features & Services

### Dashboard
Live summary counters on the main screen: Active Licenses, Expired Licenses, Detained Licenses, Pending Applications, International Licenses, Today's Test Appointments.

### Driving License Services

| Service | Description |
|---------|-------------|
| New Local Driving License | Opens a full application → test pipeline → license issuance flow |
| New International License | Requires valid Class 3 local license |
| Retake Test | New application to reschedule a failed test |
| Renew Driving License | Renewal application with fee |
| Replacement for Lost or Damaged | Issues a replacement; old license deactivated |
| Release Detained License | Releases a seized license after fine payment |

### Test Pipeline (First-Time License)

An applicant must pass 3 sequential tests before a license is issued:

```
New Application (PassedTests = 0)
      │
      ▼
  Vision Test ──── Fail → Retake Application → Reschedule
      │ Pass (PassedTests = 1)
      ▼
  Written Test ─── Fail → Retake Application → Reschedule
      │ Pass (PassedTests = 2)
      ▼
  Practical Test ── Fail → Retake Application → Reschedule
      │ Pass (PassedTests = 3)
      ▼
  Application → Completed
  License Issued + Serial Number Generated
```

`CurrentTestType` is a computed property — it always returns the next required test based on `PassedTests`. A license is only issued when `IsPassedAllTests()` is true.

### License Classes

| ID | Class |
|----|-------|
| 1 | Small Motorcycle |
| 2 | Heavy Motorcycle |
| 3 | Ordinary Driving (car) — required for international license |
| 4 | Commercial Vehicles |
| 5 | Agricultural Vehicles |
| 6 | Small and Medium Bus |
| 7 | Truck and Heavy Vehicle |

### User Roles & Permissions

Permissions are stored as a **bitmask integer** using the `[Flags]` pattern. The role is **never stored** — it is derived at runtime from the permission value.

| Role | Access |
|------|--------|
| Admin | All permissions (`-1`) |
| Applications Officer | All license services + test management + detention |
| Tester | Today's Test Appointments only |
| Clerk | Any custom subset of individual permissions |

Permission bits include: `UsersManagement`, `PeopleManagement`, `DriversManagement`, `NewLocalDrivingLicenseApplication`, `NewInternationalDrivingLicenseApplication`, `RetakeTestApplication`, `RenewDrivingLicenseApplication`, `ReplacementForLostOrDamagedLicenseApplication`, `ReleaseDrivingLicenseApplication`, `TodaysTestAppointments`, `DetainLicense`, `ManageApplicationTypes`, `ManageTestTypes`, and more.

---

## Tech Stack

| Technology | Usage |
|------------|-------|
| C# .NET Framework | Core language |
| WinForms | Desktop UI |
| ADO.NET | Raw SQL — `SqlConnection`, `SqlCommand`, `SqlDataReader`, `DataTable` |
| SQL Server | Relational database (includes views e.g. `DriversListInfo_View`) |

No ORM (Entity Framework, Dapper, etc.) is used. All queries are written as inline parameterized SQL in the DAL.

---

## Project Structure

```
DVLD-System/
│
├── DVLD/                               # Presentation Layer (WinForms)
│
├── DVLD-BLL/                           # Business Logic Layer
│   ├── clsPerson.cs
│   ├── clsDriver.cs
│   ├── clsUser.cs                      # Includes bitmask permission system
│   ├── clsLicense.cs
│   ├── clsLicenseClass.cs
│   ├── clsInternationalLicense.cs
│   ├── clsApplication.cs               # Base class
│   ├── clsLocalDrivingLicenseApplication.cs  # Inherits clsApplication
│   ├── clsApplicationType.cs
│   ├── clsTest.cs
│   ├── clsTestType.cs
│   ├── clsTestAppointment.cs
│   ├── clsDetainedLicense.cs
│   ├── clsSerialNumber.cs
│   ├── clsCountry.cs
│   ├── clsValidation.cs
│   └── clsUtility.cs
│
├── DVLD-DAL/                           # Data Access Layer
│   ├── clsDBManager.cs                 # Generic DB infrastructure (all operations)
│   ├── clsSettings.cs                  # Connection string
│   ├── clsPersonDAL.cs
│   ├── clsDriverDAL.cs
│   ├── clsUserDAL.cs
│   ├── clsLicenseDAL.cs
│   ├── clsLicenseClassDAL.cs
│   ├── clsInternationalLicenseDAL.cs
│   ├── clsApplicationDAL.cs
│   ├── clsLocalDrivingLicenseApplicationDAL.cs
│   ├── clsTestDAL.cs
│   ├── clsTestTypeDAL.cs
│   ├── clsTestAppointmentDAL.cs
│   ├── clsDetainedLicenseDAL.cs
│   └── clsSerialNumberDAL.cs
│
├── Utilities/
│   ├── clsValidation.cs                # Names, phone, email, NationalNo, etc.
│   └── clsUtility.cs                   # Full name builder, age calculator, date parser
│
├── People Images/                      # Profile photo storage (paths stored in DB)
├── DVLD Database.png                   # Database schema diagram
└── DVLD-System.sln
```

---

## Getting Started

### Prerequisites
- Windows OS
- Visual Studio 2019 or later
- SQL Server (Express or higher)
- SQL Server Management Studio (SSMS)

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/YahYa-mzn/DVLD-System.git
   ```

2. **Set up the database**
   - Open SSMS, create a database named `DVLD`
   - Run the database scripts or restore from backup if included
   - Schema reference: `DVLD Database.png`

3. **Configure the connection string**
   - In `DVLD-DAL/clsSettings.cs`, update the connection string to match your SQL Server instance

4. **Set up People Images folder**
   - Ensure the path configured for profile photos exists and is accessible

5. **Run**
   - Set `DVLD` as the startup project in Visual Studio
   - Build and run (`F5`)
   - Default credentials: `admin` / `1234`

---

## Known Limitations & Planned Improvements

The following are explicitly noted as TODOs in the source code:

- **Password hashing** — `HashPassword()` in `clsUser` is a placeholder. Passwords are currently stored as plain text.
- **License auto-expiration** — A SQL Server Agent Job is needed to deactivate licenses when `ExpirationDate` is reached. Noted in `clsLicense` but not yet implemented.
- **Late appointment auto-lock** — A SQL Server Agent Job is needed to lock appointments where the applicant did not attend. Noted in `clsTestAppointment` but not yet implemented.

---

## Credits

This project is based on **Course 19 by Mohammed Abu Hadhoud** from [Programming Advices](https://www.youtube.com/@ProgrammingAdvices).

Built by **Yahya Mazini** — [GitHub](https://github.com/YahYa-mzn)
