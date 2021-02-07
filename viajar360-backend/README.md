
# Rest Api Viajar 360 

ASP.NET Core 5.0 - REST API for Viajar 360 Content Managment System, Authentication Registration and Forum

More info at https://github.com/classroomEntreRios/proyecto-g1b-proyecto-g1b

## Migrations
First: Install the tool (CLI) 

    dotnet tool install --global dotnet-ef

**for the DataContext (SQL Server Express)**

Build  an Initial migration 

    dotnet ef migrations add InitialCreate --context DataContext -o Migrations/SqlServerMigrations

drop database 

    dotnet ef database drop --context DataContext

update database 

    dotnet ef database update --context DataContext

**for the SqliteDataContext (Sqlite)**

build Initial migration

    dotnet ef migrations add InitialCreate --context SqliteDataContext -o Migrations/SqliteMigrations

drop database

    dotnet ef database drop --context SqliteDataContext

update database

    dotnet ef database update --context SqliteDataContext

## For the SQL Server connections strings...
First with ***SQL MANAGER*** Enable TCP/IP and open port **1433** under **"IP Addresses"** tab **"IPALL"** 
also with ***SSMS*** create the new user under Security->Logins  with server roles **public** and **sysadmin**

**Important**: In server properties->Security->Server Authentication set option **"SQL Server and Windows Authentication mode"**

check **"ConnectionStrings"** sections in ***appsettings.json*** and ***appsettings.Development.json***
files for example 

    "Viajar360Database": "Data Source=tcp:127.0.0.1,1433;Initial Catalog=fullstack2;User ID=**tuusuario**;Password=**tuclave**;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

**Important**: Tip ***Initial Catalog*** refers to the database name for the *InitialCreate* migration.

## For SqlLite connection...
Uncomment and/or use a single local file in *Development Mode*
for example

    "Viajar360Database": "Data Source=LocalDatabase.db"

Regards!
Aníbal.-

***Note**: Make a shortcut for SQL Manager if refuses to start the path in Win 10 64bits is*

     C:\Windows\SysWOW64\SQLServerManager15.msc


