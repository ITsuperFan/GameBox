/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


using System;

namespace GameBoxFramework.Runtime.Procedure
{
    using GameBoxFramework.Runtime.FSM;

    public sealed class ProcedureManager :BaseModule ,IProcedureManager,IFSMOwner
    {

        private IFSM ProcedureFSM;

        public BaseProcedure CurrentProcedure { get; private set; }

        public BaseProcedure[] Procedures { get { return null; } }

        public void AddProcedure<T>() where T : BaseProcedure
        {
            
        }

        public void RemoveProcedure<T>() where T : BaseProcedure
        {
            
        }

        public void SetBootProcedure<T>() where T : BaseProcedure
        {
           
        }
        protected internal override void OnDestroy(IModuleManager t_IModuleManager)
        {
            
        }
        protected internal override void OnInit(IModuleManager t_IModuleManager)
        {
            ProcedureFSM = new FSM(this,"ProcedureFSM");
        }
        protected internal override void OnStart(IModuleManager t_IModuleManager)
        {
            
        }
        protected internal override void OnUpdate(IModuleManager t_IModuleManager)
        {
           
        }
        protected internal override void OnStop(IModuleManager t_IModuleManager)
        {

        }

    }
}