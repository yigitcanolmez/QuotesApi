# QuotesApi

A robust ASP.NET Core Web API for managing quotes with authentication, caching, and database persistence.

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
