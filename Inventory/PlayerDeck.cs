
using System.Collections.Generic;
using Cards;
using UnityEngine;

namespace Inventory
{
    public class PlayerDeck
    {
        public const int MAX_CARDS = 7;
        public CardLibrary CardLibrary;
        public List<CardData> ActiveCards = new List<CardData>();
        public IEnumerable<CardData> ownedCards;

        void Start()
        {
            for (int i = 0; i < MAX_CARDS; i++)
            {
                AddRandomCard();
            }
        }

        public void AddRandomCard()
        {
            CardData randomCard = CardLibrary.getRandomCard();
            if (randomCard != null)  ActiveCards.Add(randomCard);
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