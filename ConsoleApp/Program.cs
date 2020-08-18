using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IsRunYear(1896);
            new_MaoPao();
            Console.WriteLine(Foo(30));
        }

        #region 冒泡排序法
        /// <summary>
        /// @author:wp
        /// @datetime:2020-07-22
        /// @desc:冒泡排序法
        /// </summary>
        public static void MaoPao()
        {
            var nums = new int[] { 25, 18, 98, 75, 189, 36, 9, 166, 24 };
            List<int> new_num = new List<int>();
            var o_length = nums.Length;
            var temp = 0;
            for (int i = 1; i < o_length; i++)
            {
                for (int j = 0; j < o_length - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        temp = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            Console.WriteLine("开始");
            foreach (var item in nums)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("结束");
        }
        #endregion

        #region 计算第三十位数
        /// <summary>
        /// 计算第三十位数
        /// </summary>
        public static int Foo(int i)
        {
            var num = 0;
            if (i == 0)
            {
                num = 0;
            }
            else if (i <= 2)
            {
                num = 1;
            }
            else
            {
                num = Foo(i - 1) + Foo(i - 2);
            }
            return num;
        }
        #endregion

        #region 计算最大数
        /// <summary>
        /// 计算最大数
        /// </summary>
        /// <returns></returns>
        public static int MaxNum()
        {
            int max = 0;
            int x = 12, y = 10, z = 15;
            if (x > y)
            {
                max = x;
            }
            else
            {
                max = y;
            }
            if (z > max)
            {
                max = z;
            }
            return max;
        }

        #endregion

        #region 猜数字
        /// <summary>
        /// 猜数字 1-10
        /// </summary>
        public static void IsNum()
        {
            var randon = new Random();
            var text = randon.Next(1, 10);
            var num = Convert.ToInt32(Console.ReadLine());

            while (num != text)
            {
                Console.WriteLine("不好意思 你猜错了 请继续猜");
                num = Convert.ToInt32(Console.ReadLine());
                continue;
            }

            if (num == text)
            {
                Console.WriteLine("恭喜你,猜对了");
            }
        }
        #endregion

        public static void new_MaoPao()
        {
            int[] nums = { 12, 15, 8, 165, 78, 95, 31 };

            var n_length = nums.Length;

            for (int i = 0; i < n_length; i++)
            {
                for (int j = 0; j < n_length - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            foreach (var num in nums)
            {
                Console.Write(num + ",");
            }
        }



        public static void IsRunYear(int year = 1900)
        {
            var isRun = false;
            if (year % 4 == 0 && year % 100 != 0)
            {
                isRun = true;
            }
            else if (year % 400 == 0)
            {
                isRun = true;
            }
            if (isRun)
            {
                Console.WriteLine("是润年");
            }
            else
            {
                Console.WriteLine("不是闰年");
            }
        }
    }


}
