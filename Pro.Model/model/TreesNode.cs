using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Model.model
{
    /// <summary>
    /// @author:wp
    /// @dateime:2019-12-04
    /// @desc:vue中树形实体
    /// </summary>
    public class TreesNode
    {
        /// <summary>
        /// 树形中名称显示
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// ID标识
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        ///子集
        /// </summary>
        public List<TreesNode> Children { get; set; }

    }
}
