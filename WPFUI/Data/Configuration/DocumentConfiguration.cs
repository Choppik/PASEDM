using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class DocumentConfiguration : IEntityTypeConfiguration<DocumentDTO>
    {
        public void Configure(EntityTypeBuilder<DocumentDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.RegistrationNumber).HasMaxLength(10);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.TypeDocument).HasMaxLength(50);
        }
    }
}