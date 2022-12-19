using System.ComponentModel.DataAnnotations;

namespace lesson13_Security.Entities
{
    public class Car : BaseEntity
    {
        [Required]
        public string? Make { get; set; }

        [Required]
        public int MakeYear { get; set; }

        public virtual List<Tire> Tires { get; set; } = new List<Tire>();
    }
}