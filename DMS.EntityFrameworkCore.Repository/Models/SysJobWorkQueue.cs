using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysJobWorkQueue
    {
        public int WorkQueueId { get; set; }
        public int WorkType { get; set; }
        public int ToUserId { get; set; }
        public string UserName { get; set; }
        public string RelateKey { get; set; }
        public string SendUserCode { get; set; }
        public int EventLevel { get; set; }
        public string WorkTitle { get; set; }
        public string WorkContent { get; set; }
        public string WorkHtmlcontent { get; set; }
        public bool SendFlag { get; set; }
        public string SendResult { get; set; }
        public DateTime PlanSendTime { get; set; }
        public DateTime SendTime { get; set; }
        public int TryTimeCount { get; set; }
        public string ValidateCode { get; set; }
        public bool ValidateFlag { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateUser { get; set; }
        public string Remark { get; set; }
        public string ServerIp { get; set; }
        public bool CloseFlag { get; set; }
        public int CloseUser { get; set; }
        public DateTime CloseTime { get; set; }
        public string CloseRemark { get; set; }
    }
}
