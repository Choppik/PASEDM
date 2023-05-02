using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Document
    {
        private readonly IDocumentCreator _documentCreator;
        private readonly IDocProvider _docProvider;

        public Document(IDocumentCreator documentCreator)
        {
            _documentCreator = documentCreator;
        }

        public Document(IDocProvider docProvider)
        {
            _docProvider = docProvider;
        }

        public Document(int id, string nameDoc)
        {
            Id = id;
            NameDoc = nameDoc;
        }

        public Document(string nameDoc, int registrationNumber, DateTime dateCreateDoc, string summary, string conditionDoc, string secrecyStamp, string path, int? termID)
        {
            NameDoc = nameDoc;
            RegistrationNumber = registrationNumber;
            DateCreateDoc = dateCreateDoc;
            Summary = summary;
            ConditionDoc = conditionDoc;
            SecrecyStamp = secrecyStamp;
            Path = path;
            TermID = termID;
        }
        public Document(
            int id, 
            string nameDoc, 
            int registrationNumber, 
            DateTime dateCreateDoc, 
            string summary,
            string conditionDoc, 
            string secrecyStamp, 
            string path, 
            int? termID) 
            : this(nameDoc, registrationNumber, dateCreateDoc, summary, conditionDoc, secrecyStamp, path, termID)
        {
            Id = id;
        }

        //private readonly IDocumentProvider _documentProviders;
        //private readonly IDocumentConflictValidator _documentConflictValidator;
        public int Id { get; }
        public string NameDoc { get; }
        public int RegistrationNumber { get; }
        public DateTime DateCreateDoc { get; }
        public string Summary { get; }
        public string ConditionDoc { get; }
        public string SecrecyStamp { get; }
        public string Path { get; }
        public int? TermID { get; }

        public async Task AddDoc(Document document)
        {
            await _documentCreator.CreateDocument(document);
        }
        public async Task<IEnumerable<Document>> GetAllDoc()
        {
            return await _docProvider.GetAllDoc();
        }
        public async Task<Document> GetDoc(Document document)
        {
            return await _docProvider.GetDoc(document);
        }
    }
}