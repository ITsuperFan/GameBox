/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using GameBoxFramework.Utility;
using System;
using System.Reflection;

namespace GameBoxFramework.Route
{
    /// <summary>
    /// 路由管家
    /// </summary>
	internal sealed class RouteManager : BaseModule, IRouteManager
    {
        private readonly RouteTrieMap<string, Delegate> m_RouteTrieMap = new RouteTrieMap<string, Delegate>();

        private const string m_RouteSeparator = "@";

        #region 私有方法
                /// <summary>
                /// 注册路由
                /// </summary>
                /// <param name="t_Action"></param>
                /// <param name="t_Delegate"></param>
                private void RegisterRoute(string t_Action , Delegate t_Delegate)
                {
                    if (!m_RouteTrieMap.ContainsKey(t_Action))
                    {
                        m_RouteTrieMap.Add(t_Action,t_Delegate);
                    }
                }

                private void RegisterRoute(string t_TypeName, object t_Target)
                {
                    var t_Type = t_Target.GetType();
                    var t_TypeCustomAttributes = t_Type.GetCustomAttributes(false);
                    for (int i = 0; i < t_TypeCustomAttributes.Length; i++)
                    {
                        if (t_TypeCustomAttributes[i] is RouteInvalidAttribute) return; //如果这个类也标记了无效路由，那么将直接退出，不反射它
                    }

                    var t_Methods = t_Type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public| BindingFlags.DeclaredOnly);
                    for (int i = 0; i < t_Methods.Length; i++)
                    {
                        var t_MethodCustomAttributes = t_Methods[i].GetCustomAttributes(false);
                        bool t_IsRouteInvalidA=false;
                        for (int j = 0; j < t_MethodCustomAttributes.Length; j++)
                        {
                            if (t_MethodCustomAttributes[j] is RouteInvalidAttribute)
                            {
                                t_IsRouteInvalidA = true;
                                break; //如果标记了无效路由，那么就不注册此记录
                            } 
                        }

                if (!t_IsRouteInvalidA) //如果没有无效路由标记 ， 那么添加此路由记录
                {
                    //UnityEngine.Debug.Log(t_TypeName + m_RouteSeparator + t_Methods[i].Name);
                    RegisterRoute(t_TypeName + m_RouteSeparator + t_Methods[i].Name, DelegateHelper.CreateDelegate(t_Methods[i], t_Target));
                }


            }
                }

                #endregion

        #region 公开方法
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="t_Type">目标类型</param>
        public void RegisterRoute(Type t_Type)
        {
            RegisterRoute(t_Type.Name, Activator.CreateInstance(t_Type));
        }

        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="t_Target">目标类实例</param>
        public void RegisterRoute(object t_Target)
        {
            RegisterRoute(t_Target.GetType().Name, t_Target);
        }
        /// <summary>
        /// 路由
        /// </summary>
        /// <param name="t_Action">路由动作</param>
        /// <param name="t_Request">路由请求</param>
        /// <param name="t_Handler">路由响应回调</param>
        public void Route(string t_Action, BaseEventArgs t_Request = null, Action<object> t_Handler = null)
        {
            if (m_RouteTrieMap.ContainsKey(t_Action))
            {
                Delegate t_Delegate;
                m_RouteTrieMap.TryGetValue(t_Action,out t_Delegate);
                var t_Parameters = t_Delegate.Method.GetParameters();
                if (null != t_Delegate)
                if (1== t_Parameters.Length)
                {
                        if (null != t_Handler)
                        {
                            t_Handler(t_Delegate.DynamicInvoke(t_Request));
                        }
                        else
                        {
                            t_Delegate.DynamicInvoke(t_Request);
                        }
                }
                else
                {
                        if (null != t_Handler)
                        {
                            t_Handler(t_Delegate.DynamicInvoke());
                        }
                        else
                        {
                            t_Delegate.DynamicInvoke();
                        }
                    }
                
            }

        }
        #endregion


        #region 模块生命周期

        protected internal override void OnInit(IModuleManager t_IModuleManager)
        {
            var t_TypeFullNames =  TypeHelper.GetTypeFullNames<BaseController>();
            for (int i = 0; i < t_TypeFullNames.Length; i++)
            {
                RegisterRoute(Type.GetType(t_TypeFullNames[i]));
            }
        }

        protected internal override void OnStart(IModuleManager t_IModuleManager)
        {
           
        }

        protected internal override void OnUpdate(IModuleManager t_IModuleManager)
        {
            
        }

        protected internal override void OnStop(IModuleManager t_IModuleManager)
        {
            
        }

        protected internal override void OnDestroy(IModuleManager t_IModuleManager)
        {
            
        }

        #endregion
    }
}
