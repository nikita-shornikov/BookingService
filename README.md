\# BookingService



Backend service for booking management (booking creation, confirmation, cancellation, completion).  

Architecture follows a Clean Architecture approach with separated layers (Domain, Application, Infrastructure, API).





\## 🧱 Tech Stack

\- .NET 8

\- ASP.NET Core Web API

\- xUnit (unit testing)

\- Clean Architecture (Domain / Application / Infrastructure / API)





\## 📂 Solution Structure

```

BookingService/

├─ src/

│ ├─ BookingService.Api # Web API (entry point)

│ ├─ BookingService.Application # Application services, DTOs, interfaces

│ ├─ BookingService.Domain # Entities, business rules, domain exceptions

│ └─ BookingService.Infrastructure # Persistence, external integrations (future)

└─ tests/

└─ BookingService.Domain.Tests # Unit tests for domain logic

```



\## 🧪 Tests



dotnet test



Status:

\- Domain model covered with unit tests (status transitions: draft → confirmed → completed / cancel behavior)





\## ▶️ Run API



Run locally:



dotnet run --project src/BookingService.Api



http://localhost:5207





\## 🏗️ Roadmap



\- \[x] Domain model (Booking) + rules

\- \[x] Domain unit tests

\- \[ ] Application layer (CQRS-style services)

\- \[ ] REST endpoints (controllers)

\- \[ ] EF Core persistence (e.g., PostgreSQL)

\- \[ ] Authentication \& per-user bookings

\- \[ ] Docker support





\## 📌 Notes



This repository is used for .NET backend portfolio development and interview preparation.



