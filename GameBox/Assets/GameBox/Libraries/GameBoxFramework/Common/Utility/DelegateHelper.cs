/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace GameBoxFramework
{
    /// <summary>
    /// 委托助手
    /// </summary>
    public class DelegateHelper 
	{
        /// <summary>
        /// 将反射获取到的MethodInfo转变成委托
        /// </summary>
        /// <param name="t_MethodInfo">方法信息类</param>
        /// <param name="t_Target">源目标类</param>
        /// <returns></returns>
        public static Delegate CreateDelegate(MethodInfo t_MethodInfo, object t_Target)
        {
            if (t_MethodInfo == null)
                throw new GameBoxFrameworkException("MethodInfo类型参数为空!");
            Type delegateType;
            var typeArgs = t_MethodInfo.GetParameters().Select(p => p.ParameterType).ToList();
            // 创建一个Delegate类型   
            if (t_MethodInfo.ReturnType == typeof(void))
            {
                delegateType = Expression.GetActionType(typeArgs.ToArray());
            }
            else
            {
                typeArgs.Add(t_MethodInfo.ReturnType);
                delegateType = Expression.GetFuncType(typeArgs.ToArray());
            }
            // 创建一个Delegate类型，如果目标是可支持的
            var result = (t_Target == null) ?
                Delegate.CreateDelegate(delegateType, t_MethodInfo) :
                Delegate.CreateDelegate(delegateType, t_Target, t_MethodInfo);

            return result;
        }

    }
}