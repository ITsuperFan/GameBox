/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework;
using UnityEngine;

namespace GameBox
{
    /// <summary>
    /// GameBox入口类
    /// </summary>
	public sealed class GameBoxMain : MonoBehaviour 
	{
        #region GameBox生命周期
        //唤醒GameBox
        private void Awake()
        {
            GameBox.Inspector = new GameBoxInspector(); //平台自检
            GameBox.Bootstrap = new GameBoxBootstrap(); //启动引导
            GameBox.App = new GameBoxApplication(

                new GameBoxFrameworkModuleManager(new GameBoxFrameworkSLinkedList()), //GameBox层实现的驱动(模块管家)实例
                new GameBoxComponentManager(new ComponentManagerSLinkedList()) // GameBox层实现的组件管家实例

                ); //启动应用程序
            GameBox.App.OnInit(Time.deltaTime, Time.unscaledDeltaTime);//初始化程序

        }

        private void OnEnable()
        {
            //驱动应用程序内置模块
            GameBox.App.OnStart(Time.deltaTime,Time.unscaledDeltaTime);
        }

        private void Update()
        {
            //驱动应用程序内置模块
            GameBox.App.OnUpdate(Time.deltaTime, Time.unscaledDeltaTime);
        }

        private void OnDisable()
        {
            //驱动应用程序内置模块
            GameBox.App.OnStop(Time.deltaTime, Time.unscaledDeltaTime);
        }

        private void OnDestroy()
        {
            //驱动应用程序内置模块
            GameBox.App.OnDestroy(Time.deltaTime, Time.unscaledDeltaTime);
        }
        #endregion
    }
}
