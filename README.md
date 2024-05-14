
<h1 align="center">
    <img alt="dotnetcore" title="#NAVATESTE" src="https://miro.medium.com/v2/resize:fit:705/1*OiVr2f63kbvC4xKCB_z-mw.png" width="650px" />
</h1>

<h4 align="center"> 
	 IO Route! 🚀 Done! 
</h4>
<p align="center">
  <img alt="GitHub language count" src="https://img.shields.io/github/languages/count/leozeracode/IORoute?color=%2304D361">

  <img alt="Repository size" src="https://img.shields.io/github/repo-size/leozeracode/IORoute">
	
  <a href="https://www.linkedin.com/in/leonardo-rviana/">
    <img alt="Made by Leonardo Viana" src="https://img.shields.io/badge/made%20by-LeonardoViana-%2304D361">
  </a>

  <a href="https://github.com/leozeracode/IORoute/commits/master">
    <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/leozeracode/IORoute">
  </a>

  <img alt="License" src="https://img.shields.io/badge/license-MIT-brightgreen">
   <a href="https://github.com/leozeracode/IORoute/stargazers">
    <img alt="Stargazers" src="https://img.shields.io/github/stars/leozeracode/IORoute?style=social">
  </a>
</p>

## Overview

IORoute is a project developed in .NET Core for finding the cheapest route between two locations.

## :rocket: Technologies

- [.NET Core](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.npgsql.org/efcore/index.html)
- [xUnit](https://xunit.net/)
- [Moq](https://github.com/Moq/moq4)

## Development Setup

To set up the development environment, follow these steps:

1. Clone this repository.
2. Open the solution in Visual Studio or your preferred IDE.
3. Make sure you have an instance of PostgreSQL running.
4. Update the connection string in the `appsettings.json` file to match your PostgreSQL instance.
5. Run the Entity Framework Core migrations to create the database schema:

## Development Setup

To set up the development environment, follow these steps:

1. **Clone this repository:** 


```bash
 $ git clone https://github.com/leozeracode/IORoute

```

2. **Navigate to the project folder:**

 ```bash
$ cd IORoute
```

3. **Open the solution in Visual Studio or your preferred IDE.**

4. **Ensure PostgreSQL is running and update connection string:**
   - Make sure you have an instance of PostgreSQL running.
   - Update the connection string in the appsettings.json file to match your PostgreSQL instance.
  
5. **Run Entity Framework Core migrations:**
 ```bash
$ dotnet ef database update
```

6. **Run the application:**
 ```bash
$ dotnet run --project IORoute.API
```

The API will start running on https://localhost:5000.

## Running Tests

1. **Navigate to the test project folder:**
 ```bash
$ cd IORoute.Test
```

2. **Run the tests:**
 ```bash
$ dotnet test
```

This will execute all unit tests in the project.
