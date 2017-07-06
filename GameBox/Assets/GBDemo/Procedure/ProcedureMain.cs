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
    public sealed class ProcedureMain : BaseProcedure
    {

        protected override void ProcedureInit(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureMain ProcedureInit");
        }
        protected override void ProcedureEnter(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureMain ProcedureEnter");
        }
        protected override void ProcedureLoop(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureMain ProcedureLoop " + StateStayRealWorldTime+"    "+ StateStayTotalRealWorldTime);
        }
        protected override void ProcedureExit(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureMain ProcedureExit");
        }
        protected override void ProcedureDestroy(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureMain ProcedureDestroy");
        }


    }
}