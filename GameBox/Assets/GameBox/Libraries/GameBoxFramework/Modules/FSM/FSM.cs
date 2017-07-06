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
    /// GameBoxFramework层的 状态机
    /// </summary>
    public class FSM : BaseFSM, IFSM, IComparable<FSM>
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
        public FSM(IFSMOwner t_IFSMOwner, string t_FSMName, params BaseFSMState[] t_FSMStates) : base(t_IFSMOwner, t_FSMName, new FSMTrieMap<string, BaseFSMState>(), new FSMTrieMap<string, BaseFSMCondition>()) //子类选择的数据类型 可以为 FSMTrieMap<string,BaseFSMState>()
        {
            AddState(t_FSMStates); // 批量添加状态机条件
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
        public bool IsRunning { get; protected set; }
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
                IStateMapDataStructure.Foreach((key, value) => {
                    if (value.GetType() == t_StateType)
                    {
                        m_TempState = value;
                    }
                });
        }
        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <param name="t_BaseFSMState">更改的目标状态</param>
        public void ChangeState(BaseFSMState t_BaseFSMState)
        {
            if (IsRunning)
                IStateMapDataStructure.Foreach((key, value) => {
                    if (value.Equals(t_BaseFSMState))
                    {
                        m_TempState = value;
                    }
                });
        }
        /// <summary>
        /// 更改状态机状态
        /// </summary>
        /// <param name="t_StateName">状态的名字</param>
        public void ChangeState(string t_StateName)
        {
            if (IsRunning)
                IStateMapDataStructure.Foreach((key, value) => {
                    if (key== t_StateName)
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
            IStateMapDataStructure.TryGetValue(t_FSMName, out value);

            if (!IStateMapDataStructure.ContainsKey(t_FSMName))
                IStateMapDataStructure.Remove(t_FSMName);

            if (null != value)
                value.OnStateDestroy(this);
        }
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <typeparam name="T">状态类型</typeparam>
        public void RemoveState<T>() where T : BaseFSMState
        {
            IStateMapDataStructure.Foreach((key, value) => {
                if (value is T)
                {
                    IStateMapDataStructure.Remove(key);
                    value.OnStateDestroy(this);
                }
            });
        }
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="t_StateType">状态类型</param>
        public void RemoveState(Type t_StateType)
        {
            IStateMapDataStructure.Foreach((key, value) => {
                if (value.GetType() == t_StateType)
                {
                    IStateMapDataStructure.Remove(key);
                    value.OnStateDestroy(this);
                }
            });
        }
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="t_StateType">状态类型不定项数组</param>
        public void RemoveState(params Type[] t_StateTypes)
        {
            if(null!= t_StateTypes)
                for (int i = 0; i < t_StateTypes.Length; i++)
                {
                    RemoveState(t_StateTypes[i]);
                }
        }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <typeparam name="T">状态的类型</typeparam>
        public void AddState<T>() where T : BaseFSMState
        {
            var t_State = Activator.CreateInstance(typeof(T)) as BaseFSMState; // 如果改状态没有名字，那么改状态就采用状态的类名
            if (IStateMapDataStructure.ContainsKey(typeof(T).Name))
                throw new GameBoxFrameworkException(string.Format("状态'{0}'已经存在!", typeof(T).Name));

            IStateMapDataStructure.Add(typeof(T).Name, t_State);
            t_State.OnStateInit(this); //初始化状态机
        }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="t_StateType">状态的抽象基类类型的Type类</param>
        public void AddState(Type t_StateType)
        {
            if (IStateMapDataStructure.ContainsKey(t_StateType.Name))
                throw new GameBoxFrameworkException(string.Format("状态'{0}'已经存在!", t_StateType.Name));

            AddState(Activator.CreateInstance(t_StateType) as BaseFSMState);

            //var t_Ctor = t_StateType.GetConstructors();

            //if (0 < t_Ctor.Length) //有构造方法
            //{
            //    AddState(Activator.CreateInstance(t_StateType) as BaseFSMState);
            //}
            //else //无默认构造方法
            //{
            //    AddState(FormatterServices.GetSafeUninitializedObject(t_StateType) as BaseFSMState);
            //}
        }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="t_StateTypes">状态的抽象基类类型的Type类不定项数组</param>
        public void AddState(params Type[] t_StateTypes)
        {
            if(null!= t_StateTypes)
            for (int i = 0; i < t_StateTypes.Length; i++)
            {
               AddState(t_StateTypes[i]);
            }
        }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="t_StateType">状态的抽象基类类型</param>
        public void AddState(BaseFSMState t_BaseFSMState)
        {
            if(null==t_BaseFSMState)
                throw new GameBoxFrameworkException(string.Format("添加的状态不能为空!"));

            if (!string.IsNullOrEmpty(t_BaseFSMState.StateName))
            {
                if (IStateMapDataStructure.ContainsKey(t_BaseFSMState.StateName))
                        throw new GameBoxFrameworkException(string.Format("状态'{0}'已经存在!", t_BaseFSMState.GetType().Name));
                IStateMapDataStructure.Add(t_BaseFSMState.StateName, t_BaseFSMState);
            }
            else
            {
                if (IStateMapDataStructure.ContainsKey(t_BaseFSMState.GetType().Name)) throw new GameBoxFrameworkException(string.Format("状态'{0}'已经存在!", t_BaseFSMState.GetType().Name));
                IStateMapDataStructure.Add(t_BaseFSMState.GetType().Name, t_BaseFSMState); // 如果改状态没有名字，那么改状态就采用状态的类名
            }
                

            t_BaseFSMState.OnStateInit(this); //初始化状态机
        }
        /// <summary>
        /// 批量添加状态
        /// </summary>
        /// <param name="BaseFSMState">状态的抽象基类类型</param>
        public void AddState(params BaseFSMState[] t_BaseFSMStates)
        {
            for (int i = 0; i < t_BaseFSMStates.Length; i++)
            {
                AddState(t_BaseFSMStates[i]);
            }
        }
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <typeparam name="T">状态的类型</typeparam>
        /// <returns>状态的实例</returns>
        public T GetState<T>() where T : BaseFSMState
        {
            var t_Array = IStateMapDataStructure.ToArray();
            for (int i = 0; i < t_Array.Length; i++)
            {
                if (t_Array[i].Value is T)
                {
                    return t_Array[i].Value as T;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取所有状态
        /// </summary>
        /// <returns>基础状态数组</returns>
        public BaseFSMState[] GetAllState()
        {
            BaseFSMState[] t_BaseFSMStates = new BaseFSMState[IStateMapDataStructure.Count];
            var t_StateMaps = IStateMapDataStructure.ToArray();
            for (int i = 0; i < t_StateMaps.Length; i++)
            {
                t_BaseFSMStates[i] = t_StateMaps[i].Value;
            }
            return t_BaseFSMStates;
        }
        /// <summary>
        /// 更新现有的状态
        /// </summary>
        /// <param name="t_FSMStateName">要更新的现有状态的键索引</param>
        /// <param name="t_BaseFSMState">要替换的状态实例</param>
        public void UpdateState(string t_FSMStateName, BaseFSMState t_BaseFSMState)
        {
            if(IStateMapDataStructure.ContainsKey(t_FSMStateName))
                IStateMapDataStructure.Update(t_FSMStateName, t_BaseFSMState);
        }
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="t_Type">状态的Type类型</param>
        /// <returns>状态的抽象基础状态的实例引用</returns>
        public BaseFSMState GetState(Type t_Type)
        {
            var t_Array = IStateMapDataStructure.ToArray();
            for (int i = 0; i < t_Array.Length; i++)
            {
                if (t_Array[i].Value.GetType() == t_Type)
                {
                    return t_Array[i].Value as BaseFSMState;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="t_StateName">状态保存进状态机时名字</param>
        /// <returns>状态的抽象基础状态的实例引用</returns>
        public BaseFSMState GetState(string t_StateName)
        {
            BaseFSMState t_BaseFSMState;
            IStateMapDataStructure.TryGetValue(t_StateName, out t_BaseFSMState);
            return t_BaseFSMState;
        }
        /// <summary>
        /// 添加状态机条件
        /// </summary>
        /// <typeparam name="T">状态机条件</typeparam>
        public void AddCondition<T>() where T : BaseFSMCondition
        {
            if (!IConditionMapDataStructure.ContainsKey(typeof(T).Name))
                IConditionMapDataStructure.Add(typeof(T).Name, Activator.CreateInstance<T>());
            else
                throw new GameBoxFrameworkException(string.Format("已经存在'{0}'条件",typeof(T).Name));      
        }
        /// <summary>
        /// 添加状态机条件
        /// </summary>
        /// <param name="t_BaseFSMCondition">状态机条件类型</param>
        public void AddCondition(BaseFSMCondition t_BaseFSMCondition)
        {
            if (!IConditionMapDataStructure.ContainsValue(t_BaseFSMCondition))
                IConditionMapDataStructure.Add(t_BaseFSMCondition.GetType().Name, t_BaseFSMCondition);
            else
                throw new GameBoxFrameworkException(string.Format("已经存在'{0}'条件", t_BaseFSMCondition.GetType().Name));
        }
        /// <summary>
        /// 批量添加状态机条件
        /// </summary>
        /// <param name="t_BaseFSMCondition">状态机条件类型</param>
        public void AddCondition(params BaseFSMCondition[] t_BaseFSMConditions)
        {
            for (int i = 0; i < t_BaseFSMConditions.Length; i++)
            {
                AddCondition(t_BaseFSMConditions[i]);
            }
        }
        /// <summary>
        /// 移除状态机条件
        /// </summary>
        /// <param name="t_FSMName">状态机条件的类名</param>
        public void RemoveCondition(string t_ConditionName)
        {
            BaseFSMCondition value;
            IConditionMapDataStructure.TryGetValue(t_ConditionName, out value);

            if (!IStateMapDataStructure.ContainsKey(t_ConditionName))
                IStateMapDataStructure.Remove(t_ConditionName);
            if(null!=value)
                value.OnConditionDestroy(this);
        }
        /// <summary>
        /// 移除状态机条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveCondition<T>() where T : BaseFSMCondition
        {
            IConditionMapDataStructure.Foreach((key, value) => {
                if (value is T)
                {
                    IStateMapDataStructure.Remove(key);
                    value.OnConditionDestroy(this);
                }
            });
        }
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="t_StateType">状态类型</param>
        public void RemoveCondition(Type t_ConditionType)
        {
            IConditionMapDataStructure.Foreach((key, value) => {
                if (value.GetType() == t_ConditionType)
                {
                    IConditionMapDataStructure.Remove(key);
                    value.OnConditionDestroy(this);
                }
            });
        }
        /// <summary>
        /// 批量移除状态机条件
        /// </summary>
        /// <param name="t_StateType">状态机条件不定项数组</param>
        public void RemoveCondition(params Type[] t_ConditionTypes)
        {
            if (null!=t_ConditionTypes)
            for (int i = 0; i < t_ConditionTypes.Length; i++)
            {
                    RemoveCondition(t_ConditionTypes[i]);
            }
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <typeparam name="T">基础状态机条件</typeparam>
        /// <returns>状态机条件</returns>
        public T GetCondition<T>() where T : BaseFSMCondition
        {
            BaseFSMCondition t_Condition;
            IConditionMapDataStructure.TryGetValue(typeof(T).Name, out t_Condition);
            return t_Condition as T;
        }

        /// <summary>
        /// 获取所有条件
        /// </summary>
        /// <returns>基础条件实例数组</returns>
        public BaseFSMCondition[] GetAllCondition()
        {
            BaseFSMCondition[] t_BaseConditions = new BaseFSMCondition[IConditionMapDataStructure.Count];
            var t_ConditionMaps = IConditionMapDataStructure.ToArray();
            for (int i = 0; i < t_ConditionMaps.Length; i++)
            {
                t_BaseConditions[i] = t_ConditionMaps[i].Value;
            }
            return t_BaseConditions;
        }


        /// <summary>
        /// 轮询更新状态
        /// </summary>
        private void UpdateState()
        {
            if (null == m_TempState) throw new GameBoxFrameworkException(string.Format("状态机 '{0}' 没有被赋予初始状态！", m_FSMName));

            if (!m_TempState.Equals(State)) //如果当前的临时状态和当前状态不是处于一个状态，那么状态已经被更改了
            {
                if (null != State) //如果当前状态已经被初始化
                {
                    State.OnStateExit(this); //上一个状态 退出
                    State.StateStayRealWorldTime = 0; //清0时间
                    State.StateStayGameWorldTime = 0;//清0时间

                    LastState = State;   //保存上一个状态
                }

                State = m_TempState; //更新当前状态
                if (null != StateChangedEventHandler)
                    StateChangedEventHandler(new FSMEventArgs() { IFSM = this, LastState = LastState, State = State }); //事件通知

                State.OnStateEnter(this); //当前状态 进入
                
            }
            else
            {
                State.OnStateLoop(this); //当前状态 轮询
                State.StateStayTotalGameWorldTime += GameBoxFrameworkTime.GameWorldElapsedTime; //状态的游戏世界总的流逝时间
                State.StateLoopGameWorldTime = GameBoxFrameworkTime.GameWorldElapsedTime; //状态的游戏世界总的流逝时间
                State.StateStayGameWorldTime += GameBoxFrameworkTime.GameWorldElapsedTime; //状态从进入开始到现在的游戏世界总的流逝时间，退出后会被重置为0

                State.StateStayTotalRealWorldTime += GameBoxFrameworkTime.RealWorldElapsedTime; //状态的真实世界流逝时间
                State.StateLoopRealWorldTime = GameBoxFrameworkTime.RealWorldElapsedTime; //状态的真实世界流逝时间
                State.StateStayRealWorldTime += GameBoxFrameworkTime.RealWorldElapsedTime; //状态从进入开始到现在的游戏世界总的流逝时间，退出后会被重置为0

            }
        }
        /// <summary>
        /// 轮询更新条件
        /// </summary>
        private void UpdateCondition()
        {
            IConditionMapDataStructure.Foreach((key,value)=> {
                if (value.OnConditionLoop(this))
                {
                    if(null!= value.StateType)
                        ChangeState(value.StateType);
                }
            });
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
            IsRunning = true;
        }
        /// <summary>
        /// 状态机被轮询
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal override void OnUpdate(IFSMOwner t_IFSMOwner)
        {
            if (IsRunning) //如果状态机在运行
            {
                UpdateState(); //轮询更新状态
                UpdateCondition(); //轮询更新条件
            }
        }
        /// <summary>
        /// 状态机被停止
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal override void OnStop(IFSMOwner t_IFSMOwner)
        {
            //TODO：状态机关闭后 
            IsRunning = false;

        }
        /// <summary>
        /// 状态机被销毁
        /// </summary>
        /// <param name="t_IModuleManager">状态机模块的管家</param>
        protected internal override void OnDestroy(IFSMOwner t_IFSMOwner)
        {
            //TODO：状态机被销毁后

            IsRunning = false;

            //销毁所有的状态
            IStateMapDataStructure.Foreach((key,value)=> {

                value.OnStateDestroy(this);

            });
            IStateMapDataStructure.Clear();

            //销毁所有的条件
            IConditionMapDataStructure.Foreach((key, value) => {

                value.OnConditionDestroy(this);

            });
            IConditionMapDataStructure.Clear();

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