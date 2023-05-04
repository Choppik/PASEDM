﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class DocumentDTO
    {
        [Key]
        public int ID { get; set; }
        public string NameDoc { get; set; }
        public int RegistrationNumber { get; set; }
        public DateTime DateCreateDoc { get; set; }
        public string Summary { get; set; }
        public string Path { get; set; }
        public int? TermID { get; set; }
        public TermDTO Term { get; set; }
        public int? SecrecyStampsID { get; set; }
        public SecrecyStampDTO SecrecyStamps { get; set; }
        public int? DocStagesID { get; set; }
        public DocStagesDTO DocStages { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}