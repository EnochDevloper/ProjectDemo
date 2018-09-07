using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro.Model
{
    /// <summary>
    /// -
    /// </summary>
    [Table("Student")]
    public partial class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "编号")]
        public Guid s_id { get; set; }

        [StringLength(50)]
        [Display(Name = "姓名")]
        public string s_name { get; set; }

        [StringLength(50)]
        [Display(Name = "登陆名")]
        public string s_loginName { get; set; }

        [StringLength(50)]
        [Display(Name = "密码")]
        public string s_passWord { get; set; }

        [StringLength(200)]
        [Display(Name = "姓名地址")]
        public string s_address { get; set; }

        [Display(Name = "性别")]
        public byte? s_sex { get; set; }

        [Display(Name = "年龄")]
        public int? s_age { get; set; }

        [StringLength(20)]
        [Display(Name = "联系电话")]
        public string s_phone { get; set; }

        [Display(Name = "状态")]
        public byte? s_status { get; set; }

        [Display(Name = "备注")]
        public string s_remark { get; set; }

        [Display(Name = "创建日期")]
        public DateTime? s_createDate { get; set; }

        [Display(Name = "年级")]
        public Guid? s_Grade_ID { get; set; }

    }
}
