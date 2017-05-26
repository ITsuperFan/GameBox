/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBox.Runtime.Component
{
    /// <summary>
    /// 模块驱动管家组件
    /// </summary>
    public sealed class ModuleManagerComponent : BaseGameBoxComponent
    {
        private void Update()
        {
            //驱动系统内置模块
            GameBoxEntry.GameBoxModuleManager.Update(UnityEngine.Time.deltaTime, UnityEngine.Time.unscaledDeltaTime);
        }

    }
}