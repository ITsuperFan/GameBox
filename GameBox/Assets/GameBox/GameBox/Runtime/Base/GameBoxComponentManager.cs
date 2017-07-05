/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using GameBoxFramework;
using System.Collections.Generic;
using System;

namespace GameBox
{
    public sealed class GameBoxComponentManager : BaseComponentManager, IComponentManager
    {

        /// <summary>
        /// 组件被注册事件
        /// </summary>
        public event EventHandler<ComponentRegisteredEventArgs> ComponentRegisteredEventHandler;   
        /// <summary>
        /// 组件被销毁事件
        /// </summary>
        public event EventHandler<ComponentDestroyedEventArgs> ComponentDestroyedEventHandler;
        /// <summary>
        /// 管理的模块数量
        /// </summary>
        public int ComponentsCount { get { return IListDataStructure.NodeCount; }}
        /// <summary>
        /// 管理的所有模块的名字数组
        /// </summary>
        public string[] ComponentNames { get {

                var t_ComponentArray = IListDataStructure.ToArray();
                string[] t_Components = new string[t_ComponentArray.Length];
                for (int i = 0; i < t_ComponentArray.Length; i++)
                {
                    t_Components[i] = t_ComponentArray[i].GetType().Name;
                }
                return 0 < t_ComponentArray.Length ? t_Components : null;
            } }
        /// <summary>
        /// 初始化数据结构类型的构造方法
        /// </summary>
        /// <param name="t_IListDataStructure"></param>
        public GameBoxComponentManager(IListDataStructure<IComponent> t_IListDataStructure):base(t_IListDataStructure)
        {

        }

        /// <summary>
        /// 获取GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        public T GetComponent<T>() where T:IComponent
        {
            var t_ComponentArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_ComponentArray.Length; i++)
            {
                if (t_ComponentArray[i] is T)
                {
                    t_ComponentArray[i].Weight++;
                    return (T)t_ComponentArray[i];
                }
            }
            IListDataStructure.Sort();
            return default(T);
        }

        /// <summary>
        /// 获取注册GameBox的组件数组
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        public  T[] GetComponents<T>() where T : IComponent
        {
            List<T> t_Components = new List<T>();
            var t_ComponentArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_ComponentArray.Length; i++)
            {
                if (t_ComponentArray[i] is T)
                {
                    t_Components.Add((T)t_ComponentArray[i]);
                }
            }
            IListDataStructure.Sort();
            return 0 < t_Components.Count ? t_Components.ToArray():null;
        }

        /// <summary>
        /// 注册GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        public void RegisterComponent(IComponent t_BaseGameBoxComponent)
        {         
            if (!IListDataStructure.Contains(t_BaseGameBoxComponent))
            {
                if (null!=ComponentRegisteredEventHandler)
                {
                    ComponentRegisteredEventHandler(this,new ComponentRegisteredEventArgs() { Component = t_BaseGameBoxComponent });
                }
                IListDataStructure.AddNode(t_BaseGameBoxComponent);
            }
        }

        /// <summary>
        /// 销毁指定的GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        public void DestroyComponent(IComponent t_BaseGameBoxComponent)
        {
            if (!IListDataStructure.Contains(t_BaseGameBoxComponent))
            {
                if (null != ComponentDestroyedEventHandler)
                {
                    ComponentDestroyedEventHandler(this,new ComponentDestroyedEventArgs() { Component = t_BaseGameBoxComponent });
                }
                IListDataStructure.RemoveNode(component => component.Equals(t_BaseGameBoxComponent));
            }
            IListDataStructure.Sort();
        }

        /// <summary>
        /// 销毁所有的GameBox的组件
        /// </summary>
        /// <typeparam name="T">GameBox的组件类型</typeparam>
        /// <returns>返回GamBox的组件</returns>
        public  void DestroyComponents<T>() where T : IComponent
        {
            var t_ComponentArray = IListDataStructure.ToArray();
            for (int i = 0; i < t_ComponentArray.Length; i++)
            {
                if (t_ComponentArray[i] is T)
                {
                    IListDataStructure.RemoveNode(component => component.Equals(t_ComponentArray[i]));
                }
            }
        }
    }
}
