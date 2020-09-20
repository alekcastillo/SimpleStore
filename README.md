
# SimpleStore
This project was started for our 'Web Development' college class. It uses .Net Core 3.1, ReactJS 16 & Boostrap 4.1.3, and was created using the [.Net Core & React template proyect](https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-3.1), which means that both the backend & frontend servers run in parallel. For database control, we used the Entity Framework Core 3.1.8 ORM in a Code-First modality, which means that the database is declared first in models and then created & updated via automatic migrations.

# Setup
Follow this guide to get the proyect working locally on your machine in a couple of minutes.

## Database

The project is intended to use Visual Studio's **included** SQL Server instance as its database engine by default. If you want to connect to the database from your SQL Server Management Studio, you can use the following server names coupled with the default Windows Authentication:
- ****Visual Studio 2012**:**
> (localdb)\v11.0
- ****>= Visual Studio 2015**:**
> (localdb)\MSSQLLocalDB

By default, the appsettings.json use *Server = (localdb)\\MSSQLLocalDB* in the SimpleStoreDb connection string. If you use Visual Studio 2012, you'll have to change this to *Server = (localdb)\v11.0*.

## Migrations

When running the project for the first time or updating it, you'll have to run the migrations to create or update your database to match the designed models. To do this, you'll have to install the .Net Core CLI Tools if you don't have them already:
>dotnet  tool install --global dotnet-ef

Once you have that, go to the projects root directory and run:
>dotnet  ef database update

If you update the models, you'll also have to create a migration to update the database. To do this, just run (replacing <MIGRATION_NAME> with a specific name that describes your change>:
>dotnet  ef migrations add <MIGRATION_NAME>