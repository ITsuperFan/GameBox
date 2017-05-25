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
    /// 基础条件抽象类
    /// </summary>
	public abstract class BaseFSMCondition  
	{
        #region 状态的操作

        /// <summary>
        /// 条件绑定的状态
        /// </summary>
        private Type m_StateType;

        /// <summary>
        /// 条件绑定的状态属性
        /// </summary>
        public Type StateType
        {
            get { return m_StateType; }
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <returns>返回条件基类</returns>
        public void UpdateState<T>() where T : BaseFSMState
        {
            m_StateType = typeof(T);
        }

        #endregion

        #region 构造方法
        /// <summary>
        /// 默认条件构造方法
        /// </summary>
        public BaseFSMCondition() : this(null)
        {

        }

        /// <summary>
        /// 初始化状态的条件构造方法
        /// </summary>
        /// <param name="t_State"></param>
        public BaseFSMCondition(BaseFSMState t_State)
        {

        }
        #endregion

        #region 条件的生命周期
        /// <summary>
        /// 条件初始化
        /// </summary>
        /// <param name="t_ConditionOwner">条件的持有者-状态机</param>
        protected internal abstract void OnConditionInit(IFSM t_ConditionOwner);

        /// <summary>
        /// 条件轮询
        /// </summary>
        /// <param name="t_StateOwner">条件的持有者-状态机</param>
        /// <returns>返回条件结果</returns>
        protected internal abstract bool OnConditionLoop(IFSM t_ConditionOwner);

        /// <summary>
        /// 条件被销毁
        /// </summary>
        /// <param name="t_ConditionOwner">条件的持有者-状态机</param>
        protected internal abstract void OnConditionDestroy(IFSM t_ConditionOwner);
        #endregion

    }
}