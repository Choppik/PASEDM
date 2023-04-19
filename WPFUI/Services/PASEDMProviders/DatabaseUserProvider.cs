using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders
{
    public class DatabaseUserProvider : IUserProvider
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseUserProvider(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<UserDTO> userDTOs = await context.Users.Include(u => u.Employee).ToListAsync();

                return userDTOs.Select(u => ToUser(u));
            }
        }

        private static User ToUser(UserDTO dto)
        {
            return new User(dto.UserName, dto.Password, dto.EmployeeID);
        }
        public async Task<IEnumerable<User>> GetUser()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<UserDTO> userDTOs = await context.Users.ToListAsync();

                return userDTOs.Select(u => ToNameUser(u));
            }
        }
        private static User ToNameUser(UserDTO dTO)
        {
            return new User(dTO.UserName);
        }
    }
}