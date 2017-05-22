/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework.Runtime.FSM
{
    public sealed class FSMEventArgs : GameBoxFrameworkEventArgs
    {
        public IFSM IFSM;
        public BaseFSMState LastState;
        public BaseFSMState State;
    }
}
