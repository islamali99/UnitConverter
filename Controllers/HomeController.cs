using UnitConverter.Models;
using UnitConverter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;

namespace UnitConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly VisitorTrackingService _visitorTracking;

        public HomeController(IStringLocalizer<HomeController> localizer, VisitorTrackingService visitorTracking)
        {
            _localizer = localizer;
            _visitorTracking = visitorTracking;
        }

        private void TrackVisitor()
        {
            var sessionId = HttpContext.Session.Id;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Visited")))
            {
                _visitorTracking.RecordVisit(sessionId);
                HttpContext.Session.SetString("Visited", "true");
            }
            else
            {
                _visitorTracking.UpdateActivity(sessionId);
            }
        }

        [HttpGet]
        public IActionResult GetStatistics()
        {
            var stats = _visitorTracking.GetStatistics();
            return Json(new { totalVisits = stats.TotalVisits, activeUsers = stats.ActiveUsers });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Index()
        {
            TrackVisitor();
            return View();
        }

        [HttpGet]
        public IActionResult Length()
        {
            TrackVisitor();
            return View();
        }

        [HttpPost]
        public IActionResult Length(ConversionModel model)
        {
            TrackVisitor();
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
            TrackVisitor();
            return View();
        }

        [HttpPost]
        public IActionResult Weight(ConversionModel model)
        {
            TrackVisitor();
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
            TrackVisitor();
            return View();
        }

        [HttpPost]
        public IActionResult Temperature(ConversionModel model)
        {
            TrackVisitor();
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
