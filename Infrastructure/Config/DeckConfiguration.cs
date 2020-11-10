using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    internal class DeckConfiguration
    {
        public class CardPossessedConfiguration : IEntityTypeConfiguration<Deck>, IEntityTypeConfiguration
        {
            public void Configure(EntityTypeBuilder<Deck> builder)
            {
                //builder.ToTable("DECKS");

                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                       .ValueGeneratedOnAdd();

                builder.HasMany(d => d.CardList)
                .WithOne()
                .HasForeignKey(c => c.DeckId);
            }
        }
    }
}
