/*
* Copyright (c) 2008-2017 Mr-Alan, Inc.
* Mail: Mr.Alan.China@gmail.com 
* Mail: Mr.Alan.China@outlook.com
* Website: www.0x69h.com
*/

namespace GameBox.Editor
{
    /// <summary>
    /// 游戏框架 Inspector 抽象类。
    /// </summary>
    internal abstract class BaseGameBoxEditor : UnityEditor.Editor
    {
        /// <summary>
        /// 保存编译过程的中间变量
        /// </summary>
        private bool m_IsCompiling = false;

        /// <summary>
        /// 绘制事件。
        /// </summary>
        public override void OnInspectorGUI()
        {
            if (m_IsCompiling && !UnityEditor.EditorApplication.isCompiling)
            {
                m_IsCompiling = false;
                OnCompileComplete();
            }
            else if (!m_IsCompiling && UnityEditor.EditorApplication.isCompiling)
            {
                m_IsCompiling = true;
                OnCompileStart();
            }



        }

        /// <summary>
        /// 编译开始事件。
        /// </summary>
        protected virtual void OnCompileStart()
        {

        }

        /// <summary>
        /// 编译完成事件。
        /// </summary>
        protected virtual void OnCompileComplete()
        {

        }
    }
}
