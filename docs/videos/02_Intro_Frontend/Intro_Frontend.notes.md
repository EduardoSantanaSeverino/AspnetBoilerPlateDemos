In this video I am gonna share with you a brief introduction to AspnetBoilerPlate framework but this time around we gonna look at the Frontend side of things.
In the past video we looked at the APIs and Backend side of the framework. On the contrary, now I am going to be talking about Angular that the frontend implementation.

Hey, this is Eduardo Santana here, I have been doing software development for many years now, and I wanted to create this series of videos to help you, if you are a student or a new software developer, who is looking to create a new web application and you want to follow a clear path to follow the best practices of object oriented programming.

The main idea is for you to use this AspnetBoilerPlate framework as a start up point for your new web application which will give you the best practices and will save you time on boiler plate code.

Because at the end of the day, in every application there are some repetitive task that you have to do over and over again. and This Framework will give you solid start up point that you can rely on.

In this specific video we gonna talk about:

First, who is this framework for on the frontend? does it work for you? and after we are gonna talk about some of the most relevant time saving features that this framework is offering.

Now, lets move on to Who is this for?

---

# Who is this for? On the Frontend?

When it comes to the Frontend, the AspnetBoilerPlate, is for someone who is looking for Rapid Application Development, but more important for someone who is familiar on the Angular ecosystem.

This framework will give you the option to download a complete project which will have the login page, tenant page, multi-tenancy page and users and roles management pages.

So, lets go and see the download page, so we can see the different options there:

https://aspnetboilerplate.com/Templates

Go to the Site and read there.

The Template Version:
Target Framework Version:
Download:

Going back to our presentation, we can see that on the current AspnetBoilerPlate framework is using:

- Angular15+
- NSwag 13 (https://github.com/RicoSuter/NSwag)
- TypeScript 4.8
- Jasmine 4.5

and some on so fort:

Now, let's see the different features.

---

# Features? On the Frontend?

When it comes to the most relevant Frontend features, we have:

- Token-Based Authentication with Jwt Token functionality which will be it to you by default in the template.
- You gonna have as well the Angular Multi-Tenancy management pages provided by the framework.
- Multi-Language Support with angular localize pipe that is right there for you.
- And finally, you gonna have Proxy Service with Static Data Types generated by NSwag.

I personally think the most relevant and useful feature is this last one, and that is why, I wanted to talk about this one in the next slide.

---

# Why do we need NSwag?...

Let me start by saying, In a normal JavaScript web application we need some sort of access the backend APIs in some way.

Most of the time we do use HTTP request to access the backend information.

and for those HTTP request we mostly go for using libraries like Axios or we could just go for vanilla JavaScript XMLHttpRequest class.

In Angular, on the contrary we want to use angular http library, but we want to create a Proxy Service class that will hold, that will contain all the backend communication related stuff in there.

So we are going to use a TypeScript Proxy Service, that will expose the backend APIs as methods in the TypeScript Proxy Service,

And we are going to see what it means in couple of seconds.

Again in your Angular code you will have ProxyService class which allows you to do HTTP request and you will get access to the Backend APIs information.

EXPLAIN THE FIGURE: .......

How is it going to work? how do you create this ProxyService with static DataTypes?

that are coming from the Backend, 1 you can do it Manually create your DTOs and so on. or you can use Nswag.

Let s look at the figure next slide:

---

# Why do we need NSwag? in Angular code.

So, this Proxy Service will be generated automatically for you by NSwag,

The way it works is that NSwag will take your Swagger url and from there it will take the Open API specifications, and then it is going to generate your TypeScript Proxy Service for your application.

And you can find more information about the Nswag functionality in the Github page and how ti generate the Proxy Service by going to the github page.

I m going to leave the link in the video description.

Let go back to the presentation.

---

# Frontend Example

It is very easy to get up up and running with a complete angular application when you download the template, Let s go to the example page, and so you can see how easy it is to start the new application.

- https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Angular

Lets go to see the page: DEMO the page...

After the demo. . .

# Thank you

I want to leave this video there.

The next video I am going to show you the backend up and running and will create a new Swagger API, using PostgreSQL database and EntityFramework.

After that in another video I m gonna show one Angular application and the Student Entity with permissions applied.

And finally, I m going to you, how to generate the code for a new Entity Class using a code generator.

If you finding value in this video, please give it a thumbs-up. and subscribe to get notifications for the next video.

See you next time.
