/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBoxFramework.EventPool
{

    /// <summary>
    /// 事件主题队列数据类型
    /// </summary>
    internal sealed class EventTopicQueueData
    {
        /// <summary>
        /// 发布者
        /// </summary>
        public object Sender { get; set; }
        /// <summary>
        /// 事件发布时候的参数
        /// </summary>
        public BaseEventArgs EventArgs { get; set; }
        /// <summary>
        /// 事件主题接口
        /// </summary>
        public IEventTopic EventTopic { get; set; }
    }
}