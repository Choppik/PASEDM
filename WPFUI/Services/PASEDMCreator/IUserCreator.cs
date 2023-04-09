using PASEDM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator
{
    public interface IUserCreator
    {
        Task CreateUser(User user);
    }
}
