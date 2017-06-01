/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;

namespace GameBoxFramework.Runtime.Event
{
    /// <summary>
    /// 有效事件标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, AllowMultiple = false)]
    public class ActiveEventAttribute : Attribute
    {
        public string EventName { get; set; }

        public ActiveEventAttribute(string t_EventName)
        {
            EventName = t_EventName;
        }
    }
}
