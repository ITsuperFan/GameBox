/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework.Algorithms;
using System;
using System.Collections.Generic;

namespace GameBoxFramework.Runtime.Event
{
    /// <summary>
    /// 有效事件数据据结构
    /// </summary>
    /// <typeparam name="TKey">键</typeparam>
    /// <typeparam name="TValue">值</typeparam>
    public sealed class ActiveEventTrieMap<TKey, TValue> : IMapDataStructure<TKey, TValue>
    {
        /// <summary>
        /// 查找树
        /// </summary>
        private readonly TrieMap<TValue> m_TrieMap = new TrieMap<TValue>();

        /// <summary>
        /// 映射表数量
        /// </summary>
        public int Count
        {
            get
            {
                return m_TrieMap.Count;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t_TKey"></param>
        /// <param name="t_TValue"></param>
        public void Add(TKey t_TKey, TValue t_TValue)
        {
                m_TrieMap.Add(t_TKey.ToString(), t_TValue);
        }

        /// <summary>
        /// 清除映射类型
        /// </summary>
        public void Clear()
        {
            m_TrieMap.Clear();
        }

        /// <summary>
        /// 判断是否包含这个键
        /// </summary>
        /// <param name="t_Key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey t_Key)
        {
            return m_TrieMap.ContainsWord(t_Key.ToString());
        }

        /// <summary>
        /// 判断是否包含这个值
        /// </summary>
        /// <param name="t_Value"></param>
        /// <returns></returns>
        public bool ContainsValue(TValue t_Value)
        {
            foreach (var item in m_TrieMap)
            {
                if (item.Equals(t_Value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="t_Handler"></param>
        public void Foreach(Action<TKey, TValue> t_Handler)
        {
            foreach (var item in m_TrieMap)
            {
                t_Handler((TKey)Convert.ChangeType(item.Key, typeof(TKey)),item.Value);
            }
        }

        /// <summary>
        /// 获取可枚举数
        /// </summary>
        /// <returns>返回可枚举数实例</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return  (IEnumerator<KeyValuePair<TKey, TValue>>)m_TrieMap.GetEnumerator();
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="word"></param>
        public void Remove(TKey word)
        {
            m_TrieMap.Remove(word.ToString());
        }

        /// <summary>
        /// 转换成键值对数组
        /// </summary>
        /// <returns>键值对数组</returns>
        public KeyValuePair<TKey, TValue>[] ToArray()
        {
            KeyValuePair<TKey, TValue>[] t_KeyValuePair = new KeyValuePair<TKey, TValue>[m_TrieMap.Count];
            int t_Index=0;
            foreach (var item in m_TrieMap)
            {
                t_KeyValuePair[t_Index++] = new KeyValuePair<TKey, TValue>( (TKey)Convert.ChangeType(item.Key, typeof(TKey)) , item.Value);
            }
            return t_KeyValuePair;
        }

        /// <summary>
        /// 尝试获取值
        /// </summary>
        /// <param name="t_TKey"></param>
        /// <param name="t_TValue"></param>
        public void TryGetValue(TKey t_TKey, out TValue t_TValue)
        {
            m_TrieMap.SearchByWord(t_TKey.ToString(),out t_TValue);
        }

        /// <summary>
        /// 更新指定键的值
        /// </summary>
        /// <param name="t_TKey">键的类型</param>
        /// <param name="t_TValue">值的类型</param>
        public void Update(TKey t_TKey, TValue t_TValue)
        {
            m_TrieMap.UpdateWord(t_TKey.ToString(),t_TValue);
        }



    }
}