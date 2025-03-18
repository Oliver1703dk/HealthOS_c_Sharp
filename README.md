# HealthOS_c_Sharp



# .NET Project Setup and Run Guide

## Prerequisites

Ensure you have the following installed before setting up and running the project:

- .NET SDK (Latest stable version) → [Download](https://dotnet.microsoft.com/download)
- Visual Studio or any preferred IDE with .NET support → [Download](https://visualstudio.microsoft.com/)
- DataGrip or pgAdmin (for database management) → [DataGrip](https://www.jetbrains.com/datagrip/) | [pgAdmin](https://www.pgadmin.org/)
- PostgreSQL → [Download](https://www.postgresql.org/download/)

---

# Database Setup

To set up the database, run the `HealthOS.sql` file in **DataGrip** or **pgAdmin**. This file will create the necessary tables and insert initial data.

## Steps to Execute SQL File in pgAdmin
1. Open **pgAdmin** and connect to your PostgreSQL instance.
2. Create a new database if not already created.
3. Open the **Query Tool**.
4. Load `HealthOS.sql` into the Query Tool and execute it.

## Steps to Execute SQL File in DataGrip
1. Open **DataGrip** and connect to your PostgreSQL database.
2. Open the `HealthOS.sql` file.
3. Execute the script to create tables and seed data.

---

# Configure Database Connection

Modify the following file to include the correct database credentials:

**File:** `PersistenceHandler.cs`
```
csharp
private PersistenceHandler()
{
    string host = "localhost";
    int port = 5432;
    string database = "postgres";
    string username = "postgres";
    string password = "your_password_here";

    _connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";
    InitializePostgresqlDatabase();
}
```
Replace `your_password_here` with the actual password for your PostgreSQL database.

---

# Restore Dependencies

Run the following command to restore project dependencies:
```
dotnet restore
```

---

# Build the Project

To build the project, use:
```
dotnet build
```

---

# Run the Project

## For a web application:
```
dotnet run
```

## For a console application:
```
dotnet run --project YourProjectName
```

