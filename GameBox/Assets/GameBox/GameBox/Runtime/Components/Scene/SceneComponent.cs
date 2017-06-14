/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/
using GameBoxFramework;
using GameBoxFramework.EventPool;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace GameBox.Runtime.Component
{
    public sealed class SceneComponent : BaseGameBoxComponent
    {
        [SerializeField]
        private string m_LasterSceneName;
        [SerializeField]
        private string m_TargetSceneName;
        [SerializeField]
        private string m_CurrentSceneName;

        [SerializeField]
        private string m_LasterRemovedSceneName;
        [SerializeField]
        private string m_TargetRemovedSceneName;
        [SerializeField]
        private string m_CurrentRemovedSceneName;

        public string LasterSceneName { get { return m_LasterSceneName; } private set { m_LasterSceneName = value; } }
        public string TargetSceneName { get { return m_TargetSceneName; } private set { m_LasterSceneName = m_TargetSceneName; m_TargetSceneName = value;  } }
        public string CurrentSceneName { get { return m_CurrentSceneName; } private set { m_CurrentSceneName = value; } }


        public string LasterRemovedSceneName { get { return m_LasterRemovedSceneName; } private set { m_LasterRemovedSceneName = value; } }
        public string TargetRemovedSceneName { get { return m_TargetRemovedSceneName; } private set { m_LasterRemovedSceneName = m_TargetRemovedSceneName; m_TargetRemovedSceneName = value; } }
        public string CurrentRemovedSceneName { get { return m_CurrentRemovedSceneName; } private set { m_CurrentRemovedSceneName = value; } }


        /// <summary>
        /// 场景模块
        /// </summary>
        private ISceneManager m_SceneManager;

        /// <summary>
        /// 事件池管家接口
        /// </summary>
        private IEventPoolManager m_IEventPoolManager;

        public event EventHandler LoadFailureEventHandler;
        public event EventHandler LoadSuccessEventHandler;
        public event EventHandler LoadUpdateEventHandler;

        public event EventHandler UnLoadFailureEventHandler;
        public event EventHandler UnLoadSuccessEventHandler;
        public event EventHandler UnLoadUpdateEventHandler;

        public event EventHandler MoveToSuccessEventHandler;
        public event EventHandler MoveToFailureEventHandler;
        public event EventHandler MoveToUpdateEventHandler;


        protected override void Awake()
        {
            base.Awake();

            m_IEventPoolManager = GameBoxEntry.GetBuiltInModule<IEventPoolManager>();
            if (null== m_IEventPoolManager)
            {
                throw new GameBoxFrameworkException("IEventPoolManager是无效的.");
            }

            if (null== m_SceneManager && null== gameObject.GetComponent<SceneManager>())
            {
                m_SceneManager = gameObject.AddComponent<SceneManager>();

                m_SceneManager.LoadFailureEventHandler += (o, e) => { if (null != LoadFailureEventHandler) LoadFailureEventHandler(this, e); };
                m_SceneManager.LoadSuccessEventHandler += (o, e) => { if (null != LoadSuccessEventHandler) LoadSuccessEventHandler(this, e); };
                m_SceneManager.LoadUpdateEventHandler  += (o, e) => { if (null != LoadUpdateEventHandler) LoadUpdateEventHandler(this, e); };

                m_SceneManager.UnLoadFailureEventHandler += (o, e) => { if (null != UnLoadFailureEventHandler) UnLoadFailureEventHandler(this, e); };
                m_SceneManager.UnLoadSuccessEventHandler += (o, e) => { if (null != UnLoadSuccessEventHandler) UnLoadSuccessEventHandler(this, e); };
                m_SceneManager.UnLoadUpdateEventHandler  += (o, e) => { if (null != UnLoadUpdateEventHandler) UnLoadUpdateEventHandler(this, e); };

                m_SceneManager.MoveToSuccessEventHandler += (o, e) => { if (null != MoveToSuccessEventHandler) MoveToSuccessEventHandler(this, e); };
                m_SceneManager.MoveToFailureEventHandler += (o, e) => { if (null != MoveToFailureEventHandler) MoveToFailureEventHandler(this, e); };
                m_SceneManager.MoveToUpdateEventHandler  += (o, e) => { if (null != MoveToUpdateEventHandler) MoveToUpdateEventHandler(this, e); };

                RegisterSceneEventTopic();

            }
            

        }


        /// <summary>
        /// 当前场景数量
        /// </summary>
        public int CurrentScenesCount
        {
            get
            {
                return null == m_SceneManager ? 0 : m_SceneManager.CurrentScenesCount;
            }
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        public void LoadScene(string t_SceneName, LoadSceneModle t_LoadSceneModle = LoadSceneModle.Append, bool t_AllowSceneActivation = false) 
        {
            TargetSceneName = t_SceneName;
            m_SceneManager.LoadScene(t_SceneName, t_LoadSceneModle, t_AllowSceneActivation);
        }

        /// <summary>
        /// 移动场景
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t_GameObjectList"></param>
        /// <param name="t_SceneName"></param>
        public void MoveToScene<T>(List<T> t_GameObjectList, string t_SceneName)
        {
            m_SceneManager.MoveToScene<T>(t_GameObjectList,t_SceneName);
        }

        /// <summary>
        /// 卸载场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        public void UnLoadScene(string t_SceneName)
        {
            TargetRemovedSceneName = t_SceneName;
            m_SceneManager.UnLoadScene(t_SceneName);
        }

        /// <summary>
        /// 合并场景
        /// </summary>
        /// <param name="t_SourceSceneName"></param>
        /// <param name="t_TargetSceneName"></param>
        public void MergeScene(string t_SourceSceneName, string t_TargetSceneName)
        {
            try
            {
                m_SceneManager.MergeScene(t_SourceSceneName, t_TargetSceneName);
            }
            catch (System.Exception)
            {
               
            }
            
        }

        public void SetActiveScene(string t_SceneName)
        {
            //以后改动接口


        }



        /// <summary>
        /// 注册Scene事件主题
        /// </summary>
        private void RegisterSceneEventTopic()
        {

            m_IEventPoolManager.CreateEventTopic(SceneEventType.LoadFailure.ToString()); //创建 LoadFailure 广播主题
            m_IEventPoolManager.CreateEventTopic(SceneEventType.LoadSuccess.ToString()); //创建 LoadSuccess 广播主题
            m_IEventPoolManager.CreateEventTopic(SceneEventType.LoadUpdate.ToString()); //创建 LoadUpdate 广播主题
            m_IEventPoolManager.CreateEventTopic(SceneEventType.UnLoadFailure.ToString()); //创建 UnLoadFailure 广播主题
            m_IEventPoolManager.CreateEventTopic(SceneEventType.UnLoadSuccess.ToString()); //创建 UnLoadSuccess 广播主题
            m_IEventPoolManager.CreateEventTopic(SceneEventType.UnLoadUpdate.ToString()); //创建 UnLoadUpdate 广播主题
            m_IEventPoolManager.CreateEventTopic(SceneEventType.MoveToFailure.ToString()); //创建 MoveToFailure 广播主题
            m_IEventPoolManager.CreateEventTopic(SceneEventType.MoveToSuccess.ToString()); //创建 MoveToSuccess 广播主题
            m_IEventPoolManager.CreateEventTopic(SceneEventType.MoveToUpdate.ToString()); //创建 MoveToUpdate 广播主题


            LoadFailureEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicSmart(SceneEventType.LoadFailure.ToString(), o, e); var t_TopicName = SceneEventType.LoadFailure.ToString()+(e as SceneEventArgs).SceneName; if (m_IEventPoolManager.HasTopic(t_TopicName)) m_IEventPoolManager.PublishTopicSmart(t_TopicName,o,e);  };
            LoadSuccessEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicSmart(SceneEventType.LoadSuccess.ToString(), o, e); var t_TopicName = SceneEventType.LoadSuccess.ToString() + (e as SceneEventArgs).SceneName; if (m_IEventPoolManager.HasTopic(t_TopicName)) m_IEventPoolManager.PublishTopicSmart(t_TopicName, o, e);  };
            LoadUpdateEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicSmart(SceneEventType.LoadUpdate.ToString(), o, e); var t_TopicName = SceneEventType.LoadUpdate.ToString() + (e as SceneEventArgs).SceneName; if (m_IEventPoolManager.HasTopic(t_TopicName)) m_IEventPoolManager.PublishTopicSmart(t_TopicName, o, e); };

            UnLoadFailureEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicSmart(SceneEventType.UnLoadFailure.ToString(), o, e); var t_TopicName = SceneEventType.UnLoadFailure.ToString() + (e as SceneEventArgs).SceneName; if (m_IEventPoolManager.HasTopic(t_TopicName)) m_IEventPoolManager.PublishTopicSmart(t_TopicName, o, e);};
            UnLoadSuccessEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicSmart(SceneEventType.UnLoadSuccess.ToString(), o, e); var t_TopicName = SceneEventType.UnLoadSuccess.ToString() + (e as SceneEventArgs).SceneName; if (m_IEventPoolManager.HasTopic(t_TopicName)) m_IEventPoolManager.PublishTopicSmart(t_TopicName, o, e); };
            UnLoadUpdateEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicSmart(SceneEventType.UnLoadUpdate.ToString(), o, e); var t_TopicName = SceneEventType.UnLoadUpdate.ToString() + (e as SceneEventArgs).SceneName; if (m_IEventPoolManager.HasTopic(t_TopicName)) m_IEventPoolManager.PublishTopicSmart(t_TopicName, o, e);  };

            MoveToSuccessEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicSmart(SceneEventType.MoveToFailure.ToString(), o, e); var t_TopicName = SceneEventType.MoveToFailure.ToString() + (e as SceneEventArgs).SceneName; if (m_IEventPoolManager.HasTopic(t_TopicName)) m_IEventPoolManager.PublishTopicSmart(t_TopicName, o, e); };
            MoveToFailureEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicSmart(SceneEventType.MoveToSuccess.ToString(), o, e); var t_TopicName = SceneEventType.MoveToSuccess.ToString() + (e as SceneEventArgs).SceneName; if (m_IEventPoolManager.HasTopic(t_TopicName)) m_IEventPoolManager.PublishTopicSmart(t_TopicName, o, e); };
            MoveToUpdateEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicSmart(SceneEventType.MoveToUpdate.ToString(), o, e); var t_TopicName = SceneEventType.MoveToUpdate.ToString() + (e as SceneEventArgs).SceneName; if (m_IEventPoolManager.HasTopic(t_TopicName)) m_IEventPoolManager.PublishTopicSmart(t_TopicName, o, e);  };

        }



        /// <summary>
        /// 注册事件经纪人所管辖的发布者或者订阅者
        /// </summary>
        /// <param name="t_Target"></param>
        public void Register(object t_Target)
        {
            var t_Type = t_Target.GetType();

            var t_Methods = t_Type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            for (int i = 0; i < t_Methods.Length; i++)
            {
                var t_CustomAttributes = t_Methods[i].GetCustomAttributes(false);
                for (int j = 0; j < t_CustomAttributes.Length; j++)
                {
                    if (t_CustomAttributes[j] is SceneEventAttribute)//订阅者
                    {
                        var t_SceneEventAttribute = t_CustomAttributes[j] as SceneEventAttribute;
                        var t_TargetTopicName = t_SceneEventAttribute.SceneEventTopicName+ t_SceneEventAttribute.SceneName;
                        if (m_IEventPoolManager.HasTopic(t_TargetTopicName)) //如果存在这个主题
                        {
                            m_IEventPoolManager.GetEventTopic(t_TargetTopicName).AddSubscriber(DelegateHelper.CreateDelegate(t_Methods[i], t_Target)); //添加订阅者
                        }
                        else //如果不存在
                        {
                            m_IEventPoolManager.CreateEventTopic(t_TargetTopicName).AddSubscriber(DelegateHelper.CreateDelegate(t_Methods[i], t_Target)); //添加订阅者
                        }
                    }
                }
            }

        }



    }
}
