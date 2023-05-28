using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Division
    {
        private IDivisionProvider _divisionProvider;
        public Division() { }

        public Division(IDivisionProvider divisionProvider)
        {
            _divisionProvider = divisionProvider;
        }

        public Division(int id, int numberDivision, string nameDivision)
        {
            Id = id;
            NumberDivision = numberDivision;
            NameDivision = nameDivision;
        }

        public int Id { get; set; }
        public int NumberDivision { get; set; }
        public string NameDivision { get; set; }

        public Task<IEnumerable<Division>> GetAllDivisions()
        {
            return _divisionProvider.GetAllDivisions();
        }
        public override string ToString()
        {
            return $"{NameDivision}";
        }
    }
}