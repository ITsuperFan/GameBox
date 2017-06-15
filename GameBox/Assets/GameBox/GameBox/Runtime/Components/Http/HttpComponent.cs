/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework;
using GameBoxFramework.EventPool;
using System.Reflection;
using UnityEngine;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// Http组件
    /// </summary>
    [AddComponentMenu("GameBox/Http")]
    public sealed class HttpComponent : BaseGameBoxComponent 
	{
        /// <summary>
        /// 事件池管家接口
        /// </summary>
        private IEventPoolManager m_IEventPoolManager=null;

        /// <summary>
        /// HttpClient接口
        /// </summary>
        private IHttpClient m_IHttpClient=null;

        /// <summary>
        /// Http请求事件
        /// </summary>
        public event EventHandler HttpEventHandler;

        /// <summary>
        /// 初始化组件
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            m_IEventPoolManager = GameBoxEntry.GetBuiltInModule<IEventPoolManager>();
            if (null == m_IEventPoolManager)
            {
                throw new GameBoxFrameworkException("IEventPoolManager是无效的.");
            }

            if (null== m_IHttpClient&&null==GetComponent<IHttpClient>())
            {
                m_IHttpClient = gameObject.AddComponent<HttpMonoClient>();
            }

            RegisterHttpEventTopic(); //注册Http事件主题
        }

        /// <summary>
        /// HTTP协议Get方式去请求服务器
        /// </summary>
        /// <param name="t_HttpRequestData">请求的数据</param>
        /// <param name="t_GetHandler"></param>
        public void Get(HttpRequestData t_HttpRequestData, EventHandler t_GetHandler=null)
        {
            m_IHttpClient.Get(t_HttpRequestData,(o,e)=> {

                if (null!= t_GetHandler)
                {
                    t_GetHandler(this,e); 
                }

                if (null!=HttpEventHandler)
                {
                    HttpEventHandler(this,e);
                }

            });
        }

        public void Post(HttpRequestData t_HttpRequestData, EventHandler t_GetHandler = null)
        {
            m_IHttpClient.Post(t_HttpRequestData, (o, e) => {

                if (null != t_GetHandler)
                {
                    t_GetHandler(this, e);
                }

                if (null != HttpEventHandler)
                {
                    HttpEventHandler(this, e);
                }
            });
        }


        /// <summary>
        /// 注册事件经纪人所管辖的发布者或者订阅者
        /// </summary>
        /// <param name="t_Target">注册的目标对象</param>
        public void Register(object t_Target)
        {
            var t_Type = t_Target.GetType();

            var t_Methods = t_Type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            for (int i = 0; i < t_Methods.Length; i++)
            {
                var t_CustomAttributes = t_Methods[i].GetCustomAttributes(false);
                for (int j = 0; j < t_CustomAttributes.Length; j++)
                {
                    if (t_CustomAttributes[j] is HttpEventAttribute)//订阅者
                    {
                        var t_HttpEventAttribute = t_CustomAttributes[j] as HttpEventAttribute;
                        var t_TargetTopicName = t_HttpEventAttribute.HttpEventTopicName + (@t_HttpEventAttribute.URL ?? string.Empty);
                        if (m_IEventPoolManager.HasTopic(t_TargetTopicName))
                        {
                            m_IEventPoolManager.GetEventTopic(t_TargetTopicName).AddSubscriber(DelegateHelper.CreateDelegate(t_Methods[i], t_Target)); //添加订阅者
                        }
                        else
                        {
                            m_IEventPoolManager.CreateEventTopic(t_TargetTopicName).AddSubscriber(DelegateHelper.CreateDelegate(t_Methods[i], t_Target)); //添加订阅者
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 注册Http事件主题
        /// </summary>
        private void RegisterHttpEventTopic()
        {
            m_IEventPoolManager.CreateEventTopic(HttpRequstType.Get.ToString()); //创建 HttpRequstType.Get 广播主题
            m_IEventPoolManager.CreateEventTopic(HttpRequstType.Post.ToString()); //创建 HttpRequstType.Post 广播主题

            HttpEventHandler += (o, e) => {

                var t_HttpEventArgs = e as HttpEventArgs;
                var t_EventTopic = t_HttpEventArgs.HttpRequstType.ToString() + @t_HttpEventArgs.HttpRequestData.URL;
                if (m_IEventPoolManager.HasTopic(t_EventTopic))
                {
                    m_IEventPoolManager.PublishTopicSmart(t_EventTopic,this,t_HttpEventArgs);
                }
                m_IEventPoolManager.PublishTopicSmart(t_HttpEventArgs.HttpRequstType.ToString(), this, t_HttpEventArgs);
            };
        }

    }
}