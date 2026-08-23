# QuotesApi

A robust ASP.NET Core Web API for managing quotes with authentication, caching, and database persistence.

## Table of Contents

- [Overview](#overview)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [Configuration](#configuration)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Features](#features)
- [Build & Deployment](#build--deployment)

## Overview

QuotesApi is an ASP.NET Core REST API that provides CRUD operations for managing quotes. It features JWT-based authentication via Auth0, SQL Server integration with Entity Framework Core, response caching, and comprehensive error handling.

## Technology Stack

- **Framework**: ASP.NET Core (.NET)
- **Language**: C#
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT Bearer tokens (Auth0)
- **API Documentation**: Swagger/OpenAPI
- **CI/CD**: Azure Pipelines
- **Response Format**: JSON & XML

## Project Structure

```
QuotesApi/
├── Controllers/
│   ├── QuoteController.cs          # In-memory quote operations
│   └── EfQuoteController.cs         # Database-backed quote operations (JWT protected)
├── Data/
│   └── QuoteDbContext.cs            # Entity Framework DbContext
├── Models/
│   └── Quote.cs                     # Quote entity model
├── Middleware/
│   ├── ExceptionHandlerMiddleware.cs # Global exception handling
│   └── DenemeMiddleware.cs           # Custom middleware
├── Program.cs                       # Application entry point & configuration
└── appsettings.json                # Configuration file
```

## Prerequisites

- .NET SDK (version specified in project)
- SQL Server 2016 or higher
- Auth0 account (for JWT authentication)
- Visual Studio 2022 or Visual Studio Code

## Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/yigitcanolmez/QuotesApi.git
cd QuotesApi
```

### 2. Restore NuGet Packages

```bash
dotnet restore
```

### 3. Configure Database Connection

Update `appsettings.json` with your SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "Sql": "Server=YOUR_SERVER;Database=QuotesDb;User Id=sa;Password=YOUR_PASSWORD;"
  }
}
```

### 4. Apply Database Migrations

```bash
dotnet ef database update
```

### 5. Run the Application

```bash
dotnet run
```

The API will be available at `https://localhost:5123`

## Configuration

### appsettings.json

```json
{
  "ConnectionStrings": {
    "Sql": "your_sql_server_connection_string"
  },
  "Jwt": {
    "Authority": "https://dev-iaz33aj5ecqggglu.us.auth0.com",
    "Audience": "http://localhost:5123"
  }
}
```

### Authentication Setup (Auth0)

The API is configured with Auth0 JWT Bearer authentication:

- **Authority**: `https://dev-iaz33aj5ecqggglu.us.auth0.com`
- **Audience**: `http://localhost:5123`

To authenticate requests:
1. Obtain a JWT token from Auth0
2. Include it in the request header: `Authorization: Bearer <token>`

## API Endpoints

### QuoteController (In-Memory - No Auth Required)

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/quote` | Get all quotes |
| `POST` | `/quote/Post` | Create a new quote |
| `PUT` | `/quote/{id}` | Update quote by index |
| `DELETE` | `/quote/{id}` | Delete quote by index |

### EfQuoteController (Database-Backed - JWT Required)

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/efquote` | Get all quotes (supports sorting) |
| `GET` | `/api/efquote/PagingQuote` | Get paginated quotes |
| `GET` | `/api/efquote/SearchingQuote` | Search quotes by title |
| `GET` | `/api/efquote/{id}` | Get quote by ID |
| `POST` | `/api/efquote` | Create a new quote |
| `PUT` | `/api/efquote/{id}` | Update quote by ID |
| `DELETE` | `/api/efquote/{id}` | Delete quote by ID |

### Query Parameters

- **sorting**: `asc` - ascending order, `desc` - descending order (by CreatedAt)
- **pageNumber**: Page number for pagination
- **pageSize**: Items per page
- **type**: Search term for quote titles

## Features

### ✅ Response Caching

- Client-side caching enabled for GET requests (60-second TTL)
- Response cache headers included for `/api/efquote` endpoint

### ✅ Global Exception Handling

- Custom exception middleware for consistent error responses
- Handles specific exceptions (FileNotFoundException)
- Returns 500 Internal Server Error for unhandled exceptions

### ✅ JWT Authentication

- Auth0 integration for secure API access
- `[Authorize]` attribute on EfQuoteController
- Bearer token validation on all protected endpoints

### ✅ Entity Framework Core

- SQL Server database integration
- Efficient query execution with IQueryable support
- LINQ-based query composition

### ✅ API Documentation

- Swagger/OpenAPI integration
- Interactive API explorer at `/swagger`
- Automatically generated from code

### ✅ Content Negotiation

- JSON and XML response formats supported
- Content-Type negotiation via `AddXmlSerializerFormatters()`

## Build & Deployment

### Build

```bash
dotnet build
```

### Run Tests

```bash
dotnet test
```

### Publish

```bash
dotnet publish -c Release -o ./publish
```

### Azure Pipelines

The project includes an `azure-pipelines.yml` configuration:

- **Trigger**: Master branch
- **Platform**: Windows-latest
- **Pipeline Steps**:
  1. NuGet Tool Installer
  2. NuGet Restore
  3. Visual Studio Build (Release)
  4. Unit Tests (VSTest)
  5. Artifact Creation

## Quote Model

```csharp
public class Quote
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

## Error Handling

The API implements comprehensive error handling:

- **200 OK**: Successful operations
- **400 Bad Request**: Invalid request data
- **401 Unauthorized**: Missing or invalid JWT token
- **404 Not Found**: Resource not found
- **500 Internal Server Error**: Server exceptions with detailed logging

## Development

### Run in Development Mode

```bash
dotnet run --launch-profile https
```

Swagger UI will be available at: `https://localhost:5123/swagger`

### Hot Reload

```bash
dotnet watch run
```

## License

This project is open source and available under the [MIT License](LICENSE).

## Author

**Yiğitcan Ölmez** - [@yigitcanolmez](https://github.com/yigitcanolmez)

---

For issues, questions, or contributions, please visit the [GitHub repository](https://github.com/yigitcanolmez/QuotesApi).
