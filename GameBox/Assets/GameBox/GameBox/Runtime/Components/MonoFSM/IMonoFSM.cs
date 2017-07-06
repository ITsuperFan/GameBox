using System;
using UnityEngine;

namespace GameBox.Runtime.Component
{

    public interface IMonoFSM
    {
        /// <summary>
        /// 状态机的Runner
        /// </summary>
        MonoBehaviour Component { get; }

        /// <summary>
        /// 当前的状态映射数据结构
        /// </summary>
        StateMapping CurrentStateMap { get; }

        /// <summary>
        /// 是否正在转移状态
        /// </summary>
        bool IsInTransition { get; }

    }


    public interface IMonoFSM<T> : IMonoFSM where T : struct, IConvertible, IComparable
    {


        /// <summary>
        /// 状态机状态的改变事件
        /// </summary>
        event Action<T> OnFSMStateChangedEventHandler;

        /// <summary>
        /// 当前状态
        /// </summary>
        T State { get; }
       
        /// <summary>
        /// 上一次的状态
        /// </summary>
        T LastState{get;}

        /// <summary>
        /// 改变状态的状态
        /// </summary>
        /// <param name="t_NewState"></param>
        void ChangeState(T t_NewState);

        /// <summary>
        /// 改变状态的状态
        /// </summary>
        /// <param name="t_NewState">改变状态的模式</param>
        /// <param name="t_FSMStateTransitionOption"></param>
        void ChangeState(T t_NewState, MonoFSMStateTransitionOption t_FSMStateTransitionOption);

    }



}
