﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class DocumentDTO
    {
        [Key]
        public int ID { get; set; }
        public string NameDoc { get; set; }
        public int RegistrationNumber { get; set; }
        public string Summary { get; set; }
        public byte[] FileDoc { get; set; }
        public int? TermID { get; set; }
        public TermDTO Term { get; set; }
        public int? SecrecyStampsID { get; set; }
        public SecrecyStampDTO SecrecyStamps { get; set; }
        public int? DocStagesID { get; set; }
        public DocStagesDTO DocStages { get; set; }
        public int? DocumentTypesID { get; set; }
        public DocumentTypesDTO DocumentTypes { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
        public ICollection<MoveDocumentDTO> MoveDocuments { get; set; }
    }
}