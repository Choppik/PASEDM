﻿using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PASEDM.Models
{
    public class SecrecyStamps
    {
        private ISecrecyStampsProvider _secrecyStampsProvider;
        public SecrecyStamps(ISecrecyStampsProvider secrecyStampsProvider)
        {
            _secrecyStampsProvider = secrecyStampsProvider;
        }

        public SecrecyStamps() { }
        public SecrecyStamps(int id, string nameSecrecyStamp, int secrecyStampValue)
        {
            Id = id;
            NameSecrecyStamp = nameSecrecyStamp;
            SecrecyStampValue = secrecyStampValue;
        }

        public int Id { get; }
        public string NameSecrecyStamp { get; set; }
        public int SecrecyStampValue { get; set; }
        public Task<IEnumerable<SecrecyStamps>> GetAllSecrecyStamps()
        {
            return _secrecyStampsProvider.GetAllSecrecyStamps();
        }
        public override string ToString()
        {
            return $"{NameSecrecyStamp}";
        }
    }
}