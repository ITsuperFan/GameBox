/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework.Network
{
    /// <summary>
    /// 客户端网络接口
    /// </summary>
    public interface INetworkClient:INetwork
    {

        /// <summary>
        /// 客户端给服务端发送数据
        /// </summary>
        /// <param name="t_Byte">需要发送给服务端的字节流</param>
        void Write(byte[] t_Byte);


    }
}
