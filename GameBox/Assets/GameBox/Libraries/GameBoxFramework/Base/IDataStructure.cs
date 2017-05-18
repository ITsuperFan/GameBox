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
    public interface IDataStructure<T>
	{

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
        T GetNode(Func<T,bool> t_Handler);

        /// <summary>
        /// 删除数据节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t_Node"></param>
        void RemoveNode(Func<T, bool> t_Handler);



	}
}