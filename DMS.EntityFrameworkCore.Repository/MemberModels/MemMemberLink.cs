using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.MemberModels
{
    public partial class MemMemberLink
    {
        public int LinkType { get; set; }
        public string LinkKey { get; set; }
        public long MemberId { get; set; }
        public string UserInfoJson { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
