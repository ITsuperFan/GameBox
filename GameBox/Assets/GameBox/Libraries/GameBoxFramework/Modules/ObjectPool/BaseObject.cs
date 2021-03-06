﻿/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;

namespace GameBoxFramework.ObjectPool
{
    /// <summary>
    /// 对象基类。
    /// </summary>
    public abstract class BaseObject
    {
        private readonly string m_Name;
        private readonly object m_Target;
        private bool m_Locked;
        private int m_Priority;
        private DateTime m_LastUseTime;

        /// <summary>
        /// 初始化对象的新实例。
        /// </summary>
        /// <param name="target">对象。</param>
        public BaseObject(object target)
            : this(null, target, false, 0)
        {

        }

        /// <summary>
        /// 初始化对象的新实例。
        /// </summary>
        /// <param name="name">对象名称。</param>
        /// <param name="target">对象。</param>
        public BaseObject(string name, object target)
            : this(name, target, false, 0)
        {

        }

        /// <summary>
        /// 初始化对象的新实例。
        /// </summary>
        /// <param name="name">对象名称。</param>
        /// <param name="target">对象。</param>
        /// <param name="locked">对象是否被加锁。</param>
        public BaseObject(string name, object target, bool locked)
            : this(name, target, locked, 0)
        {

        }

        /// <summary>
        /// 初始化对象的新实例。
        /// </summary>
        /// <param name="name">对象名称。</param>
        /// <param name="target">对象。</param>
        /// <param name="priority">对象的优先级。</param>
        public BaseObject(string name, object target, int priority)
            : this(name, target, false, priority)
        {

        }

        /// <summary>
        /// 初始化对象的新实例。
        /// </summary>
        /// <param name="name">对象名称。</param>
        /// <param name="target">对象。</param>
        /// <param name="locked">对象是否被加锁。</param>
        /// <param name="priority">对象的优先级。</param>
        public BaseObject(string name, object target, bool locked, int priority)
        {
            if (target == null)
            {
                throw new GameBoxFrameworkException(string.Format("Target '{0}' is invalid.", name));
            }

            m_Name = name ?? string.Empty;
            m_Target = target;
            m_Locked = locked;
            m_Priority = priority;
            m_LastUseTime = DateTime.Now;
        }

        /// <summary>
        /// 获取对象名称。
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        /// <summary>
        /// 获取对象。
        /// </summary>
        public object Target
        {
            get
            {
                return m_Target;
            }
        }

        /// <summary>
        /// 获取或设置对象是否被加锁。
        /// </summary>
        public bool Locked
        {
            get
            {
                return m_Locked;
            }
            set
            {
                m_Locked = value;
            }
        }

        /// <summary>
        /// 获取或设置对象的优先级。
        /// </summary>
        public int Priority
        {
            get
            {
                return m_Priority;
            }
            set
            {
                m_Priority = value;
            }
        }

        /// <summary>
        /// 获取对象上次使用时间。
        /// </summary>
        public DateTime LastUseTime
        {
            get
            {
                return m_LastUseTime;
            }
            internal set
            {
                m_LastUseTime = value;
            }
        }

        /// <summary>
        /// 获取对象时的事件。
        /// </summary>
        protected internal virtual void OnSpawn()
        {

        }

        /// <summary>
        /// 回收对象时的事件。
        /// </summary>
        protected internal virtual void OnUnspawn()
        {

        }

        /// <summary>
        /// 释放对象。
        /// </summary>
        protected internal abstract void Release();
    }
}
