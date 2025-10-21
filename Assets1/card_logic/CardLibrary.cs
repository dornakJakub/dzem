using System.Collections.Generic;
using UnityEngine;

namespace card_logic
{
    [CreateAssetMenu(fileName = "CardLibrary", menuName = "Cards/CardLibrary")]
    public class CardLibrary :  ScriptableObject
    {
        private static CardLibrary _instance;

        public static CardLibrary Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Load it from Resources (requires a copy in a "Resources" folder)
                    _instance = Resources.Load<CardLibrary>("CardLibrary");

                    if (_instance == null)
                    {
                        Debug.LogError("❌ CardLibrary not found in Resources! Please place one in a folder named 'Resources'.");
                    }
                }

                return _instance;
            }
        }

        public List<CardData> allCards = new List<CardData>();

        public CardData GetRandomCard()
        {
            float total = 0f;
            Debug.LogError(allCards);
            foreach (var card in allCards) total += card.dropChance;
            
            float roll = Random.value * total;
            foreach (var card in allCards)
            {
                
                roll -= card.dropChance;
                if (roll <= 0 && card.unlocked) return card;
            }
            
            //Fallback
            return allCards[Random.Range(0, allCards.Count)];
        }
        
        public void UnlockMilestone(int milestone)
        {
            foreach (var card in allCards)
            {
                if (!card.unlocked && card.milestone <= milestone)
                {
                    card.unlocked = true;
                }
            }
        }
    }
}