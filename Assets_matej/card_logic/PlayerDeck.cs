
using System.Collections.Generic;
using UnityEngine;

namespace card_logic
{
    public class PlayerDeck :  MonoBehaviour
    {
        public static PlayerDeck Instance { get; private set; }
        private const int MAX_CARDS = 7;
        public List<CardData> ActiveCards = new List<CardData>();

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
            for (var i = 0; i < MAX_CARDS; i++)
            {
                AddRandomCard();
            }
        }

        public void AddRandomCard()
        {
            CardData randomCard = CardLibrary.Instance.GetRandomCard();
            while (HasCard(randomCard))
            {
                randomCard = CardLibrary.Instance.GetRandomCard();
            }
            DeckUI.Instance.CreateCard(randomCard);
            ActiveCards.Add(randomCard);
        }

        public bool AddCard(CardData cardData)
        {
            if (HasCard(cardData))
            {
                return false;
            }
            ActiveCards.Add(cardData); 
            return true;
        }

        private bool HasCard(CardData cardData)
        {
            return ActiveCards.Contains(cardData);
        }
    }
}