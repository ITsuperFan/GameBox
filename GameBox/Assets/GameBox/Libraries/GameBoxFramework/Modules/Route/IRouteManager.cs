/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;

namespace GameBoxFramework.Route
{
    /// <summary>
    /// 路由管家接口
    /// </summary>
	public interface IRouteManager 
	{
        /// <summary>
        /// 路由
        /// </summary>
        /// <param name="t_Action">路由动作</param>
        /// <param name="t_Request">路由请求</param>
        /// <param name="t_Handler">路由响应回调</param>
        void Route(string t_Action,BaseEventArgs t_Request= null,Action<object> t_Handler=null); //Route("GameController@Play",response=>{   });

        /// <summary>
        /// 注册某个类型的有效路由
        /// </summary>
        /// <param name="t_Action"></param>
        /// <param name="t_Type"></param>
        void RegisterRoute(Type t_Type);
        void RegisterRoute(object t_Target);
    }
}
