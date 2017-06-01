/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBoxFramework.Runtime.Event
{
    /// <summary>
    /// 有效事件的执行返回结果类
    /// </summary>
    public class ActiveEventResult
    {
        /// <summary>
        /// 有效事件映射的方法的名字
        /// </summary>
        public string ActiveEventMapMethodName { get; set; }

        /// <summary>
        /// 有效事件的返回结果
        /// </summary>
        public object ActiveEventReturn { get; set; }

    }
}
