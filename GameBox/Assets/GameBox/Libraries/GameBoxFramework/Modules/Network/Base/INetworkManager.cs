/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Net.Sockets;

namespace GameBoxFramework.Network
{

    using GameBoxFramework;

    /// <summary>
    /// 网络管家
    /// </summary>
    public interface INetworkManager
    {
        /// <summary>
        /// 网络消息事件
        /// </summary>
        event EventHandler NetworkEventHandler;

        /// <summary>
        /// 网络数量
        /// </summary>
        int NetworkCount{ get; }

        /// <summary>
        /// 所有网络名字数组
        /// </summary>
        string[] NetworkNames { get; }

        /// <summary>
        /// 创建网络
        /// </summary>
        /// <typeparam name="T">网络的类型</typeparam>
        /// <param name="t_NetworkName">网络的名字</param>
        /// <param name="t_IP">IP</param>
        /// <param name="t_Port">Port</param>
        /// <param name="t_INetworkPacketQueue">网络消息包队列</param>
        /// <param name="t_AddressFamily">寻址方案</param>
        /// <returns>网络的类型对应的实例</returns>
        T CreateNetwork<T>(string t_NetworkName, string t_IP, int t_Port, INetworkPacketQueue t_INetworkPacketQueue = null, AddressFamily t_AddressFamily = AddressFamily.InterNetwork) where T : INetwork;

        /// <summary>
        /// 获取网络
        /// </summary>
        /// <param name="t_NetworkName">网络的名字</param>
        /// <typeparam name="T"></typeparam>
        T GetNetwork<T>(string t_NetworkName) where T : INetwork;

        /// <summary>
        /// 移除网络
        /// </summary>
        /// <param name="t_NetworkKey">网络的名字</param>
        void RemoveNetwork(string t_NetworkKey);

        /// <summary>
        /// 移除所有网络
        /// </summary>
        void RemoveAllNetwork();


	}
}