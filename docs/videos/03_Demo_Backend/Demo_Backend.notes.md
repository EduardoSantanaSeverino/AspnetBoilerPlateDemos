---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://aspnetboilerplate.com/img/backgrounds/6.jpg')
marp: true
---

# Demo Backend

In this video I am gonna share with you a quick demonstration for ASP.NET Boilerplate using PostgreSQL, C#, Entity Framework Swagger API.

---

# Previous Introduction Video

In the previous video we've been talking about ASP.NET Boilerplate. We talked about:

- Who is this for? On the Backend?
- Features? On the Backend?
- Who is this for? On the Frontend?
- Features? On the Frontend?
- Why do you need NSwag?

If you have not watch those videos, I strongly suggest you to go over and watch those, so you get a better idea of what we are doing in this video.

Moving on. when it comes to the technologies, it is important that we set the grounds.

---

# Technology / Topics

For you to follow along it is better that you are familiar with the following technologies, but it is not a requirement, because I am going be explaining what you need to follow along.

- MS SQL Server or PostgreSQL
- EntityFramework
- Swagger
- C# Class, Interface, Inheritance, DI
- Docker Container
- No going through each file in the template

---

# What are we doing? - 1

We are following the next steps, for:

1. Start the PostgreSQL container
2. Quick Overview of the Backend
3. Download the ASP.NET Boilerplate
4. Update the project to use PostgreSQL
5. Migrate the PostgreSQL database
6. Disable Background Jobs

---

# What are we doing? - 2

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
  Quick overview, let s have a quick look at what we are doing, this is the application running Demo of the backend api and swagger application.
  Here you have my Rider IDE, I can click on the solution explorer, and see the different projects. Remember this is Domain Driven Design.
  Let's see the entity model that I just created for this demo. You can see the Student entity class.
  After, let's try to run the application, where I can see the swagger application.
  and I can see the new entity.

---

# Follow Step 3:

- Download the AspnetBoilerPlate:

  - Go to `https://aspnetboilerplate.com/Templates`.
  - Add your project name, mine is: `MyCollegeV1`.
  - Click on Create my project to download.

---

# Follow Step 4:

- Update the project to use PostgreSQL:

  - Go to entity framework folder, `cd source/MyCollegeV1/aspnet-core/src/MyCollegeV1.EntityFrameworkCore`.
  - Run command: `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.3`.
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

  - Remove all migration files under `/\*.EntityFrameworkCore/Migrations` folder. (include `DbContextModelSnapshot`).
  - `dotnet ef migrations add InitialMigration` -> this goes under EntityFramework project.
  - `dotnet ef database update` -> this goes under EntityFramework project.

---

# Follow Step 6:

- Disable Background Jobs:

  To disable those you only need to add the line to the Module of your host app:
  public override void PreInitialize()

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
