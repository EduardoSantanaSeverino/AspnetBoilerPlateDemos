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

# Follow the next steps:

- Follow the next steps...
- Using `Command` + `P` on Mac shortcut.
- Using `Control` + `P` on Windows shortcut.

---

# 1. Start the PostgreSQL container:

- Show the `scripts/db/docker-compose.yml` file.
- Start the `docker-compose` file.
- show docker container.

---

# 2. Quick Overview of the Backend project.

- Outcome preview: `MyCollegeV1` vs `MyCollegeV2`.
- Using Rider IDE for the Backend (`MyCollegeV2`).
- Solution explorer, using Domain Driven Design.
- Entity Model for this demo at: `src/MyCollegeV2.Core/Models/Student.cs`.
- With Service Class at: `src/MyCollegeV2.Application/Students/StudentAppService.cs`.
- See the service in swagger, `GetAll` Students.
- Insert Entity in swagger:

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

# 3. Download the AspnetBoilerPlate:

- Go to `https://aspnetboilerplate.com/Templates`.
- Add your project name, mine is: `MyCollegeV1`.
- Click on Create my project to download.

---

# 4. Update the project to use PostgreSQL:

- Open solution `source/MyCollegeV1/aspnet-core/MyCollegeV1.sln` project, in your code editor, for me Rider, In terminal change directory to: `cd source/MyCollegeV1/aspnet-core`.
- In terminal change directory to: `cd src/MyCollegeV1.EntityFrameworkCore`.
  - Run command: `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.3`.
- Delete `Microsoft.EntityFrameworkCore.SqlServer` from `MyCollegeV1.EntityFrameworkCore` project, because it will not be used anymore.
  - In Rider: Unload Project, then Edit project file and remove `<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.3" />` line.
- Open file: `src/MyCollegeV1.EntityFrameworkCore/EntityFrameworkCore/MyCollegeV1DbContextConfigurer.cs`, replace `UseSqlServer` with `UseNpgsql`.
- Remove all migration files under `/MyCollegeV1.EntityFrameworkCore/Migrations` folder. (include `DbContextModelSnapshot`).
- Open file `src/MyCollegeV1.EntityFrameworkCore/EntityFrameworkCore/MyCollegeV1DbContext.cs`, add the `OnModelCreating` to the `MyCollegeV1DbContext` class.

  ```csharp
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Abp.Localization.ApplicationLanguageText>()
          .Property(p => p.Value)
          .HasMaxLength(100); // any integer that is smaller than 10485760
  }
  ```

- Open file: `src/MyCollegeV1.Web.Host/Startup/MyCollegeV1WebHostModule.cs`, add the `PreInitialize` to the `MyCollegeV1WebHostModule` class.

  ```csharp
  public override void PreInitialize()
  {
      System.AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
      System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
      // https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations
  }
  ```

- Compile the project:
  - In Rider: click `Top Menu` > `Build` > `Build Solution`.

---

# 5. Migrate the PostgreSQL database:

- Open file: `src/MyCollegeV1.Web.Host/appsettings.json`, update the Connection String to your liking, for me: `"User ID=postgres;Password=iJ55BNHuSDCrV5TBR;Host=192.168.22.101;Port=5432;Database=MyCollegeDB_V1;Pooling=true;"`.
- In terminal change directory to: `cd src/MyCollegeV1.EntityFrameworkCore`.
  - `dotnet ef migrations add InitialMigration` -> this goes under EntityFramework project.
  - `dotnet ef database update` -> this goes under EntityFramework project.

---

# 6. Disable Background Jobs feature:

- To disable those you only need to add the line to the Module of your host app, open file: `src/MyCollegeV1.Web.Host/Startup/MyCollegeV1WebHostModule.cs`, update or add the `PreInitialize` method of the `MyCollegeV1WebHostModule` class, code below:

  ```csharp
  public override void PreInitialize()
  {
      Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
      System.AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true); // From previous steps...
      System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // From previous steps...
      // https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations
  }
  ```

- More info: `https://aspnetboilerplate.com/Pages/Documents/Background-Jobs-And-Workers`.

---

# 7. Disable SignalR feature:

Note: SignalR is used by several features like Chat and Real Time Notifications. We are not going to used it for the moment, therefore commenting out the line of code that we dont need.

- Open file: `src/MyCollegeV1.Web.Core/MyCollegeV1.Web.Core.csproj`:
  - Comment out the `<PackageReference Include="Abp.AspNetCore.SignalR" Version="8.1.0" />` line.
- Open file: `src/MyCollegeV1.Web.Core/MyCollegeV1WebCoreModule.cs`:
  - Comment out the `using Abp.AspNetCore.SignalR;` line.
  - Comment out the `typeof(AbpAspNetCoreSignalRModule)` line.
- Open file: `src/MyCollegeV1.Web.Host/Startup/Startup.cs:`:
  - Comment out the `using Abp.AspNetCore.SignalR.Hubs;` line.
  - Comment out the `services.AddSignalR();` line.
  - Comment out the `endpoints.MapHub<AbpCommonHub>("/signalr");` line.
- Compile the project:
  - In Rider: click `Top Menu` > `Build` > `Build Solution`.
