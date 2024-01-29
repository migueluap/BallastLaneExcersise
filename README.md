<img src="https://avatars.githubusercontent.com/u/445896?v=4" alt="BallastLane Project">

# BallasLane Technical Excercise

The Project is a open-source project written in .NET Core

## User Stories

- US1: As an online store owner, I want to Read (view) my customers so that I can review what is currently active on my site

  - Tasks:
    - Create DB table
    - Populate the table with a few sample data
    - Create select DB script
    - Create for viewing my customers
    - Create automated functional tests for viewing functionality

- US2: As an online store owner, I want to Register / Update a customer so that I can save information about their preference for products

  - Tasks:
    - Create insert / update DB script
    - Create UI for create / update a customer
    - Create automated functional tests for adding customer functionality
    - Create automated functional tests for updating customer functionality

- US3: As an online store owner, I want to Delete a customer so that I can maintain only active users
  - Tasks:
    - Create delete DB operation
    - Create UI for deleting a customer
    - Create automated functional tests for the delete functionality

## Design System

## Technologies implemented:

- ASP.NET 6.0
- ASP.NET MVC Core
- ASP.NET WebApi Core with JWT Bearer Authentication
- ASP.NET Identity Core
- Entity Framework Core 6.0
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI with JWT support

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository

## How to use:

- You will need the latest Visual Studio 2022 and the latest .NET Core SDK 6.0.
- The SDK and tools can be downloaded from https://dot.net/core.

Also you can run the BallasLane Project in Visual Studio Code (Windows, Linux or MacOS).

## How to run using docker:

## Disclaimer:

- **NOT** pretend to be an optimal solution, this project implementation applies **over-engineering** for a simple CRUD because the goal is to demonstrate knowledge about the technologies and architecture software.
