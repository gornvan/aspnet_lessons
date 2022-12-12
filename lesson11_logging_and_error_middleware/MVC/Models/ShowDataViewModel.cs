using System.ComponentModel.DataAnnotations;

namespace lesson11_serilog.Models
{
    public class ShowDataViewModel
    {
        [Required]
        public string Text { get; set; }

        public int Year { get; set; }

        [Required]
        public bool? Approval { get; set; }
    }
}
