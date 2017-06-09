/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



namespace GameBoxFramework.Runtime.EventPool
{
    /// <summary>
    /// 事件池管家
    /// </summary>
    public interface IEventPoolManager  
	{

        /// <summary>
        /// 创建一个事件主题
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        /// <param name="t_IsMainThread">是否在主线程</param>
        /// <returns>返回事件主题接口</returns>
        IEventTopic CreateEventTopic(string t_EventTopicName, bool t_IsMainThread=true);

        /// <summary>
        /// 获取一个事件主题
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        /// <returns>返回事件主题接口</returns>
        IEventTopic GetEventTopic(string t_EventTopicName);

        /// <summary>
        /// 移除一个事件主题
        /// </summary>
        /// <param name="t_EventTopic">事件主题</param>
        void RemoveEventTopic(string t_EventTopicName);

        /// <summary>
        /// 发布一个线程安全的主题
        /// </summary>
        /// <param name="t_EventTopicName">主题名字</param>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        void PublishTopic(string t_EventTopicName,object t_Sender, BaseEventArgs t_EventArgs);

        /// <summary>
        /// 立刻发布一个非线程安全的主题
        /// </summary>
        /// <param name="t_EventTopicName">主题名字</param>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        void PublishTopicNow(string t_EventTopicName, object t_Sender, BaseEventArgs t_EventArgs);

        /// <summary>
        /// 智能发布一个主题，根据主题处在的线程自动选择发布方式
        /// </summary>
        /// <param name="t_EventTopicName">主题名字</param>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        void PublishTopicSmart(string t_EventTopicName, object t_Sender, BaseEventArgs t_EventArgs);
        

    }
}