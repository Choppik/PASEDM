using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class TypeUserConfiguration : IEntityTypeConfiguration<TypeCardDTO>
    {
        public void Configure(EntityTypeBuilder<TypeCardDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.TypeCard).HasMaxLength(50);
            builder.Property(x => x.TypeCardValue).HasMaxLength(2);
        }
    }
}