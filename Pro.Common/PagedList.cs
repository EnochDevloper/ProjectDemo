using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Common
{

    /// <summary>
    /// 分页配置
    /// </summary>
    [Serializable]
    public class PagedList<T> : List<T>
    {

        /// <summary>
        /// 构造函数  分页
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalRecord">数据总数</param>
        public PagedList(IEnumerable<T> source, int currentPage, int pageSize, int totalRecord)
        {
            this.TotalRecord = totalRecord;
            this.PageSize = pageSize;
            this.CurrentPage = currentPage;
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize != 0)
            {
                TotalPage++;
            }
            this.AddRange(source);
        }








        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>

        public int PageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>

        //public int TotalPage { get { return (int)Math.Ceiling(TotalRecord / (double)PageSize); } }
        public int TotalPage { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>

        public int TotalRecord { get; set; }

        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrePage
        {
            get { return (CurrentPage > 1); }
        }

        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPage);
            }
        }



    }
}