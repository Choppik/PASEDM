using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class DocumentTypes
    {
        private IDocTypProvider _docTypProvider;

        public DocumentTypes() { }
        public DocumentTypes(IDocTypProvider docTypProvider)
        {
            _docTypProvider = docTypProvider;
        }

        public DocumentTypes(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; set; }
        public Task<IEnumerable<DocumentTypes>> GetAllDocTyp()
        {
            return _docTypProvider.GetAllDocTyp();
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}