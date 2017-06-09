/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using System.Collections.Generic;

namespace GameBoxFramework.Runtime.EventPool
{


    /// <summary>
    /// 事件主题队列
    /// </summary>
	internal sealed class EventTopicQueue 
    {
        /// <summary>
        /// 主题队列
        /// </summary>
        private Queue<EventTopicQueueData> m_EventTopicQueue = new Queue<EventTopicQueueData>();

        /// <summary>
        /// 队列的数量
        /// </summary>
        public int Count { get { return m_EventTopicQueue.Count; } }

        /// <summary>
        /// 入队列
        /// </summary>
        /// <param name="t_IEventTopic"></param>
        public void Enqueue(IEventTopic t_IEventTopic,object t_Sender, BaseEventArgs t_EventArgs)
        {
            m_EventTopicQueue.Enqueue(new EventTopicQueueData() { EventTopic = t_IEventTopic, Sender = t_Sender, EventArgs = t_EventArgs });
        }

        /// <summary>
        /// 出队列
        /// </summary>
        public void Dequeue()
        {
            var IEventTopicData =  m_EventTopicQueue.Dequeue();
            IEventTopicData.EventTopic.PublishTopicNow(IEventTopicData.Sender, IEventTopicData.EventArgs);
        }

        /// <summary>
        /// 清除所有的队列主题数据
        /// </summary>
        public void Clear()
        {
            m_EventTopicQueue.Clear();
        }


    }
}