using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DMS.EntityFrameworkCore.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            DMS.NLogs.Logger.Info("Index=>这是nlog的日志");
            DMS.NLogs.Logger.Error("Index=>这是nlog的异常日志");
            return Ok("我是DMS.EntityFrameworkCore.Api首页");
        }
    }
}