using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class StaffConfiguration : IEntityTypeConfiguration<EmployeeDTO>
    {
        public void Configure(EntityTypeBuilder<EmployeeDTO> builder)
        {
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.NumberEmployee).HasMaxLength(10);
            builder.Property(x => x.FullName).HasMaxLength(50);
            builder.Property(x => x.Mail).HasMaxLength(100);
            builder.Property(x => x.Admittance).HasMaxLength(50);
        }
    }
}