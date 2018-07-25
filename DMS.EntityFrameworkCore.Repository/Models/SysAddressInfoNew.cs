using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysAddressInfoNew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string ShortName { get; set; }
        public int LevelType { get; set; }
        public string CityCode { get; set; }
        public string ZipCode { get; set; }
        public string MergerName { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
        public string Pinyin { get; set; }
    }
}
