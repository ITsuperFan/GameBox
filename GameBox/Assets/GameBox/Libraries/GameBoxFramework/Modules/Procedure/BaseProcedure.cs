/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using GameBoxFramework.FSM;
using System;

namespace GameBoxFramework.Procedure
{
    /// <summary>
    /// 抽象流程基类
    /// </summary>
	public abstract class BaseProcedure : BaseFSMState
    {
        /// <summary>
        /// 该流程的持有者
        /// </summary>
        private IFSM m_ProcedureOwner;

        /// <summary>
        /// 默认构造方法
        /// </summary>
        public BaseProcedure() : base()
        {

        }

        /// <summary>
        /// 初始化状态名字的构造方法
        /// </summary>
        /// <param name="t_StateName"></param>
        public BaseProcedure(string t_StateName) : base(t_StateName)
        {

        }

        /// <summary>
        /// 改变流程
        /// </summary>
        /// <typeparam name="T">流程的类型</typeparam>
        public void ChangeProcedure<T>() where T : BaseProcedure
        {
            m_ProcedureOwner.ChangeState<T>();
        }

        /// <summary>
        /// 改变流程
        /// </summary>
        /// <param name="t_ProcedureType">流程的Type类型</param>
        public void ChangeProcedure(Type t_ProcedureType)
        {
            m_ProcedureOwner.ChangeState(t_ProcedureType);
        }

        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <param name="t_StateName">状态的名字</param>
        public void ChangeProcedure(string t_ProcedureName)
        {
            m_ProcedureOwner.ChangeState(t_ProcedureName);
        }


        //GBF层用的状态处理方法，GBF驱动
        protected internal override void OnStateInit(IFSM t_StateOwner)
        {
            m_ProcedureOwner = t_StateOwner;
            ProcedureInit(t_StateOwner);
        }
        protected internal override void OnStateEnter(IFSM t_StateOwner)
        {
            ProcedureEnter(t_StateOwner);
        }
        protected internal override void OnStateLoop(IFSM t_StateOwner)
        {
            ProcedureLoop(t_StateOwner);
        }
        protected internal override void OnStateExit(IFSM t_StateOwner)
        {
            ProcedureExit(t_StateOwner);
        }
        protected internal override void OnStateDestroy(IFSM t_StateOwner)
        {
            ProcedureDestroy(t_StateOwner);
        }

        //非GBF层用的状态处理方法
        protected abstract void ProcedureInit(IFSM t_ProcedureOwner);
        protected abstract void ProcedureEnter(IFSM t_ProcedureOwner);
        protected abstract void ProcedureLoop(IFSM t_ProcedureOwner);
        protected abstract void ProcedureExit(IFSM t_ProcedureOwner);
        protected abstract void ProcedureDestroy(IFSM t_ProcedureOwner);

    }
}