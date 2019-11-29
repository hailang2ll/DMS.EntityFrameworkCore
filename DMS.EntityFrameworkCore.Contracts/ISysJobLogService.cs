using DMS.Common.BaseResult;
using DMS.EntityFrameworkCore.Contracts.Result;
using DMS.EntityFrameworkCore.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.EntityFrameworkCore.Contracts
{
   public interface ISysJobLogService
    {
        /// <summary>
        /// 同步新增
        /// </summary>
        /// <returns></returns>
        ResponseResult Add();

        /// <summary>
        /// 异步新增
        /// </summary>
        /// <returns></returns>
        Task<ResponseResult> AddAsync();

        /// <summary>
        /// 同步查询示例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysJobLog GetEntity(int id);

        /// <summary>
        /// 异步查询示例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SysJobLog> GetEntityAsync(int id);

        List<SysJobLog> GetList(string searchText, string searchText2);
        Task<List<SysJobLog>> GetListAsync(string searchText, string searchText2);
        List<SysJobLog> GetListExt(string searchText, string searchText2);
        Task<List<SysJobLog>> GetListExtAsync(string searchText, string searchText2);

        /// <summary>
        /// 同步分页查询示例
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        ResponsePageResult<SysJobLog> GetPageList(int pageIndex, int pageSize, string searchText);

        /// <summary>
        /// 异步分页查询示例
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        Task<ResponsePageResult<SysJobLog>> GetPageListAsync(int pageIndex, int pageSize, string searchText);

        Task<SysJobLog> GetFromSql();
    }
}
