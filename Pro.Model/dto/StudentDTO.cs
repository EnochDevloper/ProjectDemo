using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Model.dto
{
    public class StudentDTO
    {

        [Display(Name = "主键ID")]
        public Guid s_id { get; set; }

        [Display(Name = "姓名")]
        public string s_name { get; set; }

        [Display(Name = "登录名")]
        public string s_loginName { get; set; }

        [Display(Name = "密码")]
        public string s_passWord { get; set; }

        [Display(Name = "地址")]
        public string s_address { get; set; }

        [Display(Name = "性别")]
        public byte? s_sex { get; set; }

        [Display(Name = "性别")]
        public string SexName { get; set; }

        [Display(Name = "年龄")]
        public int? s_age { get; set; }

        [Display(Name = "联系电话")]
        public string s_phone { get; set; }

        [Display(Name = "状态ID")]
        public byte? s_status { get; set; }

        [Display(Name = "状态")]
        public string StatusName { get; set; }

        [Display(Name = "备注")]
        public string s_remark { get; set; }

        [Display(Name = "创建日期")]
        public DateTime? s_createDate { get; set; }

        [Display(Name = "年级")]
        public Guid? s_Grade_ID { get; set; }

        [Display(Name = "年级")]
        public string GradeName { get; set; }
    }
}
