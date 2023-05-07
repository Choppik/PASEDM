using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class SecrecyStamps
    {
        private ISecrecyStampsProvider _secrecyStampsProvider;

        public SecrecyStamps(ISecrecyStampsProvider secrecyStampsProvider)
        {
            _secrecyStampsProvider = secrecyStampsProvider;
        }

        public SecrecyStamps(int id, string nameSecrecyStamp, int secrecyStampValue)
        {
            Id = id;
            NameSecrecyStamp = nameSecrecyStamp;
            SecrecyStampValue = secrecyStampValue;
        }

        public int Id { get; }
        public string NameSecrecyStamp { get; }
        public int SecrecyStampValue { get; }
        public Task<IEnumerable<SecrecyStamps>> GetAllSecrecyStamps()
        {
            return _secrecyStampsProvider.GetAllSecrecyStamps();
        }
    }
}