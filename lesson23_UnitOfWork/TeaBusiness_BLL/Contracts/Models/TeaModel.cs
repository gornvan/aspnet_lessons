namespace TeaBusiness_BLL.Contracts.Models
{
    public class TeaModel : EntityBase<long>
    {
        public string Name { get; set; }

        public virtual IEnumerable<StorageModel> StoragesStoring { get; set; }
    }
}
