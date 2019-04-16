using DMS.BaseFramework.Common.BaseResult;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace DMS.EntityFrameworkCore.Extension
{
    /// <summary>
    /// 查询构造器扩展类
    /// </summary>
    public static class IQueryableExtension
    {
        #region ToPagerSource 分页查询
        /// <summary>
        /// 同步分页查询方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static DataResultList<T> ToPageList<T>(this IQueryable<T> query, int pageIndex, int pageSize) where T : class
        {
            DataResultList<T> result = new DataResultList<T>() { PageIndex = pageIndex, PageSize = pageSize, };
            result.TotalRecord = query.Count();
            if (result.TotalRecord > 0)
            {
                //if (!query.ToString().Contains("ORDER BY"))
                //{
                //    query = query.OrderBy(e => 0);
                //}
                if (pageIndex == 1)
                {
                    query = query.Take(result.PageSize);
                }
                else
                {
                    query = query.Skip((result.PageIndex - 1) * result.PageSize).Take(result.PageSize);
                }
                result.ResultList = query.ToList();
            }
            else
            {
                result.ResultList = new List<T>();
            }
            return result;
        }
        public static async Task<DataResultList<T>> ToPageListAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize) where T : class
        {
            DataResultList<T> result = new DataResultList<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            result.TotalRecord = await query.CountAsync();
            if (result.TotalRecord > 0)
            {
                //if (!query.ToString().Contains("ORDER BY"))
                //{
                //    query = query.OrderBy(e => 0);
                //}
                if (pageIndex == 1)
                {
                    query = query.Take(result.PageSize);
                }
                else
                {
                    query = query.Skip((result.PageIndex - 1) * result.PageSize).Take(result.PageSize);
                }
                result.ResultList = await query.ToListAsync();
            }
            else
            {
                result.ResultList = new List<T>();
            }
            return result;
        }
        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        //public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string columnName) where T : class
        //{
        //    return OrderByInternal(source, columnName, false, false);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        //public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string columnName) where T : class
        //{
        //    return OrderByInternal(source, columnName, true, false);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="columnName"></param>
        /// <param name="descending"></param>
        /// <param name="thenBy"></param>
        /// <returns></returns>
        //private static IQueryable<T> OrderByInternal<T>(this IQueryable<T> source, string columnName, bool descending, bool thenBy) where T : class
        //{
        //    Type type = typeof(T);
        //    PropertyInfo property = type.GetProperty(columnName);
        //    if (property == null)
        //        throw new ArgumentException("propertyName", "Not Exist");

        //    ParameterExpression param = Expression.Parameter(type, "p");
        //    Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
        //    LambdaExpression orderByExpression = Expression.Lambda(propertyAccessExpression, param);
        //    string methodName = string.Empty;

        //    if (descending && thenBy)
        //    {
        //        methodName = "ThenByDescending";
        //    }
        //    else if (descending && !thenBy)
        //    {
        //        methodName = "OrderByDescending";
        //    }
        //    else if (!descending && thenBy)
        //    {
        //        methodName = "ThenBy";
        //    }
        //    else if (!descending && !thenBy)
        //    {
        //        methodName = "OrderBy";
        //    }
        //    //string methodName = descending ? "OrderByDescending" : "OrderBy";
        //    MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));
        //    return source.Provider.CreateQuery<T>(resultExp);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        //public static IQueryable<T> ThenBy<T>(this IQueryable<T> source, string columnName) where T : class
        //{
        //    return OrderByInternal(source, columnName, false, true);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        //public static IQueryable<T> ThenByDescending<T>(this IQueryable<T> source, string columnName) where T : class
        //{
        //    return OrderByInternal(source, columnName, true, true);
        //}
    }
}