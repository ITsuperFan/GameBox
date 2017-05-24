/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework.Runtime.FSM;

namespace GameBoxFramework
{
    public sealed class StateOne : FSMState
    {

        protected override void StateInit(IFSM t_FSMOwner) { UnityEngine.Debug.Log("StateOne Init..."); }
        protected override void StateEnter(IFSM t_FSMOwner) { UnityEngine.Debug.Log("StateOne Enter..."); }
        protected override void StateLoop(IFSM t_FSMOwner) { UnityEngine.Debug.Log("StateOne Loop..."); }
        protected override void StateExit(IFSM t_FSMOwner) { UnityEngine.Debug.Log("StateOne Exit..."); }
        protected override void StateDestroy(IFSM t_FSMOwner) { UnityEngine.Debug.Log("StateOne Destroy..."); }
    }
}