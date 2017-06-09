/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox.Runtime.Component;
using GameBoxFramework;
using GameBoxFramework.Runtime.EventPool;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// UIEventComponent组件
    /// </summary>
    public sealed class UIEventComponent : BaseGameBoxComponent 
	{
        [SerializeField]
        private UIEventArgs m_UIEventData = new UIEventArgs();

        /// <summary>
        /// 实时更新的数据
        /// </summary>
        public UIEventArgs UIEventData { get { return m_UIEventData; }}

        /// <summary>
        /// UI被点击事件
        /// </summary>
        public event Action<GameObject, UIEventArgs> OnClickEventHandler;



        /// <summary>
        /// 事件池管家接口
        /// </summary>
        private IEventPoolManager m_IEventPoolManager = null;

        protected override void Awake()
        {
            base.Awake();
            m_IEventPoolManager = GameBoxEntry.GetBuiltInModule<IEventPoolManager>();
            if (null == m_IEventPoolManager)
            {
                throw new GameBoxFrameworkException("IEventPoolManager是无效的！");
            }



        }




        /// <summary>
        /// 更新UIEventData 
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="resultAppendList"></param>
        public void UpdateUIEventData(GameBoxGraphicRaycaster t_Raycaster, PointerEventData t_EventData, List<RaycastResult> t_ResultAppendList)
        {


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
            UIEventData.enterEventCamera = t_EventData.enterEventCamera;
            UIEventData.pressEventCamera = t_EventData.pressEventCamera;
            UIEventData.position = t_EventData.position;
            UIEventData.pressPosition = t_EventData.pressPosition;
            UIEventData.clickTime = t_EventData.clickTime;


            if (null!= t_EventData.pointerPress)
            {
                if (null != OnClickEventHandler)
                {
                    OnClickEventHandler(t_EventData.pointerPress, UIEventData);
                }
            }









        }






    }
}