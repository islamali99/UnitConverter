# Unit Converter Web Application (.NET)

A simple web application built with ASP.NET Core MVC that converts between different units of measurement including length, weight, and temperature.

## Features

- **Length Converter**: Convert between millimeter, centimeter, meter, kilometer, inch, foot, yard, and mile
- **Weight Converter**: Convert between milligram, gram, kilogram, ounce, and pound
- **Temperature Converter**: Convert between Celsius, Fahrenheit, and Kelvin

## Prerequisites

- .NET 8.0 SDK or later
- A code editor (Visual Studio, VS Code, or Rider)

## Installation

1. Make sure you have .NET 8.0 SDK installed. Check by running:
```bash
dotnet --version
```

2. Navigate to the project directory:
```bash
cd /Users/mac/UnitConverter
```

## Running the Application

1. Restore dependencies and build the project:
```bash
dotnet build
```

2. Run the application:
```bash
dotnet run
```

3. Open your web browser and go to:
```
http://localhost:5000
```
or
```
https://localhost:5001
```

## Usage

1. From the home page, select the type of conversion you want to perform (Length, Weight, or Temperature)
2. Enter the value you want to convert
3. Select the unit to convert from
4. Select the unit to convert to
5. Click the "Convert" button
6. The converted value will be displayed on the same page

## Project Structure

```
UnitConverter/
├── Program.cs              # Application entry point and configuration
├── UnitConverter.csproj    # Project file
├── Controllers/
│   └── HomeController.cs   # Main controller with conversion logic
├── Models/
│   └── ConversionModel.cs  # Model for form data and results
├── Views/
│   ├── _ViewImports.cshtml # Global view imports
│   ├── _ViewStart.cshtml   # View start configuration
│   ├── Shared/
│   │   └── _Layout.cshtml  # Shared layout template
│   └── Home/
│       ├── Index.cshtml    # Home page
│       ├── Length.cshtml   # Length conversion page
│       ├── Weight.cshtml   # Weight conversion page
│       └── Temperature.cshtml # Temperature conversion page
└── wwwroot/
    └── css/
        └── style.css       # Stylesheet for the web pages
```

## Technologies Used

- **Backend**: ASP.NET Core 8.0 MVC
- **Frontend**: Razor Pages, HTML5, CSS3
- **No database required** - All calculations are done server-side

## Development

To run in development mode with hot reload:
```bash
dotnet watch run
```
