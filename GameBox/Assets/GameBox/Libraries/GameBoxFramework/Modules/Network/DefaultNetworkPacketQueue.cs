/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Collections.Generic;

namespace GameBoxFramework.Network
{
    /// <summary>
    /// 框架默认的NetworkPacketQueue
    /// </summary>
    public sealed class DefaultNetworkPacketQueue : INetworkPacketQueue
    {
        /// <summary>
        /// 网络消息包的队列
        /// </summary>
        private readonly Queue<NetworkEventArgs> m_NetworkPacketQueue = new Queue<NetworkEventArgs>();

        /// <summary>
        /// 队列长度
        /// </summary>
        public int Count
        {
            get
            {
                return m_NetworkPacketQueue.Count;
            }
        }

        /// <summary>
        /// 队列首部
        /// </summary>
        /// <returns></returns>
        public NetworkEventArgs Peek()
        {
            return m_NetworkPacketQueue.Peek();
        }

        /// <summary>
        /// 网络消息出队列
        /// </summary>
        /// <returns>网络事件参数</returns>
        public NetworkEventArgs DeNetworkQueue()
        {
            return 0<m_NetworkPacketQueue.Count ? m_NetworkPacketQueue.Dequeue() :null;
        }

        /// <summary>
        /// 网络消息入队列
        /// </summary>
        /// <param name="t_NetworkEventArgs">网络事件参数</param>
        public void EnNetworkQueue(NetworkEventArgs t_NetworkEventArgs)
        {
            if (null == t_NetworkEventArgs) throw new GameBoxFrameworkException("进队列的事件参数不能为NULL");

            m_NetworkPacketQueue.Enqueue(t_NetworkEventArgs);
        }


    }
}
