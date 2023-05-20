using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class MoveCardConfiguration : IEntityTypeConfiguration<MoveCardDTO>
    {
        public void Configure(EntityTypeBuilder<MoveCardDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Viewed).HasMaxLength(1);
        }
    }
}