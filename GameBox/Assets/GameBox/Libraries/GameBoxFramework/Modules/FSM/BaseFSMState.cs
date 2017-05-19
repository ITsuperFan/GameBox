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
        /// 该状态总的流逝时间
        /// </summary>
        public abstract float StateTime { get; protected set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseFSMState()
        {
            StateInit(); //状态的初始化
        }
        /// <summary>
        /// 初始化状态
        /// </summary>
        protected internal abstract void StateInit();
        /// <summary>
        /// 进入状态
        /// </summary>
        protected internal abstract void StateEnter();
        /// <summary>
        /// 轮训状态
        /// </summary>
        protected internal abstract void StateLoop();
        /// <summary>
        /// 退出状态
        /// </summary>
        protected internal abstract void StateExit();

    }
}