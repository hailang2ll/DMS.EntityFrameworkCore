using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysAppversionRecord
    {
        public string Versions { get; set; }
        public bool ForceFlag { get; set; }
        public string Url { get; set; }
        public int Equipment { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
