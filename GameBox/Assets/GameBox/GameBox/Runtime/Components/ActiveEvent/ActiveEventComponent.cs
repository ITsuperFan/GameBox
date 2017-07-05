/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework;
using GameBoxFramework.Event;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// 有效事件
    /// </summary>
    //[DisallowMultipleComponent]
    [AddComponentMenu("GameBox/ActiveEvent")]
    public sealed class ActiveEventComponent : BaseGameBoxComponent
    {
        private IActiveEventManager m_ActiveEventManager  = null;

        /// <summary>
        /// 获取有效事件的数量
        /// </summary>
        public int ActiveEventCount
        {
            get
            {
                return null==m_ActiveEventManager?0: m_ActiveEventManager.ActiveEventCount;
            }
        }

        /// <summary>
        /// 获取所有有效事件的名字
        /// </summary>
        public string[] ActiveEventNames
        {
            get
            {
                return m_ActiveEventManager.ActiveEventNames;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            m_ActiveEventManager = GameBox.App.Driver.GetModule<IActiveEventManager>();

            if (m_ActiveEventManager == null)
            {
                throw new GameBoxFrameworkException("IActiveEventManager是无效的.");
            }
        }

        /// <summary>
        /// 加载有效事件程序集
        /// </summary>
        /// <param name="t_FullNamespace">装载的程序集路径</param>
        public void LoadActiveEventAssembly(string t_FullNamespace)
        {
            m_ActiveEventManager.LoadActiveEventAssembly(t_FullNamespace); 
        }

        /// <summary>
        /// 加载有效事件程序集
        /// </summary>
        /// <typeparam name="T">有效事件类型</typeparam>
        public void LoadActiveEventAssembly<T>()
        {
            m_ActiveEventManager.LoadActiveEventAssembly(typeof(T).FullName);
        }

        /// <summary>
        /// 加载有效事件程序集
        /// </summary>
        /// <param name="t_Type">注册了有效事件类的Type类型</param>
        public void LoadActiveEventAssembly(Type t_Type)
        {
            m_ActiveEventManager.LoadActiveEventAssembly(t_Type.FullName);
        }

        /// <summary>
        /// 调用有效事件
        /// </summary>
        /// <param name="t_ActiveEventName">有效事件的名字</param>
        /// <param name="t_Params">有效事件的参数</param>
        /// <returns>返回结果集</returns>
        public List<ActiveEventResult> CallActiveEvent(string t_ActiveEventName, params object[] t_Params)
        {
            return m_ActiveEventManager.CallActiveEvent(t_ActiveEventName, t_Params);
        }

        /// <summary>
        /// 销毁有效事件
        /// </summary>
        /// <param name="t_ActiveEventName"></param>
        public void DestroyActiveEvent(string t_ActiveEventName)
        {
            m_ActiveEventManager.DestroyActiveEvent(t_ActiveEventName);
        }


    }
}
