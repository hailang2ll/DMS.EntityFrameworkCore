using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.MemberModels
{
    public partial class MemMemberAddress
    {
        public long MemAddressId { get; set; }
        public long MemberId { get; set; }
        public string AreaCodePath { get; set; }
        public string AreaNamePath { get; set; }
        public string AreaAddress { get; set; }
        public bool IsDefault { get; set; }
        public string Contact { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public string IdentityCard { get; set; }
        public string IdentityCardName { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public long CreateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public long UpdateBy { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime DeleteTime { get; set; }
        public long DeleteBy { get; set; }
    }
}
