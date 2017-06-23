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
        [SerializeField]
        private Text m_Text;

        private void Start()
        {
            GameBoxEntry.GetComponent<UIEventComponent>().Register(this);
        }

        [UIEvent(UIEventType.UpEvent)]
        private void UIEventDemo_OnClickEventHandler00(GameObject arg1, UIEventArgs arg2)
        {
            // m_Cube.transform.localScale = Vector3.one*i++;
            // m_Cube.name = arg2.lastPress.name;
            //Debug.Log("所有的按钮名字:  " + arg1.name);
            //arg1.GetComponent<Graphic>().color = Color.yellow;

            m_Text.text = "UpEvent ：" + arg2.lastPress.name;

            arg1.GetComponent<Graphic>().color = Random.Range(1, 10) > 5 ? Color.yellow : Color.red;
        }

        [UIEvent(UIEventType.PressEvent)]
        private void UIEventDemo_OnClickEventHandler0(GameObject arg1, UIEventArgs arg2)
        {
            m_Text.text = "PressEvent ：" + arg2.pointerPress.name;

            //Debug.Log("所有的按钮名字:  " + arg1.name);

        }


        [UIEvent( UIEventType.ClickEvent,"Scene1_Canvas1_Button_Alan")]
        private void UIEventDemo_OnClickEventHandler1(object arg1, UIEventArgs arg2)
        {
            //Debug.Log("private:  " + arg1);
            //(arg1 as GameObject).GetComponent<Graphic>().color = Color.green;

        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  

        [UIEvent(UIEventType.DragEvent)]
        public void UIEventDemo_OnClickEventHandler2(object arg1, UIEventArgs arg2)
        {
            //Debug.Log("public:  " + arg1);
        }

        //[UIEvent(UIEventType.PressEvent)]
        protected void UIEventDemo_OnClickEventHandler3(object arg1, UIEventArgs arg2)
        {
            //Debug.Log("protected:  " + arg1);
        }

        private void Update()
        {

                // Debug.Log(EventSystem.current.currentSelectedGameObject+"   "+ EventSystem.current);

        }


    }
}