# 💼 Job Application Manager

A complete system for managing job applications. The project allows users to sign up, log in, and organize their recruitment processes (companies, positions, status, and dates) through a Desktop interface connected to a RESTful API.

![Badge Status](https://img.shields.io/badge/Status-In_Development-yellow)
![Badge .NET](https://img.shields.io/badge/.NET-8.0-purple)
![Badge WinForms](https://img.shields.io/badge/Frontend-Windows_Forms-blue)

## 📸 Screenshots

*(Placeholder for your Login screen and Applications Grid screenshots)*

## 🚀 Tech Stack

### Backend (API)
- **C# .NET 8**: Main framework.
- **ASP.NET Core Web API**: Creation of REST endpoints.
- **Entity Framework Core**: ORM for database communication.
- **SQL Server**: Relational database.
- **Dependency Injection**: Configuration of services and repositories.

### Frontend (Desktop)
- **Windows Forms (WinForms)**: User Interface.
- **HttpClient**: API Consumption.
- **System.Text.Json**: JSON serialization and deserialization.
- **Async/Await**: Asynchronous programming to ensure a responsive UI.

### Architecture & Patterns
The project follows an N-Tier architecture to separate responsibilities:
- **ProjectDomain**: Database entities (`ApplicationEntity`, `ApplicantEntity`).
- **ProjectShared**: DTOs (Data Transfer Objects) shared between Front and Back.
- **ProjectApplication**: Business logic, Services, and Interfaces.
- **ProjectAPI**: Controllers and entry configuration.
- **ProjectWinForms**: User Interface layer.

## ✨ Features

- [x] **Authentication**: User Sign Up and Login.
- [x] **Application CRUD**:
  - Add new job applications (Company, Position, Status).
  - List all applications for the logged-in user.
  - Edit application details.
  - Delete applications.
- [x] **Data Validation**: Handling of empty fields and invalid date formats.

## 🛠️ How to Run

### Prerequisites
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB or Full instance)

### Step 1: Database Setup
1. Navigate to the API project (`ProjectAPI`).
2. In `appsettings.json`, check the **Connection String**.
3. Open the **Package Manager Console** in Visual Studio.
4. Select `ProjectAPI` (or the project containing your Context) and run:
   ```powershell
   Update-Database
   ```

### Step 2: Running the API
1. Set `ProjectAPI` as the startup project.
2. Run the project (F5 or Ctrl+F5).
3. The API should open in the browser (Swagger UI) showing available endpoints. Note the URL (e.g., https://localhost:7001). (or the configured port). 

### Step 3: Running the WinForms Application
1. Go to the `ProjectWinForms` project.
2. In your service file (e.g., `ApiService.cs`), set the `BaseAddress` of `HttpClient` to the API URL from Step 2.
3. Right-click the Solution -> Properties -> Multiple startup projects.
4. Configure it to start both `ProjectAPI` and `ProjectWinForms` or just `ProjectWinForms` if the API is already running. 

## 📚 Key Learnings
During the development of this project, several key concepts were applied:
- **Object Mapping**: Manual conversion from Entities to DTOs to protect the database structure and format data for the UI (solving issues like mapping JobTitle in DB to PositionTitle in UI).
- **Dependency Injection (DI)**: Configuring Program.cs to inject services directly into Windows Forms.
- **Error Handling**: Implementing Try/Catch blocks and handling default values for null types (fixing DateTime minimum value errors).
- **API Consumption**: Using HttpClient with standard HTTP verbs (GET, POST, PUT, DELETE).

## 👨‍💻 Author

**Bernardo Guilherme Madruga Mecabô**

* [LinkedIn](https://www.linkedin.com/in/bernardomecabo/)
* [GitHub](https://github.com/bernardommecabo)