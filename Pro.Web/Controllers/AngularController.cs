using Pro.Dal.Base;
using Pro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pro.Common;
using System.Web.Mvc;
using Pro.Dal.Stu;
using Pro.Repository.Repository;
using System.Linq.Expressions;
using Pro.Dal.Constellatory;
using Pro.Model.dto;
using Pro.Extension;

namespace Pro.Web.Controllers
{
    public class AngularController : BaseController
    {
        // GET: Angular


        #region 构造函数
        /// <summary>
        /// 构造函数  声明 EF
        /// </summary>
        private IStudentService stuService;
        private IConstellationService consService;
        private IDataRepository<Grade> gradeReporitory;
        private IDataRepository<Student> stuReporitory;
        private IBaseService<Student> baseService;
        public AngularController(IStudentService _stuService, IDataRepository<Student> _stuReporitory, IDataRepository<Grade> _gradeReporitory, IConstellationService _consService, IBaseService<Student> _baseService)
        {
            this.stuService = _stuService;
            this.stuReporitory = _stuReporitory;
            this.gradeReporitory = _gradeReporitory;
            this.baseService = _baseService;
            this.consService = _consService;
        }
        #endregion


        #region 页面

        public ActionResult AngularList()
        {
            #region 下拉框

            Enum status = SysStatus.Enable;
            ViewData["selectList"] = status.GetSelectList();

            #endregion

            //var dataList = stuService.GetAllStu("", "", "", 1, 10);
            return View();
        }
        #endregion

        #region 分页 异步查询
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult GetStudentByCondition(int page, int pageSize, string sortName, List<PropModel> searchs)
        {
            AjaxMessage ajax = new AjaxMessage();
            ajax.IsSuccess = false;
            ajax.Message = "查询失败,系统异常";
            try
            {
                int count = 0;
                //lamada表达式 条件数组
                List<Expression<Func<StudentDTO, bool>>> parmList = new List<Expression<Func<StudentDTO, bool>>>();


                if (searchs.Count() > 0)
                {
                    foreach (PropModel item in searchs)
                    {
                        if (!string.IsNullOrEmpty(item.value) && item.value != ",")
                        {
                            ExpressionTools.GetEqualPars(item.property, parmList, item.value, item.method);
                        }
                    }
                }

                var list = stuService.GetConditionStu(page, pageSize, sortName, parmList, ref count);
                var DataList = new PagedList<StudentDTO>(list, page, pageSize, count);

                ajax.data = DataList;
                ajax.total = count;         //数据总条数
                ajax.PageIndex = page;      //当前页
                ajax.PageSize = pageSize;   //每页显示条数

                ajax.IsSuccess = true;
                ajax.Message = "查询成功";
            }
            catch (Exception e)
            {
                ajax.Message = e.Message;
            }

            //return ajax;
            return Json(new
            {
                Rows = ajax.data,
                Total = ajax.total,        //数据总条数
                PageIndex = page,      //当前页
                PageSize = pageSize,   //每页显示条数
                TotalPage = ajax.TotalPage
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加页面  代码跳转
        /// <summary>
        /// 代码跳转页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAddStu()
        {
            //TempData["login"] = "zhangchu";

            return RedirectToAction("AddStudent", new { name = "张楚" });
        }

        public ActionResult AddStudent(string txtName)
        {
            //string tname = txtName;
            //string sname = Request["name"].ToString();
            //Student model = stuReporitory.GetAllList().FirstOrDefault(c => c.s_name == sname);
            return View();
        }
        #endregion

        #region 编辑页面
        /// <summary>
        /// 编辑学生信息页面
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns></returns>
        public ActionResult EditStudent(string id)
        {
            #region 下拉框

            Enum status = SysStatus.Enable;
            ViewData["selectList"] = status.GetSelectList(false);

            Enum sex = Gender.Male;
            ViewData["sexLiat"] = sex.GetSelectList(false);

            List<SelectListItem> list = gradeReporitory.GetAllList().Select(c => new SelectListItem { Text = c.GradeName, Value = c.ID.ToString() }).ToList();
            ViewData["gradeList"] = list;


            #endregion

            if (!string.IsNullOrEmpty(id))
            {
                Guid UserId = new Guid(id);
                var model = stuReporitory.GetRepositoy().FirstOrDefault(c => c.s_id == UserId);
                return View(model);
            }
            return View();

        }
        #endregion

        #region Index页面
        /// <summary>
        /// Index页面
        /// </summary>
        /// <param name="txtname"></param>
        /// <param name="pagesize"></param>
        /// <param name="page"></param>
        /// <returns></returns>

        public ActionResult Index(string txtname, int pagesize = 10, int page = 1)
        {
            var dataList = stuService.GetAllStu(txtname, "", "", page, pagesize);
            return View(dataList);
        }
        #endregion

        #region 根据ID获取学生信息
        /// <summary>
        /// 根据学生ID获取学生
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStudentInfo(string sid)
        {
            string name = string.Empty;
            if (!string.IsNullOrEmpty(sid))
            {
                string[] ids = sid.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    var id = new Guid(ids[i]);
                    if (!string.IsNullOrEmpty(id.ToString()))
                    {
                        name += baseService.GetById(id).s_name + ",";
                    }
                }
            }
            if (!string.IsNullOrEmpty(name) && name.Contains(','))
            {
                name = name.Substring(0, name.Length - 1);
            }
            return Json(new { stuName = name }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改状态
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id">学生ID</param>
        /// <returns></returns>
        public JsonResult UpdateStatus(string id)
        {
            AjaxMessage ajax = new AjaxMessage();
            ajax.IsSuccess = false;
            ajax.Message = "系统异常";

            if (!string.IsNullOrEmpty(id))
            {
                Guid sId = new Guid(id.ToString());
                var m_student = stuReporitory.GetFirstOrDefault(c => c.s_id == sId);
                if (m_student != null)
                {
                    if (m_student.s_status == 1)
                    {

                        int result = stuReporitory.Update(c => c.s_id == sId, c => new Student { s_status = 0 });
                        if (result > 0)
                        {
                            ajax.IsSuccess = true;
                            ajax.Message = "禁用成功";
                        }
                    }
                    else
                    {
                        int result = stuReporitory.Update(c => c.s_id == sId, c => new Student { s_status = 1 });
                        if (result > 0)
                        {
                            ajax.IsSuccess = true;
                            ajax.Message = "启用成功";
                        }
                    }
                }
            }
            return Json(ajax);
        }
        #endregion

        #region 编辑页面  修改功能
        /// <summary>
        /// 编辑页面  修改功能
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateStu(Student stu)
        {
            AjaxMessage ajax = new AjaxMessage();
            ajax.IsSuccess = false;
            ajax.Message = "系统异常";
            if (stu != null)
            {
                Student result = stuReporitory.Update(stu);
                if (result != null)
                {
                    ajax.IsSuccess = true;
                    ajax.Message = "修改成功";
                }
            }
            return Json(ajax);
        }
        #endregion
    }
}