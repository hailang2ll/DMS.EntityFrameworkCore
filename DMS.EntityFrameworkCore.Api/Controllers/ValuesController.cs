using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.EntityFrameworkCore.Service;
using Microsoft.AspNetCore.Mvc;


/*
 * 文档接口：Swashbuckle.AspNetCore 3.0（后续通过源码更改）
 * 数据接口主要看ServiceBase类的继承
 * 
 * 分布式日志收集地址：http://192.168.0.100:9002
 * 帐号：xiaol@jinglih.com，密码：123456
 * 备注：每一个业务系统对应一个日志项目，同时ApiKey的值对应也得修改
 */
namespace DMS.EntityFrameworkCore.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public SysJobLogService service = new SysJobLogService();

        /// <summary>
        /// 同步示例接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var entity1 = service.GetEntity(13);
            //var isSuccess = service.Add();
            //var pageList = service.GetPageList(1, 15, string.Empty);

            var list = service.GetListExt("我是","b");
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 异步示例接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            var entity1 = await service.GetEntityAsync(13);
            var isSuccess = await service.AddAsync();
            var pageList = await service.GetPageListAsync(1, 15, string.Empty);
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
