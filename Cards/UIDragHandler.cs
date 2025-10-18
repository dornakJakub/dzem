using UnityEngine;
using UnityEngine.EventSystems;

namespace dzem.Cards
{
    public class UIDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;
        private Canvas canvas;
        private Vector2 pointerOffset;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            if (canvas == null)
            {
                Debug.LogError("UIDraggable: No Canvas found in parent hierarchy.");
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // Convert pointer position to local point in parent space
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPointerPos
            );

            // Calculate offset so the UI element doesn't jump to pointer center
            pointerOffset = rectTransform.localPosition - (Vector3)localPointerPos;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (rectTransform == null) return;

            // Convert current pointer position to local space
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPointerPos
            );

            // Move the UI element to follow the pointer with offset
            rectTransform.localPosition = localPointerPos + pointerOffset;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            
        }
    }
}