/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;

namespace GameBoxFramework
{
    /// <summary>
    /// 数据结构接口
    /// </summary>
    public interface IDataStructure 
	{

        /// <summary>
        /// 获取第一个节点数据
        /// </summary>
        /// <typeparam name="T">节点数据类型</typeparam>
        /// <returns>返回的节点实例</returns>
        T GetFirstNode<T>();

        /// <summary>
        /// 获取最后一个节点数据
        /// </summary>
        /// <typeparam name="T">节点数据类型</typeparam>
        /// <returns>返回的节点实例</returns>
        T GetLastNode<T>();

        /// <summary>
        /// 添加数据节点
        /// </summary>
        /// <typeparam name="T">数据节点类型</typeparam>
        void AddNode<T>(T t_Node);

        /// <summary>
        /// 获取数据节点
        /// </summary>
        /// <typeparam name="T">数据节点类型</typeparam>
        /// <param name="t_Handler">查询委托</param>
        /// <returns>返回数据节点实例</returns>
        T GetNode<T>(Func<T,bool> t_Handler);

        /// <summary>
        /// 删除数据节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t_Node"></param>
        void Remove<T>(Func<T, bool> t_Handler);

        /// <summary>
        /// 排序该数据结构
        /// </summary>
        /// <returns></returns>
        IDataStructure Sort();

	}
}