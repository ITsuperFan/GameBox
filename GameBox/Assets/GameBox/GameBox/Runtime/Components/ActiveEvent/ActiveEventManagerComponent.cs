/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Collections.Generic;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// 有效事件管家
    /// </summary>
    public sealed class ActiveEventManagerComponent : BaseGameBoxComponent
    {
        private IActiveEventManager m_ActiveEventManager  = null;

        public int ActiveEventCount
        {
            get
            {
                return null==m_ActiveEventManager?0: m_ActiveEventManager.ActiveEventCount;
            }
        }

        public string[] ActiveEventNames
        {
            get
            {
                return m_ActiveEventManager.ActiveEventNames;
            }
        }

        protected override void Awake()
        {
          
            if (m_ActiveEventManager == null)
            {
                return;
            }
        }

        public void LoadActiveEventAssembly(string t_FullNamespace)
        {
            m_ActiveEventManager.LoadActiveEventAssembly(t_FullNamespace); 
        }

        public void LoadActiveEventAssembly<T>()
        {
            m_ActiveEventManager.LoadActiveEventAssembly(typeof(T).FullName);
        }

        public List<ActiveEventResult> CallActiveEvent(string t_ActiveEventName, params object[] t_Params)
        {
            return m_ActiveEventManager.CallActiveEvent(t_ActiveEventName, t_Params);
        }

        public void DestroyActiveEvent(string t_ActiveEventName)
        {
            m_ActiveEventManager.DestroyActiveEvent(t_ActiveEventName);
        }

    
    }
}
