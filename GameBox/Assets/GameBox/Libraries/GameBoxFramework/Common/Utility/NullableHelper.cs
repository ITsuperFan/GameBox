﻿/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework.Utility
{
    /// <summary>
    /// 可空类型相关的实用函数。
    /// </summary>
    public static class NullableHelper
    {
        /// <summary>
        /// 获取对象是否是可空类型。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="t">对象。</param>
        /// <returns>对象是否是可空类型。</returns>
        public static bool IsNullable<T>(T t) { return false; }

        /// <summary>
        /// 获取对象是否是可空类型。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="t">对象。</param>
        /// <returns>对象是否是可空类型。</returns>
        public static bool IsNullable<T>(T? t) where T : struct { return true; }
    }
}
