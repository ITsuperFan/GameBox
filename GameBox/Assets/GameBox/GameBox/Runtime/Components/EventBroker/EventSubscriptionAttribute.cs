/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;


namespace GameBox.Runtime.Component
{
    /// <summary>
    /// EventBroker模式中订阅者的特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class EventSubscriptionAttribute : Attribute
    {

        /// <summary>
        /// 事件主题名字
        /// </summary>
        public string EventTopicName { get; private set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        public EventSubscriptionAttribute(string t_EventTopicName)
        {
            EventTopicName = t_EventTopicName;
        }

    }
}