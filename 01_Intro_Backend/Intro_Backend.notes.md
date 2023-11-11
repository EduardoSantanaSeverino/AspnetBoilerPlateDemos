Part 1 - The Brief

In this video I am gonna share with you a brief introduction to a top of the line dotnet rapid application framework to help you to your boost productivity and save time on delivering your next dotnet web application. Also, keep in mind this is going to be a super simple introduction video where you will get a clear idea to decide if this is best for you.

Part 2 - The Intro Who Am I?

Hey, this is Eduardo Santana here, bit about myself, I have been doing software development for many years now, and also, as professor I get to see how many students struggling to create their new web applications. I see how new programmers trying to put so much time creating repetitive code that you will have do over and over in every new web application.

And because of this, I wanted to created a series of videos that will give you a clear path for creating your new dotnet web application but using the AspnetBoilerPlate framework.

First we are going to talk about who is framework for? does it work for you? and secondly we are talking about some most important time saving features that this framework is offering you.

Part 3 - Content?
Deliver the Content or presentation

Part 4 - Optional Bonus
Over-deliver

Party 5 - Call to Action
What they are going to do next?
After this video there will be a coming video about the demonstration on how to create your new project using this framework.
And also, how automatically generate some boiler plate. so stick around and If you finding value in this video, give it a thumbs-up. It really makes a huge difference.

# AspnetBoilerPlate

Welcome everyone, this is an introduction video to talk about what is AspnetBoilerPlate, who is it for

and this video is for someone who is new to AspnetBoilerPlate, just introduction to the framework.

Let get into it.

---

AspnetBoilerPlate

It is an Open source and well really well-documented application framework.

which is not just a framework, it also provides a strong architectural model based on Domain Driven Design or DDD, with it all the best practices in mind.

Moving on lets have a quick view.

https://aspnetboilerplate.com/

---

# Quick View

- Let's do a quick search in google chrome, and discover a tiny little bit of AspnetBoilerPlate. We can see it is really popular, I know should be others things out there, but AspnetBoilerPlate has worked for me.

And I wanted to introduce some of the best youtube video tutorials that I have found so far.

We can see there from: Lee Richardson some very good demonstration videos. on me tab 2 and 3.

So, moving on, lets talk about who is this for, is this framework for you?

---

# Who is this for? On the Backend? - 1

- This Framework AspnetBoilerPlate is for someone who is looking for a Rapid Application Development and for someone who is well familiar with C# programming language and Dotnet framework for the Backend for those a rest APIs that you need for your application.
- We can see that we are currently in the version 8 of the AspnetBoilerPlate at this very moment.. This version number 8 is using:

  - dotnet 7
  - Entity Framework 7 - (https://learn.microsoft.com/en-us/ef/core/providers)
    and we all know how powerful the entiyframework is, for example we see that it support all major databases, like:

    - Azure SQL, SQLite, Memory DB, Cosmos DB, PostgreSQL, MySQL, Oracle, and some many others, you see the link there with more details about.
      Meaning that you can use this AspnetBoilerPlate with any database of those mentioned before. as long as the entity framework supports it, then aspnetboilerplate supports it.

Let's move on the next slide

---

# Who is this for? On the Backend? - 2

- This version 8 is using Automapper 12 for Automatic Dto mappings.
- Quick note: a AspnetBoilerPlate a couple of years ago was migrated away from Castle Windsor as Dependency Injection framework. You remember that Castle Windsor was very popular Dependency Injection framework back in the days. It is not longer any more in AspnetBoilerPlate. Moving on.
- It is following Domain Driven Design for an organized application, also following only the best practices for Object Oriented Design principles and of course using SOLID principles as well.

Moving, lets talk about features for the backend.

---

# Features? On the Backend? - 1

One of the most important features is that you it will save you time with a lot of repetitive task that you have to do on a normal regular application. Let s call it boiler plate code that you have to create for every application, And one example of this is creating a repository for one Entity Model in C#:

For example with this Framework in place, out of the box you will get generic Repository for a new Entity Model in the sense that you can do something like: IRepository<EntityTask>, and it just worked, and of course it all is using Unit Of Work under the hood.

Another time saving feature is on the Authorization and Authentication, by default the framework you will have, login, register, user, role and tenant management pages.

For example you don't have to create the login page, it will give it to you out of the box.

Let's talk about Multi-Tenancy, hey many of those applications that you create is going to use some kind of Multi-Tenancy. For example when it comes to one costumer of your application, having access to his own files, so only the owner of the data can see its own information, that s the most simple form of Multi-Tenancy.

And it is out of the box for you in AspnetBoilerPlate.

It is automatically applied with Entity Framework Filters to separate each tenant information in every request to the database.

---

# Features? On the Backend? - 2

You can use Caching Service out of the box to cache any Entity information coming from the database, by the way the default Caching Service is In Memory Cache Service but you can update it to use redis.

Another thing that you have is Data filters out of the box, something like soft delete, the soft delete is an amazing feature. it is there automatically applied for you.

You have Multi Language out of the box, and very important Audit Logging, this AuditLogin will log: the User information, the browser name or description, the IP address, the calling service and method and parameters, calling time, execution duration and some other information is automatically saved for each request.

But in conclusion this Framework will give you Many Many more features that'll help you to create a new maintainable application with ease.

So, moving on, lets talk about one example of the documentation.

---

# Features? On the Backend? Example

Very important to mention that AspnetBoilerPlate it has an amazing documentation on its website and the guys at AspnetBoilerPlate, they make a very good job when it comes to keep it updated, also the community. there is a very big community out there writing documentation for this framework.

Let see this website: click the link:

https://aspnetboilerplate.com/Pages/Documents/Introduction

and change camera angle.

We can see this a quick sample application with the task entity model.

We have a Application Service for the Task Entity, which have a generic Repository with Dependency Injection being injected there.

Also, we have the declarative Permissions in there, and we have input Dto as an input variable.

We quickly add a log line with into our logger object,

We then check if the task entity exist in the database, if is not, then throw an exception.

on the contrary We then map the input to a entity, so later we can use the update methods in the repository to update our entity model object.

And again all of this is using Unit Of Work.

Let's Scroll down a little bit here. . .

where we can see one by one some of the features on the template and you can click and go one by one to learn more.

For example lets click on repository.

We can see with details some documentation on how to use the default repositories.

Let's change camera again.

And move on the next slide.

So, I just want to conclude here, and invite you to download the demo template and try it yourself.

and that is going to be all for this video. thank you.

also stay tune because the next video will be about the Instruction for the Front End using this template.

Subscribe to the a notification for next video.

---

# Links

- https://www.google.com/search?q=AspnetBoilerPlate&rlz=1C5MACD_enCA1046CA1046&oq=AspnetBoilerPlate&aqs=chrome..69i57j69i59j69i65j69i60l3j69i65l2.1460j0j1&sourceid=chrome&ie=UTF-8#ip=1
- https://www.youtube.com/watch?v=fboRUsd00N8&list=PLEqIq664dDRZ1ObTGKwkwUrrj5mT4pmv2
- https://www.youtube.com/watch?v=4hIh8FUlTA0&list=PLsNclT2aHJcM6nvhvvijXI_WdUXPvgf28

If you finding value in this video, give it a thumbs-up. It really makes a huge difference.
