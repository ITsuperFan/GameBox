/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox.Extension;
using GameBox.Runtime.Component;
using GameBoxFramework.ObjectPool;
using UnityEngine;

namespace Alan
{
    using GameBox;
    public class ObjectPoolDemo : MonoBehaviour 
	{
        /// <summary>
        /// 对象池组件
        /// </summary>
        private ObjectPoolComponent m_ObjectPoolComponent;

        private IObjectPool<OPDemo> m_IObjectPoo01;
        private IObjectPool<OPDemo> m_IObjectPoo02;

        [SerializeField]
        private GameObject m_Target;

        private GameObject m_TempObj;

        public class OPDemo : BaseUnityObject
        {
            public OPDemo(string t_Name, GameObject t_GameObject) : base(t_Name, t_GameObject) { }
        }


        private void Start()
        {
            m_ObjectPoolComponent = GameBox.GetComponent<ObjectPoolComponent>();
            m_IObjectPoo01 = m_ObjectPoolComponent.CreateSingleSpawnObjectPool<OPDemo>("对象池01");
            m_IObjectPoo02 = m_ObjectPoolComponent.CreateSingleSpawnObjectPool<OPDemo>("对象池02", 10  , 1);

            m_IObjectPoo01.Register(new OPDemo("对象池01_对象1", GameObject.CreatePrimitive( PrimitiveType.Cube )),false);
            m_IObjectPoo01.Register(new OPDemo("对象池01_对象1", GameObject.CreatePrimitive(PrimitiveType.Cube)),false);
            m_IObjectPoo01.Register(new OPDemo("对象池01_对象1", GameObject.CreatePrimitive(PrimitiveType.Cube)),false);
            m_IObjectPoo01.Register(new OPDemo("对象池01_对象1", GameObject.CreatePrimitive(PrimitiveType.Cube)),false);
            m_IObjectPoo01.Register(new OPDemo("对象池01_对象1", GameObject.CreatePrimitive(PrimitiveType.Cube)),false);
            m_IObjectPoo01.Register(new OPDemo("对象池01_对象1", GameObject.CreatePrimitive(PrimitiveType.Cube)),false);


            m_IObjectPoo02.Register(new OPDemo("对象池02_对象2", m_Target), false);

            m_Target = GameObject.Instantiate(m_Target);
            m_Target.Register<OPDemo>("对象池03_对象1","对象1");
            m_Target = GameObject.Instantiate(m_Target);
            m_Target.Register<OPDemo>("对象池03_对象1", "对象1");

            gameObject.Register<OPDemo>("对象池04_对象1", "对象1");



        }

        private void OnGUI()
        {
            if (GUILayout.Button("Click1"))
            {
                if (m_IObjectPoo01.CanSpawn("对象池01_对象1"))
                {
                    Debug.Log((m_TempObj=m_IObjectPoo01.Spawn("对象池01_对象1").Target as GameObject).name);
                }
            }



            if (GUILayout.Button("Click2"))
            {         
                m_IObjectPoo01.Unspawn(m_TempObj);
            }


            if (GUILayout.Button("Click3"))
            {

                m_Target = gameObject.Spawn<OPDemo>("对象池03_对象1","对象1");
            }

            if (GUILayout.Button("Click4"))
            {

                m_Target.Unspawn<OPDemo>("对象池03_对象1");
            }
        }


    }
}