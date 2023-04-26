﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PASEDM.Data.DTOs
{
    public class DocumentTypesDTO
    {
        [Key]
        public int ID {  get; set; }
        public string Name { get; set; }
        public DateTime ExecutionDate { get; set; }
        public ICollection<CardDTO> Cards { get; set; }
    }
}