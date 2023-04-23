using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class CaseConfiguration : IEntityTypeConfiguration<CaseDTO>
    {
        public void Configure(EntityTypeBuilder<CaseDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.NumberCase).HasMaxLength(10);
            builder.Property(x => x.Desription).HasMaxLength(100);
        }
    }
}