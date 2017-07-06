/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GameBoxFramework.EventPool;
using System.Reflection;
using GameBoxFramework;

namespace GameBox.Runtime.Component
{


    /// <summary>
    /// UIEventComponent组件
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("GameBox/UIEvent")]
    [RequireComponent(typeof(GameBoxGraphicRaycaster))]
    public sealed class UIEventComponent : BaseGameBoxComponent
	{
        [SerializeField]
        private UIEventArgs m_UIEventData = new UIEventArgs();
        /// <summary>
        /// 实时更新的数据
        /// </summary>
        public UIEventArgs UIEventData { get { return m_UIEventData; }}
        //[SerializeField]
        private bool hoverOnceControl; //悬停控制
        //[SerializeField] 
        private bool clickOnceControl; //点击控制
        //[SerializeField] 
        private bool dragOnceControl; //滑动处理

#if (UNITY_ANDROID || UNITY_IPHONE)  && !UNITY_EDITOR
        private int m_OnPressTouchCount; //在移动端按下的时候的触屏数目
        private float m_PressRealTime; //按下的时候的实时秒数
#endif


        public event EventHandler OnEnterEventHandler; //悬停事件
        public event EventHandler OnHoverEventHandler; //悬停事件
        public event EventHandler OnExitEventHandler; //按下后抬起事件

        public event EventHandler OnDownEventHandler; //按下事件
        public event EventHandler OnPressEventHandler; //按住事件
        public event EventHandler OnClickEventHandler; //点击事件
        public event EventHandler OnUpEventHandler; //抬起事件

        public event EventHandler OnBeginDragEventHandler; //开始滑动事件
        public event EventHandler OnDragEventHandler; //滑动事件
        public event EventHandler OnEndDragEventHandler; //结束滑动事件



        /// <summary>
        /// 事件池管家接口
        /// </summary>
        private IEventPoolManager m_IEventPoolManager = null;

        protected override void Awake()
        {
            base.Awake();
            m_IEventPoolManager = GameBox.App.Driver.GetModule<IEventPoolManager>();
            if (null == m_IEventPoolManager)
            {
                throw new GameBoxFrameworkException("IEventPoolManager是无效的！");
            }

            RegisterUIEventTopic(); //注册UI事件主题


        }

        /// <summary>
        /// 更新UIEventData 
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="resultAppendList"></param>
        public void UpdateUIEventData(GameBoxGraphicRaycaster t_Raycaster, PointerEventData t_EventData, List<RaycastResult> t_ResultAppendList)
        {
            //Debug.Log(t_EventData.ToString());

            #region 更新事件参数
            UIEventData.pointerEnter = t_EventData.pointerEnter;
            UIEventData.pointerPress = t_EventData.pointerPress;
            UIEventData.rawPointerPress = t_EventData.rawPointerPress;
            UIEventData.pointerDrag = t_EventData.pointerDrag;
            UIEventData.hovered = t_EventData.hovered;
            UIEventData.isPointerMoving = t_EventData.IsPointerMoving();
            UIEventData.isScrolling = t_EventData.IsScrolling();
            UIEventData.clickCount = t_EventData.clickCount;
            UIEventData.lastPress = t_EventData.lastPress;
            UIEventData.selectedObject = t_EventData.selectedObject;
            UIEventData.eligibleForClick = t_EventData.eligibleForClick;
            UIEventData.dragging = t_EventData.dragging;
            UIEventData.useDragThreshold = t_EventData.useDragThreshold;
            UIEventData.enterEventCamera = t_EventData.enterEventCamera;
            UIEventData.pressEventCamera = t_EventData.pressEventCamera;
            UIEventData.position = t_EventData.position;
            UIEventData.pressPosition = t_EventData.pressPosition;
            UIEventData.clickTime = t_EventData.clickTime;
            #endregion

            #region 悬停处理
            if (null == t_EventData.pointerPress && null != t_EventData.pointerEnter && !hoverOnceControl) //悬停进入处理
            {
                //Debug.Log("悬停进入");
                if (null!= OnEnterEventHandler)
                {
                    OnEnterEventHandler(t_EventData.pointerEnter, UIEventData);
                }
                UIEventData.lastEnter = t_EventData.pointerEnter;
                hoverOnceControl = true;
            }

            if (null == t_EventData.pointerPress && null != t_EventData.pointerEnter) //悬停停留处理
            {
                //Debug.Log("悬停停留");
                if (null != OnHoverEventHandler)
                {
                    OnHoverEventHandler(t_EventData.pointerEnter, UIEventData);
                }
            }

            if (null == t_EventData.pointerPress && null == t_EventData.pointerEnter && hoverOnceControl) //悬停移出处理
            {
                //Debug.Log("悬停移出");
                if (null != OnExitEventHandler)
                {
                    OnExitEventHandler(UIEventData.lastEnter, UIEventData);
                }
                hoverOnceControl = false;
            }

            #endregion

            #region 按键处理

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
            if (null != t_EventData.pointerPress && !clickOnceControl) //按下和点击处理
            {
                //Debug.Log("按下");
                if (null != OnDownEventHandler)
                {
                    OnDownEventHandler(t_EventData.pointerPress, UIEventData);
                }
                //Debug.Log("点击");
                if (null != OnClickEventHandler)
                {
                    OnClickEventHandler(t_EventData.pointerPress, UIEventData);
                }
                clickOnceControl = true;
            }

            if (null != t_EventData.pointerPress) //按住处理
            {
                //Debug.Log("按住");
                if (null != OnPressEventHandler)
                {
                    OnPressEventHandler(t_EventData.pointerPress, UIEventData);
                }
            }

            if (null != t_EventData.lastPress && clickOnceControl) //抬起处理
            {
                //Debug.Log("抬起");
                if (null != OnUpEventHandler)
                {
                    OnUpEventHandler(t_EventData.lastPress, UIEventData);
                }
                clickOnceControl = false;
            }
#endif

#if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR

            if (0<Input.touchCount && null != t_EventData.pointerPress && !clickOnceControl) //屏幕有触摸点 && 按下和点击处理
            {
                //Debug.Log("按下");
                if (null != OnDownEventHandler)
                {
                    OnDownEventHandler(t_EventData.pointerPress, UIEventData);
                }
                //Debug.Log("点击");
                if (null != OnClickEventHandler)
                {
                    OnClickEventHandler(t_EventData.pointerPress, UIEventData);
                }
                m_OnPressTouchCount = Input.touchCount; //按下的那一刻的触屏数目
                clickOnceControl = true;
                info1 = "按下" + Time.deltaTime;
            }

            //按下的时候 可以 其他手指 也可以触摸屏幕
            if (m_OnPressTouchCount <= Input.touchCount && null != t_EventData.pointerPress) //按住处理
            {
                //Debug.Log("按住");
                if (null != OnPressEventHandler)
                {
                    OnPressEventHandler(t_EventData.pointerPress, UIEventData);
                }
                info2 = "按住"+Time.deltaTime+"  "+(Time.realtimeSinceStartup - m_PressRealTime);
                m_PressRealTime = Time.realtimeSinceStartup;
            }

            if (0.01f<(Time.realtimeSinceStartup - m_PressRealTime) && clickOnceControl) //抬起处理
            {
                //Debug.Log("抬起");
                clickOnceControl = false;
                info3 = "抬起"+Time.deltaTime;
                if (null != OnUpEventHandler)
                {
                    OnUpEventHandler(UIEventData.lastPress, UIEventData);
                }
                UIEventData.lastPress = t_EventData.pointerPress; //保存上一次的按下 刷新
                m_OnPressTouchCount = 0;
                
            }

            info4 = t_EventData.ToString()+"   \n"+Time.deltaTime.ToString();

#endif


            #endregion

            #region 滑动处理
            if (null != t_EventData.pointerDrag && !dragOnceControl) //开始滑动处理
            {
                //Debug.Log("开始滑动处理");
                if (null != OnBeginDragEventHandler)
                {
                    OnBeginDragEventHandler(t_EventData.pointerDrag, UIEventData);
                }
                UIEventData.lastDrag = t_EventData.pointerDrag;
                dragOnceControl = true;
            }

            if (null != t_EventData.pointerDrag) //滑动中处理
            {
                //Debug.Log("滑动中处理");
                if (null != OnDragEventHandler)
                {
                    OnDragEventHandler(t_EventData.pointerDrag, UIEventData);
                }
            }

            if (null == t_EventData.pointerDrag && dragOnceControl) //结束滑动处理
            {
                //Debug.Log("结束滑动处理");
                if (null != OnEndDragEventHandler)
                {
                    OnEndDragEventHandler(UIEventData.lastDrag, UIEventData);
                }
                dragOnceControl = false;
            }
            #endregion

            
        }

        /// <summary>
        /// 注册UI事件主题
        /// </summary>
        private void RegisterUIEventTopic()
        {

            m_IEventPoolManager.CreateEventTopic("EnterEvent"); //创建EnterEvent广播主题
            m_IEventPoolManager.CreateEventTopic("HoverEvent");//创建HoverEvent广播主题
            m_IEventPoolManager.CreateEventTopic("ExitEvent");//创建ExitEvent广播主题
            m_IEventPoolManager.CreateEventTopic("DownEvent");//创建DownEvent广播主题
            m_IEventPoolManager.CreateEventTopic("ClickEvent");//创建ClickEvent广播主题
            m_IEventPoolManager.CreateEventTopic("PressEvent");//创建PressEvent广播主题
            m_IEventPoolManager.CreateEventTopic("UpEvent");//创建UpEvent广播主题
            m_IEventPoolManager.CreateEventTopic("BeginDragEvent");//创建BeginDragEvent广播主题
            m_IEventPoolManager.CreateEventTopic("DragEvent");//创建DragEvent广播主题
            m_IEventPoolManager.CreateEventTopic("EndDragEvent");//创建EndDragEvent广播主题


            OnEnterEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicNow("EnterEvent", o, e); var t_TargetName = "EnterEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //悬停事件
            OnHoverEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicNow("HoverEvent", o, e); var t_TargetName = "HoverEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //悬停事件
            OnExitEventHandler += (o, e) => {  m_IEventPoolManager.PublishTopicNow("ExitEvent", o, e);   var t_TargetName = "ExitEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //按下后抬起事件
            OnDownEventHandler += (o, e) => {  m_IEventPoolManager.PublishTopicNow("DownEvent", o, e);   var t_TargetName = "DownEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //按下事件
            OnPressEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicNow("PressEvent", o, e); var t_TargetName = "PressEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //按住事件
            OnClickEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicNow("ClickEvent", o, e); var t_TargetName = "ClickEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //点击事件
            OnUpEventHandler += (o, e) => {    m_IEventPoolManager.PublishTopicNow("UpEvent", o, e);       var t_TargetName = "UpEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //抬起事件
            OnBeginDragEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicNow("BeginDragEvent", o, e); var t_TargetName = "BeginDragEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //开始滑动事件
            OnDragEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicNow("DragEvent", o, e); var t_TargetName = "DragEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //滑动事件
            OnEndDragEventHandler += (o, e) => { m_IEventPoolManager.PublishTopicNow("EndDragEvent", o, e); var t_TargetName = "EndDragEvent" + (o as GameObject).name; if (m_IEventPoolManager.HasTopic(t_TargetName)) { m_IEventPoolManager.PublishTopicNow(t_TargetName, o, e); } }; //结束滑动事件

        }

        /// <summary>
        /// 注册事件经纪人所管辖的发布者或者订阅者
        /// </summary>
        /// <param name="t_Target"></param>
        public void Register(object t_Target)
        {
            var t_Type = t_Target.GetType();

            var t_Methods = t_Type.GetMethods(BindingFlags.Instance |BindingFlags.NonPublic | BindingFlags.Public);
            for (int i = 0; i < t_Methods.Length; i++)
            {
                var t_CustomAttributes = t_Methods[i].GetCustomAttributes(false);
                for (int j = 0; j < t_CustomAttributes.Length; j++)
                {
                    if (t_CustomAttributes[j] is UIEventAttribute)//订阅者
                    {
                        var t_UIEventAttribute = t_CustomAttributes[j] as UIEventAttribute;
                        var t_TargetTopicName = t_UIEventAttribute.UIEventTopicName + (t_UIEventAttribute.UIWidgetName??string.Empty);
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

        #if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR
        private string info1;
        private string info2;
        private string info3;
        private string info4;

        private void OnGUI()
        {
            GUILayout.Label(UIEventData.ToString());
            GUILayout.Label("系统触摸数目: " + Input.touchCount);
            GUILayout.Label("记录触摸数目: " + m_OnPressTouchCount);
            GUILayout.Label("Debug: " + info1);
            GUILayout.Label("Debug: " + info2);
            GUILayout.Label("Debug: " + info3);
            GUILayout.Label("Debug: " + info4);
        }
        #endif
    }
}