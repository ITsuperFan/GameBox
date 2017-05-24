/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;

namespace GameBoxFramework
{
    public interface IListDataStructure<T>
    {
        /// <summary>
        /// 节点的数量
        /// </summary>
        int NodeCount { get; }

        /// <summary>
        /// 是否包含该节点
        /// </summary>
        /// <param name="t_Value"></param>
        /// <returns></returns>
        bool Contains(T t_Value);

        /// <summary>
        /// 添加数据节点
        /// </summary>
        /// <typeparam name="T">数据节点类型</typeparam>
        void AddNode(T t_Node);

        /// <summary>
        /// 获取数据节点
        /// </summary>
        /// <typeparam name="T">数据节点类型</typeparam>
        /// <param name="t_Handler">查询委托</param>
        /// <returns>返回数据节点实例</returns>
        T GetNode(Func<T, bool> t_Handler);

        /// <summary>
        /// 删除数据节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t_Node"></param>
        void RemoveNode(Func<T, bool> t_Handler);


        /// <summary>
        /// 清除所有的数据节点
        /// </summary>
        void Clear();

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