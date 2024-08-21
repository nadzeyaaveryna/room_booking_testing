# room_booking_testing
Test automation framework for booking the room task using .NET

# Project Overview

This project is a comprehensive .NET test automation solution, designed to streamline the testing process and improve software quality. Our solution leverages various tools and technologies to provide a robust framework for automated testing.

# Prerequisites

Before you can run the code, ensure you have the following installed on your system:

- .NET SDK: The project requires .NET 5.0 SDK installed. You can download it from [here](https://dotnet.microsoft.com/download/dotnet/5.0).
- Node.js: To run Playwright tests, Node.js (latest stable version) is required. Download Node.js from [here](https://nodejs.org/en/download/).
- Playwright: After installing Node.js, install Playwright by running `npm install playwright` in your CLI.

# How to Run the Code Using CLI

1. **Clone the Repository:** Clone the repository to your local machine.
2. **Navigate to the Project Directory:** Open a command line interface (CLI) and navigate to the project directory.
3. **Restore Dependencies:** Run `dotnet restore` to restore all the dependencies. This step ensures that all the necessary .NET packages are available.
4. **Build the Project:** Build the project by executing `dotnet build`. This compiles the source code and prepares it for execution.
5. **Run Tests:** To run the .NET tests, use `dotnet test`. This command will execute all the tests defined in the project according to the configurations.

For running tests that require Playwright:
- Ensure Playwright is installed by running `npm install playwright` if you haven't done so already.
- Navigate to the directory containing the Playwright tests and execute the tests using `npx playwright test`.

These instructions offer a step-by-step guide for running the project using command line interfaces, facilitating users who either do not have access to Visual Studio or prefer CLI tools for their operations.