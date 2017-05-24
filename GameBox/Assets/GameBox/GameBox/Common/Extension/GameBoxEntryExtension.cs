/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework;
using UnityEngine;

namespace GameBox.Extension
{
	public static class GameBoxEntryExtension 
	{
        /// <summary>
        /// 获取系统内置模块
        /// </summary>
        /// <typeparam name="T">GameObject</typeparam>
        /// <returns>BuiltInModule</returns>
        public static T GetBuiltInModule<T>(this GameObject t_T) where T : class
        {
            return GameBoxEntry.GetBuiltInModule<T>();
        }

        /// <summary>
        /// 获取系统内置模块
        /// </summary>
        /// <typeparam name="T">Transform</typeparam>
        /// <returns>BuiltInModule</returns>
        public static T GetBuiltInModule<T>(this Transform t_T) where T : class
        {
            return t_T.gameObject.GetBuiltInModule<T>();
        }
    }
}