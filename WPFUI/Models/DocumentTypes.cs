using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class DocumentTypes
    {
        private IDocTypProvider _docTypProvider;

        public DocumentTypes(IDocTypProvider docTypProvider)
        {
            _docTypProvider = docTypProvider;
        }

        public DocumentTypes(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public int ID { get; }
        public string Name { get; }
        public Task<IEnumerable<DocumentTypes>> GetAllDocTyp()
        {
            return _docTypProvider.GetAllDocTyp();
        }
    }
}