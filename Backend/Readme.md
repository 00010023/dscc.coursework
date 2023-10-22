# Server Side Application for Blogger

This is a simple ASP.NET Core Web API application that provides endpoints for managing authors and their posts. It uses Entity Framework Core for data access and SQL Server as its database.

## Prerequisites
- .NET 6 SDK
- SQL Server (can be local or hosted, e.g., using Docker)
- (Optional) Postman API testing

## Setup

**1. Database Setup**

Ensure that SQL Server is running. If using Docker, you can start an instance with:

```shell
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=AreY0uD0neW1thCW!' -p 1433:1433 --name dscc-db -d mcr.microsoft.com/mssql/server:2022-latest
```

**2. Clone the Repository**

If the project is hosted on a Git repository, clone it:

```shell
git clone https://github.com/00010023/dscc.coursework.git
cd dscc.coursework
```

**3. Update Database Connection String**

In the `appsettings.json` file, ensure the connection string is set to your database:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Blog;User Id=sa;Password=AreY0uD0neW1thCW!;"
}
```

Adjust the server, user, and password as necessary.

**4. Run Migrations**

To create or update the database schema, run:

```shell
dotnet ef database update
```

## Running the Application

From the root directory of the project, run:

```shell
dotnet run
```

This will start the application. By default, it should be accessible at `https://localhost:5001/`.