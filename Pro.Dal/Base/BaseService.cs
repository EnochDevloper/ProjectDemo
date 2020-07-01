using Pro.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wuqi.Webdiyer;
using EntityFramework.Extensions;
using Pro.Common;
using System.Reflection;
using System.Web;

namespace Pro.Dal.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {

        EFDbContext ObjEntity = new EFDbContext();

        #region 1.0添加实体数据
        /// <summary>
        /// 添加数据
        /// </summary> 
        public T Add(T model)
        {
            ObjEntity.Set<T>().Add(model);
            ObjEntity.SaveChanges();
            return model;
        }
        #endregion

        #region 1.1批量添加实体数据
        /// <summary>
        /// 批量添加数据
        /// </summary> 
        public int InsertForList(List<T> list)
        {
            if (list != null)
            {
                ObjEntity.Set<T>().AddRange(list);
                int result = ObjEntity.SaveChanges();
                return result;
            }
            return 0;
        }
        #endregion



        #region 2.0根据实体删除
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Delete(T model)
        {
            ObjEntity.Set<T>().Attach(model);
            ObjEntity.Set<T>().Remove(model);
            return ObjEntity.SaveChanges();
        }
        #endregion

        #region  2.1根据条件删除
        /// <summary>
        /// 2.1 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns>返回受影响的行数</returns>
        public int DelBy(Expression<Func<T, bool>> delWhere)
        {
            //2.1.1 查询要删除的数据
            List<T> listDeleting = ObjEntity.Set<T>().Where(delWhere).ToList();
            //2.1.2 将要删除的数据 用删除方法添加到 EF 容器中
            listDeleting.ForEach(u =>
            {
                ObjEntity.Set<T>().Attach(u);  //先附加到EF 容器
                ObjEntity.Set<T>().Remove(u); //标识为删除状态
            });
            //2.1.3 一次性生成sql语句 到数据库执行删除
            return ObjEntity.SaveChanges();
        }
        #endregion


        #region 3.0根据主键查询实体(数组)
        /// <summary>
        /// 查询单个实体
        /// </summary>
        public T Find(params object[] keyValues)
        {
            return ObjEntity.Set<T>().Find(keyValues);
        }
        #endregion

        #region 3.1 根据主键查询实体
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        public T GetById(object keyValues)
        {
            return ObjEntity.Set<T>().Find(keyValues);
        }

        public T GetByGuid(Guid key)
        {
            return ObjEntity.Set<T>().Find(key);
        }
        #endregion

