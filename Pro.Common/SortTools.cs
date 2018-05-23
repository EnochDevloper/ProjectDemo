using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Common
{
    public static class SortTools
    {
        #region 根据字段排序
        public static IQueryable<T> DataSorting<T>(IQueryable<T> source, string sortExpression, string sortDirection)
        {
            string sortingDir = string.Empty;
            if (sortDirection.ToUpper().Trim() == "ASC")
                sortingDir = "OrderBy";
            else if (sortDirection.ToUpper().Trim() == "DESC")
                sortingDir = "OrderByDescending";

            PropertyInfo[] properties = typeof(T).GetProperties();
            ParameterExpression param = null;
            if (string.IsNullOrEmpty(sortExpression))
            {
                param = Expression.Parameter(typeof(T), properties[0].Name);
                sortExpression = properties[0].Name;
            }
            else
            {
                param = Expression.Parameter(typeof(T), sortExpression);
            }

            PropertyInfo pi = typeof(T).GetProperty(sortExpression);
            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            return query;
        }

        public static IQueryable<T> DataPaging<T>(IQueryable<T> source, int pageNumber, int pageSize)
        {
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        ///  处理数据集合
        /// </summary>
        /// <param name="sort">排序字段-排序方式</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="isSort">是否开启分页  默认开启</param>
        /// <returns></returns>
        public static IQueryable<T> SortingAndPaging<T>(IQueryable<T> source, string sort, int pageNumber, int pageSize, bool isSort = true)
        {
            IQueryable<T> query = null;
            if (!string.IsNullOrEmpty(sort) && sort.Contains('-'))
            {
                string sortExpression = sort.Split('-')[0];
                string sortDirection = sort.Split('-')[1];
                query = DataSorting<T>(source, sortExpression, sortDirection);


            }
            else
            {
                query = DataSorting<T>(source, "", "asc");
            }

            if (isSort)
            {
                return DataPaging(query, pageNumber, pageSize);
            }
            else
            {
                return query;
            }

        }
        #endregion
    }
}
