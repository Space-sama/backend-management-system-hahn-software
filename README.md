# Backend - .NET 8 Core CRUD Application

## Prerequisites
- .NET 8 SDK installed
- SQL Server installed
- Entity Framework Core Tools

## Setup Instructions

## Step 1: Clone the repository
`git clone [your-repo-url]`
`cd [your-backend-folder]`

## Step 2: Install .NET EF Core Tools
write down : `dotnet tool install --global dotnet-ef`

## Step 3: Configure Database Connection
Open the appsettings.json file and update the connection string to match the SQL Server instance:

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "Ticket_Database": "Server=your-server-name;Database=Ticket_Database;Trusted_Connection=True;Encrypt=False;"
  }
}

## Step 4: Create the SQL Database
Before running the application, ensure you have created the Ticket_Database (or the database name you used in the connection string) in SQL Server.

## Step 5: Run Migrations and Update the Database
Use the following commands to generate and apply the database schema:

`dotnet ef migrations add InitialCreate`
`dotnet ef database update`

## Step 6: Build and Run the Backend
Once the database is set up, you can build and run the project:

1. Build the project:
`dotnet build`
2. Run the project:
`dotnet run`

The backend will be running on http://localhost:5000 (or another port if configured).

### Dependencies
The following .NET packages are required for this project:

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design
System.Text.Json

You can add these packages with:
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package System.Text.Json

# Adding New Migrations
To create a new migration if your model changes, use the following command:
`dotnet ef migrations add [MigrationName]` ('InitialCreate')

# Updating the Database
To apply the migrations and update your database schema:
dotnet ef database update

then run the project always with : `dotnet build` & `dotnet run`

