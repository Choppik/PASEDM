using PASEDM.Services.PASEDMConflictValidator;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class Document
    {
        private readonly IDocumentCreator _documentCreator;
        private readonly IDocProvider _docProvider;

        public Document() { }
        public Document(string nameDoc, int registrationNumber, DateTime dateCreateDoc, string summary, string path, int? termID, SecrecyStamps secrecyStamp, int? docStagesID)
            : this(default, nameDoc, registrationNumber, dateCreateDoc, summary, path, termID, secrecyStamp, docStagesID)
        { }

        public Document(int id, string nameDoc) 
            : this(id, nameDoc, default, default, "", "", default, default, default)
        { }
        public Document(string nameDoc)
            : this(default, nameDoc, default, default, "", "", default, default, default)
        { }

        public Document(int id, string nameDoc, int registrationNumber, DateTime dateCreateDoc, string summary, string path, int? termID, SecrecyStamps secrecyStamp, int? docStagesID)
        {
            Id = id;
            NameDoc = nameDoc;
            RegistrationNumber = registrationNumber;
            DateCreateDoc = dateCreateDoc;
            Summary = summary;
            Path = path;
            TermID = termID;
            SecrecyStamp = secrecyStamp;
            DocStagesID = docStagesID;
        }

        public Document(IDocumentCreator documentCreator, IDocProvider docProvider)
        {
            _documentCreator = documentCreator;
            _docProvider = docProvider;
        }

        public int Id { get; }
        public string NameDoc { get; set; }
        public int RegistrationNumber { get; }
        public DateTime DateCreateDoc { get; }
        public string Summary { get; }
        public string Path { get; }
        public int? TermID { get; }
        public SecrecyStamps SecrecyStamp { get; }
        public int? DocStagesID { get; }

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
        public override string ToString()
        {
            return $"{NameDoc}";
        }
    }
}