using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace card_logic
{
    public class UIDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;
        private Canvas canvas;
        private Vector2 pointerOffset;
        private Vector3 originalPosition;
        
        [Header("Drop Zones")]
        private string[] validDropZoneTags = {"DropZone", "serve_zone", "deck_zone"};
        
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
                        if (validTag == "serve_zone")
                        {
                            var cardUi = GetComponent<CardUI>();
                            var cardData = cardUi._cardData;
                            if (Serve.Instance)
                            {
                                Debug.LogError("Serve existuje");
                            }
                            var isNew = Serve.Instance.AddCard(cardData);
                            if (isNew)
                            {
                                PlayerDeck.Instance.ActiveCards.Remove(cardData);
                            }
                            Debug.LogError($"deck: {PlayerDeck.Instance.ActiveCards.Count}");
                            Debug.LogError($"serve: {Serve.Instance.cardList.Count}");
                        } else if (validTag == "deck_zone")
                        {
                            var cardUi = GetComponent<CardUI>();
                            var cardData = cardUi._cardData;
                            var isNew = PlayerDeck.Instance.AddCard(cardData);
                            if  (isNew)
                            {
                                Serve.Instance.cardList.Remove(cardData);
                            }
                            Debug.LogError($"deck: {PlayerDeck.Instance.ActiveCards.Count}");
                            Debug.LogError($"serve: {Serve.Instance.cardList.Count}");
                        }

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