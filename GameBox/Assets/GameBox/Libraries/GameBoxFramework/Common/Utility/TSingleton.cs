using System;
using System.Reflection;

namespace GameBoxFramework.Utility
{
    /// <summary>
    /// 非继承MonoBehaviour的单例继承此类，并加入私有构造函数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TSingleton<T> where T : class
    {
        private static T singleton;
        private static readonly object syslock = new object();
        public static readonly System.Type[] EmptyTypes = new System.Type[0];

        public static T Singleton
        {
            get
            {
                if (singleton == null)
                {
                    lock (syslock)
                    {
                        if (singleton == null)
                        {
                            ConstructorInfo ci = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, EmptyTypes, null);
                            if (ci == null) { throw new InvalidOperationException("这个类必须包含一个私有的构造函数"); }
                            singleton = (T)ci.Invoke(null);
                        }
                    }
                }
                return singleton;
            }

        }


    }

}