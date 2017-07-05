/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

using GameBox.Runtime.Component;
using UnityEngine;
using UnityEngine.UI;

namespace Alan
{
    using GameBox;
    public class SceneDemo : MonoBehaviour 
	{
        [SerializeField]
        private Text m_TextProcess;

        private SceneComponent m_SceneComponent;

        private void Start()
        {

            m_SceneComponent =  GameBox.GetComponent<SceneComponent>();
            m_SceneComponent.Register(this);
            m_SceneComponent.LoadUpdateEventHandler += (o, e) => { m_TextProcess.text = (e as SceneEventArgs).SceneName + " : " + (e as SceneEventArgs).Process; };
        }

        [SceneEvent( SceneEventType.LoadSuccess)]
        private void SceneEventDemo1(object o,SceneEventArgs e)
        {
            Debug.Log("All " + e.SceneName+" : "+e.Process);
        }

        [SceneEvent(SceneEventType.LoadSuccess, "A")]
        private void SceneEventDemo2(object o, SceneEventArgs e)
        {
            Debug.Log("Single " + e.SceneName + " : " + e.Process);
        }

        private void OnGUI()
        {

            if (GUILayout.Button("Load A Scene"))
            {
                m_SceneComponent.LoadScene("A", LoadSceneModle.Append,true);

            }

            if (GUILayout.Button("Load B Scene"))
            {
                m_SceneComponent.LoadScene("B", LoadSceneModle.Append, true);

            }

            if (GUILayout.Button("Load C Scene"))
            {
                m_SceneComponent.LoadScene("C", LoadSceneModle.Append, true);

            }
        }


    }
}