/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using UnityEngine;
using GameBoxFramework.Runtime.FSM;
using GameBoxFramework;
using GameBox;
using GameBox.Runtime.Component;
using System.Collections;

namespace Alan
{
    public class FSMDemo : MonoBehaviour 
	{
        private FSMManagerComponent m_FSMManager;
        private FSM m_FSM;

        private void Start()
        {
          //  yield return new WaitForSeconds(2f);

            m_FSMManager = GameBoxEntry.GetComponent<FSMManagerComponent>();
            m_FSM = m_FSMManager.CreateFSM("Demo", new StateOne(),new StateTwo()); //创建一个状态机
            m_FSM.ChangeState<StateOne>(); //初始状态

        }

        private void OnGUI()
        {
            if (GUILayout.Button("ChangeState StateOne"))
            {
                m_FSM.ChangeState<StateOne>();
            }

            if (GUILayout.Button("ChangeState StateTwo"))
            {
                m_FSM.ChangeState<StateTwo>();
            }
        }

    }
}