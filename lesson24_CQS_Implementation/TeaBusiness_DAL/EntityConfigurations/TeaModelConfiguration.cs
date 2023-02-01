using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeaBusiness_BLL.Contracts.Models;

namespace TeaBusiness_DAL.EntityConfigurations
{
    internal class TeaModelConfiguration : IEntityTypeConfiguration<TeaModel>
    {
        public void Configure(EntityTypeBuilder<TeaModel> builder)
        {
            builder.ToTable("Tea");
            builder.HasMany<StorageModel>(tea => tea.StoragesStoring)
                .WithMany(storage => storage.TeasStored);
        }
    }
}
