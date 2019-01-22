using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DMS.EntityFrameworkCore.Extension
{
    /// <summary>
    /// 服务基础接口
    /// </summary>
    public interface IServiceBase
    {
        #region 同步
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        T LastOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        T First<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        List<T> GetList<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        T GetByKey<T>(int id) where T : class;
        T GetByKey<T>(long id) where T : class;
        T GetByKey<T>(Guid id) where T : class;
        T GetByKey<T, TKeyType>(TKeyType id) where T : class;

        int Insert<T>(T entity) where T : class;
        int Insert<T>(List<T> entities) where T : class;

        int Delete<T>(T entity) where T : class;
        int Delete<T>(List<T> entities) where T : class;
        int Delete<T>(int key) where T : class;
        int Delete<T>(Guid key) where T : class;
        int Delete<T>(Expression<Func<T, bool>> predicate) where T : class;

        int Update<T>(T entity) where T : class;
        int Update<T>(List<T> entities) where T : class;
        int Update<T>(Expression<Func<T, T>> set, Expression<Func<T, bool>> where) where T : class;

        int Count<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        long LongCount<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        #endregion

        #region 异步
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        Task<T> LastOrDefaultAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;

        Task<T> GetByKeyAsync<T>(int id) where T : class;
        Task<T> GetByKeyAsync<T>(long id) where T : class;
        Task<T> GetByKeyAsync<T>(Guid id) where T : class;
        Task<T> GetByKeyAsync<T, TKeyType>(TKeyType id) where T : class;

        Task<long> InsertAsync<T>(T entity) where T : class;
        Task<long> InsertAsync<T>(List<T> entities) where T : class;

        Task<long> DeleteAsync<T>(T entity) where T : class;
        Task<long> DeleteAsync<T>(List<T> entities) where T : class;
        Task<long> DeleteAsync<T>(int key) where T : class;
        Task<long> DeleteAsync<T>(Guid key) where T : class;
        Task<long> DeleteAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        Task<long> UpdateAsync<T>(T entity) where T : class;
        Task<long> UpdateAsync<T>(List<T> entities) where T : class;
        Task<long> UpdateAsync<T>(Expression<Func<T, T>> set, Expression<Func<T, bool>> where) where T : class;

        Task<int> CountAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        Task<long> LongCountAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        #endregion

        IQueryable<T> GetQueryable<T>() where T : class;
    }
}