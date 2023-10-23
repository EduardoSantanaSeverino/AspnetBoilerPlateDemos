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

# Backend Features

- Authorization and Authentication
- Audit Logs
- Generic Repositories
- SignalR (Next video)
- Background Jobs (Next video)
- Multi-Tenancy (Next video)

---

# What are we doing?

1. Start the PostgreSQL container
2. Quick Overview of the Backend
3. Download the ASP.NET Boilerplate
4. Update the project to use PostgreSQL
5. Migrate the PostgreSQL database
6. Disable Background Jobs feature

---

# What are we doing? - Continue...

7. Disable SignalR feature
8. Disable Multi-Tenancy feature
9. Create a new Entity and Add it to DBcontext
10. Add the Application Service
11. Check Swagger Endpoint
12. Test the CRUD functionality
13. BONUS - Show Audit logs and Generic Repository.

---

# Follow Step 1:

- Start the PostgreSQL container:

  - Show the `scripts/db/docker-compose.yml` file.
  - Start the `docker-compose` file.
  - show docker container.

---

# Follow Step 2:

- Quick Overview of the Backend project.

  - Outcome preview: `MyCollegeV1` vs `MyCollegeV2`.
  - Insert Entity:

  ```json
  {
    "firstName": "Logan",
    "lastName": "Kim",
    "address": "941 Progress Ave, Scarborough, Ontario, Canada",
    "programName": "Game Programming",
    "doB": "1991-04-10",
    "isActive": true
  }
  ```

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

- Disable Background Jobs feature:

  - To disable those you only need to add the line to the Module of your host app:
    `public override void PreInitialize()`

    ```csharp
    {
        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
    }
    ```

  - More info: `https://aspnetboilerplate.com/Pages/Documents/Background-Jobs-And-Workers`.

---

# Follow Step 7:

- Disable SignalR feature:

  - In file: `source/MyCollegeV1/angular/src/app/app.component.ts`:
    - Comment out the `import { SignalRAspNetCoreHelper } from '@shared/helpers/SignalRAspNetCoreHelper';` line.
    - Inside `ngOnInit()` function, comment out: `SignalRAspNetCoreHelper.initSignalR();` line.
  - In file: `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Web.Core/MyCollegeV1.Web.Core.csproj`:
    - Comment out the `<PackageReference Include="Abp.AspNetCore.SignalR" Version="8.1.0" />` line.
  - In file: `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Web.Core/MyCollegeV1WebCoreModule.cs`:
    - Comment out the `using Abp.AspNetCore.SignalR;` line.
    - Comment out the `typeof(AbpAspNetCoreSignalRModule)` line.
  - In file: `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Web.Host/Startup/Startup.cs:`:
    - Comment out the `using Abp.AspNetCore.SignalR.Hubs;` line.
    - Comment out the `services.AddSignalR();` line.
    - Comment out the `endpoints.MapHub<AbpCommonHub>("/signalr");` line.
  - More info: `https://aspnetboilerplate.com/Pages/Documents/SignalR-AspNetCore-Integration`.

---

# Follow Step 8:

- Disable Multi Tenancy feature:

  - In file: `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Core/MyCollegeV1Consts.cs` Set the `public const bool MultiTenancyEnabled = true;` line to `public const bool MultiTenancyEnabled = false;`.
  - More info: `https://aspnetboilerplate.com/Pages/Documents/Multi-Tenancy`.

---

# Follow Step 9:

- Create a new Entity and Add it to DBcontext:
  - Take the Entity file from: `source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Core/Models/Student.cs` and copy into: `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Core/Models/Student.cs`.
  - Add the New Student Entity to your data context file: `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.EntityFrameworkCore/EntityFrameworkCore/MyCollegeV1DbContext.cs`.
    - Add this: `public virtual DbSet<Student> Students { get; set; }`.

---

# Follow Step 10:

- Add the Application Service:
  - Take files in folder: `source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students` and put it into: `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students`.
  - Add permissions to file: `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Core/Authorization/MyCollegeV1AuthorizationProvider.cs`.
  - Check the core module of your application.

---

# Follow Step 11:

- Check Swagger Endpoint:

---

# Follow Step 12:

- Test the CRUD functionality:

---

# Follow Step 13:

- BONUS - Show Audit logs
  - Show file `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Web.Host/App_Data/Logs/Logs.txt`.
  - Show Table in database.
- BONUS - Show Generic Repository.
  - Copy custom additional methods from the `source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students/StudentAppService.cs`.
  - See how it looks in the Swagger.

---

# Thank you

- Next videos:
  - Hands On Frontend Angular and the Student Entity.
  - Automatically Generating the Backend and Frontend code.
- Like & Subscribe

---

# Links

- https://aspnetboilerplate.com/Pages/Documents/EF-Core-Oracle-Integration
- https://aspnetboilerplate.com/Pages/Documents/EF-Core-PostgreSql-Integration
- https://aspnetboilerplate.com/Pages/Documents/Background-Jobs-And-Workers
- https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations#opting-out-of-the-new-timestamp-mapping-logic
- https://aspnetboilerplate.com/Pages/Documents/SignalR-AspNetCore-Integration
- https://aspnetboilerplate.com/Pages/Documents/Multi-Tenancy
- https://aspnetboilerplate.com/Pages/Documents/Object-To-Object-Mapping
