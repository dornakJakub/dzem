using dzem.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace dzem.Inventory
{
    public class CardUI : MonoBehaviour
    {
        public Image cardImage;
        
        private CardData _cardData;
        private PlayerDeck _playerDeck;

        public void Setup(CardData cardData, PlayerDeck playerDeck)
        {
            Debug.LogError(cardData.cardImage);
            _cardData = cardData;
            cardImage.sprite = _cardData.cardImage;
            _playerDeck = playerDeck;
        }

        public void OnUseCard()
        {
            _playerDeck.UseCard(_cardData);
        }
    }
}