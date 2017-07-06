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
	public class SceneEventAttribute : Attribute
    {

        /// <summary>
        /// 事件主题名字
        /// </summary>
        public string SceneEventTopicName { get; private set; }

        public string SceneName { get; private set; }



        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_SceneEventType">场景事件类型</param>
        public SceneEventAttribute(SceneEventType t_SceneEventType,string t_SceneName=null)
        {
            SceneEventTopicName = t_SceneEventType.ToString();
            SceneName = t_SceneName??string.Empty;
        }

    }
}