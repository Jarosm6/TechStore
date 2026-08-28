# TechStore

TechStore is a work-in-progress e-commerce application built as a portfolio project.

The goal of the project is to build a complete online electronics store while developing practical experience with backend development, REST APIs, authentication, authorization, databases, and later a React frontend.

## Tech Stack

### Backend
- C#
- ASP.NET Core Web API
- .NET 10
- Entity Framework Core
- ASP.NET Core Identity
- MySQL
- Scalar / OpenAPI

### Frontend
- React *(planned)*

## Currently Implemented

### Products
- Retrieve all products
- Retrieve a product by ID
- Create new products through an admin-only endpoint
- Product data stored in MySQL using Entity Framework Core

### Authentication
- User registration
- User login
- User logout
- Cookie-based authentication
- Persistent login using "Remember Me"
- Password hashing handled by ASP.NET Core Identity
- Account lockout after multiple failed login attempts

### Authorization
- Role-based authorization
- `User` and `Admin` roles
- Admin-only endpoints protected with role authorization

### Database
- MySQL database integration
- Entity Framework Core migrations
- ASP.NET Core Identity tables
- Automatic initialization of application roles

### API
- REST API built with ASP.NET Core controllers
- DTOs used for incoming requests
- Appropriate HTTP status codes, including `201 Created` when creating resources
- OpenAPI documentation and endpoint testing with Scalar

## Planned Functionality

### Product Management
- Update existing products
- Delete products
- Product input validation
- Product categories
- Product search, filtering and sorting
- Pagination

### User Features
- User profile management
- Address management

### Shopping
- Shopping cart
- Cart quantity management
- Checkout process
- Order creation
- Order history
- Stock validation during purchases

### Admin Panel
- Product management
- Order management
- User management
- Basic store statistics

### Frontend
- React-based user interface
- Product catalogue
- Product details
- Authentication views
- Shopping cart
- Checkout
- User account
- Admin interface
- Responsive design

## Project Status

🚧 **Work in Progress**

The backend foundation is currently under development. Authentication, role-based authorization, product retrieval and admin product creation are already functional.

The next development stages will focus on completing product CRUD operations and validation before expanding the application with shopping and frontend functionality.

## Project Structure

```text
TechStore.API/
├── Controllers/
├── Data/
├── DTOs/
├── Migrations/
├── Models/
├── Program.cs
└── appsettings.json
```

## Security

Sensitive local configuration such as database credentials is stored using ASP.NET Core User Secrets and is not committed to the repository.

## Author

Portfolio project created for learning and demonstrating practical full-stack development skills.