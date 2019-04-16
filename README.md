## DMS.EntityFrameworkCore           
           
           
### 基于EntityFrameworkCore框架扩展的基础组件，依赖DMS中基础框架，目前以泛型的方式实现添删改查，支持同步与异步操作，支持复杂的查询，Lambda表达式动态查询            
           
### 实例操作             
### 1、GET查询             
### FirstOrDefault查询  
```c#           
var entity = service.FirstOrDefault(q => q.JobLogId == 8);  
```             
### First查询    
```c#           
entity = service.First(q => q.JobLogId == 9);           
```     
### 数据集合   
```c#            
var list = service.GetList(q => q.Message == "我是循环被修改的値");             
```    
### 分页   
```c#            
var dataList = service.GetQueryable().Where(q => q.Message == "aaaa9").OrderByDescending(q => q.JobLogId).ToPageList(1, 20);             
```   
### 2、COUNT/LongCount查询               
### COUNT查询   
```c#              
var count = service.Count();             
count = service.Count(q => q.Message == "aaaa10");             
```      
### LongCount查询    
```c#           
var longCount = service.LongCount();             
longCount = service.LongCount(q => q.Message == "aaaa10");             
```      
### 3、Insert操作             
### 单条数据插入 
```c#              
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
```            
### 批量数据插入   
```c#              
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
```                               
                                   
### 4、Update操作              
### 单条记录修改   
```c#            
var entity = service.FirstOrDefault(q => q.JobLogId == 3);             
entity.Message = "我是第一条修改1";             
intFlag = service.Update(entity);             
Console.WriteLine("第一条数据修改状态：" + intFlag);               
```           
```c#         
var entity1 = service.First(q => q.JobLogId == 4);             
entity1.Message = "我是第二条修改11";             
intFlag = service.Update(entity1);             
Console.WriteLine("第二条数据修改状态：" + intFlag);             
```       
### 多条记录修改  
```c#             
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
```
           
### lambda修改    
```c#           
intFlag = service.Update(q => q.Message == "aaaa1" && q.JobLogType == 1, o => new SysJobLog() { Message = "这是lambda修改" });             
Console.WriteLine("表达式修改状态：" + intFlag);             
```        
### 5、删除操作  
### 删除操作   
```c#            
var entity = service.GetByKey<int>(8);             
intFlag = service.Delete(entity);             
Console.WriteLine("实体删除状态：" + intFlag);             
```        
### 批量删除   
```c#            
List<int> ints = new List<int>() {             
                    { 9},             
                    { 10},             
                    { 11},             
                };           
var list = service.GetList(q => ints.Contains(q.JobLogId));             
intFlag = service.Delete(list);             
Console.WriteLine("批量实体删除状态：" + intFlag);             
```        
### 主键删除   
```c#            
intFlag = service.Delete(12);              
Console.WriteLine("ID删除状态：" + intFlag);             
```         
### lambda删除    
```c#           
intFlag = service.Delete(q => q.Message == "我是循环被修改的値");             
Console.WriteLine("表达示删除状态：" + intFlag);              
```                    
                       
           
                                   
                                   
