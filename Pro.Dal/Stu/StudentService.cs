using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pro.Model;
using Pro.Repository.Repository;
using Pro.Common;
using System.Linq.Expressions;
using System.Data.Entity;
using Pro.Model.dto;
using EntityFramework.Extensions;

namespace Pro.Dal.Stu
{
    public class StudentService : IStudentService
    {
        EFDbContext ObjEntity = new EFDbContext();
        private IDataRepository<Student> StuBLL;

        public StudentService()
        {
            this.StuBLL = new DataRepository<Student>();
        }

        /// <summary>
        /// 编辑修改学生信息想
        /// </summary>
        public Student ModifyStudent(Student stu)
        {
            return StuBLL.Update(stu);
        }

        /// <summary>
        /// 获取所有学生信息
        /// </summary>
        /// <returns></returns>
        public PagedList<Student> GetAllStu(string stuName, string Status, string Sort, int currentPage, int pageSize)
        {

            int count = 0;
            Expression<Func<Student, DateTime?>> order = c => c.s_createDate;
            List<Expression<Func<Student, bool>>> parmList = new List<Expression<Func<Student, bool>>>();

            //学生姓名查找
            if (!string.IsNullOrEmpty(stuName))
            {
                parmList.Add(c => c.s_name.Contains(stuName));
            }

            //根据状态查找
            if (!string.IsNullOrEmpty(Status) && Status.ToInt32() >= 0)
            {
                parmList.Add(c => c.s_status.ToString() == Status);
            }

            var dataList = StuBLL.GetDataByPage(currentPage, pageSize, parmList, Sort, ref count);
            return new PagedList<Student>(dataList, currentPage, pageSize, count);
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="parmList"></param>
        /// <returns></returns>
        public List<StudentDTO> GetConditionStu(int page, int pagesize, string sortName, List<Expression<Func<StudentDTO, bool>>> parmList, ref int count)
        {
            var query = (from c in ObjEntity.Student
                         join d in ObjEntity.Grade on c.s_Grade_ID equals d.ID
                         select new StudentDTO()
                         {
                             s_id = c.s_id,
                             s_name = c.s_name,
                             s_address = c.s_address,
                             s_sex = c.s_sex,
                             s_age = c.s_age,
                             s_createDate = c.s_createDate,
                             s_loginName = c.s_loginName,
                             s_passWord = c.s_passWord,
                             s_phone = c.s_phone,
                             s_remark = c.s_remark,
                             s_status = c.s_status,
                             SexName = c.s_sex == 0 ? "男" : "女",
                             StatusName = c.s_status == 1 ? "启用" : "禁用",
                             s_Grade_ID=c.s_Grade_ID,
                             GradeName = d.GradeName
                         });

            if (parmList != null || parmList.Count!=0)
            {
                foreach (var parm in parmList)
                {
                    query = query.Where(parm);
                }
            }
            //返回总条数
            count = query.Count();
            if (count > 0)
            {
                query = SortTools.SortingAndPaging<StudentDTO>(query, sortName, page, pagesize);
                return query.ToList();
            }
            else
            {
                return new List<StudentDTO> { };
            }
        }




        /// <summary>
        /// 获取实体类
        /// </summary>
        /// <returns></returns>
        public Student GetModel(string id)
        {
            Guid sId = new Guid(id.ToString());
            return StuBLL.GetFirstOrDefault(c => c.s_id == sId);
        }


        /// <summary>
        ///修改状态
        /// </summary>
        /// <returns></returns>
        public int ModifyStatus(string id, int status)
        {
            int result = 0;

            string[] ids = id.Split(',');
            List<string> id_list = new List<string>();
            int length = id_list.Count;
            for (int i = 0; i < ids.Length; i++)
            {
                string sid = ids[i];
                id_list.Add(sid);
            }
            if (id_list.Count > 0)
            {
                result = StuBLL.Update(c => id_list.Contains(c.s_id.ToString()), r => new Student { s_status = (byte)status });
            }

            return result;
        }

        /// <summary>
        /// 根据主键ID删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteStu(string id)
        {
            int result = 0;

            return result;
        }
    }
}
