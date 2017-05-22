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
    /// 状态机接口
    /// </summary>
    public interface IFSM 
	{
        /// <summary>
        /// 更改状态机事件
        /// </summary>
        event Action<FSMEventArgs> StateChangedEventHandler;

        /// <summary>
        /// 当前状态
        /// </summary>
        BaseFSMState State { get; }

        /// <summary>
        /// 上一个状态
        /// </summary>
        BaseFSMState LastState { get; }

        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void ChangeState<T>()where T : BaseFSMState;

        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <param name="t_StateType"></param>
        void ChangeState(Type t_StateType);

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <typeparam name="T">状态的类型</typeparam>
        void AddState<T>() where T: BaseFSMState;

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="t_StateType">状态的抽象基类类型</param>
        void AddState(BaseFSMState t_BaseFSMState);

        /// <summary>
        /// 更新现有的状态
        /// </summary>
        /// <param name="t_FSMStateName">要更新的现有状态的键索引</param>
        /// <param name="t_BaseFSMState">要替换的状态实例</param>
        void UpdateState(string t_FSMStateName,BaseFSMState t_BaseFSMState);

        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="t_FSMName">状态名字</param>
        void RemoveState(string t_FSMName);

        /// <summary>
        /// 移除状态
        /// </summary>
        /// <typeparam name="T">状态类型</typeparam>
        void RemoveState<T>() where T:BaseFSMState;

        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="t_StateType">状态类型</param>
        void RemoveState(Type t_StateType);
    }
}