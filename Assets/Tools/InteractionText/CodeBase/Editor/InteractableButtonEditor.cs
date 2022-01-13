using UnityEditor;
using UnityEditor.UI;

namespace InteractionUI.EditorUtilities
{
    [CustomEditor(typeof(InteractionButton), true)]
    public sealed class InteractableButtonEditor : ButtonEditor
    {
        private SerializedProperty m_interactionTextProperty = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_interactionTextProperty = serializedObject.FindProperty("InteractionText");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            serializedObject.Update();
            EditorGUILayout.PropertyField(m_interactionTextProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}