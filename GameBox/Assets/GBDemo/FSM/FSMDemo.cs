/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using UnityEngine;
using GameBoxFramework.Runtime.FSM;
using GameBoxFramework;
using GameBox.Extension;

namespace Alan
{
    public class FSMDemo : MonoBehaviour 
	{
        private IFSMManager m_IFSMManager;
        private FSM m_FSM;

        private void OnGUI()
        {
            if (GUILayout.Button("Click"))
            {
                m_IFSMManager = gameObject.GetBuiltInModule<IFSMManager>();
                m_FSM = m_IFSMManager.CreateFSM("Demo", new StateOne());
                m_FSM.ChangeState<StateOne>();
            }

        }

    }
}