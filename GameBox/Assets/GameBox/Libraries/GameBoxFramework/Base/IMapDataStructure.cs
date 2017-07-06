/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using System.Collections.Generic;

namespace GameBoxFramework
{

    /// <summary>
    /// 字典数据类型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapDataStructure<TKey,TValue>
    {
        /// <summary>
        /// 映射表数量
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 添加映射
        /// </summary>
        /// <param name="t_TKey"></param>
        /// <param name="t_TValue"></param>
        void Add( TKey t_TKey , TValue t_TValue );

        /// <summary>
        /// 更新指定键的值
        /// </summary>
        /// <param name="t_TKey">键的类型</param>
        /// <param name="t_TValue">值的类型</param>
        void Update(TKey t_TKey, TValue t_TValue);

        /// <summary>
        /// 移除改映射
        /// </summary>
        /// <param name="word"></param>
        void Remove(TKey word);

        /// <summary>
        /// 清除映射类型
        /// </summary>
        void Clear();

        /// <summary>
        /// 获取映射值
        /// </summary>
        /// <param name="t_TKey"></param>
        /// <param name="t_TValue"></param>
        void TryGetValue( TKey t_TKey ,out TValue t_TValue );

        /// <summary>
        /// 是否包含键
        /// </summary>
        /// <param name="t_Key"></param>
        /// <returns></returns>
        bool ContainsKey(TKey t_Key);

        /// <summary>
        /// 是否包含数值
        /// </summary>
        /// <param name="t_Key"></param>
        /// <returns></returns>
        bool ContainsValue(TValue t_Value);

        /// <summary>
        /// 遍历改映射表
        /// </summary>
        /// <param name="t_Handler">回调处理</param>
        void Foreach(Action<TKey,TValue> t_Handler);

        /// <summary>
        /// 转换成键值对数组
        /// </summary>
        /// <returns>键值对数组</returns>
        KeyValuePair<TKey, TValue>[] ToArray();

        /// <summary>
        /// 获取可枚举数
        /// </summary>
        /// <returns>返回可枚举数实例</returns>
        IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
    }

}