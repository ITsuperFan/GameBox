/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox;
using GameBox.Runtime.Component;
using UnityEngine;

namespace Alan
{
    public class ObjectPoolDemo : MonoBehaviour 
	{
        /// <summary>
        /// 对象池组件
        /// </summary>
        private ObjectPoolComponent m_ObjectPoolComponent;

        [SerializeField]
        private GameObject m_Target;

        private void Start()
        {
            m_ObjectPoolComponent = GameBoxEntry.GetComponent<ObjectPoolComponent>();
            //m_ObjectPoolComponent.CreateSingleSpawnObjectPool<GameObject>();
        }

      


    }
}