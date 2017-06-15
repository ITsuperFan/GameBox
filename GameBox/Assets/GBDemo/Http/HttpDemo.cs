/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox;
using GameBox.Runtime.Component;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameBoxFramework
{
	internal sealed class HttpDemo : MonoBehaviour 
	{
        private HttpComponent m_HttpComponent;

        private void Start()
        {

            m_HttpComponent = GameBoxEntry.GetComponent<HttpComponent>();
            m_HttpComponent.Register(this);

        }

        [HttpEvent( HttpRequstType.Get )]
        private void HttpEventFunctionGetDemo(object t_Sender,HttpEventArgs t_HttpEventArgs)
        {
            Debug.Log("通过事件池的形式监听的Http Get 请求返回数据的事件: "+ t_HttpEventArgs.HttpResponseData.StringData);
        }

        [HttpEvent(HttpRequstType.Post)]
        private void HttpEventFunctionPostDemo(object t_Sender, HttpEventArgs t_HttpEventArgs)
        {
            Debug.Log("通过事件池的形式监听的Http Post 请求返回数据的事件: " + t_HttpEventArgs.HttpResponseData.StringData);

        }

        [HttpEvent(HttpRequstType.Get, @"https://www.baidu.com")]
        private void HttpEventFunctionGetWithDemoURL1(object t_Sender, HttpEventArgs t_HttpEventArgs)
        {
            Debug.Log(@"https://www.baidu.com"+"通过事件池的形式监听的Http Get 请求返回数据的事件: " + t_HttpEventArgs.HttpResponseData.StringData);
        }

        [HttpEvent(HttpRequstType.Get, @"https://m.baidu.com")]
        private void HttpEventFunctionGetWithDemoURL2(object t_Sender, HttpEventArgs t_HttpEventArgs)
        {
            Debug.Log(@"https://m.baidu.com"+"通过事件池的形式监听的Http Get 请求返回数据的事件: " + t_HttpEventArgs.HttpResponseData.StringData);
        }



        private string t_StringData=string.Empty; //存储服务器返回的数据
        private void OnGUI()
        {
            if (GUILayout.Button("HTTP Get https://www.baidu.com"))
            {
                m_HttpComponent.Get(new HttpRequestData(@"https://www.baidu.com"),(o,e)=> {

                    var t_HttpEventArgs = e as HttpEventArgs;
                    Debug.Log("https://www.baidu.com 打印出服务器返回的数据是什么: " + (t_StringData = t_HttpEventArgs.HttpResponseData.StringData));

                });
            }

            if (GUILayout.Button("HTTP Get https://m.baidu.com"))
            {
                m_HttpComponent.Get(new HttpRequestData(@"https://m.baidu.com"), (o, e) => {

                    var t_HttpEventArgs = e as HttpEventArgs;
                    Debug.Log("https://m.baidu.com 打印出服务器返回的数据是什么: " + (t_StringData = t_HttpEventArgs.HttpResponseData.StringData));

                });
            }

            if (GUILayout.Button("HTTP Post"))
            {
                var t_Form = new Dictionary<string, string>(); //Post的表单数据
                t_Form.Add("action","addLike");
                t_Form.Add("um_id", "174");
                t_Form.Add("um_action", "ding");

                m_HttpComponent.Post(new HttpRequestData("http://0x69h.com/wp-admin/admin-ajax.php", t_Form), (o, e) => {

                    var t_HttpEventArgs = e as HttpEventArgs;
                    Debug.Log("打印出服务器返回的数据是什么: " + (t_StringData = t_HttpEventArgs.HttpResponseData.StringData));
                    
                });
            }

            //GUILayout.Label(t_StringData);  //GUI 显示有限
        }

    }
}