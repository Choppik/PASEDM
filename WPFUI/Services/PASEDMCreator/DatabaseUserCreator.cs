using PASEDM.Data;
using PASEDM.Data.DTOs;
using PASEDM.Models;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
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
                try
                {
                    UserDTO userDTO = ToUserDTO(user);
                    context.Users.Add(userDTO);
                }
                finally
                { 
                    await context.SaveChangesAsync();
                }
            }
        }

        private static UserDTO ToUserDTO(User user)
        {
            return new UserDTO()
            {
                UserName = user.UserName,
                Password = user.Password,
                DateOfCreation = user.DateOfCreation,
                Role = user.Role,
                EmployeeID = user.EmployeeID
            };
        }
    }
}