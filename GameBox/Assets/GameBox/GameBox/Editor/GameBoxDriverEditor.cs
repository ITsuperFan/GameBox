using UnityEditor;

namespace GameBox.Editor
{
    [CustomEditor(typeof(GameBoxDriver))]
    internal sealed class GameBoxDriverEditor : BaseGameBoxEditor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GameBoxDriver t = (GameBoxDriver)target;
            EditorGUILayout.LabelField("GameBox Version",GameBoxEntry.Version);
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
