using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wuqi.Webdiyer;

namespace Pro.Dal.Base
{
    public interface IBaseService<T> where T : class
    {
        #region 1.0添加实体数据
        //添加
        T Add(T model);
        #endregion



        #region 2.0根据实体删除
        //删除
        int Delete(T model);
        #endregion

        #region  2.1根据条件删除
        //根据条件删除
        int DelBy(Expression<Func<T, bool>> delWhere);
        #endregion




        #region 3.0根据主键查询实体
        //根据I的查找
        //keyValues是主键值  
        T Find(params object[] keyValues);
        #endregion

        #region 3.1根据条件查询单个model
        T GetModel(Expression<Func<T, bool>> whereLambda);


        T GetById(object keyValues);
        #endregion



        #region 4.0 修改实体
        //修改
        int Update(T model);
        #endregion

        #region 4.1 批量修改
        /// <summary>
        /// 4.1 批量修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="whereLambda"></param>
        /// <param name="modifiedPropertyNames"></param>
        /// <returns></returns>
        int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedPropertyNames);
        #endregion



        #region 5.0.0 查询所有数据
        //获取所有
        List<T> FindAll();
        #endregion

        #region  5.0 根据条件查询
        List<T> GetListBy(List<Expression<Func<T, bool>>> parmList);
        #endregion

        #region 5.1 根据条件查询，并排序 
        List<T> GetListBy<TKey>(List<Expression<Func<T, bool>>> parmList, Expression<Func<T, TKey>> orderLambda, bool isAsc = true);
        #endregion

        #region  5.2 根据条件查询
        List<T> GetListBySingle(Expression<Func<T, bool>> parm);
        #endregion


        #region 6.0 分页查询 带输出
        List<T> GetPagedList<TKey>(int pageIndex, int pageSize, ref int rowCount, List<Expression<Func<T, bool>>> parmList, Expression<Func<T, TKey>> orderByLambda, bool isAsc = true, AspNetPager CtrPagerIndex = null);
        #endregion

        #region 6.1 分页查询 带输出 并支持双字段排序
        List<T> GetPagedList<TKey1, TKey2>(int pageIndex, int pageSize, ref int rowCount, List<Expression<Func<T, bool>>> parmList, Expression<Func<T, TKey1>> orderByLambda1, Expression<Func<T, TKey2>> orderByLambda2, bool isAsc1 = true, bool isAsc2 = true, AspNetPager CtrPagerIndex = null);
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
        List<T> GetListByPageer<TKey>(IQueryable<T> query, int pageIndex, int pageSize, ref int rowCount, List<Expression<Func<T, bool>>> parmList, Expression<Func<T, TKey>> orderByLambda, bool isAsc = true, AspNetPager CtrPagerIndex = null);
        #endregion
    }
}
