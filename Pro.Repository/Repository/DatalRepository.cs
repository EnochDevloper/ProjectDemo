using Pro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using System.Linq.Expressions;
using System.Data.Entity;
using AutoMapper;
using Pro.Repository.Extensions;
using System.Data.Entity.Infrastructure;
using Pro.Common;

namespace Pro.Repository.Repository
{

    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        public EFDbContext dbContext=new EFDbContext();
        private DbSet<TEntity> dbSet;

        public DataRepository()
        {
            //this.dbContext = _dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        #region 属性包含 以及dispose

        private bool IsDispose = false;

        protected virtual void Dispose(bool Disposed)
        {
            if (!IsDispose)
            {
                if (Disposed)
                {
                    dbContext.Dispose();
                }
            }
            this.IsDispose = true;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        /// <summary>
        /// 已经禁用了tacking
        /// </summary>
        /// <param name="propertySelectors">属性包含 即include</param>
        /// <returns></returns>
        public IQueryable<TEntity> GetRepositoy(params Expression<Func<TEntity, object>>[] propertySelectors)
        {

            IQueryable<TEntity> query = dbSet.AsNoTracking();

            if (!propertySelectors.IsNullOrEmpty())
            {
                propertySelectors.ForEach_(r =>
                {
                    query = query.Include(r);
                });
            }

            return query;
        }

        #endregion

        #region 获取所有数据  (增、删、改、查)


        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAllList()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="T"></param>
        public TEntity Insert(TEntity T)
        {
            dbContext.Set<TEntity>().Add(T);
            return T;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="T">修改的实体</param>
        /// <param name="predicate">条件</param>
        public void Update(TEntity T, Expression<Func<TEntity, bool>> predicate)
        {
            dbContext.Set<TEntity>().Where(predicate).Update(r => T);
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ID"></param>
        public void Delete(Guid ID)
        {
            dbContext.Set<TEntity>().Delete();
        }

        #endregion

        #region 分页
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pageSize">煤业显示条数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">排序方式 1.正序  2.倒序</param>
        /// <returns></returns>
        public List<TEntity> GetDataByPage(int page, int pageSize, List<Expression<Func<TEntity, bool>>> parmList, string Sort, ref int count)
        {
            IQueryable<TEntity> query = dbSet;
            if (parmList != null)
            {
                foreach (var parm in parmList)
                {
                    query = query.Where(parm);
                }
            }
            count = query.Count();
            query = SortTools.SortingAndPaging<TEntity>(query, Sort, page, pageSize, true);

            List<TEntity> queryList = query.ToList();

            return queryList;
        }
        #endregion

        #region 获取单个实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns></returns>
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> parm)
        {
            return dbSet.FirstOrDefault(parm);
        }
        #endregion


        #region dto

        public TDto FirstOrDefault<TDto>(Expression<Func<TEntity, bool>> predicate)
        {
            return GetRepositoy().Where(predicate).ProjectToFirstOrDefault<TDto>();
        }

        public List<TDto> GetList<TDto>(Expression<Func<TEntity, bool>> predicate)
        {
            return GetRepositoy().Where(predicate).ProjectToList<TDto>();
        }

        public async Task<List<TDto>> GetListAsync<TDto>(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetRepositoy().Where(predicate).ProjectToListAsync<TDto>();
        }

        #endregion

        #region max

        public T Max<T>(Expression<Func<TEntity, T>> selectProperty, Expression<Func<TEntity, bool>> predicate)
        {
            return GetRepositoy().Where(predicate).Select(selectProperty).Max();
        }

        #endregion

        #region count

        /// <summary>
        /// 获取数据数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return GetRepositoy().Count();
        }

        /// <summary>
        /// 根据条件获取数量
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int Count(Expression<Func<TEntity, bool>> parm)
        {
            return GetRepositoy().Count(parm);
        }

        #endregion

        #region update

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            DbEntityEntry entry = dbContext.Entry<TEntity>(entity);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();
            return entity;

        }

        public int Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateAction)
        {
            return GetRepositoy().Where(predicate).Update(updateAction);
        }
        #endregion

        #region insert

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await Task.Run(() => Insert(entity));
        }

        public IEnumerable<TEntity> Insert(IEnumerable<TEntity> entitys)
        {
            return dbContext.Set<TEntity>().AddRange(entitys);
        }

        public async Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entitys)
        {
            return await Task.Run(() => Insert(entitys));
        }
        #endregion

        #region delete

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            return GetRepositoy().Where(predicate).Delete();
        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetRepositoy().Where(predicate).DeleteAsync();
        }

        #endregion


        #region 保存更改
        /// <summary>
        /// 保存更改
        /// </summary>

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        #endregion


    }
}
