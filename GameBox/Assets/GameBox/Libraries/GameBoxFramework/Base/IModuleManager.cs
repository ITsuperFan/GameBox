/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework
{
    /// <summary>
    /// 模块管家接口
    /// </summary>
    public interface IModuleManager 
	{

        /// <summary>
        /// 管理的模块数量
        /// </summary>
        int ModulesCount { get; }
        /// <summary>
        /// 管理的所有模块的名字数组
        /// </summary>
        string[] ModuleNames { get; }
        /// <summary>
        /// 模块管家初始化
        /// </summary>
        void Init();
        /// <summary>
        /// 模块管家启动
        /// </summary>
        void Start();
        /// <summary>
        /// 模块管家轮询
        /// </summary>
        void Update();
        /// <summary>
        /// 模块管家停止
        /// </summary>
        void Stop();
        /// <summary>
        /// 模块管家销毁
        /// </summary>
        void Destroy();
        /// <summary>
        /// 获取管理的模块
        /// </summary>
        /// <typeparam name="T">模块的类型</typeparam>
        /// <returns>返回指定模块实例</returns>
        T GetModule<T>() where T:class;
    }
}