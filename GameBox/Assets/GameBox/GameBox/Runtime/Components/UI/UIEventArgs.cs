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

namespace GameBox.Runtime.Component
{
    [Serializable]
    public class UIEventArgs : BaseEventArgs 
	{
        public GameObject pointerEnter;
        public GameObject pointerPress;
        public GameObject rawPointerPress;
        public GameObject lastPress;
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
        public bool eligibleForClick;

    }
}