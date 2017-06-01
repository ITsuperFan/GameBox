/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBox
{
    /// <summary>
    /// 模块驱动管家组件
    /// </summary>
    public sealed class GameBoxDriver : BaseGameBoxComponent
    {

        protected override void Awake()
        {
            base.Awake();
            //驱动系统内置模块
            GameBoxEntry.GameBoxModuleManager.Init(UnityEngine.Time.deltaTime, UnityEngine.Time.unscaledDeltaTime);
        }

        private void OnEnable()
        {
            //驱动系统内置模块
            GameBoxEntry.GameBoxModuleManager.Start(UnityEngine.Time.deltaTime, UnityEngine.Time.unscaledDeltaTime);
        }

        private void Update()
        {
            //驱动系统内置模块
            GameBoxEntry.GameBoxModuleManager.Update(UnityEngine.Time.deltaTime, UnityEngine.Time.unscaledDeltaTime);
        }

        private void OnDisable()
        {
            //驱动系统内置模块
            GameBoxEntry.GameBoxModuleManager.Stop(UnityEngine.Time.deltaTime, UnityEngine.Time.unscaledDeltaTime);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            //驱动系统内置模块
            GameBoxEntry.GameBoxModuleManager.Destroy(UnityEngine.Time.deltaTime, UnityEngine.Time.unscaledDeltaTime);
        }




    }
}