using Newtonsoft.Json;
using Pro.Common;
using Pro.Dal.Base;
using Pro.Dal.Constellatory;
using Pro.Dal.Stu;
using Pro.Extension;
using Pro.Model;
using Pro.Model.dto;
using Pro.Model.model;
using Pro.Repository.Repository;
using Pro.WebApi.Models;
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
        private IDataRepository<Student> stuReporitory;
        /// <summary>
        /// 构造函数
        /// </summary>
        public StudentsController(IDataRepository<Student> _stuReporitory)
        {
            this.stuReporitory = _stuReporitory;
        }



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
        [HttpPost]
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
        public AjaxPager GetStudentByCondition(int page, int pageSize, string sortName, string searchs)
        {
            AjaxPager ajax = new AjaxPager();
            ajax.IsSuccess = false;
            ajax.Message = "查询失败,系统异常";
            try
            {
                var searchData = !string.IsNullOrEmpty(searchs) ? JsonConvert.DeserializeObject<List<PropModel>>(searchs) : new List<PropModel>();
                int count = 0;
                //lamada表达式 条件数组
                List<Expression<Func<StudentDTO, bool>>> parmList = new List<Expression<Func<StudentDTO, bool>>>();

                //if (!string.IsNullOrEmpty(s_name))
                //{
                //    parmList.Add(c => c.s_name.Contains(s_name));
                //}

                //if (!string.IsNullOrEmpty(s_address))
                //{
                //    parmList.Add(c => c.s_address.Contains(s_address));
                //}

                if (searchData != null && searchData.Count() > 0)
                {
                    foreach (PropModel item in searchData)
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

        #region 登录功能
        /// <summary>
        /// @author:wp
        /// @datetime:2019-12-13
        /// @desc:登录功能
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public AjaxMessage Login(string userName = "", string passWord = "")
        {
            AjaxMessage ajax = new AjaxMessage();
            try
            {
                DataRepository<Student> stuReporitory = new DataRepository<Student>();
                if (string.IsNullOrEmpty(userName))
                {
                    userName = "zhangchu";
                }

                if (string.IsNullOrEmpty(passWord))
                {
                    passWord = "123456";
                }

                var m_student = stuReporitory.GetRepositoy().FirstOrDefault(c => c.s_loginName == userName);
                if (m_student != null)
                {
                    if (m_student.s_passWord == passWord)
                    {
                        ajax.Message = "登录成功";
                        ajax.data = m_student;
                        ajax.IsSuccess = true;
                    }
                    else
                    {
                        ajax.Message = "登录失败,密码错误!";
                        ajax.IsSuccess = false;
                    }
                }
                else
                {
                    ajax.Message = "账户不存在,请检查核实!";
                    ajax.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
            return ajax;
        }
        #endregion

        #region  修改学生信息功能
        /// <summary>
        /// 编辑页面  修改功能
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        [HttpPost]
        public AjaxMessage UpdateStu(Student stu)
        {
            AjaxMessage ajax = new AjaxMessage();

            try
            {
                ajax.IsSuccess = false;
                ajax.Message = "系统异常,修改失败";
                if (stu != null)
                {
                    Student result = stuReporitory.Update(stu);
                    if (result != null)
                    {
                        ajax.IsSuccess = true;
                        ajax.Message = "修改成功";
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
            return ajax;
        }
        #endregion

        #region 重置密码
        /// <summary>
        /// @author:wp
        /// @datetime:2020-04-03
        /// @desc:重置密码
        /// </summary>
        /// <param name="sid">编号</param>
        /// <returns></returns>

        public AjaxMessage ResetPassWord(Guid sid)
        {
            AjaxMessage ajax = new AjaxMessage();

            try
            {
                ajax.IsSuccess = false;
                ajax.Message = "系统异常,修改失败";
                if (!string.IsNullOrEmpty(sid.ToString()) && sid != Guid.Empty)
                {
                    var model = stuReporitory.GetFirstOrDefault(c => c.s_id == sid);
                    if (model != null)
                    {
                        model.s_passWord = "123";
                        var result = stuReporitory.Update(model);
                        if (result != null)
                        {
                            ajax.IsSuccess = true;
                            ajax.Message = "重置密码成功";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ajax.Message = ex.Message;
            }
            return ajax;
        }
        #endregion
    }
}