/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using System.Net;
using System.Net.Sockets;

namespace GameBoxFramework.Network
{
    public class UDPClient : INetworkClient
    {


        /// <summary>
        /// 远程终端
        /// </summary>
        private EndPoint m_EndPoint = new IPEndPoint(IPAddress.Any, 0);
        /// <summary>
        /// 客户端每次异步接受到的消息长度
        /// </summary>
        private int m_Recv;

        /// <summary>
        /// 缓冲区
        /// </summary>
        private byte[] m_Buffer;

        /// <summary>
        /// 缓冲区的大小
        /// </summary>
        private int m_BufferSize = 1024;

        /// <summary>
        /// 寻址方案
        /// </summary>
        private AddressFamily m_AddressFamily;

        /// <summary>
        /// 客户端同步锁
        /// </summary>
        private static object m_ClientThreadLock =new object();

        /// <summary>
        /// 网络消息包队列
        /// </summary>
        public INetworkPacketQueue INetworkPacketQueue { get; protected set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; protected  set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; protected  set; }

        /// <summary>
        /// 套接字
        /// </summary>
        public Socket Socket { get; protected  set; }

        /// <summary>
        /// 是否在活动状态
        /// </summary>
        public bool IsActive { get; protected set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_IP"></param>
        /// <param name="t_Port"></param>
        /// <param name="t_AddressFamily"></param>
        /// <param name="t_INetworkPacketQueue"></param>
        public UDPClient(string t_IP, int t_Port,  INetworkPacketQueue t_INetworkPacketQueue= null ,AddressFamily t_AddressFamily= AddressFamily.InterNetwork)
        {
            IP = t_IP;
            Port = t_Port;
            m_AddressFamily = t_AddressFamily;
            INetworkPacketQueue = t_INetworkPacketQueue??new DefaultNetworkPacketQueue();
        }

        /// <summary>
        /// 启动网络
        /// </summary>
        public void Start()
        {
            m_Buffer = new byte[m_BufferSize];
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //实例化Socket
            m_EndPoint = new IPEndPoint(IPAddress.Parse(IP), Port); //服务端的终端信息
            INetworkPacketQueue.EnNetworkQueue(new NetworkEventArgs() { NetworkState = NetworkStateType.Start, Packet = new NetworkPacket() { INetwork = this } }); //消息队列        
            Socket.BeginReceiveFrom(m_Buffer, 0, m_Buffer.Length, SocketFlags.None, ref m_EndPoint, new AsyncCallback(AsycReveiveFrom), null);
            IsActive = true;
        }

        /// <summary>
        /// 重启网络
        /// </summary>
        public void ReStart()
        {
            INetworkPacketQueue.EnNetworkQueue(new NetworkEventArgs() { NetworkState = NetworkStateType.ReStart, Packet = new NetworkPacket() { INetwork = this } }); //消息队列
            Stop();
            Start();
        }

        /// <summary>
        /// 关闭网络
        /// </summary>
        public void Stop()
        {
            INetworkPacketQueue.EnNetworkQueue(new NetworkEventArgs() { NetworkState = NetworkStateType.Stop, Packet = new NetworkPacket() { INetwork = this } }); //消息队列
            Socket.Close();
            IsActive = false;
        }

        /// <summary>
        /// 读数据
        /// </summary>
        /// <param name="t_Socket"></param>
        /// <param name="t_EndPoint"></param>
        /// <param name="t_Buffer"></param>
        /// <param name="t_Length"></param>
        public void Read(Socket t_Socket, EndPoint t_EndPoint, byte[] t_Buffer, int t_Length)
        {
            INetworkPacketQueue.EnNetworkQueue(new NetworkEventArgs() { NetworkState = NetworkStateType.Transparent, Packet= new NetworkPacket() { Buffer = t_Buffer, Length=t_Length, INetwork = this, EndPoint = t_EndPoint } });
        }


        /// <summary>
        /// 客户端写数据
        /// </summary>
        /// <param name="t_Byte"></param>
        public void Write(byte[] t_Byte)
        {
           
            lock (m_ClientThreadLock)
            {
                Socket.SendTo(t_Byte, 0, t_Byte.Length, SocketFlags.None, m_EndPoint);
            }
        }

        /// <summary>
        /// 异步接受数据
        /// </summary>
        /// <param name="t_Ar"></param>
        protected virtual void AsycReveiveFrom(IAsyncResult t_Ar)
        {
            m_Recv = Socket.EndReceiveFrom(t_Ar, ref m_EndPoint);
           
            if (m_Recv > 0)
            {               
                Read(Socket, m_EndPoint, m_Buffer, m_Recv); //读取数据
                m_Buffer = new byte[m_BufferSize]; //创建新的缓冲区以及刷新缓冲区的大小
            }
           
            Socket.BeginReceiveFrom(m_Buffer , 0, m_Recv, SocketFlags.None, ref m_EndPoint, new AsyncCallback(AsycReveiveFrom), Socket);
        }


        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="t_Socket"></param>
        /// <param name="t_EndPoint"></param>
        /// <param name="t_Buffer"></param>
        /// <param name="t_Length"></param>
        public void Write(Socket t_Socket, EndPoint t_EndPoint, byte[] t_Buffer, int t_Length)
        {
            lock (m_ClientThreadLock)
            {
                t_Socket.SendTo(t_Buffer, 0, t_Length, SocketFlags.None, t_EndPoint);
            }
        }

        /// <summary>
        /// 销毁网络
        /// </summary>
        public void Destroy()
        {
            if(IsActive)
                Stop();
            Socket = null;
        }

        /// <summary>
        /// 设置缓冲区的大小
        /// </summary>
        /// <param name="t_BufferSize">缓冲区大小</param>
        public void SetBufferSize(int t_BufferSize)
        {
            m_BufferSize = t_BufferSize;
        }
    }
}
