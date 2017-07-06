/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework.Network;
using System;


namespace GameBox.Runtime.Component
{
    /// <summary>
    /// EventBroker模式中订阅者的特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class NetworkEventAttribute : Attribute
    {

        /// <summary>
        /// 事件主题名字
        /// </summary>
        public string NetworkEventTopicName { get; private set; }

        /// <summary>
        /// 网络实例的名字
        /// </summary>
        public string NetworkName { get; private set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_UIWidgetName">网络实例的名字</param>
        public NetworkEventAttribute(NetworkStateType t_NetworkState, string t_NetworkName = null)
        {
            NetworkEventTopicName = t_NetworkState.ToString();
            NetworkName = t_NetworkName;
        }

    }
}