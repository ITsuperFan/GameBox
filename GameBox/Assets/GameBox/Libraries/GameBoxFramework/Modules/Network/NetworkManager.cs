/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Net.Sockets;

namespace GameBoxFramework.Network
{
    /// <summary>
    /// 网络模块
    /// </summary>
    internal sealed class NetworkManager : BaseModule,INetworkManager
    {
        /// <summary>
        /// 网络消息事件
        /// </summary>
        public event EventHandler NetworkEventHandler;

        /// <summary>
        /// 抽象数据结构类型
        /// </summary>
        private readonly IMapDataStructure<string, INetwork> IMapDataStructure=new NetworkTrieMap<string, INetwork>();

        /// <summary>
        /// 网络数量
        /// </summary>
        public int NetworkCount
        {
            get
            {
                return IMapDataStructure.Count;
            }
        }

        /// <summary>
        /// 所有网络名字数组
        /// </summary>
        public string[] NetworkNames
        {
            get {
                string[] t_NetworkNames = new string[NetworkCount];
                int t_Index = 0;
                foreach (var item in IMapDataStructure)
                {
                    t_NetworkNames[t_Index++] = item.Key;
                }
                return t_NetworkNames;
            }
        }

        /// <summary>
        /// 创建网络
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t_NetworkName"></param>
        /// <param name="t_IP"></param>
        /// <param name="t_Port"></param>
        /// <param name="t_INetworkQueue"></param>
        /// <returns></returns>
        public T CreateNetwork<T>(string t_NetworkName, string t_IP, int t_Port, INetworkPacketQueue t_INetworkPacketQueue = null, AddressFamily t_AddressFamily = AddressFamily.InterNetwork) where T : INetwork
        {
            INetwork t_INetwork = null;

            if (IMapDataStructure.ContainsKey(t_NetworkName))
            {
                IMapDataStructure.TryGetValue(t_NetworkName, out t_INetwork);
                return (T)t_INetwork;
            }
            else
            {
                object[] t_Parameters = new object[] { t_IP, t_Port };

                T t_Instance = (T)System.Activator.CreateInstance(typeof(T), t_IP,t_Port, t_INetworkPacketQueue??new DefaultNetworkPacketQueue(),t_AddressFamily);
                IMapDataStructure.Add(t_NetworkName, t_Instance);
                t_Instance.Start();
                return t_Instance;
            }
        }

        /// <summary>
        /// 获取网络
        /// </summary>
        /// <typeparam name="T">网络的类型</typeparam>
        /// <param name="t_NetworkName">网络的名字</param>
        /// <returns>网络的类型对应的实例</returns>
        public T GetNetwork<T>(string t_NetworkName) where T : INetwork
        {
            INetwork t_INetwork = null;
            if (IMapDataStructure.ContainsKey(t_NetworkName))
            {
                IMapDataStructure.TryGetValue(t_NetworkName, out t_INetwork);
                return (T)t_INetwork;
            }
            return default(T);
        }

        /// <summary>
        /// 移除所有网络
        /// </summary>
        public void RemoveAllNetwork()
        {
            IMapDataStructure.Foreach((key,value)=> {
                value.Destroy();
            });

            IMapDataStructure.Clear();
        }

        /// <summary>
        /// 移除网络
        /// </summary>
        /// <param name="t_NetworkKey">网络的名字</param>
        public void RemoveNetwork(string t_NetworkKey)
        {
            if (IMapDataStructure.ContainsKey(t_NetworkKey))
            {
                INetwork t_INetwork = null;
                IMapDataStructure.TryGetValue(t_NetworkKey,out t_INetwork);
                t_INetwork.Destroy();
                IMapDataStructure.Remove(t_NetworkKey);
            }
        }


        /// <summary>
        /// 模块初始化的时候调用
        /// </summary>
        protected internal override void OnInit(IModuleManager t_IModuleManager)
        {
           
        }


        /// <summary>
        /// 模块被启动的时候调用
        /// </summary>
        protected internal override void OnStart(IModuleManager t_IModuleManager)
        {
            foreach (var network in IMapDataStructure)
            {
                if (!network.Value.IsActive)
                    network.Value.Start();
            }
        }


        /// <summary>
        /// 模块被轮询的时候调用
        /// </summary>
        protected internal override void OnUpdate(IModuleManager t_IModuleManager)
        {
            foreach (var network in IMapDataStructure)
            {
                if (null != NetworkEventHandler)
                {
                    var t_NetworkEventArgs = network.Value.INetworkPacketQueue.DeNetworkQueue();
                    if (null != t_NetworkEventArgs)
                    {
                        t_NetworkEventArgs.Name = network.Key;
                        var t_Packet = t_NetworkEventArgs.Packet;
                        NetworkEventHandler(null== t_Packet ? null: t_Packet.INetwork,t_NetworkEventArgs);
                    }
                   
                }
            }
        }


        /// <summary>
        /// 模块被停止的时候调用
        /// </summary>
        protected internal override void OnStop(IModuleManager t_IModuleManager)
        {
            foreach (var network in IMapDataStructure)
            {
                if(network.Value.IsActive)
                    network.Value.Stop();
            }
        }


        /// <summary>
        /// 模块被销毁前调用
        /// </summary>
        protected internal override void OnDestroy(IModuleManager t_IModuleManager)
        {
            foreach (var network in IMapDataStructure)
            {
                network.Value.Destroy();
            }
        }
    }
}