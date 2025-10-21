using UnityEngine;

namespace card_logic
{
    [CreateAssetMenu(fileName = "card", menuName = "Cards/Card")]
    public class CardData : ScriptableObject
    {
        public string cardName;
        public Sprite cardImage;
        public float dropChance = 1f;
        public Food food;
        public int points;
        public int ingCount;
        public bool unlocked = false;
        public bool isIng;
        public int milestone;
    }
}