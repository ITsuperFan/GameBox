/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;

namespace GameBoxFramework.Network
{
    public interface INetworkPacketQueue
    {
        /// <summary>
        /// 队列长度
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 队列首部
        /// </summary>
        /// <returns></returns>
        NetworkEventArgs Peek();

        /// <summary>
        /// 网络消息入队列
        /// </summary>
        /// <param name="t_NetworkEventArgs">网络事件参数</param>
        void EnNetworkQueue(NetworkEventArgs t_NetworkEventArgs);

        /// <summary>
        /// 网络消息出队列
        /// </summary>
        /// <returns>网络事件参数</returns>
        NetworkEventArgs DeNetworkQueue();





    }
}
