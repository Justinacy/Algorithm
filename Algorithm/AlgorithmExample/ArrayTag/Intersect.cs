using Algorithm.AlgorithmExample.ArrayTag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

int[] item;
IntersectTest intersect = new IntersectTest();
int[] numOne = new int[] { 1, 2, 2, 1 };
int[] numTwo = new int[] { 2, 2 };
//foreach(var item in intersect.LinqIntersect(numOne, numTwo))
//{
//    Console.WriteLine(item);
//}
// item = intersect.TwoIntersectUp(new int[] { 1, 2, 3, 4, 4, 13 }, new int[] { 1, 2, 3, 9, 10 });
item = intersect.TwoIntersect(new int[] { 1, 3, 4 }, new int[] { 1, 3, 3, 4 });

foreach (var i in item)
{
    Console.WriteLine(i);
}



namespace Algorithm.AlgorithmExample.ArrayTag
{
    /// <summary>
    /// 数组交集
    /// </summary>
    public class IntersectTest
    {

        /// <summary>
        /// C# linq方法求数组交集
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int[] LinqIntersect(int[] num1, int[] num2)
        {
            //会自动去重
            return num1.Intersect(num2).ToArray();
        }



        /// <summary>
        /// 例：输入: nums1 = [1,2,2,1], nums2 = [2,2]  输出: [2,2]
        /// 输出结果中每个元素出现的次数，应与元素在两个数组中出现的次数一致(应与元素在两个数组中出现次数的最小值一致)。
        /// 我们可以不考虑输出结果的顺序。
        /// </summary>     
        public int[] TwoIntersect(int[] num1, int[] num2)
        {
            //因为要考虑元素在数组中出现的次数，采取字典方式(Java中等同于Map)，将元素与出现次数映射
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            List<int> list = new List<int>();

            foreach (var item1 in num1)
            {
                //初始化字典
                if (keyValuePairs.ContainsKey(item1))
                {
                    //字典中key相同时将value+1
                    keyValuePairs[item1]++;
                }
                else
                {
                    //否则追加进数组
                    keyValuePairs.Add(item1, 1);
                }
            }

            //遍历数组2
            foreach (var item2 in num2)
            {
                //比较元素是否相等，并且出现次数大于0，因为当元素相等时将出现次数减一，当出现次数小于等于0时表示当前元素在两个
                //出现次数不一致
                if (keyValuePairs.ContainsKey(item2) && keyValuePairs[item2] > 0)
                {
                    list.Add(item2);
                    keyValuePairs[item2]--;
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// 输出结果中的每个元素一定是唯一的。
        //  我们可以不考虑输出结果的顺序。
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int[] TwoIntersect2(int[] num1, int[] num2)
        {
            List<int> list = new List<int>();
            foreach (var item1 in num1)
            {
                foreach (var item2 in num2)
                {
                    //!list.Contains(item1) 保证结果中出现结果为唯一值
                    if (item1 == item2 && !list.Contains(item1))
                    {
                        list.Add(item2);
                    }
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// 如果给定的数组已经排好序呢？你将如何优化你的算法？我们分析一下，假如两个数组都是有序的，分别为：arr1 = [1,2,3,4,4,13]，arr2 = [1,2,3,9,10]
        /// 不需要申请新的数组,避免浪费空间
        /// </summary>
        /// <returns></returns>
        public int[] TwoIntersectUp(int[] arr1, int[] arr2)
        {
            Array.Sort(arr2);
            Array.Sort(arr1);
            //声明指针
            int a = 0, b = 0, c = 0;
            //指针应不超过数组长度
            while (a < arr1.Length && b < arr2.Length)
            {
                //元素小的指针往后移动
                if (arr1[a] < arr2[b])
                {
                    a++;
                }
                else if (arr1[a] > arr2[b])
                {
                    b++;
                }
                else
                {
                    //元素相等时指针同时移动
                    arr1[c] = arr1[a];
                    Console.WriteLine(arr1[a]);
                    c++;
                    a++;
                    b++;
                }
            }
            //截取相等部分
            return arr1.Take(c).ToArray();
        }
    }
}
