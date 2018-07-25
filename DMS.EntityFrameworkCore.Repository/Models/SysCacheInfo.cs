using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysCacheInfo
    {
        public Guid CacheKey { get; set; }
        public int CacheType { get; set; }
        public int RedisNum { get; set; }
        public string CacheName { get; set; }
        public string CacheData { get; set; }
        public DateTime ExpiryTime { get; set; }
        public int StatusFlag { get; set; }
        public int Hits { get; set; }
        public int Length { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateBy { get; set; }
        public string UpdateByName { get; set; }
        public string XsltFilePath { get; set; }
        public DateTime XsltLastUpdateTime { get; set; }
        public DateTime XsltControlLastUpdateTime { get; set; }
        public string MemVersion { get; set; }
        public int RelationId { get; set; }
        public int RelationType { get; set; }
    }
}
