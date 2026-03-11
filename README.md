# ContactBook

A REST API for managing contacts, with search, filtering, and pagination. Built with ASP.NET Core 10 and Entity Framework Core.

## Features

- **Full CRUD** — Create, Read, Update, Delete contacts
- **Search** — Search across name, email, and company (case-insensitive)
- **Filter** — Filter contacts by company name
- **Pagination** — Page through results with configurable page size
- **Swagger UI** — Interactive API documentation

## Tech Stack

- ASP.NET Core 10 Web API
- Entity Framework Core (Code First)
- SQLite
- Swagger / OpenAPI

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Setup

```bash
# Clone the repository
git clone https://github.com/Grosstick/ContactBook.git
cd ContactBook

# Restore packages and run
dotnet restore
dotnet ef database update
dotnet run
```

The API will be available at `http://localhost:5010`.
Swagger UI: `http://localhost:5010/swagger`

The database is seeded with 10 sample contacts on first run.

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/contacts` | List all contacts (supports search, filter, pagination) |
| GET | `/api/contacts/{id}` | Get a single contact |
| POST | `/api/contacts` | Create a new contact |
| PUT | `/api/contacts/{id}` | Update a contact |
| DELETE | `/api/contacts/{id}` | Delete a contact |

### Query Parameters

| Parameter | Type | Description |
|-----------|------|-------------|
| `search` | string | Search in name, email, and company |
| `company` | string | Filter by exact company name |
| `page` | int | Page number (default: 1) |
| `pageSize` | int | Items per page (default: 10, max: 50) |

### Example Requests

```
GET /api/contacts?search=jan
GET /api/contacts?company=Netwise
GET /api/contacts?page=1&pageSize=5
GET /api/contacts?search=anna&company=Netwise
```

## Project Structure

```
ContactBook/
├── Controllers/
│   └── ContactsController.cs        # API endpoints
├── Models/
│   ├── Contact.cs                    # Entity model
│   └── DTOs/
│       ├── ContactDto.cs             # Response DTO
│       ├── CreateContactDto.cs       # POST request DTO
│       ├── UpdateContactDto.cs       # PUT request DTO
│       └── PagedResult.cs            # Pagination wrapper
├── Repositories/
│   ├── IContactRepository.cs         # Repository interface
│   └── ContactRepository.cs          # EF Core implementation
├── Data/
│   ├── ApplicationDbContext.cs        # Database context
│   └── SeedData.cs                   # Sample data seeder
└── Program.cs                        # App configuration
```

