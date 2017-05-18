/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Collections.Generic;


namespace GameBoxFramework.Extension
{
    /// <summary>
    /// 链表帮助类
    /// </summary>
    public static class ListExitension
    {
        /// <summary>
        /// IList<T> 交换两个数
        /// </summary>
        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (list.Count < 2 || firstIndex == secondIndex)   
                return;

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        ///// <summary>
        ///// ArrayList<T> 交换两个数
        ///// </summary>
        //public static void Swap<T>(this ArrayList<T> list, int firstIndex, int secondIndex)
        //{
        //    if (list.Count < 2 || firstIndex == secondIndex)   //This check is not required but Partition function may make many calls so its for perf reason
        //        return;

        //    var temp = list[firstIndex];
        //    list[firstIndex] = list[secondIndex];
        //    list[secondIndex] = temp;
        //}

        /// <summary>
        /// 给改链表的每一个节点赋予初始化的值
        /// </summary>
        public static void Populate<T>(this IList<T> collection, T value)
        {
            if (collection == null)
                return;

            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = value;
            }
        }
    }
}

