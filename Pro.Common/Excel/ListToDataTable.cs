using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Pro.Common
{
    public static class ListToDataTable
    {

        /// <summary>
        /// List转化成Table
        /// </summary>
        /// <returns></returns>
        public static DataTable ListToTable<T>(IList<T> ResList)
        {

            //DataTable TempDT = new DataTable();
            //GetHeadProperties<T>(TempDT);


            ////此处遍历IList的结构并建立同样的DataTable
            //PropertyInfo[] p = ResList[0].GetType().GetProperties();


            //for (int i = 0; i < ResList.Count; i++)
            //{
            //    ArrayList TempList = new ArrayList();
            //    int index = 0;
            //    //将IList中的一条记录写入ArrayList
            //    foreach (PropertyInfo pi in p)
            //    {
            //        Attribute attr = pi.GetCustomAttribute(typeof(ExportAttr), true);
            //        if (attr != null && attr.GetType() == typeof(ExportAttr))
            //        {
            //            object oo = pi.GetValue(ResList[i], null);
            //            TempList.Add(oo);
            //            index++;
            //        }
            //    }

            //    object[] item = new object[index];
            //    //遍历ArrayList向object[]里放数据
            //    for (int j = 0; j < TempList.Count; j++)
            //    {
            //        item.SetValue(TempList[j], j);
            //    }
            //    //将object[]的内容放入DataTable
            //    TempDT.LoadDataRow(item, true);
            //}
            ////返回DataTable
            //return TempDT;
        }


        #region 获取实体类 头部列
        //  设置Dictionary<string, string> 得到实体类的字段名称和值

        public static void GetHeadProperties<T>(DataTable TempDT)
        {
            //if (true)
            //{
            //    //PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            //    PropertyInfo[] properties = typeof(T).GetProperties();
            //    if (properties.Length >= 1)
            //    {
            //        foreach (PropertyInfo objItem in properties)
            //        {

            //            Attribute attr = objItem.GetCustomAttribute(typeof(ExportAttr), true);
            //            if (attr != null && attr.GetType() == typeof(ExportAttr))
            //            {

            //                string DisplayName = objItem.Name;                                                  //实体类字段名称
            //                                                                                                    //string value = objItem.GetValue(t, null).ToString();                              //该字段的值

            //                foreach (var item in objItem.CustomAttributes)
            //                {
            //                    foreach (var item2 in item.NamedArguments)
            //                    {
            //                        DisplayName = item2.TypedValue.Value.ToString();
            //                    }
            //                }
            //                TempDT.Columns.Add(DisplayName);
            //            }
            //        }
            //    }
            //}
        }


        #endregion
    }
}
