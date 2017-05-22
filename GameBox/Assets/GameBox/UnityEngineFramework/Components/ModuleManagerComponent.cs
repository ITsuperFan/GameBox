/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework;

namespace UnityEngineFramework.Runtime.Component
{
    public sealed class ModuleManagerComponent : BaseGameBoxComponent
    {
        private IModuleManager m_IModuleManager;
        private void Awake()
        {

            m_IModuleManager = new GameBoxFrameworkModuleManager();

        }

        private void Update()
        {

            m_IModuleManager.Update(UnityEngine.Time.deltaTime, UnityEngine.Time.unscaledDeltaTime);

        }

    }
}