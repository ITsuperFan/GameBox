/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework
{
    /// <summary>
    /// GameBoxFramework基础模块
    /// </summary>
    public abstract class BaseGameBoxFrameworkModule 
	{


        /// <summary>
        /// 模块的权值
        /// </summary>
        internal int Weight { get; set; }

        /// <summary>
        /// 模块初始化的时候调用
        /// </summary>
        protected abstract void OnInit(IModuleManager t_IModuleManager);

        /// <summary>
        /// 模块被启动的时候调用
        /// </summary>
        protected abstract void OnStart(IModuleManager t_IModuleManager);

        /// <summary>
        /// 模块被轮询的时候调用
        /// </summary>
        protected abstract void OnUpdate(IModuleManager t_IModuleManager);

        /// <summary>
        /// 模块被停止的时候调用
        /// </summary>
        protected abstract void OnStop(IModuleManager t_IModuleManager);

        /// <summary>
        /// 模块被销毁前调用
        /// </summary>
        protected abstract void OnDestroy(IModuleManager t_IModuleManager);


    }
}