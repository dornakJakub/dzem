using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace card_logic
{
    public class Serve:  MonoBehaviour
    {
        public List<CardData> cardList = new List<CardData>();
        
        public static Serve Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        public bool AddCard(CardData card)
        {
            if (cardList.Contains(card))
            {
                return false;
            }
            else
            {
                cardList.Add(card);
                return true;
            }
        }

        public void OnServe()
        {
            Debug.LogError("ve funkci");
            if (cardList.Count == 0) return;
            Debug.LogError("v listu jsou itemy");
            foreach (var card in cardList)
            {
                Debug.LogError("cyklus start");
                Debug.LogError(card.name);
                var cardUi = GetCardUIFromData(card);
                Debug.LogError(cardUi);
                cardUi.Destroy();
                PlayerDeck.Instance.AddRandomCard();
            }
            cardList.Clear();
            AudioManager.Instance.PlayServeSound();
            //AddScore(plate_points(cardList, all_food));
        }
        
        CardUI GetCardUIFromData(CardData data)
        {
            foreach (var cardUI in FindObjectsByType<CardUI>(FindObjectsSortMode.None))
                if (cardUI._cardData == data)
                    return cardUI;

            return null;
        }
    }
}