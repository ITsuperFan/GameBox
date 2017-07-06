/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using System.Net;
using System.Net.Sockets;

namespace GameBoxFramework.Network
{
    /// <summary>
    /// 网络消息包
    /// </summary>
    public class NetworkPacket 
	{

        /// <summary>
        /// 传输的缓冲区消息
        /// </summary>
        public byte[] Buffer { get; set; }

        /// <summary>
        /// 消息包长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 网络的套接字
        /// </summary>
        public INetwork INetwork { get; set; }

        /// <summary>
        /// 终端信息
        /// </summary>
        public EndPoint EndPoint { get; set; }

    }
}