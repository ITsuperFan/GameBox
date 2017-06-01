using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using GameBoxFramework.Utility;
using GameBoxFramework.Runtime.Procedure;
using GameBox.Runtime.Component;

namespace GameBox.Editor
{
    [CustomEditor(typeof(ProcedureManagerComponent))]
    internal sealed class ProcedureModuleNodeEditor : BaseGameBoxEditor
    {
        private SerializedProperty m_AvailableProcedureTypeNames = null; //对应ProcedureManagerComponent里面的m_AvailableProcedureTypeNames属性
        private SerializedProperty m_BootProcedureTypeName = null;//对应ProcedureManagerComponent里面的m_EntranceProcedureTypeName属性

        private string[] m_ProcedureTypeNames = null;
        private List<string> m_CurrentAvailableProcedureTypeNames = null; //当前在OnInspectorGUI面板上下拉选项的可选流程
        private int m_BootProcedureIndex = -1;//当前在OnInspectorGUI面板上的可选项的初始索引位置

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update(); //更新被序列化的对象上的数据

            ProcedureManagerComponent t = (ProcedureManagerComponent)target;

            if (string.IsNullOrEmpty(m_BootProcedureTypeName.stringValue))
            {
                EditorGUILayout.HelpBox("You must set the BootProcedure!", MessageType.Error);
            }
            else if (EditorApplication.isPlaying)
            {
                EditorGUILayout.LabelField("Current Procedure", t.CurrentProcedure == null ? "None" : t.CurrentProcedure.GetType().ToString());
            }

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                GUILayout.Label("Available Procedures", EditorStyles.boldLabel);
                if (m_ProcedureTypeNames.Length > 0)
                {
                    EditorGUILayout.BeginVertical("box");
                    {
                        foreach (string procedureTypeName in m_ProcedureTypeNames)
                        {
                            bool selected = m_CurrentAvailableProcedureTypeNames.Contains(procedureTypeName);
                            if (selected != EditorGUILayout.ToggleLeft(procedureTypeName, selected)) //绘制勾选框
                            {
                                if (!selected)
                                {
                                    m_CurrentAvailableProcedureTypeNames.Add(procedureTypeName);
                                    WriteAvailableProcedureTypeNames();
                                }
                                else if (procedureTypeName != m_BootProcedureTypeName.stringValue)
                                {
                                    m_CurrentAvailableProcedureTypeNames.Remove(procedureTypeName);
                                    WriteAvailableProcedureTypeNames();
                                }
                            }
                        }
                    }
                    EditorGUILayout.EndVertical();
                }
                else
                {
                    EditorGUILayout.HelpBox("There is no available procedure.", MessageType.Warning);
                }

                if (m_CurrentAvailableProcedureTypeNames.Count > 0)
                {
                    EditorGUILayout.Separator();

                    int selectedIndex = EditorGUILayout.Popup("Entrance Procedure", m_BootProcedureIndex, m_CurrentAvailableProcedureTypeNames.ToArray());
                    if (selectedIndex != m_BootProcedureIndex)
                    {
                        m_BootProcedureIndex = selectedIndex;
                        m_BootProcedureTypeName.stringValue = m_CurrentAvailableProcedureTypeNames[selectedIndex];
                    }
                }
                else
                {
                    EditorGUILayout.HelpBox("Select available procedures first.", MessageType.Info);
                }
            }
            EditorGUI.EndDisabledGroup();

            serializedObject.ApplyModifiedProperties();
        }

        protected override void OnCompileComplete()
        {
            base.OnCompileComplete();

            RefreshTypeNames();
        }

        private void OnEnable()
        {
            m_AvailableProcedureTypeNames = serializedObject.FindProperty("m_AvailableProcedureTypeNames"); //映射序列化对象
            m_BootProcedureTypeName = serializedObject.FindProperty("m_BootProcedureTypeName");//映射序列化对象

            RefreshTypeNames(); //刷新BaseProcedure的子类的TypeNames，然后修改序列化对象的值
        }


        /// <summary>
        /// 刷新BaseProcedure的子类的TypeNames
        /// </summary>
        private void RefreshTypeNames()
        {
            m_ProcedureTypeNames = TypeHelper.GetTypeNames(typeof(BaseProcedure));
            ReadAvailableProcedureTypeNames();

            int oldCount = m_CurrentAvailableProcedureTypeNames.Count;
            m_CurrentAvailableProcedureTypeNames = m_CurrentAvailableProcedureTypeNames.Where(x => m_ProcedureTypeNames.Contains(x)).ToList();
            if (m_CurrentAvailableProcedureTypeNames.Count != oldCount)
            {
                WriteAvailableProcedureTypeNames();
            }

            if (!string.IsNullOrEmpty(m_BootProcedureTypeName.stringValue))
            {
                m_BootProcedureIndex = m_CurrentAvailableProcedureTypeNames.IndexOf(m_BootProcedureTypeName.stringValue);
                if (m_BootProcedureIndex < 0)
                {
                    m_BootProcedureTypeName.stringValue = null;
                }
            }

            serializedObject.ApplyModifiedProperties(); //应用已经更改了的序列化属性
        }
        /// <summary>
        /// 读取AvailableProcedureTypeNames
        /// </summary>
        private void ReadAvailableProcedureTypeNames()
        {
            m_CurrentAvailableProcedureTypeNames = new List<string>();
            int count = m_AvailableProcedureTypeNames.arraySize;
            for (int i = 0; i < count; i++)
            {
                m_CurrentAvailableProcedureTypeNames.Add(m_AvailableProcedureTypeNames.GetArrayElementAtIndex(i).stringValue);
            }
        }

        /// <summary>
        /// 写入AvailableProcedureTypeNames
        /// </summary>
        private void WriteAvailableProcedureTypeNames()
        {     
            m_AvailableProcedureTypeNames.ClearArray(); //清除上一次更新TypeNames
            if (m_CurrentAvailableProcedureTypeNames == null) //如果清除数组后为空，那么直接退出
            {
                return;
            }
            m_CurrentAvailableProcedureTypeNames.Sort(); //把流程进行排序
            int count = m_CurrentAvailableProcedureTypeNames.Count;
            for (int i = 0; i < count; i++)
            {
                m_AvailableProcedureTypeNames.InsertArrayElementAtIndex(i); //清空数组对应索引里面的内容
                m_AvailableProcedureTypeNames.GetArrayElementAtIndex(i).stringValue = m_CurrentAvailableProcedureTypeNames[i]; //给序列化对象赋值为当前对应索引的流程
            }
        }
    }
}
