# SimpleStore
This project was started for our 'Web Development' college class. It uses .Net Core 3.1, ReactJS 16 & Boostrap 4.1.3, and was created using the [.Net Core & React template proyect](https://docs.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-3.1), which means that both the backend & frontend servers run in parallel. For database control, we used the EntityFrameworkCore 3.1.8 ORM in a Code-First modality, which means that the database is declared first in models and then created & updated via automatic migrations.

# Setup
Follow this guide to get the proyect working locally on your machine in a couple of minutes.

## Database Connection

The project has no connection strings, which means that EntityFramework will use Visual Studio's **included** SQLServer instance as its database engine by default. If you want to connect to the database from your SQLServerManagementStudio, you can use the following server names coupled with the default Windows Authentication:
- ****Visual Studio 2012**:**
> (localdb)\v11.0
- ****>= Visual Studio 2015**:**
> (localdb)\MSSQLLocalDB