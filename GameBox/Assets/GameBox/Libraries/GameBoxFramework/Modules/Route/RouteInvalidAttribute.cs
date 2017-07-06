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
    /// 无效路由标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class RouteInvalidAttribute : BaseAttribute
    {

        public RouteInvalidAttribute() { }

    }
}