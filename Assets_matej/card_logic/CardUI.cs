using UnityEngine;
using UnityEngine.UI;

namespace card_logic
{
    public class CardUI : MonoBehaviour
    {
        public Image cardImage;
        
        public CardData _cardData;

        public void Setup(CardData cardData)
        {
            Debug.LogError(cardData.cardImage);
            _cardData = cardData;
            cardImage.sprite = _cardData.cardImage;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}