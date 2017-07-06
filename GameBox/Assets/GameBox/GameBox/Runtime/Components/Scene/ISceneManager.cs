/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/
using GameBoxFramework;
using System.Collections.Generic;
namespace GameBox.Runtime.Component
{

    public interface ISceneManager
    {
        /// <summary>
        /// 成功加载场景
        /// </summary>
        event EventHandler LoadSuccessEventHandler;
        /// <summary>
        /// 加载场景失败
        /// </summary>
        event EventHandler LoadFailureEventHandler;
        /// <summary>
        /// 正在加载场景 / 参数为加载进度
        /// </summary>
        event EventHandler LoadUpdateEventHandler;

        /// <summary>
        /// 成功卸载场景
        /// </summary>
        event EventHandler UnLoadSuccessEventHandler;
        /// <summary>
        /// 卸载场景失败
        /// </summary>
        event EventHandler UnLoadFailureEventHandler;
        /// <summary>
        /// 正在卸载场景 / 参数为卸载进度
        /// </summary>
        event EventHandler UnLoadUpdateEventHandler;

        /// <summary>
        /// 成功移动游戏物体到目标场景
        /// </summary>
        event EventHandler MoveToSuccessEventHandler;
        /// <summary>
        /// 移动游戏物体到目标场景失败
        /// </summary>
        event EventHandler MoveToFailureEventHandler;
        /// <summary>
        /// 正在移动游戏物体到目标场景 / 参数为移动进度
        /// </summary>
        event EventHandler MoveToUpdateEventHandler;

        /// <summary>
        /// 当前场景名字
        /// </summary>
        string CurrentSceneName { get; }

        /// <summary>
        /// 当前场景数量
        /// </summary>
        int CurrentScenesCount { get; }
        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        /// <returns></returns>
        void LoadScene(string t_SceneName,LoadSceneModle t_LoadSceneModle= LoadSceneModle.Append, bool t_AllowSceneActivation = false);
        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        /// <returns></returns>
        void UnLoadScene(string t_SceneName);
        /// <summary>
        /// 将场景中的游戏物体移动到另外一个场景中
        /// </summary>
        void MoveToScene<T>(List<T> t_GameObjectList, string t_SceneName);
        /// <summary>
        /// 合并两个场景
        /// </summary>
        /// <param name="t_SourceScene">原场景</param>
        /// <param name="t_TargetScene">目标场景</param>
        void MergeScene(string t_SourceSceneName, string t_TargetSceneName);
     
        /// <summary>
        /// 设置活动场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        void SetActiveScene(string t_SceneName);
    }
}
