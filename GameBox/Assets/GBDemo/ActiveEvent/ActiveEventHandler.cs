/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework.Event;
using UnityEngine;
using UnityEngine.UI;

namespace Alan
{
	public class ActiveEventHandler 
	{
        [ActiveEvent("有效事件方法名")]
        public static void ActiveEventDemoHandler(GameObject t_GO,Image t_Img,Text t_Text)
        {
            t_GO.name = "有效事件处理的游戏物体_处理者的签名是"+typeof(ActiveEventHandler).FullName;

            t_Img.color = Color.green;

            t_Text.text = "有效事件处理的渲染文字";
        }

	}
}