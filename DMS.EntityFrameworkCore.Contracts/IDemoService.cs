using DMS.BaseFramework.Common.BaseResult;
using DMS.EntityFrameworkCore.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.EntityFrameworkCore.Contracts
{
    /// <summary>
    /// 扩展接口，一般继承类没有的接口
    /// </summary>
    public interface IDemoService
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
    }
}