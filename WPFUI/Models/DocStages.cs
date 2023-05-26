using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class DocStages
    {
        private IDocStagesProvider _docStagesProvider;

        public DocStages() { }
        public DocStages(IDocStagesProvider docStagesProvider)
        {
            _docStagesProvider = docStagesProvider;
        }

        public DocStages(int? id, string nameDocStage, int docStagesValue)
        {
            Id = id;
            NameDocStage = nameDocStage;
            DocStagesValue = docStagesValue;
        }

        public int? Id { get; }
        public string NameDocStage { get; set; }
        public int DocStagesValue { get; }
        public Task<IEnumerable<DocStages>> GetAllDocStages()
        {
            return _docStagesProvider.GetAllDocStages();
        }
        public override string ToString()
        {
            return $"{NameDocStage}";
        }
    }
}