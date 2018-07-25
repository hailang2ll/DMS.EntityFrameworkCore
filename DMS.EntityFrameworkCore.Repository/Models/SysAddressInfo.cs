using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysAddressInfo
    {
        public int AddressId { get; set; }
        public string NameCode { get; set; }
        public string AddressName { get; set; }
        public string CodePath { get; set; }
        public string NamePath { get; set; }
        public int LevelPath { get; set; }
        public int ParentId { get; set; }
        public string AreaCode { get; set; }
        public string ZipCode { get; set; }
    }
}
