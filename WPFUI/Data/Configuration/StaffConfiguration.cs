﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PASEDM.Data.DTOs;

namespace PASEDM.Data.Configuration
{
    internal class StaffConfiguration : IEntityTypeConfiguration<EmployeeDTO>
    {
        public void Configure(EntityTypeBuilder<EmployeeDTO> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}
