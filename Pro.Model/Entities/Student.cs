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
		public Guid s_id { get; set; }

		[StringLength(50)]
		public string s_name { get; set; }

		[StringLength(50)]
		public string s_loginName { get; set; }

		[StringLength(50)]
		public string s_passWord { get; set; }

		[StringLength(200)]
		public string s_address { get; set; }

		public byte? s_sex { get; set; }

		public int? s_age { get; set; }

		[StringLength(20)]
		public string s_phone { get; set; }

		public byte? s_status { get; set; }

		public string s_remark { get; set; }

		public DateTime? s_createDate { get; set; }

		public Guid? s_Grade_ID { get; set; }

    }
}
