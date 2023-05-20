using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Data.DTOs;
using System.Linq;
using System.Threading.Tasks;
using PASEDM.Models;

namespace PASEDM.Services.PASEDMConflictValidator
{
    public class DatabaseUserConflictValidator : IUserConflictValidator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseUserConflictValidator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<User> GetConflictingUser(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                UserDTO userDTO = await context.Users
                    .Where(u => u.UserName == user.UserName)
                    .Where(u => u.Password == user.Password)
                    .FirstOrDefaultAsync();

                if (userDTO == null)
                {
                    return null;
                }

                return ToUser(userDTO);
            }
        }
        private static User ToUser(UserDTO dto)
        {
            return new User(dto.ID, dto.UserName, dto.Password, dto.RecordConfirmation);
        }
    }
}