using Pro.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Repository.Repository
{

    public interface IDataRepository
    {
    }

    /// <summary>
    /// 平台仓储接口
    /// </summary>
    public interface IDataRepository<TEntity> : IDataRepository where TEntity : class
    {
        /// <summary>
        /// 获取仓储,用于原始的DbContext操作,如要获取原始的实体对象Entity就可以用GetRepositoy
        /// </summary>
        /// <param name="propertySelectors">属性包含 include,属性选择表达式</param>
        /// <returns></returns>
        IQueryable<TEntity> GetRepositoy(params Expression<Func<TEntity, object>>[] propertySelectors);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="T">需添加的实体类</param>
        /// <returns></returns>
        TEntity Insert(TEntity T);

        /// <summary>
        /// g根据ID删除
        /// </summary>
        /// <param name="ID">主键ID</param>
        void Delete(Guid ID);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="T"></param>
        /// <param name="predicate"></param>
        void Update(TEntity T, Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAllList();

        /// <summary>
        /// 分页获取
        /// </summary>
        List<TEntity> GetDataByPage(int page, int pageSize, List<Expression<Func<TEntity, bool>>> parmList, string Sort, ref int count);

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="parm">条件</param>
        /// <returns></returns>
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> parm);

        /// <summary>
        /// 获取满足条件的最大值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selectProperty">属性选择表达式</param>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        T Max<T>(Expression<Func<TEntity, T>> selectProperty, Expression<Func<TEntity, bool>> predicate);

        #region dto

        /// <summary>
        /// FirstOrDefault
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        TDto FirstOrDefault<TDto>(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据条件获取dto列表
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        List<TDto> GetList<TDto>(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 异步根据条件获取dto列表
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<List<TDto>> GetListAsync<TDto>(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region 获取数量

        int GetCount();

        int Count(Expression<Func<TEntity, bool>> parm);

        #endregion

        #region  update

        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);


        /// <summary>
        /// 使满足条件的实体都进行 更新
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <param name="updateAction">更新表达式</param>
        /// <returns></returns>
        int Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateAction);

        #endregion

        #region  insert

        /// <summary>
        /// 异步新增单个实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// 批量新增实体
        /// </summary>
        /// <param name="entitys">实体集合</param>
        /// <returns></returns>
        IEnumerable<TEntity> Insert(IEnumerable<TEntity> entitys);

        /// <summary>
        /// 异步批量新增实体
        /// </summary>
        /// <param name="entitys">实体集合</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entitys);
        #endregion

        #region  delete
        /// <summary>
        /// 删除满足条件的实体
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        int Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 异步 删除满足条件的实体
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 保存所有更改,在有工作单元的方法中,会由工作单元自动调用
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// 异步 保存所有更改,在有工作单元的方法中,会由工作单元自动调用
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
        #endregion
    }
}
