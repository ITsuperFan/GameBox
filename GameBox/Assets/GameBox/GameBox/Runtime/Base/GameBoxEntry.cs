/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework;
using System;

namespace GameBox
{
    public static class GameBoxEntry
    {
        /// <summary>
        /// 静态构造方法
        /// </summary>
        static GameBoxEntry()
        {
            GameBoxComponentManager.ComponentRegisteredEventHandler += e => { if (null != ComponentRegisteredEventHandler) ComponentRegisteredEventHandler(e); };
            GameBoxComponentManager.ComponentDestroyedEventHandler += e => { if (null != ComponentDestroyedEventHandler) ComponentDestroyedEventHandler(e); };
        }


        /// <summary>
        /// 版本号
        /// </summary>
        public static string Version = "2.0";

        /// <summary>
        /// 内建模块管家
        /// </summary>
        public static readonly IModuleManager GameBoxModuleManager = new GameBoxFrameworkModuleManager();

        /// <summary>
        /// 游戏扩展组件管家
        /// </summary>
        public static readonly IComponentManager GameBoxComponentManager = new GameBoxComponentManager();


        /// <summary>
        /// 组件被注册事件
        /// </summary>
        public static event Action<ComponentRegisteredEventArgs> ComponentRegisteredEventHandler;

        /// <summary>
        /// 组件被销毁事件
        /// </summary>
        public static event Action<ComponentDestroyedEventArgs> ComponentDestroyedEventHandler;



        /// <summary>
        /// 获取系统内置模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetBuiltInModule<T>() where T : class
        {
            return GameBoxModuleManager.GetModule<T>();
        }

        /// <summary>
        /// 获取GameBox扩展组件
        /// </summary>
        /// <typeparam name="T">GameBox组件类型</typeparam>
        /// <returns>返回指定组件类型的搜索第一个实例</returns>
        public static T GetComponent<T>() where T : BaseGameBoxComponent
        {
            return GameBoxComponentManager.GetComponent<T>();
        }

        /// <summary>
        /// 获取GameBox扩展组件数组
        /// </summary>
        /// <typeparam name="T">GameBox组件类型</typeparam>
        /// <returns>返回指定组件类型的搜索所有实例</returns>
        public static T[] GetComponents<T>() where T : BaseGameBoxComponent
        {
            return GameBoxComponentManager.GetComponents<T>();
        }
       
        /// <summary>
        /// 注册GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        public static void RegisterComponent(BaseGameBoxComponent t_BaseGameBoxComponent)
        {         
            GameBoxComponentManager.RegisterComponent(t_BaseGameBoxComponent);
        }

        /// <summary>
        /// 销毁指定的所有GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        public static void DestroyComponent(BaseGameBoxComponent t_BaseGameBoxComponent)
        {
            GameBoxComponentManager.DestroyComponent(t_BaseGameBoxComponent);
        }

    }



}