# ASP.NET Core CMS(Content Management System)

This is a simple Content Management System created using ASP.NET Core and Entity Framework Core with Multi-Layered architecture.

## How to run this Project

- Download this Project
- Open this Project in Visual Studio 2022 (Make sure .NET 7 SDK is installed)
- Click on `Build Solution` in Visual Studio 2022 so that all the nuget packages gets installed/restored.
- Modified the SQL Server Database Connection String in appSettings.json
- Execute `Update-Database` EF Core Migration command to get the database created in SQL Server
- Run the application by pressing F5

## Login Details for this Project

- UserName: `test`
- Password: `TEST@#123`

## EF Core Seeding

The `CoreCMSContext` class will seed test/dummy data for sidebar, pages, user and roles using the overridden `OnModelCreating()` method.

![](https://i.imgur.com/EyjYLCg.jpeg)

![](https://i.imgur.com/kdmoLnr.jpeg)

## Project Details

- Multi-Layered Architecture
- Separate projects for Data, Model, Services and Web
- Managing package dependencies using Nuget
- Using Models and ViewModels(DTOs)
- Using EF Core Code-First for Data Access
- EF Core Code-First Migration
- Managing service dependencies using IoC and DI
- Using EF Core Eager Loading for loading related data
- CMS Features: Pages, Sidebars and Navigation bar
- Using RichTextEditor for Pages and Sidebars
- Using Areas for PagesController and SidebarsController
- Creating ViewComponents to display Navigation and Sidebar in Layout file
- Using ASP.NET Core Identity for Register, Login and Logout functionality
- Restricting permissions & functionality to admin role users only using Authroize attribute

## Project Feature Snapshots

![](https://i.imgur.com/igOxvPF.jpeg)

![](https://i.imgur.com/cvSMtoe.jpeg)

![](https://i.imgur.com/wftkjxA.jpeg)

![](https://i.imgur.com/ucs0mnl.jpeg)

![](https://i.imgur.com/aKbXFGy.jpeg)

![](https://i.imgur.com/W9dC89c.jpeg)

![](https://i.imgur.com/r9lzkq2.jpeg)

![](https://i.imgur.com/fhgiUzy.jpeg)