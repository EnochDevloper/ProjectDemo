using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wuqi.Webdiyer;

namespace Pro.Common
{
    public static class Commons
    {
        public static void SavaChange(AspNetPager CtrPagerIndex)
        {
            int totalPage = CtrPagerIndex.RecordCount % CtrPagerIndex.PageSize == 0 ? CtrPagerIndex.RecordCount / CtrPagerIndex.PageSize : CtrPagerIndex.RecordCount / CtrPagerIndex.PageSize + 1;
            totalPage = totalPage == 0 ? 1 : totalPage;
            CtrPagerIndex.CustomInfoHTML = "当前第" + CtrPagerIndex.CurrentPageIndex + "/" + totalPage + "页 共" + CtrPagerIndex.RecordCount + "条记录 每页" + CtrPagerIndex.PageSize + "条";
        }
    }
}
