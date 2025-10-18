
using System.Collections.Generic;
using dzem.Cards;
using UnityEngine;

namespace dzem.Inventory
{
    public class PlayerDeck :  MonoBehaviour
    {
        public const int MAX_CARDS = 7;
        public CardLibrary CardLibrary;
        public List<CardData> ActiveCards = new List<CardData>();
        public DeckUI deckUI;

        void Awake()
        {
            Debug.LogError("ASDAS");
            for (int i = 0; i < MAX_CARDS; i++)
            {
                AddRandomCard();
            }
        }

        public void AddRandomCard()
        {
            CardData randomCard = CardLibrary.GetRandomCard();
            if (randomCard != null)  ActiveCards.Add(randomCard);
            Debug.LogError("ADDED");
        }

        public void UseCard(CardData card)
        {
            if (ActiveCards.Contains(card))
            {
                ActiveCards.Remove(card);
                AddRandomCard();
            }
            else
            {
                Debug.LogError($"Card {card.name} is not in the list and has been used");
            }
        }
    }
}