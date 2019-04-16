using DMS.BaseFramework.Common.BaseResult;
using DMS.BaseFramework.Common.Utility;
using DMS.EntityFrameworkCore.Extension;
using DMS.EntityFrameworkCore.Repository.MemberModels;
using DMS.EntityFrameworkCore.Repository.Models;
using DMS.EntityFrameworkCore.Service;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMS.BaseFramework.EFCore.ConsoleAppTest
{
    class Program
    {
        static int intFlag = 0;
        static SysJobLogService service = new SysJobLogService();
        static MemberService memservice = new MemberService();

        static void Main(string[] args)
        {
            Get();
            //Count();
            //Insert();
            //Update();
            //Delete();


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static void Get()
        {
            //var entity1 = service.FirstOrDefault<SysJobLog>(q => q.JobLogId == 2);
            //var entity2 = service.LastOrDefault<SysJobLog>(q => q.JobLogId > 2);
            //var entity3 = service.First<SysJobLog>(q => q.JobLogId > 300);
            //var entity4 = service.GetList<SysJobLog>(q => q.JobLogId > 2);

            //var key1 = service.GetByKey<SysJobLog>(1);
            //key1.JobLogId = 2;

            //var dataList = service.GetQueryable<SysJobLog>().Select(q => new { q.JobLogId, q.Message, q.CreateTime })
            //.Where(q => q.Message.Contains("aaaa8")).OrderByDescending(q => q.CreateTime).ToPageList(1, 16);

            //var count = service.Count<SysJobLog>(q => q.Message.Contains("aaaa8"));


            #region 删除
            //var entity1 = service.FirstOrDefault<SysJobLog>(q => q.JobLogId == 0);
            //var del = service.Delete<SysJobLog>(entity1);

            //var entity4 = service.GetList<SysJobLog>(q => q.JobLogId <= 2);
            //del = service.Delete<SysJobLog>(entity4);

            //List<int> ins = new List<int>() {
            //    4,5
            //};
            //del = service.Delete<SysJobLog>(q => ins.Contains(q.JobLogId));

            //var del = service.DeleteBulk<SysJobLog>(q => q.JobLogId <= 7);

            #endregion
            //var entity = service.FirstOrDefault<SysJobLog>(q => q.JobLogId == 1);
            //entity.Message = "我是第一条修改1";
            //intFlag = service.Update(entity);

            #region 修改2，多条记录一起修改
            List<int> ints = new List<int>() {
                    { 8},
                    { 9},
                    { 10},
                };
            List<SysJobLog> sysJobLogs = new List<SysJobLog>();
            var list = service.GetList<SysJobLog>(q => ints.Contains(q.JobLogId));
            foreach (var item in list)
            {
                item.Message = "我是循环被修改的値";
                sysJobLogs.Add(item);
                SysJobLog sysJobLog = list.Where(q => q.JobLogId == 8).FirstOrDefault();
                if (sysJobLog != null)
                {
                    sysJobLog.JobLogId = 11;
                    sysJobLogs.Add(sysJobLog);
                }
            }
            intFlag = service.Update(sysJobLogs);
            //intFlag = service.Update(list);

            //Console.WriteLine("循环修改状态：" + intFlag);
            #endregion

            // intFlag = service.UpdateBulk<SysJobLog>(o => new SysJobLog() { Message = "这是lambda修改" }, q => q.Message.Contains("我是循环") && q.JobLogType <= 10);


            //var entity4 = service.GetList<SysJobLog>(q => ints.Contains(q.JobLogId));
            //foreach (var item in entity4)
            //{
            //    item.Message = "我是被跟踪的7";
            //}
            //var flag = service.DbContext.SaveChanges();

            //query.Where(q => q.No == No).BatchUpdate(q => new TEST
            //{
            //    Flag = 0,
            //    Status = 0,
            //    PayPrice = (payStatusFlag == (int)EnumPayStatusFlag.Complete ? q.OrderPrice : q.OrderPrice * summaryOrderMst.Discount)
            //});


            // var flag = service.Update<SysJobLog>(entity4);


            //service.Add();


            //foreach (var item in entity4)
            //{
            //    item.Name = item.Name + "我是修改的1";
            //}

            //SysJobLog insertJobLog = new SysJobLog()
            //{
            //    Name = "我是新增加的1",
            //    CreateTime = DateTime.Now,
            //    Message = "111",
            //    TaskLogType = 1,
            //    JobLogType = 1,
            //    ServerIp = "0.0"
            //};
            //entity4.Add(insertJobLog);

            //service.BulkInsertOrUpdate<SysJobLog>(entity4);

        }

        static void Count()
        {
            var count = service.Count<SysJobLog>();
            count = service.Count<SysJobLog>(q => q.Message == "aaaa10");

            var longCount = service.LongCount<SysJobLog>();
            longCount = service.LongCount<SysJobLog>(q => q.Message == "aaaa10");
        }

        static void Insert()
        {
            #region 新增1
            for (int i = 0; i < 100; i++)
            {
                SysJobLog sysJobLog = new SysJobLog()
                {
                    JobLogType = 1,
                    Message = "aaaa" + i,
                    Name = "a",
                    ServerIp = "127.0.0.1",
                    TaskLogType = 1,
                    CreateTime = DateTime.Now,
                };
                intFlag = service.Insert(sysJobLog);
                Console.WriteLine("新增数据状态值（返回当前一条语句状态）：" + intFlag);
            }
            #endregion

            #region 新增2
            List<SysJobLog> jobList = new List<SysJobLog>();
            for (int i = 0; i < 100; i++)
            {
                SysJobLog sysJobLog = new SysJobLog()
                {
                    JobLogType = 1,
                    Message = "aaaa" + i,
                    Name = "a",
                    ServerIp = "127.0.0.1",
                    TaskLogType = 1,
                    CreateTime = DateTime.Now,
                };
                jobList.Add(sysJobLog);
            }
            intFlag = service.Insert(jobList);
            Console.WriteLine("新增数据状态值（返回List集合数）：" + intFlag);
            #endregion
        }

        static void Update()
        {
            #region 修改1，一条记录修改
            var entity = service.FirstOrDefault<SysJobLog>(q => q.JobLogId == 3);
            entity.Message = "我是第一条修改1";
            intFlag = service.Update(entity);
            Console.WriteLine("第一条数据修改状态：" + intFlag);

            var entity1 = service.First<SysJobLog>(q => q.JobLogId == 4);
            entity1.Message = "我是第二条修改11";
            intFlag = service.Update(entity1);
            Console.WriteLine("第二条数据修改状态：" + intFlag);
            #endregion

            #region 修改2，多条记录一起修改
            List<int> ints = new List<int>() {
                    { 5},
                    { 6},
                    { 7},
                };
            var list = service.GetList<SysJobLog>(q => ints.Contains(q.JobLogId));
            foreach (var item in list)
            {
                item.Message = "我是循环被修改的値";
            }
            intFlag = service.Update(list);
            Console.WriteLine("循环修改状态：" + intFlag);
            #endregion

            #region 修改3，目前还不支持
            //intFlag = service.Update<SysJobLog>(o => new SysJobLog() { Message = "这是lambda修改" }, q => q.Message == "aaaa1" && q.JobLogType == 1);
            //Console.WriteLine("表达式修改状态：" + intFlag);
            #endregion

        }
        static void Delete()
        {
            var entity = service.GetByKey<SysJobLog>(8);
            intFlag = service.Delete(entity);
            Console.WriteLine("实体删除状态：" + intFlag);

            List<int> ints = new List<int>() {
                    { 9},
                    { 10},
                    { 11},
                };
            var list = service.GetList<SysJobLog>(q => ints.Contains(q.JobLogId));
            intFlag = service.Delete(list);
            Console.WriteLine("批量实体删除状态：" + intFlag);



            intFlag = service.Delete<SysJobLog>(q => q.Message == "我是循环被修改的値");
            Console.WriteLine("表达示删除状态：" + intFlag);
        }
    }
}