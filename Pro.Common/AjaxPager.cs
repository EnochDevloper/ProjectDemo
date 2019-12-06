using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Common
{
    public class AjaxPager
    {
        /// <summary>
        /// 数据
        /// </summary>
        public object Rows { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 总页码
        /// </summary>
        public int TotalPage
        {
            get
            {
                if (PageSize > 0)
                {
                    return Total % PageSize == 0 ? Total / PageSize : (Total / PageSize) + 1;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                TotalPage = value;
            }
        }
        /// <summary>
        /// 排序(格式：排序字段-排序方式)
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; }
    }
}
