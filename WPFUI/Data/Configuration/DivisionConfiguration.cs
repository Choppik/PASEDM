using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class DivisionConfiguration : IEntityTypeConfiguration<DivisionDTO>
    {
        public void Configure(EntityTypeBuilder<DivisionDTO> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Division).HasMaxLength(50);
        }
    }
}