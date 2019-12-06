using Pro.Common;
using Pro.Dal.Base;
using Pro.Dal.Constellatory;
using Pro.Dal.Stu;
using Pro.Extension;
using Pro.Model;
using Pro.Model.dto;
using Pro.Model.model;
using Pro.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pro.WebApi.Controllers
{
    /// <summary>
    /// 学生控制器
    /// </summary>
    public class StudentsController : ApiController
    {



        #region 获取vue树形数据结构
        /// <summary>
        /// 获取vue树形数据结构
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public AjaxMessage GetVueTree(string pid)
        {
            var json = Json(new { });
            AjaxMessage ajax = new AjaxMessage();
            try
            {
                var treeList = DiGuiCompany();
                ajax.data = treeList;
                ajax.IsSuccess = true;
                ajax.Message = "数据获取成功";
            }
            catch (Exception ex)
            {
                ajax.IsSuccess = false;
                ajax.Message = ex.Message;

            }
            return ajax;
        }
        #endregion

        #region 递归获取公司
        /// <summary>
        /// 递归获取公司及部门
        /// </summary>
        /// <param name="ParentID">父公司ID</param>
        /// <returns></returns>
        public List<TreesNode> DiGuiCompany(Guid? ParentID = null)
        {
            EFDbContext context = new EFDbContext();
            if (ParentID == null)
            {
                ParentID = Guid.Empty;
            }
            List<TreesNode> TreeList = new List<TreesNode>();

            var parentList = context.Company.Where(c => c.PId == ParentID).ToList();

            if (parentList.Count > 0)
            {
                foreach (var item in parentList)
                {
                    TreesNode node = new TreesNode();
                    node.Id = item.CompanyID;
                    node.Label = item.CompanyName;
                    node.Children = DiGuiCompany(item.CompanyID);
                    TreeList.Add(node);
                }
            }


            return TreeList;
        }
        #endregion


        #region 分页 异步查询
        /// <summary>
        /// 分页 异步查询学生列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="sortName">排序</param>
        /// <param name="searchs">查询条件</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        public AjaxPager GetStudentByCondition(int page, int pageSize, string sortName, List<PropModel> searchs)
        {
            AjaxPager ajax = new AjaxPager();
            ajax.IsSuccess = false;
            ajax.Message = "查询失败,系统异常";
            try
            {
                int count = 0;
                //lamada表达式 条件数组
                List<Expression<Func<StudentDTO, bool>>> parmList = new List<Expression<Func<StudentDTO, bool>>>();


                if (searchs != null && searchs.Count() > 0)
                {
                    foreach (PropModel item in searchs)
                    {
                        if (!string.IsNullOrEmpty(item.value) && item.value != ",")
                        {
                            ExpressionTools.GetEqualPars(item.property, parmList, item.value, item.method);
                        }
                    }
                }

                StudentService stuService = new StudentService();

                var list = stuService.GetConditionStu(page, pageSize, sortName, parmList, ref count);
                var DataList = new PagedList<StudentDTO>(list, page, pageSize, count);

                ajax.Rows = DataList;
                ajax.Total = count;         //数据总条数
                ajax.PageIndex = page;      //当前页
                ajax.PageSize = pageSize;   //每页显示条数
                ajax.Sort = sortName;

                ajax.IsSuccess = true;
                ajax.Message = "查询成功";
            }
            catch (Exception e)
            {
                ajax.Message = e.Message;
            }

            return ajax;

        }
        #endregion
    }
}