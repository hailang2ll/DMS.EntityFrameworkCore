## DMS.EntityFrameworkCore           
           
           
### 基于EntityFrameworkCore框架扩展的基础组件，依赖DMS中基础框架，目前以泛型的方式实现添删改查，支持同步与异步操作，支持复杂的查询，同时支持批量更新，批量删除等操作，以及Lambda表达式动态查询          
qq交流群：18362376
<br />
作者微信：tangguo_9669

![运营公众号](https://github.com/hailang2ll/DMS.EntityFrameworkCore/blob/master/gzh02.jpg)
<br />
         
### 1、GET查询，所有接口实现   
```c#     
T FirstOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : class;
Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
T First<T>(Expression<Func<T, bool>> predicate = null) where T : class;
Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
T LastOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : class;
Task<T> LastOrDefaultAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
List<T> GetList<T>(Expression<Func<T, bool>> predicate = null, bool isTracking = true) where T : class;
Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> predicate = null, bool isTracking = true) where T : class;
T GetByKey<T>(params object[] keyVaules) where T : class;
Task<T> GetByKeyAsync<T>(params object[] keyVaules) where T : class;
int Count<T>(Expression<Func<T, bool>> predicate = null) where T : class;
Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
long LongCount<T>(Expression<Func<T, bool>> predicate = null) where T : class;
Task<long> LongCountAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
```    
### 查询实现例子
```c#           
var entity = service.FirstOrDefault(q => q.JobLogId == 8);  
var entity = service.FirstOrDefaultAsync(q => q.JobLogId == 8);  
var entity = service.First(q => q.JobLogId == 9); 
var entity = service.FirstAsync(q => q.JobLogId == 9); 
var entity = service.LastOrDefault(q => q.JobLogId == 8);
var entity = service.LastOrDefaultAsync(q => q.JobLogId == 8);  
var list = service.GetList(q => q.Message == "我是循环被修改的値");   
var list = service.GetListAsync(q => q.Message == "我是循环被修改的値");  
var dataList = service.GetQueryable().Where(q => q.Message == "aaaa9").OrderByDescending(q => q.JobLogId).ToPageList(1, 20); 
var dataList = service.GetQueryable().Where(q => q.Message == "aaaa9").OrderByDescending(q => q.JobLogId).ToPageListAsync(1, 20); 
var count = service.Count();             
var count = service.Count(q => q.Message == "aaaa10");  
```             
  
   
### 2、Insert操作，所有接口实现
```c#  
int Insert<T>(T entity) where T : class;
Task<long> InsertAsync<T>(T entity) where T : class;
int Insert<T>(List<T> entities) where T : class;
Task<long> InsertAsync<T>(List<T> entities) where T : class;
```   
### 插入实现例子
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
                                   
### 3、Update操作，所有接口实现  
```c#  
int Update<T>(T entity) where T : class;
Task<int> UpdateAsync<T>(T entity) where T : class;
int Update<T>(List<T> entities) where T : class;
Task<int> UpdateAsync<T>(List<T> entities) where T : class;
int Update<T>(Expression<Func<T, bool>> where) where T : class;
Task<int> UpdateAsync<T>(Expression<Func<T, bool>> where) where T : class;
int UpdateBulk<T>(Expression<Func<T, T>> set, Expression<Func<T, bool>> where) where T : class, new();
Task<int> UpdateBulkAsync<T>(Expression<Func<T, T>> set, Expression<Func<T, bool>> where) where T : class, new();
```  
### 修改实例，批量修改
```c#                     
var intFlag = service.Update(entity); 
var intFlag = service.UpdateAsync(entity); 
var intFlag = service.Update(list); 
var intFlag = service.UpdateAsync(list); 
var intFlag = service.UpdateBulk<SysJobLog>(o => new SysJobLog() { Message = "这是lambda修改" }, q => q.Message.Contains("我是循环") && q.JobLogType <= 10); 
var intFlag = service.UpdateBulkAsync<SysJobLog>(o => new SysJobLog() { Message = "这是lambda修改" }, q => q.Message.Contains("我是循环") && q.JobLogType <= 10); 
```                
                 
### 4、删除操作，所有接口实现  
```c#  
int Delete<T>(T entity) where T : class;
Task<long> DeleteAsync<T>(T entity) where T : class;
int Delete<T>(List<T> entities) where T : class;
Task<long> DeleteAsync<T>(List<T> entities) where T : class;
int Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
Task<long> DeleteAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
int DeleteBulk<T>(Expression<Func<T, bool>> where) where T : class, new();
Task<int> DeleteBulkAsync<T>(Expression<Func<T, bool>> where) where T : class, new();
``` 
### 删除操作实例   
```c#                       
var intFlag = service.Delete(entity); 
var intFlag = service.DeleteAsync(entity); 
var intFlag = service.Delete(list);
var intFlag = service.DeleteAsync(list); 
var intFlag = service.Delete(q => q.Message == "我是循环被修改的値");  
var intFlag = service.DeleteAsync(q => q.Message == "我是循环被修改的値"); 
var intFlag = service.Delete(12);  
var intFlag = service.DeleteBulk<SysJobLog>(q => q.JobLogId <= 7) 
var intFlag = service.DeleteBulkAsync<SysJobLog>(q => q.JobLogId <= 7) 
```             
                       
           
                                   
                                   
