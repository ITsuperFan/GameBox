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
    ///  GameBox使用类
    /// </summary>
	public static class GameBox 
	{
        /// <summary>
        /// 版本号
        /// </summary>
        public static string Version = "2.1";

        /// <summary>
        /// GameBox自检实例
        /// </summary>
        public static BaseInspector Inspector { get; internal set; }

        /// <summary>
        /// GameBox引导实例
        /// </summary>
        public static BaseBootstrap Bootstrap { get; internal set; }

        /// <summary>
        /// GameBox应用程序实例
        /// </summary>
        public static BaseApplication App { get; internal set; }
       
            
        #region API

        /// <summary>
        /// 获取系统内置模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetBuiltInModule<T>() where T : class
        {
            return App.Driver.GetModule<T>();
        }

        /// <summary>
        /// 获取GameBox扩展组件
        /// </summary>
        /// <typeparam name="T">GameBox组件类型</typeparam>
        /// <returns>返回指定组件类型的搜索第一个实例</returns>
        public static T GetComponent<T>() where T : IComponent
        {
            return App.ComponentManager.GetComponent<T>();
        }

        /// <summary>
        /// 获取GameBox扩展组件数组
        /// </summary>
        /// <typeparam name="T">GameBox组件类型</typeparam>
        /// <returns>返回指定组件类型的搜索所有实例</returns>
        public static T[] GetComponents<T>() where T : IComponent
        {
            return App.ComponentManager.GetComponents<T>();
        }

        #endregion

    }
}
