using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class TaskStagesConfiguration : IEntityTypeConfiguration<TaskStagesDTO>
    {
        public void Configure(EntityTypeBuilder<TaskStagesDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.TaskStages).HasMaxLength(100);
            builder.Property(x => x.TaskStagesValue).HasMaxLength(2);
        }
    }
}