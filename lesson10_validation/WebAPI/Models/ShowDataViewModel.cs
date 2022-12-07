using System.ComponentModel.DataAnnotations;

namespace lesson10_validation.Models
{
    public class ShowDataViewModel
    {
        [Required]
        public string Text { get; set; }

        [Range(1, 2022)]
        public int Year { get; set; }

        [Required]
        public bool? Approval { get; set; }
    }
}
