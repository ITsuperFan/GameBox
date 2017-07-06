/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework;
using System;
using GameBox.Runtime.Component;

namespace GameBox
{
    /// <summary>
    ///  GameBox使用类
    /// </summary>
	public static partial class GameBox 
	{
        #region Components

        public static UIEventComponent UIEventComponent { get; private set; }
        public static ActiveEventComponent ActiveEventComponent { get; private set; }
        public static EventBrokerComponent EventBrokerComponent { get; private set; }
        public static FSMComponent FSMComponent { get; private set; }
        public static HttpComponent HttpComponent { get; private set; }
        public static ModelComponent ModelComponent { get; private set; }
        public static MonoFSMComponent MonoFSMComponent { get; private set; }
        public static NetworkComponent NetworkComponent { get; private set; }
        public static ObjectPoolComponent ObjectPoolComponent { get; private set; }
        public static ProcedureComponent ProcedureComponent { get; private set; }
        public static RouteComponent RouteComponent { get; private set; }
        public static SceneComponent SceneComponent { get; private set; }

        #endregion


        #region API

        /// <summary>
        /// 获取系统内置模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetBuiltInModule<T>() where T : class
            {
                return null == App ? default(T) : App.Driver.GetModule<T>();
            }

            /// <summary>
            /// 获取GameBox扩展组件
            /// </summary>
            /// <typeparam name="T">GameBox组件类型</typeparam>
            /// <returns>返回指定组件类型的搜索第一个实例</returns>
            public static T GetComponent<T>() where T : IComponent
            {
                return null==App?default(T):App.ComponentManager.GetComponent<T>();
            }

            /// <summary>
            /// 获取GameBox扩展组件数组
            /// </summary>
            /// <typeparam name="T">GameBox组件类型</typeparam>
            /// <returns>返回指定组件类型的搜索所有实例</returns>
            public static T[] GetComponents<T>() where T : IComponent
            {
                return null == App ? null : App.ComponentManager.GetComponents<T>();
            }

            /// <summary>
            /// 路由
            /// </summary>
            /// <param name="t_Action">路由动作</param>
            /// <param name="t_Request">路由请求</param>
            /// <param name="t_Handler">路由响应回调</param>
            public static void Route(string t_Action, BaseEventArgs t_Request = null, Action<object> t_Handler = null)
            {
                if (null != RouteComponent)
                    RouteComponent.Route(t_Action,t_Request,t_Handler);
                else
                    RouteComponent = GetComponent<RouteComponent>();
            }

        #endregion

    }
}
