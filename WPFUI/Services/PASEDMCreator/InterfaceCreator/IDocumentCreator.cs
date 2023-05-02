using PASEDM.Models;
using System.Threading.Tasks;

namespace PASEDM.Services.PASEDMCreator.InterfaceCreator
{
    public interface IDocumentCreator
    {
        Task CreateDocument(Document document);
    }
}