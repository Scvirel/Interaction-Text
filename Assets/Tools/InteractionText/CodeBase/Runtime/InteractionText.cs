using TMPro;

using UnityEngine;

namespace InteractionUI
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasRenderer))]
    [AddComponentMenu("UI/InteractionText", 51)]
    public sealed class InteractionText : TextMeshProUGUI
    {
        [SerializeField] private Color m_activeColor = default;
        [SerializeField] private Color m_disableColor = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            Init();
        }

        public void SetInteration(bool value)
        {
            base.color = value ? m_activeColor : m_disableColor;
        }

        private void Init()
        {
            m_activeColor = Color.white;
            m_disableColor = Color.white;
        }
    }
}