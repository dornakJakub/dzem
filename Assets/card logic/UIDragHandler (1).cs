using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace dzem.Cards
{
    public class UIDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;
        private Canvas canvas;
        private Vector2 pointerOffset;
        private Vector3 originalPosition;
        
        [Header("Drop Zones")]
        public string[] validDropZoneTags = {"DropZone"};
        
        [Header("Grid Settings")]
        public float gridSize = 100f; // Size of each grid cell in pixels
        public bool snapToGrid = true; // Changed back to true

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
            originalPosition = rectTransform.localPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            originalPosition = rectTransform.localPosition;
            AudioManager.Instance.PlayButtonClick();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPointerPos
            );

            pointerOffset = rectTransform.localPosition - (Vector3)localPointerPos;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (rectTransform == null) return;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPointerPos
            );

            Vector3 targetPosition = localPointerPos + pointerOffset;
            
            rectTransform.localPosition = targetPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            bool droppedInValidZone = IsOverValidDropZone(eventData);
            
            if (!droppedInValidZone)
            {
                ReturnToOriginalPosition();
            }
            else
            {
                // Snap to grid when dropped in valid zone
                AudioManager.Instance.PlayDragSound();
                if (snapToGrid)
                {
                    Vector3 snappedPosition = SnapToGrid(rectTransform.localPosition);
                    rectTransform.localPosition = snappedPosition;
                }
                Debug.Log("Dropped in valid zone!");
            }
        }

        private Vector3 SnapToGrid(Vector3 position)
        {
            float snappedX = Mathf.Round(position.x / gridSize) * gridSize;
            float snappedY = Mathf.Round(position.y / gridSize) * gridSize;
            return new Vector3(snappedX, snappedY, position.z);
        }

        private bool IsOverValidDropZone(PointerEventData eventData)
        {
            // Get ALL objects under cursor (even behind other objects)
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            // Check each object for valid tags
            foreach (RaycastResult result in results)
            {
                foreach (string validTag in validDropZoneTags)
                {
                    if (result.gameObject.CompareTag(validTag))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        private void ReturnToOriginalPosition()
        {
            rectTransform.localPosition = originalPosition;
        }
    }
}