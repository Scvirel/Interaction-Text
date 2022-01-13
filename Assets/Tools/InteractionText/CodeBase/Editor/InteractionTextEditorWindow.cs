using TMPro;

using UnityEditor;

using UnityEngine;
using UnityEngine.UI;

namespace InteractionUI.EditorUtilities
{
    public static class InteractionTextEditorWindow
    {
        [MenuItem("GameObject/InteractionText/InteractionButton", false, 0)]
        private static void SpawnInteractionButton(MenuCommand command)
        {
            GameObject contextObj = command.context as GameObject;
            GameObject buttonObj = CreateInteractionElementRoot("InteractionButton", new Vector2(160f, 30f));
            GameObject textObj = CreateInteractionText("Button");

            InteractionButton buttonComponent = buttonObj.AddComponent<InteractionButton>();
            buttonObj.AddComponent<Image>().color = Color.white;

            buttonComponent.InteractionText = textObj.GetComponent<InteractionText>();

            buttonObj.SetParentEditorUtility(textObj);
            contextObj.SetParentEditorUtility(buttonObj);
        }

        private static GameObject CreateInteractionText(string textContent)
        {
            GameObject textObj = ObjectFactory.CreateGameObject("InteractionText");

            RectTransform rectTransform = textObj.AddComponent<RectTransform>();
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.sizeDelta = Vector2.zero;

            InteractionText textComponent = textObj.AddComponent<InteractionText>();
            textComponent.text = textContent;
            textComponent.color = Color.black;
            textComponent.horizontalAlignment = HorizontalAlignmentOptions.Center;
            textComponent.verticalAlignment = VerticalAlignmentOptions.Middle;

            return textObj;
        }

        private static GameObject CreateInteractionElementRoot(string name, Vector2 size)
        {
            GameObject obj = new GameObject(name);
            RectTransform rectTransform = obj.AddComponent<RectTransform>();
            rectTransform.sizeDelta = size;
            return obj;
        }  
    }
}