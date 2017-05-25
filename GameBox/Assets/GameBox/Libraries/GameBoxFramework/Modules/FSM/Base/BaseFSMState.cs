/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBoxFramework.Runtime.FSM
{
    /// <summary>
    /// 状态抽象类
    /// </summary>
    public abstract class BaseFSMState
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseFSMState() : this(null)
        {

        }

        /// <summary>
        /// 初始化状态名字的构造方法
        /// </summary>
        /// <param name="t_StateName"></param>
        public BaseFSMState(string t_StateName)
        {
            StateName = t_StateName ?? string.Empty;
        }

        /// <summary>
        /// 状态名字
        /// </summary>
        protected internal readonly string StateName;

        /// <summary>
        /// 该状态总的流逝时间
        /// </summary>
        public  float StateTotalGameWorldTime { get; protected internal set; }

        /// <summary>
        /// 处于该状态的流逝时间
        /// </summary>
        public  float StateGameWorldTime { get; protected internal set; }

        /// <summary>
        /// 该状态总的流逝时间
        /// </summary>
        public  float StateTotalRealWorldTime { get; protected internal set; }

        /// <summary>
        /// 处于该状态的流逝时间
        /// </summary>
        public  float StateRealWorldTime { get; protected internal set; }


        /// <summary>
        /// 初始化状态
        /// </summary>
        protected internal abstract void OnStateInit(IFSM t_StateOwner);
        /// <summary>
        /// 进入状态
        /// </summary>
        protected internal abstract void OnStateEnter(IFSM t_StateOwner);
        /// <summary>
        /// 轮训状态
        /// </summary>
        protected internal abstract void OnStateLoop(IFSM t_StateOwner);
        /// <summary>
        /// 退出状态
        /// </summary>
        protected internal abstract void OnStateExit(IFSM t_StateOwner);
        /// <summary>
        /// 销毁状态
        /// </summary>
        protected internal abstract void OnStateDestroy(IFSM t_StateOwner);

    }
}