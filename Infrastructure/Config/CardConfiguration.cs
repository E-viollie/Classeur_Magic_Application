using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtgApiManager.Lib.Dto;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Config
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>, IEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            //builder.ToTable("CARDS");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

        }
    }
}
