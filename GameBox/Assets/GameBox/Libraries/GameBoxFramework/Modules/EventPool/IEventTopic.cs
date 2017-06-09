/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using System;

namespace GameBoxFramework.Runtime.EventPool
{
    /// <summary>
    /// 事件主题接口
    /// </summary>
    public interface IEventTopic : IComparable<IEventTopic>
	{
        /// <summary>
        /// 权重
        /// </summary>
        int Weight { get; set; }

        /// <summary>
        /// 事件主题的名字
        /// </summary>
        string EventTopicName { get;}

        /// <summary>
        /// 是否在主线程
        /// </summary>
        bool IsMainThread{ get; }

        /// <summary>
        /// 事件主题的绑定委托
        /// </summary>
        EventHandler EventTopicPublisher{ get; }

        /// <summary>
        /// 添加订阅者
        /// </summary>
        /// <param name="t_Subscriber">订阅者委托</param>
        void AddSubscriber(Delegate t_Subscriber);

        /// <summary>
        /// 移除订阅者
        /// </summary>
        /// <param name="t_Subscriber">订阅者委托</param>
        void RemoveSubscriber(Delegate t_Subscriber);

        /// <summary>
        /// 发布主题
        /// </summary>
        /// <param name="t_Sender">发送者</param>
        /// <param name="t_EventArgs">事件参数</param>
        void PublishTopic(object t_Sender, BaseEventArgs t_EventArgs);

        /// <summary>
        /// 立刻发布一个非线程安全的主题
        /// </summary>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        void PublishTopicNow( object t_Sender, BaseEventArgs t_EventArgs);

        /// <summary>
        /// 智能发布一个主题，根据主题处在的线程自动选择发布方式
        /// </summary>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        void PublishTopicSmart(object t_Sender, BaseEventArgs t_EventArgs);

        /// <summary>
        /// 轮询主题
        /// </summary>
        void Update();
    }
}