        #region 3.2根据条件查询单个model
        /// <summary>
        /// 3.2 根据条件查询单个model
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return ObjEntity.Set<T>().Where(whereLambda).AsNoTracking().FirstOrDefault();
        }
        #endregion



        #region 4.0 修改实体
        /// <summary>
        /// 4.0 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(T model)
        {

            //ObjEntity.Configuration.ValidateOnSaveEnabled = false;       //关闭实体属性验证
            DbEntityEntry entry = ObjEntity.Entry<T>(model);
            entry.State = EntityState.Modified;
            return ObjEntity.SaveChanges();
        }


        #endregion

        #region 4.1 批量修改
        /// <summary>
        /// 4.1 批量修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="whereLambda"></param>
        /// <param name="modifiedPropertyNames"></param>
        /// <returns></returns>
        public int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedPropertyNames)
        {
            //4.1.1 查询要修改的数据
            List<T> listModifing = ObjEntity.Set<T>().Where(whereLambda).ToList();
            //4.1.2 获取实体类类型对象
            Type t = typeof(T);
            //4.1.3 获取实体类所有的公共属性
            List<PropertyInfo> propertyInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            //4.1.4 创建实体属性字典集合
            Dictionary<string, PropertyInfo> dicPropertys = new Dictionary<string, PropertyInfo>();
            //4.1.5 将实体属性中要修改的属性名 添加到字典集合中  键：属性名  值：属性对象
            propertyInfos.ForEach(p =>
            {
                if (modifiedPropertyNames.Contains(p.Name))
                {
                    dicPropertys.Add(p.Name, p);
                }
            });
            //4.1.6 循环要修改的属性名
            foreach (string propertyName in modifiedPropertyNames)
            {
                //判断要修改的属性名是否在实体类的属性集合中存在
                if (dicPropertys.ContainsKey(propertyName))
                {
                    //如果存在，则取出要修改的属性对象
                    PropertyInfo proInfo = dicPropertys[propertyName];
                    //取出要修改的值
                    object newValue = proInfo.GetValue(model, null);
                    //批量设置要修改对象的属性
                    foreach (T item in listModifing)
                    {
                        //为要修改的对象的要修改的属性设置新的值
                        proInfo.SetValue(item, newValue, null);
                    }
                }
            }
            //一次性生成sql语句 到数据库执行
            return ObjEntity.SaveChanges();
        }
        #endregion



        #region 5.0.0 查询所有数据
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>

        public List<T> FindAll()
        {
            return ObjEntity.Set<T>().ToList();
        }
        #endregion

        #region  5.0.1 根据条件查询
        /// <summary>
        /// 5.0 根据条件查询
        /// </summary>
        public List<T> GetListBy(List<Expression<Func<T, bool>>> parmList)
        {
            IQueryable<T> query = ObjEntity.Set<T>();
            if (parmList != null)
            {
                foreach (var parm in parmList)
                {
                    query = query.Where(parm);
                }
            }
            return query.AsNoTracking().ToList();
        }
        #endregion

        #region 5.1 根据条件查询，并排序 
        /// <summary>
        /// 5.1 根据条件查询，并排序
        /// </summary>
        public List<T> GetListBy<TKey>(List<Expression<Func<T, bool>>> parmList, Expression<Func<T, TKey>> orderLambda, bool isAsc = true)
        {
            IQueryable<T> query = ObjEntity.Set<T>();
            //条件
            if (parmList != null)
            {
                foreach (var parm in parmList)
                {
                    query = query.Where(parm);
                }
            }

            //排序方式
            if (isAsc)
            {
                return query.OrderBy(orderLambda).AsNoTracking().ToList();
            }
            else
            {
                return query.OrderByDescending(orderLambda).AsNoTracking().ToList();
            }
        }
        #endregion

        #region  5.2 根据条件查询
        /// <summary>
        /// 5.2 根据条件查询
        /// </summary>
        public List<T> GetListBySingle(Expression<Func<T, bool>> parm)
        {
            IQueryable<T> query = ObjEntity.Set<T>();
            if (parm != null)
            {
                query = query.Where(parm);
            }
            return query.AsNoTracking().ToList();
        }
        #endregion





        #region 6.0分页查询 带输出
        /// <summary>
        /// @author:wp
        /// @datetime:2016-09-22
        /// @desc:分页查询 带输出
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件 lambda表达式</param>
        /// <param name="orderBy">排序 lambda表达式</param>
        /// <returns></returns>
        public List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, List<Expression<Func<T, bool>>> parmList, Expression<Func<T, TKey>> orderByLambda, bool isAsc = true, AspNetPager CtrPagerIndex = null)
        {

            IQueryable<T> query = ObjEntity.Set<T>();
            if (parmList != null)
            {
                foreach (var parm in parmList)
                {
                    query = query.Where(parm);
                }
            }

            // 分页 一定注意： Skip 之前一定要 OrderBy
            rowCount = query.Count();
            if (CtrPagerIndex != null)
            {
                CtrPagerIndex.RecordCount = rowCount;
                CtrPagerIndex.PageSize = pageSize;
                CtrPagerIndex.CurrentPageIndex = pageIndex;
                Commons.SavaChange(CtrPagerIndex);
            }
            if (isAsc)
            {
                return query.OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
            }
            else
            {
                return query.OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
            }
        }
        #endregion

        #region 6.1 分页查询 带输出 并支持双字段排序
        /// <summary>
        /// @author:wp
        /// @datetime:2016-09-22
        /// @desc: 分页查询 带输出 并支持双字段排序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件 lambda表达式</param>
        /// <param name="orderBy">排序 lambda表达式</param>
        /// <returns></returns>
        public List<T> GetPagedList<TKey1, TKey2>(int pageIndex, int pageSize, ref int rowCount, List<Expression<Func<T, bool>>> parmList, Expression<Func<T, TKey1>> orderByLambda1, Expression<Func<T, TKey2>> orderByLambda2, bool isAsc1 = true, bool isAsc2 = true, AspNetPager CtrPagerIndex = null)
        {
            IQueryable<T> query = ObjEntity.Set<T>();
            if (parmList != null)
            {
                foreach (var parm in parmList)
                {
                    query = query.Where(parm);
                }
            }

            rowCount = query.Count();

            if (CtrPagerIndex != null)
            {
                CtrPagerIndex.RecordCount = rowCount;
                CtrPagerIndex.PageSize = pageSize;
                CtrPagerIndex.CurrentPageIndex = pageIndex;
                Commons.SavaChange(CtrPagerIndex);
            }

            if (isAsc1)
            {
                if (isAsc2)
                {
                    return query.OrderBy(orderByLambda1).ThenBy(orderByLambda2).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
                }
                else
                {
                    return query.OrderBy(orderByLambda1).ThenByDescending(orderByLambda2).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
                }
            }
            else
            {
                if (isAsc2)
                {
                    return query.OrderByDescending(orderByLambda1).ThenBy(orderByLambda2).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
                }
                else
                {
                    return query.OrderByDescending(orderByLambda1).ThenByDescending(orderByLambda2).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
                }
            }
        }
        #endregion

        #region 6.2分页查询 带输出
        /// <summary>
        /// @author:wp
        /// @datetime:2016-09-22
        /// @desc:分页查询 带输出
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件 lambda表达式</param>
        /// <param name="orderBy">排序 lambda表达式</param>
        /// <returns></returns>
        public List<T> GetListByPageer<TKey>(IQueryable<T> query, int pageIndex, int pageSize, ref int rowCount, List<Expression<Func<T, bool>>> parmList, Expression<Func<T, TKey>> orderByLambda, bool isAsc = true, AspNetPager CtrPagerIndex = null)
        {

            if (query != null)
            {
                if (parmList != null)
                {
                    foreach (var parm in parmList)
                    {
                        query = query.Where(parm);
                    }
                }

                // 分页 一定注意： Skip 之前一定要 OrderBy

                rowCount = query.Count();

                if (CtrPagerIndex != null)
                {
                    CtrPagerIndex.RecordCount = rowCount;
                    CtrPagerIndex.PageSize = pageSize;
                    CtrPagerIndex.CurrentPageIndex = pageIndex;
                    Commons.SavaChange(CtrPagerIndex);
                }
                //Commons.SavaChange(new AspNetPagerTool());


                if (isAsc)
                {
                    return query.OrderBy(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
                }
                else
                {
                    return query.OrderByDescending(orderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
                }
            }
            return null;
        }

        #endregion
    }
}
