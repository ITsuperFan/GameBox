using GameBox.Runtime.Component;
using System.Collections.Generic;
using UnityEditor;

namespace GameBox.Editor
{
    [CustomEditor(typeof(RouteComponent))]
    internal sealed class RouteComponentEditor : BaseGameBoxEditor
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

            RouteComponent t = (RouteComponent)target;

            if (null != t.RouteNames)
            {
                Dictionary<string, List<string> > RouteTable = new Dictionary<string, List<string>>();
                for (int i = 0; i < t.RouteNames.Length; i++)
                {
                    var t_Splits = t.RouteNames[i].Split('@');
                    if (RouteTable.ContainsKey(t_Splits[0]))
                    {
                        RouteTable[t_Splits[0]].Add(string.Format("{0}->{1}", t_Splits[0], t_Splits[1]));
                    }
                    else
                    {
                        RouteTable.Add(t_Splits[0], new List<string>() { string.Format("{0}->{1}", t_Splits[0], t_Splits[1]) });
                    }
                }

                if (PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
                {
                    EditorGUILayout.LabelField("Route Count", t.RoutesCount.ToString());

                    if (null != t.RouteNames)
                    foreach (var route in RouteTable)
                    {
                        bool lastState = m_OpenedItems.Contains(route.Key);
                        bool currentState = EditorGUILayout.Foldout(lastState, string.IsNullOrEmpty(route.Key) ? "<Unnamed>" : route.Key);
                        if (currentState != lastState)
                        {
                            if (currentState)
                            {
                                m_OpenedItems.Add(route.Key);
                            }
                            else
                            {
                                m_OpenedItems.Remove(route.Key);
                            }
                        }
                        if (currentState)
                        {
                            EditorGUILayout.BeginVertical("box");
                            {
                                    for (int i = 0; i < route.Value.Count; i++)
                                    {
                                        EditorGUILayout.LabelField(i.ToString()+ "_Route", route.Value[i].ToString());
                                    }
                            }
                            EditorGUILayout.EndVertical();
                        }
                    }
                    EditorGUILayout.Separator();
                }

            }




            Repaint();
        }
    }
}
