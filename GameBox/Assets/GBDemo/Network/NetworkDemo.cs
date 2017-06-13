/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox;
using GameBox.Runtime.Component;
using GameBoxFramework.Network;
using System.Text;
using UnityEngine;


namespace Alan
{
    public sealed class NetworkDemo : MonoBehaviour 
	{
        private NetworkComponent m_NetworkComponent; //网络组件
        private UDPServer m_UDPServer;//UDP网络实例
        private UDPClient m_UDPClient01;//UDP网络实例
        private UDPClient m_UDPClient02;//UDP网络实例


        private void Start()
        {
            m_NetworkComponent = GameBoxEntry.GetComponent<NetworkComponent>();
            m_UDPServer = m_NetworkComponent.CreateNetwork<UDPServer>("服务端", "127.0.0.1", 6666);
            m_UDPClient01 = m_NetworkComponent.CreateNetwork<UDPClient>("客户端01", "127.0.0.1", 6666);
            m_UDPClient02 = m_NetworkComponent.CreateNetwork<UDPClient>("客户端02", "127.0.0.1", 6666);

            m_NetworkComponent.NetworkEventHandler += M_NetworkComponent_NetworkEventHandler; //监听网络事件
            m_NetworkComponent.Register(this);
        }

        [NetworkEvent( NetworkStateType.Start)]
        private void NetworkEventAttributeDemo1(INetwork t_Sender, NetworkEventArgs t_EventArgs)
        {
            Debug.Log("Start: " + t_Sender + "  " + t_EventArgs.Name);
        }

        [NetworkEvent(NetworkStateType.Stop)]
        private void NetworkEventAttributeDemo2(INetwork t_Sender, NetworkEventArgs t_EventArgs)
        {
            Debug.Log("Stop: " + t_Sender + "  " + t_EventArgs.Name);
        }

        [NetworkEvent(NetworkStateType.Transparent)]
        private void NetworkEventAttributeDemo3(INetwork t_Sender, NetworkEventArgs t_EventArgs)
        {
            Debug.Log("Transparent: " + t_Sender + "  " + t_EventArgs.Name + Encoding.Unicode.GetString(t_EventArgs.Packet.Buffer, 0, t_EventArgs.Packet.Length));
        }



        /// <summary>
        /// 监听所有的网络消息
        /// </summary>
        /// <param name="t_Sender"></param>
        /// <param name="t_EventArgs"></param>
        private void M_NetworkComponent_NetworkEventHandler(object t_Sender, GameBoxFramework.BaseEventArgs t_EventArgs)
        {
            NetworkEventArgs t_NetworkEventArgs = t_EventArgs as NetworkEventArgs;
            if (t_NetworkEventArgs.NetworkState == NetworkStateType.Transparent) //如果当前的网络状态为正常传输
            {
                NetworkPacket t_NetworkPacket = t_NetworkEventArgs.Packet;
                string s = Encoding.Unicode.GetString(t_NetworkPacket.Buffer, 0, t_NetworkPacket.Length);
                Debug.Log("网络名字为:    '" + t_NetworkEventArgs.Name + "'    接受到的数据是:      " + s + "      数据包的长度是:  " + t_NetworkPacket.Length);
            }

        }

        private void OnGUI()
        {

            if (GUILayout.Button("服务端广播"))
            {
                m_UDPServer.Push(Encoding.Unicode.GetBytes("服务端广播的数据..."));
            }

            if (GUILayout.Button("客户端01发送给服务端"))
            {
                m_UDPClient01.Write(Encoding.Unicode.GetBytes("客户端01发送给服务端的数据..."));
            }

            if (GUILayout.Button("客户端02发送给服务端"))
            {
                m_UDPClient02.Write(Encoding.Unicode.GetBytes("客户端02发送给服务端的数据..."));
            }

            if (GUILayout.Button("移除客户端02"))
            {
                m_NetworkComponent.RemoveNetwork("客户端02");
            }

            if (GUILayout.Button("移除所有网络实例"))
            {
                m_NetworkComponent.RemoveAllNetwork();
            }
        }


    }
}