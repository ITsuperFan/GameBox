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
using UnityEngine.UI;

namespace Alan
{
    public class UIEventDemo : MonoBehaviour
	{

        private void Start()
        {
            GameBoxEntry.GetComponent<UIEventComponent>().Register(this);
        }

        [UIEvent( UIEventType.ClickEvent,"Button_Alan")]
        private void UIEventDemo_OnClickEventHandler1(object arg1, UIEventArgs arg2)
        {
            Debug.Log("private:  " + arg1);
            (arg1 as GameObject).GetComponent<Graphic>().color = Color.green;

        }

        [UIEvent(UIEventType.DragEvent)]
        public void UIEventDemo_OnClickEventHandler2(object arg1, UIEventArgs arg2)
        {
            Debug.Log("public:  " + arg1);
        }

        //[UIEvent(UIEventType.PressEvent)]
        protected void UIEventDemo_OnClickEventHandler3(object arg1, UIEventArgs arg2)
        {
            Debug.Log("protected:  " + arg1);
        }

        private void Update()
        {

                // Debug.Log(EventSystem.current.currentSelectedGameObject+"   "+ EventSystem.current);

        }


    }
}