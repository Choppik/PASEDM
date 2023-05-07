using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class SenderConfiguration : IEntityTypeConfiguration<SenderDTO>
    {
        public void Configure(EntityTypeBuilder<SenderDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
        }
    }
}