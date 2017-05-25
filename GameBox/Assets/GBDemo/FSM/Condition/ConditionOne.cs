/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework.Runtime.FSM;


namespace Alan
{
    public class ConditionOne : FSMCondition
    {


        public override void ConditionInit(IFSM t_ConditionOwner)
        {
           
        }

        public override bool ConditionLoop(IFSM t_ConditionOwner)
        {
            UnityEngine.Debug.Log("ConditionOne ConditionLoop");
            return false;
        }

        public override void ConditionDestroy(IFSM t_ConditionOwner)
        {

        }


    }
}