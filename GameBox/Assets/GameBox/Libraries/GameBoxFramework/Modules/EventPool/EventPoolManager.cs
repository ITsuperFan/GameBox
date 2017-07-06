/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;

namespace GameBoxFramework.EventPool
{
    /// <summary>
    /// 事件池管家
    /// </summary>
    internal sealed class EventPoolManager : BaseModule, IEventPoolManager
    {
        /// <summary>
        /// 事件池管家
        /// </summary>
        private readonly IListDataStructure<IEventTopic> IListDataStructure = new EventPoolManagerSLinkedList();




        /// <summary>
        /// 是否存在主题
        /// </summary>
        /// <param name="t_TopicName">主题名字</param>
        /// <returns></returns>
        public bool HasTopic(string t_TopicName)
        {
            return null != GetEventTopic(t_TopicName);
        }


        /// <summary>
        /// 创建一个事件主题
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        /// <returns>返回事件主题接口</returns>
        public IEventTopic CreateEventTopic(string t_EventTopicName,bool t_IsMainThread=true)
        {
            if (null != GetEventTopic(t_EventTopicName)) throw new GameBoxFrameworkException("已经存在此事件主题!");

            var t_EventTopic = new EventTopic(t_EventTopicName,t_IsMainThread);
            IListDataStructure.AddNode(t_EventTopic);
            return t_EventTopic;
        }

        /// <summary>
        /// 获取一个事件主题
        /// </summary>
        /// <param name="t_EventTopicName">事件主题名字</param>
        /// <returns>返回事件主题接口</returns>
        public IEventTopic GetEventTopic(string t_EventTopicName)
        {
            var t_EventTopicArray = IListDataStructure.ToArray();
            IEventTopic t_Target = null;
            for (int i = 0; i < t_EventTopicArray.Length; i++)
            {
                if (t_EventTopicArray[i].EventTopicName == t_EventTopicName)
                {
                    t_Target = t_EventTopicArray[i];
                    t_EventTopicArray[i].Weight++; //权重自加
                    IListDataStructure.Sort(); //重新排序
                    break;
                }
            }
            return t_Target;
        }

        /// <summary>
        /// 发布一个线程安全的主题
        /// </summary>
        /// <param name="t_EventTopicName">主题名字</param>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        public void PublishTopic(string t_EventTopicName, object t_Sender, BaseEventArgs t_EventArgs)
        {
            var t_IEventTopic = GetEventTopic(t_EventTopicName);
            if (null == t_IEventTopic) throw new GameBoxFrameworkException("需要发布的主题为空!");

            t_IEventTopic.PublishTopic(t_Sender,t_EventArgs);
        }

        /// <summary>
        /// 立刻发布一个非线程安全的主题
        /// </summary>
        /// <param name="t_EventTopicName">主题名字</param>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        public void PublishTopicNow(string t_EventTopicName, object t_Sender, BaseEventArgs t_EventArgs)
        {
            var t_IEventTopic = GetEventTopic(t_EventTopicName);
            if (null == t_IEventTopic) throw new GameBoxFrameworkException("需要发布的主题为空！");

            t_IEventTopic.PublishTopicNow(t_Sender, t_EventArgs); //立刻发布一个主题，但是这个不是线程安全的
        }

        /// <summary>
        /// 智能发布一个主题，根据主题处在的线程自动选择发布方式
        /// </summary>
        /// <param name="t_EventTopicName">主题名字</param>
        /// <param name="t_Sender">主题的发布者</param>
        /// <param name="t_EventArgs">主题的事件参数</param>
        public void PublishTopicSmart(string t_EventTopicName, object t_Sender, BaseEventArgs t_EventArgs)
        {
            var t_IEventTopic = GetEventTopic(t_EventTopicName);
            if (null == t_IEventTopic) throw new GameBoxFrameworkException("需要发布的主题为空！");

            t_IEventTopic.PublishTopicSmart(t_Sender, t_EventArgs); //立刻发布一个智能主题
        }

        /// <summary>
        /// 移除一个事件主题
        /// </summary>
        /// <param name="t_EventTopic">事件主题</param>
        public void RemoveEventTopic(string t_EventTopicName)
        {
            IListDataStructure.RemoveNode(eventTopic=>eventTopic.EventTopicName == t_EventTopicName);
        }

        /// <summary>
        /// 模块初始化的时候调用
        /// </summary>
        protected internal override void OnInit(IModuleManager t_IModuleManager)
        {
            
        }

        /// <summary>
        /// 模块被启动的时候调用
        /// </summary>
        protected internal override void OnStart(IModuleManager t_IModuleManager)
        {
           
        }

        /// <summary>
        /// 模块被轮询的时候调用
        /// </summary>
        protected internal override void OnUpdate(IModuleManager t_IModuleManager)
        {
            var t_Nodes = IListDataStructure.ToArray();
            for (int i = 0; i < t_Nodes.Length; i++)
            {
                t_Nodes[i].Update();
            }
        }

        /// <summary>
        /// 模块被停止的时候调用
        /// </summary>
        protected internal override void OnStop(IModuleManager t_IModuleManager)
        {
            
        }

        /// <summary>
        /// 模块被销毁前调用
        /// </summary>
        protected internal override void OnDestroy(IModuleManager t_IModuleManager)
        {
            IListDataStructure.Clear();
        }


    }
}