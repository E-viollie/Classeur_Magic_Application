using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtgApiManager.Lib.Dto;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Config
{
    public class CardPossessedConfiguration : IEntityTypeConfiguration<CardPossessed>, IEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<CardPossessed> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
            builder.
        }
    }
}
