/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/




using System.Collections.Generic;

namespace GameBoxFramework.FSM
{
    /// <summary>
    /// 状态机管家接口
    /// </summary>
	public interface IFSMManager 
	{

        /// <summary>
        /// 创建状态机
        /// </summary>
        /// <param name="t_IFSMOwner">状态机的持有者</param>
        /// <param name="t_FSMName">状态机的名字</param>
        /// <param name="t_FSMStates">状态机的状态</param>
        /// <returns>创建出来的状态机实例</returns>
        IFSM CreateFSM(string t_FSMName,params FSMState[] t_FSMStates);

        /// <summary>
        /// 获取状态机
        /// </summary>
        /// <param name="t_FSMName">状态机的名字</param>
        /// <returns>获取到的状态机实例</returns>
        IFSM GetFSM(string t_FSMName);

        /// <summary>
        /// 移除状态机
        /// </summary>
        /// <param name="t_FSMName">状态机名字</param>
        /// <returns>返回状态机管家接口</returns>
        IFSMManager RemoveFSM(string t_FSMName);


    }
}