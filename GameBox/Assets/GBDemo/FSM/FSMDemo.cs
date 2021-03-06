﻿/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox.Runtime.Component;
using GameBoxFramework.FSM;
using UnityEngine;

namespace Alan
{
    using GameBox;
    public class FSMDemo : MonoBehaviour 
	{
        private FSMComponent m_FSMManager;
        private IFSM m_IFSM;

        private void Start()
        {
            //  yield return new WaitForSeconds(2f);

            m_FSMManager = GameBox.GetComponent<FSMComponent>(); //获取状态机管家组件
            m_IFSM = m_FSMManager.CreateFSM("Demo"); //创建一个状态机
            m_IFSM.AddState<StateOne>();
            m_IFSM.AddState(typeof(StateTwo));
            m_IFSM.AddCondition<ConditionOne>();
            m_IFSM.AddCondition<ConditionTwo>();
            m_IFSM.ChangeState<StateOne>(); //初始状态

        }

        private void OnGUI()
        {
            if (GUILayout.Button("ChangeState StateOne"))
            {
                m_IFSM.ChangeState<StateOne>();
            }

            if (GUILayout.Button("ChangeState StateTwo"))
            {
                m_IFSM.ChangeState<StateTwo>();
            }

            if (GUILayout.Button("Update Condition State"))
            {
                m_IFSM.GetCondition<ConditionTwo>().UpdateState<StateTwo>();
            }
        }

    }
}