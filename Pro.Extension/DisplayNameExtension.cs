using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Reflection;
using System.ComponentModel;

namespace Pro.Extension
{
    public static class DisplayNameExtension
    {

        #region 获取Description

        /// <summary>
        /// 获取枚举的描述信息(Description)
        /// </summary>
        /// <param name="val">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            string str = enumValue.ToString();
            System.Reflection.FieldInfo field = enumValue.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            System.ComponentModel.DescriptionAttribute da = (System.ComponentModel.DescriptionAttribute)objs[0];
            return da.Description;
        }
        #endregion


        #region 获取DisplayName
        /// <summary>
        /// 获取Dsiplayname
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumVal)
        {
            if (enumVal == null) return "无效";
            string enumStr = enumVal.ToString();
            var type = enumVal.GetType();
            string[] enumValues = { enumStr };
            if (enumStr.Contains(","))
            {
                enumValues = enumStr.Split(',').Select(i => i.Trim()).ToArray();
            }

            string showName = "";
            foreach (var item in enumValues)
            {

                var menInfo = type.GetMember(item);
                if (menInfo == null || menInfo.Count() == 0)
                {
                    showName = enumVal.ToString();
                }
                else
                {
                    var attributes = menInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                    DisplayAttribute attribute = (attributes.Length > 0) ? (DisplayAttribute)attributes[0] : null;
                    showName = attribute == null ? enumVal.ToString() : attribute.Name;
                }
            }

            return showName.ToString();
        }

        /// <summary>
        /// 获取displayName
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string GetDisplayNames(this Enum enumVal, string value)
        {
            if (enumVal == null)
            {
                return "无效";
            }

            string showName = "";
            var type = enumVal.GetType();
            var menInfo = type.GetMember(value);

            if (menInfo == null || menInfo.Count() == 0)
            {
                showName = enumVal.ToString();
            }
            else
            {
                var attributes = menInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                DisplayAttribute attribute = (attributes.Length > 0) ? (DisplayAttribute)attributes[0] : null;
                showName = attribute == null ? enumVal.ToString() : attribute.Name;
            }

            return showName.ToString();
        }
        #endregion


        #region 获取list 绑定下拉框
        /// <summary>
        /// 获取listItem
        /// </summary>
        /// <param name="enumObj"></param>
        /// <returns></returns>

        public static List<SelectListItem> GetSelectList(this Enum enumVal, bool isDefault = true)
        {

            List<SelectListItem> selectList = new List<SelectListItem>();

            Type type = enumVal.GetType();
            foreach (int value in Enum.GetValues(type))
            {
                selectList.Add(new SelectListItem() { Text = GetDisplayNames(enumVal, Enum.GetName(type, value)), Value = value.ToString() });
            }
            if (isDefault)
            {
                selectList.Insert(0, new SelectListItem { Text = "请选择", Value = "-1" });
            }
            return selectList;
        }
        #endregion

    }
}
