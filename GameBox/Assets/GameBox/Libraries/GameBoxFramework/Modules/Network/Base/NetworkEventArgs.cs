/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using System.Net;

namespace GameBoxFramework.Network
{
    /// <summary>
    /// 网络消息事件传输消息
    /// </summary>
    public class NetworkEventArgs : BaseEventArgs
    {
        /// <summary>
        /// 网络的名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 该消息包代表的网络状态
        /// </summary>
        public NetworkStateType NetworkState { get; set; }

        /// <summary>
        /// 消息包
        /// </summary>
        public NetworkPacket Packet { get;set;}


    }
}
