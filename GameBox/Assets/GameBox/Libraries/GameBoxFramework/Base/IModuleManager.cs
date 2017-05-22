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
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        void Init(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);
        /// <summary>
        /// 模块管家启动
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        void Start(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);
        /// <summary>
        /// 模块管家轮询
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        void Update(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);
        /// <summary>
        /// 模块管家停止
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        void Stop(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);
        /// <summary>
        /// 模块管家销毁
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        void Destroy(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);
        /// <summary>
        /// 获取管理的模块
        /// </summary>
        /// <typeparam name="T">模块的类型</typeparam>
        /// <returns>返回指定模块实例</returns>
        T GetModule<T>() where T : class;
    }
}