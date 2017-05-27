/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework.Runtime.FSM;
using GameBoxFramework;

namespace GameBox.Runtime.Component
{
	public sealed class FSMManagerComponent : BaseGameBoxComponent
	{
        private IFSMManager m_IFSMManager = null;
        protected override void Awake()
        {
            base.Awake();

            m_IFSMManager = GameBoxEntry.GetBuiltInModule<IFSMManager>();
            if (null==m_IFSMManager)
            {
               throw new GameBoxFrameworkException("IFSMManager是无效的.");
            }
        }

        #region 组件功能

            public IFSM CreateFSM(string t_FSMName, params FSMState[] t_FSMStates)
            {
                return m_IFSMManager.CreateFSM(t_FSMName, t_FSMStates);
            }

            public IFSM GetFSM(string t_FSMName)
            {
                return m_IFSMManager.GetFSM(t_FSMName);
            }

            public IFSMManager RemoveFSM(string t_FSMName)
            {
                return m_IFSMManager.RemoveFSM(t_FSMName);
            }

        #endregion



    }
}