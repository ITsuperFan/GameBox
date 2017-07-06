/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using GameBoxFramework;
using GameBoxFramework.Route;
using System;
using UnityEngine;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// 路由组件
    /// </summary>
    [AddComponentMenu("GameBox/Route")]
    public sealed class RouteComponent : BaseGameBoxComponent
    {

        /// <summary>
        /// 流程管家接口
        /// </summary>
        private IRouteManager m_IRouteManager;

        /// <summary>
        /// 路由数目
        /// </summary>
        public int RoutesCount
        {
            get
            {
                return null == m_IRouteManager ? 0 : m_IRouteManager.RoutesCount;
            }
        }

        /// <summary>
        /// 路由数组
        /// </summary>
        public string[] RouteNames { get { return null == m_IRouteManager ? null : m_IRouteManager.RouteNames; } }

        /// <summary>
        /// 路由
        /// </summary>
        /// <param name="t_Action">路由动作</param>
        /// <param name="t_Request">路由请求</param>
        /// <param name="t_Handler">路由响应回调</param>
        public void Route(string t_Action, BaseEventArgs t_Request = null, Action<object> t_Handler = null)
        {
            m_IRouteManager.Route(t_Action,t_Request,t_Handler);
        }

        //初始化组件
        protected override void Awake()
        {
            base.Awake();

            m_IRouteManager = GameBox.App.Driver.GetModule<IRouteManager>();
            if (null== m_IRouteManager)
            {
                throw new GameBoxFrameworkException("IRouteManager是无效的.");
            }

        }

      


    }
}