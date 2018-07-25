using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMS.EntityFrameworkCore.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceBase : IServiceBase
    {
        /// <summary>
        /// 
        /// </summary>
        private DbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ServiceBase(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        public DbContext DbContext
        {
            get
            {
                return _context;
            }
        }

        #region Get操作
        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T FirstOrDefault<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return _context.Set<T>().FirstOrDefault(predicate);
            }
            return _context.Set<T>().FirstOrDefault();
        }

        /// <summary>
        /// 如果查不数据直接报错
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T First<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                try
                {
                    return _context.Set<T>().First(predicate);
                }
                catch
                {
                    return default(T);
                }
            }
            return _context.Set<T>().First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> GetList<T>(Expression<Func<T, bool>> predicate = null) where T : class
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
        /// <summary>
        /// 更具表的主键获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByKey<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByKey<T>(long id) where T : class
        {
            return _context.Set<T>().Find(id);
        }
        public T GetByKey<T>(Guid id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKeyType"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByKey<T, TKeyType>(TKeyType id) where T : class
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
        public virtual int Insert<T>(T entity) where T : class
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
        public int Insert<T>(List<T> entities) where T : class
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
        public int Delete<T>(T entity) where T : class
        {
            if (entity != null)
            {
                return _context.Delete(entity);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Delete<T>(List<T> entities) where T : class
        {
            if (entities != null && entities.Count > 0)
            {
                return _context.Delete(entities);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Delete<T>(int key) where T : class
        {
            T entity = GetByKey<T>(key);
            if (entity != null)
            {
                return Delete(entity);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Delete<T>(Guid key) where T : class
        {
            T entity = this.GetByKey<T>(key);
            if (entity != null)
            {
                return Delete(entity);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Delete(predicate);
        }
        #endregion

        #region 修改实体
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update<T>(T entity) where T : class
        {
            if (entity != null)
            {
                return _context.Modifiy(entity);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Update<T>(List<T> entities) where T : class
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
        public int Update<T>(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateExpression) where T : class
        {
            return _context.Modifiy(predicate, updateExpression);
        }
        #endregion

        #region Count
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return _context.Set<T>().Count(predicate);
            }
            return _context.Set<T>().Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public long LongCount<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate != null)
            {
                return _context.Set<T>()
                               .LongCount(predicate);
            }
            return _context.Set<T>().LongCount();
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetQueryable<T>() where T : class
        {
            return DbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~ServiceBase()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}