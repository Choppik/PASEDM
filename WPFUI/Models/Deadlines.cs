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

        public Deadlines(int id, string nameTerm, string term)
        {
            Id = id;
            NameTerm = nameTerm;
            Term = term;
        }

        public int Id { get; }
        public string NameTerm { get; }
        public string Term { get; }
        public Task<IEnumerable<Deadlines>> GetAllDeadlines()
        {
            return _deadlinesProvider.GetAllDeadlines();
        }
    }
}