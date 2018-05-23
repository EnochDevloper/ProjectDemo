using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pro.Common
{


    /// <summary>
    /// 用户状态
    /// </summary>
    public enum SysStatus
    {
        /// <summary>
        /// 禁用
        /// </summary>
        [Display(Name = "禁用")]
        Disable = 0,

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        Enable = 1,
    }


    /// <summary>
    /// 用户状态
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 禁用
        /// </summary>
        [Display(Name = "男")]
        Male = 0,

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "女")]
        Femal = 1,
    }

    /// <summary>
    /// 年级
    /// </summary>
    public enum GradeName
    {
        /// <summary>
        /// 一年级
        /// </summary>
        [Display(Name = "一年级")]
        FirstGrade = 1,

        /// <summary>
        /// 二年级
        /// </summary>
        [Display(Name = "二年级")]
        SecondGrade = 2,

        /// <summary>
        /// 三年级
        /// </summary>
        [Display(Name = "三年级")]
        ThirdGrade = 3,
    }

}
