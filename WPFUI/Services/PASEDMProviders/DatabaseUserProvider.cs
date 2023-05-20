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
                IEnumerable<UserDTO> userDTOs = await context.Users
                    .Include(u => u.Employee).ThenInclude(u => u.AccessRights)
                    .Include(u => u.Role)
                    .ToListAsync();

                return userDTOs.Select(u => ToUser(u));
            }
        }

        private static User ToUser(UserDTO dto)
        {
            Role role = new(dto.Role.ID, dto.Role.NameRole, dto.Role.SignificanceRole);
            AccessRights accessRights = new(dto.Employee.AccessRights.ID, dto.Employee.AccessRights.AccessRights, dto.Employee.AccessRights.AccessRightsValue);
            Employee employee = new(dto.Employee.ID, dto.Employee.NumberEmployee, dto.Employee.FullName, dto.Employee.Mail, accessRights, dto.Employee.DivisionID);
            return new User(dto.ID, dto.UserName, dto.Password, dto.RecordConfirmation, dto.DateOfCreation, role, employee);
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

        public async Task<IEnumerable<User>> GetUserRecordConfirmation()
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<UserDTO> userDTOs = await context.Users
                    .Where(u => u.RecordConfirmation == 0)
                    .Include(u => u.Employee).ThenInclude(u => u.AccessRights)
                    .Include(u => u.Role)
                    .ToListAsync();

                return userDTOs.Select(u => ToUserNoConfirmation(u));
            }
        }
        private static User ToUserNoConfirmation(UserDTO dto)
        {
            Role role = new(dto.Role.ID, dto.Role.NameRole, dto.Role.SignificanceRole);
            AccessRights accessRights = new(dto.Employee.AccessRights.ID, dto.Employee.AccessRights.AccessRights, dto.Employee.AccessRights.AccessRightsValue);
            Employee employee = new(dto.Employee.ID, dto.Employee.NumberEmployee, dto.Employee.FullName, dto.Employee.Mail, accessRights, dto.Employee.DivisionID);
            
            return new User(dto.ID, dto.UserName, dto.DateOfCreation, role, employee);
        }
        public async Task ConfirmationUser(User user)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    UserDTO userDTO = await context.Users
                        .Where(t => t.ID == user.Id)
                        .FirstOrDefaultAsync();

                    if (userDTO != null)
                    {
                        userDTO.RecordConfirmation = 1;
                    }
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}