/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/



using GameBoxFramework.Runtime.FSM;

namespace Alan
{
    public sealed class StateTwo : FSMState
    {

        protected override void StateInit(IFSM t_StateOwner) { UnityEngine.Debug.Log("StateTwo Init..."); }
        protected override void StateEnter(IFSM t_StateOwner) { UnityEngine.Debug.Log("StateTwo Enter..."); }
        protected override void StateLoop(IFSM t_StateOwner) { UnityEngine.Debug.Log("StateTwo Loop..."); }
        protected override void StateExit(IFSM t_StateOwner) { UnityEngine.Debug.Log("StateTwo Exit..."); }
        protected override void StateDestroy(IFSM t_StateOwner) { UnityEngine.Debug.Log("StateTwo Destroy..."); }
    }
}