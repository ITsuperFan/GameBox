/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/
using System;
using UnityEngine;

namespace GameBox
{
    /// <summary>
    /// GameBox基础组件
    /// </summary>
	public abstract class BaseGameBoxComponent : MonoBehaviour , IComparable<BaseGameBoxComponent>
    {
        /// <summary>
        /// 模块的权值
        /// </summary>
        public int Weight { get; protected internal set; }

        /// <summary>
        /// 比较接口
        /// </summary>
        /// <param name="other">其他的模块</param>
        /// <returns>比较后的结果</returns>
        public int CompareTo(BaseGameBoxComponent other)
        {
           return this.Weight - other.Weight; //自身模块的权重 - 需要进行比较的模块的权重        
        }


        #region Unity生命周期

        /// <summary>
        /// 组件被唤醒时
        /// </summary>
        protected virtual void Awake()
        {
            //基础组件初始化时的操作
            GameBoxEntry.RegisterComponent(this);

        }

        /// <summary>
        /// 组件被销毁时
        /// </summary>
        protected virtual void OnDestroy()
        {
            //基础组件销毁时的操作
            GameBoxEntry.DestroyComponent(this);
        }

        #endregion



    }
}