using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Common
{
    public class AjaxMessage
    {
        //是否成功
        public bool IsSuccess { get; set; }

        //消息提示
        private string message;

        public string Message
        {
            get { return string.IsNullOrEmpty(message) ? "" : message; }
            set { message = value; }
        }

        //过期时间
        private int timeOut;

        public int TimeOut
        {
            get { return timeOut == 0 ? 1200 : timeOut; }
            set { timeOut = value; }
        }

        private string value;

        public string Value
        {
            get { return string.IsNullOrEmpty(value) ? "" : value; }
            set { this.value = value; }
        }

        private string[] name;

        public string[] Name
        {
            get { return this.name; }
            set { this.name = value; }
        }


        public Object data { get; set; }

        public Object Data { get; set; }

        //public Object Data
        //{
        //    get { return data; }
        //    set { data = value; }
        //}

        private int id;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        private int index;

        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }

        private string empId { get; set; }

        public string EmpId
        {
            get { return this.empId; }
            set { this.empId = value; }
        }

        private int count;

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        private int pageIndex;
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }

            set
            {
                pageIndex = value;
            }
        }

        private int pageSize;
        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }

        public int total { get; set; }

        public string type { get; set; }

        private int totalPage;
        public int TotalPage
        {
            get
            {
                if (PageSize > 0)
                {
                    return total % PageSize == 0 ? total / PageSize : (total / PageSize) + 1;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                totalPage = value;
            }
        }
    }
}
