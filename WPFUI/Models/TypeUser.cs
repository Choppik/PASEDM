using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class TypeUser
    {
        private ITypeUserProvider _typeUserProvider;

        public TypeUser(ITypeUserProvider typeUserProvider)
        {
            _typeUserProvider = typeUserProvider;
        }

        public TypeUser(int id, string nameTypeUser, int typeUserValue)
        {
            Id = id;
            NameTypeUser = nameTypeUser;
            TypeUserValue = typeUserValue;
        }

        public int Id { get; }
        public string NameTypeUser { get; }
        public int TypeUserValue { get; }
        public Task<IEnumerable<TypeUser>> GetAllTypeUsers()
        {
            return _typeUserProvider.GetAllTypeUsers();
        }
    }
}