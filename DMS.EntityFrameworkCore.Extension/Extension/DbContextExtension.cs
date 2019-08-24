using DMS.Common.BaseResult;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DMS.EntityFrameworkCore.Extension
{
    /*
 Added 对象为新对象，并且已添加到对象上下文，但尚未调用 SaveChanges 方法。 在保存更改后，对象状态将更改为 Unchanged。 状态为 Added 的对象在 ObjectStateEntry 中没有原始值。  
 Deleted 对象已从对象上下文中删除。 在保存更改后，对象状态将更改为 Detached。  
 Detached 对象存在，但没有被跟踪。 在创建实体之后、但将其添加到对象上下文之前，该实体处于此状态。 通过调用 Detach 方法从上下文中移除实体后，或者使用 NoTrackingMergeOption 加载实体后，该实体也会处于此状态。 没有 ObjectStateEntry 实例与状态为 Detached 的对象关联。  
 Modified 对象上的一个标量属性已更改，但尚未调用 SaveChanges 方法。 在不带更改跟踪代理的 POCO 实体中，调用 DetectChanges 方法时，已修改属性的状态将更改为 Modified。 在保存更改后，对象状态将更改为 Unchanged。  
 Unchanged 自对象附加到上下文中后，或自上次调用 SaveChanges 方法后，此对象尚未经过修改。 
 */
    public static class DbContextExtension
    {

        #region Add 添加，批量添加
        /// <summary>
        /// 添加一条实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int Insert<T>(this DbContext context, T entity) where T : class
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }
        public static async Task<int> InsertAsync<T>(this DbContext context, T entity) where T : class
        {
            await context.Set<T>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static int Insert<T>(this DbContext context, List<T> entities) where T : class
        {
            if (entities.Count() == 0) return 0;
            foreach (T entity in entities)
            {
                context.Set<T>().Add(entity);
            }
            return context.SaveChanges();
        }
        public static async Task<int> InsertAsync<T>(this DbContext context, List<T> entities) where T : class
        {
            if (entities.Count() == 0) return 0;
            foreach (T entity in entities)
            {
                await context.Set<T>().AddAsync(entity);
            }
            return await context.SaveChangesAsync();
        }
        #endregion

        #region Delete 删除，批量删除，Lambda表达示
        /// <summary>
        /// 根据主健删除一条实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int Delete<T>(this DbContext context, T entity) where T : class
        {
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);

            //var entry = context.Entry(entity);
            //if (entry.State == EntityState.Detached)
            //{
            //    context.Set<T>().Attach(entity);
            //}
            //entry.State = EntityState.Deleted;

            return context.SaveChanges();
        }
        public static async Task<int> DeleteAsync<T>(this DbContext context, T entity) where T : class
        {
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static int Delete<T>(this DbContext context, List<T> entities) where T : class
        {
            if (entities.Count() == 0) return 0;
            foreach (T entity in entities)
            {
                context.Set<T>().Attach(entity);
                context.Set<T>().Remove(entity);
            }
            return context.SaveChanges();
        }
        public static async Task<int> DeleteAsync<T>(this DbContext context, List<T> entities) where T : class
        {
            if (entities.Count() == 0)
                return 0;

            foreach (T entity in entities)
            {
                context.Set<T>().Attach(entity);
                context.Set<T>().Remove(entity);
            }
            return await context.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int Delete<T>(this DbContext context, Expression<Func<T, bool>> predicate) where T : class
        {
            int rows = 0;
            IQueryable<T> entry = context.Set<T>().Where(predicate);
            //IQueryable<T> entry = (predicate == null) ? context.Set<T>().AsQueryable() : context.Set<T>().Where(predicate);
            List<T> list = entry.ToList();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    context.Set<T>().Remove(list[i]);
                }
                rows = context.SaveChanges();
            }
            return rows;
        }
        public static async Task<int> DeleteAsync<T>(this DbContext context, Expression<Func<T, bool>> predicate) where T : class
        {
            int rows = 0;
            IQueryable<T> entry = context.Set<T>().Where(predicate);
            List<T> list = entry.ToList();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    context.Set<T>().Remove(list[i]);
                }
                rows = await context.SaveChangesAsync();
            }
            return rows;
        }
        #endregion

        #region Modifiy 修改，批量修改，Lambda表达示
        /// <summary>
        /// 修改公共方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        private static void ModifiyInternal<T>(this DbContext context, T entity) where T : class
        {
            var entry = context.Entry<T>(entity);
            if (entry.State == EntityState.Detached)
            {
                context.Set<T>().Attach(entity);
            }
            entry.State = EntityState.Modified;
        }
        /// <summary>
        /// 修改实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int Modifiy<T>(this DbContext context, T entity) where T : class
        {
            ModifiyInternal(context, entity);
            return context.SaveChanges();
        }
        public static async Task<int> ModifiyAsync<T>(this DbContext context, T entity) where T : class
        {
            ModifiyInternal(context, entity);
            return await context.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static int Modifiy<T>(this DbContext context, List<T> entities) where T : class
        {
            if (entities.Count() == 0) return 0;
            foreach (T entity in entities)
            {
                ModifiyInternal(context, entity);
            }
            return context.SaveChanges();
        }
        public static async Task<int> ModifiyAsync<T>(this DbContext context, List<T> entities) where T : class
        {
            if (entities.Count() == 0) return 0;
            foreach (T entity in entities)
            {
                ModifiyInternal(context, entity);
            }
            return await context.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="predicate"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        public static int Modifiy<T>(this DbContext context,Expression<Func<T, bool>> where) where T : class
        {
            #region 注释
            //DmlExpressionParser<T> updateExpressionParser = new UpdateExpressionParser<T>(context.Database.ProviderName, set, where);
            //string script = updateExpressionParser.GetDmlCommand();
            //rows = context.Database.ExecuteSqlCommand(script);
            //return rows;

            //IQueryable<T> entry = context.Set<T>().Where(where);
            //IQueryable<T> entry = (predicate == null) ? context.Set<T>().AsQueryable() : context.Set<T>().Where(predicate);
            //string propertyName = "";
            //var memberInitExpression = set.Body as MemberInitExpression;
            //foreach (MemberBinding binding in memberInitExpression.Bindings)
            //{
            //    propertyName = binding.Member.Name;

            //    var memberAssignment = binding as MemberAssignment;
            //    Expression memberExpression = memberAssignment.Expression;

            //    object value;
            //    if (memberExpression.NodeType == ExpressionType.Constant)
            //    {
            //        var constantExpression = memberExpression as ConstantExpression;
            //        if (constantExpression == null)
            //            throw new ArgumentException(
            //                "The MemberAssignment expression is not a ConstantExpression.", "updateExpression");

            //        value = constantExpression.Value;
            //    }
            //    else
            //    {
            //        LambdaExpression lambda = Expression.Lambda(memberExpression, null);
            //        value = lambda.Compile().DynamicInvoke();
            //    }
            //}



            //MemberInitExpression initExpression = set.Body as MemberInitExpression;
            //if (initExpression != null)
            //{
            //    Type type = typeof(T);

            //    List<MemberAssignment> memberAssignments = (from m in initExpression.Bindings.OfType<MemberAssignment>() select m).ToList();

            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("UPDATE ");
            //    sb.Append(type.Name);
            //    sb.Append("SET ");
            //    foreach (var item in memberAssignments)
            //    {
            //        sb.Append(item.ToString().Replace("\"", "'"));
            //        sb.Append(" , ");
            //    }
            //    //context.Database.ExecuteSqlCommand("");
            //    //var result = (from m in initExpression.Bindings.OfType<MemberAssignment>()
            //    //              select new { PropertyName = m.Member.Name }).ToList();
            //    //var map = MetadataAccessor.GetTableNameByEdmType<T>(containerName);

            //    //StringBuilder sb = new StringBuilder();
            //    //sb.Append("SET ").
            //    //Append(map[result[0].PropertyName])
            //    //.Append("=")
            //    //.Append(result[0].Value.Replace("\"", "'"));

            //    //for (int i = 1; i < result.Count; i++)
            //    //{
            //    //    sb.Append(",");
            //    //    sb.Append(map[result[i].PropertyName]);//MetadataAccessor.GetColumnNameByEdmProperty<T>(result[i].PropertyName));
            //    //    sb.Append("=");
            //    //    sb.Append(result[i].Value.Replace("\"", "'"));
            //    //}
            //}
            #endregion

            int rows = 0;
            IQueryable<T> entry = context.Set<T>().Where(where);
            List<T> list = entry.ToList();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    ModifiyInternal(context, item);
                }
                rows = context.SaveChanges();
            }
            return rows;
        }
        public static async Task<int> ModifiyAsync<T>(this DbContext context, Expression<Func<T, bool>> where) where T : class
        {
            #region 扩展方法
            //TSqlAssembledResult result = TSqlAssembled.Update<T>(set, where);
            //context.Database.ExecuteSqlCommand(result.SqlStr);
            //return await context.SaveChangesAsync();
            #endregion

            int rows = 0;
            IQueryable<T> entry = context.Set<T>().Where(where);
            List<T> list = await entry.ToListAsync();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    ModifiyInternal(context, item);
                }
                rows = await context.SaveChangesAsync();
            }
            return rows;
        }
        #endregion

        #region ToPageList 取得分页数据源
        /// <summary>
        /// 取得分页数据源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static DataResultList<T> ToPageList<T>(this DbContext context, int pageIndex, int pageSize) where T : class
        {
            IQueryable<T> query = context.Set<T>().AsQueryable();
            return query.ToPageList<T>(pageIndex, pageSize);
        }
        public static async Task<DataResultList<T>> ToPageListAsync<T>(this DbContext context, int pageIndex, int pageSize) where T : class
        {
            IQueryable<T> query = context.Set<T>().AsQueryable();
            return await query.ToPageListAsync(pageIndex, pageSize);
        }
        #endregion

    }
}