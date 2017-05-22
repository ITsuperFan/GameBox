/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework;

namespace GameBox
{
    public static class GameBoxEntry
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public static string Version = "2.0";

        /// <summary>
        /// 内建模块管家
        /// </summary>
        public static readonly IModuleManager GameBoxModuleManager = new GameBoxFrameworkModuleManager();

        /// <summary>
        /// 获取系统内置模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetBuiltInModule<T>() where T : class
        {
            return GameBoxModuleManager.GetModule<T>();
        }





    }
}