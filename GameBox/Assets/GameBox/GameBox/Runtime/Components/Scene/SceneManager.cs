/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/
using System.Collections;
using System.Collections.Generic;
using GameBoxFramework;
using UnityEngine;

namespace GameBox.Runtime.Component
{
    public sealed class SceneManager : MonoBehaviour, ISceneManager
    {
        /// <summary>
        /// 当前场景名字
        /// </summary>
        public string CurrentSceneName
        {
            get
            {
                return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            }
        }

        /// <summary>
        /// 当前场景数量
        /// </summary>
        public int CurrentScenesCount
        {
            get
            {
                return UnityEngine.SceneManagement.SceneManager.sceneCount;
            }
        }

        public event EventHandler LoadSuccessEventHandler;
        public event EventHandler LoadFailureEventHandler;
        public event EventHandler LoadUpdateEventHandler;
        public event EventHandler UnLoadSuccessEventHandler;
        public event EventHandler UnLoadFailureEventHandler;
        public event EventHandler UnLoadUpdateEventHandler;
        public event EventHandler MoveToSuccessEventHandler;
        public event EventHandler MoveToFailureEventHandler;
        public event EventHandler MoveToUpdateEventHandler;

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        public void LoadScene(string t_SceneName,LoadSceneModle t_LoadSceneModle = LoadSceneModle.Append, bool t_AllowSceneActivation = false)
        {
            UnityEngine.SceneManagement.Scene t_TargetScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(t_SceneName);

            if (!t_TargetScene.isLoaded)
            {
                StartCoroutine(LoadSceneAsync(t_SceneName,t_TargetScene, t_LoadSceneModle, t_AllowSceneActivation));
            }
            else
            {
                if (null != LoadFailureEventHandler)
                    LoadFailureEventHandler(this,new SceneEventArgs() { SceneName = t_SceneName, Process = 0f, Scene = t_TargetScene });
            }
        }
      
        /// <summary>
        /// 协程加载场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        /// <returns></returns>
        private IEnumerator LoadSceneAsync(string t_SceneName, UnityEngine.SceneManagement.Scene t_TargetScene, LoadSceneModle t_LoadSceneModle = LoadSceneModle.Append, bool t_AllowSceneActivation = false)
        {

            AsyncOperation t_Async = null;
            if (t_LoadSceneModle == LoadSceneModle.Append)
                t_Async=UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(t_SceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            else
                t_Async=UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(t_SceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);

            float t_Progres = 0;
            yield return new WaitForEndOfFrame();
            t_Async.allowSceneActivation = t_AllowSceneActivation;

            while (99.9f > t_Progres)
            {
                t_Progres = t_Async.progress * 100f;
                if (89.9f > t_Progres) //场景加载完毕前
                {
                    //t_Progres = Mathf.MoveTowards(t_Progres, t_Async.progress * 100f, Time.deltaTime*1000f);
                    
                    if (null != LoadUpdateEventHandler)
                        LoadUpdateEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process = t_Progres, Scene = t_TargetScene });
                }
                else //当场景加载完毕
                {
                    //t_Progres = Mathf.Lerp(t_Progres, 100f, Time.deltaTime);
                    t_Progres = 100f;
                    if (null != LoadUpdateEventHandler)
                        LoadUpdateEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process = t_Progres, Scene = t_TargetScene });

                }

                yield return null;
            }

            if (null != LoadUpdateEventHandler)
                LoadUpdateEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process = 100f, Scene = t_TargetScene });

            yield return new WaitForEndOfFrame(); //平滑过渡

            if (null != LoadSuccessEventHandler)
                LoadSuccessEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process = t_Progres, Scene = t_TargetScene });

            if(!t_AllowSceneActivation)
                t_Async.allowSceneActivation = !t_AllowSceneActivation;

            yield return t_Async;

        }

        /// <summary>
        /// 移动场景
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t_GameObjectList"></param>
        /// <param name="t_SceneName"></param>
        public void MoveToScene<T>(List<T> t_GameObjectList, string t_SceneName)
        {
            UnityEngine.SceneManagement.Scene t_TargetScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(t_SceneName);
            if (t_TargetScene.IsValid())
            {
                int t_GameObjectCount = t_GameObjectList.Count;
                for (int i = 0; i < t_GameObjectList.Count; i++)
                {
                    UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(t_GameObjectList[i] as GameObject, t_TargetScene);
                    if (null != MoveToUpdateEventHandler)
                        MoveToUpdateEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process =( 0 == i ? 0 : i / t_GameObjectCount)*100, Scene = t_TargetScene }  );
                }
                UnityEngine.SceneManagement.SceneManager.SetActiveScene(t_TargetScene);
                if (null != MoveToSuccessEventHandler)
                    MoveToSuccessEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process =100f, Scene = t_TargetScene });
            }
            else
            {
                //不是一个有效的场景
                if (null != MoveToFailureEventHandler)
                    MoveToFailureEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process = 0f, Scene = t_TargetScene });
            }
        }

        /// <summary>
        /// 卸载场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        public void UnLoadScene(string t_SceneName)
        {
            UnityEngine.SceneManagement.Scene t_TargetScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(t_SceneName);
            if (t_TargetScene.isLoaded)
            {
                if (t_TargetScene == UnityEngine.SceneManagement.SceneManager.GetActiveScene())
                {
                    //卸载该场景，那么该游戏物体也将会被销毁
                    if (null != UnLoadFailureEventHandler)
                        UnLoadFailureEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process = 0f, Scene = t_TargetScene });
                }
                else
                {
                    StartCoroutine(UnloadSceneYield(t_SceneName,t_TargetScene));
                }
            }
            else
            {
                // 场景没有被加载
                if (null != UnLoadFailureEventHandler)
                    UnLoadFailureEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process = 0f, Scene = t_TargetScene });
            }
        }

        /// <summary>
        /// 协程卸载场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        /// <returns></returns>
        private IEnumerator UnloadSceneYield(string t_SceneName, UnityEngine.SceneManagement.Scene t_TargetScene)
        {
            AsyncOperation t_Async = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(t_SceneName);
            if (null != UnLoadUpdateEventHandler)
                UnLoadUpdateEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process = t_Async.progress * 100f, Scene = t_TargetScene });
            if (t_Async.isDone)
            {
                if (null != UnLoadSuccessEventHandler)
                    UnLoadSuccessEventHandler(this, new SceneEventArgs() { SceneName = t_SceneName, Process = 100f, Scene = t_TargetScene });
            }

            yield return t_Async;
        }

        /// <summary>
        /// 合并场景
        /// </summary>
        /// <param name="t_SourceScene"></param>
        /// <param name="t_TargetScene"></param>
        public void MergeScene(string t_SourceSceneName, string t_TargetSceneName)
        {
            UnityEngine.SceneManagement.Scene t_SourceScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(t_SourceSceneName);
            UnityEngine.SceneManagement.Scene t_TargetScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(t_TargetSceneName);
            UnityEngine.SceneManagement.SceneManager.MergeScenes(t_SourceScene, t_TargetScene);         
        }

        /// <summary>
        /// 设置活动场景
        /// </summary>
        /// <param name="t_SceneName"></param>
        public void SetActiveScene(string t_SceneName)
        {
            UnityEngine.SceneManagement.Scene t_Scene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(t_SceneName);
            UnityEngine.SceneManagement.SceneManager.SetActiveScene(t_Scene);
        }
    }
}
