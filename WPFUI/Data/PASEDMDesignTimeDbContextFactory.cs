using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASEDM.Data
{
    public class PASEDMDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PASEDMContext>
    {
        public PASEDMContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer("Server=localhost;Database=AppPASEDM;User Id=user1;Password=sa;TrustServerCertificate=True").Options;

            return new PASEDMContext(options);
        }
    }
}
