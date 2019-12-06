using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro.Model
{
    /// <summary>
    /// 项目立项
    /// </summary>
    [Table("PM_ProjectInfo")]
    public partial class PM_ProjectInfo
    {


        /// <summary>
        /// ID
        /// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid ID { get; set; }


        /// <summary>
        /// 立项名称
        /// </summary>
		[StringLength(500)]
		public string ProjectName { get; set; }


        /// <summary>
        /// 立项编号
        /// </summary>
		[StringLength(200)]
		public string ProjectCode { get; set; }


        /// <summary>
        /// 项目来源
        /// </summary>
		public Guid? ProjectSource { get; set; }


        /// <summary>
        /// 项目类型
        /// </summary>
		[StringLength(2000)]
		public string ProjectType { get; set; }


        /// <summary>
        /// 项目跟踪阶段
        /// </summary>
		public Guid? ProjectTrackPhase { get; set; }


        /// <summary>
        /// 项目地点
        /// </summary>
		[StringLength(500)]
		public string ProjectLocation { get; set; }


        /// <summary>
        /// 项目规模
        /// </summary>
		[StringLength(500)]
		public string ProjectScale { get; set; }


        /// <summary>
        /// 项目确定方式
        /// </summary>
		public Guid? ProjectWay { get; set; }


        /// <summary>
        /// 是否已发布招标公告
        /// </summary>
		public int? IsTender { get; set; }


        /// <summary>
        /// 预计合同金额
        /// </summary>
		public decimal? Amount { get; set; }


        /// <summary>
        /// 经营主导人
        /// </summary>
		[StringLength(50)]
		public string Responsible { get; set; }


        /// <summary>
        /// 立项项目状态
        /// </summary>
		public int? Status { get; set; }


        /// <summary>
        /// 经营主导人ID
        /// </summary>
		public Guid? ResponsibleID { get; set; }


        /// <summary>
        /// 项目来源其他
        /// </summary>
		[StringLength(500)]
		public string ProjectSourceOther { get; set; }


        /// <summary>
        /// 项目类型其他
        /// </summary>
		[StringLength(500)]
		public string ProjectTypeOther { get; set; }


        /// <summary>
        /// 申请人
        /// </summary>
		[StringLength(50)]
		public string ApplyUser { get; set; }


        /// <summary>
        /// 申请人ID
        /// </summary>
		public Guid? ApplyUserID { get; set; }


        /// <summary>
        /// 申请时间
        /// </summary>
		public DateTime? ApplyTime { get; set; }


        /// <summary>
        /// 实施名称
        /// </summary>
		[StringLength(500)]
		public string ImplementationName { get; set; }


        /// <summary>
        /// 业主单位
        /// </summary>
		[StringLength(500)]
		public string ConstructionUnits { get; set; }


        /// <summary>
        /// 业主单位ID
        /// </summary>
		[StringLength(100)]
		public string ConstructionUnitIDs { get; set; }


        /// <summary>
        /// 联系人
        /// </summary>
		[StringLength(500)]
		public string Contact { get; set; }


        /// <summary>
        /// 项目工期开始
        /// </summary>
		public DateTime? DurationStart { get; set; }


        /// <summary>
        /// 项目工期结束
        /// </summary>
		public DateTime? DurationEnd { get; set; }


        /// <summary>
        /// 移交事项
        /// </summary>
		[StringLength(1000)]
		public string Transfer { get; set; }


        /// <summary>
        /// 其他情况说明
        /// </summary>
		[StringLength(4000)]
		public string Description { get; set; }


        /// <summary>
        /// 项目等级
        /// </summary>
		public Guid? ProjectRegistration { get; set; }


        /// <summary>
        /// 项目负责人
        /// </summary>
		[StringLength(50)]
		public string ProjectManager { get; set; }


        /// <summary>
        /// 项目负责人ID
        /// </summary>
		public Guid? ProjectManagerID { get; set; }


        /// <summary>
        /// 技术负责人
        /// </summary>
		[StringLength(50)]
		public string Technical { get; set; }


        /// <summary>
        /// 技术负责人ID
        /// </summary>
		public Guid? TechnicalID { get; set; }


        /// <summary>
        /// 主要接收生产部门ID
        /// </summary>
		public Guid? MainDeptID { get; set; }


        /// <summary>
        /// 其他接收生产部门ID
        /// </summary>
		[StringLength(8000)]
		public string OtherDeptID { get; set; }


        /// <summary>
        /// 主要接收生产部门
        /// </summary>
		[StringLength(200)]
		public string MainDept { get; set; }


        /// <summary>
        /// 其他接收生产部门
        /// </summary>
		[StringLength(4000)]
		public string OtherDept { get; set; }


        /// <summary>
        /// 审批状态0进行中1审批通过2终止
        /// </summary>
		public int? ApprovalStatus { get; set; }


        /// <summary>
        /// 项目信息确认人ID
        /// </summary>
		public Guid? ConfirmUserID { get; set; }


        /// <summary>
        /// 项目信息确认人姓名
        /// </summary>
		[StringLength(50)]
		public string ConfirmUserName { get; set; }


        /// <summary>
        /// 项目信息确认时间
        /// </summary>
		public DateTime? ConfirmTime { get; set; }


        /// <summary>
        /// 项目信息确认处理人ID
        /// </summary>
		public Guid? RemineUserID { get; set; }


        /// <summary>
        /// 项目类型名称
        /// </summary>
		[StringLength(50)]
		public string ProjectTypeName { get; set; }


        /// <summary>
        /// 移交事项名称
        /// </summary>
		[StringLength(50)]
		public string TransferName { get; set; }

    }
}
