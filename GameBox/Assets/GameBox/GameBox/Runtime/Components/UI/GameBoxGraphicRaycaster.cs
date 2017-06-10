/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System;
using GameBoxFramework;

namespace GameBox.Runtime.Component
{
    /// <summary>
    /// GameBoxGraphicRaycaster组件
    /// </summary>
    public sealed class GameBoxGraphicRaycaster : GraphicRaycaster
    {
        private UIEventComponent m_UIEventComponent;


        protected override void Start()
        {
            base.Start();

            UIEventComponent[] t_UIEventComponents = GameBoxEntry.GetComponents<UIEventComponent>();
            if (null== t_UIEventComponents)
            {
                throw new GameBoxFrameworkException("场景必须要有UIEventComponent组件.");
            }
            else if(1<t_UIEventComponents.Length)
            {
                throw new GameBoxFrameworkException("场景有且只能有一个UIEventComponent组件.");
            }else if (0 < t_UIEventComponents.Length)
            {
                m_UIEventComponent = t_UIEventComponents[0];
            }
           
        }

        public event Action<object, UIEventArgs> UIEventHandler;

        public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
        {
            base.Raycast(eventData, resultAppendList);

            m_UIEventComponent.UpdateUIEventData(this, eventData, resultAppendList); //更新UIEventComponent组件事件参数

        }


    }
}