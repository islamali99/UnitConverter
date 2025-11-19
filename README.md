# Unit Converter Web Application

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp)
![License](https://img.shields.io/badge/license-MIT-blue)

A professional, modern web application built with ASP.NET Core MVC that converts between different units of measurement. Features a beautiful, responsive UI with smooth animations and an intuitive user experience.

## 🌟 Features

- **Length Converter**: Convert between millimeter, centimeter, meter, kilometer, inch, foot, yard, and mile
- **Weight Converter**: Convert between milligram, gram, kilogram, ounce, and pound
- **Temperature Converter**: Convert between Celsius, Fahrenheit, and Kelvin
- **Modern UI**: Professional gradient design with smooth animations
- **Responsive**: Works seamlessly on desktop, tablet, and mobile devices
- **Real-time Conversion**: Server-side calculations with instant results
- **No Database Required**: Lightweight and fast

## 🚀 Live Demo

🔗 [View Live Application](https://unitconverter.onrender.com)

## 📸 Screenshots

### Home Page
Beautiful card-based interface for selecting conversion types

### Conversion Pages
Clean, intuitive forms with gradient styling and smooth interactions

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core 8.0 (C#)
- **Frontend**: Razor Pages, HTML5, CSS3
- **Architecture**: MVC (Model-View-Controller)
- **Deployment**: Render.com / Fly.io

## 📋 Prerequisites

- .NET 8.0 SDK or later
- A code editor (Visual Studio, VS Code, or Rider)

## 💻 Installation & Setup

1. **Clone the repository:**
```bash
git clone https://github.com/islamali99/UnitConverter.git
cd UnitConverter
```

2. **Restore dependencies:**
```bash
dotnet restore
```

3. **Build the project:**
```bash
dotnet build
```

## 🎯 Running the Application

### Development Mode
```bash
dotnet run
```

### Development with Hot Reload
```bash
dotnet watch run
```

Open your browser and navigate to:
- **HTTP**: http://localhost:5000
- **HTTPS**: https://localhost:5001

## 📖 Usage

1. From the home page, select the type of conversion (Length, Weight, or Temperature)
2. Enter the value you want to convert
3. Select the unit to convert from (defaults are pre-selected)
4. Select the unit to convert to
5. Click the **Convert** button
6. View the converted result displayed below the form

## 📁 Project Structure

```
UnitConverter/
├── Program.cs                  # Application entry point & configuration
├── UnitConverter.csproj        # Project file
├── Dockerfile                  # Docker configuration for deployment
├── render.yaml                 # Render.com deployment config
├── Controllers/
│   └── HomeController.cs       # Main controller with conversion logic
├── Models/
│   └── ConversionModel.cs      # Model for form data and results
├── Views/
│   ├── _ViewImports.cshtml     # Global view imports
│   ├── _ViewStart.cshtml       # View start configuration
│   ├── Shared/
│   │   └── _Layout.cshtml      # Shared layout template
│   └── Home/
│       ├── Index.cshtml        # Home page with conversion options
│       ├── Length.cshtml       # Length conversion page
│       ├── Weight.cshtml       # Weight conversion page
│       └── Temperature.cshtml  # Temperature conversion page
└── wwwroot/
    └── css/
        └── style.css           # Professional styling with animations
```

## 🚢 Deployment

This application can be deployed to various platforms:

### Render.com (Free Tier)
```bash
# Already configured with render.yaml
# Just connect your GitHub repo to Render
```

### Fly.io (Free Tier)
```bash
# Install Fly CLI
brew install flyctl

# Login and launch
flyctl auth login
flyctl launch
```

### Azure App Service
```bash
az webapp up --name your-app-name --runtime "DOTNET|8.0"
```

## 🔧 Conversion Formulas

### Length
All conversions go through meters as the base unit:
- 1 meter = 1000 millimeters
- 1 meter = 100 centimeters  
- 1 meter = 0.001 kilometers
- 1 meter = 39.3701 inches
- 1 meter = 3.28084 feet
- 1 meter = 1.09361 yards
- 1 meter = 0.000621371 miles

### Weight
All conversions go through grams as the base unit:
- 1 gram = 1000 milligrams
- 1 gram = 0.001 kilograms
- 1 gram = 0.035274 ounces
- 1 gram = 0.00220462 pounds

### Temperature
- **Celsius to Fahrenheit**: (C × 9/5) + 32
- **Celsius to Kelvin**: C + 273.15
- **Fahrenheit to Celsius**: (F - 32) × 5/9

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

## 👨‍💻 Author

**Islam Ali**
- GitHub: [@islamali99](https://github.com/islamali99)

## 🙏 Acknowledgments

- Built with ASP.NET Core MVC
- Inspired by the need for a simple, elegant unit converter
- Modern UI design principles

---

⭐ **Star this repo if you find it helpful!**
