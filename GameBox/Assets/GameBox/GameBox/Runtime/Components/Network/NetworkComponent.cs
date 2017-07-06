/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using UnityEngine;
using System.Reflection;
using System.Net.Sockets;
using GameBoxFramework.EventPool;
using GameBoxFramework.Network;

namespace GameBox.Runtime.Component
{
    using GameBoxFramework;

    /// <summary>
    /// NetworkComponent组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("GameBox/Network")]
    public sealed class NetworkComponent : BaseGameBoxComponent
    {
        /// <summary>
        /// 网络管家接口
        /// </summary>
        private INetworkManager m_INetworkManager=null;

        /// <summary>
        /// 事件池管家接口
        /// </summary>
        private IEventPoolManager m_IEventPoolManager=null;

        /// <summary>
        /// 网络数量
        /// </summary>
        public int NetworkCount { get { return null == m_INetworkManager ? 0 : m_INetworkManager.NetworkCount; } }

        /// <summary>
        /// 所有网络名字数组
        /// </summary>
        public string[] NetworkNames { get { return null == m_INetworkManager ? null : m_INetworkManager.NetworkNames; } }

        /// <summary>
        /// 网络消息事件
        /// </summary>
        public event EventHandler NetworkEventHandler;

        protected override void Awake()
        {
            base.Awake();

            m_INetworkManager = GameBox.App.Driver.GetModule<INetworkManager>();
            if (null == m_INetworkManager)
            {
                throw new GameBoxFrameworkException("INetworkManager是无效的！");
            }

            m_IEventPoolManager = GameBox.App.Driver.GetModule<IEventPoolManager>();
            if (null == m_IEventPoolManager)
            {
                throw new GameBoxFrameworkException("IEventPoolManager是无效的！");
            }


            RegisterNetworkEventTopic(); //注册网络主题事件

            m_INetworkManager.NetworkEventHandler += M_INetworkManager_NetworkEventHandler;




        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            m_INetworkManager.NetworkEventHandler -= M_INetworkManager_NetworkEventHandler;
        }

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="t_Sender"></param>
        /// <param name="t_EventArgs"></param>
        private void M_INetworkManager_NetworkEventHandler(object t_Sender, BaseEventArgs t_EventArgs)
        {
            if (null != NetworkEventHandler) NetworkEventHandler(t_Sender,t_EventArgs); //本网络组件的事件通知

            var t_NetworkEventArgs = t_EventArgs as NetworkEventArgs;

            if (m_IEventPoolManager.HasTopic(t_NetworkEventArgs.NetworkState.ToString()))
                m_IEventPoolManager.PublishTopicNow(t_NetworkEventArgs.NetworkState.ToString(), t_Sender, t_EventArgs);

            var t_TargetName = t_NetworkEventArgs.NetworkState.ToString() + t_NetworkEventArgs.Name;

            if (m_IEventPoolManager.HasTopic(t_TargetName))
            {
                m_IEventPoolManager.PublishTopicNow(t_TargetName, t_Sender, t_EventArgs);
            }

        }




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
        public T CreateNetwork<T>(string t_NetworkName, string t_IP, int t_Port, INetworkPacketQueue t_INetworkPacketQueue = null, AddressFamily t_AddressFamily = AddressFamily.InterNetwork) where T : INetwork
        {
            return m_INetworkManager.CreateNetwork<T>(t_NetworkName,t_IP,t_Port,t_INetworkPacketQueue,t_AddressFamily);
        }
      
        /// <summary>
        /// 获取网络
        /// </summary>
        /// <param name="t_NetworkName">网络的名字</param>
        /// <typeparam name="T"></typeparam>
        public T GetNetwork<T>(string t_NetworkName) where T : INetwork
        {
            return m_INetworkManager.GetNetwork<T>(t_NetworkName);
        }
      
        /// <summary>
        /// 移除所有网络
        /// </summary>
        public void RemoveAllNetwork()
        {
            m_INetworkManager.RemoveAllNetwork();
        }
    
        /// <summary>
        /// 移除网络
        /// </summary>
        /// <param name="t_NetworkKey">网络的名字</param>
        public void RemoveNetwork(string t_NetworkKey)
        {
            m_INetworkManager.RemoveNetwork(t_NetworkKey);
        }


        /// <summary>
        /// 注册UI事件主题
        /// </summary>
        private void RegisterNetworkEventTopic()
        {

            m_IEventPoolManager.CreateEventTopic(NetworkStateType.UnKnow.ToString()); //创建 UnKnow 主题
            m_IEventPoolManager.CreateEventTopic(NetworkStateType.HeartBeat.ToString()); //创建 HeartBeat 主题
            m_IEventPoolManager.CreateEventTopic(NetworkStateType.Start.ToString()); //创建 Start 主题
            m_IEventPoolManager.CreateEventTopic(NetworkStateType.ReStart.ToString()); //创建 ReStart 主题
            m_IEventPoolManager.CreateEventTopic(NetworkStateType.Stop.ToString()); //创建 Stop 主题
            m_IEventPoolManager.CreateEventTopic(NetworkStateType.Transparent.ToString()); //创建 Transparent 主题

        }


        /// <summary>
        /// 注册事件经纪人所管辖的发布者或者订阅者
        /// </summary>
        /// <param name="t_Target"></param>
        public void Register(object t_Target)
        {
            var t_Type = t_Target.GetType();

            var t_Methods = t_Type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            for (int i = 0; i < t_Methods.Length; i++)
            {
                var t_CustomAttributes = t_Methods[i].GetCustomAttributes(false);
                for (int j = 0; j < t_CustomAttributes.Length; j++)
                {
                    if (t_CustomAttributes[j] is NetworkEventAttribute)//订阅者
                    {
                        var t_NetworkEventAttribute = t_CustomAttributes[j] as NetworkEventAttribute;
                        var t_TargetTopicName = t_NetworkEventAttribute.NetworkEventTopicName + (t_NetworkEventAttribute.NetworkName ?? string.Empty);
                        if (m_IEventPoolManager.HasTopic(t_TargetTopicName))
                        {
                            m_IEventPoolManager.GetEventTopic(t_TargetTopicName).AddSubscriber(DelegateHelper.CreateDelegate(t_Methods[i], t_Target)); //添加订阅者
                        }
                        else
                        {
                            m_IEventPoolManager.CreateEventTopic(t_TargetTopicName).AddSubscriber(DelegateHelper.CreateDelegate(t_Methods[i], t_Target)); //添加订阅者
                        }
                    }
                }
            }

        }


    }
}