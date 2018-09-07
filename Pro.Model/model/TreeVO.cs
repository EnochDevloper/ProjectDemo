using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Model.model
{
    /**
  * zTree树形结构对象VO类
  * 
  * @author Administrator
  * 
  */
    public class TreeVO
    {
        public Guid? id { get; set; }

        public Guid? pid { get; set; }
        public string name { get; set; }

    }
}
