# Hotel Reservation System

1. Install these packages:
dotnet add package Microsoft.EntityFrameworkCore.SqlLite
dotnet add package Microsoft.EntityFrameworkCore.Design

2. Install this tool:
dotnet tool install --global dotnet-ef

3. Run initial migration:
dotnet ef migrations add InitialCreate -o Data/Migrations

4. Update database:
dotnet ef database update

5. Run backend:
dotnet run

## Note Regarding TokenService

The `TokenService` class included in this project is intended for future usage and is currently not implemented or utilized in the current version of the Hotel Reservation System. It has been included in the codebase as a placeholder for potential future authentication or authorization features.

As of the current scope, user authentication and authorization have not been implemented.

Thank you for your understanding.


Regards, Tran Nguyen Khoi.