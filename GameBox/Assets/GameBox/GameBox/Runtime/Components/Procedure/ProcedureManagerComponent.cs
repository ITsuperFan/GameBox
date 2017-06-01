/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;
using GameBoxFramework;
using GameBoxFramework.Runtime.Procedure;
using UnityEngine;

namespace GameBox.Runtime.Component
{ 
    /// <summary>
    /// 流程管家组件
    /// </summary>
	public sealed class ProcedureManagerComponent : BaseGameBoxComponent
    {

        [SerializeField]
        private string[] m_AvailableProcedureTypeNames = null;

        [SerializeField]
        private string m_BootProcedureTypeName = null;



        /// <summary>
        /// 流程管家接口
        /// </summary>
        private IProcedureManager m_IProcedureManager;
        public BaseProcedure CurrentProcedure { get; set; }

        public BaseProcedure BootProcedure { get; set; }

        public BaseProcedure[] Procedures { get { return null==m_IProcedureManager?null:m_IProcedureManager.Procedures; } }

        public void AddProcedure<T>() where T : BaseProcedure
        {
            if (null!= m_IProcedureManager)
            {
                m_IProcedureManager.AddProcedure<T>();
            }
        }

        public void RemoveProcedure<T>() where T : BaseProcedure
        {
            if (null != m_IProcedureManager)
            {
                m_IProcedureManager.RemoveProcedure<T>();
            }
        }

        protected override void Awake()
        {
            base.Awake();

            m_IProcedureManager = GameBoxEntry.GetBuiltInModule<IProcedureManager>();
            if (null==m_IProcedureManager)
            {
                throw new GameBoxFrameworkException("IProcedureManager是无效的.");
            }

            for (int i = 0; i < m_AvailableProcedureTypeNames.Length; i++)
            {
                m_IProcedureManager.AddProcedure(Type.GetType(m_AvailableProcedureTypeNames[i]));
            }
            
            m_IProcedureManager.BootProcedure = m_IProcedureManager.GetProcedure(Type.GetType(m_BootProcedureTypeName));
        }

      


    }
}