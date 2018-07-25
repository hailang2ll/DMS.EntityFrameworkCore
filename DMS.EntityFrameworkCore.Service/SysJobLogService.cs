using DMS.BaseFramework.Common.Extension;
using DMS.EntityFrameworkCore.Contracts;
using DMS.EntityFrameworkCore.Extension;
using DMS.EntityFrameworkCore.Repository.Models;
using DMS.Exceptionless;
using System.ComponentModel;

namespace DMS.EntityFrameworkCore.Service
{
    public enum EnumMemUserType
    {
        [Description("普通用户")]
        Nornm = 0,
        [Description("QQ用户")]
        QQType = 1,
        [Description("dfdfdsfd ")]
        Test = 2
    }


    public class EnumStatusFlag
    {
        /// <summary>
        /// 0未审核 
        /// </summary>
        [Description("未审核")]
        public const int None = 0;

        /// <summary>
        ///   1待审核(停用)
        /// </summary>
        [Description("待审核")]
        public const int Pending = 1;

        /// <summary>
        ///  2回收站 
        /// </summary>
        [Description("回收站")]
        public const int Delete = 2;

        /// <summary>
        /// 3不通过  
        /// </summary>
        [Description("不通过")]
        public const int UnPassed = 3;

        /// <summary>
        /// 4已审核(启用)
        /// </summary>
        [Description("已审核")]
        public const int Passed = 4;

        /// <summary>
        /// 5已过期
        /// </summary>
        [Description("已过期")]
        public const int Expired = 5;

        /// <summary>
        /// 6锁定
        /// </summary>
        [Description("锁定")]
        public const int Locking = 6;
    }



    public class SysJobLogService :  ServiceBase<SysJobLog>, IDemoService
    {
        public SysJobLogService() : base(new WALIUJR_SYSContext())
        { }


        public SysJobLog GetEntity(int id)
        {
            SysJobLog entity = this.FirstOrDefault(q => q.JobLogId == 13);

            LessLog.Info("我是一条测试日志");

            var json =typeof(EnumMemUserType).ToJson();

            var des = EnumMemUserType.QQType.GetDescription();

            return entity;
        }
    }
}
