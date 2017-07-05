/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework;
using System;


namespace GameBox.Runtime.Component
{
    /// <summary>
    /// EventBroker模式中发布者的特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Event, AllowMultiple = false)]
    public sealed class EventPublicationAttribute : BaseAttribute
    {
        /// <summary>
        /// 事件主题名字
        /// </summary>
        public string EventTopicName { get; private set; }

        /// <summary>
        /// 主否是主线程程序
        /// </summary>
        public bool IsMainThread { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        public EventPublicationAttribute(string t_EventTopicName,bool t_IsMainThread = true)
        {
            EventTopicName = t_EventTopicName;
            IsMainThread = t_IsMainThread;
        }

    }
}