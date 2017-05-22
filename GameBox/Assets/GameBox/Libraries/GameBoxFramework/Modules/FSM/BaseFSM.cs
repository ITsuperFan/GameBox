/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;

namespace GameBoxFramework.Runtime.FSM
{
    /// <summary>
    /// 状态机抽象基类
    /// </summary>
    public abstract class BaseFSM 
    {
        #region 变量和属性
        /// <summary>
        /// 状态机的名字
        /// </summary>
        protected internal readonly string m_FSMName;

        /// <summary>
        /// 状态机的权值
        /// </summary>
        public int Weight { get; protected internal set; }

        /// <summary>
        /// 映射图类型接口
        /// </summary>
        protected readonly IMapDataStructure<string, BaseFSMState> IMapDataStructure;

        /// <summary>
        /// 状态机是否运行变量
        /// </summary>
        protected bool isRunning;

        /// <summary>
        /// 状态机运行属性
        /// </summary>
        public abstract bool IsRunning { get; protected internal set; }
        #endregion

        #region 构造方法
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public BaseFSM() : this(null,null, new FSMTrieMap<string, BaseFSMState>()) //默认数据结构类型为 FSMTrieMap<string,BaseFSMState>()
        {

        }

        /// <summary>
        /// 初始化有限状态机的名字和有限状态机的映射数据类型的构造方法
        /// </summary>
        /// <param name="t_FSMName"></param>
        /// <param name="t_IMapDataStructure"></param>
        public BaseFSM(IFSMOwner t_IFSMOwner, string t_FSMName,  IMapDataStructure<string, BaseFSMState> t_IMapDataStructure)
        {
            m_FSMName = t_FSMName ?? string.Empty;
            IMapDataStructure = t_IMapDataStructure;
            OnInit(t_IFSMOwner);
        }
        #endregion

        #region 状态机的生命周期
        /// <summary>
        /// 状态机初始化
        /// </summary>
        /// <param name="t_IFSMOwner">状态机模块的管家</param>
        protected internal abstract void OnInit(IFSMOwner t_IFSMOwner);

        /// <summary>
        /// 状态机启动
        /// </summary>
        protected internal abstract void OnStart(IFSMOwner t_IFSMOwner);

        /// <summary>
        /// 状态机被轮询
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal abstract void OnUpdate(IFSMOwner t_IFSMOwner);

        /// <summary>
        /// 状态机被停止
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal abstract void OnStop(IFSMOwner t_IFSMOwner);

        /// <summary>
        /// 状态机被销毁
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal abstract void OnDestroy(IFSMOwner t_IFSMOwner);
        #endregion

    }
}