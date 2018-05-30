using System.ComponentModel.DataAnnotations;

namespace APICalculator.Models
{
    public class CalculationModel
    {
        [Required]
        public decimal X { get; set; }

        [Required]
        public decimal Y { get; set; }
    }
}
