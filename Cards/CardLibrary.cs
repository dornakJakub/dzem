using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(fileName = "CardLibrary", menuName = "Cards/CardLibrary")]
    public class CardLibrary :  ScriptableObject
    {
        public List<CardData> allCards = new List<CardData>();

        public CardData getRandomCard()
        {
            if (allCards.Count == 0) return null;

            float total = 0f;
            foreach (var card in allCards) total += card.dropChance;
            
            float roll = Random.value * total;
            foreach (var card in allCards)
            {
                roll -= card.dropChance;
                if (roll <= 0) return card;
            }
            
            //Fallback
            return allCards[Random.Range(0, allCards.Count)];
        }
    }
}