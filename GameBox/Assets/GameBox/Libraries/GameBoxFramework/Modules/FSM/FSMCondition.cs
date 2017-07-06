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
    /// 状态机基础条件抽象类
    /// </summary>
    public abstract class FSMCondition : BaseFSMCondition
    {
        /// <summary>
        /// 条件被轮询事件
        /// </summary>
        public event Action<bool> ConditionUpdateEventHandler;

        /// <summary>
        /// 条件初始化
        /// </summary>
        /// <param name="t_ConditionOwner">条件的持有者-状态机</param>
        protected internal override void OnConditionInit(IFSM t_ConditionOwner)
        {
            ConditionInit(t_ConditionOwner);
        }
        /// <summary>
        /// 条件轮询
        /// </summary>
        /// <param name="t_StateOwner">条件的持有者-状态机</param>
        /// <returns>返回条件结果</returns>
        protected internal override bool OnConditionLoop(IFSM t_ConditionOwner)
        {
            bool t_ConditionState = ConditionLoop(t_ConditionOwner);
            if (null!=ConditionUpdateEventHandler)
            {
                ConditionUpdateEventHandler(t_ConditionState);
            }
            return t_ConditionState;
        }
        /// <summary>
        /// 条件被销毁
        /// </summary>
        /// <param name="t_ConditionOwner">条件的持有者-状态机</param>
        protected internal override void OnConditionDestroy(IFSM t_ConditionOwner)
        {
            ConditionDestroy(t_ConditionOwner);
        }
        /// <summary>
        /// 条件初始化
        /// </summary>
        /// <param name="t_ConditionOwner">条件的持有者-状态机</param>
        public abstract void ConditionInit(IFSM t_ConditionOwner);
        /// <summary>
        /// 条件轮询
        /// </summary>
        /// <param name="t_StateOwner">条件的持有者-状态机</param>
        /// <returns>返回条件结果</returns>
        public abstract bool ConditionLoop(IFSM t_ConditionOwner);
        /// <summary>
        /// 条件被销毁
        /// </summary>
        /// <param name="t_ConditionOwner">条件的持有者-状态机</param>
        public abstract void ConditionDestroy(IFSM t_ConditionOwner);

    }
}