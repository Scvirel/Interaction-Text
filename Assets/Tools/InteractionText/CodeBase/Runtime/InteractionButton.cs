using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

namespace InteractionUI
{
    [AddComponentMenu("UI/InteractionButton", 50)]
    public sealed class InteractionButton : Button
    {
        public InteractionText InteractionText = default;

        protected override void DoStateTransition(SelectionState state, bool value)
        {
            base.DoStateTransition(state, value);
            InteractionText?.SetInteration(interactable);
        }
    }
}