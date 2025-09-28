# Calculator API

A simple API built with .NET 8 that performs basic arithmetic operations (Add, Subtract, Multiply, Divide) on two numbers.
The API is protected with JWT Authentication and provides an interactive Swagger UI for documentation and testing.

------------------------------------------------------------
✨ Features
------------------------------------------------------------
- Built with .NET 8 (ASP.NET Core)
- Interactive documentation with Swagger UI
- JWT Bearer Authentication with expiration
- Includes Unit Tests & Integration Tests
- Ready to run with Docker and docker-compose

------------------------------------------------------------
🛠 Requirements
------------------------------------------------------------
- .NET 8 SDK (if running locally)
- Docker
- Docker Compose

------------------------------------------------------------
🚀 Run with Docker Compose
------------------------------------------------------------
1. Make sure you are in the project root (where docker-compose.yml is located).
2. Run:
   docker-compose up --build
3. The API will be available at:
   http://localhost:8080/swagger

------------------------------------------------------------
🔑 Authentication
------------------------------------------------------------
The API requires a JWT token for protected endpoints.

1. Call the Login endpoint:
   POST /auth/login

   Response:
   {
     "token": "eyJhbGciOiJIUzI1NiIs..."
   }

2. Use the token in headers for subsequent requests:
   Authorization: Bearer <your_token_here>

3. Example request:
   curl -X POST "http://localhost:8080/calculate" ^
        -H "Authorization: Bearer <your_token_here>" ^
        -H "operation: add" ^
        -H "Content-Type: application/json" ^
        -d "{\"num1\": 10, \"num2\": 5}"

------------------------------------------------------------
🧪 Tests
------------------------------------------------------------
Run unit & integration tests:
   dotnet test

Tests include:
- Unit tests for arithmetic operations
- Integration tests for login and secured /calculate endpoint

------------------------------------------------------------
📂 Project structure
------------------------------------------------------------
API_Calculator/
│── src/
│   └── IO.Swagger/          # Main API project
│── IO.Swagger.Tests/        # Unit & Integration tests
│── Dockerfile               # Docker image definition
│── docker-compose.yml       # Multi-container orchestration
│── README.txt               # Project documentation

------------------------------------------------------------
📌 Notes
------------------------------------------------------------
- JWT tokens expire after 30 minutes (configurable in appsettings.json).
- Swagger UI will show a lock icon 🔒 for secured endpoints.
- To test easily, use Postman or Swagger’s built-in Authorize button.
