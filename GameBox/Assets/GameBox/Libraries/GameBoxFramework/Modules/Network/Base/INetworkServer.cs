/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Collections.Generic;
using System.Net;

namespace GameBoxFramework.Network
{
    /// <summary>
    /// 服务端网络接口
    /// </summary>
    public interface INetworkServer : INetwork
    {
        /// <summary>
        /// 客户端的终端列表
        /// </summary>
        List<EndPoint> ClientEndPointList { get; }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="t_Byte">需要广播的字节流</param>
        void Push(byte[] t_Byte);

    }



}
