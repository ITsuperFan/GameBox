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
    /// 基础事件参数
    /// </summary>
    public abstract class BaseEventArgs : EventArgs
    {
        /// <summary>
        /// 空参数
        /// </summary>
        public new static readonly BaseEventArgs Empty = EventArgs.Empty as BaseEventArgs;
    }
}