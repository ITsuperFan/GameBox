/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Net.Sockets;
using System.Net;

namespace GameBoxFramework.Network
{
    /// <summary>
    /// 网络接口
    /// </summary>
    public interface INetwork
    {
        /// <summary>
        /// 是否在活动状态
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// IP地址
        /// </summary>
        string IP { get;  }

        /// <summary>
        /// 端口号
        /// </summary>
        int Port { get;  }

        /// <summary>
        /// 网络队列接口
        /// </summary>
        INetworkPacketQueue INetworkPacketQueue { get; }

        /// <summary>
        /// Socket连接对象
        /// </summary>
        Socket Socket { get;  }

        /// <summary>
        /// 启动网络
        /// </summary>
        void Start();

        /// <summary>
        /// 重启网络
        /// </summary>
        void ReStart();

        /// <summary>
        /// 关闭网络
        /// </summary>
        void Stop();

        /// <summary>
        /// 销毁网络
        /// </summary>
        void Destroy();

        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="t_Socket">建立连接的套接字</param>
        /// <param name="t_EndPoint">目标端</param>
        /// <param name="t_Buffer">缓冲区</param>
        /// <param name="t_Length">缓冲区长度</param>
        void Write(Socket t_Socket, EndPoint t_EndPoint, byte[] t_Buffer,int t_Length); 

        /// <summary>
        /// 读数据
        /// </summary>
        /// <param name="t_Socket">建立连接的套接字</param>
        /// <param name="t_EndPoint">目标端</param>
        /// <param name="t_Buffer">缓冲区</param>
        /// <param name="t_Length">缓冲区长度</param>
        void Read (Socket t_Socket, EndPoint t_EndPoint, byte[] t_Buffer,int t_Length);

        /// <summary>
        /// 设置缓冲区的大小
        /// </summary>
        /// <param name="t_BufferSize">缓冲区大小</param>
        void SetBufferSize(int t_BufferSize);

    }
}
