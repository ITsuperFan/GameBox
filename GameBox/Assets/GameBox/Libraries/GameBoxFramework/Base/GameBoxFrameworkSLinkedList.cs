/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using GameBoxFramework.Algorithms;

namespace GameBoxFramework
{
    public sealed class GameBoxFrameworkSLinkedList : IListDataStructure<BaseModule>
    {
        /// <summary>
        /// 单链表实例
        /// </summary>
        private readonly SLinkedList<BaseModule> m_SLinkedList = new SLinkedList<BaseModule>();

        /// <summary>
        /// 获取链表的第一个节点数据
        /// </summary>
        /// <typeparam name="T">节点数据类型</typeparam>
        /// <returns>返回的节点实例</returns>
        public BaseModule GetFirstNode()
        {
            return m_SLinkedList.First;
        }
        /// <summary>
        /// 获取链表的最后一个节点数据
        /// </summary>
        /// <typeparam name="T">节点数据类型</typeparam>
        /// <returns>返回的节点实例</returns>
        public BaseModule GetLastNode()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 添加数据节点
        /// </summary>
        /// <typeparam name="T">数据节点类型</typeparam>
        public void AddNode(BaseModule t_Node)
        {
            m_SLinkedList.Append(t_Node);
        }
        /// <summary>
        /// 获取数据节点
        /// </summary>
        /// <typeparam name="T">数据节点类型</typeparam>
        /// <param name="t_Handler">查询委托</param>
        /// <returns>返回数据节点实例</returns>
        public BaseModule GetNode(Func<BaseModule, bool> t_Handler)
        {
            var t_ToList = m_SLinkedList.ToList(); //转换成System.List
            for (int i = 0; i < t_ToList.Count; i++)
            {
               
                if (t_Handler(t_ToList[i]))
                {
                    return t_ToList[i];
                }
            }
            return null;
        }
        /// <summary>
        /// 删除数据节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t_Node"></param>
        public void RemoveNode(Func<BaseModule, bool> t_Handler)
        {
            var t_ToList = m_SLinkedList.ToList(); //转换成System.List
            for (int i = 0; i < t_ToList.Count; i++)
            {
                if (t_Handler(t_ToList[i]))
                {
                    m_SLinkedList.RemoveAt(i);
                    return;
                }
            }
        }
        /// <summary>
        /// 排序该数据结构
        /// </summary>
        /// <returns></returns>
        public IListDataStructure<BaseModule> Sort()
        {
            m_SLinkedList.SelectionSort(); //选择排序
            return this;
        }
        /// <summary>
        /// 转换成节点类型数组
        /// </summary>
        /// <typeparam name="T">节点类型</typeparam>
        /// <returns>返回节点类型数组</returns>
        public BaseModule[] ToArray()
        {
            return m_SLinkedList.ToArray(); //转换成System.Array
        }
    }
}