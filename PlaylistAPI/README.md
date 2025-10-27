# Playlist API

The application is built using **ASP.NET Core Web API (.NET 8)** and uses **Entity Framework Core InMemory Database** for data storage.  
All API endpoints are publicly available and documented through **Swagger UI**.

---

## 🔗 Code Repository
GitHub Repository: https://github.com/selcuksuatsayin-se/PlaylistAPI

---

## Design

### Overall Structure
The system follows a **layered and minimalistic architecture** to meet assignment requirements:
- **Controller Layer:** Handles API endpoints (PlaylistItemsController).
- **Model Layer:** Defines the data model (PlaylistItem).  
- Uses PlaylistContext with EF Core’s InMemory database provider.


The API supports the following operations:
- Retrieve all playlist items (`GET /api/PlaylistItems`)
- Retrieve a specific item by ID (`GET /api/PlaylistItems/{id}`)
- Add a new playlist item (`POST /api/PlaylistItems`)
- Update an existing item (`PUT /api/PlaylistItems/{id}`)
- Delete an item (`DELETE /api/PlaylistItems/{id}`)
- Search items by title (`POST /api/PlaylistItems/search?search={title}`)

---

## Tools & Technologies
- Language: C#
- Framework: .NET 8 Web API
- ORM: Entity Framework Core (InMemory provider)
- Documentation: Swagger
- IDE: Visual Studio 2022
- Deployment: Azure App Service

---

## Issues Encountered
- **Entity Framework InMemory Initialization**  
Initially, DbSet<PlaylistItem> returned null due to a missing initialization.  
Fixed by properly configuring the database in Program.cs
- **Swagger Not Displaying After Deployment**  
After deployment to Azure, Swagger UI didn’t load because it was wrapped inside an environment check if (app.Environment.IsDevelopment()).  
Since Azure runs in Production mode, this condition prevented Swagger from initializing.  
Solved by moving app.UseSwagger() and app.UseSwaggerUI() outside of the if (IsDevelopment) block in Program.cs, ensuring Swagger works in all environments.