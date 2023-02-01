namespace TeaBusiness_BLL.Contracts.Models
{
    public class StorageModel : EntityBase<long>
    {
        public string Name { get; set; }

        public virtual IEnumerable<TeaModel> TeasStored { get; set; }
    }
}
