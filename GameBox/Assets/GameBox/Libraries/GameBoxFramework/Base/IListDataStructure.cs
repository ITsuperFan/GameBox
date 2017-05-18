/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBoxFramework
{
    public interface IListDataStructure<T> : IDataStructure<T>
    {

        /// <summary>
        /// 获取链表的第一个节点数据
        /// </summary>
        /// <typeparam name="T">节点数据类型</typeparam>
        /// <returns>返回的节点实例</returns>
        T GetFirstNode();

        /// <summary>
        /// 获取链表的最后一个节点数据
        /// </summary>
        /// <typeparam name="T">节点数据类型</typeparam>
        /// <returns>返回的节点实例</returns>
        T GetLastNode();

        /// <summary>
        /// 排序该数据结构
        /// </summary>
        /// <returns></returns>
        IListDataStructure<T> Sort();

        /// <summary>
        /// 转换成节点类型数组
        /// </summary>
        /// <typeparam name="T">节点类型</typeparam>
        /// <returns>返回节点类型数组</returns>
        T[] ToArray();



    }
}