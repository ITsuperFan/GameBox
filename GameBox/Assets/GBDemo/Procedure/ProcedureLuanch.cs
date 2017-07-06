/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBoxFramework.FSM;
using GameBoxFramework.Procedure;


namespace GameBoxFramework
{
    public sealed class ProcedureLuanch : BaseProcedure
    {

        protected override void ProcedureInit(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureLuanch ProcedureInit");
        }
        protected override void ProcedureEnter(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureLuanch ProcedureEnter");
        }
        protected override void ProcedureLoop(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureLuanch ProcedureLoop "+ StateStayRealWorldTime + "    " + StateStayTotalRealWorldTime);
            if (5f<StateStayRealWorldTime)
            {
                ChangeProcedure<ProcedureMain>();
            }
        }
        protected override void ProcedureExit(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureLuanch ProcedureExit");
        }
        protected override void ProcedureDestroy(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureLuanch ProcedureDestroy");
        }


    }
}