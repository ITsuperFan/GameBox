/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework;
using UnityEngine.SceneManagement;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// 场景事件参数
    /// </summary>
    public class SceneEventArgs : BaseEventArgs 
	{
        /// <summary>
        /// 场景
        /// </summary>
        public Scene Scene { get; set; }

        /// <summary>
        /// 场景名
        /// </summary>
		public string SceneName { get; set; }

        /// <summary>
        ///  进度
        /// </summary>
		public float Process { get; set; }

    }
}