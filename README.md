# DMS.EntityFrameworkCore


一、基于EntityFrameworkCore框架扩展的基础组件，目前以泛型的方式实现添删改查等操作，其中包扩展分页查询，分组，排序等方法，目前还在完善中

二、实例操作
1、GET查询
//FirstOrDefault查询
var entity = service.FirstOrDefault(q => q.JobLogId == 8);

//First查询
entity = service.First(q => q.JobLogId == 9);

//数据集合
var list = service.GetList(q => q.Message == "我是循环被修改的値");

//分页
var dataList = service.GetQueryable().Where(q => q.Message == "aaaa9").OrderByDescending(q => q.JobLogId).ToPageList(1, 20);

2、COUNT/LongCount查询
//COUNT查询
var count = service.Count();
count = service.Count(q => q.Message == "aaaa10");

//LongCount查询
var longCount = service.LongCount();
longCount = service.LongCount(q => q.Message == "aaaa10");

3、Insert操作
//单条数据插入
  SysJobLog sysJobLog = new SysJobLog()
   {
    JobLogType = 1,
    Message = "aaaa" + i,
    Name = "a",
    ServerIp = "127.0.0.1",
    TaskLogType = 1,
    CreateTime = DateTime.Now,
    };
  var intFlag = service.Insert(sysJobLog);
  
//批量数据插入
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
var intFlag = service.Insert(jobList);
                        
                        
4、Update操作  
//单条记录修改
var entity = service.FirstOrDefault(q => q.JobLogId == 3);
entity.Message = "我是第一条修改1";
intFlag = service.Update(entity);
Console.WriteLine("第一条数据修改状态：" + intFlag);  


var entity1 = service.First(q => q.JobLogId == 4);
entity1.Message = "我是第二条修改11";
intFlag = service.Update(entity1);
Console.WriteLine("第二条数据修改状态：" + intFlag);

//多条记录修改
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
            

//lambda修改，目前还在完善中。。。
intFlag = service.Update(q => q.Message == "aaaa1" && q.JobLogType == 1, o => new SysJobLog() { Message = "这是lambda修改" });
Console.WriteLine("表达式修改状态：" + intFlag);


//删除操作
var entity = service.GetByKey<int>(8);
intFlag = service.Delete(entity);
Console.WriteLine("实体删除状态：" + intFlag);
  
//批量删除
List<int> ints = new List<int>() {
                    { 9},
                    { 10},
                    { 11},
                };
var list = service.GetList(q => ints.Contains(q.JobLogId));
intFlag = service.Delete(list);
Console.WriteLine("批量实体删除状态：" + intFlag);

//主键删除
intFlag = service.Delete(12);
Console.WriteLine("ID删除状态：" + intFlag);

//lambda删除
intFlag = service.Delete(q => q.Message == "我是循环被修改的値");
Console.WriteLine("表达示删除状态：" + intFlag);
            
            

                        
                        
