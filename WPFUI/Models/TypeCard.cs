using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class TypeCard
    {
        private ITypeCardProvider _typeUserProvider;

        public TypeCard() { }
        public TypeCard(ITypeCardProvider typeUserProvider)
        {
            _typeUserProvider = typeUserProvider;
        }

        public TypeCard(int id, string nameTypeCard, int typeCardValue)
        {
            Id = id;
            NameTypeCard = nameTypeCard;
            TypeCardValue = typeCardValue;
        }

        public int Id { get; }
        public string NameTypeCard { get; }
        public int TypeCardValue { get; }
        public Task<IEnumerable<TypeCard>> GetAllTypeUsers()
        {
            return _typeUserProvider.GetAllTypeUsers();
        }
    }
}