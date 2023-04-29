using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class CardConfiguration : IEntityTypeConfiguration<CardDTO>
    {
        public void Configure(EntityTypeBuilder<CardDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.NumberCard).HasMaxLength(10);
            builder.Property(x => x.NameCard).HasMaxLength(50);
            builder.Property(x => x.Comment).HasMaxLength(200);
        }
    }
}