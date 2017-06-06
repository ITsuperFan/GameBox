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

    public enum MonoFSMDemoState
    {

        Init,
        State1,
        State2,


    }

    public class MonoFSMDemo : MonoBehaviour 
	{
        private IMonoFSM<MonoFSMDemoState> m_IMonoFSM=null;
        

        private void Start()
        {

            m_IMonoFSM =   GameBoxEntry.GetComponent<MonoFSMManagerComponent>().CreateMonoFSM<MonoFSMDemoState>(this);

        }

        private void OnGUI()
        {
            if (GUILayout.Button("更改到State1状态"))
            {
                m_IMonoFSM.ChangeState( MonoFSMDemoState.State1 );
            }
            else if(GUILayout.Button("更改到State2状态"))
            {
                m_IMonoFSM.ChangeState(MonoFSMDemoState.State2);
            }


        }


        private void Init_Enter()
        {
            Debug.Log("Init_Enter");
        }

        private void Init_Update()
        {
            Debug.Log("Init_Update");
        }

        private void Init_Exit()
        {
            Debug.Log("Init_Exit");
        }



        private void State1_Enter()
        {
            Debug.Log("State1_Enter");
        }

        private void State1_Update()
        {
            Debug.Log("State1_Update");
        }

        private void State1_Exit()
        {
            Debug.Log("State1_Exit");
        }



        private void State2_Enter()
        {
            Debug.Log("State2_Enter");
        }

        private void State2_Update()
        {
            Debug.Log("State2_Update");
        }

        private void State2_Exit()
        {
            Debug.Log("State2_Exit");
        }


    }
}