/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;
using UnityEngine;
using GameBoxFramework;
using System.Collections.Generic;
using System.Text;

namespace GameBox.Runtime.Component
{
    [Serializable]
    public class UIEventArgs : BaseEventArgs 
	{
        public GameObject pointerEnter;
        public GameObject pointerPress;
        public GameObject rawPointerPress;
        public GameObject lastPress;
        public GameObject lastEnter;
        public GameObject lastDrag;
        public GameObject pointerDrag;
        public GameObject selectedObject;
        public Camera enterEventCamera;
        public Camera pressEventCamera;
        public Vector2 position;
        public Vector2 pressPosition;
        public List<GameObject> hovered;
        public int clickCount;
        public float clickTime;
        public bool isPointerMoving;
        public bool isScrolling;
        public bool dragging;
        public bool eligibleForClick;
        public bool useDragThreshold;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("\n pointerEnter:  " + (null!=pointerEnter ? pointerEnter.name:"Nil"));
            sb.Append("\n pointerPress:  " + (null!= pointerPress ? pointerPress.name:"Nil"));
            sb.Append("\n rawPointerPress:  " + (null!= rawPointerPress ? rawPointerPress.name:"Nil"));
            sb.Append("\n lastPress:  " + (null!= lastPress ? lastPress.name:"Nil"));
            sb.Append("\n lastEnter:  " + (null!= lastEnter ? lastEnter.name:"Nil"));
            sb.Append("\n lastDrag:  " + (null!= lastDrag ? lastDrag.name:"Nil"));
            sb.Append("\n pointerDrag:  " + (null!= pointerDrag ? pointerDrag.name:"Nil"));
            sb.Append("\n selectedObject:  " + (null!= selectedObject ? selectedObject.name:"Nil"));
            sb.Append("\n enterEventCamera:  " + (null!= enterEventCamera ? enterEventCamera.name:"Nil"));
            sb.Append("\n pressEventCamera:  " + (null!= pressEventCamera ? pressEventCamera.name: "Nil"));

            sb.Append("\n position:  " + position);
            sb.Append("\n pressPosition:  " + pressPosition);
            for (int i = 0; i < hovered.Count; i++)
            {
                sb.Append("\n hovered:  " + hovered[i]);
            }
            sb.Append("\n clickCount:  " + (clickCount));
            sb.Append("\n clickTime:  " + (clickTime));
            sb.Append("\n isPointerMoving:  " + (isPointerMoving));
            sb.Append("\n isScrolling:  " + (isScrolling));
            sb.Append("\n dragging:  " + (dragging));
            sb.Append("\n eligibleForClick:  " + (eligibleForClick));
            sb.Append("\n useDragThreshold:  " + (useDragThreshold));
            return sb.ToString();
        
        }
    }
}