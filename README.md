# EquadisRJP

## Overview

EquadisRJP is an advanced **Supplier and Retailer Management** system built with ASP.NET 8 and a modular Domain-Driven Design (DDD) architecture. It consists of two primary Web API services:
- **EquadisRJP.IdentityAuth**: A standalone identity authentication service using JWT.
- **EquadisRJP.Service**: A core API that handles business logic, connected to multiple DDD-based libraries.

The system supports complex supplier-retailer relationships, partnership tracking, commercial offer publishing, and access control—all with a focus on clean architecture and security best practices.

## Technologies Used

- **Language & Framework**: C# with .NET 8
- **Architecture**: Domain-Driven Design (DDD)
  - EquadisRJP.Domain
  - EquadisRJP.Application
  - EquadisRJP.Infrastructure
  - EquadisRJP.Service
- **Design Patterns**:Clean Architecture (Onion Architecture)
  - Mediator
  - CQRS
  - Dependency Injection
  - DTO Mapping
- **Authentication**: JWT Bearer tokens via ASP.NET Identity
- **Validation**: FluentValidation
- **Mapping**: AutoMapper
- **Logging**: NLog
- **Documentation**: Swagger via Swashbuckle
- **ORM**: Entity Framework Core
- **Database**: SQL Server

## Features

- 🔐 Identity and authentication system using JWT tokens
- 🧑‍🤝‍🧑 Partnership management between suppliers and retailers
- 📈 Commercial offers and retailer subscriptions
- 🔄 Partnership expiration and renewal tracking
- ✅ Fluent request validation and DTO mapping
- 📦 Layered DDD structure with separation of concerns
- 📝 Integrated Swagger documentation
- 📊 Logging with NLog


## Domain Summary

- A **supplier** can be linked to multiple retailers.
- A **retailer** can be linked to multiple suppliers.
- The system tracks:
  - Creation and status of **partnerships**
  - Supplier-created **offers** (e.g., discounts or time-limited promotions)
  - **Retailer subscriptions** to those offers
  - Access control to offers: only active partnered retailers can view them

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server (local or remote)
- Visual Studio 2022 or any compatible IDE

## Setup Steps

### 1. Clone the Repository

```bash
git clone https://github.com/HadiBawarshi/EquadisRJP.git
cd EquadisRJP
```
### 2. Open the Solution

Open `EquadisRJP.sln` in Visual Studio 2022.

### 3. Database Setup

Choose one of the following:

#### Option A: Use SQL Script

- Navigate to the `Resources` folder.
- Use one of the provided `.sql` files:
  - **Schema only** – Creates just the structure.
  - **Schema + Seed** – Creates the structure and inserts sample data including an admin user.
- Create a database named `RjpDb`, then execute the chosen SQL script.

#### Option B: Use Backup File

- Use the `RjpDb.bak` file from the `Resources` folder to restore the full database using SQL Server Management Studio (SSMS).

### 4. Configure Connection String

Open `appsettings.Development.json` and update the connection string if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=RjpDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
### 5. Running the Project

- Set `EquadisRJP.Service` as the startup project to launch the Swagger UI.
- **Recommended**: Use a launch profile that starts both `EquadisRJP.Service` and `EquadisRJP.IdentityAuth` to enable authentication and full API functionality(you will need role based tokens to access certain apis).

---

## API Documentation

Swagger UI is enabled by default.

Access it by navigating to:
```bash
https://localhost:<port>/swagger
```

## License

This project is open-source and can be modified as needed.

---

## Author

**Hadi Bawarshi**  
[GitHub](https://github.com/HadiBawarshi)
