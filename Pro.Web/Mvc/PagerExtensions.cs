using Pro.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;


namespace System.Web.Mvc
{
    public static class PagerExtensions
    {
        public static MvcHtmlString Pager<T>(this HtmlHelper html, PagedList<T> model)
        {
            if (model.TotalRecord == 0)
            {
                return null;
            }

            var link = new StringBuilder();
            link.Append("<div class='col-lg-12'>");

            //显示分页信息
            link.Append(string.Format("<div class='full-left'>&nbsp;&nbsp;第{0}/{1}页 每页<input type='text' id='txtpagesize' style='width:50px;' value='{2}'/>条数据<a href='#' onclick='MPageIndex()' class='btn btn-primary btn-mini'>确认</a> 共{3}条数据 </div>", model.CurrentPage, model.TotalPage, model.PageSize, model.TotalRecord));

            //计算页码
            int start = model.CurrentPage - 5;
            start = start <= 0 ? 1 : start;
            int end = start + 9;
            end = end >= model.TotalPage ? model.TotalPage : end;


            //页数开始
            link.Append("<div class='full-right'><ul class='pagination'>");
            //首页
            link.Append(string.Format("<li class='previous'><a href='?page={0}' title='首页'>首页</a></li>", 1));
            //往上页数跳转
            if (start >= 2)
            {
                link.Append(string.Format("<li class='previous'><a href='?page={0}'  title=''>…</a></li>", (model.CurrentPage - 5) > 0 ? (model.CurrentPage - 5) : 1));
            }
            else
            {
                link.Append("<li class='previous disabled'><a>…</a></li>");
            }
            //上一页
            if (model.HasPrePage)
            {
                link.Append(string.Format("<li class='previous'><a href='?page={0}'  title='上一页'>上一页</a></li>", model.CurrentPage - 1));
            }
            else
            {
                link.Append("<li class='previous disabled'><a>上一页</a></li>");
            }
            //中间页码
            for (int i = start; i <= end; i++)
            {
                if (i == model.CurrentPage)
                {
                    link.Append(string.Format("<li class='active'><a>{0}</a></li>", i));
                }
                else
                {
                    link.Append(string.Format("<li class='previous'><a href='?page={0}'  title='{1}'>{0}</a></li>", i, "第" + i + "页"));
                }
            }


            //下一页
            if (model.HasNextPage)
            {
                link.Append(string.Format("<li class='next'><a href='?page={0}'  title='下一页'>下一页</a></li>", model.CurrentPage + 1));
            }
            else
            {
                link.Append("<li class='next disabled'><a>下一页</a></li>");
            }
            //往下页数跳转
            if (model.TotalPage >= model.CurrentPage + 5)
            {
                link.Append(string.Format("<li class='previous'><a href='?page={0}'  title=''>…</a></li>", (model.CurrentPage + 6) >= model.TotalPage ? model.TotalPage : (model.CurrentPage + 6)));
            }
            else
            {
                link.Append("<li class='previous disabled'><a>…</a></li>");
            }
            //末页
            link.Append(string.Format("<li class='previous'><a href='?page={0}'  title='末页'>末页</a></li>", model.TotalPage));
            link.Append(string.Format("<li class='previous'><input type='text' class='txtpage' id='txtPages' value='{0}' /><li><li  class='previous'><a href='#' onclick='ChangePage()'>跳转</a></li>", model.CurrentPage));
            link.Append("</ul></div></div>");
            link.Append(@"<script type='text/javascript'></script>");
            return MvcHtmlString.Create(link.ToString());

        }


        public static MvcHtmlString PagerAjax<T>(this HtmlHelper html, PagedList<T> model)
        {
            if (model.TotalRecord == 0)
            {
                return null;
            }

            var link = new StringBuilder();
            link.Append("<div class='col-lg-12'>");

            //显示分页信息
            link.Append(string.Format("<div class='full-left'>&nbsp;&nbsp;第{0}/{1}页 每页{2}条数据  共{3}条数据 </div>", model.CurrentPage, model.TotalPage, model.PageSize, model.TotalRecord));

            //计算页码
            int start = model.CurrentPage - 5;
            start = start <= 0 ? 1 : start;
            int end = start + 9;
            end = end >= model.TotalPage ? model.TotalPage : end;


            //页数开始
            link.Append("<div class='full-right'><ul class='pagination'>");
            //首页
            link.Append(string.Format("<li class='previous'><a  onclick='hhl.ajaxPartial({0},\"formPageSearch\")' title='首页' data-toggle='tooltip'>首页</a></li>", 1, "formPageSearch"));
            //往上页数跳转
            if (start >= 2)
            {
                link.Append(string.Format("<li class='previous'><a  onclick='hhl.ajaxPartial({0},\"formPageSearch\")'>…</a></li>", (model.CurrentPage - 5) > 0 ? (model.CurrentPage - 5) : 1));
            }
            else
            {
                link.Append("<li class='previous disabled'><a>…</a></li>");
            }
            //上一页
            if (model.HasPrePage)
            {
                link.Append(string.Format("<li class='previous'><a  onclick='hhl.ajaxPartial({0},\"formPageSearch\")'  title='上一页' data-toggle='tooltip'>上一页</a></li>", model.CurrentPage - 1));
            }
            else
            {
                link.Append("<li class='previous disabled'><a  title='上一页' data-toggle='tooltip'>上一页</a></li>");
            }
            //中间页码
            for (int i = start; i <= end; i++)
            {
                if (i == model.CurrentPage)
                {
                    link.Append(string.Format("<li class='active'><a>{0}</a></li>", i));
                }
                else
                {
                    link.Append(string.Format("<li class='previous'><a onclick='hhl.ajaxPartial({0},\"formPageSearch\")'  title='{1}' data-toggle='tooltip'>{0}</a></li>", i, "第" + i + "页"));
                }
            }


            //下一页
            if (model.HasNextPage)
            {
                link.Append(string.Format("<li class='next'><a onclick='hhl.ajaxPartial({0},\"formPageSearch\")' title='下一页' data-toggle='tooltip'>下一页</a></li>", model.CurrentPage + 1));
            }
            else
            {
                link.Append("<li class='next disabled'><a>下一页</a></li>");
            }
            //往下页数跳转
            if (model.TotalPage >= model.CurrentPage + 5)
            {
                link.Append(string.Format("<li class='previous'><a  onclick='hhl.ajaxPartial({0},\"formPageSearch\")'>…</a></li>", (model.CurrentPage + 6) >= model.TotalPage ? model.TotalPage : (model.CurrentPage + 6)));
            }
            else
            {
                link.Append("<li class='previous disabled'><a>…</a></li>");
            }
            //末页
            link.Append(string.Format("<li class='previous'><a onclick='hhl.ajaxPartial({0},\"formPageSearch\")'  title='末页' data-toggle='tooltip'>末页</a></li>", model.TotalPage));
            link.Append("</ul></div></div>");
            return MvcHtmlString.Create(link.ToString());

        }

    }
}
