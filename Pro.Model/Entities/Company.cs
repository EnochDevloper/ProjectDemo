using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro.Model
{
    /// <summary>
    /// -
    /// </summary>
    [Table("Company")]
    public partial class Company
    {


        /// <summary>
        /// 公司ID
        /// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CompanyID { get; set; }


        /// <summary>
        /// 公司名称
        /// </summary>
		[StringLength(50)]
		public string CompanyName { get; set; }


        /// <summary>
        /// 上级公司ID
        /// </summary>
		public int? PId { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
		public DateTime? CreateDate { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
		public bool? IsDelete { get; set; }

    }
}
