/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
namespace GameBoxFramework.Procedure
{
    using GameBoxFramework.FSM;
    /// <summary>
    /// 流程模块
    /// </summary>
    internal sealed class ProcedureManager :BaseModule ,IProcedureManager,IFSMOwner
    {

        #region 变量和属性
        /// <summary>
        /// 流程状态机
        /// </summary>
        private FSM m_ProcedureFSM;
        /// <summary>
        /// 启动的第一个流程是否已经被初始化
        /// </summary>
        private bool m_IsBootProcedureInit;
        /// <summary>
        /// 启动的第一个流程变量
        /// </summary>
        public BaseProcedure m_BootProcedure;
        /// <summary>
        /// 当前的流程属性
        /// </summary>
        public BaseProcedure CurrentProcedure { get { return m_ProcedureFSM.State as BaseProcedure; } }

        /// <summary>
        /// 启动的第一个流程
        /// </summary>
        public BaseProcedure BootProcedure {
            get { return m_BootProcedure; }
            set {
                if (null == m_BootProcedure)
                {
                    m_BootProcedure = value;
                    m_ProcedureFSM.ChangeState(m_BootProcedure);
                }
            } }

        /// <summary>
        /// 获取所有的流程
        /// </summary>
        public BaseProcedure[] Procedures { get {

                return (BaseProcedure[])m_ProcedureFSM.GetAllState();

            } }
        #endregion

        #region 流程模块的操作
        /// <summary>
        /// 添加流程
        /// </summary>
        /// <typeparam name="T">流程类型</typeparam>
        public void AddProcedure<T>() where T : BaseProcedure
        {
            m_ProcedureFSM.AddState<T>();
        }
        /// <summary>
        /// 获取流程
        /// </summary>
        /// <typeparam name="T">流程类型</typeparam>
        /// <returns>流程实例</returns>
        public T GetProcedure<T>() where T : BaseProcedure
        {
            return m_ProcedureFSM.GetState<T>();
        }
        /// <summary>
        /// 移除流程
        /// </summary>
        /// <typeparam name="T">流程类型</typeparam>
        public void RemoveProcedure<T>() where T : BaseProcedure
        {
            m_ProcedureFSM.RemoveState<T>();
        }
        /// <summary>
        /// 添加流程
        /// </summary>
        /// <param name="t_ProcedureType">流程的Type类型</param>
        public void AddProcedure(Type t_ProcedureType)
        {
            m_ProcedureFSM.AddState(t_ProcedureType);
        }
        /// <summary>
        /// 获取流程
        /// </summary>
        /// <param name="t_ProcedureType">流程的Type类型</param>
        /// <returns></returns>
        public BaseProcedure GetProcedure(Type t_ProcedureType)
        {
            return m_ProcedureFSM.GetState(t_ProcedureType) as BaseProcedure;
        }
        #endregion

        #region 流程模块的生命周期

        /// <summary>
        /// 模块初始化的时候调用
        /// </summary>
        protected internal override void OnInit(IModuleManager t_IModuleManager)
        {         
            m_ProcedureFSM = new FSM(this,"ProcedureFSM");
            m_ProcedureFSM.OnInit(this);
        }

        /// <summary>
        /// 模块被启动的时候调用
        /// </summary>
        protected internal override void OnStart(IModuleManager t_IModuleManager)
        {
            m_ProcedureFSM.OnStart(this);
        }

        /// <summary>
        /// 模块被轮询的时候调用
        /// </summary>
        protected internal override void OnUpdate(IModuleManager t_IModuleManager)
        {

            if (null != BootProcedure)
                m_ProcedureFSM.OnUpdate(this);
            else
                throw new GameBoxFrameworkException(string.Format("没有添加启动的第一个流程!"));
           
        }

        /// <summary>
        /// 模块被停止的时候调用
        /// </summary>
        protected internal override void OnStop(IModuleManager t_IModuleManager)
        {
            m_ProcedureFSM.OnStop(this);
        }

        /// <summary>
        /// 模块被销毁前调用
        /// </summary>
        protected internal override void OnDestroy(IModuleManager t_IModuleManager)
        {
            m_ProcedureFSM.OnDestroy(this);
        }
        #endregion

    }
}