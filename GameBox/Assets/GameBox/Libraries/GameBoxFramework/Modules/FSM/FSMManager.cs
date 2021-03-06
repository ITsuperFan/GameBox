﻿/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Collections.Generic;

namespace GameBoxFramework.FSM
{
    /// <summary>
    /// 状态机模块
    /// </summary>
    internal sealed class FSMManager : BaseModule, IFSMManager, IFSMOwner
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
        public IFSM CreateFSM( string t_FSMName, params FSMState[] t_FSMStates)
        {
            var t_FSM = new FSM(this, t_FSMName, t_FSMStates);
            t_FSM.OnInit(this);
            t_FSM.OnStart(this);
            IListDataStructure.AddNode(t_FSM);
            return t_FSM;
        }

        /// <summary>
        /// 获取状态机
        /// </summary>
        /// <param name="t_FSMName">状态机的名字</param>
        /// <returns>获取到的状态机实例</returns>
        public IFSM GetFSM(string t_FSMName)
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
            ////防止内建模块的状态机服务被关闭
            //for (int i = 0; i < BuiltInFSMList.Length; i++)
            //{
            //    if (t_FSMName==BuiltInFSMList[i])
            //    {
            //        return this;
            //    }
            //} 

            var t_FSM =  IListDataStructure.GetNode(fsm => fsm.m_FSMName == t_FSMName);
            t_FSM.OnDestroy(this);
            IListDataStructure.RemoveNode(fsm => fsm.m_FSMName == t_FSMName);
            return this;
        }

        /// <summary>
        /// 模块初始化的时候调用
        /// </summary>
        protected internal override void OnInit(IModuleManager t_IModuleManager)
        {
            //TODO:模块初始化时候的一些操作
           
        }

        /// <summary>
        /// 模块被启动的时候调用
        /// </summary>
        protected internal override void OnStart(IModuleManager t_IModuleManager)
        {
            //TODO:模块启动时候的一些操作

            var t_FSMArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_FSMArray.Length; i++)
            {
                if (null != t_FSMArray[i] && false == t_FSMArray[i].IsRunning) //如果该状态机的状态为不运行状态，那么去调用状态机的启动方法
                    t_FSMArray[i].OnStart(this);
            }
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
                    t_FSMArray[i].OnStop(this);
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
                    t_FSMArray[i].OnDestroy(this);
            }
        }


    }
}