using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DMS.EntityFrameworkCore.Extension
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {

        private DbContext _context;
        public ServiceBase(DbContext context)
        {
            this._context = context;
        }

        public DbContext DbContext
        {
            get
            {
                return this._context;
            }
        }

        /// <summary>
        /// 公用泛型处理属性
        /// 注:所有泛型操作的基础
        /// </summary>
        public DbSet<T> DbSet
        {
            get { return this._context.Set<T>(); }
        }



        #region Get操作
        public T FirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _context.Set<T>()
                               .FirstOrDefault(predicate);
            }
            return _context.Set<T>().FirstOrDefault();
        }

        /// <summary>
        /// 如果查不数据直接报错
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T First(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                try
                {
                    return _context.Set<T>()
                                   .First(predicate);
                }
                catch
                {
                    return default(T);
                }
            }
            return _context.Set<T>().First();
        }

        public List<T> GetList(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _context.Set<T>().AsNoTracking().ToList();
            }
            else
            {
                return _context.Set<T>().Where(predicate).ToList();
            }

        }
        #endregion

        #region 根据主键获取实体
        public T GetByKey(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T GetByKey(long id)
        {
            return _context.Set<T>().Find(id);
        }
        public T GetByKey(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public T GetByKey<TKeyType>(TKeyType id)
        {
            return _context.Set<T>().Find(id);
        }
        #endregion

        #region 新增实体
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Insert(T entity)
        {
            if (entity != null)
            {
                return _context.Insert(entity);
            }
            return 0;
        }
        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Insert(List<T> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                return _context.Insert<T>(entities);
            }
            return 0;
        }
        #endregion

        #region 删除实体
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(T entity)
        {
            if (entity != null)
            {
                return _context.Delete(entity);
            }
            return 0;
        }
        public int Delete(List<T> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                return _context.Delete(entities);
            }
            return 0;
        }
        public int Delete(int key)
        {
            T entity = this.GetByKey(key);
            if (entity != null)
            {
                return Delete(entity);
            }
            return 0;
        }
        public int Delete(Guid key)
        {
            T entity = this.GetByKey(key);
            if (entity != null)
            {
                return Delete(entity);
            }
            return 0;
        }

        public int Delete(Expression<Func<T, bool>> predicate)
        {
            return _context.Delete(predicate);
        }
        #endregion

        #region 修改实体
        public int Update(T entity)
        {
            if (entity != null)
            {
                return _context.Modifiy(entity);
            }
            return 0;
        }
        public int Update(List<T> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                return _context.Modifiy<T>(entities);
            }
            return 0;
        }


        /// <summary>
        /// 目前还不支持
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        public int Update(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateExpression)
        {
            return _context.Modifiy(predicate, updateExpression);
        }
        #endregion

        #region Count
        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _context.Set<T>()
                               .Count(predicate);
            }
            return _context.Set<T>().Count();
        }
        public long LongCount(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _context.Set<T>()
                               .LongCount(predicate);
            }
            return _context.Set<T>().LongCount();
        }
        #endregion

        public IQueryable<T> GetQueryable()
        {
            return this.DbContext.Set<T>().AsQueryable();
        }

        ~ServiceBase()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }
    }

}
