
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Pro.Repository;
using Pro.Common;


namespace HHLWedding.Web.AdminWorkArea.Handler
{
    /// <summary>
    /// ImportCustomer 的摘要说明
    /// </summary>
    public class ImportCustomer : IHttpHandler
    {

        #region 服务

      

        #endregion

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/octet-stream";
            //HttpPostedFile imgFile = context.Request.Files["upFile"];           //upFile   就是input的name
            ImportFile(context);

        }


        /// <summary>
        /// 导入客户文件
        /// </summary>

        public void ImportFile(HttpContext context)
        {
            //获取上传的excel文件
            HttpFileCollection file = HttpContext.Current.Request.Files;

            AjaxMessage ajax = new AjaxMessage();
            ajax.IsSuccess = false;

            string pathAddress = "";        //完整的excel保存路径
            string type = "success";          //成功状态
            string suffix = "";             //后缀名
            try
            {



                if (file.Count == 0)
                {
                    //直接点击导入 没有选择Excel文件  
                    ajax.Message = "文件不能为空,请选择上传文件";
                    type = "error";
                }
                else
                {
                    HttpPostedFile upFile = file[0];

                    #region 判断文件类型 大小 保存文件

                    if (type == "success")
                    {
                        int filesize = upFile.ContentLength;                                            //excel文件大小
                        int Maxsize = 4000 * 1024;                                                      //最大空间大小为4M
                        string filename = DateTime.Now.ToString("HHmmssfff") + upFile.FileName;         //文件名
                        string path = HttpContext.Current.Server.MapPath("/Template/");                 //文件夹路径
                        pathAddress = path + filename;                                                  //完整的excel保存路径
                        suffix = Path.GetExtension(pathAddress).ToString();                             //获取后缀名


                        if (suffix != ".xls" && suffix != ".xlsx")
                        {
                            ajax.Message = "上传文件必须是xlsx或xls文件";
                            type = "error";
                        }
                        else
                        {
                            if (filesize > Maxsize)
                            {
                                ajax.Message = "文件大小不能超过4M";
                                type = "error";
                            }
                            else
                            {
                                //判断文件夹是否存在  若不存在 就新建
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                //保存Excel
                                upFile.SaveAs(pathAddress);

                                type = "success";
                            }
                        }
                    }
                    #endregion

                    #region 验证excel模板(根据标题验证)
                    //获取excel的数据  用DataTable保存

                    #endregion

                    #region 循环验证excel里的内容
                    DataTable dt = ExcelUtil.ExcelToDataTable(pathAddress, "getTitle");

                    if (type == "success")
                    {
                        if (dt != null)
                        {
                            for (int i = 1; i < dt.Rows.Count; i++)
                            {
                                DataRow row = dt.Rows[i];
                            }
                        }
                    }
                    #endregion

                    #region 添加客户至数据库
                    if (type == "success")
                    {

                    }
                    #endregion
                }
            }
            catch (SqlException ex)
            {
                ajax.Message = ex.Message + "   请重新导入！";
                type = "error";
            }
            catch (Exception e)
            {
                ajax.Message = e.Message;
                type = "error";
            }
            finally
            {
                //删除Excel文件
                if (File.Exists(pathAddress))
                {
                    File.Delete(pathAddress);
                }
            }

            context.Response.Write(JsonConvert.SerializeObject(ajax));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}