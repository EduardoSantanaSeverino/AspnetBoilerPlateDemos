# **AspnetBoilerPlate**

Welcome everyone, today we are going to talk about AspnetBoilerPlate,

We are going to do a quick demo for the backend APIs using C# , Entity Framework and Application Service.

---

# Previous Introduction Video

It should be already published another video where I go on:

- Who is this for? On the Backend and the Frontend.
- Quick features Features that you can find On the Backend and Frontend.
- Link in the video description.

---

# Quick Overview

- Quick overview, let s have a quick look at what we are doing, this is the application running Demo of the backend api and swagger application.

Here you have my Rider IDE, I can click on the solution explorer, and see the different projects. Remember this is Domain Driven Design.

Let's see the entity model that I just created for this demo. You can see the Student entity class.

After, let's try to run the application, where I can see the swagger application.

and I can see the new entity.

- ***

# What are we doing?

- Download the AspnetBoilerPlate
- Update the project to use PostgreSQL
  - go to entity framework folder:
  - dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.3
  - Delete Microsoft.EntityFrameworkCore.SqlServer from \*.EntityFrameworkCore project because it will not be used anymore.
  - replace the content of the file: DbContextConfigurer
  - update the UseSqlServer with UseNpgsql
  - add the AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true); to the Start Up
  - add the OnModelCreating to the datacontext and add the reference.
  - Also add those to the context constructor:
    - System.AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    - System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
- Migrate the PostgreSQL database
  - Remove all migration files under /\*.EntityFrameworkCore/Migrations folder. (include DbContextModelSnapshot)
  - dotnet ef migrations add InitialMigration -> this goes under EntityFramework project.
  - dotnet ef database update > this goes under EntityFramework project.
- Disable Background Jobs
  - to disable those you only need to add the line to the Module of your host app:
  - public override void PreInitialize()
  - {
  -     Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
  - }
- Disable SignalR Service
  - SignalR is used by several features like Chat and Real Time Notifications. You need to comment out those features (their html contents in your app). You also need to comment out SignalR in Startup.cs and client side SignalRHelper.ts. also remove the nuget package.
  1. we disabled on the dotnet project on the startup class and module.
  2. on the angular on the init project.
- Create a new Entity and Add it to DBcontext
  let s show in the screen the entity model to be created.
- Add the Application Service
  we will
- Check Swagger Endpoint
- Test the CRUD functionality

---

# Links

- https://aspnetboilerplate.com/Pages/Documents/EF-Core-Oracle-Integration
- https://aspnetboilerplate.com/Pages/Documents/EF-Core-PostgreSql-Integration
- https://aspnetboilerplate.com/Pages/Documents/Background-Jobs-And-Workers
- https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations#opting-out-of-the-new-timestamp-mapping-logic
- https://aspnetboilerplate.com/Pages/Documents/SignalR-AspNetCore-Integration
- https://support.aspnetzero.com/QA/Questions/10869/Disable-SignalR
