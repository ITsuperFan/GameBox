/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBoxFramework.Runtime.FSM
{
    public interface IFSM 
	{
        //Map 存储状态
        
        /// <summary>
        /// 状态机的名字
        /// </summary>
        string FSMName { get; }

        /// <summary>
        /// 状态机的持有者
        /// </summary>
        IFSMOwner FSMOwner { get; }




    }
}