using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysPageAreaOption
    {
        public Guid AreaKey { get; set; }
        public string AreaName { get; set; }
        public int AreaType { get; set; }
        public string AreaCode { get; set; }
        public string CodePath { get; set; }
        public string NamePath { get; set; }
        public Guid ParentKey { get; set; }
        public string AreaImage { get; set; }
        public int SortOrder { get; set; }
        public string AreaDesc { get; set; }
        public int AreaCount { get; set; }
        public int StatusFlag { get; set; }
        public bool IsCreateXml { get; set; }
        public string CacheFileName { get; set; }
        public string IisCacheName { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateBy { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime DeleteTime { get; set; }
        public int DeleteBy { get; set; }
    }
}
