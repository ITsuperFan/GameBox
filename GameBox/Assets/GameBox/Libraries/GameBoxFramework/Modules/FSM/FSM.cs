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
    /// GameBoxFramework层的 状态机
    /// </summary>
    public class FSM : BaseFSM, IFSM,IComparable<FSM>
    {
        #region 构造方法
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public FSM() : base()
        {

        }

        /// <summary>
        /// 初始化有限状态机的构造方法
        /// </summary>
        /// <param name="t_FSMName"></param>
        /// <param name="t_FSMStates"></param>
        public FSM(IFSMOwner t_IFSMOwner, string t_FSMName, params BaseFSMState[] t_FSMStates) : base(t_IFSMOwner, t_FSMName, new FSMTrieMap<string, BaseFSMState>()) //子类选择的数据类型 可以为 FSMTrieMap<string,BaseFSMState>()
        {
            for (int i = 0; i < t_FSMStates.Length; i++)
            {
                AddState(t_FSMStates[i]);
            }
        }
        #endregion

        #region 变量和属性
        /// <summary>
        /// 状态机的管理模块接口
        /// </summary>
        private IFSMOwner t_IFSMOwner;

        /// <summary>
        /// 状态机运行属性
        /// </summary>
        public override bool IsRunning
        {
            get { return isRunning; }

            protected internal set
            {
                if (value == isRunning) return;
                if (value) //如果设置在运行调用OnStart方法
                    OnStart(t_IFSMOwner);
                else //如果设置不在运行调用OnStart方法
                    OnStop(t_IFSMOwner);
            }
        }

        /// <summary>
        /// 当前状态
        /// </summary>
        public BaseFSMState State { get; protected set; }

        /// <summary>
        /// 上一个状态
        /// </summary>
        public BaseFSMState LastState { get; protected set; }

        /// <summary>
        /// 临时状态
        /// </summary>
        private BaseFSMState m_TempState;
        #endregion

        #region 事件
        /// <summary>
        /// 更改状态机事件
        /// </summary>
        public event Action<FSMEventArgs> StateChangedEventHandler;
        #endregion

        #region 状态机的操作
        /// <summary>
        /// 更改状态机事件
        /// </summary>
        public void ChangeState<T>() where T : BaseFSMState
        {
            ChangeState(typeof(T));
        }

        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <param name="t_StateType"></param>
        public void ChangeState(Type t_StateType)
        {
            if (IsRunning)
                IMapDataStructure.Foreach((key, value) => {
                    if (value.GetType() == t_StateType)
                    {
                        m_TempState = value;
                    }
                });
        }
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="t_FSMName"></param>
        public void RemoveState(string t_FSMName)
        {
            BaseFSMState value;
            IMapDataStructure.TryGetValue(t_FSMName, out value);

            if (!IMapDataStructure.ContainsKey(t_FSMName))
                IMapDataStructure.Remove(t_FSMName);

            value.OnStateDestroy(this);
        }
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <typeparam name="T">状态类型</typeparam>
        public void RemoveState<T>() where T : BaseFSMState
        {
            IMapDataStructure.Foreach((key, value) => {
                if (value is T)
                {
                    IMapDataStructure.Remove(key);
                    value.OnStateDestroy(this);
                    return;
                }
            });
        }
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="t_StateType">状态类型</param>
        public void RemoveState(Type t_StateType)
        {
            IMapDataStructure.Foreach((key, value) => {
                if (value.GetType() == t_StateType)
                {
                    IMapDataStructure.Remove(key);
                    value.OnStateDestroy(this);
                    return;
                }
            });
        }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <typeparam name="T">状态的类型</typeparam>
        public void AddState<T>() where T : BaseFSMState
        {
            var t_State = Activator.CreateInstance(typeof(T), typeof(T).Name) as BaseFSMState; // 如果改状态没有名字，那么改状态就采用状态的类名
            IMapDataStructure.Add(t_State.StateName, t_State);
            t_State.OnStateInit(this); //初始化状态机
        }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="t_StateType">状态的抽象基类类型</param>
        public void AddState(BaseFSMState t_BaseFSMState)
        {
            if (!string.IsNullOrEmpty(t_BaseFSMState.StateName))
                IMapDataStructure.Add(t_BaseFSMState.StateName, t_BaseFSMState);
            else
                IMapDataStructure.Add(t_BaseFSMState.GetType().Name, t_BaseFSMState); // 如果改状态没有名字，那么改状态就采用状态的类名

            t_BaseFSMState.OnStateInit(this); //初始化状态机
        }
        /// <summary>
        /// 更新现有的状态
        /// </summary>
        /// <param name="t_FSMStateName">要更新的现有状态的键索引</param>
        /// <param name="t_BaseFSMState">要替换的状态实例</param>
        public void UpdateState(string t_FSMStateName, BaseFSMState t_BaseFSMState)
        {
            IMapDataStructure.Update(t_FSMStateName, t_BaseFSMState);
        }
        #endregion

        #region 状态机的生命周期
        /// <summary>
        /// 状态机初始化
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal override void OnInit(IFSMOwner t_IFSMOwner)
        {
            //TODO:子类状态机可以在这里初始化一些东西
            IsRunning = true;
        }

        /// <summary>
        /// 状态机启动
        /// </summary>
        protected internal override void OnStart(IFSMOwner t_IFSMOwner)
        {
            //TODO：状态机启动后 
        }

        /// <summary>
        /// 状态机被轮询
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal override void OnUpdate(IFSMOwner t_IFSMOwner)
        {
            if (IsRunning)
            {
                if (!m_TempState.Equals(State)) //如果当前的临时状态和当前状态不是处于一个状态，那么状态已经被更改了
                {
                    State.OnStateExit(this); //上一个状态 退出
                    LastState = State;   //保存上一个状态
                    State = m_TempState; //更新当前状态
                    if (null != StateChangedEventHandler)
                        StateChangedEventHandler(new FSMEventArgs() { IFSM = this, LastState = LastState, State = State }); //事件通知
                    State.OnStateEnter(this); //当前状态 进入
                }
                else
                {
                    State.OnStateLoop(this); //当前状态 轮询
                    State.StateTotalGameWorldTime += GameBoxFrameworkTime.RealWorldElapsedTime; //状态的游戏世界总的流逝时间
                    State.StateTotalRealWorldTime += GameBoxFrameworkTime.RealWorldElapsedTime; //状态的真实世界总的流逝时间
                    State.StateGameWorldTime = GameBoxFrameworkTime.RealWorldElapsedTime; //状态的游戏世界流逝时间
                    State.StateRealWorldTime = GameBoxFrameworkTime.RealWorldElapsedTime; //状态的真实世界流逝时间
                }

            }
        }

        /// <summary>
        /// 状态机被停止
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal override void OnStop(IFSMOwner t_IFSMOwner)
        {
            //TODO：状态机关闭后 

        }

        /// <summary>
        /// 状态机被销毁
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal override void OnDestroy(IFSMOwner t_IFSMOwner)
        {
            //TODO：状态机被销毁后


        }


        #endregion

        #region 实现的接口
        /// <summary>
        /// 比较接口
        /// </summary>
        /// <param name="other">需要进行比较的目标状态机实例</param>
        /// <returns>比较后的结果</returns>
        public int CompareTo(FSM other)
        {
            return this.Weight - other.Weight; //自身的权重 - 需要进行比较的权重        
        }
        #endregion
    }
}