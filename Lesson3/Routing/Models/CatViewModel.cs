using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Routing.Models
{
    public class CatViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int BirthYear { get; set; }
    }
}
