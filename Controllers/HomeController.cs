using UnitConverter.Models;
using Microsoft.AspNetCore.Mvc;

namespace UnitConverter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Length()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Length(ConversionModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Result = ConvertLength(model.Value, model.FromUnit, model.ToUnit);
                    model.ShowResult = true;
                }
                catch (Exception ex)
                {
                    model.ErrorMessage = $"Error: {ex.Message}";
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Weight()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Weight(ConversionModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Result = ConvertWeight(model.Value, model.FromUnit, model.ToUnit);
                    model.ShowResult = true;
                }
                catch (Exception ex)
                {
                    model.ErrorMessage = $"Error: {ex.Message}";
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Temperature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Temperature(ConversionModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Result = ConvertTemperature(model.Value, model.FromUnit, model.ToUnit);
                    model.ShowResult = true;
                }
                catch (Exception ex)
                {
                    model.ErrorMessage = $"Error: {ex.Message}";
                }
            }
            return View(model);
        }

        private double ConvertLength(double value, string fromUnit, string toUnit)
        {
            // Convert to meters first
            var toMeters = new Dictionary<string, double>
            {
                { "millimeter", 0.001 },
                { "centimeter", 0.01 },
                { "meter", 1 },
                { "kilometer", 1000 },
                { "inch", 0.0254 },
                { "foot", 0.3048 },
                { "yard", 0.9144 },
                { "mile", 1609.34 }
            };

            double meters = value * toMeters[fromUnit];
            double result = meters / toMeters[toUnit];
            return result;
        }

        private double ConvertWeight(double value, string fromUnit, string toUnit)
        {
            // Convert to grams first
            var toGrams = new Dictionary<string, double>
            {
                { "milligram", 0.001 },
                { "gram", 1 },
                { "kilogram", 1000 },
                { "ounce", 28.3495 },
                { "pound", 453.592 }
            };

            double grams = value * toGrams[fromUnit];
            double result = grams / toGrams[toUnit];
            return result;
        }

        private double ConvertTemperature(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit)
                return value;

            // Convert to Celsius first
            double celsius;
            if (fromUnit == "Fahrenheit")
                celsius = (value - 32) * 5 / 9;
            else if (fromUnit == "Kelvin")
                celsius = value - 273.15;
            else
                celsius = value;

            // Convert from Celsius to target unit
            if (toUnit == "Fahrenheit")
                return celsius * 9 / 5 + 32;
            else if (toUnit == "Kelvin")
                return celsius + 273.15;
            else
                return celsius;
        }
    }
}
