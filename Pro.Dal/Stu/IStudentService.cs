using Pro.Common;
using Pro.Interface;
using Pro.Model;
using Pro.Model.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Dal.Stu
{
    public interface IStudentService
    {
        /// <summary>
        /// 获取所有学生信息
        /// </summary>
        /// <returns></returns>
        PagedList<Student> GetAllStu(string stuName, string Status, string Sort, int currentPage, int pageSize);

        /// <summary>
        /// 条件查询
        /// </summary>
        List<StudentDTO> GetConditionStu(int page, int pagesize, string sortName, List<Expression<Func<StudentDTO, bool>>> parmList, ref int count);

        Student GetModel(string id);

        Student ModifyStudent(Student stu);


        int ModifyStatus(string id, int status);

        int DeleteStu(string id);
    }
}
