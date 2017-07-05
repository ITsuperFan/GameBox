/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using GameBox.Runtime.Component;
using UnityEngine;
using UnityEngine.UI;

namespace Alan
{
    using GameBox;
    public class ActiveEventDemo : MonoBehaviour 
	{
        [SerializeField]
        private Button m_Button;


        private void Start()
        {
            GameBox.GetComponent<ActiveEventComponent>().LoadActiveEventAssembly<ActiveEventHandler>();
            m_Button.onClick.AddListener(()=> {
                GameBox.GetComponent<ActiveEventComponent>().CallActiveEvent("有效事件方法名",m_Button.gameObject,m_Button.GetComponent<Image>(), m_Button.GetComponentInChildren<Text>());
            });

        }
    }
}