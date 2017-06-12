/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox.Runtime.Component;
using GameBoxFramework;
using GameBoxFramework.ObjectPool;
using GameBoxFramework.Utility;
using System;
using UnityEngine;

namespace GameBox.Extension
{
    /// <summary>
    /// 对象池扩展类
    /// </summary>
    public static class ObjectPoolExtension 
	{
        /// <summary>
        /// 静态构造方法
        /// </summary>
        static ObjectPoolExtension()
        {
            ObjectPoolComponent = GameBoxEntry.GetComponent<ObjectPoolComponent>();
        }

        /// <summary>
        /// 对象池组件成员变量
        /// </summary>
        private static ObjectPoolComponent m_ObjectPoolComponent;

        /// <summary>
        /// 对象池组件成员属性
        /// </summary>
        private static ObjectPoolComponent ObjectPoolComponent { get { return m_ObjectPoolComponent; } set { if (null == m_ObjectPoolComponent) m_ObjectPoolComponent = value; } }

        /// <summary>
        /// 对象池组件是否是有效的
        /// </summary>
        /// <returns></returns>
        private static void IsObjectPoolComponentValid()
        {
            if (null == ObjectPoolComponent) throw new GameBoxFrameworkException("对象池组件是无效的.");
        }


        /// <summary>
        ///  获取对象
        /// </summary>
        /// <typeparam name="T">BaseObject的派生类型</typeparam>
        /// <param name="t_GameObject">游戏对象</param>
        /// <param name="t_ObjectPoolName">对象池的名字</param>
        /// <param name="t_ObjectName">对象的名字</param>
        /// <returns>返回从对象池获取到的对象实例</returns>
        public static GameObject Spawn<T>(this GameObject t_GameObject, string t_ObjectPoolName, string t_ObjectName) where T:BaseObject
        {
            IsObjectPoolComponentValid();

            var t_IObjectPool =  ObjectPoolComponent.GetObjectPool<T>(t_ObjectPoolName);
            return t_IObjectPool.Spawn(t_ObjectName).Target as GameObject;
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <typeparam name="T">BaseObject的派生类型</typeparam>
        /// <param name="t_GameObject">游戏对象</param>
        /// <param name="t_ObjectPoolName">对象池的名字</param>
        public static void Unspawn<T>(this GameObject t_GameObject,string t_ObjectPoolName) where T : BaseObject
        {
            IsObjectPoolComponentValid();

            var t_IObjectPool = ObjectPoolComponent.GetObjectPool<T>(t_ObjectPoolName);
            if(null!= t_IObjectPool)
                 t_IObjectPool.Unspawn(t_GameObject);
        }

        /// <summary>
        /// 把游戏对象注册进指定的对象池
        /// </summary>
        /// <typeparam name="T">BaseObject的派生类型</typeparam>
        /// <param name="t_GameObject">游戏对象</param>
        /// <param name="t_ObjectPoolName">对象池的名字</param>
        /// <param name="t_ObjectName">对象池的名字</param>
        /// <param name="t_Capacity">对象池的容量</param>
        /// <param name="t_ExpireTime">自动销毁的时间</param>
        public static void Register<T>(this GameObject t_GameObject,string t_ObjectPoolName,string t_ObjectName,int t_Capacity=int.MaxValue, float t_ExpireTime=float.MaxValue) where T : BaseObject
        {
            IsObjectPoolComponentValid();
            var t_IObjectPool = ObjectPoolComponent.GetObjectPool<T>(t_ObjectPoolName);
            if (null == t_IObjectPool)
            {
                t_IObjectPool = ObjectPoolComponent.CreateSingleSpawnObjectPool<T>(t_ObjectPoolName, t_Capacity, t_ExpireTime);
            }
            t_IObjectPool.Register((T)Activator.CreateInstance(typeof(T), t_ObjectName, t_GameObject),false);

        }


        /// <summary>
        /// 释放对象池里面的可释放对象
        /// </summary>        
        /// <typeparam name="T">BaseObject的派生类型</typeparam>
        /// <param name="t_GameObject">BaseObject的派生类型</param>
        /// <param name="t_ObjectPoolName">对象池的名字</param>

        public static void Release<T>(this GameObject t_GameObject, string t_ObjectPoolName) where T : BaseObject
        {
            IsObjectPoolComponentValid();
            var t_IObjectPool = ObjectPoolComponent.GetObjectPool<T>(t_ObjectPoolName);
            if (null != t_IObjectPool)
            {
                t_IObjectPool.Release();
            }
        }

        /// <summary>
        /// 释放对象池中的所有未使用对象
        /// </summary>        
        /// <typeparam name="T">BaseObject的派生类型</typeparam>
        /// <param name="t_GameObject">BaseObject的派生类型</param>
        /// <param name="t_ObjectPoolName">对象池的名字</param>

        public static void ReleaseAllUnused<T>(this GameObject t_GameObject, string t_ObjectPoolName) where T : BaseObject
        {
            IsObjectPoolComponentValid();
            var t_IObjectPool = ObjectPoolComponent.GetObjectPool<T>(t_ObjectPoolName);
            if (null != t_IObjectPool)
            {
                t_IObjectPool.ReleaseAllUnused();
            }
        }
    }
}