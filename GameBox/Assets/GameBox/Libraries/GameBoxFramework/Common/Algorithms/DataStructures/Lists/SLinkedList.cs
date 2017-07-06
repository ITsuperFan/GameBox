/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using System.Collections.Generic;
using GameBoxFramework.Extension;

namespace GameBoxFramework.Algorithms
{
    /// <summary>
    /// 单链表的节点类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SLinkedListNode<T> : IComparable<SLinkedListNode<T>> where T : IComparable<T>
    {
        private T m_Data;
        private SLinkedListNode<T> m_Next;

        /// <summary>
        /// 默认构造方法
        /// </summary>
        public SLinkedListNode()
        {
            Next = null;
            Data = default(T);
        }
        /// <summary>
        /// 初始化Data的构造方法
        /// </summary>
        /// <param name="dataItem"></param>
        public SLinkedListNode(T dataItem)
        {
            Next = null;
            Data = dataItem;
        }
        /// <summary>
        /// Data属性
        /// </summary>
        public T Data
        {
            get { return this.m_Data; }
            set { this.m_Data = value; }
        }
        /// <summary>
        /// Next属性
        /// </summary>
        public SLinkedListNode<T> Next
        {
            get { return this.m_Next; }
            set { this.m_Next = value; }
        }
        /// <summary>
        /// 比较接口的实现
        /// </summary>
        /// <param name="other">比较类型的实例</param>
        /// <returns>比较后的返回值</returns>
        public int CompareTo(SLinkedListNode<T> other)
        {
            if (other == null) return -1; //空值一般比非空的优先，因为可以再次赋值新的数据

            return this.Data.CompareTo(other.Data);
        }
    }


    /// <summary>
    /// 单链表类
    /// </summary>
    public class SLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        /// <summary>
        /// 节点数量
        /// </summary>
        private int m_Count;
        /// <summary>
        /// 第一个节点的值
        /// </summary>
        private SLinkedListNode<T> m_FirstNode { get; set; }
        /// <summary>
        /// 最后一个节点的值
        /// </summary>
        private SLinkedListNode<T> m_LastNode { get; set; }

        /// <summary>
        /// 节点数量属性
        /// </summary>
        public int Count
        {
            get { return m_Count; }
        }

        /// <summary>
        /// 头部节点
        /// </summary>
        public virtual SLinkedListNode<T> Head
        {
            get { return this.m_FirstNode; }
        }

        /// <summary>
        /// 默认构造方法
        /// </summary>
        public SLinkedList()
        {
            m_FirstNode = null;
            m_LastNode = null;
            m_Count = 0;
        }

        /// <summary>
        /// 链表是否为空
        /// </summary>
        /// <returns>如果为真那么链表为空，反之不为空</returns>
        public bool IsEmpty()
        {
            return (Count == 0);
        }

        /// <summary>
        /// 第一个节点Data类型实例的值的属性
        /// </summary>
        public T First
        {
            get
            {
                return (m_FirstNode == null ? default(T) : m_FirstNode.Data);
            }
        }

        /// <summary>
        /// 最后一个节点Data类型实例的值属性
        /// </summary>
        public T Last
        {
            get
            {
                if (Count == 0)
                {
                    throw new Exception("Empty list.");
                }
                else if (m_LastNode == null)
                {
                    var currentNode = m_FirstNode;
                    while (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }
                    m_LastNode = currentNode;
                    return currentNode.Data;
                }
                else
                {
                    return m_LastNode.Data;
                }
            }
        }

        /// <summary>
        /// 从链表的首部进行插入
        /// </summary>
        /// <param name="dataItem">插入链表的节点Data的类型实例</param>
        public void Prepend(T dataItem)
        {
            SLinkedListNode<T> newNode = new SLinkedListNode<T>(dataItem);

            if (m_FirstNode == null)
            {
                m_FirstNode = m_LastNode = newNode;
            }
            else
            {
                var currentNode = m_FirstNode;
                newNode.Next = currentNode;
                m_FirstNode = newNode;
            }
            m_Count++;
        }

        /// <summary>
        /// 从链表的尾部进行插入
        /// </summary>
        /// <param name="dataItem">插入链表的节点Data的类型实例</param>
        public void Append(T dataItem)
        {
            SLinkedListNode<T> newNode = new SLinkedListNode<T>(dataItem);

            if (m_FirstNode == null)
            {
                m_FirstNode = m_LastNode = newNode;
            }
            else
            {
                var currentNode = m_LastNode;
                currentNode.Next = newNode;
                m_LastNode = newNode;
            }

            // Increment the count.
            m_Count++;
        }

