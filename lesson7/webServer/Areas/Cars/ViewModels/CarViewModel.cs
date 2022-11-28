using System.ComponentModel.DataAnnotations;

namespace webServer.Areas.Cars.ViewModels
{
    public class CarViewModel
    {
        [Required]
        public string? Make { get; set; }

        [Required]
        public int MakeYear { get; set; }

        public virtual List<long>? TireIds { get; set; }
    }
}
