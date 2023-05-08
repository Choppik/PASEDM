using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class MoveUserConfiguration : IEntityTypeConfiguration<MoveUserDTO>
    {
        public void Configure(EntityTypeBuilder<MoveUserDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
        }
    }
}