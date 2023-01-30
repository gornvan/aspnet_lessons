using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_DAL.EntityConfigurations
{
    internal class StorageModelConfiguration : IEntityTypeConfiguration<StorageModel>
    {
        public void Configure(EntityTypeBuilder<StorageModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
