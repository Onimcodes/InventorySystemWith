# InventoryStystem


# 🛠 Inventory Management API

This project is a clean architecture implementation of an **Inventory & Orders Management System** built with .NET, EF Core, and PostgreSQL.

---

## 🚀 Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-repo/inventory-api.git
   cd inventory-api
2. **setup database connection**
   Update your connection string in appsettings.json under:
    "ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=InventoryDb;Username=postgres;Password=yourpassword"
}
3. Apply Migrations
   dotnet ef database update
4. Run the API
     dotnet run --project src/Inventory.Api
5. Test the endpoint.

## Assumptions

- Products are uniquely identified by Id (GUID).

- Orders are immutable once placed (cannot be edited, only canceled).

- Concurrency is handled with PostgreSQL row versioning (xmin) to prevent overselling.

- Stock is decreased only after a successful order.

- This is an API-only backend — no UI included.
  
## 🏗 Tech Stack Choices
.NET 8 – backend framework

- Entity Framework Core – ORM

- PostgreSQL – relational database

- MediatR – CQRS / request-response handling

- Clean Architecture – separation of concerns

## Important Notes

* Run the app inside a transaction-safe environment to prevent race conditions.

* Database migrations should be managed with EF Core (dotnet ef migrations add <Name>).

* For concurrency control, EF Core uses PostgreSQL’s xmin system column.

* Order placement retries on concurrency failure (optimistic concurrency handling).


## 📖 Next Steps

* Add authentication & authorization with a user module.

* Add reporting (sales, inventory levels).

* Containerize with Docker for easier deployment.


