using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class MoveDocumentConfiguration : IEntityTypeConfiguration<MoveDocumentDTO>
    {
        public void Configure(EntityTypeBuilder<MoveDocumentDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
        }
    }
}