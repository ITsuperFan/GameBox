/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework.Network
{
        /// <summary>
        /// INetwork的网络状态
        /// </summary>
        public enum NetworkStateType
        {
            UnKnow =0x00, //未知状态，用于异常处理
            Start = 0x69,//网络启动
            ReStart = 0x68,//网络重启
            Stop = 0x67,//网络关闭
            Sync = 0x66,//网络同步
            HeartBeat =0x65,//网络心跳检测
            Callback = 0x64, //网络回调
            Transparent=0x63 //透明传输
    }
}
