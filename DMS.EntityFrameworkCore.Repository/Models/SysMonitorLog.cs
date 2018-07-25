using System;
using System.Collections.Generic;

namespace DMS.EntityFrameworkCore.Repository.Models
{
    public partial class SysMonitorLog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Time { get; set; }
        public string QueryParams { get; set; }
        public string RequesHead { get; set; }
        public string HttpMethod { get; set; }
        public string Ip { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string HostName { get; set; }
        public string HostNameUser { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
