﻿/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Collections.Generic;

namespace GameBoxFramework.Utility
{
    /// <summary>
    /// 类型相关的实用函数。
    /// </summary>
    public static class TypeHelper
    {
        private readonly static string[] m_AssemblyNames = { "Assembly-CSharp" };

        /// <summary>
        /// 获取指定基类的所有子类的名称。
        /// </summary>
        /// <param name="t_TypeBase">基类类型。</param>
        /// <returns>指定基类的所有子类的名称。</returns>
        public static string[] GetTypeNames(System.Type t_TypeBase)
        {
            List<string> t_TypeNames = new List<string>();

            foreach (string t_AssemblyName in m_AssemblyNames)
            {
                System.Reflection.Assembly t_Assembly = System.Reflection.Assembly.Load(t_AssemblyName);
                if (t_Assembly == null)
                {
                    continue;
                }

                System.Type[] t_Types = t_Assembly.GetTypes();
                foreach (System.Type t_Type in t_Types)
                {
                    if (t_Type.IsClass && !t_Type.IsAbstract && t_TypeBase.IsAssignableFrom(t_Type))
                    {
                        t_TypeNames.Add(t_Type.FullName);
                    }
                }
            }

            t_TypeNames.Sort();

            return t_TypeNames.ToArray();
        }
    }
}
