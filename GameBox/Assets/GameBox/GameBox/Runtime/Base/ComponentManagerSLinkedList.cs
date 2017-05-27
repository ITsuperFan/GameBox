/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using GameBoxFramework.Algorithms;
using GameBoxFramework;

namespace GameBox
{
    public sealed class ComponentManagerSLinkedList : IListDataStructure<BaseGameBoxComponent>
    {
        /// <summary>
        /// 单链表实例
        /// </summary>
        private readonly SLinkedList<BaseGameBoxComponent> m_SLinkedList = new SLinkedList<BaseGameBoxComponent>();

        /// <summary>
        /// 节点数量
        /// </summary>
        public int NodeCount
        {
            get
            {
                return m_SLinkedList.Count;
            }
        }

        /// <summary>
        /// 获取链表的第一个节点数据
        /// </summary>
        /// <typeparam name="T">节点数据类型</typeparam>
        /// <returns>返回的节点实例</returns>
        public BaseGameBoxComponent GetFirstNode()
        {
            return m_SLinkedList.First;
        }
        /// <summary>
        /// 获取链表的最后一个节点数据
        /// </summary>
        /// <typeparam name="T">节点数据类型</typeparam>
        /// <returns>返回的节点实例</returns>
        public BaseGameBoxComponent GetLastNode()
        {
            return m_SLinkedList.Last;
        }
        /// <summary>
        /// 添加数据节点
        /// </summary>
        /// <typeparam name="T">数据节点类型</typeparam>
        public void AddNode(BaseGameBoxComponent t_Node)
        {
            m_SLinkedList.Append(t_Node);
        }
        /// <summary>
        /// 获取数据节点
        /// </summary>
        /// <typeparam name="T">数据节点类型</typeparam>
        /// <param name="t_Handler">查询委托</param>
        /// <returns>返回数据节点实例</returns>
        public BaseGameBoxComponent GetNode(Func<BaseGameBoxComponent, bool> t_Handler)
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
        public void RemoveNode(Func<BaseGameBoxComponent, bool> t_Handler)
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
        public IListDataStructure<BaseGameBoxComponent> Sort()
        {
            m_SLinkedList.SelectionSort(); //选择排序
            return this;
        }
        /// <summary>
        /// 转换成节点类型数组
        /// </summary>
        /// <typeparam name="T">节点类型</typeparam>
        /// <returns>返回节点类型数组</returns>
        public BaseGameBoxComponent[] ToArray()
        {
            return m_SLinkedList.ToArray(); //转换成System.Array
        }

        /// <summary>
        /// 清除所有的数据节点
        /// </summary>
        public void Clear()
        {
            m_SLinkedList.Clear();
        }

        /// <summary>
        /// 是否包含该节点
        /// </summary>
        /// <param name="t_Value"></param>
        /// <returns></returns>
        public bool Contains(BaseGameBoxComponent t_Value)
        {
            var t_ToList = m_SLinkedList.ToList(); //转换成System.List
            return t_ToList.Contains(t_Value);
        }

    }
}