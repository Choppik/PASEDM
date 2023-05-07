﻿using PASEDM.Data.DTOs;
using PASEDM.Data;
using System.Threading.Tasks;
using PASEDM.Models;
using PASEDM.Services.PASEDMCreator.InterfaceCreator;

namespace PASEDM.Services.PASEDMCreator
{
    public class DatabaseDocumentCreator : IDocumentCreator
    {
        private readonly PASEDMDbContextFactory _dbContextFactory;

        public DatabaseDocumentCreator(PASEDMDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateDocument(Document document)
        {
            using (PASEDMContext context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    DocumentDTO documentDTO = ToDocumentDTO(document);
                    context.Documents.Add(documentDTO);
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }

        private static DocumentDTO ToDocumentDTO(Document document)
        {
            return new DocumentDTO()
            {
                ID = document.Id,
                NameDoc = document.NameDoc,
                RegistrationNumber = document.RegistrationNumber,
                DateCreateDoc = document.DateCreateDoc,
                Summary = document.Summary,
                Path = document.Path,
                TermID = document.TermID,
                SecrecyStampsID = document.SecrecyStampID,
                DocStagesID = document.DocStagesID
            };
        }
    }
}