using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class TaskConfiguration : IEntityTypeConfiguration<TaskDTO>
    {
        public void Configure(EntityTypeBuilder<TaskDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.NameTask).HasMaxLength(50);
            builder.Property(x => x.Contents).HasMaxLength(150);
        }
    }
}