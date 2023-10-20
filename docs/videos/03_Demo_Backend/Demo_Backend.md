---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://aspnetboilerplate.com/img/backgrounds/6.jpg')
marp: true
---

# Demo Backend

Demonstration of ASP.NET Boilerplate with PostgreSQL, EntityFramework and Swagger API.

https://aspnetboilerplate.com/

---

# Previous Introduction Video

- On the Backend, who is this for?
- Features on the Backend.
- On the Frontend, who is this for?
- Features on the Frontend.
- Why do you need NSwag?

---

# Technology / Topics

- MS SQL Server or PostgreSQL
- EntityFramework
- Swagger
- C# Class, Interface, Inheritance, Dependency Injection
- Docker Container

---

# What are we doing?

1. Start the PostgreSQL container
2. Quick Overview of the Backend
3. Download the ASP.NET Boilerplate
4. Update the project to use PostgreSQL
5. Migrate the PostgreSQL database
6. Disable Background Jobs

---

# What are we doing? - Continue...

7. Disable SignalR Service
8. Create a new Entity and Add it to DBcontext
9. Add the Application Service
10. Check Swagger Endpoint
11. Test the CRUD functionality

---

# Follow Step 1:

- Start the PostgreSQL container:

  - Show the `scripts/db/docker-compose.yml` file.
  - Start the `docker-compose` file.
  - show docker container.

---

# Follow Step 2:

- Quick Overview of the Backend project.

Outcome preview: `MyCollegeV1` vs `MyCollegeV2`.

---

# Follow Step 3:

- Download the AspnetBoilerPlate:

  - Go to `https://aspnetboilerplate.com/Templates`.
  - Add your project name, mine is: `MyCollegeV1`.
  - Click on Create my project to download.

---

# Follow Step 4:

- Update the project to use PostgreSQL:

  - Go to entity framework folder, `cd source/MyCollegeV1/aspnet-core/src/MyCollegeV1.EntityFrameworkCore`
  - Run command: `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.3`
  - Delete `Microsoft.EntityFrameworkCore.SqlServer` from `*.EntityFrameworkCore` project, because it will not be used anymore.
  - Replace the content of the file: `DbContextConfigurer`.
  - Update the `UseSqlServer` with `UseNpgsql` in file `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.EntityFrameworkCore/EntityFrameworkCore/MyCollegeV1DbContextConfigurer.cs`.
  - Add the `AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true)`; to the Start Up.
  - Add the `OnModelCreating` to the datacontext and add reference to top of the file.
  - Also add those to the context constructor:
    - `System.AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);`.
    - `System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);`.

---

# Follow Step 5:

- Migrate the PostgreSQL database:

  - Remove all migration files under `/*.EntityFrameworkCore/Migrations` folder. (include `DbContextModelSnapshot`).
  - `dotnet ef migrations add InitialMigration` -> this goes under EntityFramework project.
  - `dotnet ef database update` -> this goes under EntityFramework project.

---

# Follow Step 6:

- Disable Background Jobs:

  To disable those you only need to add the line to the Module of your host app:
  `public override void PreInitialize()`

  ```csharp
  {
      Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
  }
  ```

---

# Follow Step 7:

- Disable SignalR Service:

  SignalR is used by several features like Chat and Real Time Notifications.
  You need to comment out those features (their `html` contents in your app).
  You also need to comment out `SignalR` in `Startup.cs` and client side `SignalRHelper.ts`.
  Remove the nuget package.

  1. We disabled on the dotnet project on the startup class and module.
  2. On the angular on the init project.

---

# Follow Step 8:

- Create a new Entity and Add it to DBcontext:
  - Let s show in the screen the entity model to be created.

---

# Follow Step 9:

- Add the Application Service:

---

# Follow Step 10:

- Check Swagger Endpoint:

---

# Follow Step 11:

- Test the CRUD functionality:

---

# Links

- https://aspnetboilerplate.com/Pages/Documents/EF-Core-Oracle-Integration
- https://aspnetboilerplate.com/Pages/Documents/EF-Core-PostgreSql-Integration
- https://aspnetboilerplate.com/Pages/Documents/Background-Jobs-And-Workers
- https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations#opting-out-of-the-new-timestamp-mapping-logic
- https://aspnetboilerplate.com/Pages/Documents/SignalR-AspNetCore-Integration
- https://support.aspnetzero.com/QA/Questions/10869/Disable-SignalR
