/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using UnityEngine;

namespace GameBox
{
    /// <summary>
    /// GameBox基础组件
    /// </summary>
	public class BaseGameBoxComponent : MonoBehaviour 
	{
        /// <summary>
        /// 模块的权值
        /// </summary>
        public int Weight { get; protected internal set; }


        protected virtual void Awake()
        {
            //基础组件初始化操作
        }
		

	}
}