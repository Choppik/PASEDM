using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class SecrecyStampConfiguration : IEntityTypeConfiguration<SecrecyStampDTO>
    {
        public void Configure(EntityTypeBuilder<SecrecyStampDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.SecrecyStamp).HasMaxLength(100);
            builder.Property(x => x.SecrecyStampValue).HasMaxLength(2);
        }
    }
}