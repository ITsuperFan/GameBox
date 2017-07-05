/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using UnityEngine;

namespace Alan
{
    using GameBox;
    using GameBox.Runtime.Component;
    using GameBoxFramework;
    using GameBoxFramework.Route;

    internal class MyController : Controller
    {
        private int DDD(BaseEventArgs a)
        {
            Debug.Log("控制器处理!");
            return 1000;
        }
    }

    /// <summary>
    /// 自定义路由参数
    /// </summary>
    internal class RouteDemoEventArgs : BaseEventArgs
    {
        public GameObject GO;
    }


    /// <summary>
    /// 路由展示类
    /// </summary>
    internal sealed class RouteDemo : MonoBehaviour 
	{
        private void Awake()
        {
            GameBox.GetBuiltInModule<IRouteManager>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("点击"))
            {
                GameBox.GetBuiltInModule<IRouteManager>().Route("MyController@DDD",new RouteDemoEventArgs(),
                    response=> {

                        Debug.Log(response);


                    });
            }
        }
    }
}
