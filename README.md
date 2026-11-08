# SmileDent

A Windows Forms dental clinic management application developed as an individual course project using C#, .NET 10, and Microsoft SQL Server.

## Overview

SmileDent is a desktop application designed to support basic dental clinic operations. It combines a user-facing interface with database functionality, allowing users to register, log in, explore clinic information, make appointments, and manage their reservations.

The application was developed using Windows Forms, with C# handling the application logic and Microsoft SQL Server storing application data.

## Key Features

- **User Authentication:** Login and registration functionality.
- **Clinic Information:** Main page presenting the clinic and its dental services.
- **Appointment Booking:** Create reservations by selecting services and appointment details.
- **Appointment Management:** View, add, edit, and delete existing appointments.
- **Patient Information:** Enter patient details, including allergy information.
- **Priority Reservations:** Option to request priority appointments.
- **Reservation Reports:** View saved appointment information.
- **Contact Form:** Submit messages through the application's contact section.
- **Form Validation:** Input validation and feedback for user interactions.

## Technologies Used

- **C#** – Application logic and functionality
- **.NET 10** – Application framework
- **Windows Forms** – Desktop user interface
- **Microsoft SQL Server** – Database management
- **ADO.NET / System.Data.SqlClient** – Database connectivity, where configured in the project

## Application Structure

The application is organized around Windows Forms and their associated C# code files, with configuration and resource files supporting the interface and database connection.

## Database Configuration

SmileDent uses Microsoft SQL Server for storing application information.

The current database connection is configured in `App.config`:

```xml
<connectionStrings>
    <add name="SmileDentDB"
         connectionString="Data Source=LH\SQLEXPRESS;Initial Catalog=SmileDentDB;Integrated Security=True"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

The connection string currently references a local SQL Server instance. To run the application on another computer, the connection string must be updated to match the installed SQL Server instance, and the `SmileDentDB` database must be available.

## Getting Started

### Prerequisites

- Windows
- Visual Studio with the .NET desktop development workload
- .NET 10 SDK
- Microsoft SQL Server

### Setup

1. Clone or download this repository.
2. Open `SmileDent.slnx` in Visual Studio.
3. Make sure the required .NET 10 components are installed.
4. Configure the SQL Server connection in `App.config`.
5. Ensure the `SmileDentDB` database is available on your SQL Server instance.
6. Build and run the application.

## My Role

This was an individual course project. I was responsible for developing the application structure and interface, implementing user authentication and appointment functionality, connecting the application to SQL Server, and building the forms and database operations.

## What I Learned

Through this project, I gained practical experience with C#, Windows Forms, .NET, SQL Server, database connectivity, user authentication, input validation, and CRUD operations. I also strengthened my understanding of how desktop applications interact with relational databases.

## Project Information

- **Project:** SmileDent
- **Type:** Individual Course Project
- **Category:** Desktop Application Development
- **Framework:** .NET 10
- **Language:** C#
- **Database:** Microsoft SQL Server

---

**Project Type:** Course Project  
**Developer:** Luljeta Hoti