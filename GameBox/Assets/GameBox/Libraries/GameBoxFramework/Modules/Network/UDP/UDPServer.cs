/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GameBoxFramework.Network
{
    public class UDPServer :INetworkServer
    {
        /// <summary>
        /// 远程终端
        /// </summary>
        private EndPoint m_EndPoint = new IPEndPoint(IPAddress.Any, 0);

        /// <summary>
        /// 寻址方案
        /// </summary>
        private AddressFamily m_AddressFamily;

        /// <summary>
        /// 服务端同步锁
        /// </summary>
        private static object m_ServerThreadLock = new object();

        /// <summary>
        /// 循环信号量
        /// </summary>
        private bool m_IsLoop=true;

        /// <summary>
        /// 信号量
        /// </summary>
        public static ManualResetEvent m_MRE =new ManualResetEvent(false);

        /// <summary>
        /// 网络消息包
        /// </summary>
        public INetworkPacketQueue INetworkPacketQueue { get; protected set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; protected set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; protected set; }

        /// <summary>
        /// 套接字实例
        /// </summary>
        public Socket Socket { get; protected set; }

        /// <summary>
        /// 是否在活动状态
        /// </summary>
        public bool IsActive { get; protected set; }

        /// <summary>
        /// 远程终端列表
        /// </summary>
        public List<EndPoint> ClientEndPointList { get; protected set; }

        /// <summary>
        /// 缓冲区的大小
        /// </summary>
        private int m_BufferSize=1024;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_IP"></param>
        /// <param name="t_Port"></param>
        /// <param name="t_AddressFamily"></param>
        /// <param name="t_INetworkPacketQueue"></param>
        public UDPServer(string t_IP, int t_Port, INetworkPacketQueue t_INetworkPacketQueue = null, AddressFamily t_AddressFamily = AddressFamily.InterNetwork)
        {
            IP = t_IP;
            Port = t_Port;
            m_AddressFamily = t_AddressFamily;
            INetworkPacketQueue = t_INetworkPacketQueue ?? new DefaultNetworkPacketQueue();
            ClientEndPointList = new List<EndPoint>();
        }





        /// <summary>
        /// 启动网络
        /// </summary>
        public void Start()
        {       
           Socket = new Socket(m_AddressFamily, SocketType.Dgram, ProtocolType.Udp);
           Socket.Bind(new IPEndPoint(IPAddress.Parse(IP), Port)); //绑定端口
           INetworkPacketQueue.EnNetworkQueue(new NetworkEventArgs() { NetworkState = NetworkStateType.Start, Packet = new NetworkPacket() { INetwork = this } }); //消息队列
           AsycReveiveFrom();
           IsActive = true;
        }


        /// <summary>
        /// 异步接收客户端们的数据
        /// </summary>
        protected void AsycReveiveFrom()
        {

            Action t_LoopAsycReveiveFromHandler = () =>
            {
                while (m_IsLoop)
                {
                    m_MRE.Reset();
                    var t_ClientBuffer = new byte[m_BufferSize]; 
                    Socket.BeginReceiveFrom(t_ClientBuffer, 0, t_ClientBuffer.Length, SocketFlags.None, ref m_EndPoint, new AsyncCallback(t_Ar => {
                        m_MRE.Set();
                        EndPoint t_EndPoint = t_Ar.AsyncState as EndPoint;
                        int t_Recv = Socket.EndReceiveFrom(t_Ar, ref t_EndPoint);
                        if (t_Recv > 0)
                        {
                            var t_ClientEndPoint = ClientEndPointList.Find(value=>value!=null&&value.Equals(t_EndPoint)); //检查
                            if (null != t_ClientEndPoint) //已经存在了这个客户端
                            {
                               
                            }
                            else //没有这个客户端
                            {
                                ListHelper.Add<EndPoint>(ClientEndPointList, t_EndPoint);
                            }

                            Read(Socket, t_EndPoint, t_ClientBuffer, t_Recv); //读取数据
                        }

                    }), m_EndPoint);

                    m_MRE.WaitOne(1000, true);
                }

            };
            t_LoopAsycReveiveFromHandler.BeginInvoke(new AsyncCallback(t_Ar => { }), null);
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
            m_IsLoop = false;
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
            INetworkPacketQueue.EnNetworkQueue(new NetworkEventArgs() {  NetworkState = NetworkStateType.Transparent, Packet = new NetworkPacket() { Buffer = t_Buffer, Length = t_Length, INetwork = this, EndPoint = t_EndPoint } });
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

            lock (m_ServerThreadLock)
            {
                try
                {
                    t_Socket.BeginSendTo(t_Buffer, 0, t_Length, SocketFlags.None, t_EndPoint, new AsyncCallback((t_Ar) =>
                    {
                        t_Socket.EndSendTo(t_Ar);
                        //Debug.Log("-------------------------------" + t_EndPoint + "*********"+ t_Socket.Available);
                    }), null);

                    //UnityEngine.Debug.Log(t_EndPoint+ "    "+ t_Length+"  第一位数据:  "+t_Buffer[0]);


                }
                catch (Exception ex)
                {
                    ListHelper.Remove<EndPoint>(ClientEndPointList, t_EndPoint);
                    //UnityEngine.Debug.Log(ex.Message);
                }

            }
        }

        /// <summary>
        /// 广播
        /// </summary>
        /// <param name="t_Byte"></param>
        public void Push(byte[] t_Byte)
        {
            int t_Count = ClientEndPointList.Count;
            for (int i = 0; i < t_Count; i++)
            {
                try
                {
                    //UnityEngine.Debug.Log(ClientEndPointList[i]+ "    "+t_Byte.Length);
                    Write(Socket, ClientEndPointList[i], t_Byte, t_Byte.Length);
                }
                catch (Exception ex)
                {
                    ListHelper.Remove<EndPoint>(ClientEndPointList, ClientEndPointList[i]);
                    //UnityEngine.Debug.Log(ex.Message);
                }
               
            }
        }

        /// <summary>
        /// 销毁网络
        /// </summary>
        public void Destroy()
        {
            if (IsActive)
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
