using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysAdminOperationLog
    {
        public long OperId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PageName { get; set; }
        public string ActionName { get; set; }
        public string LocalIp { get; set; }
        public string LocalAddr { get; set; }
        public string Url { get; set; }
        public int OperationType { get; set; }
        public DateTime CreateTime { get; set; }
        public string Remark { get; set; }
    }
}
