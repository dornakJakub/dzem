using UnityEngine;

namespace dzem.Cards
{
    [CreateAssetMenu(fileName = "card", menuName = "Cards/Card")]
    public class CardData : ScriptableObject
    {
        public string cardName;
        public Sprite cardImage;
        public float dropChance = 1f;
    }
}