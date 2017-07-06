/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/
using System;

namespace GameBoxFramework
{
	public interface IComponentManager
    {
        /// <summary>
        /// 组件被注册事件
        /// </summary>
        event EventHandler<ComponentRegisteredEventArgs> ComponentRegisteredEventHandler;

        /// <summary>
        /// 组件被销毁事件
        /// </summary>
        event EventHandler<ComponentDestroyedEventArgs> ComponentDestroyedEventHandler;

        /// <summary>
        /// 管理的模块数量
        /// </summary>
        int ComponentsCount { get; }

        /// <summary>
        /// 管理的所有模块的名字数组
        /// </summary>
        string[] ComponentNames { get; }

        /// <summary>
        /// 获取GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        T GetComponent<T>()where T:IComponent;

        /// <summary>
        /// 获取GameBox的组件数组
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件数组</returns>
        T[] GetComponents<T>() where T : IComponent;

        /// <summary>
        /// 注册GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        void RegisterComponent(IComponent t_BaseGameBoxComponent);

        /// <summary>
        /// 销毁指定的所有GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        void DestroyComponents<T>() where T : IComponent;

        /// <summary>
        /// 销毁指定的GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        void DestroyComponent(IComponent t_BaseGameBoxComponent);
    }

}