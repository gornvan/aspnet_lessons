using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
    }
}
