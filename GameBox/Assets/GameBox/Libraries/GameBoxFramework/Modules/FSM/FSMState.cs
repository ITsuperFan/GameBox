/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBoxFramework.Runtime.FSM
{
    /// <summary>
    /// GBF层的状态抽象基类
    /// </summary>
    public abstract class FSMState : BaseFSMState
    {
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public FSMState() : base()
        {

        }
        /// <summary>
        /// 初始化状态名字的构造方法
        /// </summary>
        /// <param name="t_StateName"></param>
        public FSMState(string t_StateName) : base(t_StateName)
        {

        }

        //GBF层用的状态处理方法，GBF驱动
        protected internal override void OnStateInit(IFSM t_StateOwner)
        {
            StateInit(t_StateOwner);
        }
        protected internal override void OnStateEnter(IFSM t_StateOwner)
        {
            StateEnter(t_StateOwner);
        }
        protected internal override void OnStateLoop(IFSM t_StateOwner)
        {
            StateLoop(t_StateOwner);
        }
        protected internal override void OnStateExit(IFSM t_StateOwner)
        {
            StateExit(t_StateOwner);
        }
        protected internal override void OnStateDestroy(IFSM t_StateOwner)
        {
            StateDestroy(t_StateOwner);
        }

        //非GBF层用的状态处理方法
        protected virtual void StateInit(IFSM t_StateOwner) { }
        protected virtual void StateEnter(IFSM t_StateOwner) { }
        protected virtual void StateLoop(IFSM t_StateOwner) { }
        protected virtual void StateExit(IFSM t_StateOwner) { }
        protected virtual void StateDestroy(IFSM t_StateOwner) { }
    }
}