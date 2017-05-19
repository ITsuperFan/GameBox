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
        /// 添加映射
        /// </summary>
        /// <param name="t_TKey"></param>
        /// <param name="t_TValue"></param>
        void Add( TKey t_TKey , TValue t_TValue );

        /// <summary>
        /// 移除改映射
        /// </summary>
        /// <param name="word"></param>
        void Remove(TKey word);

        /// <summary>
        /// 获取映射值
        /// </summary>
        /// <param name="t_TKey"></param>
        /// <param name="t_TValue"></param>
        void TryGetValue( TKey t_TKey ,out TValue t_TValue );

        /// <summary>
        /// 获取可枚举类型
        /// </summary>
        /// <returns></returns>
        IEnumerator<string> GetEnumerator();

        /// <summary>
        /// 遍历改映射表
        /// </summary>
        /// <param name="t_Handler"></param>
        void Foreach(Action<TKey,TValue> t_Handler);
    }
}