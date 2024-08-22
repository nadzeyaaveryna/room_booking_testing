# Room Booking System Test Automation Framework

This document provides an overview of the test automation framework (TAF) developed for the room booking system. It outlines the structure, tools used, modules descriptions, and instructions on how to run the code.

## Structure Overview

The codebase is organized into multiple projects, each serving a specific purpose within the test automation framework for the room booking system. The key projects are:

- **BookingRoom.API**: Contains API controllers for handling room bookings, room reports, and base API functionalities. Includes response models for room and room reports.
- **BookingRoom.Core**: Provides the core functionalities, including business objects for persons, rooms, and time slots, configuration settings, utility functions, and logging mechanisms.
- **BookingRoom.Tests**: The main test automation framework project, containing feature files for BDD scenarios, step definitions for mapping the steps in feature files to C# methods, and support utilities like screenshot helpers.
- **BookingRoom.UI**: Contains the UI drivers and helpers required for UI test automation, including browser factory, waiting helpers, and page object models for various pages and components in the UI.


## Tools Used in the Solution

The solution utilizes several tools and libraries, including but not limited to:

- **SpecFlow**: Used for writing and executing BDD-style tests, as seen in the `.feature` files and their corresponding step definitions.
- **Playwright**: Utilized within the `BookingRoom.UI` project for browser automation and interactions in UI tests.
- **NLog**: A logging library used in the `BookingRoom.Core` project for logging purposes.


## Modules Description

- **API Controllers (`BookingRoom.API/ApiControllers`)**: Handles HTTP requests and responses for room booking and reporting functionalities.
- **Business Objects (`BookingRoom.Core/BusinessObjects`)**: Defines the core entities like `Person`, `Room`, and `TimeSlot`, along with their management logic.
- **Configuration (`BookingRoom.Core/Configuration`)**: Manages application configuration settings.
- **Utils (`BookingRoom.Core/Utils`)**: Provides utility functions including date/time helpers, enum helpers, string generation helpers, and a test context helper for managing test execution context.
- **Features (`BookingRoom.Tests/Features`)**: Contains Gherkin feature files defining BDD scenarios for testing the room booking system.
- **Step Definitions (`BookingRoom.Tests/StepDefinitions`)**: Implements step definitions for the steps outlined in the feature files, binding them to actual test code.
- **UI Pages (`BookingRoom.UI/Pages`)**: Implements the Page Object Model (POM) pattern for UI elements, facilitating easier UI test automation.

#### Tests Configuration

Development configuration for test env is in: [BookingRoom.Core/appsettings.json]

#### How to execute tests 

## Prerequisites 

- `.NET SDK`: Make sure you have the .NET SDK installed. You can download it from https://dotnet.microsoft.com/download.
- Visual Studio, VS Code or .NET CLI (.NET CLI is included with the .NET SDK).

## Test Execution

1. Open Terminal/CMD: Open a terminal or command prompt and navigate to project directory located in [`../room_booking_testing/BookingRoom.TAF`].

2 Restore Dependencies using command:

dotnet restore

3. Build the Project using command:

dotnet build

4. Install Playwright browsers using PowerShell command: 

pwsh BookingRoom.TAF/bin/Debug/net6.0/playwright.ps1 install

5. Execute Tests:
1.
dotnet test

This command will discover and run all the tests in your project.