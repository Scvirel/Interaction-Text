using TMPro.EditorUtilities;

using UnityEditor;

using UnityEngine;

namespace InteractionUI.EditorUtilities
{
    [CustomEditor(typeof(InteractionText), true)]
    [CanEditMultipleObjects]
    public sealed class TMPInteractable_EditorPanelUI : TMP_EditorPanelUI
    {
        private SerializedProperty m_activeColorProperty = default;
        private SerializedProperty m_disableColorProperty = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_activeColorProperty = serializedObject.FindProperty("m_activeColor");
            m_disableColorProperty = serializedObject.FindProperty("m_disableColor");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            serializedObject.Update();

            DrawInteractionSettings();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawInteractionSettings()
        {
            Rect rect = EditorGUILayout.GetControlRect(false, 24);
            if (GUI.Button(rect, new GUIContent("<b>Interaction Settings</b>"), TMP_UIStyleManager.sectionHeader))
                InteractionFoldout.InteracationSettings = !InteractionFoldout.InteracationSettings;

            GUI.Label(
                rect,
                InteractionFoldout.InteracationSettings ? InteractionFoldout.LabelNames[0] : InteractionFoldout.LabelNames[1],
                TMP_UIStyleManager.rightLabel
                );

            if (InteractionFoldout.InteracationSettings)
            {
                EditorGUILayout.PropertyField(m_activeColorProperty);
                EditorGUILayout.PropertyField(m_disableColorProperty);
            }
        }

        private struct InteractionFoldout
        {
            public static bool InteracationSettings = default;
            public static string[] LabelNames = new string[2]
            {
                    "<i>(Click to collapse)</i> ",
                    "<i>(Click to expand)</i> "
            };
        }
    }
}