        /// <summary>
        /// 按照索引进行插入
        /// </summary>
        /// <param name="dataItem">节点Data类型实例</param>
        /// <param name="index">链表的索引</param>
        public void InsertAt(T dataItem, int index)
        {
            if (index == 0)
            {
                Prepend(dataItem);
            }
            else if (index == Count)
            {
                Append(dataItem);
            }
            else if (index > 0 && index < Count)
            {
                var currentNode = m_FirstNode;
                var newNode = new SLinkedListNode<T>(dataItem);

                for (int i = 1; i < index; ++i)
                {
                    currentNode = currentNode.Next;
                }

                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;

                m_Count++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// 通过索引进行移除节点
        /// </summary>
        /// <param name="index">节点所在链表的索引</param>
        public void RemoveAt(int index)
        {
            if (IsEmpty() || index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                m_FirstNode = m_FirstNode.Next;
                m_Count--;
            }
            else if (index == Count - 1)
            {
                var currentNode = m_FirstNode;

                while (currentNode.Next != null && currentNode.Next != m_LastNode)
                    currentNode = currentNode.Next;

                currentNode.Next = null;
                m_LastNode = currentNode;

                m_Count--;
            }
            else
            {
                int i = 0;
                var currentNode = m_FirstNode;
                while (currentNode.Next != null)
                {
                    if (i + 1 == index)
                    {
                        currentNode.Next = currentNode.Next.Next;

                        m_Count--;
                        break;
                    }

                    ++i;
                    currentNode = currentNode.Next;
                }
            }
        }

        /// <summary>
        /// 清楚所有的节点，将链表头部和尾部赋值为null和链表节点数量赋值为0
        /// </summary>
        public void Clear()
        {
            m_FirstNode = null;
            m_LastNode = null;
            m_Count = 0;
        }

        /// <summary>
        /// 通过链表的索引值获取节点Data类型实例
        /// </summary>
        /// <param name="index">输入的链表索引值</param>
        /// <returns>返回节点的Data类型实例</returns>
        public T GetAt(int index)
        {
            if (index == 0)
            {
                return First;
            }
            else if (index == (Count - 1))
            {
                return Last;
            }
            else if (index > 0 && index < (Count - 1))
            {
                var currentNode = m_FirstNode;
                for (int i = 0; i < index; ++i)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Data;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// 从链表里面获取一个随机节点的值
        /// </summary>
        /// <param name="index">自定义的链表开始索引</param>
        /// <param name="countOfElements">自定义的链表的结束索引</param>
        /// <returns>链表的节点值</returns>
        public SLinkedList<T> GetRange(int index, int countOfElements)
        {
            SLinkedList<T> newList = new SLinkedList<T>();
            var currentNode = this.m_FirstNode;

            // Handle Index out of Bound errors
            if (Count == 0)
            {
                return newList;
            }
            else if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            // Move the currentNode reference to the specified index
            for (int i = 0; i < index; ++i)
            {
                currentNode = currentNode.Next;
            }

            // Append the elements to the new list using the currentNode reference
            while (currentNode != null && newList.Count <= countOfElements)
            {
                newList.Append(currentNode.Data);
                currentNode = currentNode.Next;
            }

            return newList;
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        public virtual void SelectionSort()
        {
            if (IsEmpty())
                return;

            var currentNode = m_FirstNode;
            while (currentNode != null)
            {
                var nextNode = currentNode.Next;
                while (nextNode != null)
                {
                    if (nextNode.Data.IsLessThan(currentNode.Data))
                    {
                        var temp = nextNode.Data;
                        nextNode.Data = currentNode.Data;
                        currentNode.Data = temp;
                    }

                    nextNode = nextNode.Next;
                }

                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// 转换成系统的数组类型
        /// </summary>
        /// <returns>所有节点的Data数组</returns>
        public T[] ToArray()
        {
            T[] array = new T[Count];

            var currentNode = m_FirstNode;
            for (int i = 0; i < Count; ++i)
            {
                if (currentNode != null)
                {
                    array[i] = currentNode.Data;
                    currentNode = currentNode.Next;
                }
                else
                {
                    break;
                }
            }

            return array;
        }

        /// <summary>
        /// 转换成系统的List类型
        /// </summary>
        /// <returns>Syste.List</returns>
        public List<T> ToList()
        {
            List<T> list = new List<T>();

            var currentNode = m_FirstNode;
            for (int i = 0; i < Count; ++i)
            {
                if (currentNode != null)
                {
                    list.Add(currentNode.Data);
                    currentNode = currentNode.Next;
                }
                else
                {
                    break;
                }
            }

            return list;
        }

        /// <summary>
        /// 将链表转换成可读性比较强的字符串
        /// </summary>
        /// <returns></returns>
        public string ToReadable()
        {
            int i = 0;
            var currentNode = m_FirstNode;
            string listAsString = string.Empty;

            while (currentNode != null)
            {
                listAsString = String.Format("{0}[{1}] => {2}\r\n", listAsString, i, currentNode.Data);
                currentNode = currentNode.Next;
                ++i;
            }

            return listAsString;
        }

        /********************************************************************************/
        /// <summary>
        /// 获取泛型枚举数
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new SLinkedListEnumerator(this);
        }
        /// <summary>
        /// 获取枚举数
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new SLinkedListEnumerator(this);
        }

        /********************************************************************************/


        /// <summary>
        /// 单链表的枚举数类型
        /// </summary>
        internal class SLinkedListEnumerator : IEnumerator<T>
        {
            private SLinkedListNode<T> m_current;
            private SLinkedList<T> m_doublyLinkedList;

            public SLinkedListEnumerator(SLinkedList<T> list)
            {
                this.m_doublyLinkedList = list;
                this.m_current = list.Head;
            }

            public T Current
            {
                get { return this.m_current.Data; }
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                m_current = m_current.Next;

                return (this.m_current != null);
            }

            public void Reset()
            {
                m_current = m_doublyLinkedList.Head;
            }

            public void Dispose()
            {
                m_current = null;
                m_doublyLinkedList = null;
            }
        }
    }

}
