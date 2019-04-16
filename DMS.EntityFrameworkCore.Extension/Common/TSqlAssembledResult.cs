using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DMS.EntityFrameworkCore.Extension.Common
{
    public class TSqlAssembledResult
    {
        /// <summary>
        /// 编译后的参数集合
        /// </summary>
        public SqlParameter[] SqlParameters { get; set; }
        /// <summary>
        /// 编译后的SQL字符串
        /// </summary>
        public string SqlStr { get; set; }
    }
}
