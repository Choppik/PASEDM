using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator
{
    public class DatabaseUserCreator : IUserCreator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseUserCreator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateUser(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                UserDTO userDTO = ToUserDTO(user);

                context.Users.Add(userDTO);
                await context.SaveChangesAsync();
            }
        }

        private UserDTO ToUserDTO(User user)
        {
            return new UserDTO()
            {
                UserName = user.UserName,
                Password = user.Password,
            };
        }
    }
}
