/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using UnityEngine;

namespace GameBox.Extension
{
    /// <summary>
    /// Vector3扩展类
    /// </summary>
	public static class Vector3Extension 
	{
        /// <summary>
        /// 修改Vector3的值
        /// </summary>
        /// <param name="vector3">目标Vector3</param>
        /// <param name="x">X的值</param>
        /// <returns></returns>
        public static Vector3 X(this Vector3 vector3,float x)
        {
            return new Vector3(x, vector3.y, vector3.z);
        }

        /// <summary>
        /// 修改Vector3的值
        /// </summary>
        /// <param name="vector3">目标Vector3</param>
        /// <param name="y">Y的值</param>
        /// <returns></returns>
        public static Vector3 Y(this Vector3 vector3, float y)
        {
            return new Vector3(vector3.x,y, vector3.z);
        }

        /// <summary>
        /// 修改Vector3的值
        /// </summary>
        /// <param name="vector3">目标Vector3</param>
        /// <param name="y">Z的值</param>
        /// <returns></returns>
        public static Vector3 Z(this Vector3 vector3, float z)
        {
            return new Vector3(vector3.x, vector3.y,z);
        }

    }
}