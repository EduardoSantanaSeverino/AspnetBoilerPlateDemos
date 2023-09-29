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
  - dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.11
- Disable Background Jobs
- Disable SignalR Service
- Migrate the PostgreSQL database
- Create a new Entity and Add it to DBcontext
- Add the Application Service
- Check Swagger Endpoint
- Test the CRUD functionality

---

# Links

- https://aspnetboilerplate.com/Pages/Documents/EF-Core-Oracle-Integration
- https://aspnetboilerplate.com/Pages/Documents/EF-Core-PostgreSql-Integration
- https://aspnetboilerplate.com/Pages/Documents/Background-Jobs-And-Workers
