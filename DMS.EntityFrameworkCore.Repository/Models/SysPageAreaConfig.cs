using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysPageAreaConfig
    {
        public Guid ConfigKey { get; set; }
        public Guid AreaKey { get; set; }
        public string CodePath { get; set; }
        public string NamePath { get; set; }
        public string ShowName { get; set; }
        public int RelationId { get; set; }
        public string RelationName { get; set; }
        public string RelationLink { get; set; }
        public int RelationType { get; set; }
        public string ConfigImage { get; set; }
        public int StatusFlag { get; set; }
        public int SortOrder { get; set; }
        public string Color { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UpdateUser { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime DeleteTime { get; set; }
        public int DeleteUser { get; set; }
    }
}
