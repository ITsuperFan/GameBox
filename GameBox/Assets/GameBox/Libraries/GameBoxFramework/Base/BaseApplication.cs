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
        /// <summary>
        /// 模块驱动接口
        /// </summary>
        public IModuleManager Driver { get; protected set; }
        /// <summary>
        /// 游戏扩展组件管家
        /// </summary>
        public IComponentManager ComponentManager { get; protected set; }

        //public BaseApplication() { }

        ///// <summary>
        ///// 构造方法
        ///// </summary>
        ///// <param name="t_Driver"></param>
        //public BaseApplication(IModuleManager t_Driver, IComponentManager t_ComponentManager)
        //{
        //    UnityEngine.Debug.Log("2");
        //    Driver = t_Driver;
        //    ComponentManager = t_ComponentManager;
        //}

        #region 程序事件

        /// <summary>
        /// 驱动前事件
        /// </summary>
        public virtual void OnDrivingBefore() { }

        /// <summary>
        /// 驱动启动事件
        /// </summary>
        public virtual void OnDrivingStart() { }

        /// <summary>
        /// 正在驱动事件
        /// </summary>
        public virtual void OnDrivingUpdate() { }

        /// <summary>
        /// 驱动结束事件
        /// </summary>
        public virtual void OnDrivingEnd() { }


        #endregion

        #region 程序生命周期事件
        /// <summary>
        /// 程序被初始化事件
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界一帧的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界一帧的流逝时间</param>
        public virtual void OnInit(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {

            //TODO: 模块管家的初始化工作
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;
            OnDrivingBefore();
            Driver.Init();
        }
        /// <summary>
        /// 程序被启动事件
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界一帧的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界一帧的流逝时间</param>
        public virtual void OnStart(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被启动的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;
            OnDrivingStart();
            Driver.Start();
        }
        /// <summary>
        /// 程序被轮训事件
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界一帧的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界一帧的流逝时间</param>
        public virtual void OnUpdate(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被轮询的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            Driver.Update();
            OnDrivingUpdate();
        }
        /// <summary>
        /// 程序被停止事件
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
        /// 程序被销毁事件
        /// </summary>
        /// <param name="t_GameWorldElapsedTime">游戏世界一帧的流逝时间</param>
        /// <param name="t_RealWorldElapsedTime">真实世界一帧的流逝时间</param>
        public virtual void OnDestroy(float t_GameWorldElapsedTime, float t_RealWorldElapsedTime)
        {
            //TODO: 模块管家的被销毁的时候
            GameBoxFrameworkTime.GameWorldElapsedTime = t_GameWorldElapsedTime;
            GameBoxFrameworkTime.RealWorldElapsedTime = t_RealWorldElapsedTime;

            Driver.Destroy();
            OnDrivingEnd();
        }
        #endregion


    }
}
