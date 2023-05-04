using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<RoleDTO>
    {
        public void Configure(EntityTypeBuilder<RoleDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.NameRole).HasMaxLength(50);
            builder.Property(x => x.SignificanceRole).HasMaxLength(2);
        }
    }
}