# Dr. Silly Stringz Factory

#### By: Jase Grable

## Description

Dr. Silly Stringz Factory is an MVC web app that manages a list of engineers and machines, and specifies which engineers are allowed to operate what machines. It demonstrates proficiency in database migrations and many-to-many relationships.

## Technologies Used

- C#
- .NET6 SDK
- ASP.NET Core MVC
- EF Core
- SQL
- HTML
- CSS
- Markdown
- Razor

## Setup

_Note: You will need to have the following installed locally before you can run this application:_

- _.NET6_
- _MySQL_
- _MySQL Workbench_
- _VS Code_

1. In the terminal run these commands in order:

- `$ git clone https://github.com/JaseGrable/DrSillyStringz.Solution.git`
- `cd DrSillyStringz.Solution`
- `$ touch .gitignore` 2. copy/paste this into the .gitignore file:
- obj
- bin
- appsettings.json
- .DS_Store (if on a Mac)

3. Navigate to this project's production directory called "Factory" with `$ cd Factory`.
4. Within the production directory run the command `$ touch appsettings.json`.
5. In the appsettings.json file, paste in the following code, replacing [user-id] and [password] with your username and password for MySQL Workbench. (Remember to remove the square brackets when inputting your details):
   {
   `"ConnectionStrings": {
   "DefaultConnection": "Server=localhost;Port=3306;database=factory;uid=[user-id];pwd=[password];"
   }
   }``
6. Within the production directory "Factory", run `$ dotnet ef database update` to instantiate the database.
7. Still within the production directory, run `$ dotnet watch run` in the command line to launch the application in development mode in a browser, and interact with the application.

## Known Bugs

- When Adding Machine to Engineer or Engineer to Machine, there is a routing error currently.

## MIT License

Copyright (c) 2023 Jase Grable
