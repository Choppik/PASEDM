using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class RecipientConfiguration : IEntityTypeConfiguration<RecipientDTO>
    {
        public void Configure(EntityTypeBuilder<RecipientDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
        }
    }
}