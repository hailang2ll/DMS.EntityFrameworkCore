using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DMS.EntityFrameworkCore.Extension
{
    public interface IServiceBase<T> where T : class
    {

        T FirstOrDefault(Expression<Func<T, bool>> predicate = null);
        T First(Expression<Func<T, bool>> predicate = null);
        List<T> GetList(Expression<Func<T, bool>> predicate = null);

        T GetByKey(int id);
        T GetByKey(long id);
        T GetByKey(Guid id);
        T GetByKey<TKeyType>(TKeyType id);

        int Insert(T entity);
        int Insert(List<T> entities);


        int Delete(T entity);
        int Delete(List<T> entities);
        int Delete(int key);
        int Delete(Guid key);
        int Delete(Expression<Func<T, bool>> predicate);

        int Update(T entity);
        int Update(List<T> entities);
        int Update(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateExpression);


        int Count(Expression<Func<T, bool>> predicate = null);
        long LongCount(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetQueryable();
       

    }
}
