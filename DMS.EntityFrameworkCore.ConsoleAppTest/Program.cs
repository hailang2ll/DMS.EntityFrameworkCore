using DMS.EntityFrameworkCore.Extension;
using DMS.EntityFrameworkCore.Repository.Models;
using DMS.EntityFrameworkCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMS.BaseFramework.EFCore.ConsoleAppTest
{
    class Program
    {
        static int intFlag = 0;
        static SysJobLogService service = new SysJobLogService();

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
            var entity = service.FirstOrDefault(q => q.JobLogId == 8);
            if (entity == null)
            {
                Console.WriteLine("实体为空");
            }
            else
            {
                Console.WriteLine("查询一个实体：" + entity.Message);
            }

            entity = service.First(q => q.JobLogId == 9);
            var list = service.GetList(q => q.Message == "我是循环被修改的値");

            var dataList = service.GetQueryable().Where(q => q.Message == "aaaa9").OrderByDescending(q => q.JobLogId).ToPageList(1, 20);
        }

        static void Count()
        {
            var count = service.Count();
            count = service.Count(q => q.Message == "aaaa10");

            var longCount = service.LongCount();
            longCount = service.LongCount(q => q.Message == "aaaa10");
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
            var entity = service.FirstOrDefault(q => q.JobLogId == 3);
            entity.Message = "我是第一条修改1";
            intFlag = service.Update(entity);
            Console.WriteLine("第一条数据修改状态：" + intFlag);

            var entity1 = service.First(q => q.JobLogId == 4);
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
            var list = service.GetList(q => ints.Contains(q.JobLogId));
            foreach (var item in list)
            {
                item.Message = "我是循环被修改的値";
            }
            intFlag = service.Update(list);
            Console.WriteLine("循环修改状态：" + intFlag);
            #endregion

            #region 修改3，目前还不支持
            intFlag = service.Update(q => q.Message == "aaaa1" && q.JobLogType == 1, o => new SysJobLog() { Message = "这是lambda修改" });
            Console.WriteLine("表达式修改状态：" + intFlag);
            #endregion

        }
        static void Delete()
        {
            var entity = service.GetByKey<int>(8);
            intFlag = service.Delete(entity);
            Console.WriteLine("实体删除状态：" + intFlag);

            List<int> ints = new List<int>() {
                    { 9},
                    { 10},
                    { 11},
                };
            var list = service.GetList(q => ints.Contains(q.JobLogId));
            intFlag = service.Delete(list);
            Console.WriteLine("批量实体删除状态：" + intFlag);

            intFlag = service.Delete(12);
            Console.WriteLine("ID删除状态：" + intFlag);

            intFlag = service.Delete(q => q.Message == "我是循环被修改的値");
            Console.WriteLine("表达示删除状态：" + intFlag);
        }

    }
}
