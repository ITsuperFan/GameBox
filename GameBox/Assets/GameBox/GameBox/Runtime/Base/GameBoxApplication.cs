/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework;

namespace GameBox
{
    /// <summary>
    /// 应用程序实现类
    /// </summary>
	public sealed class GameBoxApplication : BaseApplication
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_Driver">驱动器实例</param>
        /// <param name="GameBoxComponentManager">组件管家</param>
        public GameBoxApplication(IModuleManager t_Driver, IComponentManager t_ComponentManager) 
        {
            Driver = t_Driver;
            ComponentManager = t_ComponentManager;
        }

    }
}
