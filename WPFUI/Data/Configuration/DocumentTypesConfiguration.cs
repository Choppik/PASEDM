using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class DocumentTypesConfiguration : IEntityTypeConfiguration<DocumentTypesDTO>
    {
        public void Configure(EntityTypeBuilder<DocumentTypesDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}