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

- On the Backend, who is this for?
- Features on the Backend.
- On the Frontend, who is this for?
- Features on the Frontend.
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

# Backend Features

Because this Template will give you so much functionality out of the box, it is recommended that you disabled that ones that are not going to be used in your particular application. For sake of simplicity of the video, I will just focus on getting up and running.

- We are using in this video the default Authorization and Authentication
- The default Audit Logs will shown in as bonus.
- And the Generic Repositories will be shown as well.
- But we are leaving for future videos details on the SignalR, Background Jobs and Multi-Tenancy.

---

# What are we doing? - 1

We are following the next steps, for:

1. Start the PostgreSQL container

- Important to mention, we are doing PostgreSQL because is we are just avoiding using MS SQL Server.

2. Quick Overview of the Backend

- We are showing what is the expectation of our testing today. the project up a running.

3. Download the ASP.NET Boilerplate
4. Update the project to use PostgreSQL
5. Migrate the PostgreSQL database
6. Disable Background Jobs, we are not going to use it in this video.

Next slide:

---

# What are we doing? - 2

7. Disable SignalR feature, we are not going to use it in this video.
8. Disable Multi-Tenancy feature, we are not going to use it in this video.
9. Create a new Entity and Add it to DBcontext.
10. Add the Application Service, so we can add logic to our application.
11. Check Swagger Endpoint.
12. Test the CRUD functionality.

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

  - Remove all migration files under `/*.EntityFrameworkCore/Migrations` folder. (include `DbContextModelSnapshot`).
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

- Disable SignalR:

SignalR is used by several features like Chat and Real Time Notifications. we are not going to used a chat for the moment, therefore commenting out the line of code that we dont need.

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

I want to leave this video there.

The next video I am going to show you one Angular application and the Student Entity with permissions applied.

And after, I m going to you, how to generate the code for a new Entity Class using a code generator.

If you finding value in this video, please give it a thumbs-up. and subscribe to get notifications for the next video.

See you in the next one.

---

# Links

- https://aspnetboilerplate.com/Pages/Documents/EF-Core-Oracle-Integration
- https://aspnetboilerplate.com/Pages/Documents/EF-Core-PostgreSql-Integration
- https://aspnetboilerplate.com/Pages/Documents/Background-Jobs-And-Workers
- https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations#opting-out-of-the-new-timestamp-mapping-logic
- https://aspnetboilerplate.com/Pages/Documents/SignalR-AspNetCore-Integration
- https://aspnetboilerplate.com/Pages/Documents/Multi-Tenancy
- https://aspnetboilerplate.com/Pages/Documents/Object-To-Object-Mapping
