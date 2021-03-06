﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.EntityFrameworkCore.Contracts;
using DMS.EntityFrameworkCore.Repository.Models;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {    
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
