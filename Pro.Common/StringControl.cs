using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Common
{
    public static class StringControl
    {

        /// <summary>
        /// 尝试将字符串转换为数字如字符串非法则返回0
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static int ToInt32(this string Value)
        {
            int IntValue = 0;
            int.TryParse(Value, out IntValue);
            return IntValue;

        }


        /// <summary>
        /// 尝试将字符串转换为十进制数如字符串非法则返回0
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string Value)
        {
            decimal ReturnValue = 0;
            decimal.TryParse(Value, out ReturnValue);
            return ReturnValue;
        }

        /// <summary>
        /// 尝试将字符串转换为十进制数如字符串非法则返回0
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static double ToDouble(this string Value)
        {
            double ReturnValue = 0;
            double.TryParse(Value, out ReturnValue);
            return ReturnValue;
        }



        /// <summary>
        /// 尝试将字符串转换为时间格式 如果字符串非法则返回最小时间
        /// </summary>
        /// <param name="Value"></param>
        public static DateTime? ToDateTime(this string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return DateTime.Now;
            }
            DateTime ReturnValue = DateTime.Now;
            DateTime.TryParse(Value, out ReturnValue);
            return ReturnValue;
        }



        /// <summary>
        /// 尝试将字符串转换GUID 如果不能转换则返回Guid.Empty
        /// </summary>
        /// <param name="Value"></param>
        public static Guid ToGuid(this string Value)
        {
            Guid ReturnValue = Guid.Empty;
            Guid.TryParse(Value, out ReturnValue);
            return ReturnValue;
        }


        /// <summary>
        /// 转换字符串为BOOL类型
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static bool ToBool(this string Value)
        {
            bool ReturnValue = false;
            bool.TryParse(Value, out ReturnValue);
            return ReturnValue;
        }

        /// <summary>
        /// 是否是字符串 并且如果是数字必须大于0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrNumber(this string value)
        {
            bool isNumEmpty = true;
            if (!string.IsNullOrEmpty(value))
            {
                isNumEmpty = false;
                if (value.StartsWith("-"))
                {
                    isNumEmpty = true;
                }
            }
            return isNumEmpty;
        }

    }
}
