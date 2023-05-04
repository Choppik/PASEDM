using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Role
    {
        private IRoleProvider _roleProvider;

        public Role(IRoleProvider roleProvider)
        {
            _roleProvider = roleProvider;
        }

        public Role(int id, string nameRole, int significanceRole)
        {
            Id = id;
            NameRole = nameRole;
            SignificanceRole = significanceRole;
        }

        public int Id { get; }
        public string NameRole { get; }
        public int SignificanceRole { get; }
        public async Task<IEnumerable<Role>> GetAllRole()
        {
            return await _roleProvider.GetAllRole();
        }
    }
}