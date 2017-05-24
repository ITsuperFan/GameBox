/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;

namespace GameBoxFramework
{
    /// <summary>
    /// GameBoxFramework的模块管家
    /// </summary>
    public sealed class GameBoxFrameworkModuleManager : BaseModuleManager, IModuleManager
    {
        /// <summary>
        /// 管理的模块数量
        /// </summary>
        public int ModulesCount
        {
            get
            {
                return IListDataStructure.NodeCount;
            }
        }
        /// <summary>
        /// 所有模块的名字数组
        /// </summary>
        public string[] ModuleNames
        {
            get
            {
                var t_ModuleArray = IListDataStructure.ToArray();
                string[] t_ModuleNames = new string[t_ModuleArray.Length];
                for (int i = 0; i < t_ModuleArray.Length; i++)
                {
                    t_ModuleNames[i] = t_ModuleArray[i].GetType().Name;
                }
                return 0 < t_ModuleArray.Length ? t_ModuleNames : null;
            }
        }
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public GameBoxFrameworkModuleManager():base()
        {
        }
        /// <summary>
        /// 初始化 IListDataStructure 接口的构造方法
        /// </summary>
        /// <param name="t_IListDataStructure"></param>
        public GameBoxFrameworkModuleManager(IListDataStructure<BaseModule> t_IListDataStructure): base(t_IListDataStructure)
        {
        }
        /// <summary>
        /// 获取管理的模块
        /// </summary>
        /// <typeparam name="T">模块的类型</typeparam>
        /// <returns>返回指定模块实例</returns>
        public  T GetModule<T>() where T:class
        {
            Type t_InterfaceType = typeof(T);
            if (!t_InterfaceType.IsInterface) //如果不是接口
            {
                throw new GameBoxFrameworkException(string.Format("你只能通过接口来获取系统内建模块，{0} 不是内建模块对应的接口.", t_InterfaceType.FullName));
            }
            if (!t_InterfaceType.FullName.StartsWith("GameBoxFramework.")) //如果接口的命名空间开头不为内建系统命名空间
            {
                throw new GameBoxFrameworkException(string.Format("{0} 不是系统内建的模块.", t_InterfaceType.FullName));
            }
            var t_NamespaceSplits = t_InterfaceType.Namespace.Split('.');
            string t_ModuleName = string.Format("{0}.{1}.{2}", "GameBoxFramework.Runtime", t_NamespaceSplits[t_NamespaceSplits.Length - 1], t_InterfaceType.Name.Substring(1));
            Type t_ModuleType = Type.GetType(t_ModuleName);
            if (t_ModuleType == null) //如果存在这个内建模块类型
            {
                throw new GameBoxFrameworkException(string.Format("找不到系统内建模块 '{0}'.", t_ModuleName));
            }
            var t_TargetModule = IListDataStructure.GetNode(module => null != module && module.GetType() == t_ModuleType);
            if (null == t_TargetModule) //还没有存在这个模块
            {
                t_TargetModule = (BaseModule)Activator.CreateInstance(t_ModuleType);//创建该模块
                if (t_TargetModule == null)
                {
                    throw new GameBoxFrameworkException(string.Format("创建 '{0}' 模块失败.", t_ModuleType.GetType().FullName));
                }
                else
                {
                    IListDataStructure.AddNode(t_TargetModule); //添加进数据结构
                    t_TargetModule.OnInit(this); //初始化模块
                    t_TargetModule.OnStart(this); //启动模块
                }
            }
            else //已经存在这个模块
            {
                t_TargetModule.Weight++; //该模块权值刷新
                IListDataStructure.Sort(); //重新排序模块，已确保权值高的模块优先被搜索到，提高效率
            }
            //return (T)Convert.ChangeType(t_TargetModule,typeof(T)); //将 BaseModlue 转换成 模块对应的接口
            return t_TargetModule as T;
        }
        /// <summary>
        /// 模块管家初始化
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public void Init(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的初始化工作
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;
        }
        /// <summary>
        /// 模块管家启动
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public void Start(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被启动的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            var t_ModuleArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_ModuleArray.Length; i++)
            {
                if (null != t_ModuleArray[i])
                    t_ModuleArray[i].OnStart(this);
            }
        }
        /// <summary>
        /// 模块管家轮询
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public void Update(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被轮询的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            var t_ModuleArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_ModuleArray.Length; i++)
            {
                if (null != t_ModuleArray[i])
                    t_ModuleArray[i].OnUpdate(this);
            }
        }
        /// <summary>
        /// 模块管家停止
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public void Stop(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被停止的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            var t_ModuleArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_ModuleArray.Length; i++)
            {
                if (null != t_ModuleArray[i])
                    t_ModuleArray[i].OnStop(this);
            }
        }
        /// <summary>
        /// 模块管家销毁
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public void Destroy(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被销毁的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            var t_ModuleArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_ModuleArray.Length; i++)
            {
                if (null != t_ModuleArray[i])
                    t_ModuleArray[i].OnDestroy(this);
            }
        }

    }
}