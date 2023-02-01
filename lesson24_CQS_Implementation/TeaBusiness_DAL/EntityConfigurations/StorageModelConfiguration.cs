using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_DAL.EntityConfigurations
{
    internal class StorageModelConfiguration : IEntityTypeConfiguration<StorageModel>
    {
        public void Configure(EntityTypeBuilder<StorageModel> builder)
        {
            builder.ToTable("Storage");
            builder.HasMany<TeaModel>(storage => storage.TeasStored)
                .WithMany(tea => tea.StoragesStoring);
        }
    }
}
