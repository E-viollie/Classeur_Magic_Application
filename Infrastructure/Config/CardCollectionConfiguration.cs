using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class CardCollectionConfiguration : IEntityTypeConfiguration<CardCollection>
    {
        public void Configure(EntityTypeBuilder<CardCollection> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
