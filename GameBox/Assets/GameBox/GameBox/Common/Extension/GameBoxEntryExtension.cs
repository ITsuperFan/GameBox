/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework;

namespace GameBox.Extension
{
	public static class GameBoxEntryExtension 
	{
        /// <summary>
        /// 获取系统内置模块
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetBuiltInModule<T>(this UnityEngine.GameObject t_GameObject) where T : class
        {
            return GameBoxEntry.GetBuiltInModule<T>();
        }

    }
}