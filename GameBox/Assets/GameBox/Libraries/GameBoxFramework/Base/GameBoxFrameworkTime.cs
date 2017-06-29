/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework
{

    /// <summary>
    /// GBF层时间
    /// </summary>
    public static class GameBoxFrameworkTime
    {
        /// <summary>
        /// 游戏世界的流逝时间
        /// </summary>
        private static float m_GameWorldElapsedTime;
        /// <summary>
        /// 真实世界的流逝时间
        /// </summary>
        private static float m_RealWorldElapsedTime;
        /// <summary>
        /// 游戏世界的流逝总时间
        /// </summary>
        private static float m_TotalGameWorldElapsedTime;
        /// <summary>
        /// 真实世界的流逝总时间
        /// </summary>
        private static float m_TotalRealWorldElapsedTime;

        /// <summary>
        /// 游戏世界的流逝时间
        /// </summary>
        public static float GameWorldElapsedTime { get { return m_GameWorldElapsedTime; } internal set { m_GameWorldElapsedTime = value; m_TotalGameWorldElapsedTime += value; } }

        /// <summary>
        /// 真实世界的流逝时间
        /// </summary>
		public static float RealWorldElapsedTime { get { return m_RealWorldElapsedTime; } internal set { m_RealWorldElapsedTime = value; m_TotalRealWorldElapsedTime += value; } }

        /// <summary>
        /// 游戏世界的流逝总时间
        /// </summary>
        public static float TotalGameWorldElapsedTime { get { return m_TotalGameWorldElapsedTime; } } 

        /// <summary>
        /// 真实世界的流逝总时间
        /// </summary>
		public static float TotalRealWorldElapsedTime { get { return m_TotalRealWorldElapsedTime; } }


    }
}
