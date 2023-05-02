using PASEDM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMProviders.InterfaceProviders
{
    public interface IDocProvider
    {
        Task<IEnumerable<Document>> GetAllDoc();
        Task<Document> GetDoc(Document document);
    }
}