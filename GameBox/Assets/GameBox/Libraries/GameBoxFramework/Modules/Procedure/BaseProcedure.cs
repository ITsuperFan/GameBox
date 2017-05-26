/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using GameBoxFramework.Runtime.FSM;

namespace GameBoxFramework.Runtime.Procedure
{
    /// <summary>
    /// 抽象流程基类
    /// </summary>
	public abstract class BaseProcedure : BaseFSMState
    {
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

        //GBF层用的状态处理方法，GBF驱动
        protected internal override void OnStateInit(IFSM t_StateOwner)
        {
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
        protected virtual void ProcedureInit(IFSM t_StateOwner) { }
        protected virtual void ProcedureEnter(IFSM t_StateOwner) { }
        protected virtual void ProcedureLoop(IFSM t_StateOwner) { }
        protected virtual void ProcedureExit(IFSM t_StateOwner) { }
        protected virtual void ProcedureDestroy(IFSM t_StateOwner) { }

    }
}