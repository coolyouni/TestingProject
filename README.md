# Haibooks Automation Testing Project

## Project Overview

This project is designed to automate the functional testing of the Haibooks web application. The tests are written in C# using the Selenium WebDriver and NUnit frameworks. The project follows the Page Object Model (POM) design pattern to ensure a clear separation between test scripts and the underlying page structure, making tests more maintainable and scalable.

## Technology Stack

- **Programming Language:** C#
- **Automation Framework:** Selenium WebDriver
- **Test Framework:** NUnit
- **Build Tool:** .NET CLI / Visual Studio
- **BDD Framework:** SpecFlow (Pending)
- **Test Data:** Excel (using interop office excel file)
- **Other Tools:** Docker (for containerized test execution), Git (for version control)

## Project Structure

The project is organized into the following directories:

HaibooksAutomationForWeb/
│
├── src/
│ ├── main/
│ │ ├── CSharp/
│ │ │ └── Haibooks/
│ │ │ ├── Pages/
│ │ │ │ ├── LoginPage.cs
│ │ │ │ ├── DashboardPage.cs
│ │ │ │ └── ...
│ │ │ ├── Tests/
│ │ │ │ ├── LoginTests.cs
│ │ │ │ ├── DashboardTests.cs
│ │ │ │ └── ...
│ │ │ ├── Utilities/
│ │ │ │ ├── ExcelReader.cs
│ │ │ │ └── ...
│ │ │ └── Constants/
│ │ │ ├── Config.cs
│ │ │ └── Paths.cs
│ │ └── resources/
│ │ └── datadriven_haibooks.xlsx
│ └── test/
│ └── HaibooksAutomationForWeb.Tests.csproj


Running the Tests
Prerequisites
Ensure you have the following installed:
.NET SDK
NUnit Console Runner
ChromeDriver (or another WebDriver)
Restore the project dependencies using the following command:
dotnet restore
Running Tests
You can run the tests using the NUnit Console Runner or directly from Visual Studio:

Using NUnit Console Runner:

nunit3-console HaibooksAutomationForWeb.Tests.dll
Using Visual Studio:
Open the solution in Visual Studio and run the tests via the Test Explorer.

Data-Driven Testing
This project uses Excel files for data-driven testing. The ExcelReader.cs utility class is responsible for reading test data from the Excel file located in the resources/ directory.

Example: Reading Data from Excel
Excel Reading:

The Excel file is opened using xlApp.Workbooks.Open(Constants.ExcelPathForDataDriven);.
The specific cells are accessed using xlRange.Cells[row, column].Value2.ToString();.
I included exception handling (try-catch-finally) to ensure that resources are properly released, even if an exception occurs.
COM Object Release:

The Marshal.ReleaseComObject is used to properly release COM objects, preventing memory leaks and ensuring the Excel process exits cleanly.
Error Handling:

A COMException is caught, and a message is printed to the console to aid in debugging if something goes wrong during file access.
