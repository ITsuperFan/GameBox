using UnityEditor;

namespace GameBox.Editor
{
    [CustomEditor(typeof(GameBoxMain))]
    internal sealed class GameBoxDriverEditor : BaseGameBoxEditor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GameBoxMain t = (GameBoxMain)target;
            EditorGUILayout.LabelField("GameBox Version",GameBox.Version);
        }

        private void OnEnable()
        {

        }

        protected override void OnCompileComplete()
        {

        }

        protected override void OnCompileStart()
        {

        }

    }
}
