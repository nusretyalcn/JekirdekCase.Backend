# Customer Management System

## Overview

Customer Management System is a comprehensive customer management system built using .NET Core 7.0. It provides an efficient and seamless approach to managing customer information, including adding, updating, and deleting customer data. With its modular architecture and integration of key technologies, CustomerFlow ensures high performance, security, and reliability.

## Features

- **Backend Development**: Built on .NET Core 7.0, using Generic Repository, Aspect-Oriented Programming, and Fluent Validation for clean, maintainable, and scalable code.
- **Authentication & Security**: JWT authentication for secure access control and protecting sensitive customer data.
- **Dependency Injection**: Uses Autofac for efficient and scalable dependency injection, improving flexibility and maintainability of the application.

## Key Technologies

- **.NET Core 7.0**
- **Generic Repository Pattern**
- **Aspect-Oriented Programming**
- **Fluent Validation**
- **Entity Framework**
- **JWT Authentication**
- **Autofac**

  ## Changing the Connection String in EfDbContext.cs

To configure the connection string for your database, you need to modify the connection string in the `EfDbContext.cs` file. Here's how you can do it:

1. Open the file: `JekirdekCase.Backend\DataAccess\Concrete\EntityFramework\Context\EfDbContext.cs`.
   
2. Locate the line where the connection string is set. It will look something like this:

   ```csharp
   optionsBuilder.UseNpgsql("Your_Connection_String_Here");

## CORS Policy

The CORS policy is configured to allow requests from specific origins. The frontend host address is defined in the `Program.cs` file inside the `policy.WithOrigins("http://localhost:3000")` line.

You can modify this URL to match the address of your frontend application, if needed. 
   ```csharp
policy.WithOrigins("http://your-frontend-url.com")

   ```      
  
     
           

For example, if your frontend is hosted on a different address, update it like so:




## Registering to the System

To register a new user in the system, send a **POST** request to the following endpoint:

**URL:** `https://localhost:7256/api/Auth/register`

    ```json {
       "email": "string",
       "password": "string",
       "firstName": "string",
        "lastName": "string"
        }   
 

### Request Body:
The email field must be in a valid mail format for validation rules (e.g., user@gmail.com).

## Logging in Web API
## Logging

The logs for the Web API are saved to a file located at:Web Api/logs


## PostgreSQL Tables

### Customers

| Column Name        | Data Type          | Description          |
|--------------------|--------------------|----------------------|
| **Id**             | integer (Primary Key) | Customer ID         |
| **FirstName**      | character varying   | Customer First Name  |
| **LastName**       | character varying   | Customer Last Name   |
| **Email**          | character varying   | Customer Email       |
| **RegistrationDate** | date             | Registration Date    |
| **Region**         | character varying   | Customer Region      |

---

### Users

| Column Name        | Data Type          | Description          |
|--------------------|--------------------|----------------------|
| **Id**             | integer (Primary Key) | User ID            |
| **FirstName**      | character varying   | User First Name      |
| **LastName**       | character varying   | User Last Name       |
| **Email**          | character varying   | User Email           |
| **PasswordHash**   | bytea              | Hashed Password      |
| **PasswordSalt**   | bytea              | Salt for Password    |
| **CreatedAt**      | timestamp without time zone | User Creation Time |
| **UpdatedAt**      | timestamp without time zone | Last Update Time   |

---

### OperationClaims

| Column Name        | Data Type          | Description          |
|--------------------|--------------------|----------------------|
| **Id**             | integer (Primary Key) | Operation Claim ID  |
| **Name**      | character varying   | Role Name |

---

### UserOperationClaims

| Column Name           | Data Type          | Description          |
|-----------------------|--------------------|----------------------|
| **Id**                | integer (Primary Key) | User-Operation Claim ID |
| **UserId**            | integer            | UserId For Role|
| **OperationClaimId**  | integer            | Role Id |


## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/nusretyalcn/JekirdekCase.Backend
   
2. Install dependencies:
   ```bash
   dotnet restore
 
3. Run the project:
   ```bash
   dotnet run


