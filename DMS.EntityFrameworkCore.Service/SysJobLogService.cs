using DMS.BaseFramework.Common.BaseResult;
using DMS.BaseFramework.Common.Extension;
using DMS.BaseFramework.Common.Extension.ExpressionFunc;
using DMS.EntityFrameworkCore.Contracts;
using DMS.EntityFrameworkCore.Extension;
using DMS.EntityFrameworkCore.Repository.Models;
using DMS.Exceptionless;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

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

    /// <summary>
    /// 
    /// </summary>
    public class SysJobLogService : ServiceBase, IDemoService
    {
        /// <summary>
        /// 
        /// </summary>
        public SysJobLogService()
            : base(new WALIUJR_SYSContext()) { }

        /// <summary>
        /// 同步插入
        /// </summary>
        /// <returns></returns>
        public ResponseResult Add()
        {
            ResponseResult result = new ResponseResult();
            SysJobLog jobLogEntity = new SysJobLog()
            {
                Name = "测试",
                JobLogType = 1,
                ServerIp = "::",
                TaskLogType = 1,
                Message = "测试消息",
                CreateTime = DateTime.Now
            };

            SysLog jobEntity = new SysLog()
            {
                Logger = "测试数据",
                Level = "测试等级",
                Ip = "::",
                DeleteFlag = false,
                LogType = 1,
                Message = "测试数据",
                SubSysId = 1,
                SubSysName = "测试子名称",
                Thread = "测试数据",
                Url = "http://www.jinglih.com/",
                MemberName = "17623827239",
                CreateTime = DateTime.Now,
                Exception = "测试异常信息"
            };

            //常规的写法
            using (TransactionScope scope = new TransactionScope())
            {
                Insert(jobEntity);
                Insert(jobLogEntity);

                //锁表查询测试
                SysLog logEntity = FirstOrDefault<SysLog>(q => q.LogId == 86);
                SysJobLog entity = FirstOrDefault<SysJobLog>(q => q.JobLogId == 13);

                scope.Complete();//提交事务
            }
            return result;
        }

        /// <summary>
        /// 异步插入
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseResult> AddAsync()
        {
            ResponseResult result = new ResponseResult();
            SysJobLog jobLogEntity = new SysJobLog()
            {
                Name = "测试",
                JobLogType = 1,
                ServerIp = "::",
                TaskLogType = 1,
                Message = "测试消息",
                CreateTime = DateTime.Now
            };

            SysLog jobEntity = new SysLog()
            {
                Logger = "测试数据",
                Level = "测试等级",
                Ip = "::",
                DeleteFlag = false,
                LogType = 1,
                Message = "测试数据",
                SubSysId = 1,
                SubSysName = "测试子名称",
                Thread = "测试数据",
                Url = "http://www.jinglih.com/",
                MemberName = "17623827239",
                CreateTime = DateTime.Now,
                Exception = "测试异常信息"
            };

            ////常规的写法
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                //执行action
                await InsertAsync(jobEntity);
                await InsertAsync(jobLogEntity);

                //锁表查询测试
                SysLog logEntity = await FirstOrDefaultAsync<SysLog>(q => q.LogId == 86);
                SysJobLog entity = await FirstOrDefaultAsync<SysJobLog>(q => q.JobLogId == 13);

                //提交事务
                scope.Complete();
            }
            return result;
        }

        /// <summary>
        /// 同步查询示例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysJobLog GetEntity(int id)
        {
            SysJobLog entity = FirstOrDefault<SysJobLog>(q => q.JobLogId == 13);
            LessLog.Info("我是一条测试日志");

            var json = typeof(EnumMemUserType).ToJson();
            var des = EnumMemUserType.QQType.GetDescription();
            return entity;
        }

        /// <summary>
        /// 异步查询示例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SysJobLog> GetEntityAsync(int id)
        {
            return await FirstOrDefaultAsync<SysJobLog>(q => q.JobLogId == 13);
        }

        /// <summary>
        /// 第一种方法，同步
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="searchText2"></param>
        /// <returns></returns>
        public List<SysJobLog> GetList(string searchText, string searchText2)
        {
            IQueryable<SysJobLog> queryList = GetQueryable<SysJobLog>();
            if (!string.IsNullOrEmpty(searchText))
            {
                queryList = queryList.Where(q => q.Message.Equals(searchText));
            }
            if (!string.IsNullOrEmpty(searchText2))
            {
                queryList = queryList.Where(q => q.Name.Equals(searchText2));
            }
            var list = queryList.ToList();

            return list;
        }


        /// <summary>
        /// 第一种方法，异步
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="searchText2"></param>
        /// <returns></returns>
        public async Task<List<SysJobLog>> GetListAsync(string searchText, string searchText2)
        {
            IQueryable<SysJobLog> queryList = GetQueryable<SysJobLog>();
            if (!string.IsNullOrEmpty(searchText))
            {
                queryList = queryList.Where(q => q.Message.Contains(searchText));
            }
            if (!string.IsNullOrEmpty(searchText2))
            {
                queryList = queryList.Where(q => q.Name.Contains(searchText2));
            }
            var list = await queryList.ToListAsync();
            return list;
        }

        /// <summary>
        /// 第二种方同步，扩展表达式
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="searchText2"></param>
        /// <returns></returns>
        public List<SysJobLog> GetListExt(string searchText, string searchText2)
        {
            Expression<Func<SysJobLog, bool>> express = q => q.JobLogType == 1;
            express = express.And(q => q.TaskLogType == 1);
            if (!searchText.IsNullOrEmpty())
            {
                express = express.And(c => c.Message.Contains(searchText));
            }
            if (!searchText2.IsNullOrEmpty())
            {
                express = express.And(c => c.Name.Contains(searchText2));
            }

            var list = this.GetList(express);
            return list;
        }

        /// <summary>
        /// 第二种方法异步，扩展表达式
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="searchText2"></param>
        /// <returns></returns>
        public async Task<List<SysJobLog>> GetListExtAsync(string searchText, string searchText2)
        {
            Expression<Func<SysJobLog, bool>> express = q => q.JobLogType == 1;
            express = express.And(q => q.TaskLogType == 1);
            if (!searchText.IsNullOrEmpty())
            {
                express = express.And(c => c.Message.Equals(searchText));
            }
            if (!searchText2.IsNullOrEmpty())
            {
                express = express.And(c => c.Name.Equals(searchText2));
            }

            var list = await this.GetListAsync(express);
            return list;
        }


        /// <summary>
        /// 同步执行分页查询示例
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public ResponsePageResult<SysJobLog> GetPageList(int pageIndex, int pageSize, string searchText)
        {
            ResponsePageResult<SysJobLog> result = new ResponsePageResult<SysJobLog>() { data = new DataResultList<SysJobLog>() };
            IQueryable<SysJobLog> queryList = GetQueryable<SysJobLog>();
            if (!string.IsNullOrEmpty(searchText))
            {
                queryList = queryList.Where(q => q.Message.Contains(searchText));
            }

            //执行分页查询
            result.data = queryList
                .OrderBy(q => q.CreateTime)
                .ThenBy(q => q.JobLogId)
                .ToPageList(pageIndex, pageSize);

            return result;
        }

        /// <summary>
        /// 异步执行分页查询示例
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public async Task<ResponsePageResult<SysJobLog>> GetPageListAsync(int pageIndex, int pageSize, string searchText)
        {
            ResponsePageResult<SysJobLog> result = new ResponsePageResult<SysJobLog>() { data = new DataResultList<SysJobLog>() };
            IQueryable<SysJobLog> queryList = GetQueryable<SysJobLog>();
            if (!string.IsNullOrEmpty(searchText))
            {
                queryList = queryList.Where(q => q.Message.Contains(searchText));
            }

            //执行分页查询
            result.data = await queryList
                .OrderBy(q => q.CreateTime)
                .ThenBy(q => q.JobLogId)
                .ToPageListAsync(pageIndex, pageSize);

            return result;
        }
    }
}