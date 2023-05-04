using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
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
            return new User(dto.ID, dto.UserName, dto.Password, dto.DateOfCreation, dto.EmployeeID);
        }
        public async Task<bool> GetUserBool(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                UserDTO userDTO = await context.Users
                    .Where(u => u.UserName == user.UserName)
                    .FirstOrDefaultAsync();

                return userDTO is null;
            }
        }
        public async Task<User> GetUser(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                UserDTO userDTO = await context.Users
                    .Where(u => u.UserName == user.UserName)
                    .FirstOrDefaultAsync();

                if (userDTO == null)
                {
                    return null;
                }

                return ToDefiniteUser(userDTO);
            }
        }
        private static User ToDefiniteUser(UserDTO dto)
        {
            return new User(dto.ID, dto.UserName);
        }
    }
}