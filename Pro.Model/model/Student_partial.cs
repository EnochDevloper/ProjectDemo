using Pro.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Model
{
    public partial class Student
    {
        [NotMapped]
        [Display(Name = "状态")]
        public SysStatus StatusValue
        {
            get
            {
                return (SysStatus)(this.s_status == null ? 0 : this.s_status);
            }
            set
            {
                this.s_status = Convert.ToByte(value);
            }
        }


        [NotMapped]
        [Display(Name = "状态")]
        public Gender SexValue
        {
            get
            {
                return (Gender)(this.s_sex == null ? 0 : this.s_sex);
            }
            set
            {
                this.s_sex = Convert.ToByte(value);
            }
        }

        //[NotMapped]
        //[Display(Name = "年级")]
        //public GradeName GradeValue
        //{
        //    get
        //    {
        //        return (GradeName)(this.s_GradeID == null ? Guid.Empty : this.s_GradeID);
        //    }
        //    set
        //    {
        //        this.s_GradeID = new Guid(value);
        //    }
        //}
    }
}
