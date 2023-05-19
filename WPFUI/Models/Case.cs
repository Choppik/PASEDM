using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Case
    {
        public Case () { }
        public Case(int id, string numberCase, string desription)
        {
            Id = id;
            NumberCase = numberCase;
            Description = desription;
        }

        public Case(ICasesProvider casesProvider)
        {
            _casesProvider = casesProvider;
        }

        private readonly ICasesProvider _casesProvider;
        public int Id { get; }
        public string NumberCase { get; set; }
        public string Description { get; }
        public Task<IEnumerable<Case>> GetAllCase()
        {
            return _casesProvider.GetAllCase();
        }
        public override string ToString()
        {
            return $"{NumberCase}";
        }
    }
}