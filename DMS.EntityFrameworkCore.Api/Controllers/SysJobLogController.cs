using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.EntityFrameworkCore.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMS.EntityFrameworkCore.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SysJobLogController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public ISysJobLogService service { get; set; }

        /// <summary>
        /// api/SysJobLog
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            //var entity = service.GetEntity(3);
            //var entity = await service.GetFromSql();
            await service.AddAsync();

            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// api/SysJobLog/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// api/SysJobLog
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// api/SysJobLog/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// api/ApiWithActions/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
