/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBoxFramework
{
    /// <summary>
    /// 抽象基础应用程序类
    /// </summary>
	public abstract class BaseApplication
	{
        public IModuleManager Driver { get; protected internal set; }

        public BaseApplication(IModuleManager t_Driver)
        {
            Driver = t_Driver;
        }
        #region 程序生命周期
        /// <summary>
        /// 程序被初始化
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界一帧的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界一帧的流逝时间</param>
        public virtual void OnInit(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的初始化工作
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            Driver.Init();
        }
        /// <summary>
        /// 程序被启动
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界一帧的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界一帧的流逝时间</param>
        public virtual void OnStart(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被启动的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            Driver.Start();
        }
        /// <summary>
        /// 程序被轮训
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界一帧的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界一帧的流逝时间</param>
        public virtual void OnUpdate(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被轮询的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            Driver.Update();
        }
        /// <summary>
        /// 程序被停止
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界一帧的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界一帧的流逝时间</param>
        public virtual void OnStop(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被停止的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            Driver.Stop();
        }
        /// <summary>
        /// 程序被销毁
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界一帧的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界一帧的流逝时间</param>
        public virtual void OnDestroy(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被销毁的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            Driver.Destroy();
        }
        #endregion


    }
}
