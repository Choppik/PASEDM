﻿using PASEDM.Services.PASEDMConflictValidator;
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
        public Document(string nameDoc, int registrationNumber, string summary, byte[] file, Deadlines term, SecrecyStamps secrecyStamp, DocStages docStages, DocumentTypes documentTypes)
            : this(default, nameDoc, registrationNumber, summary, file, term, secrecyStamp, docStages, documentTypes)
        { }

        public Document(int id, string nameDoc) 
            : this(id, nameDoc, default, "", default, default, default, default, default)
        { }

        public Document(int id, string nameDoc, int registrationNumber, string summary, byte[] file, Deadlines term, SecrecyStamps secrecyStamp, DocStages docStages, DocumentTypes documentTypes)
        {
            Id = id;
            NameDoc = nameDoc;
            RegistrationNumber = registrationNumber;
            Summary = summary;
            FileDoc = file;
            Term = term;
            SecrecyStamp = secrecyStamp;
            DocStages = docStages;
            DocumentTypes = documentTypes;
        }

        public Document(IDocumentCreator documentCreator, IDocProvider docProvider)
        {
            _documentCreator = documentCreator;
            _docProvider = docProvider;
        }

        public int Id { get; }
        public string NameDoc { get; set; }
        public int RegistrationNumber { get; }
        public string Summary { get; }
        public byte[] FileDoc { get; }
        public Deadlines Term { get; }
        public SecrecyStamps SecrecyStamp { get; }
        public DocStages DocStages { get; }
        public DocumentTypes DocumentTypes { get; }

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