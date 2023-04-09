
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASEDM.Data
{
    public class PASEDMDbContextFactory
    {
        private readonly string _connectionString;

        public PASEDMDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PASEDMContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;

            return new PASEDMContext(options);
        }
    }
}
