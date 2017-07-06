/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Reflection;

namespace GameBoxFramework.Event
{
    /// <summary>
    /// 有效事件条目类型
    /// </summary>
    internal class ActiveEventEntry
    {
        /// <summary>
        /// 有效事件名字
        /// </summary>
        public string ActiveName { get; set; }

        /// <summary>
        /// 参数数目
        /// </summary>
        public int ParamsCount { get; set; }

        /// <summary>
        /// 有效事件的具体映射方法
        /// </summary>
        public MethodInfo ActiveEventHandler { get; set; }

    }
}
