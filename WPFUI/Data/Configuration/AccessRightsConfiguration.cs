using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class AccessRightsConfiguration : IEntityTypeConfiguration<AccessRightsDTO>
    {
        public void Configure(EntityTypeBuilder<AccessRightsDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.AccessRights).HasMaxLength(100);
            builder.Property(x => x.AccessRightsValue).HasMaxLength(2);
        }
    }
}