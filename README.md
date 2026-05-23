# Project-Managment

## Project Management API

A simple backend API for managing projects and tasks built with ASP.NET Core Web API using Clean Architecture principles.




## Features

## Authentication

- Register User

- Login User

- JWT Authentication

## Projects

- Create Project

- Get All Projects

- Get Project By Id

- Update Project

- Delete Project

## Tasks

- Create Task

- Get Tasks By Project

- Update Task Status

- Delete Task

---

# Technologies Used

- ASP.NET Core Web API

- .NET 9

- Entity Framework Core

- SQL Server

- JWT Authentication

- Clean Architecture

- Generic Repository Pattern

- FluentValidation




---



# Project Structure



```bash

ProjectManagement/

│

├── API

├── Core

├── Infrastructure

└── Application

```



---



# Architecture



The project follows Clean Architecture principles:



- API Layer  

Handles endpoints and middleware.



- Application Layer  

Contains business logic, DTOs, validation, and services.



- Infrastructure Layer  

Contains database access, repositories, authentication services, and external implementations.



- Core Layer  

Contains entities and domain models.



---



# Authentication



JWT Authentication is used to secure the API.



After login or register, a JWT token is returned.



Use the token in Swagger or Postman:



```text

Bearer YOUR\_TOKEN

```



---



# Global Exception Handling



The project uses custom middleware for handling exceptions globally.



Handled exceptions:

- Validation Exceptions

- General Exceptions



---



# Validation



FluentValidation is used for request validation.



Examples:

- Required fields

- Email validation

- Password minimum length

- Maximum length validation



---



# Database



Database Provider:

- SQL Server



Entity Framework Core is used with Code First approach and migrations.



---



# Setup Instructions



## 1. Clone Repository



```bash

git clone https://github.com/ayamohammed22/Project-Managment.git

```



---



## 2. Configure Database



Update connection string inside:



```text

appsettings.json

```



Example:



```json

"ConnectionStrings": {

&#x20; "DefaultConnection": "Server=.;Database=ProjectManagementDb;Trusted\_Connection=True;TrustServerCertificate=True"

}

```



---



## 3. Apply Migrations



```bash

dotnet ef database update

```



\---



## 4. Run Project



```bash

dotnet run

```



---



# Swagger



Swagger is enabled for testing API endpoints.



Swagger URL:



```text

https://localhost:7205/swagger/index.html

```



---



# API Endpoints



## Authentication



| Method | Endpoint |

|--------|-----------|

| POST | /api/User/register |

| POST | /api/User/login |



---



## Projects



| Method | Endpoint |

|--------|-----------|

| POST | /api/project |

| GET | /api/project |

| GET | /api/project/{id} |

| PUT | /api/project/{id} |

| DELETE | /api/project/{id} |



---



## Tasks



| Method | Endpoint |

|--------|-----------|

| POST | /api/task |

| GET | /api/task |

| PUT | /api/task |

| DELETE | /api/task/{id} |



---



# Future Improvements



- CQRS \& MediatR

- Unit Testing

- Docker Support

- Redis Caching

- Role-Based Authorization




---



# Author



Aya Mohamed Mostafa

Backend .NET Developer

