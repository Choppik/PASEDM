using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class AccessRights
    {
        private IAccessRightsProvider _accessRightsProvider;
        public AccessRights() { }

        public AccessRights(IAccessRightsProvider accessRightsProvider)
        {
            _accessRightsProvider = accessRightsProvider;
        }

        public AccessRights(int id, string nameAccessRight, int accessRightsValue)
        {
            Id = id;
            NameAccessRight = nameAccessRight;
            AccessRightsValue = accessRightsValue;
        }

        public int Id { get; }
        public string NameAccessRight { get; set; }
        public int AccessRightsValue { get; }

        public Task<IEnumerable<AccessRights>> GetAllAccessRights()
        {
            return _accessRightsProvider.GetAllAccessRights();
        }
        public override string ToString()
        {
            return $"{NameAccessRight}";
        }
    }
}