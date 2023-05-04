using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class DocStagesConfiguration : IEntityTypeConfiguration<DocStagesDTO>
    {
        public void Configure(EntityTypeBuilder<DocStagesDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.DocStages).HasMaxLength(100);
            builder.Property(x => x.DocStagesValue).HasMaxLength(2);
        }
    }
}