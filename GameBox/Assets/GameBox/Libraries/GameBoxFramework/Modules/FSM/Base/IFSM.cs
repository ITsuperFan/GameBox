/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;

namespace GameBoxFramework.FSM
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
        /// 状态机的运行状态
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void ChangeState<T>()where T : BaseFSMState;

        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <param name="t_BaseFSMState">更改的目标状态</param>
        void ChangeState(BaseFSMState t_BaseFSMState);

        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <param name="t_StateType"></param>
        void ChangeState(Type t_StateType);

        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <param name="t_StateName">状态的名字</param>
        void ChangeState(string t_StateName);

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
        /// 批量添加状态
        /// </summary>
        /// <param name="BaseFSMState">状态的抽象基类类型</param>
        void AddState(params BaseFSMState[] t_BaseFSMStates);

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="t_StateType">状态的Type</param>
        void AddState(Type t_StateType);

        /// <summary>
        /// 批量添加状态
        /// </summary>
        /// <param name="t_StateTypes">状态的抽象基类类型的Type类不定项数组</param>
        void AddState(params Type[] t_StateTypes);

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>状态实例</returns>
        T GetState<T>() where T : BaseFSMState;

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="t_Type">状态的Type类型</param>
        /// <returns>状态的抽象基础状态的实例引用</returns>
        BaseFSMState GetState(Type t_Type);

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="t_StateName">状态保存进状态机时名字</param>
        /// <returns>状态的抽象基础状态的实例引用</returns>
        BaseFSMState GetState(string t_StateName);

        /// <summary>
        /// 获取所有状态
        /// </summary>
        /// <returns>基础状态数组</returns>
        BaseFSMState[] GetAllState();

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

        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="t_StateType">状态类型不定项数组</param>
        void RemoveState(params Type[] t_StateTypes);

        /// <summary>
        /// 添加状态机条件
        /// </summary>
        /// <typeparam name="T">状态机条件类型</typeparam>
        void AddCondition<T>() where T : BaseFSMCondition;

        /// <summary>
        /// 添加状态机条件
        /// </summary>
        /// <param name="t_BaseFSMCondition">状态机条件类型</param>
        void AddCondition(BaseFSMCondition t_BaseFSMCondition);

        /// <summary>
        /// 批量添加状态机条件
        /// </summary>
        /// <param name="t_BaseFSMCondition">状态机条件类型</param>
        void AddCondition(params BaseFSMCondition[] t_BaseFSMConditions);

        /// <summary>
        /// 移除状态机条件
        /// </summary>
        /// <param name="t_FSMName">状态机条件的类名</param>
        void RemoveCondition(string t_ConditionName);

        /// <summary>
        /// 移除状态机条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RemoveCondition<T>() where T : BaseFSMCondition;

        /// <summary>
        /// 移除状态机条件
        /// </summary>
        /// <param name="t_StateType">状态机条件</param>
        void RemoveCondition(Type t_ConditionType);

        /// <summary>
        /// 批量移除状态机条件
        /// </summary>
        /// <param name="t_StateType">状态机条件不定项数组</param>
        void RemoveCondition(params Type[] t_ConditionTypes);

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <typeparam name="T">基础状态机条件</typeparam>
        /// <returns>状态机条件</returns>
        T GetCondition<T>() where T : BaseFSMCondition;

        /// <summary>
        /// 获取所有条件
        /// </summary>
        /// <returns>基础条件实例数组</returns>
        BaseFSMCondition[] GetAllCondition();
    }
}