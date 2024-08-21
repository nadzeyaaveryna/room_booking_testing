# Room Booking System Test Automation Framework

This document provides an overview of the test automation framework (TAF) developed for the room booking system. It outlines the structure, tools used, modules descriptions, and instructions on how to run the code.

## Structure Overview

The codebase is organized into multiple projects, each serving a specific purpose within the test automation framework for the room booking system. The key projects are:

- **BookingRoom.API**: Contains API controllers for handling room bookings, room reports, and base API functionalities. Includes response models for room and room reports.
- **BookingRoom.Core**: Provides the core functionalities, including business objects for persons, rooms, and time slots, configuration settings, utility functions, and logging mechanisms.
- **BookingRoom.TAF**: The main test automation framework project, containing feature files for BDD scenarios, step definitions for mapping the steps in feature files to C# methods, and support utilities like screenshot helpers.
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
- **Features (`BookingRoom.TAF/Features`)**: Contains Gherkin feature files defining BDD scenarios for testing the room booking system.
- **Step Definitions (`BookingRoom.TAF/StepDefinitions`)**: Implements step definitions for the steps outlined in the feature files, binding them to actual test code.
- **UI Pages (`BookingRoom.UI/Pages`)**: Implements the Page Object Model (POM) pattern for UI elements, facilitating easier UI test automation.

## How to Run the Code

1. Ensure you have .NET Core SDK installed on your machine.
2. Open the solution file `BookingRoom.TAF/BookingRoom.TAF.sln` in Visual Studio or another compatible IDE.
3. Restore NuGet packages to resolve all dependencies.
4. Build the solution to ensure everything compiles correctly.
5. To run the tests, navigate to the Test Explorer in your IDE and run all or select specific tests to execute.
