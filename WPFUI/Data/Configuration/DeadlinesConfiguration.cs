using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class DeadlinesConfiguration : IEntityTypeConfiguration<TermDTO>
    {
        public void Configure(EntityTypeBuilder<TermDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.NameTerm).HasMaxLength(50);
            builder.Property(x => x.Term).HasMaxLength(50);
        }
    }
}