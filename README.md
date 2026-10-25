# LetsGoLetsGetJacked
## Description
LetsGoLetsGetJacked is a web application that helps users track their workouts. Users can create workout sessions, in which they can see on which date they did it, what exercises they had done and the weight and reps for each set of their workout.

## Features
- User registration and login
- Create, View, Edit and Delete exercises
- Create Workout sessions
- Record weight and reps for each set
- View workout history
- Private Workout sessions for each user
- Form validation

## Technologies
- C#
- ASP.NET Core MVC
- Razor Views
- Entity Framework Core
- Microsoft SQL Server LocalDB
- ASP.NET Core Identity
- Bootstrap

## Requirements
- Visual Studio 2022 or newer
- .NET SDK compatible with the project
- SQL Server LocalDB
- ASP.NET and web development workload

## Installation and Setup
1. Download the repository.
2. Open the solution in Visual Studio.
3. Check the database connection string in 'appsettings.json'.
4. Open the Package Manager Console in Visual Studio.
5. Run 'Update-Database' to create or update the database.
6. Run the application from Visual Studio.

## Usage
1. Register a new accout or log in.
2. Browse the available exercises or create a new one.
3. Create a workout session.
4. Add exercises and enter the weight, reps and sets.
5. Track your sessions and trainings splits.

## Authentication and Privacy
This web application uses ASP.NET Core Identity for registration and login. Each user can access their own workout sessions, keeping their data separate from other users.

## Project structure
- 'Areas/Identity' - Contains the authentication pages.
- 'Controllers' - Handles application requests and actions.
- 'Data' - Contains the database context.
- 'Data/Migrations' - Contains Entity Framework Core database migrations.
- 'Models' - Contains the application data models.
- 'Views' - Contains the Razor Views.
- 'appsettings.json' - Contains application configuration.
- 'Program.cs' - Configures application services and request pipeline.

## Author
Created as an ASP.NET Core Fundamentals project.
