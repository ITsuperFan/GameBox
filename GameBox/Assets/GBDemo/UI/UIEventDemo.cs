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

        private void Start()
        {
            GameBoxEntry.GetComponent<EventBrokerComponent>().Register(this);
        }

        [EventSubscription("EnterEvent")]
        private void UIEventDemo_OnClickEventHandler(object arg1, UIEventArgs arg2)
        {
            Debug.Log(arg1);
        }

        private void Update()
        {

                // Debug.Log(EventSystem.current.currentSelectedGameObject+"   "+ EventSystem.current);

        }


    }
}