using Engine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Engine.ViewModels.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.IdUser).ValueGeneratedOnAdd();
            builder.Property(x => x.Login).HasMaxLength(50);
            builder.Property(x => x.Password).HasMaxLength(100);
        }
    }
}
