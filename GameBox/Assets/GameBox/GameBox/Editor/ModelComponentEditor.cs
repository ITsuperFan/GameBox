using GameBox.Runtime.Component;
using System.Collections.Generic;
using UnityEditor;

namespace GameBox.Editor
{
    [CustomEditor(typeof(ModelComponent))]
    internal sealed class ModelComponentEditor : BaseGameBoxEditor
    {
        private HashSet<string> m_OpenedItems = new HashSet<string>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available during runtime only.", MessageType.Info);
                return;
            }

            ModelComponent t = (ModelComponent)target;

            if (PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("Model Count", t.ModelCount.ToString());

                if (null!=t.ModelNames)
                for (int i = 0; i < t.ModelNames.Length; i++)
                {
                        var t_Splits = t.ModelNames[i].Split('.');
                        bool lastState = m_OpenedItems.Contains(t.ModelNames[i]);
                        bool currentState = EditorGUILayout.Foldout(lastState, string.IsNullOrEmpty(t_Splits[t_Splits.Length-1]) ? "<Unnamed>" : t_Splits[t_Splits.Length - 1]);
                        if (currentState != lastState)
                        {
                            if (currentState)
                            {
                                m_OpenedItems.Add(t.ModelNames[i]);
                            }
                            else
                            {
                                m_OpenedItems.Remove(t.ModelNames[i]);
                            }
                        }
                        if (currentState)
                        {
                            EditorGUILayout.BeginVertical("box");
                            {
                                EditorGUILayout.LabelField("ModelValid", t.HasModel(t.ModelNames[i]).ToString());
                                EditorGUILayout.LabelField("ModelFullName", t.ModelNames[i]);
                            }
                            EditorGUILayout.EndVertical();
                        }
                }
                EditorGUILayout.Separator();
            }

            Repaint();
        }


    }
}
