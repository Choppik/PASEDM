using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class TypeUserConfiguration : IEntityTypeConfiguration<TypeUserDTO>
    {
        public void Configure(EntityTypeBuilder<TypeUserDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.TypeUser).HasMaxLength(50);
            builder.Property(x => x.TypeUserValue).HasMaxLength(2);
        }
    }
}