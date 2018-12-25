using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysAddress
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string ShortName { get; set; }
        public string MergerShortName { get; set; }
        public int LevelType { get; set; }
        public string CityCode { get; set; }
        public string ZipCode { get; set; }
        public string Remark { get; set; }
    }
}
