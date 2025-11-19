using System.ComponentModel.DataAnnotations;

namespace UnitConverter.Models
{
    public class ConversionModel
    {
        [Required]
        public double Value { get; set; }

        [Required]
        public string FromUnit { get; set; } = string.Empty;

        [Required]
        public string ToUnit { get; set; } = string.Empty;

        public double Result { get; set; }

        public bool ShowResult { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
