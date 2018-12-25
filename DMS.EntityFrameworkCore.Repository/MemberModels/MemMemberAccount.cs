using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.MemberModels
{
    public partial class MemMemberAccount
    {
        public long MemberId { get; set; }
        public string Password { get; set; }
        public string PayPassword { get; set; }
        public string NickName { get; set; }
        public string TrueName { get; set; }
        public int SexType { get; set; }
        public int MemberType { get; set; }
        public int StatusFlag { get; set; }
        public string DisableReason { get; set; }
        public string RegistIp { get; set; }
        public string Logo { get; set; }
        public string Mobile { get; set; }
        public bool MobileFlag { get; set; }
        public DateTime MobileVerifyTime { get; set; }
        public DateTime BeforeLoginTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string LastLoginIp { get; set; }
        public int LoginTimes { get; set; }
        public DateTime CreateTime { get; set; }
        public string Remark { get; set; }
        public long InviterId { get; set; }
        public bool RecommendFlag { get; set; }
        public string WeChat { get; set; }
        public string IdcardNo { get; set; }
        public string ShopLogo { get; set; }
        public string ShopName { get; set; }
        public string ShopDes { get; set; }
        public int ShopStatusFlag { get; set; }
        public string AreaCodePath { get; set; }
        public string AreaNamePath { get; set; }
        public string AreaAddress { get; set; }
    }
}
