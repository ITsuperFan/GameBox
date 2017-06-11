/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using System;
using System.Collections.Generic;

namespace GameBoxFramework.Runtime.EventPool
{
    /// <summary>
    /// 事件主题
    /// </summary>
	public class EventTopic : IEventTopic
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        public EventTopic(string t_EventTopicName)
        {
            EventTopicName = t_EventTopicName;        
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        /// <param name="t_EventTopicBinder">事件主题绑定的委托</param>
        public EventTopic(string t_EventTopicName, EventHandler t_EventTopicBinder):this(t_EventTopicName)
        {
            if(null==t_EventTopicBinder)
                EventTopicPublisher = PublishTopicSmart; //绑定内部委托处理
            else
                EventTopicPublisher = t_EventTopicBinder; //绑定委托处理
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        /// <param name="t_EventTopicBinder">事件主题绑定的委托</param>
        public EventTopic(string t_EventTopicName,bool t_IsMainThread) : this(t_EventTopicName,null)
        {
            IsMainThread = t_IsMainThread;
        }

        /// <summary>
        /// 事件主题的名字
        /// </summary>
        public string EventTopicName { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 事件主题的绑定委托
        /// </summary>
        public EventHandler EventTopicPublisher { get; private set; }

        /// <summary>
        /// 是否在主线程
        /// </summary>
        public bool IsMainThread { get; private set; }

        /// <summary>
        /// 该主题的订阅者列表
        /// </summary>
        private List<Delegate> m_SubscriberEventHandlerList = new List<Delegate>();

        /// <summary>
        /// 订阅者的执行队列
        /// </summary>
        private EventTopicQueue m_EventTopicQueue = new EventTopicQueue();

        /// <summary>
        /// 添加订阅者
        /// </summary>
        /// <param name="t_Subscriber">订阅者委托</param>
        public void AddSubscriber(Delegate t_Subscriber)
        {
            if (null == t_Subscriber) throw new GameBoxFrameworkException("订阅者委托为空!");

            if (!m_SubscriberEventHandlerList.Contains(t_Subscriber))
            {
                for (int i = 0; i < m_SubscriberEventHandlerList.Count; i++)
                {
                    if (null==m_SubscriberEventHandlerList[i])
                    {
                        m_SubscriberEventHandlerList[i] = t_Subscriber;
                        return;
                    }
                }

                m_SubscriberEventHandlerList.Add(t_Subscriber);
            }
        }

        /// <summary>
        /// 移除订阅者
        /// </summary>
        /// <param name="t_Subscriber">订阅者委托</param>
        public void RemoveSubscriber(Delegate t_Subscriber)
        {
            if (null == t_Subscriber) throw new GameBoxFrameworkException("订阅者委托为空!");

            if (!m_SubscriberEventHandlerList.Contains(t_Subscriber))
            {
                m_SubscriberEventHandlerList.Remove(t_Subscriber);
            }
        }

        /// <summary>
        /// 发布主题
        /// </summary>
        /// <param name="t_Sender">发送者</param>
        /// <param name="t_EventArgs">事件参数</param>
        public void PublishTopic(object t_Sender, BaseEventArgs t_EventArgs)
        {
            m_EventTopicQueue.Enqueue(this,t_Sender,t_EventArgs);
        }

        /// <summary>
        /// 立刻发布一个非线程安全的主题
        /// </summary>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        public void PublishTopicNow(object t_Sender, BaseEventArgs t_EventArgs)
        {
            for (int i = 0; i < m_SubscriberEventHandlerList.Count; i++)
            {
                if (null != m_SubscriberEventHandlerList[i])
                {
                    if (m_SubscriberEventHandlerList[i].Target.Equals(null))
                    {
                        RemoveSubscriber(m_SubscriberEventHandlerList[i]);
                    }
                    else
                    {
                        m_SubscriberEventHandlerList[i].DynamicInvoke(t_Sender, t_EventArgs);
                    }
                }
            }
        }

        /// <summary>
        /// 智能发布一个主题，根据主题处在的线程自动选择发布方式
        /// </summary>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        public void PublishTopicSmart(object t_Sender, BaseEventArgs t_EventArgs)
        {
            if (IsMainThread)
            {
                PublishTopicNow(t_Sender, t_EventArgs);
            }
            else
            {
                PublishTopic(t_Sender, t_EventArgs);
            }

        }

        /// <summary>
        /// 轮询主题
        /// </summary>
        public void Update()
        {
            while (0 < m_EventTopicQueue.Count)
            {
                m_EventTopicQueue.Dequeue();
            }
        }

        /// <summary>
        /// 比较接口
        /// </summary>
        /// <param name="other">需要进行比较的IEventTopic</param>
        /// <returns>比较后的结果</returns>
        public int CompareTo(IEventTopic other)
        {
            return this.Weight - other.Weight;
        }

    }
}