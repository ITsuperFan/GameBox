/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using System;

namespace GameBoxFramework.Runtime.FSM
{
    public sealed class FSMManager : BaseModule, IFSMManager, IFSMOwner
    {
        /// <summary>
        /// 抽象数据结构类型
        /// </summary>
        private readonly IListDataStructure<FSM> IListDataStructure = new FSMManagerSLinkedList();
        /// <summary>
        /// 创建状态机
        /// </summary>
        /// <param name="t_FSMName">状态机的名字</param>
        /// <param name="t_FSMStates">状态机的状态</param>
        /// <returns>创建出来的状态机实例</returns>
        public FSM CreateFSM( string t_FSMName, params FSMState[] t_FSMStates)
        {
            var t_FSM = new FSM(this, t_FSMName, t_FSMStates);
            IListDataStructure.AddNode(t_FSM);
            var t_FSMArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_FSMArray.Length; i++)
            {
                if (null != t_FSMArray[i])
                    t_FSMArray[i].IsRunning = true;
            }
            return t_FSM;
        }
        /// <summary>
        /// 获取状态机
        /// </summary>
        /// <param name="t_FSMName">状态机的名字</param>
        /// <returns>获取到的状态机实例</returns>
        public FSM GetFSM(string t_FSMName)
        {
           return IListDataStructure.GetNode(fsm=>fsm.m_FSMName == t_FSMName);
        }
        /// <summary>
        /// 移除状态机
        /// </summary>
        /// <param name="t_FSMName">状态机名字</param>
        /// <returns>返回状态机管家接口</returns>
        public IFSMManager RemoveFSM(string t_FSMName)
        {
            IListDataStructure.RemoveNode(fsm=>fsm.m_FSMName==t_FSMName);
            return this;
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

        }
        /// <summary>
        /// 模块被轮询的时候调用
        /// </summary>
        protected internal override void OnUpdate(IModuleManager t_IModuleManager)
        {
            var t_FSMArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_FSMArray.Length; i++)
            {
                if (null != t_FSMArray[i])
                    t_FSMArray[i].OnUpdate(this);
            }
        }
        /// <summary>
        /// 模块被停止的时候调用
        /// </summary>
        protected internal override void OnStop(IModuleManager t_IModuleManager)
        {
            var t_FSMArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_FSMArray.Length; i++)
            {
                if (null != t_FSMArray[i])
                    t_FSMArray[i].IsRunning = false;
            }
        }
        /// <summary>
        /// 模块被销毁前调用
        /// </summary>
        protected internal override void OnDestroy(IModuleManager t_IModuleManager)
        {
            var t_FSMArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_FSMArray.Length; i++)
            {
                if (null != t_FSMArray[i])
                    t_FSMArray[i].IsRunning = false;
            }
        }
    }
}