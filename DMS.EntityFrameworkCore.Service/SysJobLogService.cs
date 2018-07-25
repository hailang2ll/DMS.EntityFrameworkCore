using DMS.EntityFrameworkCore.Extension;
using DMS.EntityFrameworkCore.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.EntityFrameworkCore.Service
{
    public class SysJobLogService : ServiceBase<SysJobLog>
    {
        public SysJobLogService() : base(new WALIUJR_SYSContext())
        { }


        public SysJobLog GetEntity()
        {
            SysJobLog entity = this.FirstOrDefault(q=>q.JobLogId==13);
            return entity;
        }
    }
}
