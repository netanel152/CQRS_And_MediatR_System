# CQRS and MediatR in ASP.NET Core

This project demonstrates the implementation of **CQRS (Command Query Responsibility Segregation)** and **MediatR** patterns in an ASP.NET Core Web API application. It uses **MediatR** to handle commands and queries, separating the read and write operations for better scalability and maintainability.

## Technologies Used

- **.NET Core 8**
- **MediatR**
- **Entity Framework Core**
- **CQRS Pattern**
- **SQL Server (or any DB provider you choose)**

## Features

- Separating commands (for write operations) and queries (for read operations) using the CQRS pattern.
- Implementation of MediatR for better separation of concerns.
- Sample CRUD operations (Create, Read, Update, Delete) using commands and queries.
- Proper usage of records for immutability in commands and queries.
- Dependency injection and middleware in ASP.NET Core.

## Getting Started

### Prerequisites

To run this project locally, you need the following:

- **.NET SDK** (6 or above)
- **SQL Server** (or another database provider)
- **Visual Studio** or **VS Code**

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/netanel152/CQRS_And_MediatR_System.git
   cd CQRS_And_MediatR_System
   ```

2. **Restore NuGet Packages:**

   Run the following command in the project folder to restore the required dependencies:

   ```bash
   dotnet restore
   ```

3. **Update Connection String:**

   Open `appsettings.json` and configure your database connection string.

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your-server;Database=your-database;User Id=your-username;Password=your-password;"
   }
   ```

4. **Apply Migrations:**

   Ensure that your database is set up correctly by applying migrations:

   ```bash
   dotnet ef database update
   ```

5. **Run the Application:**

   Start the application using the following command:

   ```bash
   dotnet run
   ```

6. **Access the API:**

   The API will be available at `https://localhost:5001` (or the port configured in `launchSettings.json`).

## Endpoints

Here’s a list of available API endpoints:

### Product Endpoints:

| HTTP Method | Endpoint                    | Description                  |
| ----------- | --------------------------- | ---------------------------- |
| GET         | `/api/products`              | Get all products              |
| GET         | `/api/products/{id}`         | Get product by ID             |
| POST        | `/api/products`              | Create a new product          |
| PUT         | `/api/products/{id}`         | Update an existing product    |
| DELETE      | `/api/products/{id}`         | Delete a product by ID        |

### Example POST Request

```json
POST /api/products
{
  "name": "Sample Product",
  "description": "Product description",
  "price": 29.99
}
```

### Example PUT Request

```json
PUT /api/products/{id}
{
  "id": "product-id",
  "name": "Updated Product Name",
  "description": "Updated description",
  "price": 39.99
}
```

## Project Structure

The project follows a **clean architecture** and **CQRS** pattern. Below is a brief description of the key components:

- **Commands**: These handle the **write operations** (create, update, delete) and use MediatR to process the command.
  - Example: `CreateProductCommand`, `UpdateProductCommand`, etc.

- **Queries**: These handle the **read operations** (fetching data) and follow the CQRS pattern by separating the logic from the write operations.
  - Example: `GetProductQuery`, `ListProductsQuery`, etc.

- **Handlers**: The logic for each command or query is handled by **MediatR Handlers**. These classes inherit from `IRequestHandler` and contain the logic to process the request.
  - Example: `CreateProductCommandHandler`, `GetProductQueryHandler`, etc.

## CQRS and MediatR in Action

- **Commands**: For every write operation (such as creating or updating a product), a command is sent via `MediatR`, and the corresponding handler takes action.
- **Queries**: A query is sent via `MediatR` for read operations, and the appropriate handler retrieves the required data.
  
This separation ensures that the application remains scalable and maintainable, especially as it grows larger.