- ONLY for Frontend - Open file: `source/MyCollegeV1/angular/src/app/app.component.ts`:
  - Comment out the `import { SignalRAspNetCoreHelper } from '@shared/helpers/SignalRAspNetCoreHelper';` line.
  - Inside `ngOnInit()` function, comment out: `SignalRAspNetCoreHelper.initSignalR();` line.
- More info: `https://aspnetboilerplate.com/Pages/Documents/SignalR-AspNetCore-Integration`.

---

# 8. Disable Multi Tenancy feature:

- Open file: `src/MyCollegeV1.Core/MyCollegeV1Consts.cs` Set the `public const bool MultiTenancyEnabled = true;` line to `public const bool MultiTenancyEnabled = false;`.
- More info: `https://aspnetboilerplate.com/Pages/Documents/Multi-Tenancy`.

---

# 9. Create a new Entity and Add it to DBcontext:

- Create Entity as per sample code below into: `src/MyCollegeV1.Core/Models/Student.cs`.
- `Student` entity sample code:

  ```csharp
  using System;
  using System.Collections.Generic;
  using System.Text;
  using Abp.Domain.Entities;
  using Abp.Domain.Entities.Auditing;

  namespace MyCollegeV1.Models
  {
      public class Student : FullAuditedEntity<int>, IPassivable
      {
          public Student()
          {
              this.IsActive = true;
              this.CreationTime = DateTime.Now;
          }
          public string FirstName { get; set; }

          public string LastName { get; set; }

          public string Address { get; set; }

          public string ProgramName { get; set; }

          public string DoB { get; set; }

          public bool IsActive { get; set; }

      }
  }
  ```

- Open file: `src/MyCollegeV1.EntityFrameworkCore/EntityFrameworkCore/MyCollegeV1DbContext.cs`, Add the New Student Entity Collection to your data context (`MyCollegeV1DbContext`) class.

  - Add this: `public virtual DbSet<Student> Students { get; set; }`.

- In terminal change directory to: `cd src/MyCollegeV1.EntityFrameworkCore`.
  - `dotnet ef migrations add AddStudentEntity` -> this goes under EntityFramework project.
  - `dotnet ef database update` -> this goes under EntityFramework project.

---

# 10. Add the Application Service:

- Take files in folder: `source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students` and put it into: `source/MyCollegeV1/aspnet-core/src/MyCollegeV1.Application/Students`.

- Update the Namespace from: `MyCollegeV2` to `MyCollegeV1`.

- For me, I created the script to copy those file: located in: `scripts/source/app-service-copy-v1.sh`.

- Open file: `src/MyCollegeV1.Core/Authorization/PermissionNames.cs`, below the other constants add student constant, add `public const string Pages_Students = "Pages.Students";`.

- Open file: `src/MyCollegeV1.Core/Authorization/MyCollegeV1AuthorizationProvider.cs`, below the other permissions, add permissions:

  - Add: `context.CreatePermission(PermissionNames.Pages_Students, L("Students"));` below.

- Check the core module of your application, file: `src/MyCollegeV1.Core/MyCollegeV1CoreModule.cs`, in there probably remove the following line as it is not needed: `Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));`.

---

# 11. Check Swagger Endpoint:

- Run the host project.

---

# 12. Test the CRUD functionality:

- Test the get all student method.

- Insert Entity in swagger:

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

- Test with permissions:

  - Stop the host project.
  - Open file: `src/MyCollegeV1.Application/Students/StudentAppService.cs`, uncomment the permission on the top of the `StudentAppService` class: `[AbpAuthorize(PermissionNames.Pages_Students)]`.
  - Re-Run the host project again.

- Login in swagger:
  - use the username as: `admin` and password as: `123qwe`.

---

# 13. BONUS - Show Audit logs and Generic Repository.

- BONUS -Show Audit logs
  - Show file `src/MyCollegeV1.Web.Host/App_Data/Logs/Logs.txt`.
  - Show Table in database.
- BONUS - Show Generic Repository.
  - Copy custom additional methods from the `source/MyCollegeV2/aspnet-core/src/MyCollegeV2.Application/Students/StudentAppServiceV2.cs`.
  - For me, I created the script to copy those file: located in: `scripts/source/app-service-copy-v2.sh`.
  - See how it looks in the Swagger.
  - We should see the new methods:
    - `GetMyCustomListAsync`, `CreateMyCustomStudentV1`, `CreateMyCustomStudentV2`,
    - Note that the object `_studentRepository` and `Repository` are referring to same object. So you could use one or the other as preference. One is coming from Base class and other other from our own class.

---

# Thank you

- Next videos:
  - Hands-on Frontend Angular and the Student Entity.
  - Automatically Generating the Backend and Frontend code.
- Like & Subscribe

---

# Links

- https://aspnetboilerplate.com/Pages/Documents/EF-Core-Oracle-Integration
- https://aspnetboilerplate.com/Pages/Documents/EF-Core-PostgreSql-Integration
- https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations#opting-out-of-the-new-timestamp-mapping-logic
- https://aspnetboilerplate.com/Pages/Documents/Background-Jobs-And-Workers
- https://aspnetboilerplate.com/Pages/Documents/SignalR-AspNetCore-Integration
- https://aspnetboilerplate.com/Pages/Documents/Multi-Tenancy
- https://aspnetboilerplate.com/Pages/Documents/Object-To-Object-Mapping
