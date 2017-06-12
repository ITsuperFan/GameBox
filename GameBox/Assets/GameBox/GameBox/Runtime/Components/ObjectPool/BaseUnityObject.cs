/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework.ObjectPool;
using UnityEngine;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// 对象池管理的目标对象
    /// </summary>
    public abstract class BaseUnityObject : BaseObject
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_Name"></param>
        /// <param name="t_GameObject"></param>
        public BaseUnityObject(string t_Name, GameObject t_GameObject):base(t_Name, t_GameObject){ }


        /// <summary>
        /// 获取对象时的事件
        /// </summary>
        protected internal override void OnSpawn()
        {
            (Target as GameObject).SetActive(true);
        }

        /// <summary>
        /// 回收对象时的事件
        /// </summary>
        protected internal override void OnUnspawn()
        {
            (Target as GameObject).SetActive(false);
        }


        /// <summary>
        /// 在Unity里面的销毁方式
        /// </summary>
        protected internal override void Release()
        {
            GameObject.DestroyImmediate(Target as GameObject, true);
        }
    }
}