# Customer Management System

## Overview

Customer Management System is a comprehensive customer management system built using .NET Core 7.0. It provides an efficient and seamless approach to managing customer information, including adding, updating, and deleting customer data. With its modular architecture and integration of key technologies, CustomerFlow ensures high performance, security, and reliability.

## Features

- **Backend Development**: Built on .NET Core 7.0, using Generic Repository, Aspect-Oriented Programming, and Fluent Validation for clean, maintainable, and scalable code.
- **Caching & Performance**: Utilizes InMemoryCache for improved performance and fast data retrieval when accessing customer data.
- **Authentication & Security**: JWT authentication for secure access control and protecting sensitive customer data.
- **Dependency Injection**: Uses Autofac for efficient and scalable dependency injection, improving flexibility and maintainability of the application.
- **Transaction Management**: Custom aspects to handle transaction consistency and reliability during database operations, ensuring data integrity when managing customer information.

## Key Technologies

- **.NET Core 7.0**
- **Generic Repository Pattern**
- **Aspect-Oriented Programming**
- **Fluent Validation**
- **Entity Framework**
- **JWT Authentication**
- **Autofac**

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
