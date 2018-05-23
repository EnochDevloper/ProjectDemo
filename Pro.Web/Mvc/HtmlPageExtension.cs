using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace System.Web.Mvc
{
        /// <summary>
    /// 分页配置
    /// </summary>
    public class PagerConfig
    {
        [Key]
        public int PagerConfigId { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        [NotMapped]
        public int CurrentPage { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        [Display(Name = "每页记录数", Description = "每页显示的记录数。")]
        [Required(ErrorMessage="×")]
        public int PageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        [NotMapped]
        public int TotalPage { get { return (int)Math.Ceiling(TotalRecord / (double)PageSize); } }
        /// <summary>
        /// 总记录数
        /// </summary>
        [NotMapped]
        public int TotalRecord { get; set; }
        /// <summary>
        /// 记录单位
        /// </summary>
        [Display(Name="记录单位",Description="记录的数量单位。如文章为“篇”；新闻为“条”")]
        [Required(ErrorMessage = "×")]
        public string RecordUnit { get; set; }
        /// <summary>
        /// 记录名称
        /// </summary>
        [Display(Name = "记录名称", Description = "记录的名称。如“文章”、“新闻”、“教程”等")]
        [Required(ErrorMessage = "×")]
        public string RecordName { get; set; }

        public PagerConfig()
        {
            CurrentPage = 1;
            PageSize = 2;
            RecordUnit = "条";
            RecordName = "记录";
        }
    }

    /// <summary>
    /// 分页数据
    /// </summary>
    public class PagerData<T> : List<T>
    {
        public PagerData(List<T> list, PagerConfig pagerConfig)
        {
            this.AddRange(list);
            Config = pagerConfig;
        }
        public PagerData(List<T> list, int currentPage, int pageSize, int totalRecord)
        {
            this.AddRange(list);
            Config.CurrentPage = currentPage;
            Config.PageSize = pageSize;
            Config.TotalRecord = totalRecord;
        }
        public PagerData(List<T> list, int currentPage, int pageSize, int totalRecord, string recordUnit, string recordName)
        {
            this.AddRange(list);
            Config.CurrentPage = currentPage;
            Config.PageSize = pageSize;
            Config.TotalRecord = totalRecord;
            Config.RecordUnit = recordUnit;
            Config.RecordName = recordName;
        }

        public PagerConfig Config { get; set; }
    }



}

namespace System.Web.Mvc.Html
{
    public static class PagerExtensions
    {
        #region 普通
        /// <summary>
        /// 分页控件
        /// </summary>
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, PagerConfig pageConfig)
        {
            return Pager(htmlHelper, actionName, controllerName, new RouteValueDictionary(routeValues), pageConfig, "nspager", "nspager", 10, true, true, true, false, false);
        }
        /// <summary>
        /// 分页控件
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, int currentPage, int totalPage, int pageSize, int totalRecord, string recordUnit, string recordName)
        {
            PagerConfig _config = new PagerConfig { CurrentPage = currentPage, PageSize = pageSize, TotalRecord = totalRecord, RecordUnit = recordUnit, RecordName = recordName };
            return Pager(htmlHelper, actionName, controllerName, new RouteValueDictionary(routeValues), _config, "nspager", "nspager", 10, true, true, true, false, false);
        }
        /// <summary>
        /// 分页控件
        /// </summary>
        /// <param name="actionName">动作名称</param>
        /// <param name="controllerName">控制器名称</param>
        /// <param name="routeValues">路由参数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="totalPage">总页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="recordUnit">记录单位</param>
        /// <param name="recordName">记录名称</param>
        /// <param name="ctrlId">分页控件Id</param>
        /// <param name="cssClass">分页控件css类名</param>
        /// <param name="digitalLinkNum">显示的数组链接个数</param>
        /// <param name="showTotalRecord">显示总记录数</param>
        /// <param name="showCurrentPage">显示当前页</param>
        /// <param name="showTotalPage">显示总页数</param>
        /// <param name="showSelect">显示页码下拉框</param>
        /// <param name="showInput">显示页码输入框</param>
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, int currentPage, int totalPage, int pageSize, int totalRecord, string recordUnit, string recordName, string ctrlId, string cssClass, int digitalLinkNum, bool showTotalRecord, bool showCurrentPage, bool showTotalPage, bool showSelect, bool showInput)
        {
            PagerConfig _config = new PagerConfig { CurrentPage = currentPage, PageSize = pageSize, TotalRecord = totalRecord, RecordUnit = recordUnit, RecordName = recordName };
            return Pager(htmlHelper, actionName, controllerName, new RouteValueDictionary(routeValues), _config, ctrlId, cssClass, digitalLinkNum, showTotalRecord, showCurrentPage, showTotalPage, showSelect, showInput);
        }
        /// <summary>
        /// 分页控件
        /// </summary>
        /// <param name="actionName">动作名称</param>
        /// <param name="controllerName">控制器名称</param>
        /// <param name="routeValues">路由参数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="totalPage">总页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="recordUnit">记录单位</param>
        /// <param name="recordName">记录名称</param>
        /// <param name="ctrlId">分页控件Id</param>
        /// <param name="cssClass">分页控件css类名</param>
        /// <param name="digitalLinkNum">显示的数组链接个数</param>
        /// <param name="showTotalRecord">显示总记录数</param>
        /// <param name="showCurrentPage">显示当前页</param>
        /// <param name="showTotalPage">显示总页数</param>
        /// <param name="showSelect">显示页码下拉框</param>
        /// <param name="showInput">显示页码输入框</param>
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, int currentPage, int totalPage, int pageSize, int totalRecord, string recordUnit, string recordName, string ctrlId, string cssClass, int digitalLinkNum, bool showTotalRecord, bool showCurrentPage, bool showTotalPage, bool showSelect, bool showInput)
        {
            PagerConfig _config = new PagerConfig { CurrentPage = currentPage, PageSize = pageSize, TotalRecord = totalRecord, RecordUnit = recordUnit, RecordName = recordName };
            return Pager(htmlHelper, actionName, controllerName, routeValues, _config, ctrlId, cssClass, digitalLinkNum, showTotalRecord, showCurrentPage, showTotalPage, showSelect, showInput);
        }
        /// <summary>
        /// 分页控件
        /// </summary>
        /// <param name="actionName">动作名称</param>
        /// <param name="controllerName">控制器名称</param>
        /// <param name="routeValues">路由参数</param>
        /// <param name="pageConfig">分页配置</param>
        /// <param name="ctrlId">分页控件Id</param>
        /// <param name="cssClass">分页控件css类名</param>
        /// <param name="digitalLinkNum">显示的数组链接个数</param>
        /// <param name="showTotalRecord">显示总记录数</param>
        /// <param name="showCurrentPage">显示当前页</param>
        /// <param name="showTotalPage">显示总页数</param>
        /// <param name="showSelect">显示页码下拉框</param>
        /// <param name="showInput">显示页码输入框</param>
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, PagerConfig pageConfig, string ctrlId, string cssClass, int digitalLinkNum, bool showTotalRecord, bool showCurrentPage, bool showTotalPage, bool showSelect, bool showInput)
        {
            UrlHelper _url = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            StringBuilder _strBuilder = new StringBuilder("<div id='" + ctrlId + "' class='" + cssClass + "'>");
            if (showTotalRecord) _strBuilder.Append("共" + pageConfig.TotalRecord + pageConfig.RecordUnit + pageConfig.RecordName + " ");
            if (showCurrentPage) _strBuilder.Append("每页" + pageConfig.PageSize + pageConfig.RecordUnit + " ");
            if(showTotalPage) _strBuilder.Append("第" + pageConfig.CurrentPage + "页/共" + pageConfig.TotalPage + "页 ");
            //首页链接
            if (pageConfig.CurrentPage > 1)
            {
                routeValues["page"] = 1;
                _strBuilder.Append("<a class='linkbtn' href='" + _url.Action(actionName, controllerName, routeValues) + "'>首页</a>");
            }
            else _strBuilder.Append("<span class='btn'>首页</span>");
            //上一页
            if (pageConfig.CurrentPage > 1)
            {
                routeValues["page"] = pageConfig.CurrentPage - 1;
                _strBuilder.Append("<a class='linkbtn' href='" + _url.Action(actionName, controllerName, routeValues) + "'>上一页</a>");
            }
            else _strBuilder.Append("<span class='btn'>上一页</span>");
            //数字导航开始
            int _startPage, _endPage;
            //总页数少于要显示的页数，页码全部显示
            if (digitalLinkNum >= pageConfig.TotalPage) { _startPage = 1; _endPage = pageConfig.TotalPage; }
            else//显示指定数量的页码
            {
                int _forward = (int)Math.Ceiling(digitalLinkNum / 2.0);
                if (pageConfig.CurrentPage > _forward)//起始页码大于1
                {
                    _endPage = pageConfig.CurrentPage + digitalLinkNum - _forward;
                    if (_endPage > pageConfig.TotalPage)//结束页码大于总页码结束页码为最后一页
                    {
                        _startPage = pageConfig.TotalPage - digitalLinkNum;
                        _endPage = pageConfig.TotalPage;

                    }
                    else _startPage = pageConfig.CurrentPage - _forward;
                }
                else//起始页码从1开始
                {
                    _startPage = 1;
                    _endPage = digitalLinkNum;
                }
            }
            //向上…
            if (_startPage > 1)
            {
                routeValues["page"] = _startPage - 1;
                _strBuilder.Append("<a class='linkbatch' href='" + _url.Action(actionName, controllerName, routeValues) + "'>…</a>");
            }
            //数字
            for (int i = _startPage; i <= _endPage; i++)
            {
                if (i != pageConfig.CurrentPage)
                {
                    routeValues["page"] = i;
                    _strBuilder.Append("<a class='linknum' href='" + _url.Action(actionName, controllerName, routeValues) + "'>" + i.ToString() + "</a>");
                }
                else
                {
                    _strBuilder.Append("<span class='currentnum'>" + i.ToString() + "</span>");
                }
            }
            //向下…
            if (_endPage < pageConfig.TotalPage)
            {
                routeValues["page"] = _endPage + 1;
                _strBuilder.Append("<a class='linkbatch' href='" + _url.Action(actionName, controllerName, routeValues) + "'>…</a>");
            }
            ////数字导航结束
            //下一页和尾页
            if (pageConfig.CurrentPage < pageConfig.TotalPage)
            {
                routeValues["page"] = pageConfig.CurrentPage + 1;
                _strBuilder.Append("<a class='linkbtn' href='" + _url.Action(actionName, controllerName, routeValues) + "'>下一页</a>");
                routeValues["page"] = pageConfig.TotalPage;
                _strBuilder.Append("<a class='linkbtn' href='" + _url.Action(actionName, controllerName, routeValues) + "'>尾页</a>");
            }
            else _strBuilder.Append("<span class='btn'>下一页</span><span class='btn'>尾页</span>");
            //显示页码下拉框
            if (showSelect)
            {
                routeValues["page"] = "-nspageselecturl-";
                _strBuilder.Append(" 跳转到第<select id='nspagerselect' data-url='" + _url.Action(actionName, controllerName, routeValues) + "'>");
                for (int i = 1; i <= pageConfig.TotalPage; i++)
                {
                    if (i == pageConfig.CurrentPage) _strBuilder.Append("<option selected='selected' value='" + i + "'>" + i + "</option>");
                    else _strBuilder.Append("<option value='" + i + "'>" + i + "</option>");
                }
                _strBuilder.Append("</select>页");
                _strBuilder.Append("<script type='text/javascript'>$('#" + ctrlId + " #nspagerselect').change(function () { location.href = $('#" + ctrlId + " #nspagerselect').attr('data-url').replace('-nspageselecturl-', $('#" + ctrlId + " #nspagerselect').val());});</script>");
            }
            //显示页码输入框
            if (showInput)
            {
                routeValues["page"] = "-nspagenumurl-";
                _strBuilder.Append("转到第<input id='nspagernum' type='text' data-url='" + _url.Action(actionName, controllerName, routeValues) + "' />页");
                _strBuilder.Append("<script type='text/javascript'>$('#" + ctrlId + " #nspagernum').keydown(function (event) {if (event.keyCode == 13) location.href = $('#" + ctrlId + " #nspagernum').attr('data-url').replace('-nspagenumurl-', $('#" + ctrlId + " #nspagernum').val()); });</script>");
            }
            _strBuilder.Append("</div>");
            return MvcHtmlString.Create(_strBuilder.ToString());
        }
        /// <summary>
        /// 分页控件
        /// </summary>
        #endregion

        #region Ajax
        /// <summary>
        /// 分页控件-Ajax
        /// </summary>
        public static MvcHtmlString PagerAjax(this HtmlHelper htmlHelper, string ctnrId, string actionName, string controllerName, object routeValues, PagerConfig pagerConfig)
        {
            return PagerAjax(htmlHelper, ctnrId, actionName, controllerName, new RouteValueDictionary(routeValues), pagerConfig, "nspager", "nspager", 10, true, true, true, false, false);
        }
        /// <summary>
        /// 分页控件-Ajax
        /// </summary>
        public static MvcHtmlString PagerAjax(this HtmlHelper htmlHelper, string ctnrId, string actionName, string controllerName, object routeValues, int currentPage, int TotalPage, int pageSize, int totalRecord, string recordUnit, string recordName)
        {
            PagerConfig _config = new PagerConfig { CurrentPage = currentPage, PageSize = pageSize, TotalRecord = totalRecord, RecordUnit = recordUnit, RecordName = recordName };
            return PagerAjax(htmlHelper, ctnrId, actionName, controllerName, new RouteValueDictionary(routeValues), _config, "nspager", "nspager", 10, true, true, true, false, false);
        }
        /// <summary>
        /// 分页控件-Ajax
        /// </summary>
        /// <param name="ctnrId">内容容器Id</param>
        /// <param name="actionName">动作名称</param>
        /// <param name="controllerName">控制器名称</param>
        /// <param name="routeValues">路由参数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="totalPage">总页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="recordUnit">记录单位</param>
        /// <param name="recordName">记录名称</param>
        /// <param name="ctrlId">分页控件Id</param>
        /// <param name="cssClass">分页控件css类名</param>
        /// <param name="digitalLinkNum">显示的数组链接个数</param>
        /// <param name="showTotalRecord">显示总记录数</param>
        /// <param name="showCurrentPage">显示当前页</param>
        /// <param name="showTotalPage">显示总页数</param>
        /// <param name="showSelect">显示页码下拉框</param>
        /// <param name="showInput">显示页码输入框</param>
        public static MvcHtmlString PagerAjax(this HtmlHelper htmlHelper, string ctnrId, string actionName, string controllerName, object routeValues, int currentPage, int TotalPage, int pageSize, int totalRecord, string recordUnit, string recordName, string ctrlId, string cssClass, int digitalLinkNum, bool showTotalRecord, bool showCurrentPage, bool showTotalPage, bool showSelect, bool showInput)
        {
            PagerConfig _config = new PagerConfig { CurrentPage = currentPage, PageSize = pageSize, TotalRecord = totalRecord, RecordUnit = recordUnit, RecordName = recordName };
            return PagerAjax(htmlHelper, ctnrId, actionName, controllerName, new RouteValueDictionary(routeValues), _config, ctrlId, cssClass, digitalLinkNum, showTotalRecord, showCurrentPage, showTotalPage, showSelect, showInput);
        }
        /// <summary>
        /// 分页控件-Ajax
        /// </summary>
        /// <param name="ctnrId">内容容器Id</param>
        /// <param name="actionName">动作名称</param>
        /// <param name="controllerName">控制器名称</param>
        /// <param name="routeValues">路由参数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="totalPage">总页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="recordUnit">记录单位</param>
        /// <param name="recordName">记录名称</param>
        /// <param name="ctrlId">分页控件Id</param>
        /// <param name="cssClass">分页控件css类名</param>
        /// <param name="digitalLinkNum">显示的数组链接个数</param>
        /// <param name="showTotalRecord">显示总记录数</param>
        /// <param name="showCurrentPage">显示当前页</param>
        /// <param name="showTotalPage">显示总页数</param>
        /// <param name="showSelect">显示页码下拉框</param>
        /// <param name="showInput">显示页码输入框</param>
        public static MvcHtmlString PagerAjax(this HtmlHelper htmlHelper, string ctnrId, string actionName, string controllerName, RouteValueDictionary routeValues, int currentPage, int TotalPage, int pageSize, int totalRecord, string recordUnit, string recordName, string ctrlId, string cssClass, int digitalLinkNum, bool showTotalRecord, bool showCurrentPage, bool showTotalPage, bool showSelect, bool showInput)
        {
            PagerConfig _config = new PagerConfig { CurrentPage = currentPage, PageSize = pageSize, TotalRecord = totalRecord, RecordUnit = recordUnit, RecordName = recordName };
            return PagerAjax(htmlHelper, ctnrId, actionName, controllerName, routeValues, _config, ctrlId, cssClass, digitalLinkNum, showTotalRecord, showCurrentPage, showTotalPage, showSelect, showInput);
        }
        /// <summary>
        /// 分页控件-Ajax
        /// <param name="ctnrId">内容容器Id</param>
        /// <param name="actionName">动作名称</param>
        /// <param name="controllerName">控制器名称</param>
        /// <param name="routeValues">路由参数</param>
        /// <param name="pageConfig">分页配置</param>
        /// <param name="ctrlId">分页控件Id</param>
        /// <param name="cssClass">分页控件css类名</param>
        /// <param name="digitalLinkNum">显示的数组链接个数</param>
        /// <param name="showTotalRecord">显示总记录数</param>
        /// <param name="showCurrentPage">显示当前页</param>
        /// <param name="showTotalPage">显示总页数</param>
        /// <param name="showSelect">显示页码下拉框</param>
        /// <param name="showInput">显示页码输入框</param>
        public static MvcHtmlString PagerAjax(this HtmlHelper htmlHelper, string ctnrId, string actionName, string controllerName, RouteValueDictionary routeValues, PagerConfig pageConfig, string ctrlId, string cssClass, int digitalLinkNum, bool showTotalRecord, bool showCurrentPage, bool showTotalPage, bool showSelect, bool showInput)
        {
            UrlHelper _url = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            StringBuilder _strBuilder = new StringBuilder("<div id='" + ctrlId + "' class='" + cssClass + "'><p>");
            if (showTotalRecord) _strBuilder.Append("共" + pageConfig.TotalRecord + pageConfig.RecordUnit + pageConfig.RecordName + " ");
            if (showCurrentPage) _strBuilder.Append("每页" + pageConfig.PageSize + pageConfig.RecordUnit + " ");
            if (showTotalPage) _strBuilder.Append("第" + pageConfig.CurrentPage + "页/共" + pageConfig.TotalPage + "页</p> ");
            //首页链接
            if (pageConfig.CurrentPage > 1)
            {
                routeValues["page"] = 1;
                _strBuilder.Append("<p><a class='linkbtn' href='" + _url.Action(actionName, controllerName, routeValues) + "'>首页</a>");
            }
            else _strBuilder.Append("<span class='btn'>首页</span>");
            //上一页
            if (pageConfig.CurrentPage > 1)
            {
                routeValues["page"] = pageConfig.CurrentPage - 1;
                _strBuilder.Append("<a class='linkbtn' href='" + _url.Action(actionName, controllerName, routeValues) + "'>上一页</a>");
            }
            else _strBuilder.Append("<span class='btn'>上一页</span>");
            //数字导航开始
            int _startPage, _endPage;
            //总页数少于要显示的页数，页码全部显示
            if (digitalLinkNum >= pageConfig.TotalPage) { _startPage = 1; _endPage = pageConfig.TotalPage; }
            else//显示指定数量的页码
            {
                int _forward = (int)Math.Ceiling(digitalLinkNum / 2.0);
                if (pageConfig.CurrentPage > _forward)//起始页码大于1
                {
                    _endPage = pageConfig.CurrentPage + digitalLinkNum - _forward;
                    if (_endPage > pageConfig.TotalPage)//结束页码大于总页码结束页码为最后一页
                    {
                        _startPage = pageConfig.TotalPage - digitalLinkNum;
                        _endPage = pageConfig.TotalPage;

                    }
                    else _startPage = pageConfig.CurrentPage - _forward;
                }
                else//起始页码从1开始
                {
                    _startPage = 1;
                    _endPage = digitalLinkNum;
                }
            }
            //向上…
            if (_startPage > 1)
            {
                routeValues["page"] = _startPage - 1;
                _strBuilder.Append("<a class='linkbatch' href='" + _url.Action(actionName, controllerName, routeValues) + "'>…</a>");
            }
            //数字
            for (int i = _startPage; i <= _endPage; i++)
            {
                if (i != pageConfig.CurrentPage)
                {
                    routeValues["page"] = i;
                    _strBuilder.Append("<a class='linknum' href='" + _url.Action(actionName, controllerName, routeValues) + "'>" + i.ToString() + "</a>");
                }
                else
                {
                    _strBuilder.Append("<span class='currentnum'>" + i.ToString() + "</span>");
                }
            }
            //向下…
            if (_endPage < pageConfig.TotalPage)
            {
                routeValues["page"] = _endPage + 1;
                _strBuilder.Append("<a class='linkbatch' href='" + _url.Action(actionName, controllerName, routeValues) + "'>…</a>");
            }
            ////数字导航结束
            //下一页和尾页
            if (pageConfig.CurrentPage < pageConfig.TotalPage)
            {
                routeValues["page"] = pageConfig.CurrentPage + 1;
                _strBuilder.Append("<a class='linkbtn' href='" + _url.Action(actionName, controllerName, routeValues) + "'>下一页</a>");
                routeValues["page"] = pageConfig.TotalPage;
                _strBuilder.Append("<a class='linkbtn' href='" + _url.Action(actionName, controllerName, routeValues) + "'>尾页</a>");
            }
            else _strBuilder.Append("<span class='btn'>下一页</span><span class='btn'>尾页</span>");
            //显示页码下拉框
            if (showSelect)
            {
                routeValues["page"] = "-nspageselecturl-";
                _strBuilder.Append(" 跳转到第<select id='nspagerselect' data-url='" + _url.Action(actionName, controllerName, routeValues) + "'>");
                for (int i = 1; i <= pageConfig.TotalPage; i++)
                {
                    if (i == pageConfig.CurrentPage) _strBuilder.Append("<option selected='selected' value='" + i + "'>" + i + "</option>");
                    else _strBuilder.Append("<option value='" + i + "'>" + i + "</option>");
                }
                _strBuilder.Append("</select>页");
                _strBuilder.Append("<script type='text/javascript'>$('#" + ctrlId + " #nspagerselect').change(function () {$.post($('#" + ctrlId + " #nspagerselect').attr('data-url').replace('-nspageselecturl-', $('#" + ctrlId + " #nspagerselect').val()), function (data) {$('#" + ctnrId + "').html(data);});});</script>");
            }
            //显示页码输入框
            if (showInput)
            {
                routeValues["page"] = "-nspagenumurl-";
                _strBuilder.Append(" 转到第<input id='nspagernum' type='text' data-url='" + _url.Action(actionName, controllerName, routeValues) + "' />页");
                _strBuilder.Append("<script type='text/javascript'>$('#" + ctrlId + " #nspagernum').keydown(function (event) {if (event.keyCode == 13) { $.post($('#" + ctrlId + " #nspagernum').attr('data-url').replace('-nspagenumurl-', $('#" + ctrlId + " #nspagernum').val()), function (data) {$('#" + ctnrId + "').html(data);}); } });</script>");
            }
            _strBuilder.Append("<script type='text/javascript'>$('#" + ctrlId + " a').click(function () {$.post($(this).attr('href'), function (data) {$('#" + ctnrId + "').html(data);});return false; });</script>");
            _strBuilder.Append("</p></div>");
            return MvcHtmlString.Create(_strBuilder.ToString());
        }
        #endregion
    }
}