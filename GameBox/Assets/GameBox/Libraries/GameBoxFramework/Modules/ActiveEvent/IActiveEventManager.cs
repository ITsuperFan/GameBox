/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Collections.Generic;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// 有效事件模块接口
    /// </summary>
	public interface IActiveEventManager
    {
        /// <summary>
        /// 有效事件的数目
        /// </summary>
        int ActiveEventCount { get;}

        /// <summary>
        /// 获取所有有效事件的名称
        /// </summary>
        string[] ActiveEventNames { get;}

        /// <summary>
        /// 加载有效事件的对应程序集
        /// </summary>
        /// <param name="FullNamespace"></param>
        void LoadActiveEventAssembly(string t_FullNamespace);

        /// <summary>
        /// 调用有效事件
        /// </summary>
        /// <param name="t_ActiveEventName">有效事件注册的时候对应的索引名字</param>
        /// <param name="t_Params">方法执行的参数</param>
        /// <returns></returns>
        List<ActiveEventResult> CallActiveEvent(string t_ActiveEventName,params object[] t_Params);

        /// <summary>
        /// 销毁有效事件
        /// </summary>
        /// <param name="t_ActiveEventName"></param>
        void DestroyActiveEvent(string t_ActiveEventName);

    }
}
