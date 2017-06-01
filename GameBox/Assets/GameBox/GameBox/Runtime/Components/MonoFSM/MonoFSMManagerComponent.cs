/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;
using UnityEngine;

namespace GameBox.Runtime.Component
{

    /// <summary>
    /// Mono状态机组件
    /// </summary>
	public sealed class MonoFSMManagerComponent : BaseGameBoxComponent
    {
        /// <summary>
        /// 创建MonoFSM状态机
        /// </summary>
        /// <typeparam name="T">状态枚举</typeparam>
        /// <param name="t_RunnerComponent">运行持有者的组件，用于反射里面状态对应的方法</param>
        /// <returns></returns>
        public IMonoFSM<T> CreateMonoFSM<T>(MonoBehaviour t_RunnerComponent) where T : struct, IConvertible, IComparable
        {
            return MonoFSM<T>.Init(t_RunnerComponent,default(T));
        }


    }
}