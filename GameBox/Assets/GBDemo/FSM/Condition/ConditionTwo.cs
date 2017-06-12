/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework.FSM;

namespace Alan
{
    public class ConditionTwo : FSMCondition
    {


        public override void ConditionInit(IFSM t_ConditionOwner)
        {
            UnityEngine.Debug.Log("ConditionInit");
        }

        public override bool ConditionLoop(IFSM t_ConditionOwner)
        {
            UnityEngine.Debug.Log("ConditionTwo ConditionLoop");
            return true;
        }

        public override void ConditionDestroy(IFSM t_ConditionOwner)
        {
            UnityEngine.Debug.Log("ConditionDestroy");
        }


    }
}