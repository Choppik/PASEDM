using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Deadlines
    {
        private readonly IDeadlinesProvider _deadlinesProvider;

        public Deadlines(IDeadlinesProvider deadlinesProvider)
        {
            _deadlinesProvider = deadlinesProvider;
        }

        public Deadlines(int iD, string nameTerm, string term)
        {
            ID = iD;
            NameTerm = nameTerm;
            Term = term;
        }

        public int ID { get; }
        public string NameTerm { get; }
        public string Term { get; }
        public Task<IEnumerable<Deadlines>> GetAllDeadlines()
        {
            return _deadlinesProvider.GetAllDeadlines();
        }
    }
}