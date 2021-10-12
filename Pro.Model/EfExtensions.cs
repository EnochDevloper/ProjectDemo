using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EntityFramework.Extensions;


public static class EfExtensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        if (condition)
            return query.Where(predicate);
        return query;
    }


    public static int Updates<TEntity>(this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression, List<string> NoModifyList = null, bool IsInList = false) where TEntity : class
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (updateExpression == null)
            throw new ArgumentNullException("filterExpression");
        #region 这段是新增代码
        //唐扬名:扩展Update方法,使以支持db.Carriers.Update(p => p.Id == 1, p => model);
        Expression setExpr = updateExpression.Body;
        if (setExpr.Type == typeof(TEntity) && !(setExpr is NewExpression))
        {
            IEnumerable<ParameterExpression> parameters = updateExpression.Parameters;
            TEntity t = (TEntity)Expression.Lambda(setExpr).Compile().DynamicInvoke();
            var newe = Expression.New(typeof(TEntity));
            var property = t.GetType().GetProperties();
            List<MemberBinding> list = new List<MemberBinding>();

            if (NoModifyList == null || NoModifyList.Count == 0 || IsInList == true)
            {
                //集合为空 需要实例化
                if (NoModifyList == null || NoModifyList.Count == 0)
                {
                    NoModifyList = new List<string>();
                }

                //默认不能修改主键ID(有可能主键不叫ID) 创建时间 创建用户
                NoModifyList.Add("ID");
                NoModifyList.Add("CreateDate");
                NoModifyList.Add("CreateUser");
            }

            foreach (var item in property)
            {
                //自动增长的值不能更新
                var idenditi = item.GetCustomAttributes(typeof(DatabaseGeneratedAttribute), false);
                if (idenditi.Length > 0 && ((DatabaseGeneratedAttribute)(idenditi[0])).DatabaseGeneratedOption == DatabaseGeneratedOption.Identity)
                {
                    continue;
                }

                bool isModify = true;

                if (NoModifyList.Count > 0)
                {
                    foreach (var attr in NoModifyList)
                    {
                        if (isModify == true && item.Name == attr)
                        {
                            isModify = false;
                            continue;
                        }
                    }
                }


                if (isModify == true)
                {
                    string name = item.Name;
                    object value = item.GetValue(t, null);
                    ConstantExpression constant = Expression.Constant(value, item.PropertyType);
                    var member = Expression.Bind(typeof(TEntity).GetProperty(name), constant);
                    list.Add(member);
                }

            }
            #endregion

            Expression body = Expression.MemberInit(newe, list.ToArray());
            LambdaExpression expression = Expression.Lambda(body, parameters);
            updateExpression = (Expression<Func<TEntity, TEntity>>)expression;
        }

        return source.Where(filterExpression).Update(updateExpression);
    }
}
