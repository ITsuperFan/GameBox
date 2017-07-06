/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/


namespace GameBox.Runtime.Component
{
    /// <summary>
    /// 场景事件类型
    /// </summary>
    public enum SceneEventType
    {
        /// <summary>
        /// 加载成功
        /// </summary>
        LoadSuccess,
        /// <summary>
        /// 加载失败
        /// </summary>
        LoadFailure,
        /// <summary>
        /// 加载中
        /// </summary>
        LoadUpdate,
        /// <summary>
        /// 卸载成功
        /// </summary>
        UnLoadSuccess,
        /// <summary>
        /// 卸载失败
        /// </summary>
        UnLoadFailure,
        /// <summary>
        /// 卸载中
        /// </summary>
        UnLoadUpdate,
        /// <summary>
        /// 移动成功
        /// </summary>
        MoveToSuccess,
        /// <summary>
        /// 移动失败
        /// </summary>
        MoveToFailure,
        /// <summary>
        /// 移动中
        /// </summary>
        MoveToUpdate,
    }
}