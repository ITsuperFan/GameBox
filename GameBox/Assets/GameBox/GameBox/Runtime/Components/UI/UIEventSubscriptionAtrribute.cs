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
	public class UIEventAttribute : Attribute
    {

        /// <summary>
        /// 事件主题名字
        /// </summary>
        public string UIEventTopicName { get; private set; }

        /// <summary>
        /// UI控件的名字
        /// </summary>
        public string UIWidgetName { get; private set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        public UIEventAttribute(UIEventType t_UIEventType, string t_UIWidgetName=null)
        {
            UIEventTopicName = t_UIEventType.ToString();
            UIWidgetName = t_UIWidgetName;
        }

    }
}