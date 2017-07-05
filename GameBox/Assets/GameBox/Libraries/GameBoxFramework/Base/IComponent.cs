/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;

namespace GameBoxFramework
{
    /// <summary>
    /// 组件接口
    /// </summary>
	public interface IComponent: IComparable<IComponent>
    {
        /// <summary>
        /// 模块的权值
        /// </summary>
        int Weight { get; set; }

    }
}
