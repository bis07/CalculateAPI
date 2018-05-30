using System.ComponentModel.DataAnnotations;

namespace APICalculator.Models
{
    public class CalculationModel
    {
        [Required]
        public double X { get; set; }

        [Required]
        public double Y { get; set; }
    }
}
