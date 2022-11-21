
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace webapi.Models
{
    public class WeatherQueryModel
    {
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}
