using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pro.WebApi.Models
{
    /// <summary>
    /// 写入日志文件
    /// </summary>
    public class LogHelper
    {
        private LogHelper()
        {
            SetConfig();
        }

        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        public static void WriteLog(string info)
        {
            var isEnable = logerror.IsInfoEnabled;
            //if (loginfo.IsInfoEnabled)
            //{
            loginfo.Info(info);
            //}
        }

        public static void WriteLog(string info, Exception se)
        {
            var isEnable = logerror.IsErrorEnabled;
            //if (logerror.IsErrorEnabled)
            //{
            logerror.Error(info, se);
            //}
        }
    }
}