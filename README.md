# BankApp

A desktop banking application built with WPF and ASP.NET Core Web API, developed as a portfolio project to demonstrate practical knowledge of C# and .NET development.

## Overview

BankApp allows users to register an account, log in securely, view their balance, make deposits and withdrawals, and review their full transaction history. The project is actively being developed — the current focus is migrating from a local JSON-based architecture to a full client-server model with a REST API and SQL Server database.

## Features

- User registration with BCrypt password hashing
- Secure login and logout
- Account balance view with account number and owner details
- Deposit and withdrawal with insufficient funds validation
- Transaction history with date, type, amount and running balance
- Transfer between accounts *(in progress)*

## Architecture

The application is split into two main layers:

**WPF Client** — built using the MVVM pattern. ViewModels handle screen logic and communicate with the rest of the application through interfaces. Dependencies are wired in `App.xaml.cs` using the Composition Root pattern.

**REST API** — ASP.NET Core Web API with a layered architecture: Controllers → Services → Repositories → Entity Framework Core → SQL Server. Passwords are hashed using BCrypt. *(Migration of WPF client to consume this API is in progress.)*

```
WpfBankAccount  ──[in progress]──►  BankApp.Api  ──EF Core──►  SQL Server
```

## Technology Stack

| Layer | Technology |
|---|---|
| Language | C# / .NET 9 |
| UI | WPF (Windows Presentation Foundation) |
| API | ASP.NET Core Web API |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Architecture | MVVM, Repository Pattern, Dependency Injection |
| Security | BCrypt password hashing |

## Project Structure

```
BankApp/
├── WpfBankAccount/      # WPF desktop client (MVVM)
├── BankApp.Api/         # ASP.NET Core REST API
│   ├── Controllers/
│   ├── Services/
│   ├── Repositories/
│   ├── Models/
│   └── DTOs/
└── BankAccountCore/     # Shared business logic and models
```

## Getting Started

### Prerequisites

- Windows OS
- .NET 9 SDK
- Visual Studio 2022
- SQL Server or SQL Server Express

### Installation

```bash
git clone https://github.com/PiotrLukaszewiczDev/BankApp.git
```

Open `BankAccountConsole.sln` in Visual Studio.

**To run the API:** set `BankApp.Api` as the startup project, update the connection string in `appsettings.json`, run EF Core migrations and press F5. Swagger UI will open automatically.

**To run the WPF client:** set `WpfBankAccount` as the startup project and press F5.

## Roadmap

- [x] User registration and login
- [x] Deposit and withdrawal
- [x] Transaction history
- [x] REST API with EF Core and SQL Server
- [x] BCrypt password hashing
- [ ] Connect WPF client to REST API
- [ ] JWT authentication
- [ ] Transfers between accounts

## Author

Piotr Lukaszewicz — [GitHub](https://github.com/PiotrLukaszewiczDev)
