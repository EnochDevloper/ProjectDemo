using Newtonsoft.Json;
using Pro.Model;
using Pro.Model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Autofac.Core.Activators.Reflection;

namespace Pro.Web.Controllers
{
    public class BaseController : Controller
    {

        #region 树形 获取用户
        /// <summary>
        /// 属性获取用户
        /// </summary>
        /// <returns></returns>

        public string GetTreeView(string name = "")
        {
            var deptList = new EFDbContext().Grade.ToList();
            var userList = new EFDbContext().Student.ToList();

            List<TreeVO> tree = new List<TreeVO>();


            if (!string.IsNullOrEmpty(name))
            {
                userList = userList.Where(c => c.s_name.Contains(name)).ToList();
                deptList = (from c in userList join d in deptList on c.s_Grade_ID equals d.ID select d).ToList();
            }

            foreach (var item in deptList)
            {
                TreeVO entity = new TreeVO();
                entity.id = item.ID;
                entity.pid = Guid.Empty;
                entity.name = item.GradeName;
                tree.Add(entity);
            }

            foreach (var item in userList)
            {
                TreeVO entity = new TreeVO();

                entity.id = item.s_id;
                entity.pid = item.s_Grade_ID;
                entity.name = item.s_name;
                tree.Add(entity);

            }

            string strResult = JsonConvert.SerializeObject(tree);
            return strResult;
        }
        #endregion
    }
}