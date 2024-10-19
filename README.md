**Product CRUD Operation**:

This is an ASP.NET Core MVC project for performing CRUD (Create, Read, Update, Delete) operations on a product database.
The project demonstrates how to implement a basic CRUD application using a repository pattern, Entity Framework, and Razor Views.

**Features**:
List all products
Add new products
Edit existing products
Delete products
Client-side validation and proper error handling.

**Technologies Used**:
ASP.NET Core MVC
C#
Entity Framework Core (for data access)
SQL Server (as the database)
Bootstrap (for UI styling)

**Prerequisites**:
Before running this project, ensure you have the following installed:
.NET 6.0 SDK or later
SQL Server
Visual Studio 2022 or Visual Studio Code with C# support

**Getting Started**:
Follow these steps to get the project up and running:
Clone the repository:
https://github.com/GitGuru87/ProductCrudOperation.
cd ProductCrudOperation

**Set up the database**
Create a new SQL Server database named ProductDb (or modify the connection string in appsettings.json to match your database configuration).
Run the provided SQL script (if available) to set up the Products table.

**Configure the connection string**:
In the appsettings.json file, update the DefaultConnection to match your SQL Server configuration:
"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-BHG14L9;Database=ProductDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
},

Apply migrations (if using Entity Framework):
dotnet ef database update
dotnet run
The application should be accessible at https://localhost:5001 or http://localhost:5000.

**Project Structure**:
Controllers/ProductController.cs: Handles the CRUD operations and interacts with the views.
Models/Product.cs: Represents the data model for a product.
DataAccess/ProductRepository.cs: Manages data access logic for products.
Views/Product: Contains the Razor views for displaying, adding, editing, and deleting products.
wwwroot: Contains static files such as CSS and JavaScript.

**Usage**:
Viewing Products: Visit the /Product/Index URL to see the list of products.
Adding a Product: Click the "Add New Product" button, fill out the form, and submit.
Editing a Product: Click the "Edit" link next to a product to modify its details.
Deleting a Product: Click the "Delete" link next to a product to remove it.

**Error Handling**:
Proper error handling is implemented for common issues, such as invalid data or failed operations.
Client-side validation is used to ensure that all required fields are filled in.


