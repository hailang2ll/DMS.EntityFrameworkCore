using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMS.EntityFrameworkCore.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServiceBase
    {
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : class;
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
        int Update<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateExpression) where T : class;

        int Count<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        long LongCount<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        IQueryable<T> GetQueryable<T>() where T : class;
    }
}