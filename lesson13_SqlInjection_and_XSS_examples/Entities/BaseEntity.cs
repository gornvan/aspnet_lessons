using System.ComponentModel.DataAnnotations.Schema;

namespace lesson13_Security.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
