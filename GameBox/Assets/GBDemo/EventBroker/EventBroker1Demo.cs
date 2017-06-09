/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework.Runtime.EventPool;
using GameBox.Runtime.Component;
using GameBoxFramework;
using UnityEngine;
using UnityEngine.EventSystems;
using GameBox;

namespace Alan
{
    public class EventBroker1Demo : MonoBehaviour 
	{
        [EventPublication("topic://DemoTopic")]
        public event EventHandler DemoEventHandler;

        private void Start()
        {
            GameBoxEntry.GetComponent<EventBrokerComponent>().Register(this);
            
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Click to Fire the event."))
            {
                if (null!=DemoEventHandler)
                {
                    DemoEventHandler(this, null);
                }
            }

            if (GUILayout.Button("Click to Fire the event by EventBrokerComponent."))
            {
                GameBoxEntry.GetComponent<EventBrokerComponent>().PublishTopicNow("topic://DemoTopic", UnityEngine.GameObject.CreatePrimitive( PrimitiveType.Cube ),null);
            }

        }

        [EventSubscription("topic://DemoTopic")]
        public void DemoMethod1(object t_Sender,BaseEventArgs t_BaseEventArgs)
        {
            Debug.Log(name+"  发布者 : "+ t_Sender.ToString()+ "  发布参数 : " + t_BaseEventArgs);
        }

        [EventSubscription("topic://DemoTopic")]
        public void DemoMethod2(object t_Sender, BaseEventArgs t_BaseEventArgs)
        {
            Debug.Log(name + "  发布者 : " + t_Sender.ToString() + "  发布参数 : " + t_BaseEventArgs);
        }

        [EventSubscription("topic://DemoTopic")]
        public void DemoMethod3(object t_Sender, BaseEventArgs t_BaseEventArgs)
        {
            Debug.Log(name + "  发布者 : " + t_Sender.ToString() + "  发布参数 : " + t_BaseEventArgs);
        }

    }
}