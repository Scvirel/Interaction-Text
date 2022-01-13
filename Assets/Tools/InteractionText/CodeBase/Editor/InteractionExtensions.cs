using UnityEditor;

using UnityEngine;

namespace InteractionUI.EditorUtilities
{
    public static partial class InteractionExtensions
    {
        public static void SetParentEditorUtility(this GameObject parent, GameObject child)
        {
            GameObjectUtility.SetParentAndAlign(
               child,
               parent
               );
        }
    }
}