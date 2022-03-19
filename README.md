# Library Management System - console project

1. The project is divided into layers 
2. This project contains:
* Entity framework
* Validations
* All CRUD operations
3. How to start the project:
* Make sure you have SSMS (SQL Server Management Studio) on your computer
* Enter the project via VS (Visual Studio)
* Enter Database/MyDbContext.cs then change the *localhost* to your server name
* Now enter the VS terminal
* For the next few steps, you will need to have the Entity Framework Core tools installed on your VS. If you don't enter the following command:
  ~~~
  dotnet tool install --global dotnet-ef
  ~~~
* After that instruct EF Core to create a migration named **InitialCreate**:
  ~~~
  dotnet ef migrations add InitialCreate
  ~~~
* At this point you can have EF create your database and create your schema from the migration. This can be done via the following:
  ~~~
  dotnet ef database update
  ~~~
* Now you are ready to run the project
* This project automatically creates a librarian with username: *admin* and password: *admin123*
