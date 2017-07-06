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
	public static partial class GameBox 
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

    }
}
