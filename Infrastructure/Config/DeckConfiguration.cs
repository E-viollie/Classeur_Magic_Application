using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Config
{
    class DeckConfiguration
    {
        public class CardPossessedConfiguration : IEntityTypeConfiguration<Deck>, IEntityTypeConfiguration
        {
            public void Configure(EntityTypeBuilder<Deck> builder)
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                builder.HasMany(e => e.MainBoard)
                .WithOne()
                .HasForeignKey(c => c.DeckId);
                builder.HasMany(e => e.MaybeDeck)
               .WithOne()
               .HasForeignKey(c => c.DeckId);
            }
        }
    }
}
