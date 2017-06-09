/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework;
using GameBoxFramework.Runtime.EventPool;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// EventBroker组件
    /// </summary>
    public sealed class EventBrokerComponent : BaseGameBoxComponent
    {
        /// <summary>
        /// 事件池管家接口
        /// </summary>
        private IEventPoolManager m_IEventPoolManager = null;

        protected override void Awake()
        {
            base.Awake();
            m_IEventPoolManager = GameBoxEntry.GetBuiltInModule<IEventPoolManager>();
            if (null==m_IEventPoolManager)
            {
                throw new GameBoxFrameworkException("IEventPoolManager是无效的！");
            }
        }

        /// <summary>
        /// 注册事件经纪人所管辖的发布者或者订阅者
        /// </summary>
        /// <param name="t_Target"></param>
        public void Register(object t_Target)
        {
            var t_Type = t_Target.GetType();
            var t_Events = t_Type.GetEvents();
            for (int i = 0; i < t_Events.Length; i++)
            {
                var t_CustomAttributes = t_Events[i].GetCustomAttributes(false);
                for (int j = 0; j < t_CustomAttributes.Length; j++)
                {
                    if (t_CustomAttributes[i] is EventPublicationAttribute) //发布者
                    {
                        var t_IEventTopic = CreateEventTopic((t_CustomAttributes[j] as EventPublicationAttribute).EventTopicName,(t_CustomAttributes[j] as EventPublicationAttribute).IsMainThread); //创建主题
                        t_Events[i].AddEventHandler(t_Target, t_IEventTopic.EventTopicPublisher);
                        //UnityEngine.Debug.Log("EventPublicationAtrribute: " + (t_CustomAttributes[j] is EventPublicationAttribute));
                    }
                }
               
            }

            var t_Methods = t_Type.GetMethods();
            for (int i = 0; i < t_Methods.Length; i++)
            {
                var t_CustomAttributes = t_Methods[i].GetCustomAttributes(false);
                for (int j = 0; j < t_CustomAttributes.Length; j++)
                {
                    if (t_CustomAttributes[j] is EventSubscriptionAttribute)//订阅者
                    {
                        var t_IEventTopic = GetEventTopic((t_CustomAttributes[j] as EventSubscriptionAttribute).EventTopicName); //获取主题
                        t_IEventTopic.AddSubscriber(DelegateHelper.CreateDelegate(t_Methods[i], t_Target)); //添加订阅者
                        //UnityEngine.Debug.Log("EventSubscriptionAtrribute: " + (t_CustomAttributes[j] is EventSubscriptionAttribute));
                    }
                }
            }

        }

        /// <summary>
        /// 创建一个事件主题
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        /// <returns>返回事件主题接口</returns>
        public IEventTopic CreateEventTopic(string t_EventTopicName, bool t_IsMainThread = true)
        {
            return m_IEventPoolManager.CreateEventTopic(t_EventTopicName, t_IsMainThread);
        }



        /// <summary>
        /// 获取一个事件主题
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        /// <returns>返回事件主题接口</returns>
        public IEventTopic GetEventTopic(string t_EventTopicName)
        {
            return m_IEventPoolManager.GetEventTopic(t_EventTopicName);
        }

        /// <summary>
        /// 移除一个事件主题
        /// </summary>
        /// <param name="t_EventTopic">事件主题</param>
        public void RemoveEventTopic(string t_EventTopicName)
        {
            m_IEventPoolManager.RemoveEventTopic(t_EventTopicName);
        }





        /// <summary>
        /// 发布一个线程安全的主题
        /// </summary>
        /// <param name="t_EventTopicName">主题名字</param>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        public void PublishTopic(string t_EventTopicName, object t_Sender, BaseEventArgs t_EventArgs)
        {
            m_IEventPoolManager.PublishTopic(t_EventTopicName, t_Sender, t_EventArgs);
        }

        /// <summary>
        /// 立刻发布一个非线程安全的主题
        /// </summary>
        /// <param name="t_EventTopicName">主题名字</param>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        public void PublishTopicNow(string t_EventTopicName, object t_Sender, BaseEventArgs t_EventArgs)
        {
            m_IEventPoolManager.PublishTopicNow(t_EventTopicName, t_Sender, t_EventArgs);
        }

        /// <summary>
        /// 智能发布一个主题，根据主题处在的线程自动选择发布方式
        /// </summary>
        /// <param name="t_EventTopicName">主题名字</param>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        public void PublishTopicSmart(string t_EventTopicName, object t_Sender, BaseEventArgs t_EventArgs)
        {
            m_IEventPoolManager.PublishTopicSmart(t_EventTopicName, t_Sender, t_EventArgs);
        }


    }
}