/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox;
using GameBox.Runtime.Component;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Alan
{
    public class UIEventDemo : MonoBehaviour
	{

        private void Awake()
        {
            GameBoxEntry.GetComponent<UIEventComponent>().OnClickEventHandler += UIEventDemo_OnClickEventHandler;
           

        }


        private void UIEventDemo_OnClickEventHandler(GameObject arg1, UIEventArgs arg2)
        {
            Debug.Log(arg1.name);
        }

        private void Update()
        {

           // Debug.Log(EventSystem.current.currentSelectedGameObject+"   "+ EventSystem.current);

        }


    }
}