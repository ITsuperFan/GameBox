/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using UnityEngine;
using GameBox.Runtime.Component;
using GameBoxFramework;
using GameBoxFramework.Model;
using GameBoxFramework.Route;

namespace Alan
{
    using GameBox;


    internal class MyModel : Model
    {
        private int UserId; //你可以设定 ORM 之类的
        private string UserName; //你可以设定 ORM 之类的

        /// <summary>
        /// 模型被轮询事件
        /// </summary>
        public override void OnUpdate()
        {
            DataAccess_UpdateUserId();
        }

        /// <summary>
        /// 数据访问
        /// </summary>
        public void DataAccess_UpdateUserId()
        {
            Debug.Log("主动式模型数据轮询访问!");
            UserId = 10086; //假设是模型轮询去访问数据的变动性，比如轮询某个线程的数据处理结果队列
        }


        /// <summary>
        /// 数据访问
        /// </summary>
        public void DataAccess_UpdateUserName()
        {
            Debug.Log("主动式模型数据轮询访问!");
            UserName = "Mr-Alan"; //假设是模型被动去访问数据的变动性，比如被动访问某个线程的数据处理结果队列
        }

        /// <summary>
        /// 业务逻辑
        /// </summary>
        public int Logic_UserIdWithCondition()
        {
            Debug.Log("模型业务处理!-ID");
            return 10000 < UserId ? UserId : 0;
        }

        /// <summary>
        /// 业务逻辑
        /// </summary>
        public string Logic_UserNameWithCondition()
        {
            Debug.Log("模型业务处理!-Name");
            return UserName??"空名字";
        }
    }

    [ModelInvalid]
    internal class MyModelForBoxLook : Model { }

    internal class MyController : Controller
    {
        private int DDD(BaseEventArgs a)
        {
            Debug.Log("控制器处理!  "+(a as RouteDemoEventArgs).GO.name);
            return GameBox.GetBuiltInModule<IModelManager>().GetModel<MyModel>().Logic_UserIdWithCondition();
        }

        private string CCC(BaseEventArgs a)
        {
            Debug.Log("控制器处理!  " + (a as RouteDemoEventArgs).GO.name);
            return GameBox.GetBuiltInModule<IModelManager>().GetModel<MyModel>().Logic_UserNameWithCondition();
        }

    }

    /// <summary>
    /// 自定义路由参数
    /// </summary>
    internal class RouteDemoEventArgs : BaseEventArgs
    {
        public RouteDemoEventArgs(GameObject t_GO) { GO = t_GO; }
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
            GameBox.GetBuiltInModule<IModelManager>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("获取ID"))
            {
                GameBox.GetBuiltInModule<IRouteManager>().Route("MyController@DDD",new RouteDemoEventArgs(gameObject),
                    response=> {

                        Debug.Log(response);

                    });
            }

            if (GUILayout.Button("获取Name"))
            {
                GameBox.GetBuiltInModule<IRouteManager>().Route("MyController@CCC", new RouteDemoEventArgs(gameObject),
                    response => {

                        Debug.Log(response);


                    });
            }

            if (GUILayout.Button("移除MyModel模型"))
            {
                GameBox.GetBuiltInModule<IModelManager>().RemoveModel<MyModel>();
            }

            if (GUILayout.Button("添加MyModel模型"))
            {
                GameBox.GetBuiltInModule<IModelManager>().GetModel<MyModel>();
            }

        }
    }
}
