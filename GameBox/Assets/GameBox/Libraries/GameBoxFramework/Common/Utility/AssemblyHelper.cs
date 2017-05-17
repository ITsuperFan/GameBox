using System;
using System.Collections.Generic;

namespace GameBoxFramework.Utility
{
    /// <summary>
    /// 程序集相关的实用函数。
    /// </summary>
    public static class AssemblyHelper
    {
        private static readonly IDictionary<string, Type> s_CachedTypes = new Dictionary<string, Type>();
        private static readonly IList<string> s_LoadedAssemblyNames = new List<string>();

        static AssemblyHelper()
        {
            System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (System.Reflection.Assembly assembly in assemblies)
            {
                s_LoadedAssemblyNames.Add(assembly.FullName);
            }
        }

        /// <summary>
        /// 获取已加载的程序集名称。
        /// </summary>
        /// <returns>已加载的程序集名称。</returns>
        public static string[] GetLoadedAssemblyNames()
        {
            return ((List<string>)s_LoadedAssemblyNames).ToArray();
        }

        /// <summary>
        /// 从已加载的程序集中获取类型。
        /// </summary>
        /// <param name="typeName">要获取的类型名。</param>
        /// <returns>获取的类型。</returns>
        public static Type GetTypeWithinLoadedAssemblies(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new BaseGameBoxFrameworkException("Type name is invalid.");
            }

            Type type = null;
            if (s_CachedTypes.TryGetValue(typeName, out type))
            {
                return type;
            }

            type = Type.GetType(typeName);
            if (type != null)
            {
                s_CachedTypes.Add(typeName, type);
                return type;
            }

            foreach (string assemblyName in s_LoadedAssemblyNames)
            {
                type = Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
                if (type != null)
                {
                    s_CachedTypes.Add(typeName, type);
                    return type;
                }
            }

            return null;
        }
    }
}
