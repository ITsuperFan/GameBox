/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox;
using GameBox.Runtime.Component;
using GameBoxFramework.FSM;
using GameBoxFramework.Procedure;


namespace Alan
{
    public sealed class ProcedureActiveEventLuanch : BaseProcedure
    {


        #region 事件处理



        #endregion



        protected override void ProcedureInit(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureActiveEventLuanch ProcedureInit");
            GameBoxEntry.GetComponent<ActiveEventComponent>().LoadActiveEventAssembly(typeof(ActiveEventHandler)); //装载有效事件程序集
        }

        protected override void ProcedureEnter(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureActiveEventLuanch ProcedureEnter");
           
        }

        protected override void ProcedureLoop(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureActiveEventLuanch ProcedureLoop");

        }

        protected override void ProcedureExit(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureActiveEventLuanch ProcedureExit");
          
        }

        protected override void ProcedureDestroy(IFSM t_StateOwner)
        {
            UnityEngine.Debug.Log("ProcedureActiveEventLuanch ProcedureDestroy");
        }


    }
}