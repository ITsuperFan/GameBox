/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using System.Collections.Generic;

namespace GameBoxFramework
{
    /// <summary>
    /// 获取模块管家
    /// </summary>
    public abstract class BaseGameBoxFrameworkModuleManager : IModuleManager
    {

        /// <summary>
        /// 抽象数据结构类型
        /// </summary>
        protected abstract IListDataStructure IListDataStructure { get; set; }
        /// <summary>
        /// 游戏世界的流逝时间
        /// </summary>
        public float GameWorldElapsedTime { get; protected set; }
        /// <summary>
        /// 真实世界的流逝时间
        /// </summary>
        public float RealWorldElapsedTime { get; protected set; }
        /// <summary>
        /// 管理的模块数量
        /// </summary>
        public int ModulesCount { get; protected set; }
        /// <summary>
        /// 管理的所有模块的名字数组
        /// </summary>
        public string[] ModuleNames { get; protected set; }
        /// <summary>
        /// 获取管理的模块
        /// </summary>
        /// <typeparam name="T">模块的类型</typeparam>
        /// <returns>返回指定模块实例</returns>
        public abstract T GetModule<T>() where T : class;
        /// <summary>
        /// 模块管家初始化
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public abstract void Init(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);
        /// <summary>
        /// 模块管家启动
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public abstract void Start(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);
        /// <summary>
        /// 模块管家轮询
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public abstract void Update(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);
        /// <summary>
        /// 模块管家停止
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public abstract void Stop(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);
        /// <summary>
        /// 模块管家销毁
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界的流逝时间</param>
        public abstract void Destroy(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime);

    }
}