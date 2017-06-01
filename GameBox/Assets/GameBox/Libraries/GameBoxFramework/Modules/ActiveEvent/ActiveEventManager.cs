/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameBoxFramework.Runtime.Event
{
    /// <summary>
    /// 有效事件模块实现类
    /// </summary>
    public sealed class ActiveEventManager :BaseModule , IActiveEventManager
    {
        /// <summary>
        /// 抽象数据结构类型
        /// </summary>
        private readonly IMapDataStructure<string,List<ActiveEventEntry>> IMapDataStructure = new ActiveEventTrieMap<string, List<ActiveEventEntry>>();

        /// <summary>
        /// 有效事件的数目
        /// </summary>
        public int ActiveEventCount
        {
            get
            {
                return IMapDataStructure.Count;
            }
        }

        /// <summary>
        /// 获取所有有效事件的名称
        /// </summary>
        public string[] ActiveEventNames
        {
            get
            {
                string[] t_ActiveEventNames = new string[ActiveEventCount];
                var t_Array = IMapDataStructure.ToArray();
                for (int i = 0; i < t_Array.Length; i++)
                {
                    t_ActiveEventNames[i] = t_Array[i].Key;
                }
                return t_ActiveEventNames;
            }
        }

        /// <summary>
        /// 调用有效事件
        /// </summary>
        /// <param name="t_ActiveEventName">有效事件注册的时候对应的索引名字</param>
        /// <param name="t_Params">方法执行的参数</param>
        /// <returns>返回有效事件结果列表</returns>
        public List<ActiveEventResult> CallActiveEvent(string t_ActiveEventName, params object[] t_Params)
        {
            List<ActiveEventEntry> t_ActiveEventEntryList=null;
            List<ActiveEventResult> t_ActiveEventResultList=null;

            IMapDataStructure.TryGetValue(t_ActiveEventName, out t_ActiveEventEntryList);
            if (null != t_ActiveEventEntryList)
            {
                t_ActiveEventResultList = new List<ActiveEventResult>();
                object[] t_ActiveEventHandlerParams = null;

                for (int i = 0; i < t_ActiveEventEntryList.Count; i++)
                {
                    if (0 < t_ActiveEventEntryList[i].ParamsCount) //如果存在参数
                    {
                        t_ActiveEventHandlerParams = new object[t_ActiveEventEntryList[i].ParamsCount];

                        for (int j = 0; j < t_ActiveEventHandlerParams.Length; j++)
                        {
                            if (j < t_Params.Length)
                                t_ActiveEventHandlerParams[j] = t_Params[j]; //该方法有多少个参数就 只能放多少个
                            else
                                t_ActiveEventHandlerParams[j] = null; //如果参数填写的比原来方法的参数少了，那么自动补null
                        }
                    }

                    t_ActiveEventResultList.Add(new ActiveEventResult()
                    {
                        ActiveEventMapMethodName = t_ActiveEventEntryList[i].ActiveEventHandler.Name,
                        ActiveEventReturn = t_ActiveEventEntryList[i].ActiveEventHandler.Invoke(null, t_ActiveEventHandlerParams)

                    });

                    t_ActiveEventHandlerParams = null; //本次循环完毕赋值完毕后再次赋值为空，以免影响上次数据
                }
            }

            return t_ActiveEventResultList;
        }

        /// <summary>
        /// 销毁有效事件
        /// </summary>
        /// <param name="t_ActiveEventName">有效事件对应的名字</param>
        public void DestroyActiveEvent(string t_ActiveEventName)
        {
            if (IMapDataStructure.ContainsKey(t_ActiveEventName))
            {
                IMapDataStructure.Remove(t_ActiveEventName);
            }
        }

        /// <summary>
        /// 加载有效事件的对应程序集
        /// </summary>
        /// <param name="FullNamespace">加载的程序集路径</param>
        public void LoadActiveEventAssembly(string t_FullNamespace)
        {
            var t_Type =  Type.GetType(t_FullNamespace);
            foreach (var t_Method in t_Type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                var t_ActiveEventAttribute = Attribute.GetCustomAttribute(t_Method, typeof(ActiveEventAttribute)) as ActiveEventAttribute;

                if (null != t_ActiveEventAttribute)
                {
                    if (IMapDataStructure.ContainsKey(t_ActiveEventAttribute.EventName))
                    {
                        List<ActiveEventEntry> t_ActiveEventEntryList = null;
                        IMapDataStructure.TryGetValue(t_ActiveEventAttribute.EventName,out t_ActiveEventEntryList);
                        if (null!= t_ActiveEventEntryList)
                        {
                            t_ActiveEventEntryList.Add(new ActiveEventEntry()
                            {
                                ActiveName = t_ActiveEventAttribute.EventName,
                                ParamsCount = t_Method.GetParameters().Length,
                                ActiveEventHandler = t_Method
                            });
                        }
                    }
                    else
                    {
                        IMapDataStructure.Add(t_ActiveEventAttribute.EventName,new List<ActiveEventEntry>()
                        {
                            new ActiveEventEntry()
                            {
                                ActiveName = t_ActiveEventAttribute.EventName,
                                ParamsCount = t_Method.GetParameters().Length,
                                ActiveEventHandler = t_Method
                            }
                        });
                    }
                }
            }
        }

        protected internal override void OnInit(IModuleManager t_IModuleManager)
        {
          
        }

        protected internal override void OnStart(IModuleManager t_IModuleManager)
        {
           
        }

        protected internal override void OnUpdate(IModuleManager t_IModuleManager)
        {
            
        }

        protected internal override void OnStop(IModuleManager t_IModuleManager)
        {
            
        }

        protected internal override void OnDestroy(IModuleManager t_IModuleManager)
        {

        }
    }
}
